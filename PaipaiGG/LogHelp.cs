using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PaipaiGG
{

    public class TraceHelper
    {
        private static TraceHelper _traceHelper;

        private TraceHelper()
        {
        }

        public static TraceHelper GetInstance()
        {
            if (_traceHelper == null)
                _traceHelper = new TraceHelper();

            return _traceHelper;
        }

        public void Error(string message, string module)
        {
            Log(message, MessageType.Error, module);
        }

        public void Error(Exception ex, string module)
        {
            Log(ex.StackTrace, MessageType.Error, module);
        }

        public void Warning(string message, string module)
        {
            Log(message, MessageType.Warning, module);
        }

        public void Info(string message, string module)
        {
            Log(message, MessageType.Information, module);
        }

        private void Log(string message, MessageType type, string module)
        {
            Trace.WriteLine(
                string.Format("{0},{1},{2},{3}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                type.ToString(),
                module,
                message));
        }
    }

    public enum MessageType
    {
        Information = 0,
        Warning = 1,
        Error = 2
    }

    class MyTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            File.AppendAllText(Application.StartupPath + "\\info.log", message);
        }

        public override void WriteLine(string message)
        {
            File.AppendAllText(Application.StartupPath + "\\info.log", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss    ") + message + Environment.NewLine);
        }
    }
}
