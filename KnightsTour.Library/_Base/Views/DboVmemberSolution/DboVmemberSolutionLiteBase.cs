// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:55:34 AM
// File             : DboVMemberSolutionLiteBase.cs
// ************************************************************************

using System;
using System.Data;

namespace KnightsTour
{
    /// <summary>
    /// The DboVMemberSolutionBase class which is the single place which defines the view properties. />
    /// Generated On: October 21, 2023 at 9:55:34 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended class <seealso cref="DboVMemberSolution" />.
    /// </remarks>
    public abstract class DboVMemberSolutionBase
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DboVMemberSolutionBase"/> class.
        /// Initializes a new instance of the <see cref="DboVMemberSolutionBase"/> class initialized with default properties.
        /// </summary>
        public DboVMemberSolutionBase() : base()
        {
            // View properties.
            PuzzleId = 0;
            MemberId = 0;
            SolutionId = 0;
            Rows = 0;
            Cols = 0;
            SolutionDuration = 0M;
            SolutionStartDate = DateTime.Now;
            Difficulty = string.Empty;
            PuzzleOfTheDayDate = DateTime.Now;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DboVMemberSolutionBase"/> class.
        /// Initializes a new empty instance of the DboVMemberSolutionBase class from a DataRow with the DboVMemberSolution view columns specified.
        /// </summary>
        /// <param name="record">A <see cref="DataRow"/>.</param>
        public DboVMemberSolutionBase(DataRow record)
        {
            if (record != null)
            {
                PuzzleId = record.ValueAs<int>("PuzzleId");
                MemberId = record.ValueAs<int>("MemberId");
                SolutionId = record.ValueAs<int>("SolutionId");
                Rows = record.ValueAs<int>("Rows");
                Cols = record.ValueAs<int>("Cols");
                SolutionDuration = record.ValueAs<decimal>("SolutionDuration");
                SolutionStartDate = record.ValueAs<DateTime>("SolutionStartDate");
                Difficulty = record.ValueAs<string>("Difficulty");
                PuzzleOfTheDayDate = record.ValueAs<DateTime>("PuzzleOfTheDayDate");
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DboVMemberSolutionBase"/> class.
        /// Initializes a new empty instance of the DboVMemberSolutionBase class from the record in a data reader populating only the DboVMemberSolution columns specified.
        /// </summary>
        /// <param name="record">A record returned from a database reader.</param>
        public DboVMemberSolutionBase(IDataRecord record)
        {
            if (record != null)
            {
                PuzzleId = record.ValueAs<int>("PuzzleId");
                MemberId = record.ValueAs<int>("MemberId");
                SolutionId = record.ValueAs<int>("SolutionId");
                Rows = record.ValueAs<int>("Rows");
                Cols = record.ValueAs<int>("Cols");
                SolutionDuration = record.ValueAs<decimal>("SolutionDuration");
                SolutionStartDate = record.ValueAs<DateTime>("SolutionStartDate");
                Difficulty = record.ValueAs<string>("Difficulty");
                PuzzleOfTheDayDate = record.ValueAs<DateTime>("PuzzleOfTheDayDate");
            }
        }
        #endregion Constructor(s)

        #region Properties

        /// <summary>
        /// Gets or sets the puzzle id.
        /// </summary>
        /// <value>
        /// The puzzle id.
        /// </value>
        public int PuzzleId
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
        public int MemberId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the solution id.
        /// </summary>
        /// <value>
        /// The solution id.
        /// </value>
        public int SolutionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public int Rows
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cols.
        /// </summary>
        /// <value>
        /// The cols.
        /// </value>
        public int Cols
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
        public decimal SolutionDuration
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
        /// Gets or sets the difficulty.
        /// </summary>
        /// <value>
        /// The difficulty.
        /// </value>
        public string Difficulty
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the puzzle of the day date.
        /// </summary>
        /// <value>
        /// The puzzle of the day date.
        /// </value>
        public DateTime PuzzleOfTheDayDate
        {
            get;
            set;
        }
        #endregion Properties

    } // Class
} // Namespace