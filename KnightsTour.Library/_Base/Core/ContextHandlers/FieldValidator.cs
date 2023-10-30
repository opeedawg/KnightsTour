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
// Created          : October 26, 2023 9:31:46 AM
// File             : FieldValidator.cs
// ************************************************************************

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace KnightsTour
{
    /// <summary>
    /// Class FieldValidation.
    /// </summary>
    /// <seealso cref="KnightsTour.FieldValidatorBase" />
    /// <seealso cref="KnightsTour.CoreLibrary.IFieldValidator" />
    public class FieldValidator : FieldValidatorBase, KnightsTour.CoreLibrary.IFieldValidator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidator "/> class.
        /// </summary>
        public FieldValidator () : base()
        {
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Sets the defaults.
        /// </summary>
        public void SetDefaults()
        {
            MandatoryOnInsert = false;
            MandatoryOnUpdate = false;
            MaximumLength = null;
            MinimumLength = null;
            MinimumValue = null;
            MaximumValue = null;
            RegularExpression = null;
        }
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <returns>ActionResponse.</returns>
        public KnightsTour.CoreLibrary.ActionResponse Validate(dynamic value, bool isInsert = false)
        {
            KnightsTour.CoreLibrary.ActionResponse fieldValidation = new KnightsTour.CoreLibrary.ActionResponse($"Field validation for {Table.ToString()}.{FieldName}");

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                if (MandatoryOnInsert && isInsert)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_MissingMandatoryField, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName);
                }
                else if (MandatoryOnUpdate && !isInsert)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_MissingMandatoryField, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName);
                }
            }
            else
            {
                string valueAsString = value.ToString();

                #region Data Type
                if (valueAsString != "System.Byte[]")
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(ObjectType);
                    if (!converter.IsValid(valueAsString))
                    {
                        fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_InvalidFormat, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, valueAsString, GetFriendlyName(ObjectType));
                    }
                }
                #endregion

                #region Length
                if (MinimumLength.HasValue && valueAsString.Length < MinimumLength.Value)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_TooShort, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName, MinimumLength.Value.ToString());
                }

                if (MaximumLength.HasValue && valueAsString.Length > MaximumLength.Value)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_TooLong, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName, MaximumLength.Value.ToString());
                }
                #endregion

                #region Value
                if (MinimumValue != null && value < MinimumValue)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_GreaterThanOrEqual, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName, MinimumValue.ToString());
                }

                if (MaximumValue != null && value > MaximumValue)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_LessThanOrEqual, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName, MaximumValue.ToString());
                }
                #endregion

                #region Regular expression format
                if (!string.IsNullOrEmpty(RegularExpression) && !Regex.Match(valueAsString, RegularExpression).Success)
                {
                    fieldValidation.Append(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_InvalidFormat, KnightsTour.CoreLibrary.Enumerations.MessageType.Negative, FieldName, FormatDescription);
                }
                #endregion
            }

            return fieldValidation;
        }
        /// <summary>
        /// Returns the friendly name of the data type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetFriendlyName(Type type)
        {
            string friendlyName = type.Name;
            if (type.IsGenericType)
            {
                int iBacktick = friendlyName.IndexOf('`');
                if (iBacktick > 0)
                {
                    friendlyName = friendlyName.Remove(iBacktick);
                }
                friendlyName += "<";
                Type[] typeParameters = type.GetGenericArguments();
                for (int i = 0; i < typeParameters.Length; ++i)
                {
                    string typeParamName = GetFriendlyName(typeParameters[i]);
                    friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
                }
                friendlyName += ">";
            }

            return friendlyName;
        }
        #endregion
    }
}