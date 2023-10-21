// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:16:29 AM
// File             : DboVpuzzleOfTheDay.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;

namespace KnightsTour
{
    /// <summary>
    /// The extended DboVpuzzleOfTheDay object.
    /// Generated On: October 14, 2023 at 11:16:29 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Feel free to add properties as you see fit here.
    /// </remarks>
    public class DboVpuzzleOfTheDay : DboVpuzzleOfTheDayBase
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DboVpuzzleOfTheDay"/> class.
        /// Initializes a new empty instance of the DboVpuzzleOfTheDay class.
        /// </summary>
        /// <example>
        /// <code>
        /// DboVpuzzleOfTheDay dboVpuzzleOfTheDay = new DboVpuzzleOfTheDay();
        /// </code>
        /// </example>
        public DboVpuzzleOfTheDay() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DboVpuzzleOfTheDay"/> class.
        /// Initializes a new empty instance of the DboVpuzzleOfTheDay class from the record in a data reader.
        /// </summary>
        /// <param name="record">A record returned from a database reader.</param>
        public DboVpuzzleOfTheDay(IDataRecord record) : base(record)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DboVpuzzleOfTheDay"/> class.
        /// Initializes a new empty instance of the DboVpuzzleOfTheDay class from a DataRow (via a <see cref="DataTable" /> usually part of a larger <see cref="DataSet" />).
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        public DboVpuzzleOfTheDay(DataRow record) : base(record)
        {
        }
        #endregion Extended Constructor(s)

        #region Extended Declarations
        DboVpuzzleOfTheDaySolution memberSolution = null;
        #endregion Extended Declarations

        #region Extended Properties
        public DboVpuzzleOfTheDaySolution MemberSolution 
        {
            get
            {
                if(memberSolution == null)
                {
                    memberSolution = new DboVpuzzleOfTheDaySolution();
                }

                return memberSolution;
            }
            set
            { 
                memberSolution = value;
            }
        }
        #endregion Extended Properties

        #region Extended Methods
        public string PuzzleDayFormatted
        {
            get
            {
                return PuzzleOfTheDayDate.ToString("dddd MMMM d, yyyy");
            }
        }
        
        public List<int> ColIndexes
        {
            get
            { 
                List<int> cols = new List<int>();
                for (int i = 0; i < Cols; i++)
                {
                    cols.Add(i);
                }

                return cols;
            }
        }
        public List<int> RowIndexes
        {
            get
            {
                List<int> rows = new List<int>();
                for (int i = 0; i < Rows; i++)
                {
                    rows.Add(i);
                }

                return rows;
            }
        }
        public List<List<int>> PuzzleCells
        {
            get
            {
                try
                {
                    List<List<int>> cells = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<int>>>(PuzzlePath.Split(':')[1].Replace("}", ""));

                    return cells;
                }
                catch(Exception e)
                {
                    return new List<List<int>>();
                }
            }
        }
            #endregion Extended Methods

        } // Class
} // Namespace