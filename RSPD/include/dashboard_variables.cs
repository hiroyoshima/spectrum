using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using runnerDotNet;
namespace runnerDotNet
{
	public static partial class dashboard_Variables
	{
		public static void Apply()
		{
			GlobalVars.strTableName = new XVar("Dashboard");
			GlobalVars.gSettings = XVar.Clone(new ProjectSettings(new XVar("Dashboard")));
		}
	}

}
