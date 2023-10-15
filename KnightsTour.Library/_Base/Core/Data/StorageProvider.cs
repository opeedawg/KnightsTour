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
// File             : StorageProvider.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace KnightsTour
{
    /// <summary>
    /// The StorageProvided class.
    /// </summary>
    public static class StorageProvider
    {
        #region Declarations
        static string storageHandlerType = null;
        static string storageHandlerInitialization = null;
        static KnightsTour.CoreLibrary.IStorageHandler storageHandler = null;
        static Dictionary<string, List<dynamic>> fkCache = new Dictionary<string, List<dynamic>>();
        #endregion

        #region Properties
        /// <summary>
        /// The configured storage handler type.
        /// </summary>
        public static string StorageHandlerTypeString
        {
            get
            {
                if (storageHandlerType == null)
                {
                    storageHandlerType = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerType", "").ToUpper();
                }
                return storageHandlerType;
            }
            set
            {
                storageHandlerType = value.ToUpper();
            }
        }
        /// <summary>
        /// The configured storage handler initialization string.
        /// </summary>
        public static string StorageHandlerInitialization
        {
            get
            {
                if (storageHandlerInitialization == null)
                {
                    storageHandlerInitialization = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerInitialization", null);
                }
                return storageHandlerInitialization;
            }
            set
            {
                storageHandlerInitialization = value;
            }
        }
        /// <summary>
        /// Gets the storage handler types.
        /// </summary>
        public static KnightsTour.CoreLibrary.Enumerations.StorageHandlerType StorageHandlerType
        {
            get
            {
                if (StorageHandlerTypeString == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer.ToString().ToUpper())
                    return KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer;
                else if (StorageHandlerTypeString == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle.ToString().ToUpper())
                    return KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle;
                else if (StorageHandlerTypeString == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL.ToString().ToUpper())
                    return KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL;
                else if (StorageHandlerTypeString == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL.ToString().ToUpper())
                    return KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL;
                else
                    throw new Exception($"Unhandled Repository Handler: {storageHandlerType}");
            }
        }
        #endregion

        #region Methods
        /// <summary>Gets the repository.</summary>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TLite"></typeparam>
        /// <typeparam name="TPk">The data type of the primary key.</typeparam>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> GetRepository<T, TLite, TPk>(string userName)
            where T : KnightsTour.CoreLibrary.IEntity<TPk>, new()
            where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer)
                return new SQLServerRepository<T, TLite, TPk>(GetHandler(), userName);
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL)
                return new MySQLRepository<T, TLite, TPk>(GetHandler(), userName);
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle)
                return new OracleRepository<T, TLite, TPk>(GetHandler(), userName);
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL)
                return new PostgreSQLRepository<T, TLite, TPk>(GetHandler(), userName);
            else
                throw new Exception($"Unhandled Repository Handler: {storageHandlerType}");
        }
        /// <summary>Retrieves the concrete handler.</summary>
        /// <param name="storageHandlerTypeId">Optionally pass in the type desired.</param>
        /// <returns></returns>
        public static KnightsTour.CoreLibrary.IStorageHandler GetHandler(int? storageHandlerTypeId = null)
        {

            if (storageHandler == null)
            {
                //If not passed, get it from the configuration
                if (!storageHandlerTypeId.HasValue)
                    storageHandlerTypeId = (int)StorageHandlerType;

                if (storageHandlerTypeId == (int)KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer)
                    storageHandler = new SQLServerStorageHandler(StorageHandlerInitialization);
                else if (storageHandlerTypeId == (int)KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL)
                    storageHandler = new MySQLStorageHandler(StorageHandlerInitialization);
                else if (storageHandlerTypeId == (int)KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle)
                    storageHandler = new OracleStorageHandler(StorageHandlerInitialization);
                else if (storageHandlerTypeId == (int)KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL)
                    storageHandler = new PostgreSQLStorageHandler(StorageHandlerInitialization);
                else
                    throw new Exception($"Unhandled Storage Handler: {storageHandlerType}");
            }
            return storageHandler;
        }
        /// <summary>
        /// Returns a well formatted table name based off the storage handler type.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <returns>A formatted table name.</returns>
        public static string GetTableSQL(string tableName, string schema = "")
        {
            //Clean the column name first
            tableName = CleanSqlTerm(tableName);

            switch (StorageHandlerType)
            {
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL:
                    return $"\"{tableName}\"";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer:
                    if(string.IsNullOrEmpty(schema))
                        return $"[{tableName}]";
                    else
                        return $"[{schema}].[{tableName}]";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL:
                    return $"`{tableName}`";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle:
                    return $"\"{tableName}\"";
                default:
                    return tableName;
            }
        }
        /// <summary>
        /// Returns a well formatted column name based off the storage handler type.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>A formatted column name.</returns>
        public static string GetColumnSQL(string columnName)
        {
            //Clean the column name first
            columnName = CleanSqlTerm(columnName);

            switch (StorageHandlerType)
            {
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL:
                    return $"\"{columnName}\"";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL:
                    return $"`{columnName}`";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer:
                    return $"[{columnName}]";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle:
                    return $"\"{columnName}\"";
                default:
                    return columnName;
            }
        }
        static string CleanSqlTerm(string originalString)
        {
            originalString = originalString.Replace("[", "");
            originalString = originalString.Replace("]", "");
            originalString = originalString.Replace("`", "");
            originalString = originalString.Replace("\\", "");
            originalString = originalString.Replace("\"", "");
            originalString = originalString.Replace("'", "");

            return originalString;
        }
        /// <summary>Gets the data hash SQL.</summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unhandled Data Hash SQL for Storage handler {StorageHandlerType}</exception>
        public static string GetDataHashSQL(string tableName)
        {
            switch (StorageHandlerType)
            {
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL:
                    return $"SELECT pg_xact_commit_timestamp(xmin) FROM {GetTableSQL(tableName, "")} ORDER BY pg_xact_commit_timestamp(xmin) DESC LIMIT 1";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL:
                    return $"SELECT UNIX_TIMESTAMP(update_time) FROM information_schema.tables WHERE table_schema = database() AND table_name = '{tableName}' AND (SELECT UCASE(ENGINE) FROM information_schema.TABLES WHERE TABLE_SCHEMA = database() and TABLE_NAME = '{tableName}') = 'MYISAM'";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer:
                    return $"SELECT CHECKSUM_AGG(BINARY_CHECKSUM(*)) FROM {GetTableSQL(tableName, "dbo")} WITH (NOLOCK);";
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle:
                    return $"SELECT MAX(ORA_ROWSCN) FROM {GetTableSQL(tableName, "")}";
                default:
                    throw new Exception($"Unhandled Data Hash SQL for Storage handler {StorageHandlerType}");
            }
        }
        /// <summary>Gets the parameter prefix.</summary>
        /// <returns></returns>
        public static string GetParameterPrefix()
        {
            switch (StorageHandlerType)
            {
                case KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle:
                    return $":";
                default:
                    return "@";
            }
        }
        #endregion

        #region Unit test support methods
        /// <summary>
        /// Returns the entity attributes specific to the storage handler defined.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite"></typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <returns></returns>
        public static KnightsTour.CoreLibrary.EntityAttribute<TPk> GetEntityAttribute<T, TLite, TPk>() where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer)
                return GetSQLServerEntityAttribute<T, TLite, TPk>();
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL)
                return GetMySQLEntityAttribute<T, TLite, TPk>();
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL)
                return GetPostreSQLEntityAttribute<T, TLite, TPk>();
            else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle)
                return GetOracleEntityAttribute<T, TLite, TPk>();
            else
                throw new Exception($"Unhandled StorageHandlerType in GetEntityAttribute: '{StorageHandlerType.ToString()}'");
        }
        static KnightsTour.CoreLibrary.EntityAttribute<TPk> GetSQLServerEntityAttribute<T, TLite, TPk>() where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            string key = new T().TableName;
            string schema = new T().TableSchema;
            string pk = new T().PrimaryKeyField;
            string pkFormatted = new T().PrimaryKeyFieldFormatted;
            KnightsTour.CoreLibrary.EntityAttribute<TPk> entityAttribute = new KnightsTour.CoreLibrary.EntityAttribute<TPk>();
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new SQLServerRepository<T, TLite, TPk>("System");

            #region Count
            entityAttribute.RecordCount = repository.StorageHandler.GetValue<int>(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL(key, schema)}"
            });
            #endregion

            #region First Id
            entityAttribute.FirstId = default(TPk);
            if (entityAttribute.RecordCount > 0)
            {
                entityAttribute.FirstId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT TOP 1 {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} ASC"
                });
                entityAttribute.LastId = entityAttribute.FirstId;
            }
            #endregion

            #region Last Id
            if (entityAttribute.RecordCount > 1)
            {
                entityAttribute.LastId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT TOP 1 {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} DESC"
                });
            }
            #endregion

            #region Reflected field detection
            entityAttribute.HasIntField = false;
            entityAttribute.IntField = null;
            entityAttribute.HasStringField = false;
            entityAttribute.StringField = null;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!entityAttribute.HasStringField &&
                    property.CanWrite &&
                    property.PropertyType.FullName.Contains("System.String") &&
                    property.Name != "EntityName" &&
                    property.Name != "Id" &&
                    property.Name != "PrimaryKeyField" &&
                    property.Name != "UserName" &&
                    property.Name != pkFormatted)
        {
                    entityAttribute.HasStringField = true;
                    entityAttribute.StringField = property.Name;
                }
                else if (!entityAttribute.HasIntField &&
                    property.Name != pkFormatted &&
                    property.CanWrite &&
                    property.PropertyType.FullName.Contains("System.Int32") &&
                    !property.PropertyType.FullName.Contains("System.Nullable"))
                {
                    entityAttribute.HasIntField = true;
                    entityAttribute.IntField = property.Name;
                }

                if (entityAttribute.HasStringField && entityAttribute.HasIntField)
                    break;
            }
            #endregion

            return entityAttribute;
        }
        static KnightsTour.CoreLibrary.EntityAttribute<TPk> GetMySQLEntityAttribute<T, TLite, TPk>() where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            string key = new T().TableName;
            string schema = new T().TableSchema;
            string pk = new T().PrimaryKeyField;
            string pkFormatted = new T().PrimaryKeyFieldFormatted;
            KnightsTour.CoreLibrary.EntityAttribute<TPk> entityAttribute = new KnightsTour.CoreLibrary.EntityAttribute<TPk>();
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new MySQLRepository<T, TLite, TPk>("System");

            #region Count
            entityAttribute.RecordCount = repository.StorageHandler.GetValue<long>(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL(key, schema)}"
            });
            #endregion

            #region First Id
            entityAttribute.FirstId = default(TPk);
            if (entityAttribute.RecordCount > 0)
            {
                entityAttribute.FirstId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} ASC LIMIT 1"
                });
                entityAttribute.LastId = entityAttribute.FirstId;
            }
            #endregion

            #region Last Id
            if (entityAttribute.RecordCount > 1)
            {
                entityAttribute.LastId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} DESC LIMIT 1"
                });
            }
            #endregion

            #region Reflected field detection
            entityAttribute.HasIntField = false;
            entityAttribute.IntField = null;
            entityAttribute.HasStringField = false;
            entityAttribute.StringField = null;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!entityAttribute.HasStringField &&
                    property.CanWrite &&
                    property.Name != pkFormatted &&
                    property.PropertyType.FullName.Contains("System.String") &&
                    property.Name != "EntityName" &&
                    property.Name != "PrimaryKeyField" &&
                    property.Name != "UserName")
                {
                    entityAttribute.HasStringField = true;
                    entityAttribute.StringField = property.Name;
                }
                else if (!entityAttribute.HasIntField &&
                    property.Name != pkFormatted &&
                    property.CanWrite &&
                    property.PropertyType.FullName.Contains("System.Int32") &&
                    !property.PropertyType.FullName.Contains("System.Nullable"))
                {
                    entityAttribute.HasIntField = true;
                    entityAttribute.IntField = property.Name;
                }

                if (entityAttribute.HasStringField && entityAttribute.HasIntField)
                    break;
            }
            #endregion

            return entityAttribute;
        }
        static KnightsTour.CoreLibrary.EntityAttribute<TPk> GetPostreSQLEntityAttribute<T, TLite, TPk>() where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            string key = new T().TableName;
            string schema = new T().TableSchema;
            string pk = new T().PrimaryKeyField;
            string pkFormatted = new T().PrimaryKeyFieldFormatted;
            KnightsTour.CoreLibrary.EntityAttribute<TPk> entityAttribute = new KnightsTour.CoreLibrary.EntityAttribute<TPk>();
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new PostgreSQLRepository<T, TLite, TPk>("System");

            #region Count
            entityAttribute.RecordCount = repository.StorageHandler.GetValue<long>(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL(key, schema)}"
            });
            #endregion

            #region First Id
            entityAttribute.FirstId = default(TPk);
            if (entityAttribute.RecordCount > 0)
            {
                entityAttribute.FirstId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} ASC LIMIT 1"
                });
                entityAttribute.LastId = entityAttribute.FirstId;
            }
            #endregion

            #region Last Id
            if (entityAttribute.RecordCount > 1)
            {
                entityAttribute.LastId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} ORDER BY {StorageProvider.GetColumnSQL(pk)} DESC LIMIT 1"
                });
            }
            #endregion

            #region Reflected field detection
            entityAttribute.HasIntField = false;
            entityAttribute.IntField = null;
            entityAttribute.HasStringField = false;
            entityAttribute.StringField = null;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!entityAttribute.HasStringField &&
                    property.CanWrite &&
                    property.Name != pkFormatted &&
                    property.PropertyType.FullName.Contains("System.String") &&
                    property.Name != "EntityName" &&
                    property.Name != "PrimaryKeyField" &&
                    property.Name != "UserName")
                {
                    entityAttribute.HasStringField = true;
                    entityAttribute.StringField = property.Name;
                }
                else if (!entityAttribute.HasIntField &&
                    property.Name != pkFormatted &&
                    property.CanWrite &&
                    property.PropertyType.FullName.Contains("System.Int32") &&
                    !property.PropertyType.FullName.Contains("System.Nullable"))
                {
                    entityAttribute.HasIntField = true;
                    entityAttribute.IntField = property.Name;
                }

                if (entityAttribute.HasStringField && entityAttribute.HasIntField)
                    break;
            }
            #endregion

            return entityAttribute;
        }
        static KnightsTour.CoreLibrary.EntityAttribute<TPk> GetOracleEntityAttribute<T, TLite, TPk>() where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            string key = new T().TableName;
            string schema = new T().TableSchema;
            string pk = new T().PrimaryKeyField;
            string pkFormatted = new T().PrimaryKeyFieldFormatted;
            KnightsTour.CoreLibrary.EntityAttribute<TPk> entityAttribute = new KnightsTour.CoreLibrary.EntityAttribute<TPk>();
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new OracleRepository<T, TLite, TPk>("System");

            #region Count
            entityAttribute.RecordCount = long.Parse(repository.StorageHandler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(*) FROM {StorageProvider.GetTableSQL(key, schema)}"
            }).ToString());
            #endregion

            #region First Id
            entityAttribute.FirstId = default(TPk);
            if (entityAttribute.RecordCount > 0)
            {
                entityAttribute.FirstId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} WHERE ROWNUM <= 1 ORDER BY {StorageProvider.GetColumnSQL(pk)} ASC"
                });
                entityAttribute.LastId = entityAttribute.FirstId;
            }
            #endregion

            #region Last Id
            if (entityAttribute.RecordCount > 1)
            {
                entityAttribute.LastId = repository.StorageHandler.GetValue<TPk>(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"SELECT {StorageProvider.GetColumnSQL(pk)} FROM {StorageProvider.GetTableSQL(key, schema)} WHERE ROWNUM <= 1 ORDER BY {StorageProvider.GetColumnSQL(pk)} DESC"
                });
            }
            #endregion

            #region Reflected field detection
            entityAttribute.HasIntField = false;
            entityAttribute.IntField = null;
            entityAttribute.HasStringField = false;
            entityAttribute.StringField = null;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!entityAttribute.HasStringField &&
                    property.CanWrite &&
                    property.Name != pkFormatted &&
                    property.PropertyType.FullName.Contains("System.String") &&
                    property.Name != "EntityName" &&
                    property.Name != "PrimaryKeyField" &&
                    property.Name != "UserName")
                {
                    entityAttribute.HasStringField = true;
                    entityAttribute.StringField = property.Name;
                }
                else if (!entityAttribute.HasIntField &&
                    property.Name != pkFormatted &&
                    property.CanWrite &&
                    property.PropertyType.FullName.Contains("System.Int32") &&
                    !property.PropertyType.FullName.Contains("System.Nullable"))
                {
                    entityAttribute.HasIntField = true;
                    entityAttribute.IntField = property.Name;
                }

                if (entityAttribute.HasStringField && entityAttribute.HasIntField)
                    break;
            }
            #endregion

            return entityAttribute;
        }
        /// <summary>
        /// Returns valid FK values for a given entity and FK Name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite"></typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <param name="fkName"></param>
        /// <param name="maxRows"></param>
        /// <returns></returns>
        public static List<dynamic> GetFKValues<T, TLite, TPk>(string fkName, int maxRows = 3) where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            string cacheKey = $"{new T().EntityName}By{fkName}{maxRows}";
            if (!fkCache.ContainsKey(cacheKey))
            {
                if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer)
                    PopulateSQLServerFKValues<T, TLite, TPk>(cacheKey, fkName, maxRows);
                else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL)
                    PopulateMySQLFKValues<T, TLite, TPk>(cacheKey, fkName, maxRows);
                else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.PostgreSQL)
                    PopulatePostgresqlFKValues<T, TLite, TPk>(cacheKey, fkName, maxRows);
                else if (StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle)
                    PopulateOracleFKValues<T, TLite, TPk>(cacheKey, fkName, maxRows);
                else
                    throw new Exception($"Unhandled StorageHandlerType in GetEntityAttribute: '{StorageHandlerType.ToString()}'");
            }
            return fkCache[cacheKey];
        }
        /// <summary>
        /// Populates the SQL server fk values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite">The type of the lite.</typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fkName">Name of the fk.</param>
        /// <param name="maxRows">The maximum rows.</param>
        static void PopulateSQLServerFKValues<T, TLite, TPk>(string cacheKey, string fkName, int maxRows) where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new SQLServerRepository<T, TLite, TPk>("System");

            List<dynamic> fkValues = new List<dynamic>();
            string tableName = new T().TableName;
            string schema = new T().TableSchema;

            foreach (IDataRecord fkId in repository.StorageHandler.GetRecords(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT DISTINCT {StorageProvider.GetColumnSQL(fkName)} FROM {StorageProvider.GetTableSQL(tableName, schema)}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition
                {
                    SQLOrderBy = StorageProvider.GetColumnSQL(fkName),
                    Skip = 0,
                    Take = maxRows
                }
            }))
            {
                int fkValue = fkId.ValueAs<int>(fkName);
                if (fkValue > 0)
                    fkValues.Add(fkValue);
                else
                    fkValues.Add(null);
            }
            fkCache.Add(cacheKey, fkValues);
        }
        /// <summary>
        /// Populates my SQLFK values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite">The type of the lite.</typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fkName">Name of the fk.</param>
        /// <param name="maxRows">The maximum rows.</param>
        static void PopulateMySQLFKValues<T, TLite, TPk>(string cacheKey, string fkName, int maxRows) where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new MySQLRepository<T, TLite, TPk>("System");

            List<dynamic> fkValues = new List<dynamic>();
            string tableName = new T().TableName;
            string schema = new T().TableSchema;

            foreach (IDataRecord fkId in repository.StorageHandler.GetRecords(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT DISTINCT {StorageProvider.GetColumnSQL(fkName)} FROM {StorageProvider.GetTableSQL(tableName, schema)}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition
                {
                    SQLOrderBy = StorageProvider.GetColumnSQL(fkName),
                    Skip = 0,
                    Take = maxRows
                }
            }))
            {
                long fkValue = fkId.ValueAs<int>(fkName);
                if (fkValue > 0)
                    fkValues.Add(int.Parse(fkValue.ToString()));
                else
                    fkValues.Add(null);
            }
            fkCache.Add(cacheKey, fkValues);
        }
        /// <summary>
        /// Populates the postgresql fk values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite">The type of the lite.</typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fkName">Name of the fk.</param>
        /// <param name="maxRows">The maximum rows.</param>
        static void PopulatePostgresqlFKValues<T, TLite, TPk>(string cacheKey, string fkName, int maxRows) where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new PostgreSQLRepository<T, TLite, TPk>("System");

            List<dynamic> fkValues = new List<dynamic>();
            string tableName = new T().TableName;
            string schema = new T().TableSchema;

            foreach (IDataRecord fkId in repository.StorageHandler.GetRecords(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT DISTINCT {StorageProvider.GetColumnSQL(fkName)} FROM {StorageProvider.GetTableSQL(tableName, schema)}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition
                {
                    SQLOrderBy = StorageProvider.GetColumnSQL(fkName),
                    Skip = 0,
                    Take = maxRows
                }
            }))
            {
                int fkValue = fkId.ValueAs<int>(fkName);
                if (fkValue > 0)
                    fkValues.Add(fkValue);
                else
                    fkValues.Add(null);
            }
            fkCache.Add(cacheKey, fkValues);
        }
        /// <summary>
        /// Populates the oracle fk values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TLite">The type of the lite.</typeparam>
        /// <typeparam name="TPk">The primary key data type.</typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fkName">Name of the fk.</param>
        /// <param name="maxRows">The maximum rows.</param>
        static void PopulateOracleFKValues<T, TLite, TPk>(string cacheKey, string fkName, int maxRows) where T : KnightsTour.CoreLibrary.IEntity<TPk>, new() where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
        {
            KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repository = new OracleRepository<T, TLite, TPk>("System");

            List<dynamic> fkValues = new List<dynamic>();
            string tableName = new T().TableName;
            string schema = new T().TableSchema;

            foreach (IDataRecord fkId in repository.StorageHandler.GetRecords(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT DISTINCT {StorageProvider.GetColumnSQL(fkName)} FROM {StorageProvider.GetTableSQL(tableName, schema)}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition
                {
                    SQLOrderBy = StorageProvider.GetColumnSQL(fkName),
                    Skip = 0,
                    Take = maxRows
                }
            }))
            {
                int fkValue = fkId.ValueAs<int>(fkName);
                if (fkValue > 0)
                    fkValues.Add(fkValue);
                else
                    fkValues.Add(null);
            }
            fkCache.Add(cacheKey, fkValues);
        }
        #endregion
    }
}