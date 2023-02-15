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
		public static XVar wrGetEntityArray(dynamic _param_name, dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic entArray = XVar.Array(), strXml = null, xml = null;
			strXml = XVar.Clone(CommonFunctions.wrLoadSelectedEntity((XVar)(name), (XVar)(var_type)));
			if(XVar.Pack(!(XVar)(strXml)))
			{
				return XVar.Array();
			}
			xml = XVar.Clone(new xml());
			entArray = XVar.Clone(xml.xml_to_array((XVar)(strXml)));
			if(XVar.Pack(!(XVar)(entArray)))
			{
				return XVar.Array();
			}
			XSession.Session.InitAndSetArrayItem(entArray["table_type"], "webobject", "table_type");
			XSession.Session["object_sql"] = entArray["sql"];
			if(entArray["table_type"] == "custom")
			{
				XSession.Session["object_sql"] = CommonFunctions.wrGetCustomSQL((XVar)(entArray["tables"][0]));
			}
			return entArray;
		}
		public static XVar getChartArray(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic arr = null, chrt_strXML = null, xml = null;
			xml = XVar.Clone(new xml());
			chrt_strXML = XVar.Clone(CommonFunctions.wrLoadSelectedEntity((XVar)(name), new XVar(Constants.WR_CHART)));
			arr = XVar.Clone(xml.xml_to_array((XVar)(chrt_strXML)));
			return arr;
		}
		public static XVar GetUserGroups()
		{
			dynamic arr = XVar.Array();
			if(XVar.Pack(!(XVar)(Security.permissionsAvailable())))
			{
				return XVar.Array();
			}
			if(XVar.Pack(Security.dynamicPermissions()))
			{
				dynamic data = XVar.Array(), dataSource = null, dc = null, groupIdField = null, groupLabelField = null, groupProviderField = null, qResult = null;
				arr = XVar.Clone(new XVar(0, new XVar(0, -1, 1, MVCFunctions.Concat("<", "Admin", ">")), 1, new XVar(0, -2, 1, MVCFunctions.Concat("<", "Default", ">")), 2, new XVar(0, -3, 1, MVCFunctions.Concat("<", "Guest", ">"))));
				groupIdField = new XVar("GroupID");
				groupLabelField = new XVar("Label");
				groupProviderField = new XVar("Provider");
				dataSource = XVar.Clone(Security.getUgGroupsDatasource());
				dc = XVar.Clone(new DsCommand());
				if(XVar.Pack(CommonFunctions.storageGet(new XVar("groups_provider_field"))))
				{
					dc.order.InitAndSetArrayItem(new XVar("column", groupProviderField, "dir", "ASC"), null);
				}
				dc.order.InitAndSetArrayItem(new XVar("column", groupLabelField, "dir", "ASC"), null);
				qResult = XVar.Clone(dataSource.getList((XVar)(dc)));
				while(XVar.Pack(data = XVar.Clone(qResult.fetchAssoc())))
				{
					arr.InitAndSetArrayItem(new XVar(0, data[groupIdField], 1, data[groupLabelField]), null);
				}
			}
			else
			{
				dynamic group = null;
				arr = XVar.Clone(XVar.Array());
				arr.InitAndSetArrayItem(new XVar(0, "Default", 1, "<Default>"), null);
			}
			return arr;
		}
		public static XVar GetUserGroup()
		{
			if(XVar.Pack(!(XVar)(Security.permissionsAvailable())))
			{
				return XVar.Array();
			}
			if(XVar.Pack(Security.dynamicPermissions()))
			{
				if(XVar.Pack(!(XVar)(Security.isGuest())))
				{
					dynamic userRights = XVar.Array();
					userRights = Security.dynamicUserRights();
					return userRights[".Groups"];
				}
				else
				{
					return new XVar(0, -3);
				}
			}
			else
			{
				if(XVar.Pack(!(XVar)(Security.isGuest())))
				{
					return new XVar(0, "Default");
				}
				else
				{
					return new XVar(0, "Guest");
				}
			}
			return null;
		}
		public static XVar CheckLastID(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic dataSource = null, dc = null, rs = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("rpt_type"), (XVar)(CommonFunctions.wrSqlType((XVar)(var_type)))));
			dc.totals.InitAndSetArrayItem(new XVar("field", "rpt_id", "alias", "id", "total", "max"), null);
			dataSource = XVar.Clone(CommonFunctions.wrMainDataSource());
			rs = XVar.Clone(dataSource.getTotals((XVar)(dc)));
			if(XVar.Pack(rs))
			{
				dynamic data = XVar.Array();
				data = XVar.Clone(rs.fetchAssoc());
				if(XVar.Pack(data))
				{
					return data["id"] + 1;
				}
			}
			return 1;
		}
		public static XVar GetNumberFieldsList(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic arr = XVar.Array(), t = XVar.Array();
			t = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
			arr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in t.GetEnumerator())
			{
				dynamic ftype = null;
				if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
				{
					ftype = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", f.Value))));
				}
				else
				{
					ftype = XVar.Clone(CommonFunctions.WRCustomGetFieldType((XVar)(table), (XVar)(f.Value)));
				}
				if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
				{
					arr.InitAndSetArrayItem(f.Value, null);
				}
			}
			return arr;
		}
		public static XVar WRGetNBFieldsList(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic arr = XVar.Array(), t = XVar.Array();
			t = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
			arr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in t.GetEnumerator())
			{
				dynamic ftype = null;
				if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
				{
					ftype = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", f.Value))));
				}
				else
				{
					ftype = XVar.Clone(CommonFunctions.WRCustomGetFieldType((XVar)(table), (XVar)(f.Value)));
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(ftype)))))
				{
					arr.InitAndSetArrayItem(f.Value, null);
				}
			}
			return arr;
		}
		public static XVar wrSqlType(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			return (XVar.Pack(var_type == Constants.WR_REPORT) ? XVar.Pack("report") : XVar.Pack("chart"));
		}
		public static XVar wrGetEntityList(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic dataSource = null, dc = null, entArr = XVar.Array(), permissions = XVar.Array(), ret = XVar.Array(), row = XVar.Array(), rs = null, userGroups = null, xml = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("rpt_type"), (XVar)(CommonFunctions.wrSqlType((XVar)(var_type)))));
			dc.order.InitAndSetArrayItem(new XVar("dir", "ASC", "column", "rpt_title"), null);
			dataSource = XVar.Clone(CommonFunctions.wrMainDataSource());
			rs = XVar.Clone(dataSource.getList((XVar)(dc)));
			if(XVar.Pack(!(XVar)(rs)))
			{
				return XVar.Array();
			}
			userGroups = XVar.Clone(Security.getUserGroupIds());
			ret = XVar.Clone(XVar.Array());
			xml = XVar.Clone(new xml());
			while(XVar.Pack(row = XVar.Clone(rs.fetchAssoc())))
			{
				entArr = XVar.Clone(xml.xml_to_array((XVar)(MVCFunctions.escapeEntities((XVar)(row["rpt_content"])))));
				permissions = XVar.Clone(CommonFunctions.wrGetEntityPermissions((XVar)(entArr), (XVar)(userGroups)));
				if(XVar.Pack(!(XVar)(entArr["tmp_active"])))
				{
					ret.InitAndSetArrayItem(new XVar("name", row["rpt_name"], "title", row["rpt_title"], "owner", row["rpt_owner"], "status", row["rpt_status"], "view", permissions["view"], "edit", permissions["edit"]), null);
				}
			}
			return ret;
		}
		public static XVar wrGetContent(dynamic _param_rpt_content)
		{
			#region pass-by-value parameters
			dynamic rpt_content = XVar.Clone(_param_rpt_content);
			#endregion

			dynamic entity = null, xml = null;
			if(XVar.Pack(!(XVar)(rpt_content)))
			{
				return XVar.Array();
			}
			xml = XVar.Clone(new xml());
			entity = XVar.Clone(xml.xml_to_array((XVar)(MVCFunctions.escapeEntities((XVar)(rpt_content)))));
			if(XVar.Pack(!(XVar)(entity)))
			{
				return XVar.Array();
			}
			return null;
		}
		public static XVar wrGetEntityPermissions(dynamic entity, dynamic _param_userGroups = null)
		{
			#region default values
			if(_param_userGroups as Object == null) _param_userGroups = new XVar();
			#endregion

			#region pass-by-value parameters
			dynamic userGroups = XVar.Clone(_param_userGroups);
			#endregion

			dynamic permissions = XVar.Array();
			if(XVar.Pack(!(XVar)(userGroups)))
			{
				userGroups = XVar.Clone(Security.getUserGroupIds());
			}
			permissions = XVar.Clone(new XVar("view", 0, "edit", 0));
			if(XVar.Pack(entity.KeyExists("permissions")))
			{
				foreach (KeyValuePair<XVar, dynamic> prm in entity["permissions"].GetEnumerator())
				{
					if(XVar.Pack(userGroups[prm.Value["id"]]))
					{
						permissions.InitAndSetArrayItem((XVar.Pack(prm.Value["view"] == "true") ? XVar.Pack(1) : XVar.Pack(0)), "view");
						permissions.InitAndSetArrayItem((XVar.Pack(prm.Value["edit"] == "true") ? XVar.Pack(1) : XVar.Pack(0)), "edit");
					}
				}
			}
			else
			{
				permissions.InitAndSetArrayItem(1, "view");
			}
			return permissions;
		}
		public static XVar wrLoadSelectedEntity(dynamic _param_name, dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic reportData = XVar.Array();
			reportData = XVar.Clone(CommonFunctions.wrGetEntityRecord((XVar)(name), (XVar)(var_type)));
			if(XVar.Pack(reportData))
			{
				return MVCFunctions.escapeEntities((XVar)(reportData["rpt_content"]));
			}
			return null;
		}
		public static XVar wrDeleteEntity(dynamic _param_name, dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic dataSource = null, dc = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, DataCondition.FieldEquals(new XVar("rpt_name"), (XVar)(name)), 1, DataCondition.FieldEquals(new XVar("rpt_type"), (XVar)(CommonFunctions.wrSqlType((XVar)(var_type))))))));
			dataSource = XVar.Clone(CommonFunctions.wrMainDataSource());
			dataSource.deleteSingle((XVar)(dc), new XVar(false));
			return null;
		}
		public static XVar wrSaveEntity(dynamic _param_type, dynamic _param_oldName, dynamic _param_newName, dynamic _param_title, dynamic _param_status, dynamic _param_strXML, dynamic _param_saveas)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			dynamic oldName = XVar.Clone(_param_oldName);
			dynamic newName = XVar.Clone(_param_newName);
			dynamic title = XVar.Clone(_param_title);
			dynamic status = XVar.Clone(_param_status);
			dynamic strXML = XVar.Clone(_param_strXML);
			dynamic saveas = XVar.Clone(_param_saveas);
			#endregion

			dynamic data = null, dataSource = null, dc = null;
			oldName = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(oldName)));
			newName = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(newName)));
			data = XVar.Clone(CommonFunctions.wrGetEntityRecord((XVar)(oldName), (XVar)(var_type)));
			dataSource = XVar.Clone(CommonFunctions.wrMainDataSource());
			dc = XVar.Clone(new DsCommand());
			dc.values.InitAndSetArrayItem(newName, "rpt_name");
			dc.values.InitAndSetArrayItem(title, "rpt_title");
			dc.values.InitAndSetArrayItem(strXML, "rpt_content");
			dc.values.InitAndSetArrayItem(status, "rpt_status");
			dc.values.InitAndSetArrayItem(MVCFunctions.now(), "rpt_mdate");
			if((XVar)(data)  && (XVar)((XVar)(!(XVar)(saveas))  || (XVar)(oldName == newName)))
			{
				dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, DataCondition.FieldEquals(new XVar("rpt_name"), (XVar)(oldName)), 1, DataCondition.FieldEquals(new XVar("rpt_type"), (XVar)(CommonFunctions.wrSqlType((XVar)(var_type))))))));
				dataSource.updateSingle((XVar)(dc), new XVar(false));
			}
			else
			{
				dc.values.InitAndSetArrayItem(MVCFunctions.now(), "rpt_cdate");
				dc.values.InitAndSetArrayItem(Security.getUserName(), "rpt_owner");
				if(XVar.Pack(!(XVar)(dc.values["rpt_owner"])))
				{
					dc.values.InitAndSetArrayItem("", "rpt_owner");
				}
				dc.values.InitAndSetArrayItem(CommonFunctions.wrSqlType((XVar)(var_type)), "rpt_type");
				dataSource.insertSingle((XVar)(dc));
			}
			if((XVar)((XVar)((XVar)(var_type == Constants.WR_REPORT)  && (XVar)(!(XVar)(saveas)))  && (XVar)(oldName))  && (XVar)(oldName != newName))
			{
				dynamic styleDs = null;
				dc = XVar.Clone(new DsCommand());
				dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("repname"), (XVar)(oldName)));
				dc.values.InitAndSetArrayItem(newName, "repname");
				styleDs = XVar.Clone(CommonFunctions.wrStyleDataSource());
				styleDs.updateSingle((XVar)(dc), new XVar(false));
			}
			return null;
		}
		public static XVar testAdvSearch(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				if(table == "dbo.sysdiagrams")
				{
					return 1;
				}
				if(table == "dbo.rspdHeader")
				{
					return 1;
				}
				if(table == "dbo.company")
				{
					return 1;
				}
				if(table == "dbo.radioEquipment")
				{
					return 1;
				}
				if(table == "Dashboard")
				{
					return 1;
				}
				if(table == "dbo.baranggay")
				{
					return 1;
				}
				if(table == "dbo.city")
				{
					return 1;
				}
				if(table == "dbo.province")
				{
					return 1;
				}
				if(table == "FAS Report")
				{
					return 1;
				}
				if(table == "dbo.spectrum_beta_users")
				{
					return 1;
				}
				if(table == "admin_rights")
				{
					return 1;
				}
				if(table == "admin_members")
				{
					return 1;
				}
				if(table == "admin_users")
				{
					return 1;
				}
				if(table == "dbo.stage")
				{
					return 1;
				}
				if(table == "dbo.stageStatus")
				{
					return 1;
				}
				if(table == "dbo.spectrum_betauggroups")
				{
					return 1;
				}
				if(table == "dbo.spectrum_beta_audit")
				{
					return 1;
				}
				if(table == "dbo.spectrum_beta_settings")
				{
					return 1;
				}
				if(table == "dbo.spectrum_betaugmembers")
				{
					return 1;
				}
				if(table == "dbo.spectrum_betaugrights")
				{
					return 1;
				}
				if(table == "dbo.transactionSetup")
				{
					return 1;
				}
				if(table == "dbo.rspd_application_received")
				{
					return 1;
				}
				if(table == "dbo.applicationsRecieved")
				{
					return 1;
				}
				if(table == "dbo.branch")
				{
					return 1;
				}
				if(table == "users")
				{
					return 1;
				}
				if(table == "dbo.classStation")
				{
					return 1;
				}
				if(table == "applicationEndorsed")
				{
					return 1;
				}
				if(table == "applicationUnderAssessment")
				{
					return 1;
				}
				if(table == "applicationUnderTechnicalEvaluation")
				{
					return 1;
				}
				if(table == "dbo.region")
				{
					return 1;
				}
			}
			else
			{
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					dynamic table_list = XVar.Array();
					table_list = XVar.Clone(CommonFunctions.WRGetTablesList());
					foreach (KeyValuePair<XVar, dynamic> value in table_list.GetEnumerator())
					{
						if(table == value.Value)
						{
							return 1;
						}
					}
				}
				else
				{
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						return 1;
					}
				}
			}
			return 0;
		}
		public static XVar WRAddFieldWrappers(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic connection = null, f = null, t = null;
			connection = XVar.Clone(CommonFunctions.getDefaultConnection());
			t = new XVar("");
			f = new XVar("");
			CommonFunctions.WRSplitFieldName((XVar)(field), ref t, ref f);
			if(XVar.Pack(!(XVar)(t)))
			{
				return connection.addFieldWrappers((XVar)(f));
			}
			return MVCFunctions.Concat(connection.addTableWrappers((XVar)(t)), ".", connection.addFieldWrappers((XVar)(f)));
		}
		public static XVar WRSplitFieldName(dynamic _param_str, ref dynamic table, ref dynamic field)
		{
			#region pass-by-value parameters
			dynamic str = XVar.Clone(_param_str);
			#endregion

			dynamic pos = null;
			table = new XVar("");
			field = XVar.Clone(str);
			pos = XVar.Clone(MVCFunctions.strrpos((XVar)(field), new XVar(".")));
			if(XVar.Equals(XVar.Pack(pos), XVar.Pack(false)))
			{
				return null;
			}
			table = XVar.Clone(MVCFunctions.substr((XVar)(str), new XVar(0), (XVar)(pos)));
			field = XVar.Clone(MVCFunctions.substr((XVar)(str), (XVar)(pos + 1)));
			return null;
		}
		public static XVar is_groupby_chart()
		{
			dynamic root = XVar.Array();
			if(XVar.Pack(!(XVar)(XSession.Session["webcharts"])))
			{
				return false;
			}
			root = XSession.Session["webcharts"];
			if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(root["group_by_condition"])))))
			{
				return false;
			}
			return root["group_by_condition"]["group_by_toggle"] == "true";
		}
		public static XVar WRChartLabel(dynamic _param_str)
		{
			#region pass-by-value parameters
			dynamic str = XVar.Clone(_param_str);
			#endregion

			dynamic field = null, table = null;
			table = new XVar("");
			field = new XVar("");
			CommonFunctions.WRSplitFieldName((XVar)(str), ref table, ref field);
			return field;
			if(XVar.Pack(!(XVar)(table)))
			{
				return field;
			}
			return MVCFunctions.Concat(table, ".", field);
		}
		public static XVar is_wr_db()
		{
			if(XSession.Session["webobject"]["table_type"] == "db")
			{
				return true;
			}
			else
			{
				return false;
			}
			return null;
		}
		public static XVar is_wr_project()
		{
			if(XSession.Session["webobject"]["table_type"] == "project")
			{
				return true;
			}
			else
			{
				return false;
			}
			return null;
		}
		public static XVar is_wr_custom()
		{
			if(XSession.Session["webobject"]["table_type"] == "custom")
			{
				return true;
			}
			else
			{
				return false;
			}
			return null;
		}
		public static XVar WRGetTablesList()
		{
			if(XVar.Pack(!(XVar)(XSession.Session.KeyExists("WRTableList"))))
			{
				dynamic connection = null;
				connection = XVar.Clone(CommonFunctions.getDefaultConnection());
				XSession.Session["WRTableList"] = connection.getTableList();
			}
			return XSession.Session["WRTableList"];
		}
		public static XVar WRGetFieldsList(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				ProjectSettings pSet;
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table)));
				return pSet.getFieldsList();
			}
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				if(XVar.Pack(GlobalVars.dal.Table((XVar)(table))))
				{
					return GlobalVars.dal.GetFieldsList((XVar)(table));
				}
				return CommonFunctions.dbinfoFieldsList((XVar)(table));
			}
			if(XVar.Pack(CommonFunctions.is_wr_custom()))
			{
				dynamic arr = XVar.Array(), connection = null, res = XVar.Array(), sql = null;
				res = XVar.Clone(XVar.Array());
				sql = XVar.Clone(XSession.Session["object_sql"]);
				connection = XVar.Clone(CommonFunctions.getDefaultConnection());
				arr = XVar.Clone(connection.getFieldsList((XVar)(sql)));
				foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
				{
					res.InitAndSetArrayItem(val.Value["fieldname"], null);
				}
				return res;
			}
			return null;
		}
		public static XVar dbinfoFieldsList(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic arr = XVar.Array(), connection = null, res = XVar.Array();
			if(XVar.Pack(XSession.Session["WRFieldList"].KeyExists(table)))
			{
				return XSession.Session["WRFieldList"][table];
			}
			connection = XVar.Clone(CommonFunctions.getDefaultConnection());
			arr = XVar.Clone(connection.getFieldsList((XVar)(MVCFunctions.Concat("select * from ", connection.addTableWrappers((XVar)(table)), " where 1=0"))));
			res = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
			{
				res.InitAndSetArrayItem(val.Value["fieldname"], null);
			}
			XSession.Session.InitAndSetArrayItem(res, "WRFieldList", table);
			return res;
		}
		public static XVar WRCustomGetFieldType(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				dynamic var_type = null;
				ProjectSettings pSet;
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(XSession.Session["webreports"]["tables"][0])));
				var_type = XVar.Clone(pSet.getFieldType((XVar)(field)));
				if(XVar.Pack(var_type))
				{
					return var_type;
				}
			}
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				if(XVar.Pack(GlobalVars.dal.Table((XVar)(table))))
				{
					return GlobalVars.dal.GetFieldType((XVar)(table), (XVar)(field));
				}
				return CommonFunctions.dbinfoFieldsType((XVar)(table), (XVar)(field));
			}
			if(XVar.Pack(CommonFunctions.is_wr_custom()))
			{
				dynamic res = null, sql = null;
				res = new XVar("");
				sql = XVar.Clone(XSession.Session["object_sql"]);
				if(XVar.Pack(sql))
				{
					dynamic arr = XVar.Array(), connection = null;
					connection = XVar.Clone(CommonFunctions.getDefaultConnection());
					arr = XVar.Clone(connection.getFieldsList((XVar)(sql)));
					foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
					{
						if(val.Value["fieldname"] == field)
						{
							res = XVar.Clone(val.Value["type"]);
						}
					}
				}
				return res;
			}
			return null;
		}
		public static XVar WRGetAllCustomFieldType()
		{
			dynamic arr = XVar.Array(), connection = null, res = XVar.Array(), sql = null;
			connection = XVar.Clone(CommonFunctions.getDefaultConnection());
			res = XVar.Clone(XVar.Array());
			sql = XVar.Clone(XSession.Session["object_sql"]);
			arr = XVar.Clone(connection.getFieldsList((XVar)(sql)));
			foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
			{
				res.InitAndSetArrayItem(val.Value["type"], val.Value["fieldname"]);
			}
			return res;
		}
		public static XVar WRGetFieldType(dynamic _param_fld)
		{
			#region pass-by-value parameters
			dynamic fld = XVar.Clone(_param_fld);
			#endregion

			dynamic field = null, table = null;
			table = new XVar("");
			field = new XVar("");
			CommonFunctions.WRSplitFieldName((XVar)(fld), ref table, ref field);
			return CommonFunctions.WRCustomGetFieldType((XVar)(table), (XVar)(field));
		}
		public static XVar dbinfoFieldsType(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic arr = XVar.Array(), connection = null, res = null;
			if(XVar.Pack(XSession.Session["WRFieldType"][table].KeyExists(field)))
			{
				return XSession.Session["WRFieldType"][table][field];
			}
			connection = XVar.Clone(CommonFunctions.getDefaultConnection());
			arr = XVar.Clone(connection.getFieldsList((XVar)(MVCFunctions.Concat("select * from ", connection.addTableWrappers((XVar)(table)), " where 1=0"))));
			res = new XVar("");
			foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
			{
				if(val.Value["fieldname"] == field)
				{
					res = XVar.Clone(val.Value["type"]);
				}
				XSession.Session.InitAndSetArrayItem(val.Value["type"], "WRFieldType", table, val.Value["fieldname"]);
			}
			return res;
		}
		public static XVar WRUseTimepicker(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return false;
		}
		public static XVar WRUseListLookup(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return false;
		}
		public static XVar getCaptionTable(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(XVar.Pack(!(XVar)(table)))
			{
				table = XVar.Clone(GlobalVars.strTableName);
			}
			if(table == "dbo.sysdiagrams")
			{
				return "Sysdiagrams";
			}
			if(table == "dbo.rspdHeader")
			{
				return "RSPD Form";
			}
			if(table == "dbo.company")
			{
				return "Company";
			}
			if(table == "dbo.radioEquipment")
			{
				return "Radio Equipment";
			}
			if(table == "Dashboard")
			{
				return "Dashboard";
			}
			if(table == "dbo.baranggay")
			{
				return "Baranggay";
			}
			if(table == "dbo.city")
			{
				return "City";
			}
			if(table == "dbo.province")
			{
				return "Province";
			}
			if(table == "FAS Report")
			{
				return "FAS Report";
			}
			if(table == "dbo.spectrum_beta_users")
			{
				return "Spectrum Beta Users";
			}
			if(table == "admin_rights")
			{
				return "Admin Rights";
			}
			if(table == "admin_members")
			{
				return "Admin Members";
			}
			if(table == "admin_users")
			{
				return "Admin Users";
			}
			if(table == "dbo.stage")
			{
				return "Stage";
			}
			if(table == "dbo.stageStatus")
			{
				return "Stage Status";
			}
			if(table == "dbo.spectrum_betauggroups")
			{
				return "Spectrum Betauggroups";
			}
			if(table == "dbo.spectrum_beta_audit")
			{
				return "Spectrum Beta Audit";
			}
			if(table == "dbo.spectrum_beta_settings")
			{
				return "Spectrum Beta Settings";
			}
			if(table == "dbo.spectrum_betaugmembers")
			{
				return "Spectrum Betaugmembers";
			}
			if(table == "dbo.spectrum_betaugrights")
			{
				return "Spectrum Betaugrights";
			}
			if(table == "dbo.transactionSetup")
			{
				return "Transaction Setup";
			}
			if(table == "dbo.rspd_application_received")
			{
				return "Rspd Application Received";
			}
			if(table == "dbo.applicationsRecieved")
			{
				return "Applications Recieved";
			}
			if(table == "dbo.branch")
			{
				return "Branch";
			}
			if(table == "users")
			{
				return "Users";
			}
			if(table == "dbo.classStation")
			{
				return "Class Station";
			}
			if(table == "applicationEndorsed")
			{
				return "Application Endorsed";
			}
			if(table == "applicationUnderAssessment")
			{
				return "Application Under Assessment";
			}
			if(table == "applicationUnderTechnicalEvaluation")
			{
				return "Application Under Technical Evaluation";
			}
			if(table == "dbo.region")
			{
				return "Region";
			}
			return table;
		}
		public static XVar getChartTablesList()
		{
			return CommonFunctions.WRGetQueryTables(new XVar("webcharts"));
		}
		public static XVar getReportTablesList()
		{
			return CommonFunctions.WRGetQueryTables(new XVar("webreports"));
		}
		public static XVar WRGetQueryTables(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic ret = XVar.Array(), root = XVar.Array();
			root = XSession.Session[var_type];
			ret = XVar.Clone(new XVar(0, root["tables"][0]));
			if((XVar)(MVCFunctions.strlen((XVar)(root["table_relations"]["relations"])))  && (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(root["table_relations"]["join_tables"]), new XVar(","))), XVar.Pack(false))))
			{
				dynamic joined = XVar.Array();
				joined = XVar.Clone(MVCFunctions.explode(new XVar(","), (XVar)(root["table_relations"]["join_tables"])));
				foreach (KeyValuePair<XVar, dynamic> t in joined.GetEnumerator())
				{
					if(XVar.Pack(MVCFunctions.strlen((XVar)(t.Value))))
					{
						ret.InitAndSetArrayItem(t.Value, null);
					}
				}
			}
			return ret;
		}
		public static XVar GetDefaultViewFormat(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(var_type))))
			{
				return Constants.FORMAT_DATABASE_IMAGE;
			}
			else
			{
				if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(var_type))))
				{
					return Constants.FORMAT_DATE_SHORT;
				}
				else
				{
					return Constants.FORMAT_NONE;
				}
			}
			return null;
		}
		public static XVar GetDefaultEditFormat(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(var_type))))
			{
				return Constants.EDIT_FORMAT_DATABASE_IMAGE;
			}
			else
			{
				if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(var_type))))
				{
					return Constants.EDIT_FORMAT_DATE;
				}
				else
				{
					return Constants.EDIT_FORMAT_TEXT_FIELD;
				}
			}
			return null;
		}
		public static XVar GetGenericViewFormat(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetDefaultViewFormat((XVar)(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", field)))));
		}
		public static XVar GetGenericEditFormat(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetDefaultEditFormat((XVar)(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", field)))));
		}
		public static XVar GenericStrWhereAdv(dynamic _param_strTable, dynamic _param_strField, dynamic _param_SearchFor, dynamic _param_strSearchOption, dynamic _param_SearchFor2, dynamic _param_etype)
		{
			#region pass-by-value parameters
			dynamic strTable = XVar.Clone(_param_strTable);
			dynamic strField = XVar.Clone(_param_strField);
			dynamic SearchFor = XVar.Clone(_param_SearchFor);
			dynamic strSearchOption = XVar.Clone(_param_strSearchOption);
			dynamic SearchFor2 = XVar.Clone(_param_SearchFor2);
			dynamic etype = XVar.Clone(_param_etype);
			#endregion

			dynamic btexttype = null, connection = null, ismssql = null, ret = null, sfield = null, stable = null, value1 = null, value2 = null, var_like = null, var_type = null;
			sfield = XVar.Clone(strField);
			stable = new XVar("");
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				CommonFunctions.WRSplitFieldName((XVar)(strField), ref stable, ref sfield);
				var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(strField)));
			}
			else
			{
				var_type = XVar.Clone(CommonFunctions.WRCustomGetFieldType((XVar)(strTable), (XVar)(strField)));
			}
			if(CommonFunctions.GetDatabaseType() != Constants.nDATABASE_MSSQLServer)
			{
				ismssql = new XVar(false);
			}
			else
			{
				ismssql = new XVar(true);
			}
			btexttype = XVar.Clone(CommonFunctions.IsTextType((XVar)(var_type)));
			if(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_MySQL)
			{
				btexttype = new XVar(false);
			}
			if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(var_type))))
			{
				return "";
			}
			if(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_MSSQLServer)
			{
				if((XVar)((XVar)(btexttype)  && (XVar)(strSearchOption != "Contains"))  && (XVar)(strSearchOption != "Starts with ..."))
				{
					return "";
				}
			}
			if(strSearchOption == "Empty")
			{
				if((XVar)(CommonFunctions.IsCharType((XVar)(var_type)))  && (XVar)((XVar)(!(XVar)(ismssql))  || (XVar)(!(XVar)(btexttype))))
				{
					return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is null or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "='')");
				}
				else
				{
					if((XVar)(ismssql)  && (XVar)(btexttype))
					{
						return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is null or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " LIKE '')");
					}
					else
					{
						return MVCFunctions.Concat(CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is null");
					}
				}
			}
			if(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_PostgreSQL)
			{
				var_like = new XVar("ilike");
			}
			else
			{
				var_like = new XVar("like");
			}
			if(CommonFunctions.GetGenericEditFormat((XVar)(strTable), (XVar)(sfield)) == Constants.EDIT_FORMAT_LOOKUP_WIZARD)
			{
				ProjectSettings pSet;
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(strTable)));
				if(XVar.Pack(pSet.multiSelect((XVar)(sfield))))
				{
					SearchFor = XVar.Clone(CommonFunctions.splitLookupValues((XVar)(SearchFor)));
				}
				else
				{
					SearchFor = XVar.Clone(new XVar(0, SearchFor));
				}
				ret = new XVar("");
				foreach (KeyValuePair<XVar, dynamic> searchItem in SearchFor.GetEnumerator())
				{
					dynamic value = null;
					value = XVar.Clone(searchItem.Value);
					if(XVar.Pack(!(XVar)((XVar)((XVar)(value == "null")  || (XVar)(value == "Null"))  || (XVar)(value == XVar.Pack("")))))
					{
						if(XVar.Pack(MVCFunctions.strlen((XVar)(ret))))
						{
							ret = MVCFunctions.Concat(ret, " or ");
						}
						if(strSearchOption == "Equals")
						{
							value = XVar.Clone(CommonFunctions.WRmake_db_value((XVar)(sfield), (XVar)(value), (XVar)(strTable)));
							if(XVar.Pack(!(XVar)((XVar)(value == "null")  || (XVar)(value == "Null"))))
							{
								ret = MVCFunctions.Concat(ret, CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "=", value);
							}
						}
						else
						{
							connection = XVar.Clone(CommonFunctions.getWebreportConnection());
							if((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(value), new XVar(","))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(value), new XVar("\""))), XVar.Pack(false))))
							{
								value = XVar.Clone(MVCFunctions.Concat("\"", MVCFunctions.str_replace(new XVar("\""), new XVar("\"\""), (XVar)(value)), "\""));
							}
							ret = MVCFunctions.Concat(ret, CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " = ", connection.prepareString((XVar)(value)));
							ret = MVCFunctions.Concat(ret, " or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " ", var_like, " ", connection.prepareString((XVar)(MVCFunctions.Concat("%,", value, ",%"))));
							ret = MVCFunctions.Concat(ret, " or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " ", var_like, " ", connection.prepareString((XVar)(MVCFunctions.Concat("%,", value))));
							ret = MVCFunctions.Concat(ret, " or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " ", var_like, " ", connection.prepareString((XVar)(MVCFunctions.Concat(value, ",%"))));
						}
					}
				}
				if(XVar.Pack(MVCFunctions.strlen((XVar)(ret))))
				{
					ret = XVar.Clone(MVCFunctions.Concat("(", ret, ")"));
				}
				return ret;
			}
			if(CommonFunctions.GetGenericEditFormat((XVar)(strTable), (XVar)(sfield)) == Constants.EDIT_FORMAT_CHECKBOX)
			{
				if(SearchFor == "none")
				{
					return "";
				}
				if(XVar.Pack(CommonFunctions.NeedQuotes((XVar)(var_type))))
				{
					if(SearchFor == "on")
					{
						return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "<>'0' and ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "<>'' and ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is not null)");
					}
					else
					{
						return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "='0' or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "='' or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is null)");
					}
				}
				else
				{
					if(SearchFor == "on")
					{
						return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "<>0 and ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is not null)");
					}
					else
					{
						return MVCFunctions.Concat("(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), "=0 or ", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " is null)");
					}
				}
			}
			value1 = XVar.Clone(CommonFunctions.WRmake_db_value((XVar)(sfield), (XVar)(SearchFor), (XVar)(strTable)));
			value2 = new XVar(false);
			if(strSearchOption == "Between")
			{
				value2 = XVar.Clone(CommonFunctions.WRmake_db_value((XVar)(sfield), (XVar)(SearchFor2), (XVar)(strTable)));
			}
			if((XVar)((XVar)(strSearchOption != "Contains")  && (XVar)(strSearchOption != "Starts with ..."))  && (XVar)((XVar)(XVar.Equals(XVar.Pack(value1), XVar.Pack("null")))  || (XVar)(XVar.Equals(XVar.Pack(value2), XVar.Pack("null")))))
			{
				return "";
			}
			connection = XVar.Clone(CommonFunctions.getWebreportConnection());
			if((XVar)(CommonFunctions.IsCharType((XVar)(var_type)))  && (XVar)(!(XVar)(btexttype)))
			{
				value1 = XVar.Clone(connection.upper((XVar)(value1)));
				value2 = XVar.Clone(connection.upper((XVar)(value2)));
				strField = XVar.Clone(connection.upper((XVar)(CommonFunctions.WRAddFieldWrappers((XVar)(strField)))));
			}
			else
			{
				if((XVar)((XVar)(ismssql)  && (XVar)(!(XVar)(btexttype)))  && (XVar)((XVar)(strSearchOption == "Contains")  || (XVar)(strSearchOption == "Starts with ...")))
				{
					strField = XVar.Clone(MVCFunctions.Concat("convert(varchar,", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), ")"));
				}
				else
				{
					if((XVar)((XVar)(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_PostgreSQL)  && (XVar)(!(XVar)(btexttype)))  && (XVar)((XVar)(strSearchOption == "Contains")  || (XVar)(strSearchOption == "Starts with ...")))
					{
						strField = XVar.Clone(MVCFunctions.Concat("CAST(", CommonFunctions.WRAddFieldWrappers((XVar)(strField)), " AS TEXT)"));
					}
					else
					{
						strField = XVar.Clone(CommonFunctions.WRAddFieldWrappers((XVar)(strField)));
					}
				}
			}
			ret = new XVar("");
			if(strSearchOption == "Contains")
			{
				if((XVar)(CommonFunctions.IsCharType((XVar)(var_type)))  && (XVar)(!(XVar)(btexttype)))
				{
					return MVCFunctions.Concat(strField, " ", var_like, " ", connection.upper((XVar)(connection.prepareString((XVar)(MVCFunctions.Concat("%", SearchFor, "%"))))));
				}
				else
				{
					return MVCFunctions.Concat(strField, " ", var_like, " ", connection.prepareString((XVar)(MVCFunctions.Concat("%", SearchFor, "%"))));
				}
			}
			else
			{
				if(strSearchOption == "Equals")
				{
					return MVCFunctions.Concat(strField, "=", value1);
				}
				else
				{
					if(strSearchOption == "Starts with ...")
					{
						if((XVar)(CommonFunctions.IsCharType((XVar)(var_type)))  && (XVar)(!(XVar)(btexttype)))
						{
							return MVCFunctions.Concat(strField, " ", var_like, " ", connection.upper((XVar)(connection.prepareString((XVar)(MVCFunctions.Concat(SearchFor, "%"))))));
						}
						else
						{
							return MVCFunctions.Concat(strField, " ", var_like, " ", connection.prepareString((XVar)(MVCFunctions.Concat(SearchFor, "%"))));
						}
					}
					else
					{
						if(strSearchOption == "More than ...")
						{
							return MVCFunctions.Concat(strField, ">", value1);
						}
						else
						{
							if(strSearchOption == "Less than ...")
							{
								return MVCFunctions.Concat(strField, "<", value1);
							}
							else
							{
								if(strSearchOption == "Equal or more than ...")
								{
									return MVCFunctions.Concat(strField, ">=", value1);
								}
								else
								{
									if(strSearchOption == "Equal or less than ...")
									{
										return MVCFunctions.Concat(strField, "<=", value1);
									}
									else
									{
										if(strSearchOption == "Between")
										{
											ret = XVar.Clone(MVCFunctions.Concat(strField, ">=", value1));
											ret = MVCFunctions.Concat(ret, " and ", strField, "<=", value2);
											return ret;
										}
									}
								}
							}
						}
					}
				}
			}
			return "";
		}
		public static XVar GetAdvSearchOptions(dynamic _param_table, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic format = null, options = XVar.Array();
			format = XVar.Clone(CommonFunctions.GetGenericEditFormat((XVar)(table), (XVar)(field)));
			options = XVar.Clone(XVar.Array());
			if(format == Constants.EDIT_FORMAT_DATE)
			{
				options.InitAndSetArrayItem(new XVar("type", "Equals", "label", "Equals"), null);
				options.InitAndSetArrayItem(new XVar("type", "More than ...", "label", "More than"), null);
				options.InitAndSetArrayItem(new XVar("type", "Less than ...", "label", "Less than"), null);
				options.InitAndSetArrayItem(new XVar("type", "Equal or more than ...", "label", "Equal or more than"), null);
				options.InitAndSetArrayItem(new XVar("type", "Equal or less than ...", "label", "Equal or less than"), null);
				options.InitAndSetArrayItem(new XVar("type", "Between", "label", "Between"), null);
				options.InitAndSetArrayItem(new XVar("type", "Empty", "label", "Empty"), null);
			}
			else
			{
				if(format == Constants.EDIT_FORMAT_LOOKUP_WIZARD)
				{
					ProjectSettings pSet;
					pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table), new XVar(Constants.PAGE_REPORT)));
					if(XVar.Pack(pSet.multiSelect((XVar)(field))))
					{
						options.InitAndSetArrayItem(new XVar("type", "Contains", "label", "Contains"), null);
					}
					else
					{
						options.InitAndSetArrayItem(new XVar("type", "Equals", "label", "Equals"), null);
					}
				}
				else
				{
					if((XVar)((XVar)((XVar)((XVar)(format == Constants.EDIT_FORMAT_TEXT_FIELD)  || (XVar)(format == Constants.EDIT_FORMAT_TEXT_AREA))  || (XVar)(format == Constants.EDIT_FORMAT_PASSWORD))  || (XVar)(format == Constants.EDIT_FORMAT_HIDDEN))  || (XVar)(format == Constants.EDIT_FORMAT_READONLY))
					{
						options.InitAndSetArrayItem(new XVar("type", "Contains", "label", "Contains"), null);
						options.InitAndSetArrayItem(new XVar("type", "Equals", "label", "Equals"), null);
						options.InitAndSetArrayItem(new XVar("type", "Starts with ...", "label", "Starts with"), null);
						options.InitAndSetArrayItem(new XVar("type", "More than ...", "label", "More than"), null);
						options.InitAndSetArrayItem(new XVar("type", "Less than ...", "label", "Less than"), null);
						options.InitAndSetArrayItem(new XVar("type", "Equal or more than ...", "label", "Equal or more than"), null);
						options.InitAndSetArrayItem(new XVar("type", "Equal or less than ...", "label", "Equal or less than"), null);
						options.InitAndSetArrayItem(new XVar("type", "Between", "label", "Between"), null);
						options.InitAndSetArrayItem(new XVar("type", "Empty", "label", "Empty"), null);
					}
					else
					{
						options.InitAndSetArrayItem(new XVar("type", "Equals", "label", "Equals"), null);
					}
				}
			}
			return options;
		}
		public static XVar CalcSearchParam(dynamic _param_sessPrefix)
		{
			#region pass-by-value parameters
			dynamic sessPrefix = XVar.Clone(_param_sessPrefix);
			#endregion

			dynamic sWhere = null;
			sWhere = new XVar("");
			if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_search")] == 2)
			{
				foreach (KeyValuePair<XVar, dynamic> sfor in XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor")].GetEnumerator())
				{
					dynamic strSearchFor = null, strSearchFor2 = null, var_type = null;
					strSearchFor = XVar.Clone(MVCFunctions.trim((XVar)(sfor.Value)));
					strSearchFor2 = new XVar("");
					var_type = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfortype")][sfor.Key]);
					if(XVar.Pack(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")].KeyExists(sfor.Key)))
					{
						strSearchFor2 = XVar.Clone(MVCFunctions.trim((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")][sfor.Key])));
					}
					if((XVar)(strSearchFor != XVar.Pack(""))  || (XVar)(true))
					{
						dynamic strSearchOption = null, where = null;
						if(XVar.Pack(!(XVar)(sWhere)))
						{
							if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] == "and")
							{
								sWhere = new XVar("1=1");
							}
							else
							{
								sWhere = new XVar("1=0");
							}
						}
						strSearchOption = XVar.Clone(MVCFunctions.trim((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchopt")][sfor.Key])));
						where = XVar.Clone(CommonFunctions.GenericStrWhereAdv((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtable")][sfor.Key]), (XVar)(sfor.Key), (XVar)(strSearchFor), (XVar)(strSearchOption), (XVar)(strSearchFor2), (XVar)(var_type)));
						if(XVar.Pack(where))
						{
							if(XVar.Pack(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchnot")][sfor.Key]))
							{
								where = XVar.Clone(MVCFunctions.Concat("not (", where, ")"));
							}
							if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] == "and")
							{
								sWhere = MVCFunctions.Concat(sWhere, " and ", where);
							}
							else
							{
								sWhere = MVCFunctions.Concat(sWhere, " or ", where);
							}
						}
					}
				}
			}
			return sWhere;
		}
		public static XVar WRViewFormat(dynamic _param_field, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			ProjectSettings pSet;
			pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table)));
			return pSet.getViewFormat((XVar)(field));
		}
		public static XVar get_chart_series_fields(ref dynamic arr_data_series, ref dynamic arr_label_series)
		{
			dynamic arr_fields = XVar.Array(), arr_join_tables = XVar.Array(), i = null, j = null, root = null, t = null;
			if(XVar.Pack(CommonFunctions.is_groupby_chart()))
			{
				return CommonFunctions.get_chart_groupbyseries_fields(ref arr_data_series, ref arr_label_series);
			}
			root = XSession.Session["webcharts"];
			arr_data_series = XVar.Clone(XVar.Array());
			arr_label_series = XVar.Clone(XVar.Array());
			arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
			i = new XVar(0);
			for(;i < MVCFunctions.count(arr_join_tables); i++)
			{
				t = XVar.Clone(arr_join_tables[i]);
				arr_fields = XVar.Clone(CommonFunctions.GetNumberFieldsList((XVar)(t)));
				j = new XVar(0);
				for(;j < MVCFunctions.count(arr_fields); j++)
				{
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
					{
						arr_data_series.InitAndSetArrayItem(new XVar("field", MVCFunctions.Concat(t, ".", arr_fields[j]), "label", CommonFunctions.WRChartLabel((XVar)(MVCFunctions.Concat(t, ".", arr_fields[j])))), null);
					}
					else
					{
						arr_data_series.InitAndSetArrayItem(new XVar("field", arr_fields[j], "label", CommonFunctions.WRChartLabel((XVar)(arr_fields[j]))), null);
					}
				}
				arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t)));
				j = new XVar(0);
				for(;j < MVCFunctions.count(arr_fields); j++)
				{
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
					{
						arr_label_series.InitAndSetArrayItem(new XVar("field", MVCFunctions.Concat(t, ".", arr_fields[j]), "label", CommonFunctions.WRChartLabel((XVar)(MVCFunctions.Concat(t, ".", arr_fields[j])))), null);
					}
					else
					{
						arr_label_series.InitAndSetArrayItem(new XVar("field", arr_fields[j], "label", CommonFunctions.WRChartLabel((XVar)(arr_fields[j]))), null);
					}
				}
			}
			if(XVar.Pack(!(XVar)(arr_data_series)))
			{
				arr_data_series = XVar.Clone(arr_label_series);
			}
			return null;
		}
		public static XVar get_chart_groupbyseries_fields(ref dynamic arr_data_series, ref dynamic arr_label_series)
		{
			dynamic arr = XVar.Array(), field = null, i = null, isData = null, isLabel = null, ret = null, root = XVar.Array(), strLabel = null;
			root = XSession.Session["webcharts"];
			arr_data_series = XVar.Clone(XVar.Array());
			arr_label_series = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(root["group_by_condition"]) - 1; i++)
			{
				arr = root["group_by_condition"][i];
				field = XVar.Clone(arr["field_opt"]);
				strLabel = XVar.Clone(CommonFunctions.WRChartLabel((XVar)(field)));
				isLabel = new XVar(false);
				isData = new XVar(false);
				if((XVar)(arr["group_by_value"] != "-1")  && (XVar)(arr["group_by_value"] != "GROUP BY"))
				{
					field = XVar.Clone(MVCFunctions.Concat(arr["group_by_value"], "(", field, ")"));
					isData = new XVar(true);
					isLabel = new XVar(true);
				}
				else
				{
					if(arr["group_by_value"] == "GROUP BY")
					{
						dynamic var_type = null;
						var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(field)));
						if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(var_type))))
						{
							isData = new XVar(true);
						}
						isLabel = new XVar(true);
					}
				}
				ret = XVar.Clone(new XVar("field", field, "label", strLabel));
				if(XVar.Pack(isLabel))
				{
					arr_label_series.InitAndSetArrayItem(ret, null);
				}
				if(XVar.Pack(isData))
				{
					arr_data_series.InitAndSetArrayItem(ret, null);
				}
			}
			if(XVar.Pack(!(XVar)(arr_data_series)))
			{
				arr_data_series = XVar.Clone(arr_label_series);
			}
			return null;
		}
		public static XVar WRProcessLargeText(dynamic _param_text, dynamic _param_field, dynamic _param_recid, dynamic _param_chars, dynamic _param_mode, dynamic _param_strLabel, dynamic _param_isProgectTable = null)
		{
			#region default values
			if(_param_isProgectTable as Object == null) _param_isProgectTable = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic text = XVar.Clone(_param_text);
			dynamic field = XVar.Clone(_param_field);
			dynamic recid = XVar.Clone(_param_recid);
			dynamic chars = XVar.Clone(_param_chars);
			dynamic mode = XVar.Clone(_param_mode);
			dynamic strLabel = XVar.Clone(_param_strLabel);
			dynamic isProgectTable = XVar.Clone(_param_isProgectTable);
			#endregion

			dynamic id = null, link = null, shortening = null, textbox = null;
			if(XVar.Pack(!(XVar)(chars)))
			{
				return text;
			}
			if((XVar)((XVar)(mode != Constants.MODE_LIST)  && (XVar)(mode != Constants.MODE_PRINT))  || (XVar)(MVCFunctions.strlen((XVar)(text)) < chars + 10))
			{
				return text;
			}
			if(XVar.Pack(isProgectTable))
			{
				dynamic cNumberOfChars = null;
				shortening = XVar.Clone(CommonFunctions.GetShorteningForLargeText((XVar)(text), (XVar)(cNumberOfChars)));
			}
			else
			{
				shortening = XVar.Clone(MVCFunctions.substr((XVar)(text), new XVar(0), (XVar)(chars)));
			}
			if(mode == Constants.MODE_PRINT)
			{
				return MVCFunctions.Concat(shortening, "...");
			}
			id = XVar.Clone(MVCFunctions.Concat("textbox_", MVCFunctions.GoodFieldName((XVar)(field)), recid));
			textbox = XVar.Clone(MVCFunctions.Concat("<span style=\"display:none\" id=\"", id, "\">", text, "</span>"));
			link = XVar.Clone(MVCFunctions.Concat("<a href=# onclick=\"\r\n\r\n\tvar offset = $(this).offset();\r\n\toffset.left -= $(window).scrollLeft();\r\n\toffset.top -= $(window).scrollTop();\r\n\t$('#", id, "').clone().dialog(\r\n\t{\r\ntitle: '", CommonFunctions.jsreplace((XVar)(strLabel)), "',\r\n\t\tdraggable: true,\r\n\t\tresizable: true,\r\n\t\tbgiframe: true,\r\n\t\tmodal: false,\r\n\t\tminheight:400,\r\n\t\tposition:[offset.left-50,offset.top-50]\r\n\t}\r\n\t);\r\n\treturn false;\r\n\t\">&nbsp;", "More", "...</a>"));
			return MVCFunctions.Concat(shortening, link, textbox);
		}
		public static XVar JumpTo()
		{
			return "$(\"#jumpto\").mouseover(function(){\r\n\t\tif(closetimer) {\r\n\t\t\twindow.clearTimeout(closetimer);\r\n\t\t\tclosetimer = null;\r\n\t\t}\r\n\t\tvar jumpto = $(\"#jumpto\"), menujump = $(\"#menujump\"), framejump = $(\"#framejump\");\r\n\t\tif (jumpto.top + jumpto.height() + menujump.height() + $(window).scrollTop() > $(window).height()) {\r\n\t\t\tif(menujump.height() - jumpto.offset().top + $(window).scrollTop()>0)\r\n\t\t\t{\r\n\t\t\t\tmenujump.css(\"top\", $(window).scrollTop()+\"px\");\r\n\t\t\t\tmenujump.css(\"left\", ($(this).offset().left - 6) + \"px\");\r\n\t\t\t\tframejump.css(\"width\", menujump.width());\r\n\t\t\t\tframejump.css(\"height\", menujump.height());\r\n\t\t\t\tframejump.css(\"top\", $(window).scrollTop()+\"px\");\r\n\t\t\t\tframejump.css(\"left\", ($(this).offset().left - 1) + \"px\");\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\tmenujump.css(\"top\", ($(this).offset().top - menujump.height()) + \"px\");\r\n\t\t\t\tmenujump.css(\"left\", ($(this).offset().left - 6) + \"px\");\r\n\t\t\t\tframejump.css(\"width\", menujump.width());\r\n\t\t\t\tframejump.css(\"height\", menujump.height());\r\n\t\t\t\tframejump.css(\"top\", ($(this).offset().top - framejump.height()) + \"px\");\r\n\t\t\t\tframejump.css(\"left\", ($(this).offset().left - 1) + \"px\");\r\n\t\t\t}\r\n\t\t} else {\r\n\t\t\tmenujump.css(\"top\", ($(this).offset().top + $(this).height()) + \"px\");\r\n\t\t\tmenujump.css(\"left\", ($(this).offset().left - 6) + \"px\");\r\n\t\t\tframejump.css(\"width\", menujump.width());\r\n\t\t\tframejump.css(\"height\", menujump.height());\r\n\t\t\tframejump.css(\"top\", ($(this).offset().top + $(this).height()) + \"px\");\r\n\t\t\tframejump.css(\"left\", ($(this).offset().left - 1) + \"px\");\r\n\t\t}\r\n\t\tframejump.show();\r\n\t\tmenujump.show();\r\n\t});\r\n\r\n\t$(\"#jumpto\").mouseout(function(){\r\n\t\tclosetimer = window.setTimeout(\"$('#menujump').hide();$('#framejump').hide();\", timeout);\r\n\t});\r\n\r\n\t$(\"#menujump td\").mouseover(function(){\r\n\t\tif(closetimer) {\r\n\t\t\twindow.clearTimeout(closetimer);\r\n\t\t\tclosetimer = null;\r\n\t\t}\r\n\t});\r\n\r\n\t$(\"#menujump td\").mouseout(function(){\r\n\t\tclosetimer = window.setTimeout(\"$('#menujump').hide();$('#framejump').hide();\", timeout);\r\n\t});\r\n\r\n\t$(document.body).click(function(){\r\n\t\t$(\"#menujump\").hide();\r\n\t\t$(\"#framejump\").hide();\r\n\t});\t";
			return null;
		}
		public static XVar alertDialog()
		{
			return "$(\"#alert\").dialog({\r\n\t\topen: function(event,ui){\r\n\t\t\tvar alertParent = $(\"#alert\").parent(\".ui-dialog\"), aframe = $(\"#aframe\");\r\n\t\t\tw = alertParent.width();\r\n\t\t\th = alertParent.height();\r\n\t\t\tt = alertParent.offset().top;\r\n\t\t\tl = alertParent.offset().left;\r\n\t\t\taframe.css(\"width\",w+6);\r\n\t\t\taframe.css(\"height\",h+6);\r\n\t\t\taframe.css(\"top\",t + \"px\");\r\n\t\t\taframe.css(\"left\",l + \"px\");\r\n\t\t\taframe.show();\r\n\t\t},\r\n\t\tbeforeclose: function(event,ui){\r\n\t\t\t$(\"#aframe\").hide();\r\n\t\t},\r\n\t\ttitle: \"Message\",\r\n\t\tdraggable: false,\r\n\t\tresizable: false,\r\n\t\tbgiframe: true,\r\n\t\tautoOpen: false,\r\n\t\tmodal: true,\r\n\t\tbuttons: {\r\n\t\t\tOk: function() {\r\n\t\t\t\t$(this).dialog(\"close\");\r\n\t\t\t}\r\n\t\t}\r\n\t});";
			return null;
		}
		public static XVar DBGetTableKeys(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(XVar.Pack(GlobalVars.dal.Table((XVar)(table))))
			{
				return GlobalVars.dal.GetDBTableKeys((XVar)(table));
			}
			return XVar.Array();
		}
		public static XVar colorPickerMouse()
		{
			return "\r\n\r\nfunction GiveDec(Hex)\r\n{\r\n   if(Hex == \"A\")\r\n\t  Value = 10;\r\n   else\r\n   if(Hex == \"B\")\r\n\t  Value = 11;\r\n   else\r\n   if(Hex == \"C\")\r\n\t  Value = 12;\r\n   else\r\n   if(Hex == \"D\")\r\n\t  Value = 13;\r\n   else\r\n   if(Hex == \"E\")\r\n\t  Value = 14;\r\n   else\r\n   if(Hex == \"F\")\r\n\t  Value = 15;\r\n   else\r\n\t  Value = eval(Hex);\r\n\r\n   return Value;\r\n}\r\n\r\nfunction GiveHex(Dec)\r\n{\r\n   if(Dec == 10)\r\n\t  Value = \"A\";\r\n   else\r\n   if(Dec == 11)\r\n\t  Value = \"B\";\r\n   else\r\n   if(Dec == 12)\r\n\t  Value = \"C\";\r\n   else\r\n   if(Dec == 13)\r\n\t  Value = \"D\";\r\n   else\r\n   if(Dec == 14)\r\n\t  Value = \"E\";\r\n   else\r\n   if(Dec == 15)\r\n\t  Value = \"F\";\r\n   else\r\n\t  Value = \"\" + Dec;\r\n\r\n   return Value;\r\n}\r\n\r\nfunction HexToDec(value)\r\n{\r\n   Input = value.toUpperCase();\r\n\r\n   a = GiveDec(Input.substring(0, 1));\r\n   b = GiveDec(Input.substring(1, 2));\r\n   c = GiveDec(Input.substring(2, 3));\r\n   d = GiveDec(Input.substring(3, 4));\r\n   e = GiveDec(Input.substring(4, 5));\r\n   f = GiveDec(Input.substring(5, 6));\r\n\r\n   x = (a * 16) + b; // Red\r\n   y = (c * 16) + d; // Green\r\n   z = (e * 16) + f; // Blue\r\n\r\n\treturn [x,y,z]\r\n}\r\n\r\nfunction DecToHex(Red, Green, Blue)\r\n{\r\n   a = GiveHex(Math.floor(Red / 16));\r\n   b = GiveHex(Red % 16);\r\n   c = GiveHex(Math.floor(Green / 16));\r\n   d = GiveHex(Green % 16);\r\n   e = GiveHex(Math.floor(Blue / 16));\r\n   f = GiveHex(Blue % 16);\r\n\r\n   z = a + b + c + d + e + f;\r\n\r\n\treturn z;\r\n}\r\n\r\nfunction rgbToHex(str)\r\n{\r\n\tif(str==undefined)\r\n\t\treturn \"\";\r\n\tif(str.substr(0,1)==\"#\")\r\n\t\treturn str.substr(1);\r\n\tstr=str.substring(4);\r\n\tstr=str.replace(\")\",\"\");\r\n\tarr = new Array();\r\n\tarr=str.split(\",\");\r\n\treturn DecToHex(arr[0],arr[1],arr[2]);\r\n}\r\n\r\n\t$(\".ColorPickerDivSample\").css(\"cursor\",\"pointer\");\r\n\r\n\t$(\"#colorPickerVtd td\").each(function(){\r\n        $(this).css(\"border\",\"1px solid \" + $(this).css(\"backgroundColor\"));\r\n    })\r\n\t\t.css(\"cursor\",\"pointer\");\r\n\r\n\t$(\".selector,.ColorPickerDivSample\").click(function(){\r\n\t    click_color_event(this);\r\n\t});\r\n\r\n\t$(\"#colorPickerVtd\").mouseover(function(){\r\n\t\tif(closetimerpicker) {\r\n\t\t\twindow.clearTimeout(closetimerpicker);\r\n\t\t\tclosetimerpicker = null;\r\n\t\t}\r\n\t}).mouseout(function(){\r\n\t\tclosetimerpicker = window.setTimeout(function (){\r\n\t\t\t\t$('#colorPickerVtd').hide();\r\n\t\t\t\t$(\"div.ColorPickerDivSample.active\").css(\"background-color\", $(\"div.ColorPickerDivSample.active\").attr(\"color1\"));\r\n\t\t\t}, timeoutpicker);\r\n\t});\r\n\r\n\t$(\"#colorPickerVtd td\").mouseover(function(){\r\n\t\tif(closetimerpicker) {\r\n\t\t\twindow.clearTimeout(closetimerpicker);\r\n\t\t\tclosetimerpicker = null;\r\n\t\t}\r\n\t\t$(this).css(\"border\", \"1px dotted #fff\");\r\n\t\t$(\"div.ColorPickerDivSample.active\").css(\"background-color\", $(this).css(\"background-color\"));\r\n\t});\r\n\r\n\t$(\"#colorPickerVtd td\").mouseout(function(){\r\n\t\t$(this).css(\"border\", \"1px solid \"+$(\"div.ColorPickerDivSample.active\").css(\"background-color\"));\r\n\t});\r\n\r\n\t$(\"#colorPickerVtd td\").click(function(){\r\n\t\tif ( this.id == \"nocolor\" ) {\r\n\t\t\t$(\"div.ColorPickerDivSample.active\").attr(\"color1\", \"\");\r\n\t\t\t$(\"div.ColorPickerDivSample.active\").attr(\"color2\", \"\");\r\n\t\t} else {\r\n\t\t\tbgcol=$(this).css(\"backgroundColor\");\r\n\t\t\tif(bgcol.substring(0,1)!=\"#\")\r\n\t\t\t\tbgcol=rgbToHex(bgcol);\r\n\t\t\telse\r\n\t\t\t\tbgcol=bgcol.substring(1);\r\n\t\t\t$(\"div.ColorPickerDivSample.active\").attr(\"color1\", bgcol);\r\n\t\t\tarr = HexToDec(bgcol);\r\n\t\t\tred = parseInt( arr[0] * 0.85 );\r\n\t\t\tgreen = parseInt( arr[1] * 0.85 );\r\n\t\t\tblue = parseInt( arr[2] * 0.85 );\r\n\t\t\thex = DecToHex( red, green, blue );\r\n\t\t\t$(\"div.ColorPickerDivSample.active\").attr(\"color2\", hex);\r\n\t\t}\r\n\t\t$(\"#colorPickerVtd\").hide();\r\n\t});\r\n\r\n\tfunction click_color_event(th)\r\n\t{\r\n\t\tif($(th).css(\"cursor\")==\"pointer\")\r\n\t    {\r\n\t\t\tif(closetimerpicker) {\r\n\t\t\t\twindow.clearTimeout(closetimerpicker);\r\n\t\t\t\tclosetimerpicker = null;\r\n\t\t}\r\n\t\tif($(th).attr(\"class\")==\"selector\")\r\n\t\t\tbc=$(th).parents(\"td:first\").prev(\"td\").find(\"div.ColorPickerDivSample\").css(\"background-color\");\r\n\t\telse\r\n\t\t\tbc=$(th).parents(\"td:first\").find(\"div.ColorPickerDivSample\").css(\"background-color\");\r\n\r\n\t\tvar activeDiv = $(\"div.ColorPickerDivSample.active\"), colorPicker = $(\"#colorPickerVtd\");\r\n\t\tif(activeDiv.length){\r\n\t\t\tactiveDiv.css(\"background-color\", activeDiv.attr(\"color1\"));\r\n\t\t\tactiveDiv.removeClass(\"active\");\r\n\t\t}\r\n\r\n\t\tif($(th).attr(\"class\")==\"selector\")\r\n\t\t\t$(th).parents(\"td:first\").prev(\"td\").find(\"div.ColorPickerDivSample\").addClass(\"active\");\r\n\t\telse\r\n\t\t\t$(th).parents(\"td:first\").find(\"div.ColorPickerDivSample\").addClass(\"active\");\r\n\r\n\r\n\t\tcolorPicker.css(\"top\", $(th).offset().top + \"px\");\r\n\t\tcolorPicker.css(\"left\", $(th).offset().left + $(th).width() + 3 + \"px\");\r\n\t\tcolorPicker.show();\r\n\t\t$(\"td\", colorPicker).each(function(){\r\n\t\t\t$(this).css(\"border\", \"1px solid \"+$(this).css(\"background-color\"));\r\n\t\t\tif(bc==$(this).css(\"background-color\"))\r\n\t\t\t\t$(this).css(\"border\", \"1px dotted #fff\");\r\n\t\t});\r\n\t    }\r\n\t}\r\n\r\n\t";
			return null;
		}
		public static XVar MoveTdTotal()
		{
			return "\r\nfunction total_td_move(th,direct)\r\n{\r\n\ttr=$(th).parent().parent().parent();\r\n\r\n\tif(direct==\"up\")\r\n\t\ttr2=$(tr).prev();\r\n\telse\r\n\t\ttr2=$(tr).next();\r\n\t// || $(tr2).find(\"td\").eq(3).find(\"input\").get(0).type=='checkbox'\r\n\tif(!$(tr2).find(\"td\").eq(3).find(\"input\").get(0) || $(tr2).find(\"td\").eq(3).find(\"input\").get(0).disabled)\r\n\t\ttr2=\"\";\r\n\tif(tr2!=\"\")\r\n\t{\r\n\t\tif(direct==\"up\")\r\n\t\t\t$(tr).insertBefore(tr2);\r\n\t\telse\r\n\t\t\t$(tr).insertAfter(tr2);\r\n\t}\r\n}";
			return null;
		}
		public static XVar PrepareString4DB(dynamic _param_str, dynamic _param_connection)
		{
			#region pass-by-value parameters
			dynamic str = XVar.Clone(_param_str);
			dynamic connection = XVar.Clone(_param_connection);
			#endregion

			dynamic chunklen = null, chunks = null, i = null, var_out = null;
			if(connection.dbType != Constants.nDATABASE_Oracle)
			{
				return connection.prepareString((XVar)(str));
			}
			if(MVCFunctions.strlen((XVar)(str)) < 4000)
			{
				return connection.prepareString((XVar)(str));
			}
			chunklen = new XVar(3900);
			chunks = XVar.Clone((XVar)Math.Floor((double)(MVCFunctions.strlen((XVar)(str)) / chunklen)));
			if(MVCFunctions.strlen((XVar)(str))  %  chunklen != 0)
			{
				chunks++;
			}
			var_out = new XVar("");
			i = new XVar(0);
			for(;i < chunks; i++)
			{
				if(XVar.Pack(MVCFunctions.strlen((XVar)(var_out))))
				{
					var_out = MVCFunctions.Concat(var_out, "||");
				}
				var_out = MVCFunctions.Concat(var_out, "to_clob(");
				var_out = MVCFunctions.Concat(var_out, connection.prepareString((XVar)(MVCFunctions.substr((XVar)(str), (XVar)(i * chunklen), (XVar)(chunklen)))));
				var_out = MVCFunctions.Concat(var_out, ")");
			}
			return var_out;
		}
		public static XVar WRmake_db_value(dynamic _param_field, dynamic _param_value, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic ret = null;
			ret = XVar.Clone(CommonFunctions.WRprepare_for_db((XVar)(field), (XVar)(value), (XVar)(table)));
			if(XVar.Equals(XVar.Pack(ret), XVar.Pack(false)))
			{
				return ret;
			}
			return CommonFunctions.WRadd_db_quotes((XVar)(field), (XVar)(ret), (XVar)(table));
		}
		public static XVar WRadd_db_quotes(dynamic _param_field, dynamic _param_value, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic connection = null, var_type = null;
			connection = XVar.Clone(CommonFunctions.getWebreportConnection());
			var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", field))));
			if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(var_type))))
			{
				return connection.addSlashesBinary((XVar)(value));
			}
			if((XVar)((XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack("")))  || (XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack(false))))  && (XVar)(!(XVar)(CommonFunctions.IsCharType((XVar)(var_type)))))
			{
				return "null";
			}
			if(XVar.Pack(CommonFunctions.NeedQuotes((XVar)(var_type))))
			{
				if(XVar.Pack(!(XVar)(CommonFunctions.IsDateFieldType((XVar)(var_type)))))
				{
					value = XVar.Clone(connection.prepareString((XVar)(value)));
				}
				else
				{
					value = XVar.Clone(connection.addDateQuotes((XVar)(value)));
				}
			}
			else
			{
				dynamic strvalue = null;
				strvalue = XVar.Clone(XVar.Pack(value).ToString());
				strvalue = XVar.Clone(MVCFunctions.str_replace(new XVar(","), new XVar("."), (XVar)(strvalue)));
				if(XVar.Pack(MVCFunctions.IsNumeric(strvalue)))
				{
					value = XVar.Clone(strvalue);
				}
				else
				{
					value = new XVar(0);
				}
			}
			return value;
		}
		public static XVar WRprepare_for_db(dynamic _param_field, dynamic _param_value, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic var_type = null;
			var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", field))));
			if(XVar.Pack(MVCFunctions.is_array((XVar)(value))))
			{
				value = XVar.Clone(CommonFunctions.combinevalues((XVar)(value)));
			}
			if((XVar)((XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack("")))  || (XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack(false))))  && (XVar)(!(XVar)(CommonFunctions.IsCharType((XVar)(var_type)))))
			{
				return "";
			}
			if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(var_type))))
			{
				value = XVar.Clone(CommonFunctions.localdatetime2db((XVar)(value)));
			}
			return value;
		}
		public static XVar DBGetTablesList()
		{
			dynamic ret = XVar.Array(), tables = XVar.Array();
			tables = XVar.Clone(CommonFunctions.WRGetTablesList());
			ret = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> value in tables.GetEnumerator())
			{
				dynamic val_lower = null;
				val_lower = XVar.Clone(CommonFunctions.wr_getTableName((XVar)(MVCFunctions.strtolower((XVar)(value.Value)))));
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(val_lower), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(val_lower), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(val_lower), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(val_lower), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(val_lower), new XVar(-10)) != "_ugmembers"))  && (XVar)(val_lower != "admin_rights"))  && (XVar)(val_lower != "admin_users"))  && (XVar)(val_lower != "admin_members"))  && (XVar)(val_lower != "webreports"))  && (XVar)(val_lower != "webreport_style"))  && (XVar)(val_lower != "webreport_admin"))  && (XVar)(val_lower != "webreport_settings"))  && (XVar)(val_lower != "webreport_sql"))
				{
					ret.InitAndSetArrayItem(value.Value, null);
				}
			}
			return ret;
		}
		public static XVar WRGetTableListAdmin(dynamic _param_db_type)
		{
			#region pass-by-value parameters
			dynamic db_type = XVar.Clone(_param_db_type);
			#endregion

			dynamic data = XVar.Array(), dataSource = null, dc = null, ret = XVar.Array(), rs = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("db_type"), (XVar)(db_type)));
			dataSource = XVar.Clone(CommonFunctions.wrAdminDataSource());
			rs = XVar.Clone(dataSource.getList((XVar)(dc)));
			if(XVar.Pack(!(XVar)(rs)))
			{
				return XVar.Array();
			}
			ret = XVar.Clone(XVar.Array());
			while(XVar.Pack(data = XVar.Clone(rs.fetchAssoc())))
			{
				ret.InitAndSetArrayItem(new XVar("tablename", data["tablename"], "group", data["group_name"]), null);
			}
			return ret;
		}
		public static XVar GetTablesListReport()
		{
			dynamic arr = XVar.Array(), securityFlag = null;
			arr = XVar.Clone(XVar.Array());
			securityFlag = new XVar(true);
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.sysdiagrams")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.sysdiagrams");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.sysdiagrams", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.rspdHeader")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.rspdHeader");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.rspdHeader", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.company")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.company");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.company", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.radioEquipment")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.radioEquipment");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.radioEquipment", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.baranggay")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.baranggay");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.baranggay", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.city")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.city");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.city", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.province")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.province");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.province", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_beta_users")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_beta_users");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_beta_users", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("admin_rights")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("admin_rights");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("admin_rights", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("admin_members")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("admin_members");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("admin_members", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("admin_users")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("admin_users");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("admin_users", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.stage")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.stage");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.stage", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.stageStatus")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.stageStatus");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.stageStatus", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_betauggroups")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_betauggroups");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_betauggroups", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_beta_audit")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_beta_audit");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_beta_audit", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_beta_settings")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_beta_settings");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_beta_settings", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_betaugmembers")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_betaugmembers");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_betaugmembers", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.spectrum_betaugrights")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.spectrum_betaugrights");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.spectrum_betaugrights", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.transactionSetup")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.transactionSetup");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.transactionSetup", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.rspd_application_received")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.rspd_application_received");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.rspd_application_received", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.applicationsRecieved")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.applicationsRecieved");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.applicationsRecieved", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.branch")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.branch");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.branch", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("users")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("users");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("users", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.classStation")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.classStation");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.classStation", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("applicationEndorsed")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("applicationEndorsed");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("applicationEndorsed", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("applicationUnderAssessment")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("applicationUnderAssessment");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("applicationUnderAssessment", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("applicationUnderTechnicalEvaluation")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("applicationUnderTechnicalEvaluation");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("applicationUnderTechnicalEvaluation", null);
				}
			}
			if(XVar.Pack(Security.permissionsAvailable()))
			{
				dynamic strPerm = null;
				strPerm = XVar.Clone(CommonFunctions.GetUserPermissions(new XVar("dbo.region")));
				securityFlag = XVar.Clone((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("P"))), XVar.Pack(false)))  || (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false))));
			}
			if(XVar.Pack(securityFlag))
			{
				dynamic value = null;
				value = new XVar("dbo.region");
				if((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)((XVar)(MVCFunctions.substr((XVar)(value), new XVar(-6)) != "_audit")  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-8)) != "_locking"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_ugrights"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-9)) != "_uggroups"))  && (XVar)(MVCFunctions.substr((XVar)(value), new XVar(-10)) != "_ugmembers"))  && (XVar)(value != "admin_rights"))  && (XVar)(value != "admin_users"))  && (XVar)(value != "admin_members"))  && (XVar)(value != "webreports"))  && (XVar)(value != "webreport_style"))  && (XVar)(value != "webreport_settings"))  && (XVar)(value != "webreport_admin"))  && (XVar)(value != "webreport_sql"))
				{
					arr.InitAndSetArrayItem("dbo.region", null);
				}
			}
			return arr;
		}
		public static XVar GetTablesListCustom()
		{
			dynamic arr = XVar.Array(), connection = null, data = XVar.Array(), qResult = null;
			connection = XVar.Clone(CommonFunctions.getWebreportConnection());
			arr = XVar.Clone(XVar.Array());
			qResult = XVar.Clone(connection.query((XVar)(MVCFunctions.Concat("select * from ", connection.addTableWrappers(new XVar("webreport_sql")), " order by ", connection.addFieldWrappers(new XVar("sqlname"))))));
			while(XVar.Pack(data = XVar.Clone(qResult.fetchAssoc())))
			{
				arr.InitAndSetArrayItem(new XVar("sqlname", data["sqlname"], "isStorProc", CommonFunctions.IsStoredProcedure((XVar)(data["sqlcontent"]))), null);
			}
			return arr;
		}
		public static XVar DBGetTablesListByGroup(dynamic _param_db = null)
		{
			#region default values
			if(_param_db as Object == null) _param_db = new XVar("db");
			#endregion

			#region pass-by-value parameters
			dynamic db = XVar.Clone(_param_db);
			#endregion

			dynamic ret = XVar.Array(), tables = XVar.Array(), tables_admin = XVar.Array(), userGroups = XVar.Array();
			if(db == "db")
			{
				tables = XVar.Clone(CommonFunctions.DBGetTablesList());
			}
			else
			{
				if(db == "project")
				{
					tables = XVar.Clone(CommonFunctions.GetTablesListReport());
				}
				else
				{
					tables = XVar.Clone(CommonFunctions.GetTablesListCustom());
				}
			}
			ret = XVar.Clone(XVar.Array());
			if(db == "db")
			{
				tables_admin = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("db")));
			}
			else
			{
				if(db == "project")
				{
					tables_admin = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("project")));
				}
				else
				{
					tables_admin = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("custom")));
				}
			}
			userGroups = XVar.Clone(CommonFunctions.GetUserGroup());
			foreach (KeyValuePair<XVar, dynamic> table_name in tables.GetEnumerator())
			{
				dynamic tablename = null;
				if(db == "custom")
				{
					tablename = XVar.Clone(table_name.Value["sqlname"]);
				}
				else
				{
					tablename = XVar.Clone(table_name.Value);
				}
				foreach (KeyValuePair<XVar, dynamic> tablerights in tables_admin.GetEnumerator())
				{
					dynamic found = null;
					if(tablerights.Value["tablename"] != tablename)
					{
						continue;
					}
					found = new XVar(false);
					if(XVar.Pack(!(XVar)(userGroups)))
					{
						found = new XVar(true);
					}
					else
					{
						if(tablerights.Value["group"] == "")
						{
							found = new XVar(true);
						}
						else
						{
							foreach (KeyValuePair<XVar, dynamic> group in userGroups.GetEnumerator())
							{
								if(XVar.Pack(group.Value).ToString() == tablerights.Value["group"])
								{
									found = new XVar(true);
									break;
								}
							}
						}
					}
					if(XVar.Pack(found))
					{
						ret.InitAndSetArrayItem(table_name.Value, null);
						break;
					}
				}
			}
			return ret;
		}
		public static XVar isWRAdmin()
		{
			dynamic sUserGroup = null;
			if(XVar.Pack(!(XVar)(Security.permissionsAvailable())))
			{
				return XSession.Session["WRAdmin"];
			}
			sUserGroup = XVar.Clone(XSession.Session["GroupID"]);
			if(XVar.Pack(!(XVar)(Security.dynamicPermissions())))
			{
			}
			else
			{
				return CommonFunctions.IsAdmin();
			}
			return null;
		}
		public static XVar sortUserGroup(dynamic _param_a, dynamic _param_b)
		{
			#region pass-by-value parameters
			dynamic a = XVar.Clone(_param_a);
			dynamic b = XVar.Clone(_param_b);
			#endregion

			if(a[1] < b[1])
			{
				return -1;
			}
			else
			{
				return 1;
			}
			return null;
		}
		public static XVar Convert_Old_Chart(dynamic _param_arr)
		{
			#region pass-by-value parameters
			dynamic arr = XVar.Clone(_param_arr);
			#endregion

			dynamic i = null;
			switch(((XVar)arr["chart_type"]["type"]).ToString())
			{
				case "3d_column":
					arr.InitAndSetArrayItem("2d_column", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "is3d");
					arr.InitAndSetArrayItem("false", "appearance", "isstacked");
					break;
				case "3d_bar":
					arr.InitAndSetArrayItem("2d_bar", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "is3d");
					arr.InitAndSetArrayItem("false", "appearance", "isstacked");
					break;
				case "3d_column_stacked":
					arr.InitAndSetArrayItem("2d_column", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "is3d");
					arr.InitAndSetArrayItem("true", "appearance", "isstacked");
					break;
				case "3d_bar_stacked":
					arr.InitAndSetArrayItem("2d_bar", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "is3d");
					arr.InitAndSetArrayItem("true", "appearance", "isstacked");
					break;
				case "2d_column_stacked":
					arr.InitAndSetArrayItem("2d_column", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "isstacked");
					arr.InitAndSetArrayItem("false", "appearance", "is3d");
					break;
				case "2d_column":
					arr.InitAndSetArrayItem("2d_column", "chart_type", "type");
					if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("isstacked"))))
					{
						arr.InitAndSetArrayItem("false", "appearance", "isstacked");
					}
					if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("is3d"))))
					{
						arr.InitAndSetArrayItem("false", "appearance", "is3d");
					}
					break;
				case "2d_bar_stacked":
					arr.InitAndSetArrayItem("2d_bar", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "isstacked");
					arr.InitAndSetArrayItem("false", "appearance", "is3d");
					break;
				case "2d_bar":
					arr.InitAndSetArrayItem("2d_bar", "chart_type", "type");
					if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("isstacked"))))
					{
						arr.InitAndSetArrayItem("false", "appearance", "isstacked");
					}
					if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("is3d"))))
					{
						arr.InitAndSetArrayItem("false", "appearance", "is3d");
					}
					break;
				case "line":
					arr.InitAndSetArrayItem("line", "chart_type", "type");
					if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("linestyle"))))
					{
						arr.InitAndSetArrayItem(0, "appearance", "linestyle");
					}
					break;
				case "spline":
					arr.InitAndSetArrayItem("line", "chart_type", "type");
					arr.InitAndSetArrayItem(1, "appearance", "linestyle");
					break;
				case "step_line":
					arr.InitAndSetArrayItem("line", "chart_type", "type");
					arr.InitAndSetArrayItem(2, "appearance", "linestyle");
					break;
				case "area_stacked":
					arr.InitAndSetArrayItem("area", "chart_type", "type");
					arr.InitAndSetArrayItem("true", "appearance", "isstacked");
					break;
			}
			if(XVar.Pack(!(XVar)(arr["appearance"].KeyExists("cscroll"))))
			{
				arr.InitAndSetArrayItem("true", "appearance", "cscroll");
				arr.InitAndSetArrayItem("false", "appearance", "autoupdate");
				arr.InitAndSetArrayItem("10", "appearance", "maxbarscroll");
				arr.InitAndSetArrayItem("5", "appearance", "update_interval");
			}
			i = new XVar(0);
			for(;i < 4; i++)
			{
				if(XVar.Pack(arr["appearance"].KeyExists(MVCFunctions.Concat("color", i + 1, "1"))))
				{
					arr.InitAndSetArrayItem(arr["appearance"][MVCFunctions.Concat("color", i + 1, "1")], "parameters", i, "series_color");
				}
			}
			return arr;
		}
		public static XVar WRGetListCustomSQL()
		{
			dynamic arr = XVar.Array(), connection = null, data = XVar.Array(), qResult = null;
			connection = XVar.Clone(CommonFunctions.getWebreportConnection());
			arr = XVar.Clone(XVar.Array());
			qResult = XVar.Clone(connection.query((XVar)(MVCFunctions.Concat("select * from ", connection.addTableWrappers(new XVar("webreport_sql")), " order by ", connection.addFieldWrappers(new XVar("sqlname"))))));
			while(XVar.Pack(data = XVar.Clone(qResult.fetchAssoc())))
			{
				arr.InitAndSetArrayItem(new XVar("id", data["id"], "sqlname", data["sqlname"], "sqlcontent", data["sqlcontent"]), null);
			}
			return arr;
		}
		public static XVar WRgetCurrentCustomSQL(dynamic _param_id)
		{
			#region pass-by-value parameters
			dynamic id = XVar.Clone(_param_id);
			#endregion

			dynamic data = XVar.Array();
			if(XVar.Pack(!(XVar)(id)))
			{
				return new XVar(0, 0, 1, "", 2, "");
			}
			data = XVar.Clone(CommonFunctions.wrGetCustomSQLRecordById((XVar)(id)));
			if(XVar.Pack(data))
			{
				return new XVar(0, data["id"], 1, data["sqlname"], 2, data["sqlcontent"]);
			}
			return "";
		}
		public static XVar getCustomSQLbyName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic data = XVar.Array();
			data = XVar.Clone(CommonFunctions.wrGetCustomSQLRecordByName((XVar)(name)));
			if(XVar.Pack(data))
			{
				return new XVar(0, data["id"], 1, data["sqlname"], 2, data["sqlcontent"]);
			}
			return "";
		}
		public static XVar update_report_totals()
		{
			dynamic all_fields = XVar.Array(), arr_unset = XVar.Array(), fields = XVar.Array(), root = XVar.Array(), tables = XVar.Array();
			root = XSession.Session["webreports"];
			tables = XVar.Clone(CommonFunctions.getReportTablesList());
			if(XVar.Pack(CommonFunctions.is_wr_custom()))
			{
				fields = XVar.Clone(CommonFunctions.WRGetFieldsList(new XVar("")));
			}
			arr_unset = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> fld in root["totals"].GetEnumerator())
			{
				if((XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(fld.Value["table"]), (XVar)(tables))), XVar.Pack(false)))  || (XVar)((XVar)(XVar.Equals(XVar.Pack(fld.Value["table"]), XVar.Pack(null)))  && (XVar)(CommonFunctions.is_wr_custom())))
				{
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
					{
						fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(fld.Value["table"])));
					}
					if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(fld.Value["name"]), (XVar)(fields))), XVar.Pack(false)))
					{
						continue;
					}
				}
				arr_unset.InitAndSetArrayItem(fld.Key, null);
			}
			foreach (KeyValuePair<XVar, dynamic> fld in arr_unset.GetEnumerator())
			{
				root["totals"].Remove(fld.Value);
			}
			all_fields = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> t in tables.GetEnumerator())
			{
				fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(t.Value)));
				foreach (KeyValuePair<XVar, dynamic> f in fields.GetEnumerator())
				{
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						all_fields.InitAndSetArrayItem(MVCFunctions.Concat(t.Value, ".", f.Value), null);
					}
					else
					{
						all_fields.InitAndSetArrayItem(f.Value, null);
					}
				}
			}
			foreach (KeyValuePair<XVar, dynamic> fieldItem in all_fields.GetEnumerator())
			{
				dynamic f = null, fld = XVar.Array(), table = null;
				ProjectSettings pSet;
				f = XVar.Clone(fieldItem.Value);
				table = new XVar("");
				fld = new XVar("");
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					CommonFunctions.WRSplitFieldName((XVar)(f), ref table, ref fld);
				}
				else
				{
					table = XVar.Clone(tables[0]);
					fld = XVar.Clone(f);
					f = XVar.Clone(MVCFunctions.Concat(table, "_", f));
				}
				if(XVar.Pack(root["totals"].KeyExists(MVCFunctions.GoodFieldName((XVar)(f)))))
				{
					continue;
				}
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table), new XVar(Constants.PAGE_LIST)));
				root.InitAndSetArrayItem(XVar.Array(), "totals", MVCFunctions.GoodFieldName((XVar)(f)));
				root.InitAndSetArrayItem(fld, "totals", MVCFunctions.GoodFieldName((XVar)(f)), "name");
				root.InitAndSetArrayItem(table, "totals", MVCFunctions.GoodFieldName((XVar)(f)), "table");
				root.InitAndSetArrayItem(pSet.label((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "label");
				root.InitAndSetArrayItem("true", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "show");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "min");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "max");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "sum");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "avg");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "curr");
				root.InitAndSetArrayItem("", "totals", MVCFunctions.GoodFieldName((XVar)(f)), "search");
				root.InitAndSetArrayItem(CommonFunctions.GetGenericViewFormat((XVar)(table), (XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "view_format");
				root.InitAndSetArrayItem(CommonFunctions.GetGenericEditFormat((XVar)(table), (XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "edit_format");
				root.InitAndSetArrayItem(pSet.getDisplayField((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "display_field");
				root.InitAndSetArrayItem(pSet.getLinkField((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "linkfield");
				root.InitAndSetArrayItem(pSet.showThumbnail((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "show_thumbnail");
				root.InitAndSetArrayItem(pSet.NeedEncode((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "need_encode");
				root.InitAndSetArrayItem(pSet.getStrThumbnail((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "thumbnail");
				root.InitAndSetArrayItem(pSet.getImageWidth((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "listformatobj_imgwidth");
				root.InitAndSetArrayItem(pSet.getImageHeight((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "listformatobj_imgheight");
				root.InitAndSetArrayItem(pSet.getLinkPrefix((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "hlprefix");
				root.InitAndSetArrayItem(pSet.getFilenameField((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "listformatobj_filename");
				root.InitAndSetArrayItem(pSet.getLookupType((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "lookupobj_lookuptype");
				root.InitAndSetArrayItem(pSet.getDisplayField((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "editformatobj_lookupobj_customdispaly");
				root.InitAndSetArrayItem(pSet.getLookupTable((XVar)(fld)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "editformatobj_lookupobj_table");
				root.InitAndSetArrayItem(CommonFunctions.prepareLookupWhere((XVar)(fld), (XVar)(pSet)), "totals", MVCFunctions.GoodFieldName((XVar)(f)), "editformatobj_lookupobj_where");
			}
			XSession.Session["webreports"] = root;
			return null;
		}
		public static XVar Reload_Report(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic arr = XVar.Array();
			if(XVar.Pack(!(XVar)(name)))
			{
				if(XVar.Pack(XSession.Session.KeyExists("webreports")))
				{
					return true;
				}
				else
				{
					MVCFunctions.HeaderRedirect(new XVar("webreport"));
				}
			}
			if((XVar)(MVCFunctions.postvalue(new XVar("edit")) == "style")  && (XVar)(XSession.Session.KeyExists("webreports")))
			{
				return true;
			}
			arr = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(name), new XVar(Constants.WR_REPORT)));
			if(XVar.Pack(!(XVar)(arr)))
			{
				MVCFunctions.HeaderRedirect(new XVar("webreport"));
			}
			if(XVar.Pack(!(XVar)(arr["table_type"])))
			{
				if(XVar.Pack(arr["db_based"]))
				{
					arr.InitAndSetArrayItem("db", "table_type");
				}
				else
				{
					arr.InitAndSetArrayItem("project", "table_type");
				}
			}
			XSession.Session["webreports"] = arr;
			XSession.Session.InitAndSetArrayItem(XSession.Session["webreports"]["table_type"], "webobject", "table_type");
			XSession.Session.InitAndSetArrayItem(XSession.Session["webreports"]["settings"]["name"], "webobject", "name");
			return null;
		}
		public static XVar Reload_Chart(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic arr = XVar.Array();
			if(XVar.Pack(!(XVar)(name)))
			{
				if(XVar.Pack(XSession.Session.KeyExists("webcharts")))
				{
					return true;
				}
				else
				{
					MVCFunctions.HeaderRedirect(new XVar("webreport"));
				}
			}
			arr = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(name), new XVar(Constants.WR_CHART)));
			if(XVar.Pack(!(XVar)(arr)))
			{
				MVCFunctions.HeaderRedirect(new XVar("webreport"));
			}
			if(XVar.Pack(!(XVar)(arr["table_type"])))
			{
				if(XVar.Pack(arr["db_based"]))
				{
					arr.InitAndSetArrayItem("db", "table_type");
				}
				else
				{
					arr.InitAndSetArrayItem("project", "table_type");
				}
			}
			XSession.Session["webcharts"] = arr;
			XSession.Session.InitAndSetArrayItem(XSession.Session["webcharts"]["table_type"], "webobject", "table_type");
			XSession.Session.InitAndSetArrayItem(XSession.Session["webcharts"]["settings"]["name"], "webobject", "name");
			return null;
		}
		public static XVar wr_getTableName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic pos = null;
			pos = XVar.Clone(MVCFunctions.strrpos((XVar)(name), new XVar(".")));
			if(!XVar.Equals(XVar.Pack(pos), XVar.Pack(false)))
			{
				name = XVar.Clone(MVCFunctions.substr((XVar)(name), (XVar)(pos + 1)));
			}
			return name;
		}
		public static XVar getWebreportConnection()
		{
			return GlobalVars.cman.getForWebReports();
		}
		public static XVar SetWRLangVars(dynamic _param_xt_packed, dynamic _param_prefix)
		{
			#region packeted values
			XTempl _param_xt = XVar.UnPackXTempl(_param_xt_packed);
			#endregion

			#region pass-by-value parameters
			XTempl xt = XVar.Clone(_param_xt);
			dynamic prefix = XVar.Clone(_param_prefix);
			#endregion

			dynamic is508 = null, var_var = null;
			xt.assign(new XVar("lang_label"), new XVar(true));
			var_var = XVar.Clone(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(CommonFunctions.mlang_getcurrentlang())), "_langattrs"));
			xt.assign((XVar)(var_var), new XVar("selected"));
			is508 = XVar.Clone(CommonFunctions.isEnableSection508());
			if(XVar.Pack(is508))
			{
				xt.assign_section(new XVar("lang_label"), new XVar("<label for=\"lang\">"), new XVar("</label>"));
			}
			xt.assign(new XVar("langselector_attrs"), (XVar)(MVCFunctions.Concat("name=lang ", (XVar.Pack(is508 == true) ? XVar.Pack("id=\"lang\" ") : XVar.Pack("")), "onchange=\"javascript: window.location='", MVCFunctions.GetTableLink((XVar)(prefix)), "?language='+this.options[this.selectedIndex].value\"")));
			return null;
		}
		public static XVar getProjectWRSubsetDataCommand(dynamic _param_tName, dynamic sortFields, dynamic _param_pSet_packed, dynamic _param_editmode = null)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region default values
			if(_param_editmode as Object == null) _param_editmode = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic tName = XVar.Clone(_param_tName);
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			dynamic editmode = XVar.Clone(_param_editmode);
			#endregion

			dynamic subsetDataCommand = null;
			subsetDataCommand = XVar.Clone(new DsCommand());
			subsetDataCommand.order = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> field in sortFields.GetEnumerator())
			{
				subsetDataCommand.order.InitAndSetArrayItem(new XVar("column", field.Value["name"], "dir", (XVar.Pack(field.Value["desc"]) ? XVar.Pack("DESC") : XVar.Pack("ASC"))), null);
			}
			subsetDataCommand.filter = XVar.Clone(Security.SelectCondition(new XVar("S"), (XVar)(pSet)));
			if(XVar.Pack(!(XVar)(editmode)))
			{
				dynamic searchClauseObj = null;
				searchClauseObj = XVar.Clone(SearchClause.getSearchObject((XVar)(tName)));
				searchClauseObj.searchFieldsArr = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(tName)));
				subsetDataCommand.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, subsetDataCommand.filter, 1, searchClauseObj.getSearchDataCondition()))));
			}
			return subsetDataCommand;
		}
		public static XVar wrGetEntityRecord(dynamic _param_name, dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic dataSource = null, dc = null, rs = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, DataCondition.FieldEquals(new XVar("rpt_name"), (XVar)(name)), 1, DataCondition.FieldEquals(new XVar("rpt_type"), (XVar)(CommonFunctions.wrSqlType((XVar)(var_type))))))));
			dataSource = XVar.Clone(CommonFunctions.wrMainDataSource());
			rs = XVar.Clone(dataSource.getSingle((XVar)(dc)));
			if(XVar.Pack(rs))
			{
				return rs.fetchAssoc();
			}
			return null;
		}
		public static XVar wrGetCustomSQLRecordByName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic dataSource = null, dc = null, rs = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("sqlname"), (XVar)(name)));
			dataSource = XVar.Clone(CommonFunctions.wrSqlDataSource());
			rs = XVar.Clone(dataSource.getSingle((XVar)(dc)));
			if(XVar.Pack(rs))
			{
				return rs.fetchAssoc();
			}
			return null;
		}
		public static XVar wrGetCustomSQLRecordById(dynamic _param_id)
		{
			#region pass-by-value parameters
			dynamic id = XVar.Clone(_param_id);
			#endregion

			dynamic dataSource = null, dc = null, rs = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("id"), (XVar)(id)));
			dataSource = XVar.Clone(CommonFunctions.wrSqlDataSource());
			rs = XVar.Clone(dataSource.getSingle((XVar)(dc)));
			if(XVar.Pack(rs))
			{
				return rs.fetchAssoc();
			}
			return null;
		}
		public static XVar wrGetCustomSQL(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic data = XVar.Array();
			data = XVar.Clone(CommonFunctions.wrGetCustomSQLRecordByName((XVar)(name)));
			if(XVar.Pack(data))
			{
				return data["sqlcontent"];
			}
			return "";
		}
		public static XVar wrGetStyleRS(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic dataSource = null, dc = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("repname"), (XVar)(name)));
			dc.order.InitAndSetArrayItem(new XVar("column", "report_style_id", "dir", "ASC"), null);
			dataSource = XVar.Clone(CommonFunctions.wrStyleDataSource());
			return dataSource.getList((XVar)(dc));
		}
		public static XVar wrMainDataSource()
		{
			return CommonFunctions.getDbTableDataSource(new XVar("webreports"), (XVar)(GlobalVars.cman.getSavedSearchesConnId()));
		}
		public static XVar wrSqlDataSource()
		{
			return CommonFunctions.getDbTableDataSource(new XVar("webreport_sql"), (XVar)(GlobalVars.cman.getSavedSearchesConnId()));
		}
		public static XVar wrAdminDataSource()
		{
			return CommonFunctions.getDbTableDataSource(new XVar("webreport_admin"), (XVar)(GlobalVars.cman.getSavedSearchesConnId()));
		}
		public static XVar wrStyleDataSource()
		{
			return CommonFunctions.getDbTableDataSource(new XVar("webreport_style"), (XVar)(GlobalVars.cman.getSavedSearchesConnId()));
		}
	}
}
