using Architect.Utilities.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Architect.Utilities
{
    public static class Log
    {
        #region Properties

        public static string NameFile { get; set; }

        #endregion Properties

        #region WarningLog

        /// <summary>
        /// Overload method
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entry"></param>
        /// <remarks></remarks>
        public static void WarningLog(String source, String entry)
        {
            WarningLog(source, entry, String.Empty);
        }

        /// <summary>
        /// Overload of method
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entry"></param>
        /// <param name="prefix"></param>
        /// <remarks></remarks>
        public static void WarningLog(String source, String entry, String prefix)
        {
            WarningLog(source, entry, prefix, null);
        }

        /// <summary>
        /// Overrable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entry"></param>
        /// <param name="prefix"></param>
        /// <param name="customData"></param>
        /// <remarks></remarks>
        public static void WarningLog(String source, String entry, String prefix, Object customData)
        {
            WarningLog(source, entry, prefix, customData, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entry"></param>
        /// <param name="prefix"></param>
        /// <param name="customData"></param>
        /// <param name="Async"></param>
        public static void WarningLog(String source, String entry, String prefix, Object customData, bool Async)
        {
            
            String filename = String.Empty;
            string DebugMode = "File"; // System.Configuration.ConfigurationManager.AppSettings["Log.Mode"];

            String rootPath = GetPath();

            if (prefix.IsEmpty())
            {
                filename = String.Format(@"{0}\{1:yyyyMMdd}.Warning.log", rootPath, DateTime.Now);
            }
            else
            {
                filename = String.Format(@"{0}\{1:yyyyMMdd}.Warning.{2}.log", rootPath, DateTime.Now, prefix);
            }

            NameFile = filename;

            Dictionary<String, Object> parameters = new Dictionary<String, Object>();
            DateTime _DateEfective = DateTime.Now;
            parameters.With(p =>
            {
                p.Add("DateEfective", _DateEfective.ToString("hh:mm:ss.fff"));
                p.Add("FileName", filename);
                p.Add("Source", source);
                p.Add("Entry", entry);
                p.Add("ThreadId", Thread.CurrentThread.ManagedThreadId);
                p.Add("DebugMode", DebugMode);
                p.Add("CustomData", customData);
                if (HttpContext.Current.IsNotEmpty() &&
                    HttpContext.Current.Session.IsNotEmpty())
                {
                    p.Add("SessionID", HttpContext.Current.Session.SessionID);
                }
                else
                {
                    p.Add("SessionID", "");
                }
            });

            if (Async)
            {
                var AddUsersSecurityTraceAsyn = new Task(ActionWarningLog, parameters);
                AddUsersSecurityTraceAsyn.Start();
            }
            else
            {
                while (WarningLogInternal(parameters) == false)
                {
                    Thread.Sleep(800);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameterInternal"></param>
        /// <returns></returns>
        private static bool WarningLogInternal(Dictionary<string, object> parameterInternal)
        {
            bool result = false;
            string _FileName = parameterInternal["FileName"].ToString();
            string _IP = Helpers.Connection.GetIPRequest();
            string _Source = parameterInternal["Source"].ToString();
            string _Entry = parameterInternal["Entry"].ToString();
            string _DateEfective = parameterInternal["DateEfective"].ToString();
            string _ThreadId = parameterInternal["ThreadId"].ToString();
            string _SessionID = parameterInternal["SessionID"].ToString();
            string _DebugMode = parameterInternal["DebugMode"].ToString();
            Object _CustomData = parameterInternal["CustomData"];
            FileStream fs = null;

            try
            {
                if (File.Exists(_FileName))
                {
                    fs = File.Open(_FileName, FileMode.Append);
                }
                else
                {
                    fs = File.Create(_FileName);
                }

                StreamWriter sw = new StreamWriter(fs);
                DateTime thisDate = DateTime.Now;

                sw.WriteLine(String.Format("{0} {3} {4} {5} {1} {2}", _DateEfective, _Source, _Entry, Helpers.Connection.NameHostFromIp(_IP), _ThreadId, _SessionID));
                sw.Close();

                fs.Close();

                if (!_DebugMode.Equals("File"))
                {
                    //    Dim temporalLog As New EventLogClient.EventLog
                    //    With temporalLog
                    //        .FactTime = DateTime.Now
                    //        .HostSource = Connection.NameHostFromIp(_IP)
                    //        .TypeTrace = Convert.ToInt32(Enumerations.EnumTraceType.Warrning)
                    //        .Source = _Source
                    //        .Entry = String.Format("{0}{1} Seccion Id:{2}", _Entry, vbLf, _SessionID)
                    //        If Not IsNothing(_CustomData) AndAlso Serialize.IsSerializable(_CustomData) Then
                    //            Dim dataCustom  = Serialize.SerializarObject(_CustomData)
                    //            .EventLogDetail = New EventLogClient.EventLogDetail With {.Detail = dataCustom}
                    //} else {
                    //    End With
                    //    Using EventLogClient As New EventLogClient.ManagerClient
                    //        EventLogClient.LogSave(temporalLog)
                    //    End Using
                }
                result = true;
            }
            catch (IOException exIO)
            {
                if (Marshal.GetHRForException(exIO) == -2147024864)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = true;
            }
            finally
            {
                if (fs.IsNotEmpty())
                {
                    fs.Close();
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        private static Action<Object> ActionWarningLog = (object parameterContainer) =>
        {
            Dictionary<String, Object> parameterInternal = (Dictionary<String, Object>)parameterContainer;
            int attempts = 1;
            while (WarningLogInternal(parameterInternal) == false && attempts < 4)
            {
                Thread.Sleep(800);
                attempts = attempts + 1;
            }
        };

        #endregion WarningLog

        #region TraceLog

        /// <summary>
        /// Writes an entry in the logbook file for trace
        /// </summary>
        /// <param name="source">Key associated with the originating source registration</param>
        /// <param name="entry">Information to be recorded</param>
        public static void TraceLog(string source, string entry)
        {
            TraceLog(source, entry, "Trace");
        }

        public static void TraceLog(string source, string entry, string prefix)
        {
            TraceLog(source, entry, prefix, null);
        }

        /// <summary>
        /// Overload method
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entry"></param>
        /// <param name="prefix"></param>
        /// <param name="customData"></param>
        /// <remarks></remarks>
        public static void TraceLog(string source, string entry, string prefix, Object customData)
        {
            TraceLog(source, entry, prefix, customData, true);
        }

        public static void TraceLog(String source, String entry, String prefix, Object customData, bool Async)
        {
            try
            {
             
                String filename = String.Empty;
                string DebugMode = "File";
                string format = "log";
                bool _logDebug = true;
                bool modeMultiThread = true;

                //if (System.Configuration.ConfigurationManager.AppSettings["Log.Mode"].IsNotEmpty())
                //{
                //    DebugMode = System.Configuration.ConfigurationManager.AppSettings["Log.Mode"];
                //}

                if (System.Configuration.ConfigurationManager.AppSettings["Architect.DataFactory.Log.MultiThread"].IsNotEmpty())
                {
                    modeMultiThread = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Architect.DataFactory.Log.MultiThread"].ToString());
                }

                if (System.Configuration.ConfigurationManager.AppSettings["Log.Debug"].IsNotEmpty())
                {
                    _logDebug = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Log.Debug"].ToString());
                }

                if (System.Configuration.ConfigurationManager.AppSettings["Log.Format"].IsNotEmpty())
                {
                    format = System.Configuration.ConfigurationManager.AppSettings["Log.Format"].ToString();
                }

                String rootPath = GetPath();

                if (_logDebug)
                {
                    if (prefix.IsEmpty())
                    {
                        filename = String.Format(@"{0}\{1:yyyyMMdd}.{2}", rootPath, DateTime.Now, prefix);
                    }
                    else
                    {
                        filename = String.Format(@"{0}\{1:yyyyMMdd}.{2}.{3}", rootPath, DateTime.Now, prefix, prefix);
                    }

                    filename = filename + string.Format(".{0}", format);

                    NameFile = filename;

                    Dictionary<String, Object> parameters = new Dictionary<String, Object>();
                    parameters.With(p =>
                    {
                        DateTime _DateEfective = DateTime.Now;
                        p.Add("DateEfective", _DateEfective.ToString("hh:mm:ss.fff"));
                        p.Add("DateEfectiveRaw", _DateEfective);
                        p.Add("FileName", filename);
                        p.Add("Source", source);
                        p.Add("Entry", entry);
                        p.Add("Format", format);
                        p.Add("ThreadId", Thread.CurrentThread.ManagedThreadId);
                        p.Add("DebugMode", DebugMode);
                        p.Add("CustomData", customData);
                        if (HttpContext.Current.IsNotEmpty() &&
                                           HttpContext.Current.Session.IsNotEmpty())
                        {
                            p.Add("SessionID", HttpContext.Current.Session.SessionID);
                        }
                        else
                        {
                            p.Add("SessionID", "");
                        }
                    });

                    if (modeMultiThread)
                    {
                        if (Async)
                        {
                            var AddUsersSecurityTraceAsyn = new Task(ActionTraceLog, parameters);
                            AddUsersSecurityTraceAsyn.Start();
                        }
                        else
                        {
                            while (TraceLogInternal(parameters) == false)
                            {
                                Thread.Sleep(800);
                            }
                        }
                    }
                    else
                    {
                        TraceLogInternal(parameters);
                    }
                }
            }
            catch (Exception ex)
            {
                var IsWrited = false;
                while (IsWrited == false)
                {
                    try
                    {
                        var folder = new Uri(typeof(Log).Assembly.CodeBase).LocalPath;
                        folder = Path.GetDirectoryName(folder);
                        string fileName = string.Format(@"{0}\error.text", folder);
                        StringBuilder body = new StringBuilder();
                        body.AppendLine(string.Format("Error:{0}", DateTime.Now.ToString("{1:yyyyMMdd}")));
                        body.AppendLine(string.Format("      Message:{0}", ex.Message));
                        body.AppendLine(string.Format("      Stack:{0}", ex.StackTrace));
                        if (!System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Create(fileName);
                        }
                        System.IO.File.AppendAllText(fileName, body.ToString());
                        IsWrited = true;
                    }
                    catch (IOException exIO)
                    {
                        if (Marshal.GetHRForException(exIO) == -2147024864)
                        {
                            IsWrited = false;
                        }
                        else
                        {
                            IsWrited = true;
                        }
                    }
                    catch (Exception)
                    {
                        IsWrited = true;
                    }
                    Thread.Sleep(800);
                }
            }
        }

        /// <summary>
        /// Internal method of the Tracelog
        /// </summary>
        /// <param name="pParamters"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static bool TraceLogInternal(Dictionary<String, Object> pParamters)
        {
            bool Result = false;
            Dictionary<String, Object> parameterInternal = pParamters;
            FileStream fs = null;
            string _FileName = string.Empty, _IP = string.Empty, _Source = string.Empty, _Entry = string.Empty, _DateEfective = string.Empty, _ThreadId = string.Empty, _SessionID = string.Empty, _DebugMode = string.Empty, _Format = string.Empty;
            DateTime _DataEfectiveRaw = DateTime.MinValue;
            Object _CustomData;

            parameterInternal.With(p =>
            {
                _FileName = p["FileName"].ToString();
                _IP = Helpers.Connection.GetIPRequest();
                _Source = parameterInternal["Source"].ToString();
                _Entry = parameterInternal["Entry"].ToString();
                _DateEfective = parameterInternal["DateEfective"].ToString();
                _ThreadId = parameterInternal["ThreadId"].ToString();
                _SessionID = parameterInternal["SessionID"].ToString();
                _DebugMode = parameterInternal["DebugMode"].ToString();
                _CustomData = parameterInternal["CustomData"];
                _Format = parameterInternal["Format"].ToString();
                _DataEfectiveRaw = (DateTime)parameterInternal["DateEfectiveRaw"];
            });

            try
            {
                if (File.Exists(_FileName))
                {
                    fs = File.Open(_FileName, FileMode.Append);
                }
                else
                {
                    fs = File.Create(_FileName);
                }

                StreamWriter sw = new StreamWriter(fs);
                if (_Format.Equals("csv", StringComparison.CurrentCultureIgnoreCase))
                {
                    _Source = _Source.Replace(Environment.NewLine, string.Empty);
                    _Entry = _Entry.Replace(Environment.NewLine, string.Empty);
                    sw.WriteLine(String.Format("{0},{3},{4},{5},{1},{2} ", string.Format("{0:h:mm:ss.fff tt}", _DataEfectiveRaw), _Source, _Entry, Helpers.Connection.NameHostFromIp(_IP), _ThreadId, _SessionID));
                }
                else
                {
                    sw.WriteLine(String.Format("{0} {3} {4} {5} {1} {2} ", _DateEfective, _Source, _Entry, Helpers.Connection.NameHostFromIp(_IP), _ThreadId, _SessionID));
                }
                sw.Close();
                fs.Close();
                if (!_DebugMode.Equals("File"))
                {
                }
                Result = true;
            }
            catch (IOException exIO)
            {
                if (Marshal.GetHRForException(exIO) == -2147024864)
                {
                    Result = false;
                }
                else
                {
                    Result = true;
                }
            }
            catch (Exception)
            {
                Result = true;
            }
            finally
            {
                if (fs.IsNotEmpty())
                {
                    fs.Close();
                }
            }

            return Result;
        }

        private static Action<Object> ActionTraceLog = (object parameterContainer) =>
        {
            Dictionary<String, Object> parameterInternal = (Dictionary<String, Object>)parameterContainer;
            int attempts = 1;
            while (TraceLogInternal(parameterInternal) == false && attempts < 4)
            {
                Thread.Sleep(800);
                attempts = attempts + 1;
            }
        };

        #endregion TraceLog

        #region Error

        public static bool ErrorLogInternal(Dictionary<string, Object> parameterInternal)
        {
            Boolean result = false;
            FileStream fs = null;
            string _fileName = "";
            String _DateEfective;
            String _IP = "";
            String _Source = "";
            Exception _CurrentException = null;
            String _Entry = "";
            StackTrace _ExceptionStack = null;
            StringBuilder _ServerVariables = null;
            String _SessionID = "";
            String _Code = "";
            string _DebugMode = "";
            parameterInternal.With(f =>
            {
                _Code = (string)f["Code"];
                _fileName = (string)f["FileName"];
                _DateEfective = (string)f["DateEfective"];
                _IP = Helpers.Connection.GetIPOnlyRequest();
                _Source = (string)f["Source"];
                _CurrentException = (Exception)f["CurrentException"];
                _Entry = (string)(string)f["Entry"];
                _ExceptionStack = (StackTrace)f["ExceptionStack"];
                _ServerVariables = (StringBuilder)f["ServerVariables"];
                _DebugMode = (string)f["DebugMode"];
                _SessionID = (string)f["SessionID"];
            });

            try
            {
                if (File.Exists(_fileName))
                {
                    fs = File.Open(_fileName, FileMode.Append);
                }
                else
                {
                    fs = File.Create(_fileName);
                }

                StreamWriter sw = new StreamWriter(fs);
                string stringTemporal = string.Format("{0} {1} {2}", _IP, Helpers.Connection.NameHostFromIp(_IP), _Source);

                sw.WriteLine(stringTemporal);

                if (_CurrentException.IsNotEmpty())
                {
                    TraceInnerExceptionMessage2(_CurrentException, 1, sw);
                    TraceInnerExceptionData(_CurrentException, 1, sw);
                }

                sw.With(f =>
                {
                    f.WriteLine(string.Format(" Code:{0}", _Code));
                    if (_Entry.IsNotEmpty())
                    {
                        f.WriteLine((" Entry: " + _Entry));
                    }

                    f.WriteLine((" Session Id:" + _SessionID));
                });

                if (_ServerVariables.IsNotEmpty() && _ServerVariables.ToString().IsNotEmpty())
                {
                    sw.With(f =>
                    {
                        f.WriteLine(_ServerVariables.ToString());
                    });
                }

                if (_CurrentException.IsNotEmpty())
                {
                    StackTrace ExceptionStack = new StackTrace(_CurrentException, true);
                    StackFrame[] _VectorStack = ExceptionStack.GetFrames();

                    if (_VectorStack.IsNotEmpty())
                    {
                        int _Index = _VectorStack.Length;
                        if (_Index - (_Index - 1) > 0)
                        {
                            var ExceptionFrame = ExceptionStack.GetFrame(_Index - 1);

                            sw.With(f =>
                            {
                                f.WriteLine(("Method: " + ExceptionFrame.GetMethod().ToString()));
                                f.WriteLine(string.Format(" at {0},{1}", ExceptionFrame.GetFileLineNumber(), ExceptionFrame.GetFileColumnNumber()));
                                f.WriteLine((" Class: " + ExceptionFrame.GetMethod().DeclaringType.ToString()));
                                f.WriteLine(("  File: " + ExceptionFrame.GetFileName()));
                                f.WriteLine(" Stack:");
                                f.WriteLine(ExceptionStack.ToString().Replace("   at ", "  "));
                            });
                        }
                    }
                }
                else
                {
                    StackFrame[] stat = _ExceptionStack.GetFrames();
                    var ExceptionFrame = stat[2];
                    sw.With(f =>
                    {
                        f.Write(("Method: " + ExceptionFrame.GetMethod().ToString()));
                        f.WriteLine(string.Format(" at {0},{1}", ExceptionFrame.GetFileLineNumber(), ExceptionFrame.GetFileColumnNumber()));
                        f.WriteLine(string.Format(" Class: {0}", ExceptionFrame.GetMethod().DeclaringType));
                        f.WriteLine(string.Format("  File: {0}", ExceptionFrame.GetFileName()));
                        f.WriteLine(" Stack:");
                        f.WriteLine(_ExceptionStack.ToString().Replace("   at ", "  "));
                    });
                }

                sw.Close();
                fs.Close();

                result = true;
            }
            catch (IOException exIO)
            {
                if ((Marshal.GetHRForException(exIO) == -2147024864))
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = true;
            }
            finally
            {
                if (fs.IsNotEmpty())
                {
                    fs.Close();
                }
            }

            return result;
        }
        
        public static void ErrorLog(Exception currentException)
        {
            ErrorLog(Helpers.Assembly.GetFrameProcessFullName(2), String.Empty, currentException, String.Empty);
        }
        public static string ErrorLog(Exception currentException, string code)
        {
            return ErrorLog(Helpers.Assembly.GetFrameProcessFullName(2), String.Empty, currentException, String.Empty, true, code);
        }


        // '' <summary>
        // '' Writes an entry in the logbook file for errors
        // '' </summary>
        // '' <param name="source">Key associated with the originating source registration</param>
        // '' <param name="entry">Information to be recorded</param>
        public static void ErrorLog(string source, string entry)
        {
            ErrorLog(source, entry, null, String.Empty);
        }
        public static void ErrorLog(string source, string entry, string prefix)
        {
            ErrorLog(source, entry, null, prefix);
        }
        public static void ErrorLog(string source, string entry, Exception currentException)
        {
            ErrorLog(source, entry, currentException, String.Empty);
        }

        public static void ErrorLog(string source, string entry, Exception currentException, string prefix)
        {
            ErrorLog(source, entry, currentException, prefix, true, String.Empty);
        }

        // '' <summary>
        // '' Writes an entry in the logbook file for errors
        // '' </summary>
        // '' <param name="source">Key associated with the originating source registration</param>
        // '' <param name="entry">Information to be recorded</param>
        // '' <param name="currentException">Exception that gives rise to record</param>
        public static void ErrorLog(string source, string entry, Exception currentException, string prefix, bool Async)
        {
            ErrorLog(source, entry, currentException, prefix, false, String.Empty);
        }

        private static void TraceInnerExceptionMessage2(Exception ex, int level, StreamWriter sw)
        {
            level = level + 1;
            if (ex.InnerException.IsNotEmpty())
            {
                TraceInnerExceptionMessage2(ex.InnerException, level, sw);
            }
            sw.WriteLine(string.Format(" {1}({0}) {2}", ex.GetType().Name, " ".PadLeft(level), ex.Message));
        }

        // '' <summary>
        // '' Writes an entry in the logbook file for errors
        // '' </summary>
        // '' <param name="source">Key associated with the originating source registration</param>
        // '' <param name="entry">Information to be recorded</param>
        // '' <param name="currentException">Exception that gives rise to record</param>
        // '' <param name="prefix"></param>
        // '' <param name="Async"></param>
        // '' <param name="Code"></param>
        // '' <remarks></remarks>
        public static string ErrorLog(string source, string entry, Exception currentException, string prefix, bool Async, string Code)
        {
            string rootPath = GetPath();
            bool modeMultiThread = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Architect.DataFactory.Log.MultiThread"].ToString());
            //FileStream fs = null;
            string filename = String.Empty;
            string DebugMode = "File";// System.Configuration.ConfigurationManager.AppSettings["Log.Mode"].ToString();

            string logPrefix = String.Empty;  //System.Configuration.ConfigurationManager.AppSettings["Log.Prefix"].ToString();

            if (Code.IsEmpty())
            {
                Code = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.fff");
            }

            if (prefix.IsEmpty())
            {
                prefix = logPrefix;
            }

            if (prefix.IsEmpty())
            {
                filename = string.Format("{0}\\{1:yyyyMMdd}.error.log", rootPath, DateTime.Now);
            }
            else
            {
                filename = string.Format("{0}\\{1:yyyyMMdd}.error.{2}.log", rootPath, DateTime.Now, prefix);
            }

            NameFile = filename;

            StringBuilder ServerVariables = new StringBuilder();

            if (HttpContext.Current.IsNotEmpty())
            {
                if (HttpContext.Current.Request.IsNotEmpty())
                {
                    if (HttpContext.Current.Request.ServerVariables.IsNotEmpty())
                    {
                        string value = "";
                        ServerVariables.With(f =>
                        {
                            f.AppendLine(("RawUrl: " + HttpContext.Current.Request.Url.LocalPath));
                            f.AppendLine(("   Query: " + HttpContext.Current.Request.QueryString.ToString()));
                            f.AppendLine("    Form: " + HttpContext.Current.Request.Form.ToString());
                            f.Append(" Session: ");
                            if (HttpContext.Current.Session.IsNotEmpty())
                            {
                                foreach (string key in HttpContext.Current.Session.Keys)
                                {
                                    if (HttpContext.Current.Session[key].IsNotEmpty())
                                    {
                                        value = HttpContext.Current.Session[key].ToString();
                                        if (value.IsNotEmpty() && (value.Length > 20))
                                        {
                                            value = (value.Substring(0, 20) + "...");
                                        }

                                        f.Append(string.Format("{0}={1}&", key, value));
                                    }
                                    else
                                    {
                                        f.Append(String.Format("{0}={1}&", key, "Null"));
                                    }
                                }
                            }
                            else
                            {
                                f.Append("Not Enable Session");
                            }
                        });
                    }
                }
            }

            Dictionary<string, Object> parameters = new Dictionary<string, object>();

            parameters.With(f =>
            {
                f.Add("Code", Code);
                f.Add("DateEfective", DateTime.Now.ToString("hh:mm:ss.fff"));
                f.Add("FileName", filename);
                f.Add("Source", source);
                f.Add("Entry", entry);
                f.Add("CurrentException", currentException);
                f.Add("ThreadId", Thread.CurrentThread.ManagedThreadId);
                f.Add("ExceptionStack", new StackTrace(true));
                f.Add("ServerVariables", ServerVariables);
                if (HttpContext.Current.IsNotEmpty() && HttpContext.Current.Session.IsNotEmpty())
                {
                    f.Add("SessionID", HttpContext.Current.Session.SessionID);
                }
                else
                {
                    f.Add("SessionID", "");
                }
                f.Add("DebugMode", DebugMode);
            });

            if (modeMultiThread)
            {
                if (Async)
                {
                    var AddUsersSecurityTraceAsyn = new Task(ActionErrorLog, parameters);
                    AddUsersSecurityTraceAsyn.Start();
                }
                else
                {
                    while (ErrorLogInternal(parameters) == false)
                    {
                        Thread.Sleep(800);
                    }
                }
            }
            else
            {
                ErrorLogInternal(parameters);
            }
            return Code;
        }

        private static Action<Object> ActionErrorLog = (object parameterContainer) =>
        {
            Dictionary<String, Object> parameterInternal = (Dictionary<String, Object>)parameterContainer;
            int attempts = 1;
            while (ErrorLogInternal(parameterInternal) == false && attempts < 4)
            {
                Thread.Sleep(800);
                attempts = attempts + 1;
            }
        };

        private static void TraceInnerExceptionData(Exception ex, int level, StreamWriter sw)
        {
            level = level + 1;
            if (ex.InnerException.IsNotEmpty())
            {
                TraceInnerExceptionData(ex.InnerException, level, sw);
            }
            sw.With(f =>
            {
                if ((ex.Data.Count > 0))
                {
                    f.WriteLine(string.Format(" {1}({0}) Details:", ex.GetType().Name, " ".PadLeft(level)));
                    foreach (DictionaryEntry item in ex.Data)
                    {
                        f.WriteLine("   Key: {0,-20}  Value: {1}", item.Key, item.Value);
                    }
                }
            });
        }

        #endregion Error

        public static String GetPath()
        {
            string rootPath = System.Configuration.ConfigurationManager.AppSettings["Path.Logs"];
            if (rootPath.IsEmpty())
            {
                rootPath = string.Format("{0}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            }

            return rootPath;
        }

        public static string GetFileName()
        {
            String result = String.Empty;
            result = GetPath();
            return result;
        }
    }
}