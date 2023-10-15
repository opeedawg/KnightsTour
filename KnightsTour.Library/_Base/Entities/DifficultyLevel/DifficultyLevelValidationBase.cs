// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : DifficultyLevelValidationBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// Manages and performs base validation for the DifficultyLevel entity.
    /// Generated On: October 14, 2023 at 11:18:11 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public class DifficultyLevelValidationBase : KnightsTour.CoreLibrary.IEntityValidator
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DifficultyLevelValidationBase"/> class.
        /// Initializes a new instance of the <see cref="DifficultyLevelValidation"/> class initialized with default properties.
        /// </summary>
        /// <remarks>
        /// Derived field validations are created here but can be extended, removed or updated from the exended class.
        /// </remarks>
        public DifficultyLevelValidationBase()
        {
            #region Field Validations
            FieldValidations = new List<KnightsTour.CoreLibrary.IFieldValidator>();

            // Difficulty Level Id.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.DifficultyLevelId.ToString(),
                    ObjectType = typeof(int?),
                    MandatoryOnInsert = false,
                    MandatoryOnUpdate = true,
            });

            // Name.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.Name.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
                    MaximumLength = 50,
            });

            // Description.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.Description.ToString(),
                    ObjectType = typeof(string),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Maximum Gap.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.MaximumGap.ToString(),
                    ObjectType = typeof(int),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Percent Visibility.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.PercentVisibility.ToString(),
                    ObjectType = typeof(decimal),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Highlight Closest Enabled.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.HighlightClosestEnabled.ToString(),
                    ObjectType = typeof(bool),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Duplicate Checking Enabled.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.DuplicateCheckingEnabled.ToString(),
                    ObjectType = typeof(bool),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Guess Filter Enabled.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.GuessFilterEnabled.ToString(),
                    ObjectType = typeof(bool),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Bad Link Enabled.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.BadLinkEnabled.ToString(),
                    ObjectType = typeof(bool),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Maximum Dimension.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.MaximumDimension.ToString(),
                    ObjectType = typeof(int),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
            });

            // Minimum Dimension.
            FieldValidations.Add(new FieldValidator
            {
                    Table = Enumerations.EntityName.DifficultyLevel.ToString(),
                    FieldName = Enumerations.DifficultyLevelProperty.MinimumDimension.ToString(),
                    ObjectType = typeof(int),
                    MandatoryOnInsert = true,
                    MandatoryOnUpdate = true,
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