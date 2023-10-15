// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : SQLServerStorageHandler.cs
// ************************************************************************

using KnightsTour.CoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KnightsTour
{
    /// <summary>
    /// Class SQL Server Storage Handler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.IStorageHandler" />
    public class SQLServerStorageHandler : KnightsTour.CoreLibrary.IStorageHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SQLServerStorageHandler "/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SQLServerStorageHandler (string connectionString)
        {
            ConnectionInformation = connectionString;

            //Default DB block sizes (number of rows to apply as a batch)
            InsertBlockSize = 500;
            DeleteBlockSize = 500;
            ReturnsDynamicObjects = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the default connection string.
        /// </summary>
        /// <value>The default connection string.</value>
        public string ConnectionInformation { get; set; }
        /// <summary>
        /// Gets or sets the size of the insert block.
        /// </summary>
        /// <value>The size of the insert block.</value>
        public int InsertBlockSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the delete block.
        /// </summary>
        /// <value>The size of the delete block.</value>
        public int DeleteBlockSize { get; set; }
        /// <summary>
        /// Does this handler return Dynamic Objects?
        /// </summary>
        public bool ReturnsDynamicObjects { get; set; }
        /// <summary>Gets the pk insert configuration.</summary>
        /// <value>The pk insert configuration.</value>
        public KnightsTour.CoreLibrary.Enumerations.InsertPKRule PKInsertConfiguration
        {
            get
            {
                return KnightsTour.CoreLibrary.Enumerations.InsertPKRule.AutoIncrement;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets a number of records from the storage.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>IEnumerable&lt;IDataRecord&gt;.</returns>
        public IEnumerable<dynamic> GetRecords(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<dynamic>>(getRecords, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, new object[] { statement }, 0);
        }
        /// <summary>
        /// Gets a number of records from storage.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>IEnumerable&lt;IDataRecord&gt;.</returns>
        IEnumerable<dynamic> getRecords(object[] arguments)
        {
            KnightsTour.CoreLibrary.StorageStatement statement = (KnightsTour.CoreLibrary.StorageStatement)arguments[0];
            ConfigureConnectionString(statement);

            if (
                statement.CommandType != CommandType.StoredProcedure && 
                statement.Parameter == null && 
                (statement.Parameters == null || statement.Parameters.Count == 0) && 
                Context.UseStoredProcedureIntegration &&
                Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "DxGeneralExecuteSqlGetAll")
                )
            {
                // Convert to a generic stored procedure usage syntax.
                statement.CommandType = CommandType.StoredProcedure;
                statement.Parameter = new KnightsTour.CoreLibrary.GenericParameter("@sql", statement.Statement);
                statement.Statement = "Dx_GeneralExecuteSql_GetAll";
            }

            using (SqlConnection connection = new SqlConnection(statement.ConnectionInformation))
            {
                using (SqlCommand command = CreateCommand(connection, statement))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return dataReader;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets number of records from storage.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>DataRow.</returns>
        public dynamic GetRecord(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            return MethodWrappers.CommonWrapper<dynamic>(getRecord, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, new object[] { statement }, 0);
        }
        /// <summary>
        /// Gets single record from storage.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>DataRow.</returns>
        dynamic getRecord(object[] arguments)
        {
            KnightsTour.CoreLibrary.IStorageStatement statement = (KnightsTour.CoreLibrary.IStorageStatement)arguments[0];
            ConfigureConnectionString(statement);
            using (SqlConnection connection = new SqlConnection(statement.ConnectionInformation))
            {
                using (SqlCommand command = CreateCommand(connection, statement))
                {
                    connection.Open();
                    DataSet ds = new DataSet("Single Result");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0].Rows[0];
                    else
                        return null;
                }
            }
        }
        /// <summary>
        /// Gets data set from storage.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetDataSet(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            try
            {
                ConfigureConnectionString(statement);
                using (SqlConnection connection = new SqlConnection(statement.ConnectionInformation))
                {
                    using (SqlCommand command = CreateCommand(connection, statement))
                    {
                        connection.Open();
                        DataSet ds = new DataSet("Dataset");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);

                        return ds;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, statement);
            }
            return null;
        }
        /// <summary>
        /// Executes the specified statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>System.Int32.</returns>
        public int Execute(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            int modifiedRecordCount = 0;
            try
            {
                ConfigureConnectionString(statement);
                using (SqlConnection connection = new SqlConnection(statement.ConnectionInformation))
                {
                    using (SqlCommand command = CreateCommand(connection, statement))
                    {
                        connection.Open();
                        modifiedRecordCount = command.ExecuteNonQuery();

                        return modifiedRecordCount;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, statement);
            }
            return modifiedRecordCount;
        }
        /// <summary>
        /// Gets single value from storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statement">The statement.</param>
        /// <returns>T.</returns>
        public T GetValue<T>(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            DataRow dataRow = GetRecord(statement);
            if (dataRow != null)
            {
                if (Convert.IsDBNull(dataRow[0]))
                    return default(T);
                else
                {
                    try
                    {
                        return (T)ChangeType(typeof(T), dataRow[0].ToString());
                    }
                    catch
                    { 
                        // Sometimes short values give us grief.
                        MethodInfo methodInfo = typeof(short).GetMethod("Parse", new Type[] { typeof(string) });
                        return (T)methodInfo.Invoke(typeof(short), new object[] { dataRow[0].ToString() });
                    }
                }
            }
            else
                return default(T);
        }
        static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }
        /// <summary>Adds the record.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="overrideStoredprocedureUsage">Never use stored procedures, required for unit testing.</param>
        /// <returns></returns>
        public TPk AddRecord<TPk>(KnightsTour.CoreLibrary.IEntity<TPk> entity, string connectionString = null, bool overrideStoredprocedureUsage = false)
        {
            try
            {
                IStorageStatement statement = entity.SQLInsertStatement;

                if (Context.UseStoredProcedureIntegration && !overrideStoredprocedureUsage)
                {
                    return GetValue<TPk>(statement);
                }
                else
                {
                    //Enhance the SQL
                    statement.ConnectionInformation = connectionString;
                    if (entity.PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.AutoIncrement)
                    {
                        string sql = statement.Statement;
                        //Log(statement);
                        sql = sql.Substring(0, sql.IndexOf(")") + 1) + " OUTPUT Inserted." + entity.PrimaryKeyField + " INTO @newId " + sql.Substring(sql.IndexOf("VALUES"));
                        sql = "DECLARE @newId TABLE (id int); " + sql + "; SELECT TOP 1 id FROM @newId;";
                        statement.Statement = sql;
                        TPk newId = GetValue<TPk>(statement);
                        //Debug.WriteLine($"*** RETURN VALUE (NEW ID) = {newId}");
                        return newId;
                    }
                    else
                    {
                        Execute(statement);
                        return entity.Id;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, entity.SQLInsertStatement);
            }

            return default(TPk);
        }
        /// <summary>
        /// Creates a where clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns>An Sql query specific to the database technology.</returns>
        public string GetWhereSql(EntityFilter filter)
        {
            string sql = "1 = 1";

            filter.Filters = filter.Filters.Where(f => !string.IsNullOrEmpty(f.Value)).ToList();

            foreach (SqlFilter whereClause in filter.Filters)
            {
                sql += $" AND {whereClause.GetSql}";
            }

            string textFilter = string.Empty;
            if (!string.IsNullOrEmpty(filter.TextFilter) && filter.TextColumns.Any())
            {
                foreach (string textCol in filter.TextColumns)
                    textFilter += $"{StorageProvider.GetColumnSQL(textCol)} LIKE '%{filter.TextFilter}%' OR ";
            }

            if (!string.IsNullOrEmpty(textFilter))
                textFilter = $" AND ({textFilter.Substring(0, textFilter.Length - 4)})";

            sql += textFilter;

            return sql;
        }
        /// <summary>
        /// Creates an order by clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <param name="addOrderBySql">A flag to determine of the actual ORDER BY text should be added to the query or not.</param>
        /// <returns></returns>
        public string GetOrderBySql(EntityFilter filter, bool addOrderBySql = true)
        {
            string sql = string.Empty;

            foreach (string orderClause in filter.OrderBys)
            {
                if (orderClause.Trim().Contains(" "))
                {
                    List<string> clauseParts = orderClause.Split(' ').ToList();
                    sql += StorageProvider.GetColumnSQL(clauseParts[0]);
                    if (!string.IsNullOrEmpty(clauseParts[1]))
                    {
                        string dir = clauseParts[1].ToUpper();
                        if (dir == "ASC" || dir == "DESC")
                        {
                            sql += $" {dir}";
                        }
                    }
                }
                else
                {
                    sql += StorageProvider.GetColumnSQL(orderClause);
                }

                sql += ", ";
            }

            if (!string.IsNullOrEmpty(sql))
            {
                sql = sql.Substring(0, sql.Length - 2);
                if (addOrderBySql)
                    sql = $"ORDER BY {sql}";
            }
            else
            {
                if (addOrderBySql)
                    sql = $"ORDER BY {StorageProvider.GetColumnSQL(filter.DefaultSortColumn)} ASC";
            }

            return sql;
        }
        /// <summary>
        /// Creates a pagination clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns>An Sql query specific to the database technology.</returns>
        public string GetPaginationSql(EntityFilter filter)
        {
            return $"OFFSET {filter.PageIndex * filter.PageSize} ROWS FETCH NEXT {filter.PageSize} ROWS ONLY";
        }
        /// <summary>
        /// Creates the generic parameters that match the where clause filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns></returns>
        public List<IParameter> GetParameters(EntityFilter filter)
        {
            List<IParameter> parameters = new List<IParameter>();
            filter.Filters = filter.Filters.Where(f => !string.IsNullOrEmpty(f.Value)).ToList();
            foreach (SqlFilter whereClause in filter.Filters)
            {
                parameters.Add(whereClause.GetParameter);
            }

            return parameters;
        }
        #endregion

        #region Private support methods
        /// <summary>
        /// Logs the specified statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        void Log(IStorageStatement statement)
        {
            Debug.WriteLine(string.Empty);
            Debug.WriteLine($">>> {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
            Debug.WriteLine($">>> SQL = {statement.Statement}");
            if(string.IsNullOrEmpty(statement.ConnectionInformation))
                Debug.WriteLine($">>> DB CONNECTION = {ConnectionInformation}");
            else
                Debug.WriteLine($">>> DB CONNECTION = {statement.ConnectionInformation}");

            if (statement.Parameters != null && statement.Parameters.Count > 0)
            {
                Debug.WriteLine($">>> PARAMETERS = {statement.Parameters.Count}");
                foreach (IParameter parameter in statement.Parameters)
                    Debug.WriteLine($">>>     {parameter.Name} = {parameter.Value.ToString()}");
            }
        }
        /// <summary>
        /// Configures the connection string.
        /// </summary>
        /// <param name="statement">The statement.</param>
        void ConfigureConnectionString(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            if (string.IsNullOrEmpty(statement.ConnectionInformation))
                statement.ConnectionInformation = ConnectionInformation;
        }
        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="statement">The statement.</param>
        /// <returns>SqlCommand.</returns>
        SqlCommand CreateCommand(SqlConnection connection, KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            if (statement.CommandType == CommandType.Text)
                command.CommandText = DecorateCommandText(statement);
            else
                command.CommandText = statement.Statement;

            //Utility.LogSQL(command.CommandText);
            command.CommandType = statement.CommandType;
            command.CommandTimeout = statement.TimeoutSeconds;
            if (statement.Parameter != null)
                statement.Parameters.Add(statement.Parameter);

            //Convert the generic parameters to a strong typed parameter.
            foreach (KnightsTour.CoreLibrary.IParameter parameter in statement.Parameters)
            {
                //Assume if the @ is not present, it was missed.  Perhaps make this configurable?
                if (!parameter.Name.StartsWith("@"))
                    parameter.Name = "@" + parameter.Name;

                if(parameter.Value == DBNull.Value && !string.IsNullOrEmpty(parameter.DataType) && parameter.DataType == "byte[]")
                    command.Parameters.Add(new SqlParameter(parameter.Name, SqlDbType.VarBinary, -1)).Value = parameter.Value;
                else
                    command.Parameters.Add(new SqlParameter(parameter.Name, parameter.Value));
            }

            return command;
        }
        string DecorateCommandText(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            StringBuilder sql = new StringBuilder(statement.Statement);
            //Where clause
            if (statement.Condition.Exists())
            {
                //Where
                if (!string.IsNullOrEmpty(statement.Condition.SQLWhere))
                    sql.Append($" WHERE {statement.Condition.SQLWhere}");

                //Order by
                if (!string.IsNullOrEmpty(statement.Condition.SQLOrderBy))
                    sql.Append($" ORDER BY {statement.Condition.SQLOrderBy}");
                else if (statement.Condition.Skip.HasValue || statement.Condition.Take.HasValue)
                    sql.Append($" ORDER BY CURRENT_DATE");

                //Group by
                if (!string.IsNullOrEmpty(statement.Condition.SQLGroupBy))
                    sql.Append($" GROUP BY {statement.Condition.SQLGroupBy}");

                //Having
                if (!string.IsNullOrEmpty(statement.Condition.SQLHaving))
                    sql.Append($" HAVING {statement.Condition.SQLHaving}");

                //Skip
                if (statement.Condition.Skip.HasValue)
                    sql.Append($" OFFSET {statement.Condition.Skip.ToString()} ROWS");

                //Take
                if (statement.Condition.Take.HasValue)
                {
                    if (!statement.Condition.Skip.HasValue)
                        sql.Append($" OFFSET 0 ROWS");
                    sql.Append($" FETCH NEXT {statement.Condition.Take.ToString()} ROWS ONLY");
                }
            }
            return sql.ToString();
        }
        #endregion
    }
}