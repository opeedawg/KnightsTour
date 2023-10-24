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
// Created          : October 21, 2023 9:55:34 AM
// File             : MySQLRepository.cs
// ************************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using KnightsTour.CoreLibrary;

namespace KnightsTour
{
    /// <summary>
    /// The SQL Server Repository class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TLite"></typeparam>
    /// <typeparam name="TPk">The data type of the primary key for this class.</typeparam>
    public class MySQLRepository<T, TLite, TPk> : KnightsTour.CoreLibrary.IRepository<T, TLite, TPk>
        where T : KnightsTour.CoreLibrary.IEntity<TPk>, new()
        where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>
    {
        #region Constructor
        /// <summary>
        /// Creates a new MySql repository with the default configured handler.
        /// </summary>
        /// <param name="userName">The user operating this repository.</param>
        public MySQLRepository(string userName)
        {
            if (StorageProvider.StorageHandlerType == KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL)
                StorageHandler = StorageProvider.GetHandler();
            else
                throw new Exception($"The configured StorageHandlerType is either missing or not set to {KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.MySQL.ToString()}");
            UserName = userName;
        }
        /// <summary>
        /// Creates SQL Server Repository given the passed handler.
        /// </summary>
        /// <param name="storageHandler"></param>
        /// <param name="userName">The user operating this repository.</param>
        public MySQLRepository(KnightsTour.CoreLibrary.IStorageHandler storageHandler, string userName)
        {
            StorageHandler = storageHandler;
            UserName = userName;
        }
        #endregion

        #region Declarations
        string tableName = null;
        string tableSchema = null;
        string primaryKey = null;
        string dbPKDataType = null;
        #endregion

        #region Properties
        /// <summary>
        /// Storage Handler property.
        /// </summary>
        public KnightsTour.CoreLibrary.IStorageHandler StorageHandler { get; set; }
        /// <summary>
        /// Table name property.
        /// </summary>
        string TableName
        {
            get
            {
                if (tableName == null)
                {
                    tableName = EntityMapper.GetDbEntityName(new T().EntityName);
                }
                return tableName;
            }
        }
        /// <summary>
        /// Table schema property.
        /// </summary>
        string TableSchema
        {
            get
            {
                if (tableSchema == null)
                {
                    tableSchema = new T().TableSchema;
                }
                return tableSchema;
            }
        }
        /// <summary>
        /// Primary key property.
        /// </summary>
        string PrimaryKey
        {
            get
            {
                if (primaryKey == null)
                {
                    primaryKey = new T().PrimaryKeyField;
                }
                return primaryKey;
            }
        }
        /// <summary>
        /// Primary key property.
        /// </summary>
        string PrimaryKeyFormatted
        {
            get
            {
                if (primaryKey == null)
                {
                    primaryKey = new T().PrimaryKeyFieldFormatted;
                }
                return primaryKey;
            }
        }
        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Returns the database techology specific data type given the generic primary key type of the class.
        /// </summary>
        string DBPKDataType
        {
            get
            {
                if (string.IsNullOrEmpty(dbPKDataType))
                {
                    string languageType = typeof(TPk).Name;
                    if (languageType.StartsWith("Nullable"))
                    {
                        if (typeof(TPk).FullName.Contains("System.DateTime"))
                            languageType = "DateTime";
                        else if (typeof(TPk).FullName.Contains("System.Int64"))
                            languageType = "Int64";
                        else if (typeof(TPk).FullName.Contains("System.Int32"))
                            languageType = "Int32";
                        else if (typeof(TPk).FullName.Contains("System.Int16"))
                            languageType = "Int16";
                        else if (typeof(TPk).FullName.Contains("System.Guid"))
                            languageType = "Guid";
                        else if (typeof(TPk).FullName.Contains("System.Decimal"))
                            languageType = "Decimal";
                        else if (typeof(TPk).FullName.Contains("System.Double"))
                            languageType = "Double";
                        else if (typeof(TPk).FullName.Contains("System.TimeSpan"))
                            languageType = "TimeSpan";
                        else if (typeof(TPk).FullName.Contains("System.Boolean"))
                            languageType = "Boolean";
                        else
                            languageType = "String";
                    }

                    if (languageType == "DateTime")
                        dbPKDataType = "datetime";
                    else if (languageType == "Int64" || languageType == "Int32" || languageType == "Int16" || languageType == "TimeSpan")
                        dbPKDataType = "int";
                    else if (languageType == "Decimal" || languageType == "Double")
                        dbPKDataType = "float";
                    else if (languageType == "Boolean")
                        dbPKDataType = "bit";
                    else
                        dbPKDataType = "varchar";
                }

                return dbPKDataType;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets T entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Type T</returns>
        public T GetById(TPk id)
        {
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(PrimaryKey)} = {StorageProvider.GetParameterPrefix()}id",
                Parameter = new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}id", id)
            };
            return GetRecordFromStorage(statement);
        }
        /// <summary>
        /// Gets a number of T using the specified force refresh flag.
        /// </summary>
        /// <returns>Type enumeration of T records.</returns>
        public IEnumerable<T> GetAll()
        {
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL(TableName, TableSchema)}"
            };
            return GetListFromStorage(statement);
        }
        /// <summary>
        /// Gets a number of T entities using the specified retrieval conditions.
        /// </summary>
        /// <param name="conditions">The retrieval conditions.</param>
        /// <returns>Type enumeration of T records.</returns>
        public IEnumerable<T> GetAll(KnightsTour.CoreLibrary.IRetrievalCondition conditions)
        {
            if (conditions.Columns == "*")
                conditions.Columns = $"{StorageProvider.GetTableSQL(TableName, TableSchema)}.*";

            string sql = $"SELECT {conditions.Columns} FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} ";

            if (conditions != null)
            {
                Dictionary<string, string> joinTableAliases = new Dictionary<string, string>();
                if (conditions.TableJoins != null)
                {
                    int jointTableIndex = 1;
                    foreach (KnightsTour.CoreLibrary.TableJoin join in conditions.TableJoins)
                    {
                        string joinTable = StorageProvider.GetTableSQL(join.JoinTable + join.PrimaryColumn, TableSchema);
                        string joinTableAlias = StorageProvider.GetTableSQL($"JoinTableAlias{jointTableIndex}", TableSchema);
                        joinTableAliases.Add(joinTable, joinTableAlias);

                        sql += $"{join.JoinType} JOIN {joinTable} AS {joinTableAlias} ON {joinTableAlias}.{StorageProvider.GetColumnSQL(join.JoinColumn)} = {StorageProvider.GetTableSQL(TableName, TableSchema)}.{StorageProvider.GetColumnSQL(join.PrimaryColumn)} ";
                        jointTableIndex++;
                    }
                }

                if (!string.IsNullOrEmpty(conditions.SQLWhere))
                {
                    //Replace any join table aliases
                    foreach (string tableName in joinTableAliases.Keys)
                        conditions.SQLWhere = conditions.SQLWhere.Replace(tableName, joinTableAliases[tableName]);

                    sql += $"WHERE {conditions.SQLWhere} ";
                }

                if (!string.IsNullOrEmpty(conditions.SQLOrderBy))
                {
                    //Replace any join table aliases
                    foreach (string tableName in joinTableAliases.Keys)
                        conditions.SQLOrderBy = conditions.SQLOrderBy.Replace(tableName, joinTableAliases[tableName]);

                    sql += $"ORDER BY {conditions.SQLOrderBy} ";
                }

                //Skip and take can only be applied if there is an order by statement
                if (conditions.Skip.HasValue && conditions.Take.HasValue)
                    sql += $"LIMIT {conditions.Skip}, {conditions.Take} ";
                else if (conditions.Skip.HasValue && !conditions.Take.HasValue)
                    sql += $"LIMIT {conditions.Skip}, 1000000 ";
                else if (!conditions.Skip.HasValue && conditions.Take.HasValue)
                    sql += $"LIMIT {conditions.Take}";

                sql = sql.Trim();
            }

            return GetListFromStorage(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
        }
        /// <summary>
        /// Gets a number of T entities using the specified foreign key and enumeration of ids.
        /// </summary>
        /// <param name="foreignKeyName">The retrieval conditions.</param>
        /// <param name="ids">The retrieval conditions.</param>
        /// <param name="filter">The optioanl filter.</param>
        /// <returns>Type enumeration of T records.</returns>
        public IEnumerable<T> GetByFKs<TFk>(string foreignKeyName, IEnumerable<TFk> ids, KnightsTour.CoreLibrary.IRetrievalCondition filter = null)
        {
            string sqlStatement = $"SELECT * FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(foreignKeyName)}";
            if (ids.Count() == 1)
            {
                if (ids.ToList()[0] != null)
                {
                    if(ids.ToList()[0].GetType().Name == "String")
                        sqlStatement += $" = '{ids.ToList()[0]}'";
                    else
                        sqlStatement += $" = {ids.ToList()[0]}";
                }
                else
                    sqlStatement += $" IS NULL";
            }
            else
                sqlStatement += $" IN {ids.ToSQLList()}";

            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = sqlStatement,
                Condition = filter
            };
            return GetListFromStorage(statement);
        }
        /// <summary>
        /// Gets the T entities for the specified ids.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<T> GetByIds(IEnumerable<TPk> ids)
        {
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(PrimaryKey)} IN {ids.ToSQLList<TPk>()}"
            };
            return GetListFromStorage(statement);
        }
        /// <summary>
        /// Inserts number of entities, specifying the block size for the bulk operation.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Insert(IEnumerable<T> entities, int blockSize)
        {
            //Initialize response object
            List<T> entitiesList = entities.ToList();
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"{TableName} insert.");

            //Optionally audit this fetch previous to execution
            Guid prefetchGuid = Context.AuditHandler.PreInsert(TableName, JsonConvert.SerializeObject(entities), UserName);

            if (entitiesList.Count == 1)
            {
                #region Single Insert
                T entity = entitiesList[0];
                TPk newPrimaryKey = StorageHandler.AddRecord<TPk>(entity);
                if (newPrimaryKey != null)
                {
                    entity.SetPrimaryKey(newPrimaryKey);
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsert, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, TableName, newPrimaryKey.ToString());
                }
                else
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsertFailure, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, TableName);
                response.DataObject = entitiesList[0];
                #endregion
            }
            else
            {
                #region Bulk Insert
                int insertTotal = 0;
                int batchCount = 0;
                StringBuilder sql = new StringBuilder();
                List<TPk> newIds = new List<TPk>();
                List<TPk> batchIds = null;
                if (entitiesList.Count > 0)
                {
                    foreach (T entity in entitiesList)
                    {
                        if (!entity.IsNew)
                        {
                            response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_InsertSkipped_NotNew, KnightsTour.CoreLibrary.Enumerations.MessageType.Information, TableName);
                        }
                        else
                        {
                            if (batchCount == 0)
                            {
                                sql = new StringBuilder(entity.SQLInsertBulkHeader);
                                sql.Append($" VALUES ");
                            }
                            sql.Append(entity.SQLInsertBulkRow + ",");
                            batchCount++;
                        }

                        //Time to insert a batch?
                        if (batchCount % blockSize == 0 && batchCount > 0)
                        {
                            batchCount = 0;
                            sql.Remove(sql.Length - 1, 1); //Remove the last comma
                            batchIds = FromInsertSQL(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql.ToString() }, batchCount);
                            insertTotal += batchIds.Count;
                            newIds.AddRange(batchIds);
                        }
                    }

                    //This happens if there are more records to insert but not enough to do as a batch.
                    if (batchCount > 0)
                    {
                        sql.Remove(sql.Length - 1, 1); //Remove the last comma
                        batchIds = FromInsertSQL(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql.ToString() }, batchCount);
                        insertTotal += batchIds.Count;
                        newIds.AddRange(batchIds);
                    }

                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsertTotal, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, insertTotal.ToString(), entitiesList.Count.ToString(), TableName);
                }
                //Append the new ids to the action response object
                response.Data.Add("Ids", newIds);
                #endregion
            }

            //Optionally audit this fetch post execution
            Context.AuditHandler.PostInsert(TableName, prefetchGuid, response, UserName);

            return response;
        }
        /// <summary>
        /// Updates number of entities, specifying the block size for the bulk operation.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Update(IEnumerable<T> entities)
        {
            List<T> entitiesList = entities.ToList();
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"{TableName} update.");
            int totalCount = entitiesList.Count;
            int updateCount = 0;

            //Optionally audit this fetch previous to execution
            Guid prefetchGuid = Context.AuditHandler.PreUpdate(TableName, JsonConvert.SerializeObject(entities), UserName);

            foreach (T entity in entitiesList)
            {
                if (entity.IsModified())
                {
                    int singleUpdateCount = StorageHandler.Execute(entity.SQLUpdateStatement);
                    if (singleUpdateCount > 0)
                    {
                        response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdate, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, singleUpdateCount.ToString(), TableName);
                    }
                    else
                    {
                        response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateFailure, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, TableName);
                    }
                    updateCount += singleUpdateCount;
                }
                else
                {
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_UpdateSkipped_NotModified, KnightsTour.CoreLibrary.Enumerations.MessageType.Information);
                }
            }

            if (totalCount == 1)
            {
                response.DataObject = entitiesList[0];
            }
            else if (totalCount > 0)
            {
                response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateTotal, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, updateCount.ToString(), totalCount.ToString(), TableName);
            }
            else
            {
                response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_NoOperation, KnightsTour.CoreLibrary.Enumerations.MessageType.Information);
            }

            //Optionally audit this fetch post execution
            Context.AuditHandler.PostUpdate(TableName, prefetchGuid, response, UserName);
            
            return response;
        }
        /// <summary>
        /// Deletes number of entities, specifying the block size of the operation.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<TPk> ids, int blockSize)
        {
            List<TPk> idList = ids.ToList();
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"{TableName} delete.");

            //Optionally audit this fetch previous to execution
            Guid prefetchGuid = Context.AuditHandler.PreDelete(TableName, JsonConvert.SerializeObject(ids), UserName);

            if (idList.Count == 1)
            {
                #region Single Delete
                int deleteCount = StorageHandler.Execute(new KnightsTour.CoreLibrary.StorageStatement
                {
                    Statement = $"DELETE FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(PrimaryKey)} = {StorageProvider.GetParameterPrefix()}id",
                    Parameter = new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}id", idList[0])
                });
                if (deleteCount > 0)
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDelete, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, deleteCount.ToString(), TableName);
                else
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDeleteFailure, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, TableName);
                response.DataObject = idList[0];
                #endregion
            }
            else
            {
                #region Bulk Delete
                while (idList.Count > 0)
                {
                    int takeSize = Math.Min(blockSize, idList.Count);
                    List<TPk> subIdList = idList.GetRange(0, takeSize);
                    int deleteCount = StorageHandler.Execute(new KnightsTour.CoreLibrary.StorageStatement
                    {
                        Statement = $"DELETE FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(PrimaryKey)} IN {subIdList.ToSQLList()}"
                    });
                    response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDeleteTotal, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, deleteCount.ToString(), idList.Count.ToString(), TableName);
                    idList.RemoveRange(0, takeSize);
                }
                #endregion
            }

            //Optionally audit this fetch post execution
            Context.AuditHandler.PostDelete(TableName, prefetchGuid, response, UserName);

            return response;
        }
        /// <summary>Deletes the by fk.</summary>
        /// <param name="fkColumnName">Name of the fk column.</param>
        /// <param name="fkId">The fk identifier.</param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse DeleteByFK<TFk>(string fkColumnName, TFk fkId)
        {
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"{TableName} delete by FK.");

            //Optionally audit this fetch previous to execution
            Guid prefetchGuid = Context.AuditHandler.PreDelete(TableName, $"{fkColumnName}={fkId}", UserName);

            int deleteCount = StorageHandler.Execute(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"DELETE FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(fkColumnName)} = {StorageProvider.GetParameterPrefix()}id",
                Parameter = new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}id", fkId)
            });
            if (deleteCount > 0)
                response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDelete, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, deleteCount.ToString(), TableName);
            else
                response.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_NoOperation, KnightsTour.CoreLibrary.Enumerations.MessageType.Information);
            response.DataObject = fkId;

            //Optionally audit this fetch post execution
            Context.AuditHandler.PostDelete(TableName, prefetchGuid, response, UserName);

            return response;
        }
        /// <summary>Gets the table hash.</summary>
        /// <returns>The table hash.</returns>
        public DateTime GetLastTableUpdate()
        {
            return StorageHandler.GetValue<DateTime>(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT update_time FROM information_schema.tables WHERE table_schema = database() AND table_name = '{TableName}' AND (SELECT UCASE(ENGINE) FROM information_schema.TABLES WHERE TABLE_SCHEMA = database() and TABLE_NAME = '{TableName}') = 'MYISAM'"
            });
        }
        /// <summary>Deletes the object doing a full cascade delete of all the related dependencies.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="whereClause">The optional where condition to apply.</param>
        /// <param name="pk">The where clause.</param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse DeleteCascade<TFk>(TFk id, string whereClause = null, string pk = null)
        {
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse();

            Guid prefetchGuid = new Guid();
            bool topLayer = false;
            int rowsDeleted = 0;
            EntityMetaData meta = new EntityMetaData(TableName, UserName);
            if (whereClause == null)
            {
                //Optionally audit this fetch previous to execution
                topLayer = true;
                prefetchGuid = Context.AuditHandler.PreDelete(TableName, $"{id}", UserName);
                whereClause = $"FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(PrimaryKey)} = {id.SafeSQL<TFk>()}";

                //Any further dependencies?  (A special case on the first iteration)
                foreach (RelatedEntityMetaData dependency in meta.Dependencies)
                {
                    string dependencyWhereClause = $"FROM {StorageProvider.GetTableSQL(dependency.Logic.TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(dependency.Column)} = {id.SafeSQL<TFk>()}";
                    response.Append(dependency.Logic.DeleteCascade(id, dependencyWhereClause, dependency.Logic.PKColumn));
                }
            }
            else
            {
                //Recursively check any child dependencies.
                foreach (RelatedEntityMetaData dependency in meta.Dependencies)
                {
                    string dependencyWhereClause = $"FROM {StorageProvider.GetTableSQL(dependency.Logic.TableName, TableSchema)} WHERE {StorageProvider.GetColumnSQL(dependency.Column)} IN (SELECT {StorageProvider.GetColumnSQL(pk)} {whereClause})";

                    //This stops recursive loops when there are self referencing columns on the table.
                    if (dependency.Logic.TableName != TableName)
                        response.Append(dependency.Logic.DeleteCascade(id, dependencyWhereClause, dependency.Logic.PKColumn));
                    else
                    {
                        //Finally delete the actual record after all the other dependencies have been deleted.
                        rowsDeleted = StorageHandler.Execute(new KnightsTour.CoreLibrary.StorageStatement
                        {
                            Statement = $"DELETE {dependencyWhereClause}"
                        });

                        response.Messages.Add(new KnightsTour.CoreLibrary.Message($"{rowsDeleted} rows deleted from {dependency.Logic.TableName}.", KnightsTour.CoreLibrary.Enumerations.MessageType.Information));
                    }
                }
            }

            //Finally delete the actual record after all the other dependencies have been deleted.
            rowsDeleted = StorageHandler.Execute(new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"DELETE {whereClause}"
            });

            response.Messages.Add(new KnightsTour.CoreLibrary.Message($"{rowsDeleted} rows deleted from {TableName}.", KnightsTour.CoreLibrary.Enumerations.MessageType.Information));

            //Optionally audit this fetch post execution
            if (topLayer)
                Context.AuditHandler.PostDelete(TableName, prefetchGuid, response, UserName);

            return response;
        }
        /// <summary>
        /// Gets all the entities with the filter applied.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<T> GetAllExtended(KnightsTour.CoreLibrary.EntityFilter filter)
        {
          KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();
          if (Context.UseStoredProcedureIntegration)
          {
            statement = new KnightsTour.CoreLibrary.StorageStatement()
            {
              CommandType = System.Data.CommandType.StoredProcedure,
              Statement = new T().GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType.GetAllExtended),
              Parameters = new List<KnightsTour.CoreLibrary.IParameter>() {
                new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}Filter", GetWhereSql(filter)),
                new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}OrderBy", GetOrderBySql(filter)),
                new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}PageIndex", filter.PageIndex),
                new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}PageSize", filter.PageSize),
              }
            };
          }
          else
          {
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {GetWhereSql(filter)} {GetOrderBySql(filter, true)} {GetPaginationSql(filter)}",
                    Parameters = GetParameters(filter)
            };
          }

          return GetListFromStorage(statement);
        }
        public int GetCount(KnightsTour.CoreLibrary.EntityFilter filter)
        {
          KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();
          if (Context.UseStoredProcedureIntegration)
          {
            statement = new KnightsTour.CoreLibrary.StorageStatement()
            {
              CommandType = System.Data.CommandType.StoredProcedure,
              Statement = new T().GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType.GetCount),
              Parameters = new List<KnightsTour.CoreLibrary.IParameter>() {
                new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}Filter", GetWhereSql(filter)),
              }
            };
          }
          else
          {
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
              Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL(TableName, TableSchema)} WHERE {GetWhereSql(filter)}",
              Parameters = GetParameters(filter)
            };
          }

          return GetValueFromStorage<int>(statement);
        }
        public List<KnightsTour.CoreLibrary.IParameter> GetParameters(EntityFilter filter)
        {
            List<IParameter> parameters = new List<IParameter>();
            filter.Filters = filter.Filters.Where(f => !string.IsNullOrEmpty(f.Value)).ToList();
            foreach (KnightsTour.CoreLibrary.SqlFilter whereClause in filter.Filters)
            {
                parameters.Add(whereClause.GetParameter);
            }

            return parameters;
        }        

        public string GetWhereSql(KnightsTour.CoreLibrary.EntityFilter filter)
        {
            string sql = "1 = 1";

            filter.Filters = filter.Filters.Where(f => !string.IsNullOrEmpty(f.Value)).ToList();

            foreach (KnightsTour.CoreLibrary.SqlFilter whereClause in filter.Filters)
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
        public string GetOrderBySql(KnightsTour.CoreLibrary.EntityFilter filter, bool addOrderBySql = false)
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
        public string GetPaginationSql(KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return $"LIMIT {filter.PageIndex * filter.PageSize}, {filter.PageSize}";
        }
        #endregion

        #region Overrides of the above functions
        /// <summary>
        /// Retrieves a list of T matching the function passed.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            return GetAll().Where(filter);
        }
        /// <summary>
        /// Gets a number of entities for the specified foreign key and id.
        /// </summary>
        /// <param name="foreignKeyName"></param>
        /// <param name="id"></param>
        /// <param name="filter">The optional filter.</param>
        /// <returns></returns>
        public IEnumerable<T> GetByFK<TFk>(string foreignKeyName, TFk id, KnightsTour.CoreLibrary.IRetrievalCondition filter = null)
        {
            return GetByFKs<TFk>(foreignKeyName, new List<TFk>() { id }, filter);
        }
        /// <summary>
        /// Inserts T entity into storage.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Insert(T entity)
        {
            return Insert(new List<T>() { entity }, StorageHandler.InsertBlockSize);
        }
        /// <summary>
        /// Inserts a number of entities into the storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Insert(IEnumerable<T> entities)
        {
            return Insert(entities, StorageHandler.InsertBlockSize);
        }
        /// <summary>
        /// Updates a T entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Update(T entity)
        {
            return Update(new List<T>() { entity });
        }
        /// <summary>
        /// Delete a T entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(T entity)
        {
            return Delete(new List<TPk>() { entity.Id }, StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Delete a number of entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<T> entities)
        {
            return Delete(entities.Where(e => !e.IsNew).Select(e => e.Id), StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Delete a number of entities using the specified block size.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<T> entities, int blockSize)
        {
            return Delete(entities.Where(e => !e.IsNew).Select(e => e.Id), blockSize);
        }
        /// <summary>
        /// Delete the entity with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(TPk id)
        {
            return Delete(new List<TPk>() { id }, StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Delete the entities with the specified ids.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<TPk> ids)
        {
            return Delete(ids, StorageHandler.DeleteBlockSize);
        }
        #endregion

        #region Private support methods
        /// <summary>Support method for bulk inserts.</summary>
        /// <param name="insertStatement"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        List<TPk> FromInsertSQL(KnightsTour.CoreLibrary.IStorageStatement insertStatement, int rowCount)
        {
            try
            {
                StorageHandler.Execute(insertStatement);
                //Since this is an insert, we need to further decorate the SQL to get the ids back
                insertStatement.Statement = $"SELECT LAST_INSERT_ID();";

                TPk firstNewId = StorageHandler.GetValue<TPk>(insertStatement);
                List<TPk> ids = new List<TPk>();
                for (int i = 0; i < rowCount; i++)
                {
                    ids.Add(firstNewId);
                }

                return ids;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, insertStatement);
            }
            return null;
        }
        /// <summary>
        /// Support method for bulk inserts.
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        List<T> GetListFromStorage(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            try
            {

                //Optionally audit this fetch previous to execution
                Guid prefetchGuid = Context.AuditHandler.PreFetch(new T().EntityName, UserName);

                IEnumerable<dynamic> records = StorageHandler.GetRecords(statement);
                List<T> entities = new List<T>();
                if (records != null)
                {
                    foreach (dynamic record in records)
                    {
                        T entity = (T)Activator.CreateInstance(typeof(T), record); //Instantiates the class with the proper constructor
                        entities.Add(entity);
                    }
                }

                //Optionally audit this fetch post execution
                Context.AuditHandler.PostFetch(new T().EntityName, prefetchGuid, entities.Count, UserName);

                return entities;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, statement);
            }
            return null;
        }
        /// <summary>
        /// Gets a record from the storage.
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        T GetRecordFromStorage(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            try
            {
                T entity = default(T);
                //Optionally audit this fetch previous to execution
                Guid prefetchGuid = Context.AuditHandler.PreFetch(TableName, UserName);

                dynamic record = StorageHandler.GetRecord(statement);
                if (record != null)
                {
                    entity = (T)Activator.CreateInstance(typeof(T), record); //Instantiates the class with the proper constructor
                }

                //Optionally audit this fetch post execution
                Context.AuditHandler.PostFetch(TableName, prefetchGuid, record == null ? 0 : 1, UserName);

                return entity;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleDataException(exception, statement);
            }
            return default(T);
        }
        /// <summary>
        /// Decorates storage statement.
        /// </summary>
        /// <param name="statement"></param>
        void DecorateStorageStatement(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
            if (string.IsNullOrEmpty(statement.ConnectionInformation))
                statement.ConnectionInformation = StorageHandler.ConnectionInformation;
        }
        T GetValueFromStorage<T>(KnightsTour.CoreLibrary.IStorageStatement statement)
        {
          try
          {
            //Optionally audit this fetch previous to execution
            Guid prefetchGuid = Context.AuditHandler.PreFetch(TableName, UserName);

            T result = StorageHandler.GetValue<T>(statement);

            //Optionally audit this fetch post execution
            Context.AuditHandler.PostFetch(TableName, prefetchGuid, 1, UserName);

            return result;
          }
          catch (Exception exception)
          {
            Context.ExceptionHandler.HandleDataException(exception, statement);
          }

          return default(T);
        }
      #endregion
    }
}