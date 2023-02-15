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
	public partial class WebreportPage : RunnerPage
	{
		protected static bool skipWebreportPageCtor = false;
		public WebreportPage(dynamic var_params)
			:base((XVar)var_params)
		{
			if(skipWebreportPageCtor)
			{
				skipWebreportPageCtor = false;
				return;
			}
		}
		protected override XVar setTableConnection()
		{
			this.connection = XVar.Clone(GlobalVars.cman.getDefault());
			return null;
		}
	}
}
