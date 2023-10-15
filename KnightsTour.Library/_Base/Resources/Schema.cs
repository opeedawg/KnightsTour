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
// File             : Schema.cs
// ************************************************************************

using Newtonsoft.Json;
using KnightsTour.CoreLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// A static accessor that deserializes the generated Schema.json embedded resource into the ModelSchema class hierarchy
    /// </summary>
    public class Schema
    {
        #region Declarations
        static KnightsTour.CoreLibrary.ModelSchema _model = null;
        static DateTime? lastLoadTime = null;
        static string absoluteResourceLocation = null;
        #endregion

        #region Properties
        /// <summary>
        /// The static ModelSchema accessor
        /// </summary>
        public static KnightsTour.CoreLibrary.ModelSchema Model
        {
            get
            {
                if (RequiresReload())
                    _model = GetFromEmbeddedResource();

                return _model;
            }
        }
        static DateTime LastLoadTime
        {
            get 
            {
                if (!lastLoadTime.HasValue)
                    lastLoadTime = File.GetLastWriteTimeUtc(AbsoluteResourceLocation);

                return lastLoadTime.Value;
            }
            set
            {
                lastLoadTime = value;
            }
        }
        static string AbsoluteResourceLocation
        {
            get
            {
                if (string.IsNullOrEmpty(absoluteResourceLocation))
                {
                    absoluteResourceLocation = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", ""))}\\_Base\\Resources\\Schema.json";
                }
                return absoluteResourceLocation;
            }
        }
        #endregion

        #region Support Methods
        /// <summary>
        /// Gets from embedded resource.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Unable to load schema file from: {AbsoluteResourceLocation}
        /// or
        /// Unhandled exception in Schema.GetFromEmbeddedResource(): " + exception.Message
        /// </exception>
        static KnightsTour.CoreLibrary.ModelSchema GetFromEmbeddedResource()
        {
            try
            {
                if (!File.Exists(AbsoluteResourceLocation))
                    throw new Exception($"Unable to load schema file from: {AbsoluteResourceLocation}");

                //Convert to ModelSchema
                var schema = JsonConvert.DeserializeObject<KnightsTour.CoreLibrary.ModelSchema>(File.ReadAllText(AbsoluteResourceLocation));

                return schema;
            }
            catch (Exception exception)
            {
                throw new Exception($"Unhandled exception in Schema.GetFromEmbeddedResource(): " + exception.Message, exception);
            }
        }
        /// <summary>
        /// Requireses the reload.
        /// </summary>
        /// <returns></returns>
        static bool RequiresReload()
        {
            DateTime lastWriteTime = File.GetLastWriteTimeUtc(AbsoluteResourceLocation);

            if (_model == null || lastWriteTime > LastLoadTime)
            {
                LastLoadTime = lastWriteTime;
                return true;
            }

            return false;
        }
        /// <summary>
        /// Fields the validations.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <returns></returns>
        public static List<IFieldValidator> FieldValidations(string entityName)
        {
            List<IFieldValidator> validations = new List<IFieldValidator>();

            EntitySchema schema = Model.Entities.FirstOrDefault(e => e.Name == entityName);

            if (schema != null)
            {
                foreach (PropertySchema propertySchema in schema.Properties)
                {
                    KnightsTour.FieldValidator fieldValidator = new KnightsTour.FieldValidator
                    {
                        Table = entityName,
                        FieldName = propertySchema.Name,
                        ObjectType = GetTypeFromProperty(propertySchema),
                        MandatoryOnInsert = propertySchema.IsMandatory && !propertySchema.IsPrimaryKey,
                        MandatoryOnUpdate = propertySchema.IsMandatory,
                    };

                    AttributeSchema maxLength = propertySchema.Attributes.FirstOrDefault(p => p.TypeName == "Maximum Length" && !string.IsNullOrEmpty(p.Value));
                    if (maxLength != null)
                    {
                        fieldValidator.MaximumLength = int.Parse(maxLength.Value);
                    }

                    AttributeSchema minLength = propertySchema.Attributes.FirstOrDefault(p => p.TypeName == "Minimum Length" && !string.IsNullOrEmpty(p.Value));
                    if (minLength != null)
                    {
                        fieldValidator.MinimumLength = int.Parse(minLength.Value);
                    }

                    List<string> definedFormats = new List<string>() { "Phone", "Email", "Url", "Zip Code", "Postal Code" };

                    foreach (string definedFormatName in definedFormats)
                    {
                        AttributeSchema definedFormat = propertySchema.Attributes.FirstOrDefault(p => p.TypeName == "Defined format" && p.Value == definedFormatName);
                        if (definedFormat != null)
                        {
                            fieldValidator.RegularExpression = Model.Project.Attributes.First(a => a.TypeName == definedFormatName).Value;
                            fieldValidator.FormatDescription = definedFormatName;
                        }
                    }

                    validations.Add(fieldValidator);
                }
            }

            return validations;
        }
        /// <summary>
        /// Gets the type from property.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unhandled datatype conversion: {schema.DataType}</exception>
        static Type GetTypeFromProperty(PropertySchema schema)
        {
            bool isNullable = schema.IsPrimaryKey || schema.IsForeignKey || (!schema.IsMandatory && schema.DataType != "Text");

            switch (schema.DataType)
            {
                case "Number":
                    return isNullable ? typeof(int?) : typeof(int);
                case "Number - Large":
                    return isNullable ? typeof(long?) : typeof(long);
                case "Binary":
                    return typeof(byte[]);
                case "Yes/No":
                    return isNullable ? typeof(bool?) : typeof(bool);
                case "Text":
                    return typeof(string);
                case "Date":
                    return isNullable ? typeof(DateTime?) : typeof(DateTime);
                case "Decimal":
                case "Currency":
                    return isNullable ? typeof(decimal?) : typeof(decimal);
                case "Double":
                    return isNullable ? typeof(double?) : typeof(double);
                case "Number - Small":
                    return isNullable ? typeof(short?) : typeof(short);
                case "Time":
                    return isNullable ? typeof(TimeSpan?) : typeof(TimeSpan);
                case "Unique Identifier":
                    return isNullable ? typeof(Guid?) : typeof(Guid);
                case "XML":
                    return typeof(XmlDocument);
            }

            throw new Exception($"Unhandled datatype conversion: {schema.DataType}");
        }
        #endregion
    }
}