using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BitsMonitor
{
	class Utility
	{
		public static string GetFileNameFromUrlWithGet(string fileName)
		{
			fileName = fileName.Substring(fileName.IndexOf("?"), fileName.Length - fileName.IndexOf("?"));
			Regex exp = new Regex(@"\?.*=");
			if (exp.IsMatch(fileName))
			{
				MatchCollection mc = exp.Matches(fileName);
				for (int i = mc.Count - 1; i >= 0; i--)
				{
					fileName = fileName.Remove(mc[i].Index, mc[i].Length);
				}
			}
			return "";
		}

	}
}
