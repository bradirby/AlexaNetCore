using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaNetCore
{
     public class LogHistory
    {
        public int MaxHistoryToKeep { get; set; } = 30;

        private readonly Queue<LogHistoryRow> _history = new Queue<LogHistoryRow>();


        public void Debug(string msg)
        {
            EnqueueItem(new LogHistoryRow(LogHistoryType.Debug, msg));
        }

        public void Warning(string msg)
        {
            EnqueueItem(new LogHistoryRow(LogHistoryType.Warn, msg));
        }

        public void Information(string msg)
        {
            EnqueueItem(new LogHistoryRow(LogHistoryType.Info, msg));
        }

        public void Error(string msg)
        {
            EnqueueItem(new LogHistoryRow(LogHistoryType.Error, msg));
        }
        
        private void EnqueueItem(LogHistoryRow row)
        {
            _history.Enqueue(row);
            if (_history.Count > MaxHistoryToKeep) _history.Dequeue();
        }

        public List<string> GetLogHistory()
        {
            var lst = new List<string>();
            foreach (var logRow in _history.ToList())
            {
                switch (logRow.Logtype)
                {
                    case LogHistoryType.Debug:
                        lst.Add($"DEBUG:{logRow.Msg}");
                        break;
                    case LogHistoryType.Info:
                        lst.Add($"INFO:{logRow.Msg}");
                        break;
                    case LogHistoryType.Warn:
                        lst.Add($"WARNING:{logRow.Msg}");
                        break;
                    case LogHistoryType.Error:
                        lst.Add($"ERROR:{logRow.Msg}");
                        break;
                    case LogHistoryType.Exception:
                        lst.Add($"DEBUG:{logRow.Msg} : {logRow.Exc.Message}");
                        break;
                    default:
                        lst.Add($"ERROR:{logRow.Msg}");
                        break;
                }
            }

            return lst;
        }

        internal enum LogHistoryType
        {
            Debug,
            Info,
            Warn,
            Error,
            Exception
        }

        internal class LogHistoryRow
        {
            public LogHistoryType Logtype { get;set;}
            public string Msg { get;set;}
            public Exception Exc { get; set; }

            public LogHistoryRow(LogHistoryType typ, string msg)
            {
                Logtype = typ;
                Msg = msg;
            }
            public LogHistoryRow(LogHistoryType typ, string msg, Exception exc)
            {
                Exc = exc;
                Logtype = typ;
                Msg = msg;
            }
        }
    }

}
