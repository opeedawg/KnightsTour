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
// File             : IEntityLogic.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The interface to define the minimal set of functionality for an entity logic implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TLite"></typeparam>
    public interface IEntityLogic<T, TLite, TPk> 
        where T : IEntity<TPk>
        where TLite : IEntityLite<TPk>
    {
        #region Methods
        /// <summary>
        /// Validates the object in question.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IActionResponse Validate(T entity);
        #endregion
    }
}