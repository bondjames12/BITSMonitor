using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitsNet;
using MbUnit.Framework;

namespace BitsNet.Test
{
	[TestFixture]
	public class BitsManagerTest
	{
		[Row("url","jobName","directory")]
		[RowTest]
		public void AddJob(string url, string jobName, string directory)
		{
			BitsManager.AddJob(url, jobName, directory, true);
		}
	}
}
