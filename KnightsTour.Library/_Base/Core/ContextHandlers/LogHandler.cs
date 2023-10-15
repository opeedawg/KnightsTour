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
// File             : LogHandler.cs
// ************************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace KnightsTour
{
    /// <summary>
    /// Class LogHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.LogHandlerBase" />
    /// <seealso cref="KnightsTour.CoreLibrary.ILogHandler" />
    public class LogHandler : LogHandlerBase, KnightsTour.CoreLibrary.ILogHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LogHandler"/> class.
        /// </summary>
        /// <param name="logFormat">The log format.</param>
        /// <param name="writeFrequencySeconds">The write frequency seconds.</param>
        public LogHandler(KnightsTour.CoreLibrary.Enumerations.LogFormatOption logFormat = KnightsTour.CoreLibrary.Enumerations.LogFormatOption.JSON, int writeFrequencySeconds = 30): base()
        {
            try
            {
                //Enable everything
                //Enable(ApplicationTiers.Data);
                //Enable(LoggingActions.Exception);
                //Enable(LoggingActions.SQL);
                //Enable(LoggingActions.Audit);
                //Enable(LoggingActions.Debugging);

                Logs = new List<LogEvent>();
                Timer = new System.Timers.Timer();
                Timer.Elapsed += Timer_Elapsed;
                Timer.Interval = writeFrequencySeconds * 1000;
                Timer.Enabled = true;
                IsWriting = false;
                LogFormat = logFormat;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                WriteLogFile();
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        /// <value>The timer.</value>
        System.Timers.Timer Timer { get; set; }
        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>The logs.</value>
        List<LogEvent> Logs { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is writing.
        /// </summary>
        /// <value><c>true</c> if this instance is writing; otherwise, <c>false</c>.</value>
        bool IsWriting { get; set; }
        /// <summary>
        /// Gets the log file.
        /// </summary>
        /// <value>The log file.</value>
        string LogFile
        {
            get
            {
                return $"log_{DateTime.UtcNow.ToString("yyyy-MM-dd")}.txt";
            }
        }
        /// <summary>
        /// Gets or sets the log format.
        /// </summary>
        /// <value>The log format.</value>
        KnightsTour.CoreLibrary.Enumerations.LogFormatOption LogFormat { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public void Flush()
        {
            WriteLogFile();
        }
        /// <summary>
        /// Logs the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        /// <param name="data">The data.</param>
        /// <param name="extendedDetails">The extended details.</param>
        public void Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction action, string data, object extendedDetails = null)
        {
            try
            {
                if(Configuration[tier][action])
                    Logs.Add(new LogEvent(tier, action, data, new StackTrace(), extendedDetails));
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Private support methods
        /// <summary>
        /// Writes the log file.
        /// </summary>
        void WriteLogFile()
        {
            if (!IsWriting)
            {
                try
                {
                    Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, "Start");
                    IsWriting = true;
                    if (Logs.Count > 0)
                    {
                        //Write to a file
                        Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, $"Writing {Logs.Count} log lines...");
                        File.AppendAllLines(LogFile, GetCurrentLogLines());
                        Logs.Clear();
                    }
                    else
                    {
                        Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, "No log entries to write at this time.");
                    }
                }
                catch (Exception exception)
                {
                    Context.ExceptionHandler.HandleLogException(exception);
                }
                finally
                {
                    Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, "Complete");
                    IsWriting = false;
                }
            }
            else
            {
                Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, "Skipped log file writing");
            }
        }
        /// <summary>
        /// Gets the current log lines.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> GetCurrentLogLines()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (LogEvent log in Logs)
                    lines.Add(log.GetFormattedLine(LogFormat));
                return lines;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
            return null;
        }
        #endregion

        #region Support Classes
        /// <summary>
        /// Class LogEvent.
        /// </summary>
        class LogEvent
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LogEvent"/> class.
            /// </summary>
            /// <param name="tier">The tier.</param>
            /// <param name="action">The action.</param>
            /// <param name="data">The data.</param>
            /// <param name="stackTrace">The stack trace.</param>
            /// <param name="extendedDetails">The extended details.</param>
            public LogEvent(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction action, string data, StackTrace stackTrace, object extendedDetails = null)
            {
                Tier = tier;
                Action = action;
                Data = data;
                CreateDate = DateTime.UtcNow;

                KnightsTour.CoreLibrary.MethodAttributeAssistant detail = KnightsTour.CoreLibrary.ReflectionAssistant.GetMethodAttributes(stackTrace);
                Assembly = detail.Assembly;
                NameSpace = detail.NameSpace;
                Class = detail.Class;
                Method = detail.Method;

                ExtendedDetails = extendedDetails;
            }
            /// <summary>
            /// Gets or sets the tier.
            /// </summary>
            /// <value>The tier.</value>
            [JsonIgnore]
            public KnightsTour.CoreLibrary.Enumerations.ApplicationTier Tier { get; set; }
            /// <summary>
            /// Gets or sets the action.
            /// </summary>
            /// <value>The action.</value>
            [JsonIgnore]
            public KnightsTour.CoreLibrary.Enumerations.LoggingAction Action { get; set; }
            /// <summary>
            /// Gets or sets the create date.
            /// </summary>
            /// <value>The create date.</value>
            [JsonIgnore]
            public DateTime CreateDate { get; set; }
            /// <summary>
            /// Gets or sets the extended details.
            /// </summary>
            /// <value>The extended details.</value>
            [JsonIgnore]
            public object ExtendedDetails { get; set; }
            /// <summary>
            /// Gets the date string.
            /// </summary>
            /// <value>The date string.</value>
            public string DateString
            {
                get
                {
                    return CreateDate.ToString("yyyy-MM-dd");
                }
            }
            /// <summary>
            /// Gets the time string.
            /// </summary>
            /// <value>The time string.</value>
            public string TimeString
            {
                get
                {
                    return CreateDate.ToString("HH:mm:ss.fff");
                }
            }
            /// <summary>
            /// Gets the name of the tier.
            /// </summary>
            /// <value>The name of the tier.</value>
            public string TierName
            {
                get
                {
                    return Tier.ToString();
                }
            }
            /// <summary>
            /// Gets the name of the action.
            /// </summary>
            /// <value>The name of the action.</value>
            public string ActionName
            {
                get
                {
                    return Action.ToString();
                }
            }
            /// <summary>
            /// Gets or sets the assembly.
            /// </summary>
            /// <value>The assembly.</value>
            public string Assembly { get; set; }
            /// <summary>
            /// Gets or sets the name space.
            /// </summary>
            /// <value>The name space.</value>
            public string NameSpace { get; set; }
            /// <summary>
            /// Gets or sets the class.
            /// </summary>
            /// <value>The class.</value>
            public string Class { get; set; }
            /// <summary>
            /// Gets or sets the method.
            /// </summary>
            /// <value>The method.</value>
            public string Method { get; set; }
            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            public string Data { get; set; }
            /// <summary>
            /// Gets the extended details string.
            /// </summary>
            /// <value>The extended details string.</value>
            public string ExtendedDetailsString
            {
                get
                {
                    if (ExtendedDetails == null)
                        return string.Empty;
                    else
                    {
                        try
                        {
                            return JsonConvert.SerializeObject(ExtendedDetails);
                        }
                        catch (Exception exception)
                        {
                            return $"Unabled to serialize extended details: {exception.Message}";
                        }
                    }
                }
            }

            /// <summary>
            /// Gets the formatted line.
            /// </summary>
            /// <param name="format">The format.</param>
            /// <returns>System.String.</returns>
            /// <exception cref="Exception">Unhandled log format: " + format.ToString()</exception>
            public string GetFormattedLine(KnightsTour.CoreLibrary.Enumerations.LogFormatOption format)
            {
                try
                {
                    switch (format)
                    {
                        case KnightsTour.CoreLibrary.Enumerations.LogFormatOption.PipeDelimited:
                            return $"{DateString}|{TimeString}|{Tier.ToString()}|{Action.ToString()}|{Assembly}|{NameSpace}|{Class}|{Method}|{Data}|{ExtendedDetailsString}";
                        case KnightsTour.CoreLibrary.Enumerations.LogFormatOption.TabDelimited:
                            return $"{DateString}\t{TimeString}\t{Tier.ToString()}\t{Action.ToString()}\t{Assembly}\t{NameSpace}\t{Class}\t{Method}\t{Data}\t{ExtendedDetailsString}";
                        case KnightsTour.CoreLibrary.Enumerations.LogFormatOption.JSON:
                            return JsonConvert.SerializeObject(this) + ",";
                        default:
                            throw new Exception("Unhandled log format: " + format.ToString());
                    }
                }
                catch (Exception exception)
                {
                    Context.ExceptionHandler.HandleLogException(exception);
                }
                return null;
            }
        }
        #endregion
    }
}