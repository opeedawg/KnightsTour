// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : EventHistoryValidationBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// Manages and performs base validation for the EventHistory entity.
    /// Generated On: October 14, 2023 at 11:18:11 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public class EventHistoryValidationBase : KnightsTour.CoreLibrary.IEntityValidator
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHistoryValidationBase"/> class.
        /// Initializes a new instance of the <see cref="EventHistoryValidation"/> class initialized with default properties.
        /// </summary>
        /// <remarks>
        /// Derived field validations are created here but can be extended, removed or updated from the exended class.
        /// </remarks>
        public EventHistoryValidationBase()
        {
            #region Field Validations
            FieldValidations = new List<KnightsTour.CoreLibrary.IFieldValidator>();

            // Event History Id.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.EventHistoryId.ToString(),
                    ObjectType = typeof(int?),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = true,
            });

            // Event Type Id.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.EventTypeId.ToString(),
                    ObjectType = typeof(int?),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Event Date.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.EventDate.ToString(),
                    ObjectType = typeof(DateTime),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Source Internet Address.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.SourceInternetAddress.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
                    MaximumLength = 250,
            });

            // Country.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.Country.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = false,
                    MaximumLength = 250,
            });

            // Region.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.Region.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = false,
                    MaximumLength = 250,
            });

            // City.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.City.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = false,
                    MaximumLength = 250,
            });

            // Zip Postal.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.ZipPostal.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = false,
                    MaximumLength = 250,
            });

            // Context.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.Context.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Member Id.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.EventHistory.ToString(),
                    FieldName = Enumerations.EventHistoryProperty.MemberId.ToString(),
                    ObjectType = typeof(int?),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = false,
            });
            #endregion //Field Validations

            #region Rule Validations
            RuleValidations = new List<KnightsTour.CoreLibrary.IRuleValidator>();
            #endregion //Rule Validations

            #region Custom Validations
            CustomValidations = new List<KnightsTour.CoreLibrary.ICustomValidator>();
            #endregion //Custom Validations
        }
        #endregion Constructor(s)

        #region Properties

        /// <summary>
        /// Gets or sets the field validations.
        /// </summary>
        /// <value>
        /// The field validations.
        /// </value>
        public List<KnightsTour.CoreLibrary.IFieldValidator> FieldValidations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rule validations.
        /// </summary>
        /// <value>
        /// The rule validations.
        /// </value>
        public List<KnightsTour.CoreLibrary.IRuleValidator> RuleValidations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the custom validations.
        /// </summary>
        /// <value>
        /// The custom validations.
        /// </value>
        public List<KnightsTour.CoreLibrary.ICustomValidator> CustomValidations
        {
            get;
            set;
        }
        #endregion Properties

    } // Class
} // Namespace