using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;
using System.ComponentModel.Composition;
using System.Web;
using runnerDotNet;

namespace runnerDotNet
{
	[Export(typeof(IGlobalEventProviderCS))]
	public class CommonEventsCS : IGlobalEventProviderCS
	{

		// handlers

// After successful login
		public XVar AfterSuccessfulLogin(dynamic username, dynamic password, dynamic data, dynamic pageObject)
		{
MVCFunctions.HeaderRedirect("/dashboard/dashboard" );



XSession.Session["user"] = data["ID"];
return null;

		} // AfterSuccessfulLogin


		// onscreen events

		// table maps, buttons




		public XVar AfterTableInit(dynamic context)
		{
			var table = context["table"];
			var query = context["query"];
			context["query"] = query;
			return null;
		}

		public XVar GetTablePermissions(dynamic permissions, dynamic table = null)
		{
			return permissions;
		}

		public XVar IsRecordEditable(dynamic values, dynamic isEditable, dynamic table = null)
		{
			return isEditable;
		}
	}
}