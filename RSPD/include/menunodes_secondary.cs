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
	public partial class CommonFunctions
	{
		public static XVar GetMenuNodessecondary()
		{
			dynamic menuNode = XVar.Array(), menuNodes = XVar.Array();
			menuNodes = XVar.Clone(XVar.Array());
			GlobalVars.menuNodesCache.InitAndSetArrayItem(menuNodes, "secondary");
			return null;
		}
	}
}
