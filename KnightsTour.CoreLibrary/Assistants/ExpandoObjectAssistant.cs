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
// File             : ExpandoObjectAssistant.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Credit to https://codereview.stackexchange.com/questions/1002/mapping-expandoobject-to-another-object-type
    /// </summary>
    public static class ExpandoObjectAssistant 
    {
        #region Methods
        /// <summary>
        /// Maps an expando object to a specific data object type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static T Deserialize<T>(ExpandoObject source) where T : new()
        {
            Dictionary<string, PropertyInfo> _propertyMap =
                typeof(T)
                .GetProperties()
                .ToDictionary(
                    p => p.Name.ToLower(),
                    p => p
                );

            // Might as well take care of null references early.
            if (source == null)
                throw new ArgumentNullException("source");

            T destination = new T();
            foreach (var kv in source)
            {
                PropertyInfo p;
                if (_propertyMap.TryGetValue(kv.Key.ToLower(), out p))
                {
                    var propType = p.PropertyType;
                    if (kv.Value == null && !propType.IsByRef && propType.Name != "Nullable`1")
                    {
                        throw new ArgumentException("not nullable");
                    }
                    p.SetValue(destination, kv.Value, null);
                }
            }

            return destination;
        }
        /// <summary>
        /// Serializes an entity type as an expando object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ExpandoObject Serialize<T>(T entity)
        {
            var expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)expando;
        
            foreach (var property in entity.GetType().GetProperties())
                dictionary.Add(property.Name, property.GetValue(entity));

            return (ExpandoObject)dictionary;
        }
        #endregion
    }
}
