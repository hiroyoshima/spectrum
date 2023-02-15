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
	public partial class GlobalController : BaseController
	{
		public XVar ug_group()
		{
			try
			{
				dynamic cbxNames = null, data = XVar.Array(), dataSource = null, dc = null, nonAdminTablesArr = XVar.Array(), sql = null, ug_connection = null, var_error = null, wGroupTableName = null;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.isLogged())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(!(XVar)(Security.isAdmin())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				nonAdminTablesArr = XVar.Clone(XVar.Array());
				nonAdminTablesArr.InitAndSetArrayItem("dbo.sysdiagrams", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.rspdHeader", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.company", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.radioEquipment", null);
				nonAdminTablesArr.InitAndSetArrayItem("Dashboard", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.baranggay", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.city", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.province", null);
				nonAdminTablesArr.InitAndSetArrayItem("FAS Report", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_beta_users", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.stage", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.stageStatus", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_betauggroups", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_beta_audit", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_beta_settings", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_betaugmembers", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.spectrum_betaugrights", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.transactionSetup", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.rspd_application_received", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.applicationsRecieved", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.branch", null);
				nonAdminTablesArr.InitAndSetArrayItem("users", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.classStation", null);
				nonAdminTablesArr.InitAndSetArrayItem("applicationEndorsed", null);
				nonAdminTablesArr.InitAndSetArrayItem("applicationUnderAssessment", null);
				nonAdminTablesArr.InitAndSetArrayItem("applicationUnderTechnicalEvaluation", null);
				nonAdminTablesArr.InitAndSetArrayItem("dbo.region", null);
				ug_connection = XVar.Clone(GlobalVars.cman.getForUserGroups());
				cbxNames = XVar.Clone(new XVar("add", new XVar("mask", "A", "rightName", "add"), "edt", new XVar("mask", "E", "rightName", "edit"), "del", new XVar("mask", "D", "rightName", "delete"), "lst", new XVar("mask", "S", "rightName", "list"), "exp", new XVar("mask", "P", "rightName", "export"), "imp", new XVar("mask", "I", "rightName", "import"), "adm", new XVar("mask", "M")));
				wGroupTableName = XVar.Clone(ug_connection.addTableWrappers(new XVar("dbo.spectrum_betauggroups")));
				switch(((XVar)MVCFunctions.postvalue(new XVar("a"))).ToString())
				{
					case "add":
						sql = XVar.Clone(MVCFunctions.Concat("insert into ", wGroupTableName, " (", ug_connection.addFieldWrappers(new XVar("Label")), ")", " values (", ug_connection.prepareString((XVar)(MVCFunctions.postvalue(new XVar("name")))), ")"));
						ug_connection.exec((XVar)(sql));
						sql = XVar.Clone(MVCFunctions.Concat("select max(", ug_connection.addFieldWrappers(new XVar("GroupID")), ") from ", wGroupTableName));
						data = XVar.Clone(ug_connection.query((XVar)(sql)).fetchNumeric());
						MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(new XVar("success", true, "id", data[0]))));
						break;
					case "del":
						sql = XVar.Clone(MVCFunctions.Concat("delete from ", wGroupTableName, " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", CommonFunctions.postvalue_number(new XVar("id"))));
						ug_connection.exec((XVar)(sql));
						sql = XVar.Clone(MVCFunctions.Concat("delete from ", ug_connection.addTableWrappers(new XVar("dbo.spectrum_betaugrights")), " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", CommonFunctions.postvalue_number(new XVar("id"))));
						ug_connection.exec((XVar)(sql));
						dataSource = XVar.Clone(Security.getUgMembersDatasource());
						dc = XVar.Clone(new DsCommand());
						dc.filter = XVar.Clone(DataCondition.FieldEquals(new XVar("GroupID"), (XVar)(CommonFunctions.postvalue_number(new XVar("id")))));
						dataSource.deleteSingle((XVar)(dc), new XVar(false));
						MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(new XVar("success", true))));
						break;
					case "rename":
						sql = XVar.Clone(MVCFunctions.Concat("update ", wGroupTableName, " set ", ug_connection.addFieldWrappers(new XVar("Label")), "=", ug_connection.prepareString((XVar)(MVCFunctions.postvalue(new XVar("name")))), " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", CommonFunctions.postvalue_number(new XVar("id"))));
						ug_connection.exec((XVar)(sql));
						MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(new XVar("success", true))));
						break;
					case "saveRights":
						var_error = new XVar("");
						if(XVar.Pack(MVCFunctions.postvalue(new XVar("state"))))
						{
							dynamic allRights = XVar.Array(), delGroupId = null, qResult = null, realTables = XVar.Array(), rightsRow = null, state = XVar.Array(), wRightsTableName = null;
							allRights = XVar.Clone(XVar.Array());
							sql = XVar.Clone(MVCFunctions.Concat("select ", ug_connection.addFieldWrappers(new XVar("GroupID")), ", ", ug_connection.addFieldWrappers(new XVar("TableName")), ", ", ug_connection.addFieldWrappers(new XVar("AccessMask")), " from ", wGroupTableName));
							qResult = XVar.Clone(ug_connection.query((XVar)(sql)));
							while(XVar.Pack(rightsRow = XVar.Clone(qResult.fetchNumeric())))
							{
								allRights.InitAndSetArrayItem(rightsRow, null);
							}
							wRightsTableName = XVar.Clone(ug_connection.addTableWrappers(new XVar("dbo.spectrum_betaugrights")));
							delGroupId = new XVar(0);
							state = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("state")))));
							foreach (KeyValuePair<XVar, dynamic> rightValue in allRights.GetEnumerator())
							{
								dynamic groupIDInt = null;
								groupIDInt = XVar.Clone((int)rightValue.Value[0]);
								if(groupIDInt == delGroupId)
								{
									continue;
								}
								if(XVar.Pack(!(XVar)(state.KeyExists(groupIDInt))))
								{
									sql = XVar.Clone(MVCFunctions.Concat("delete from ", wRightsTableName, " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", groupIDInt));
									ug_connection.exec((XVar)(sql));
								}
								else
								{
									if(XVar.Pack(!(XVar)(state[groupIDInt].KeyExists(GetTableId((XVar)(data[1]))))))
									{
										sql = XVar.Clone(MVCFunctions.Concat("delete from ", wRightsTableName, " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", groupIDInt, " and ", ug_connection.addFieldWrappers(new XVar("TableName")), "=", ug_connection.prepareString((XVar)(CommonFunctions.html_special_decode((XVar)(data[1]))))));
										ug_connection.exec((XVar)(sql));
									}
								}
							}
							realTables = XVar.Clone(GetRealValues());
							foreach (KeyValuePair<XVar, dynamic> groupRights in state.GetEnumerator())
							{
								foreach (KeyValuePair<XVar, dynamic> mask in groupRights.Value.GetEnumerator())
								{
									dynamic ins = null;
									if(XVar.Pack(!(XVar)(realTables.KeyExists(mask.Key))))
									{
										continue;
									}
									ins = new XVar(true);
									foreach (KeyValuePair<XVar, dynamic> rightValue in allRights.GetEnumerator())
									{
										if((XVar)(rightValue.Value[0] == groupRights.Key)  && (XVar)(rightValue.Value[1] == realTables[mask.Key]))
										{
											ins = new XVar(false);
											if(data[2] != mask.Value)
											{
												sql = XVar.Clone(MVCFunctions.Concat("update", wRightsTableName, " set ", ug_connection.addFieldWrappers(new XVar("AccessMask")), "=", ug_connection.prepareString((XVar)(mask.Value)), " where ", ug_connection.addFieldWrappers(new XVar("GroupID")), "=", groupRights.Key, " and ", ug_connection.addFieldWrappers(new XVar("TableName")), "=", ug_connection.prepareString((XVar)(CommonFunctions.html_special_decode((XVar)(realTables[mask.Key]))))));
												ug_connection.exec((XVar)(sql));
											}
										}
									}
									if(XVar.Pack(ins))
									{
										sql = XVar.Clone(MVCFunctions.Concat("insert into ", wRightsTableName, " (", ug_connection.addFieldWrappers(new XVar("TableName")), ", ", ug_connection.addFieldWrappers(new XVar("GroupID")), ", ", ug_connection.addFieldWrappers(new XVar("AccessMask")), ") ", "values (", ug_connection.prepareString((XVar)(CommonFunctions.html_special_decode((XVar)(realTables[mask.Key])))), ", ", groupRights.Key, ", ", ug_connection.prepareString((XVar)(mask.Value)), ")"));
										ug_connection.exec((XVar)(sql));
									}
									var_error = XVar.Clone(ug_connection.lastError());
								}
							}
						}
						getJSONResult((XVar)(var_error));
						break;
				}
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
		public static XVar GetTableId(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			dynamic i = null, tbls = XVar.Array();
			tbls = XVar.Clone(GetRealValues());
			i = new XVar(0);
			for(;i < MVCFunctions.count(tbls); i++)
			{
				if(tbls[i] == name)
				{
					return i;
				}
			}
			return -1;
		}
		public static XVar GetRealValues()
		{
			dynamic realValues = XVar.Array(), result = XVar.Array();
			result = XVar.Clone(XVar.Array());
			if(XVar.Pack(MVCFunctions.postvalue(new XVar("realValues"))))
			{
				realValues = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("realValues")))));
			}
			foreach (KeyValuePair<XVar, dynamic> value in realValues.GetEnumerator())
			{
				result.InitAndSetArrayItem(value.Value, value.Key);
			}
			return result;
		}
		public static XVar getJSONResult(dynamic _param_error)
		{
			#region pass-by-value parameters
			dynamic var_error = XVar.Clone(_param_error);
			#endregion

			dynamic result = XVar.Array();
			result.InitAndSetArrayItem(var_error == XVar.Pack(""), "success");
			result.InitAndSetArrayItem(var_error, "error");
			MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(result)));
			return null;
		}
	}
}
