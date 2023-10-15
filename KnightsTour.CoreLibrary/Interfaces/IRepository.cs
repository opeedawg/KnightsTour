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
// Created          : October 14, 2023 11:07:03 AM
// File             : IRepository.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Generic repository interface for a particular entity.
    /// </summary>
    public interface IRepository<T, TLite, TPk> 
        where T : IEntity<TPk>, new()
        where TLite: IEntityLite<TPk>
    {
        #region Properties
        /// <summary>
        /// The type specific storage handler for this repository.
        /// </summary>
        IStorageHandler StorageHandler { get; set; }
        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        string UserName { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves the T entitiy by its primary key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(TPk id);
        /// <summary>
        /// Retrieves a list of T entities by a collection of primary keys.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<T> GetByIds(IEnumerable<TPk> ids);
        /// <summary>
        /// Gets all of the T entities available.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Gets all of the T entities available that satisfy the filter condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(IRetrievalCondition condition);
        /// <summary>
        /// Gets all of the T entities available that satisfy the filter condition.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Func<T, bool> filter);
        /// <summary>
        /// Gets all of the T entities available give the filter passed.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllExtended(EntityFilter filter);
        /// <summary>
        /// Gets the total number of the T entities available give the filter passed.
        /// </summary>
        /// <returns></returns>
        int GetCount(EntityFilter filter);
        string GetWhereSql(EntityFilter filter);
        string GetOrderBySql(EntityFilter filter, bool addOrderBySql = false);
        string GetPaginationSql(EntityFilter filter);
        List<IParameter> GetParameters(EntityFilter filter);
        /// <summary>
        /// Gets a collection of T entities by the given foreign key column and the related id.
        /// </summary>
        /// <param name="foreignKeyName"></param>
        /// <param name="id"></param>
        /// <param name="filter">The optional retrieval condition.</param>
        /// <returns></returns>
        IEnumerable<T> GetByFK<TFk>(string foreignKeyName, TFk id, IRetrievalCondition filter = null);
        /// <summary>
        /// Gets a collection of T entities by the given foreign key column and the related ids.
        /// </summary>
        /// <param name="foreignKeyName"></param>
        /// <param name="ids"></param>
        /// <param name="filter">The optional retrieval condition.</param>
        /// <returns></returns>
        IEnumerable<T> GetByFKs<TFk>(string foreignKeyName, IEnumerable<TFk> ids, IRetrievalCondition filter = null);
        /// <summary>
        /// Inserts a single T entity into storage.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IActionResponse Insert(T entity);
        /// <summary>
        /// Inserts a collection of T entities into storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IActionResponse Insert(IEnumerable<T> entities);
        /// <summary>
        /// Inserts a collection of T entities into storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        IActionResponse Insert(IEnumerable<T> entities, int blockSize);

        /// <summary>
        /// Updates a T entity in storage.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IActionResponse Update(T entity);
        /// <summary>
        /// Updates a list of T entities in storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IActionResponse Update(IEnumerable<T> entities);

        /// <summary>
        /// Deletes a T entity from storage.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IActionResponse Delete(T entity);
        /// <summary>
        /// Deletes a list of T entities from storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IActionResponse Delete(IEnumerable<T> entities);
        /// <summary>
        /// Deletes a list of T entities from storage.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        IActionResponse Delete(IEnumerable<T> entities, int blockSize);
        /// <summary>
        /// Deletes a T entity by its primary key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IActionResponse Delete(TPk id);
        /// <summary>
        /// Deletes a collection of T entities by primary keys.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IActionResponse Delete(IEnumerable<TPk> ids);
        /// <summary>
        /// Deletes a collection of T entities by primary keys.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        IActionResponse Delete(IEnumerable<TPk> ids, int blockSize);
        /// <summary>Deletes the by fk.</summary>
        /// <param name="fkColumnName">Name of the fk column.</param>
        /// <param name="fkId">The fk identifier.</param>
        /// <returns></returns>
        IActionResponse DeleteByFK<TFk>(string fkColumnName, TFk fkId);
        /// <summary>Deletes the object doing a full cascade delete of all the related dependencies.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        IActionResponse DeleteCascade<TFk>(TFk id, string whereClause = null, string pk = null);
        /// <summary>Gets the table hash.</summary>
        /// <returns></returns>
        DateTime GetLastTableUpdate();
        #endregion
    }
}