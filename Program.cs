using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Diagnostics;
using BitsMonitor.Properties;
using System.Net;
using NLog;
using System.Security.Permissions;
using System.Security;

namespace BitsMonitor
{
	public enum UnhandledExceptionType
	{
		WinForms,
		CLR
	}

	static class Program
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			// if app was invoked with parameters - do not start GUI, just add new download to BITS
			// (should manager be started AFTER adding new download?)
			// otherwise start GUI application - to manage all downloads
			if (args.Length > 0)
			{
				AddJob(args);
			}
			else
			{
				Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
		}

		// handling unhandled exceptions (CLR)
		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			LogError(e.ExceptionObject as Exception, UnhandledExceptionType.CLR);
		}

		// handlind WinForms unhandled exceptions
		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			LogError(e.Exception, UnhandledExceptionType.WinForms);
		}

		static void LogError(Exception e, UnhandledExceptionType exType)
		{
			ExceptionInfo einfo = new ExceptionInfo();
			einfo.ShowDialog();
			string userinfo = einfo.UserProvidedInformation;
			
			string exceptionData = e.ToString();
			string logmessage = string.Format("exception type: {0} {1} {2}{1} - - - - - - - - {1}User provided information: {3}{1}{1}", exType.ToString(), Environment.NewLine, exceptionData, userinfo);
			Logger.Log(LogLevel.Error, logmessage);

			Application.Exit();
			//logger.LogException(LogLevel.Error, string.Format("exception type: {0}", exType.ToString()), e);
		}

		/// <summary>
		/// Adds job to BITS using command line parameters:
		/// </summary>
		/// <param name="args"></param>
		public static void AddJob(string[] args)
		{
			string url = string.Empty;
			string directory = string.Empty;
			string cookie = string.Empty;
			bool showMessageBox = true;

			if (args.Length < 4)
				Environment.Exit(1);

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].Contains("--url:"))
				{
					url = args[i + 1];
					continue;
				}
				if (args[i].Contains("--dir:"))
				{
					directory = args[i + 1];
					continue;
				}
				if (args[i].Contains("--n"))
				{
					showMessageBox = false;
					continue;
				}
			}

			if ((url == string.Empty) || (directory == string.Empty) || (!Directory.Exists(directory)))
			{
				if (showMessageBox)
					MessageBox.Show("No desitnation folder specified","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(1);
			}
			if (url.ToLower().StartsWith("ftp"))
			{
				if (showMessageBox)
					MessageBox.Show("FTP is not supported by BITS!"); // no message box should be shown
				Environment.Exit(2);
			}
			FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, directory);
			if (!SecurityManager.IsGranted(writePermission))
			{
				if (showMessageBox)
					MessageBox.Show("No write permission", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(3);
			}

			if ((directory.Length == 2) && (directory[1] == ':'))
				directory = directory + '\\';
			string filename = HttpUtility.UrlDecode(url.Substring(url.LastIndexOf("/") + 1));
			if (filename.Contains("?"))
			{
				filename = Utility.TryExtractFilename(filename);
				if (filename == string.Empty)
				{
					MessageBox.Show("Unable to retrieve file name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Environment.Exit(2);
				}
			}
			BitsNet.BitsManager.AddJob(url, filename, directory, Settings.Default.AutoStartBitsJob);
		}

	}
}
