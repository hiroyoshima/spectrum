using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;
using System.ComponentModel.Composition;
using runnerDotNet;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace runnerDotNet
{
	[Export(typeof(ICustomExpressionProviderCS))]
	public class CustomExpressionProviderCS : ICustomExpressionProviderCS
	{
		public XVar GetCustomExpression(XVar value, XVar data, XVar field, XVar ptype, XVar table = null)
		{
			if(table == "dbo.rspd_application_received"  &&  field == "view_data")
			{
//value = "<a href='/applicationsrecieved/list?q=%28id~equals~".data["id"].ToString()."%29&orderby=did' target='_blank'>View</a>";
;return value;
			}
			return value;
		}

		public XVar GetFileCustomExpression(XVar file, XVar data, XVar field, XVar ptype, XVar table = null)
		{
			XVar value = "";
			return value;
		}

		public XVar GetLWWhere(XVar field, XVar ptype, XVar table = null)
		{
			return "";
		}

		public XVar GetDefaultValue(XVar field, XVar ptype, XVar table = null)
		{
			if(table == "admin_users"  &&  field == "groupid")
			{
				var tmpVal = 3;
				return XVar.Pack(tmpVal);
			}
			if(table == "admin_users"  &&  field == "active")
			{
				var tmpVal = 1;
				return XVar.Pack(tmpVal);
			}
			return "";
		}

		public XVar GetAutoUpdateValue(XVar field, XVar ptype, XVar table = null)
		{
			return "";
		}

		public XVar getCustomMapIcon(XVar field, XVar table, XVar data)
		{
			XVar icon = "";
			return "";
		}

		public XVar getDashMapCustomIcon(XVar dashName, XVar dashElementName, XVar data)
		{
			XVar icon = "";
			return "";
		}

		public XVar getDashMapCustomLocationIcon(XVar dashName, XVar dashElementName, XVar data)
		{
			XVar icon = "";
			return "";
		}

		public XVar GetUploadFolderExpression(XVar field, XVar file, XVar table = null)
		{
			return "";
		}

		public XVar GetIntervalLimitsExprs(XVar table, XVar field, XVar idx, XVar isLowerBound)
		{
			return "";
		}
	}
}