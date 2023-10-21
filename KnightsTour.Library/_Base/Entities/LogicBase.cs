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
// File             : LogicBase.cs
// ************************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Xml.Serialization;
using KnightsTour.CoreLibrary;

namespace KnightsTour
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TLite">The type of the lite.</typeparam>
    /// <typeparam name="TPk">The primary key data type.</typeparam>
    public abstract class LogicBase<T, TLite, TPk> : KnightsTour.CoreLibrary.IRepository<T, TLite, TPk>, KnightsTour.CoreLibrary.IEntityLogic<T, TLite, TPk>
        where T : KnightsTour.CoreLibrary.IEntity<TPk>, new()
        where TLite : KnightsTour.CoreLibrary.IEntityLite<TPk>, new()
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="LogicBase{T, TLite}"/> class.</summary>
        /// <param name="entityName"></param>
        /// <param name="userName"></param>
        public LogicBase(Enumerations.EntityName entityName, string userName)
        {
            EntityName = entityName;
            UserName = userName;
        }
        /// <summary>Initializes a new instance of the <see cref="LogicBase{T, TLite}"/> class.</summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="userName"></param>
        public LogicBase(Enumerations.EntityName entityName, KnightsTour.CoreLibrary.IStorageHandler handler, string userName)
        {
            EntityName = entityName;
            StorageHandler = handler;
            UserName = userName;
        }
        #endregion

        #region Declarations
        KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> repositoryHandler = null; // Private repository handler used for lazy loading
        KnightsTour.CoreLibrary.IStorageHandler storageHandler = null; // Private storage handler used for lazy loading
        #endregion Declarations

        #region Properties
        /// <summary>Gets the name of the entity.</summary>
        /// <value>The name of the entity.</value>
        [JsonIgnore]
        [XmlIgnore]
        public Enumerations.EntityName EntityName { get; private set; }
        /// <summary>Gets a value indicating whether [use cache].</summary>
        /// <value>
        ///   <c>true</c> if [use cache]; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        [XmlIgnore]
        public bool UseCache { get; private set; }
        /// <summary>
        /// Gets or sets the storage repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IRepository<T, TLite, TPk> Repository
        {
            get
            {
                if (repositoryHandler == null)
                {
                    repositoryHandler = StorageProvider.GetRepository<T, TLite, TPk>(UserName);
                }
                return repositoryHandler;
            }
            set
            {
                repositoryHandler = value;
            }
        }
        /// <summary>
        /// Gets or sets the storage handler.
        /// </summary>
        /// <value>
        /// The storage handler.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageHandler StorageHandler
        {
            get
            {
                if (storageHandler == null)
                {
                    storageHandler = Repository.StorageHandler;
                }
                return storageHandler;
            }
            set
            {
                storageHandler = value;
            }
        }
        /// <summary>Gets the name of the table.</summary>
        /// <value>The name of the table.</value>
        public string TableName
        {
            get
            {
                return EntityMapper.EntityNameTransformation[new T().EntityName];
            }
        }
        /// <summary>Gets the name of the table.</summary>
        /// <value>The name of the table.</value>
        public string PKColumn
        {
            get
            {
                return new T().PrimaryKeyField;
            }
        }
        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public string UserName { get; set; }
        #endregion

        #region SELECT Methods
        public IEnumerable<T> GetAllExtended(KnightsTour.CoreLibrary.EntityFilter filter)
        {
          return MethodWrappers.CommonWrapper<IEnumerable<T>>(getAllExtended, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        public int GetCount(KnightsTour.CoreLibrary.EntityFilter filter)
        {
          return MethodWrappers.CommonWrapper<int>(getCount, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        public string GetWhereSql(KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return MethodWrappers.CommonWrapper<string>(getWhereSql, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        public string GetOrderBySql(KnightsTour.CoreLibrary.EntityFilter filter, bool addOrderBySql = false)
        {
            return MethodWrappers.CommonWrapper<string>(getOrderBySql, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter, addOrderBySql }, 0);
        }
        public string GetPaginationSql(KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return MethodWrappers.CommonWrapper<string>(getPaginationSql, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        public List<IParameter> GetParameters(KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return MethodWrappers.CommonWrapper<List<IParameter>>(getParameters, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        /// <summary>
        /// Returns all the available tList.
        /// </summary>
        /// <returns>A list of <see cref="T"/>s.</returns>
        /// <example>
        /// <code>
        /// List&lt;T&gt; tList = new TLogic().GetAll();
        /// foreach(T t in tList)
        /// {
        ///     Console.WriteLine(t.TId);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetAll()
        {
            return GetAll(false);
        }
        /// <summary>
        /// Returns all the available tList.
        /// </summary>
        /// <param name="forceRefresh">Force a storage refresh or not.</param>
        /// <returns>A list of <see cref="T"/>s.</returns>
        public IEnumerable<T> GetAll(bool forceRefresh = false)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getAll, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { forceRefresh }, 0);
        }
        /// <summary>
        /// The privately wrapped implementation of the GetAll method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private IEnumerable<T> getAll(object[] arguments)
        {
            // Convert arguments from generic call handler
            bool forceRefresh = (bool)arguments[0];

            IEnumerable<T> tList = null;

            tList = Repository.GetAll();

            // Apply the column filter and return the results
            return tList;
        }
        /// <summary>
        /// Returns all the available tList.
        /// </summary>
        /// <param name="filter">The filter to apply to the collection.</param>
        /// <returns>A list of <see cref="T"/>s filtered by the filter.</returns>T  
        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getAllByFilter, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { filter }, 0);
        }
        /// <summary>
        /// The privately wrapped implementation of the GetAll(function) method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private IEnumerable<T> getAllByFilter(object[] arguments)
        {
            // Convert arguments from generic call handler
            Func<T, bool> filter = (Func<T, bool>)arguments[0];

            return GetAll().Where(filter);

        }
        /// <summary>
        /// Returns all the available tList based on the condition supplied.
        /// </summary>
        /// <param name="condition">The condition to apply to the collection.</param>
        /// <returns>A list of <see cref="T"/>s filtered by the filter.</returns>
        public IEnumerable<T> GetAll(KnightsTour.CoreLibrary.IRetrievalCondition condition)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getAllWithConditions, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { condition }, 0);
        }
        private int getCount(object[] arguments)
        {
          // Convert arguments from generic call handler
          KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];

          int count = Repository.GetCount(filter);

          // Apply the column filter and return the results
          return count;
        }
        private string getWhereSql(object[] arguments)
        {
            // Convert arguments from generic call handler
            KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];

            string sql = Repository.GetWhereSql(filter);

            // Apply the column filter and return the results
            return sql;
        }
        private string getOrderBySql(object[] arguments)
        {
            // Convert arguments from generic call handler
            KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];
            bool addOrderBySql = (bool)arguments[1];

            string sql = Repository.GetOrderBySql(filter, addOrderBySql);

            // Apply the column filter and return the results
            return sql;
        }
        private string getPaginationSql(object[] arguments)
        {
            // Convert arguments from generic call handler
            KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];

            string sql = Repository.GetPaginationSql(filter);

            // Apply the column filter and return the results
            return sql;
        }       
        private List<IParameter> getParameters(object[] arguments)
        {
            // Convert arguments from generic call handler
            KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];

            List<IParameter> parameters = Repository.GetParameters(filter);

            // Apply the column filter and return the results
            return parameters;
        }        
        private IEnumerable<T> getAllExtended(object[] arguments)
        {
          // Convert arguments from generic call handler
          KnightsTour.CoreLibrary.EntityFilter filter = (KnightsTour.CoreLibrary.EntityFilter)arguments[0];

          IEnumerable<T> tList = null;

          tList = Repository.GetAllExtended(filter);

          // Apply the column filter and return the results
          return tList;
        }
        /// <summary>
        /// The privately wrapped implementation of the GetAll(condition) method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private IEnumerable<T> getAllWithConditions(object[] arguments)
        {
            KnightsTour.CoreLibrary.IRetrievalCondition retrievalConditions = (KnightsTour.CoreLibrary.IRetrievalCondition)arguments[0];

            IEnumerable<T> tList = Repository.GetAll(retrievalConditions).ToList();

            // Apply Column filter and return the accounts
            return tList;

        }
        /// <summary>
        /// Retrieves a single T by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the T to retrieve.</param>
        /// <returns><see cref="T"/>.</returns>
        /// <example>
        /// <code>
        /// T t = new TLogic().GetById(1);
        /// if(t != null)
        /// {
        ///     Console.WriteLine(t.Id);
        /// }
        /// </code>
        /// </example>
        public T GetById(TPk id)
        {
            return MethodWrappers.CommonWrapper<T>(getById, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { id }, 0);
        }
        /// <summary>
        /// The privately wrapped implementation of the GetById(id) method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private T getById(object[] arguments)
        {
            // Convert arguments from generic object list
            TPk id = (TPk)arguments[0];

            // Initialize response object
            T t = default(T);
            t = Repository.GetById(id);

            if (t != null)
                t.SetOriginalProperties();

            // Apply Column filter and return the accounts
            return t;
        }
        /// <summary>
        /// Returns a lost of tList by the set of primary keys.
        /// </summary>
        /// <param name="ids">A list of primary key fields (integers).</param>
        /// <returns>A list of <see cref="T"/>s.</returns>
        /// <example>
        /// <code>
        /// List&lt;T&gt; tList = new TLogic().GetByPKs(new List&lt;int&gt;(){1, 2, 3});
        /// foreach(T t in tList)
        /// {
        ///     Console.WriteLine(t.TId);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetByIds(IEnumerable<TPk> ids)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getByIds, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { ids }, 0);
        }
        /// <summary>
        /// The privately wrapped implementation of the GetById(id) method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private IEnumerable<T> getByIds(object[] arguments)
        {
            // Convert arguments from generic object list
            List<TPk> ids = (List<TPk>)arguments[0];

            // Initialize response object
            List<T> tList = Repository.GetByIds(ids).ToList();

            return tList;
        }
        /// <summary>
        /// Retrieves a list of ModelArtifacts by the foriegn key.
        /// </summary>
        /// <param name="foreignKey">The foreign key to filter <see cref="ModelArtifact"/> records on.</param>
        /// <param name="foreignKeyId">The id of the foreign key.</param>
        /// <param name="filter">The optional filter.</param>
        /// <returns>A list of <see cref="ModelArtifact"/>s.</returns>
        /// <example>
        /// <code>
        /// List&lt;ModelArtifact&gt; modelArtifact = new ModelArtifactLogic().GetByFK(ModelArtifactFKs.FKId, 1);
        /// foreach(ModelArtifact modelArtifact in modelArtifact)
        /// {
        ///     Console.WriteLine(modelArtifact.ModelArtifactId);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetByFK<TFk>(string foreignKey, TFk foreignKeyId, KnightsTour.CoreLibrary.IRetrievalCondition filter = null)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getByFKs<TFk>, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { foreignKey, new List<TFk>() { foreignKeyId }, filter }, 0);
        }
        /// <summary>
        /// Retrieves a list of ModelArtifacts by the foriegn key.
        /// </summary>
        /// <typeparam name="TFk"></typeparam>
        /// <param name="foreignKey"></param>
        /// <param name="foreignKeyIds"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> GetByFKs<TFk>(string foreignKey, IEnumerable<TFk> foreignKeyIds, KnightsTour.CoreLibrary.IRetrievalCondition filter = null)
        {
            return MethodWrappers.CommonWrapper<IEnumerable<T>>(getByFKs<TFk>, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { foreignKey, foreignKeyIds, filter }, 0);
        }
        /// <summary>
        /// The privately wrapped implementation of the getByFKs method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private IEnumerable<T> getByFKs<TFk>(object[] arguments)
        {
            string fk = (string)arguments[0];
            List<TFk> ids = ((IEnumerable<TFk>)arguments[1]).ToList();
            KnightsTour.CoreLibrary.IRetrievalCondition filter = (KnightsTour.CoreLibrary.IRetrievalCondition)arguments[2];

            List<T> tArtifacts = Repository.GetByFKs(fk, ids, filter).ToList();

            // Apply Column filter and return the accounts
            return tArtifacts;
        }
        #endregion SELECT Methods

        #region INSERT Methods
        /// <summary>
        /// Inserts the T.
        /// </summary>
        /// <param name="T">The <see cref="T"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// // This code will most likely not result in a new account being created due to base field validation failures.
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new T());
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Insert(T t)
        {
            return Insert(new List<T>() { t });
        }
        /// <summary>
        /// Inserts the specified tList.
        /// </summary>
        /// <param name="tList">The list of <see cref="T"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// // This code will most likely not result in a new account being created due to base field validation failures.
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new List&lt;T&gt;(){new T(), new T()});
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Insert(IEnumerable<T> tList)
        {
            return Insert(tList, StorageHandler.InsertBlockSize);
        }
        /// <summary>
        /// Inserts the specified tList with the block size specified.
        /// </summary>
        /// <param name="tList">The list of <see cref="T"/> to insert.</param>
        /// <param name="blockSize">The bulk insert block size (the number of items to pass at a time).</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// // This code will most likely not result in a new account being created due to base field validation failures.
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new List&lt;T&gt;(){new T(), new T()}, 100);
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Insert(IEnumerable<T> tList, int blockSize)
        {
            return MethodWrappers.CommonWrapper<KnightsTour.CoreLibrary.IActionResponse>(insert, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { tList, blockSize }, 1);
        }
        /// <summary>
        /// The base insert hander.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        private KnightsTour.CoreLibrary.IActionResponse insert(object[] arguments)
        {
            // Convert arguments from generic object list
            IEnumerable<T> tList = ((IEnumerable<T>)arguments[0]);
            int blockSize = (int)arguments[1];

            //Validation
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse();
            List<T> valididatedEntities = new List<T>();
            foreach (T t in tList)
            {
                KnightsTour.CoreLibrary.ActionResponse validationResponse = KnightsTour.Context.ValidationHandler.ValidateEntity<TPk>(new T().EntityName, new T().TableSchema, t, true);

                //Do some validation based on the configured insert type.
                if (t.PKInsertConfiguration != KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual && !t.IsNew)
                {
                    validationResponse.Messages.Add(new KnightsTour.CoreLibrary.Message("The table is set to automatically increment the primary key - do not set the primary key field.", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative));
                }
                else if (t.PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual && t.IsNew && string.IsNullOrEmpty(t.PKDefaultValue))
                {
                    validationResponse.Messages.Add(new KnightsTour.CoreLibrary.Message("The table is set to manually manage the primary key - the primary key field must be set.", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative));
                }

                if (validationResponse.IsValid)
                    valididatedEntities.Add(t);
                else
                {
                    response.Append(validationResponse);
                    if (KnightsTour.Context.ValidationHandler.AllOrNothing)
                        return response;
                }
            }

            if (valididatedEntities.Any())
                response.Append(Repository.Insert(valididatedEntities, blockSize));

            return response;
        }
        #endregion INSERT Methods

        #region UPDATE Methods
        /// <summary>
        /// Updates the T.
        /// </summary>
        /// <param name="T">The <see cref="T"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// // This code will most likely not result in a new account being updated due to the object not being modified
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Update(new TLogic().GetById(1));
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Update(T t)
        {
            return Update(new List<T>() { t });
        }
        /// <summary>
        /// When a concurrency field is set, allows for the easy updating of the executing user id field.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="executingUserId"></param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse Update(T t, int? executingUserId)
        {
            t.ExecutingUserId = executingUserId;
            return Update(t);
        }             
        /// <summary>
        /// Update the specified tList.
        /// </summary>
        /// <param name="tList">The list of <see cref="T"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// // This code will most likely not result in a new account being updated due to the object not being modified
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Update(new List&lt;T&gt;(){new TLogic.GetById(1), new TLogic.GetById(2)});
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Update(IEnumerable<T> tList)
        {
            return MethodWrappers.CommonWrapper<KnightsTour.CoreLibrary.IActionResponse>(update, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { tList }, 1);
        }
        /// <summary>
        /// The base update hander.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        private KnightsTour.CoreLibrary.IActionResponse update(object[] arguments)
        {
            // Convert arguments from generic object list
            IEnumerable<T> tList = ((IEnumerable<T>)arguments[0]);

            //Validation
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse();
            List<T> valididatedEntities = new List<T>();
            foreach (T t in tList)
            {
                KnightsTour.CoreLibrary.ActionResponse validationResponse = KnightsTour.Context.ValidationHandler.ValidateEntity<TPk>(new T().EntityName, new T().TableSchema, t);
                if (t.IsModified())
                {
                    if (validationResponse.IsValid)
                        valididatedEntities.Add(t);
                    else
                    {
                        response.Append(validationResponse);
                        if (KnightsTour.Context.ValidationHandler.AllOrNothing)
                            return response;
                    }
                }
                else
                    response.Append(new KnightsTour.CoreLibrary.Message($"The object is not modified.", KnightsTour.CoreLibrary.Enumerations.MessageType.Warning));
            }

            // Return the response object
            if (valididatedEntities.Any())
                return Repository.Update(valididatedEntities);
            else
                return response;
        }
        #endregion UPDATE Methods

        #region DELETE Methods
        /// <summary>Deletes the by fk.</summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="fkId">The fk identifier.</param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse DeleteByFK<TFk>(string columnName, TFk fkId)
        {
            // Return the response object
            return Repository.DeleteByFK(columnName, fkId);
        }
        /// <summary>Deletes the cascade.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="pk">The where clause.</param>
        /// <returns></returns>
        public KnightsTour.CoreLibrary.IActionResponse DeleteCascade<TFk>(TFk id, string whereClause = null, string pk = null)
        {
            // Return the response object
            return Repository.DeleteCascade<TFk>(id, whereClause, pk);
        }
        /// <summary>
        /// Deletes the T.
        /// </summary>
        /// <param name="T">The <see cref="T"/> to delete.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Delete(new TLogic().GetById(1));
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(T t)
        {
            return Delete(new List<TPk>() { t.Id }, StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Deletes the specified tList.
        /// </summary>
        /// <param name="tList">The list of <see cref="T"/> to delete.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new List&lt;T&gt;(){new AccountLogic.GetByPK(1), new AccountLogic.GetByPK(2)});
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<T> tList)
        {
            return Delete(tList.Select(a => a.Id).ToList(), StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Deletes the specified tList with the block size specified.
        /// </summary>
        /// <param name="tList">The list of <see cref="T"/> to delete.</param>
        /// <param name="blockSize">The bulk delete block size (the number of items to delete at a time).</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new List&lt;T&gt;(){new AccountLogic.GetByPK(1), new AccountLogic.GetByPK(2)}, 100);
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<T> tList, int blockSize)
        {
            return Delete(tList.Select(e => e.Id).ToList(), blockSize);
        }
        /// <summary>
        /// Deletes the T.
        /// </summary>
        /// <param name="tId">The primary key of the <see cref="T"/> to delete.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Delete(1);
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(TPk tId)
        {
            return Delete(new List<TPk>() { tId }, StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Deletes the specified tList.
        /// </summary>
        /// <param name="ids">The list of <see cref="T"/> ids to delete.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Delete(new List&lt;int&gt;(){1, 2, 3});
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<TPk> ids)
        {
            return Delete(ids , StorageHandler.DeleteBlockSize);
        }
        /// <summary>
        /// Deletes the specified tList with the block size specified.
        /// </summary>
        /// <param name="ids">The list of <see cref="T"/> ids to delete.</param>
        /// <param name="blockSize">The bulk delete block size (the number of items to delete at a time).</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Insert(new List&lt;T&gt;(){new AccountLogic.GetByPK(1), new AccountLogic.GetByPK(2)}, 100);
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Delete(IEnumerable<TPk> ids, int blockSize)
        {
            return MethodWrappers.CommonWrapper<KnightsTour.CoreLibrary.IActionResponse>(delete, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { ids, blockSize }, 1);
        }
        /// <summary>
        /// The base delete hander.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        private KnightsTour.CoreLibrary.IActionResponse delete(object[] arguments)
        {
            // Convert arguments from generic object list
            IEnumerable<TPk> ids = ((IEnumerable<TPk>)arguments[0]);
            int blockSize = (int)arguments[1];

            // Return the response object
            return Repository.Delete(ids, blockSize);

        }
        #endregion DELETE Methods

        #region Methods
        /// <summary>
        /// Validates the T.
        /// </summary>
        /// <param name="t">The generic class type to validate.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        /// <example>
        /// <code>
        /// KnightsTour.CoreLibrary.IActionResponse response = new TLogic().Validate(new TLogic().GetById(1));
        /// Console.WriteLine(response.IsValid); //Handy to know the overall status of the response.
        /// foreach(Message message in response.Messages)
        /// {
        ///     //A message is a rich object unto itself.
        ///     Console.WriteLine($"[{message.Type.ToString()}] {message.Content}");
        /// }
        /// </code>
        /// </example>
        public KnightsTour.CoreLibrary.IActionResponse Validate(T t)
        {
            return Context.ValidationHandler.ValidateEntity<TPk>(EntityName.ToString(), new T().TableSchema, t);
        }
        /// <summary>Gets the table hash.</summary>
        /// <returns></returns>
        public DateTime GetLastTableUpdate()
        {
            return DateTime.Now.AddYears(-100);
        }
        protected string GetCompleteExceptionMessage(Exception exception)
        {
            string exceptionMessage = string.Empty;

            if(exception.InnerException != null)
            {
                exceptionMessage += GetCompleteExceptionMessage(exception.InnerException) + Environment.NewLine;
            }

            exceptionMessage += exception.Message;

            return exceptionMessage;
        }
        #endregion Methods
    }
}