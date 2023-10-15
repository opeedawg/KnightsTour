// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : DifficultyLevelLiteBase.cs
// ************************************************************************

using System;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// The DifficultyLevelLiteBase class which is the single place which defines the properties.  Inherits <seealso cref="KnightsTour.CoreLibrary.EntityBase{T}" />
    /// Generated On: October 14, 2023 at 11:18:11 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended class <seealso cref="DifficultyLevelLite" />.
    /// </remarks>
    public abstract class DifficultyLevelLiteBase : KnightsTour.CoreLibrary.EntityBase<int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DifficultyLevelLiteBase"/> class.
        /// Initializes a new instance of the <see cref="DifficultyLevelLiteBase"/> class.
        /// </summary>
        public DifficultyLevelLiteBase()
        {
            OnIdSet += DifficultyLevelLiteBase_OnIdSet;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DifficultyLevelLiteBase"/> class.
        /// Initializes a new instance of the <see cref="DifficultyLevelLite"/> class from its full class representation.
        /// </summary>
        /// <param name="difficultyLevelBase">The <see cref="DifficultyLevelBase"/>.</param>
        public DifficultyLevelLiteBase(DifficultyLevelBase difficultyLevelBase)
        {
            // Only do this if the object exists.
            if (difficultyLevelBase != null)
            {
                OnIdSet += DifficultyLevelLiteBase_OnIdSet;
                DifficultyLevelId = difficultyLevelBase.DifficultyLevelId;
                Name = difficultyLevelBase.Name;
                Description = difficultyLevelBase.Description;
                MaximumGap = difficultyLevelBase.MaximumGap;
                PercentVisibility = difficultyLevelBase.PercentVisibility;
                HighlightClosestEnabled = difficultyLevelBase.HighlightClosestEnabled;
                DuplicateCheckingEnabled = difficultyLevelBase.DuplicateCheckingEnabled;
                GuessFilterEnabled = difficultyLevelBase.GuessFilterEnabled;
                BadLinkEnabled = difficultyLevelBase.BadLinkEnabled;
                MaximumDimension = difficultyLevelBase.MaximumDimension;
                MinimumDimension = difficultyLevelBase.MinimumDimension;

                // Also set the Id field.
                Id = this.DifficultyLevelId;
            }
        }
        #endregion Constructor(s)

        #region Properties

        /// <summary>
        /// Gets or sets the primary key field difficulty level id.
        /// </summary>
        /// <value>
        /// The difficulty level id.
        /// </value>
        public int? DifficultyLevelId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum gap.
        /// </summary>
        /// <value>
        /// The maximum gap.
        /// </value>
        public int MaximumGap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the percent visibility.
        /// </summary>
        /// <value>
        /// The percent visibility.
        /// </value>
        public decimal PercentVisibility
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight closest enabled.
        /// </summary>
        /// <value>
        /// The highlight closest enabled.
        /// </value>
        public bool HighlightClosestEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duplicate checking enabled.
        /// </summary>
        /// <value>
        /// The duplicate checking enabled.
        /// </value>
        public bool DuplicateCheckingEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the guess filter enabled.
        /// </summary>
        /// <value>
        /// The guess filter enabled.
        /// </value>
        public bool GuessFilterEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bad link enabled.
        /// </summary>
        /// <value>
        /// The bad link enabled.
        /// </value>
        public bool BadLinkEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum dimension.
        /// </summary>
        /// <value>
        /// The maximum dimension.
        /// </value>
        public int MaximumDimension
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum dimension.
        /// </summary>
        /// <value>
        /// The minimum dimension.
        /// </value>
        public int MinimumDimension
        {
            get;
            set;
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Invoked when the generic Id field of this class is modified (set).
        /// </summary>
        private void DifficultyLevelLiteBase_OnIdSet()
        {
            DifficultyLevelId = Id;
        }
        #endregion Methods

    } // Class
} // Namespace