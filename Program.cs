﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Diagnostics;
using BitsMonitor.Properties;
using System.Net;

namespace BitsMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // if app was invoked with parameters - do not start GUI, just add new download to BITS
            // (should manager be started AFTER adding new download?)
            // otherwise start GUI application - to manage all downloads
            if (args.Length > 0)
            {
                AddJob(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
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
            }

            if ((url == string.Empty) || (directory == string.Empty) || (!Directory.Exists(directory)))
            {
                Environment.Exit(1);
            }
			if (url.ToLower().StartsWith("ftp"))
			{
				MessageBox.Show("FTP is not supported by BITS!");
				Environment.Exit(2);
			}

            if ((directory.Length == 2) && (directory[1] == ':'))
                directory = directory + '\\';
			string filename = HttpUtility.UrlDecode( url.Substring( url.LastIndexOf("/") +1 ) );
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
