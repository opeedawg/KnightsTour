// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : SolutionLiteBase.cs
// ************************************************************************

using System;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// The SolutionLiteBase class which is the single place which defines the properties.  Inherits <seealso cref="KnightsTour.CoreLibrary.EntityBase{T}" />
    /// Generated On: October 26, 2023 at 9:31:46 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended class <seealso cref="SolutionLite" />.
    /// </remarks>
    public abstract class SolutionLiteBase : KnightsTour.CoreLibrary.EntityBase<int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionLiteBase"/> class.
        /// Initializes a new instance of the <see cref="SolutionLiteBase"/> class.
        /// </summary>
        public SolutionLiteBase()
        {
            OnIdSet += SolutionLiteBase_OnIdSet;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionLiteBase"/> class.
        /// Initializes a new instance of the <see cref="SolutionLite"/> class from its full class representation.
        /// </summary>
        /// <param name="solutionBase">The <see cref="SolutionBase"/>.</param>
        public SolutionLiteBase(SolutionBase solutionBase)
        {
            // Only do this if the object exists.
            if (solutionBase != null)
            {
                OnIdSet += SolutionLiteBase_OnIdSet;
                SolutionId = solutionBase.SolutionId;
                PuzzleId = solutionBase.PuzzleId;
                MemberId = solutionBase.MemberId;
                SolutionStartDate = solutionBase.SolutionStartDate;
                SolutionDuration = solutionBase.SolutionDuration;
                Path = solutionBase.Path;
                Note = solutionBase.Note;
                Code = solutionBase.Code;
                NonMemberName = solutionBase.NonMemberName;
                NonMemberIp = solutionBase.NonMemberIp;

                // Also set the Id field.
                Id = this.SolutionId;
            }
        }
        #endregion Constructor(s)

        #region Declarations
        KnightsTour.PuzzleLite _puzzleLite = null; // Private Puzzle (by PuzzleId) reference used for lite graph hydraion.  NOT lazy loaded.
        KnightsTour.MemberLite _memberLite = null; // Private Member (by MemberId) reference used for lite graph hydraion.  NOT lazy loaded.
        #endregion Declarations

        #region Properties

        /// <summary>
        /// Gets or sets the related PuzzleLite (by PuzzleId) entity reference.  Never lazy loaded.
        /// </summary>
        /// <value>
        /// The puzzle.
        /// </value>
        public KnightsTour.PuzzleLite Puzzle
        {
            get
            {
                return _puzzleLite;
            }
            set
            {
                _puzzleLite = value;
            }
        }

        /// <summary>
        /// Gets or sets the related MemberLite (by MemberId) entity reference.  Never lazy loaded.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public KnightsTour.MemberLite Member
        {
            get
            {
                return _memberLite;
            }
            set
            {
                _memberLite = value;
            }
        }

        /// <summary>
        /// Gets or sets the primary key field solution id.
        /// </summary>
        /// <value>
        /// The solution id.
        /// </value>
        public int? SolutionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the puzzle id.
        /// </summary>
        /// <value>
        /// The puzzle id.
        /// </value>
        public int? PuzzleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the member id.
        /// </summary>
        /// <value>
        /// The member id.
        /// </value>
        public int? MemberId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the solution start date.
        /// </summary>
        /// <value>
        /// The solution start date.
        /// </value>
        public DateTime SolutionStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the solution duration.
        /// </summary>
        /// <value>
        /// The solution duration.
        /// </value>
        public decimal? SolutionDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the non member name.
        /// </summary>
        /// <value>
        /// The non member name.
        /// </value>
        public string NonMemberName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the non member i p.
        /// </summary>
        /// <value>
        /// The non member ip.
        /// </value>
        public string NonMemberIp
        {
            get;
            set;
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Invoked when the generic Id field of this class is modified (set).
        /// </summary>
        private void SolutionLiteBase_OnIdSet()
        {
            SolutionId = Id;
        }
        #endregion Methods

    } // Class
} // Namespace