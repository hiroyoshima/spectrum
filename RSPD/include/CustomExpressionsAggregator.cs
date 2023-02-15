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
	public interface ICustomExpressionProvider
	{
		XVar GetCustomExpression(XVar value, XVar data, XVar field, XVar ptype, XVar table = null);
		XVar GetFileCustomExpression(XVar file, XVar data, XVar field, XVar ptype, XVar table = null);
		XVar GetLWWhere(XVar field, XVar ptype, XVar table = null);
		XVar GetDefaultValue(XVar field, XVar ptype, XVar table = null);
		XVar GetAutoUpdateValue(XVar field, XVar ptype, XVar table = null);
		XVar GetUploadFolderExpression(XVar field, XVar file, XVar table = null);
		XVar GetIntervalLimitsExprs(XVar table, XVar field, XVar idx, XVar isLowerBound);
		XVar getCustomMapIcon(XVar field, XVar table, XVar data);
		XVar getDashMapCustomIcon(XVar dashName, XVar dashElementName, XVar data);
		XVar getDashMapCustomLocationIcon(XVar dashName, XVar dashElementName, XVar data);
	}

	public interface ICustomExpressionProviderVB : ICustomExpressionProvider {}

	public interface ICustomExpressionProviderCS : ICustomExpressionProvider {}

	public class CustomExpressionProvider
	{
		private static CustomExpressionProvider _instance;

		public static CustomExpressionProvider Instance
		{
			get
			{
				if(_instance == null)
					_instance = new CustomExpressionProvider();

				return _instance;
			}
		}

		//[Import(typeof(ICustomExpressionProviderCS))]
		public ICustomExpressionProviderCS CustomExpressionProviderCS;

		//[Import(typeof(ICustomExpressionProviderVB))]
		public ICustomExpressionProviderVB CustomExpressionProviderVB;

        public void CreateEvents()
        {
			CustomExpressionProviderCS = new CustomExpressionProviderCS();
			if(appsettings.vbEvents != null)
			{
				Type eType = appsettings.vbEvents.GetType("runnerDotNet.runnerDotNet.CustomExpressionProviderVB");
				if(eType != null)
				{
					CustomExpressionProviderVB = (ICustomExpressionProviderVB)Activator.CreateInstance(eType);
				}
			}
        }

		private CustomExpressionProvider()
		{
			CreateEvents();
		}

		public XVar GetCustomExpression(XVar value, XVar data, XVar field, XVar ptype, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			if(table == "dbo.rspd_application_received"  &&  field == "view_data")
			{
				return CustomExpressionProviderCS.GetCustomExpression(value, data, field, ptype, table);
			}
			return value;
		}

		public XVar GetFileCustomExpression(XVar file, XVar data, XVar field, XVar ptype, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			return "";
		}

		public XVar GetLWWhere(XVar field, XVar ptype, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			if(table == "dbo.rspdHeader"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			if(table == "dbo.rspd_application_received"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			if(table == "dbo.applicationsRecieved"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			if(table == "applicationEndorsed"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			if(table == "applicationUnderAssessment"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			if(table == "applicationUnderTechnicalEvaluation"  &&  field == "stageStatus")
			{
				return CustomExpressionProviderCS.GetLWWhere(field, ptype, table);
			}
			return "";
		}

		public XVar GetDefaultValue(XVar field, XVar ptype, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			if(table == "admin_users"  &&  field == "groupid")
			{
				return CustomExpressionProviderCS.GetDefaultValue(field, ptype, table);
			}
			if(table == "admin_users"  &&  field == "active")
			{
				return CustomExpressionProviderCS.GetDefaultValue(field, ptype, table);
			}
			return "";
		}

		public XVar GetAutoUpdateValue(XVar field, XVar ptype, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			return "";
		}

		public XVar getCustomMapIcon(XVar field, XVar ptype, XVar table, XVar data)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			return "";
		}

		public XVar getDashMapCustomIcon(XVar dashName, XVar dashElementName, XVar data)
		{

			return "";
		}

		public XVar getDashMapCustomLocationIcon(XVar dashName, XVar dashElementName, XVar data)
		{

			return "";
		}

		public XVar GetUploadFolderExpression(XVar field, XVar file, XVar table = null)
		{
			if(!table)
			{
				table = GlobalVars.strTableName;
			}

			return "";
		}

		public XVar GetIntervalLimitsExprs(XVar table, XVar field, XVar idx, XVar isLowerBound)
		{
			return "";
		}
	}
}