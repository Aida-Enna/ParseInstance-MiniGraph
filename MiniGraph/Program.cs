using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MiniGraph
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
	    
            Application.Run(new MiniGraph());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Message :" + e.Exception.Message + "<br/>" + Environment.NewLine + "StackTrace :" + e.Exception.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                logWriter.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
