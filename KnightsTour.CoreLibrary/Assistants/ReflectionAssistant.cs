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
// File             : ReflectionAssistant.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class ReflectionUtility.
    /// </summary>
    public static class ReflectionAssistant
    {
        #region Methods
        /// <summary>
        /// Retrives all the method details based on the stack trace and optional frame
        /// </summary>
        /// <param name="stackTrace"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        public static MethodAttributeAssistant GetMethodAttributes(StackTrace stackTrace, int frameIndex = 1)
        {
            return new MethodAttributeAssistant(stackTrace, frameIndex);
        }
        /// <summary>
        /// Determines of a property exists on a object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasProperty<T>(T entity, string propertyName)
        {
            List<PropertyInfo> attributes = entity.GetType().GetProperties().ToList();
            return attributes.Exists(a => a.Name == propertyName);
        }
        /// <summary>
        /// Sets the property to the value if the property exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetValue<T>(T entity, string propertyName, object value)
        {
            if (HasProperty<T>(entity, propertyName))
            {
                PropertyInfo propertyInfo = entity.GetType().GetProperties().FirstOrDefault(p => p.Name == propertyName);
                propertyInfo.SetValue(entity, value);
            }
            else
                throw new Exception($"Property '{propertyName}' does not exist on object of type '{entity.GetType().Name}'.");
        }
        /// <summary>
        /// Returns a property value if the property exists on the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static T2 GetValue<T, T2>(T entity, string propertyName)
        {
            if (HasProperty<T>(entity, propertyName))
            {
                PropertyInfo propertyInfo = entity.GetType().GetProperties().First(p => p.Name == propertyName);
                if (typeof(T2).IsAssignableFrom(propertyInfo.PropertyType))
                    return (T2)propertyInfo.GetValue(entity);
                else
                    throw new Exception($"Property '{propertyName}' of type {propertyInfo.PropertyType.Name} can not be assigned to type {typeof(T2).Name}.");
            }
            else
                throw new Exception($"Property '{propertyName}' does not exist on object of type {entity.GetType().Name}.");
        }
        /// <summary>
        /// Reads an embeded resource file and returns the value as a string.
        /// </summary>
        /// <param name="resourcePath"></param>
        /// <param name="fileName"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static string GetResource(string resourcePath, string fileName, string projectName)
        {
            //Get all the resoure "names" (which include the internal path information) for the requested resource location (meaning, folder within the Author)
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().Where(x => x.StartsWith(resourcePath));

            //Process each resource
            foreach (var resourceName in resourceNames)
            {
                //Get a handle on the resource content
                Stream stream = assembly.GetManifestResourceStream(resourceName);

                //The filename is embedded in the resource location
                string resourceFileName = resourceName.Replace($"{resourcePath}.", string.Empty);
                if (resourceFileName == fileName)
                {
                    using (Stream resource = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string resourceContent = reader.ReadToEnd();
                            resourceContent = DoResourceReplacements(resourceContent, projectName);
                            return resourceContent;
                        }
                    }
                }
            }

            return string.Empty;
        }
        /// <summary>
        /// Repalces values in a embedded resource file.
        /// </summary>
        /// <param name="originalText"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        static string DoResourceReplacements(string originalText, string projectName)
        {
            originalText = originalText.Replace("KnightsTour", projectName);
            return originalText;
        }
        #endregion
    }
}