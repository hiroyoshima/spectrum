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
		public XVar save_state()
		{
			try
			{
				dynamic arr = XVar.Array(), is_crosstable = null, parameterCount = null, root = XVar.Array(), save_name = null, str_xml = null, xml = null;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(MVCFunctions.POSTKeyExists("str_xml")))
				{
					arr = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("str_xml")))));
					if(XVar.Pack(arr["table_type"]))
					{
						XSession.Session.InitAndSetArrayItem(arr["table_type"], "webobject", "table_type");
					}
				}
				xml = XVar.Clone(new xml());
				if(XVar.Pack(MVCFunctions.POSTKeyExists("save")))
				{
					save_name = XVar.Clone(XSession.Session["webobject"]["name"]);
				}
				if(XVar.Pack(MVCFunctions.postvalue("web")))
				{
					root = XSession.Session[MVCFunctions.postvalue("web")];
				}
				if((XVar)((XVar)(MVCFunctions.POSTKeyExists("str_xml"))  && (XVar)(MVCFunctions.POSTKeyExists("web")))  && (XVar)(!(XVar)(MVCFunctions.POSTKeyExists("save"))))
				{
					dynamic rt = null, ttype = null;
					arr = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("str_xml")))))));
					parameterCount = XVar.Clone((XVar.Pack(arr["parameters"]) ? XVar.Pack(MVCFunctions.count(arr["parameters"])) : XVar.Pack(0)));
					if((XVar)((XVar)(parameterCount < 2)  && (XVar)(MVCFunctions.postvalue("web") == "webcharts"))  && (XVar)(MVCFunctions.postvalue("name") == "parameters"))
					{
						MVCFunctions.Echo("You must select at least one series");
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					root = XSession.Session[MVCFunctions.postvalue("web")];
					if(MVCFunctions.postvalue("web") == "webreports")
					{
						Check_Crosstable_Group((XVar)(arr), (XVar)(MVCFunctions.POSTKeyExists("save")));
						is_crosstable = XVar.Clone(root["group_fields"][CommonFunctions.pre8count((XVar)(root["group_fields"])) - 1]["cross_table"]);
						Check_Crosstable_Totals((XVar)(arr), (XVar)(is_crosstable));
					}
					rt = XVar.Clone(root["tables"][0]);
					ttype = XVar.Clone(root["table_type"]);
					foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
					{
						root.InitAndSetArrayItem(val.Value, val.Key);
					}
					if(XVar.Pack(CommonFunctions.is_wr_project()))
					{
						Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(root["tables"][0])), ""),
							"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
					}
					if(MVCFunctions.postvalue("web") == "webcharts")
					{
						if((XVar)(!(XVar)(CommonFunctions.is_wr_project()))  && (XVar)((XVar)(arr.KeyExists("table_relations"))  || (XVar)(arr.KeyExists("group_by_condition"))))
						{
							update_chart_group_by_condition();
							update_chart_parameters();
						}
					}
					if(MVCFunctions.postvalue("web") == "webreports")
					{
						if((XVar)(!(XVar)(CommonFunctions.is_wr_project()))  && (XVar)(arr.KeyExists("table_relations")))
						{
							update_report_group_fields();
							CommonFunctions.update_report_totals();
							update_report_sort_fields();
							Check_Crosstable_Group((XVar)(arr), (XVar)(MVCFunctions.POSTKeyExists("save")));
						}
						if((XVar)(arr.KeyExists("group_fields"))  || (XVar)(arr.KeyExists("sort_fields")))
						{
							update_report_sort_fields();
						}
					}
					if(XVar.Pack(arr.KeyExists("tables")))
					{
						if(XVar.Pack(CommonFunctions.is_wr_custom()))
						{
							dynamic qResult = null, rs = null, sqlcontent = null;
							arr = XVar.Clone(CommonFunctions.getCustomSQLbyName((XVar)(root["tables"][0])));
							sqlcontent = XVar.Clone(arr[2]);
							GlobalVars.conn = XVar.Clone(GlobalVars.cman.getForWebReports());
							qResult = XVar.Clone(GlobalVars.conn.query((XVar)(sqlcontent)));
							rs = XVar.Clone(qResult.fetchAssoc());
							if(XVar.Pack(!(XVar)(rs)))
							{
								dynamic errstr = null;
								MVCFunctions.Echo(errstr);
								MVCFunctions.Echo(new XVar(""));
								return MVCFunctions.GetBuferContentAndClearBufer();
							}
							else
							{
								XSession.Session["customSQL"] = sqlcontent;
								XSession.Session["idSQL"] = arr[0];
								XSession.Session["nameSQL"] = arr[1];
								XSession.Session["object_sql"] = sqlcontent;
							}
						}
						if(XVar.Pack(!(XVar)(root.KeyExists("settings"))))
						{
							if(MVCFunctions.postvalue("web") == "webreports")
							{
								comlete_report_session_default_values();
								save_sql(new XVar("webreports"));
								str_xml = XVar.Clone(xml.array_to_xml((XVar)(root)));
								CommonFunctions.wrSaveEntity(new XVar(Constants.WR_REPORT), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["title"]), (XVar)(root["settings"]["status"]), (XVar)(str_xml), new XVar(false));
							}
							else
							{
								if(MVCFunctions.postvalue("web") == "webcharts")
								{
									comlete_chart_session_default_values();
									save_sql(new XVar("webcharts"));
									str_xml = XVar.Clone(xml.array_to_xml((XVar)(root)));
									CommonFunctions.wrSaveEntity(new XVar(Constants.WR_CHART), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["title"]), (XVar)(root["settings"]["status"]), (XVar)(str_xml), new XVar(false));
								}
							}
						}
						else
						{
							if((XVar)(root["tables"][0] != rt)  || (XVar)(root["table_type"] != ttype))
							{
								if(MVCFunctions.postvalue("web") == "webreports")
								{
									root.Remove("totals");
									root.Remove("group_fields");
									root.Remove("sort_fields");
									root.Remove("table_relations");
									root.Remove("where_condition");
									comlete_report_session_default_values(new XVar(true));
									save_sql(new XVar("webreports"));
								}
								else
								{
									if(MVCFunctions.postvalue("web") == "webcharts")
									{
										root.Remove("table_relations");
										root.Remove("group_by");
										root.Remove("parameters");
										root.Remove("appearance");
										root.Remove("type");
										comlete_chart_session_default_values(new XVar(true));
										save_sql(new XVar("webcharts"));
									}
								}
							}
						}
					}
					else
					{
						if(MVCFunctions.postvalue("web") == "webreports")
						{
							save_sql(new XVar("webreports"));
						}
						if(MVCFunctions.postvalue("web") == "webcharts")
						{
							save_sql(new XVar("webcharts"));
						}
					}
					MVCFunctions.Echo("OK");
				}
				else
				{
					if((XVar)((XVar)(MVCFunctions.POSTKeyExists("str_xml"))  && (XVar)(MVCFunctions.POSTKeyExists("web")))  && (XVar)(MVCFunctions.POSTKeyExists("save")))
					{
						dynamic saveas = null;
						arr = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("str_xml")))))));
						parameterCount = XVar.Clone((XVar.Pack(arr["parameters"]) ? XVar.Pack(MVCFunctions.count(arr["parameters"])) : XVar.Pack(0)));
						if((XVar)((XVar)(parameterCount < 2)  && (XVar)(MVCFunctions.postvalue("web") == "webcharts"))  && (XVar)(MVCFunctions.postvalue("name") == "parameters"))
						{
							MVCFunctions.Echo("You must select at least one series");
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
						if(MVCFunctions.postvalue("web") == "webreports")
						{
							Check_Crosstable_Group((XVar)(arr), (XVar)(MVCFunctions.POSTKeyExists("save")));
							is_crosstable = XVar.Clone(root["group_fields"][CommonFunctions.pre8count((XVar)(root["group_fields"])) - 1]["cross_table"]);
							Check_Crosstable_Totals((XVar)(arr), (XVar)(is_crosstable));
						}
						saveas = new XVar(false);
						if(XVar.Pack(MVCFunctions.POSTKeyExists("saveas")))
						{
							saveas = new XVar(true);
						}
						foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
						{
							root.InitAndSetArrayItem(val.Value, val.Key);
						}
						if(XVar.Pack(CommonFunctions.is_wr_project()))
						{
							Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(root["tables"][0])), ""),
								"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
						}
						if(MVCFunctions.postvalue("web") == "webreports")
						{
							root.InitAndSetArrayItem(Security.getUserName(), "owner");
							root.InitAndSetArrayItem(root["tables"][0], "table_name");
							root.InitAndSetArrayItem(CommonFunctions.GetTableURL((XVar)(root["tables"][0])), "short_table_name");
							if(MVCFunctions.postvalue("save") == 1)
							{
								XSession.Session.InitAndSetArrayItem("", "webreports", "tmp_active");
							}
							if((XVar)(!(XVar)(CommonFunctions.is_wr_project()))  && (XVar)(arr.KeyExists("table_relations")))
							{
								update_report_group_fields();
								CommonFunctions.update_report_totals();
								update_report_sort_fields();
								Check_Crosstable_Group((XVar)(arr), (XVar)(MVCFunctions.POSTKeyExists("save")));
							}
							if((XVar)(arr.KeyExists("group_fields"))  || (XVar)(arr.KeyExists("sort_fields")))
							{
								update_report_sort_fields();
							}
							save_sql(new XVar("webreports"));
							str_xml = XVar.Clone(xml.array_to_xml((XVar)(root)));
							CommonFunctions.wrSaveEntity(new XVar(Constants.WR_REPORT), (XVar)(save_name), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["title"]), (XVar)(root["settings"]["status"]), (XVar)(str_xml), (XVar)(saveas));
						}
						else
						{
							if(MVCFunctions.postvalue("web") == "webcharts")
							{
								root.InitAndSetArrayItem(Security.getUserName(), "settings", "owner");
								root.InitAndSetArrayItem(root["tables"][0], "settings", "table_name");
								root.InitAndSetArrayItem(CommonFunctions.GetTableURL((XVar)(root["tables"][0])), "settings", "short_table_name");
								if(MVCFunctions.postvalue("save") == 1)
								{
									XSession.Session.InitAndSetArrayItem("", "webcharts", "tmp_active");
								}
								if((XVar)(!(XVar)(CommonFunctions.is_wr_project()))  && (XVar)((XVar)(arr.KeyExists("table_relations"))  || (XVar)(arr.KeyExists("group_by_condition"))))
								{
									update_chart_group_by_condition();
									update_chart_parameters();
								}
								save_sql(new XVar("webcharts"));
								str_xml = XVar.Clone(xml.array_to_xml((XVar)(root)));
								CommonFunctions.wrSaveEntity(new XVar(Constants.WR_CHART), (XVar)(save_name), (XVar)(root["settings"]["name"]), (XVar)(root["settings"]["title"]), (XVar)(root["settings"]["status"]), (XVar)(str_xml), (XVar)(saveas));
							}
						}
						MVCFunctions.Echo("OK");
					}
					else
					{
						if(XVar.Pack(MVCFunctions.POSTKeyExists("del")))
						{
							dynamic ename = null;
							ename = XVar.Clone(MVCFunctions.postvalue(new XVar("name")));
							if(1 < CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())))
							{
								dynamic entity = null, permissions = XVar.Array(), rpt = XVar.Array();
								rpt = XVar.Clone(CommonFunctions.wrGetEntityRecord((XVar)(ename), (XVar)((XVar.Pack(MVCFunctions.postvalue("web") == "webreports") ? XVar.Pack(Constants.WR_REPORT) : XVar.Pack(Constants.WR_CHART)))));
								entity = XVar.Clone(CommonFunctions.wrGetContent((XVar)(rpt["rpt_content"])));
								permissions = XVar.Clone(CommonFunctions.wrGetEntityPermissions((XVar)(entity)));
								if((XVar)((XVar)(rpt["rpt_owner"] != Security.getUserName())  || (XVar)(rpt["rpt_owner"] == ""))  || (XVar)(permissions["view"] == 0))
								{
									if(MVCFunctions.postvalue("web") == "webreports")
									{
										MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to delete this report", "</p>"));
									}
									else
									{
										MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to delete this chart", "</p>"));
									}
									MVCFunctions.Echo(new XVar(""));
									return MVCFunctions.GetBuferContentAndClearBufer();
								}
							}
							CommonFunctions.wrDeleteEntity((XVar)(ename), (XVar)((XVar.Pack(MVCFunctions.postvalue("web") == "webreports") ? XVar.Pack(Constants.WR_REPORT) : XVar.Pack(Constants.WR_CHART))));
							MVCFunctions.Echo("OK");
						}
					}
				}
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
		public static XVar comlete_report_session_default_values(dynamic _param_isedit = null)
		{
			#region default values
			if(_param_isedit as Object == null) _param_isedit = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic isedit = XVar.Clone(_param_isedit);
			#endregion

			dynamic arr_fields = XVar.Array(), arr_fields_all = XVar.Array(), garrSummary = XVar.Array(), garrfield = null, gfield = null, root = XVar.Array(), table = null;
			ProjectSettings pSet;
			root = XSession.Session["webreports"];
			table = XVar.Clone(root["tables"][0]);
			arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(table)));
			arr_fields_all = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
			gfield = XVar.Clone(arr_fields[0]);
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				gfield = XVar.Clone(MVCFunctions.Concat(table, ".", arr_fields[0]));
			}
			garrfield = XVar.Clone(new XVar("name", gfield, "int_type", "0", "ss", "true", "group_order", "1", "color1", "FF0000", "color2", "CC0000"));
			garrSummary = XVar.Clone(XVar.Array());
			garrSummary.InitAndSetArrayItem("Summary", "name");
			garrSummary.InitAndSetArrayItem("false", "crosstable");
			garrSummary.InitAndSetArrayItem("true", "sps");
			garrSummary.InitAndSetArrayItem("true", "sds");
			garrSummary.InitAndSetArrayItem("true", "sgs");
			garrSummary.InitAndSetArrayItem("true", "sum_x");
			garrSummary.InitAndSetArrayItem("true", "sum_y");
			garrSummary.InitAndSetArrayItem("true", "sum_total");
			root.InitAndSetArrayItem(new XVar(0, garrfield, 1, garrSummary), "group_fields");
			root.InitAndSetArrayItem(XVar.Array(), "totals");
			pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table)));
			foreach (KeyValuePair<XVar, dynamic> fld in arr_fields_all.GetEnumerator())
			{
				root.InitAndSetArrayItem(XVar.Array(), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))));
				root.InitAndSetArrayItem(fld.Value, "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "name");
				root.InitAndSetArrayItem(table, "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "table");
				root.InitAndSetArrayItem(pSet.label((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "label");
				root.InitAndSetArrayItem("true", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "show");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "min");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "max");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "sum");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "avg");
				root.InitAndSetArrayItem("false", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "curr");
				root.InitAndSetArrayItem("", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "search");
				root.InitAndSetArrayItem(CommonFunctions.GetGenericViewFormat((XVar)(table), (XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "view_format");
				root.InitAndSetArrayItem(CommonFunctions.GetGenericEditFormat((XVar)(table), (XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "edit_format");
				root.InitAndSetArrayItem(pSet.getDisplayField((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "display_field");
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					root.InitAndSetArrayItem(pSet.getLinkField((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "linkfield");
				}
				else
				{
					root.InitAndSetArrayItem("", "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "linkfield");
				}
				root.InitAndSetArrayItem(pSet.showThumbnail((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "show_thumbnail");
				root.InitAndSetArrayItem(pSet.NeedEncode((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "need_encode");
				root.InitAndSetArrayItem(pSet.getStrThumbnail((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "thumbnail");
				root.InitAndSetArrayItem(pSet.getImageWidth((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "listformatobj_imgwidth");
				root.InitAndSetArrayItem(pSet.getImageHeight((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "listformatobj_imgheight");
				root.InitAndSetArrayItem(pSet.getLinkPrefix((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "hlprefix");
				root.InitAndSetArrayItem(pSet.getFilenameField((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "listformatobj_filename");
				root.InitAndSetArrayItem(pSet.getLookupType((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "lookupobj_lookuptype");
				root.InitAndSetArrayItem(pSet.getDisplayField((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "editformatobj_lookupobj_customdispaly");
				root.InitAndSetArrayItem(pSet.getLookupTable((XVar)(fld.Value)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "editformatobj_lookupobj_table");
				root.InitAndSetArrayItem(CommonFunctions.prepareLookupWhere((XVar)(fld.Value), (XVar)(pSet)), "totals", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(table, ".", fld.Value))), "editformatobj_lookupobj_where");
			}
			root.InitAndSetArrayItem(new XVar(0, new XVar("name", gfield, "desc", "false")), "sort_fields");
			if(XVar.Pack(!(XVar)(isedit)))
			{
				root.InitAndSetArrayItem(new XVar("type", "stepped", "print_friendly", "true", "lines_num", "30"), "miscellaneous");
				root.InitAndSetArrayItem(new XVar("name", MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(root["tables"][0])), "_", CommonFunctions.CheckLastID(new XVar(Constants.WR_REPORT))), "title", MVCFunctions.Concat(root["tables"][0], " Report ", CommonFunctions.CheckLastID(new XVar(Constants.WR_REPORT))), "status", "private"), "settings");
				XSession.Session.InitAndSetArrayItem(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(root["tables"][0])), "_", CommonFunctions.CheckLastID(new XVar(Constants.WR_REPORT))), "webobject", "name");
				root.InitAndSetArrayItem(Security.getUserName(), "owner");
				XSession.Session.InitAndSetArrayItem("x", "webreports", "tmp_active");
			}
			root.InitAndSetArrayItem(root["tables"][0], "table_name");
			root.InitAndSetArrayItem(CommonFunctions.GetTableURL((XVar)(root["tables"][0])), "short_table_name");
			return null;
		}
		public static XVar comlete_chart_session_default_values(dynamic _param_isedit = null)
		{
			#region default values
			if(_param_isedit as Object == null) _param_isedit = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic isedit = XVar.Clone(_param_isedit);
			#endregion

			dynamic arr_data_series = XVar.Array(), arr_fields = XVar.Array(), arr_fields_all = XVar.Array(), arr_label_series = XVar.Array(), datafield = XVar.Array(), labelfield = XVar.Array(), root = XVar.Array(), table = null, tfield = null, ttable = null;
			root = XSession.Session["webcharts"];
			table = XVar.Clone(root["tables"][0]);
			arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(table)));
			arr_fields_all = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
			root.InitAndSetArrayItem(new XVar("type", "2d_column"), "chart_type");
			arr_data_series = XVar.Clone(XVar.Array());
			arr_label_series = XVar.Clone(XVar.Array());
			CommonFunctions.get_chart_series_fields(ref arr_data_series, ref arr_label_series);
			datafield = XVar.Clone(new XVar("field", arr_fields[0], "label", CommonFunctions.WRChartLabel((XVar)(arr_fields[0]))));
			labelfield = XVar.Clone(datafield);
			if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_label_series))))
			{
				labelfield = XVar.Clone(arr_label_series[0]);
				ttable = new XVar("");
				tfield = new XVar("");
				CommonFunctions.WRSplitFieldName((XVar)(labelfield["field"]), ref ttable, ref tfield);
				labelfield.InitAndSetArrayItem(tfield, "field");
			}
			if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_data_series))))
			{
				datafield = XVar.Clone(arr_data_series[0]);
				ttable = new XVar("");
				tfield = new XVar("");
				CommonFunctions.WRSplitFieldName((XVar)(datafield["field"]), ref ttable, ref tfield);
				datafield.InitAndSetArrayItem(tfield, "field");
			}
			root.InitAndSetArrayItem(new XVar(0, new XVar("name", datafield["field"], "ohlcOpen", datafield["field"], "ohlcClose", datafield["field"], "ohlcHigh", datafield["field"], "ohlcLow", datafield["field"], "table", table, "agr_func", "", "label", datafield["label"]), 1, new XVar("name", labelfield["field"], "table", table, "agr_func", "", "label", "undefined")), "parameters");
			root.InitAndSetArrayItem(XVar.Array(), "fields");
			foreach (KeyValuePair<XVar, dynamic> fld in arr_fields_all.GetEnumerator())
			{
				root.InitAndSetArrayItem(new XVar("name", fld.Value, "label", CommonFunctions.WRChartLabel((XVar)(fld.Value)), "search", ""), "fields", null);
			}
			root.InitAndSetArrayItem(XVar.Array(), "appearance");
			root.InitAndSetArrayItem("FF0000", "appearance", "series_color");
			root.InitAndSetArrayItem("", "appearance", "color51");
			root.InitAndSetArrayItem("", "appearance", "color52");
			root.InitAndSetArrayItem("", "appearance", "color61");
			root.InitAndSetArrayItem("", "appearance", "color62");
			root.InitAndSetArrayItem("", "appearance", "color71");
			root.InitAndSetArrayItem("", "appearance", "color72");
			root.InitAndSetArrayItem("", "appearance", "color81");
			root.InitAndSetArrayItem("", "appearance", "color82");
			root.InitAndSetArrayItem("", "appearance", "color91");
			root.InitAndSetArrayItem("", "appearance", "color92");
			root.InitAndSetArrayItem("", "appearance", "color101");
			root.InitAndSetArrayItem("", "appearance", "color102");
			root.InitAndSetArrayItem("", "appearance", "color111");
			root.InitAndSetArrayItem("", "appearance", "color112");
			root.InitAndSetArrayItem("", "appearance", "color121");
			root.InitAndSetArrayItem("", "appearance", "color122");
			root.InitAndSetArrayItem("", "appearance", "color131");
			root.InitAndSetArrayItem("", "appearance", "color132");
			root.InitAndSetArrayItem("", "appearance", "color141");
			root.InitAndSetArrayItem("", "appearance", "color142");
			root.InitAndSetArrayItem("true", "appearance", "slegend");
			root.InitAndSetArrayItem("true", "appearance", "sgrid");
			root.InitAndSetArrayItem("true", "appearance", "sname");
			root.InitAndSetArrayItem("true", "appearance", "sval");
			root.InitAndSetArrayItem("true", "appearance", "sanim");
			root.InitAndSetArrayItem("false", "appearance", "scur");
			root.InitAndSetArrayItem("false", "appearance", "sstacked");
			root.InitAndSetArrayItem("false", "appearance", "saxes");
			root.InitAndSetArrayItem("false", "appearance", "slog");
			root.InitAndSetArrayItem("2", "appearance", "dec");
			root.InitAndSetArrayItem(MVCFunctions.Concat(root["tables"][0], " Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))), "appearance", "head");
			root.InitAndSetArrayItem(MVCFunctions.Concat(root["tables"][0], " Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))), "appearance", "foot");
			root.InitAndSetArrayItem("0", "appearance", "aqua");
			root.InitAndSetArrayItem("0", "appearance", "cview");
			root.InitAndSetArrayItem("false", "appearance", "is3d");
			root.InitAndSetArrayItem("false", "appearance", "isstacked");
			root.InitAndSetArrayItem("true", "appearance", "cscroll");
			root.InitAndSetArrayItem("false", "appearance", "autoupdate");
			root.InitAndSetArrayItem("10", "appearance", "maxbarscroll");
			root.InitAndSetArrayItem("5", "appearance", "update_interval");
			root.InitAndSetArrayItem("0", "appearance", "accumulstyle");
			root.InitAndSetArrayItem("false", "appearance", "accumulinvert");
			root.InitAndSetArrayItem("0", "appearance", "linestyle");
			root.InitAndSetArrayItem("0", "appearance", "gaugestyle");
			if(XVar.Pack(!(XVar)(isedit)))
			{
				root.InitAndSetArrayItem(new XVar("name", MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(root["tables"][0])), "_", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))), "title", MVCFunctions.Concat(root["tables"][0], " Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))), "status", "private", "owner", Security.getUserName(), "table_name", root["tables"][0], "short_table_name", CommonFunctions.GetTableURL((XVar)(root["tables"][0]))), "settings");
				XSession.Session.InitAndSetArrayItem(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(root["tables"][0])), "_", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))), "webobject", "name");
				root.InitAndSetArrayItem(Security.getUserName(), "owner");
				XSession.Session.InitAndSetArrayItem("x", "webcharts", "tmp_active");
			}
			else
			{
				root.InitAndSetArrayItem(new XVar("name", XSession.Session["webcharts"]["settings"]["name"], "title", XSession.Session["webcharts"]["settings"]["title"], "status", XSession.Session["webcharts"]["settings"]["status"], "owner", XSession.Session["webcharts"]["settings"]["owner"], "table_name", root["tables"][0], "short_table_name", CommonFunctions.GetTableURL((XVar)(root["tables"][0]))), "settings");
			}
			root.InitAndSetArrayItem(root["tables"][0], "table_name");
			root.InitAndSetArrayItem(CommonFunctions.GetTableURL((XVar)(root["tables"][0])), "short_table_name");
			return null;
		}
		public static XVar save_sql(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic _connection = null, arr = XVar.Array(), arr_fields = XVar.Array(), arr_fields_all = XVar.Array(), arr_fields_nb = XVar.Array(), arr_join_tables = XVar.Array(), arr_label = XVar.Array(), customLabels = XVar.Array(), f = null, fld = XVar.Array(), fld_name = null, i = null, j = null, numfield = null, root = XVar.Array(), sql_group_by = null, sql_order_by = null, sql_order_by_preview = null, sql_query = null, sql_query_preview = null, sql_where = null, t = null, table_name = null;
			sql_query = new XVar("");
			sql_where = new XVar("");
			sql_order_by = new XVar("");
			sql_order_by_preview = new XVar("");
			sql_group_by = new XVar("");
			root = XSession.Session[var_type];
			customLabels = XVar.Clone(XVar.Array());
			_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				_connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(root["tables"][0])));
			}
			switch(((XVar)var_type).ToString())
			{
				case "webreports":
					if(XVar.Pack(!(XVar)(root["sort_fields"].IsEmpty())))
					{
						sql_order_by = MVCFunctions.Concat(sql_order_by, " \nORDER BY ");
						foreach (KeyValuePair<XVar, dynamic> _arr in root["sort_fields"].GetEnumerator())
						{
							if(XVar.Pack(CommonFunctions.is_wr_project()))
							{
								sql_order_by = MVCFunctions.Concat(sql_order_by, _connection.addFieldWrappers((XVar)(_arr.Value["name"])));
							}
							else
							{
								dynamic field = null, table = null;
								table = new XVar("");
								field = new XVar("");
								CommonFunctions.WRSplitFieldName((XVar)(_arr.Value["name"]), ref table, ref field);
								if(XVar.Pack(table))
								{
									sql_order_by = MVCFunctions.Concat(sql_order_by, _connection.addTableWrappers((XVar)(table)), ".", _connection.addFieldWrappers((XVar)(field)));
								}
								else
								{
									sql_order_by = MVCFunctions.Concat(sql_order_by, _connection.addFieldWrappers((XVar)(field)));
								}
							}
							sql_order_by = MVCFunctions.Concat(sql_order_by, (XVar.Pack(_arr.Value["desc"] == "true") ? XVar.Pack(" DESC, ") : XVar.Pack(" ASC, ")));
						}
						sql_order_by = XVar.Clone(MVCFunctions.substr((XVar)(sql_order_by), new XVar(0), new XVar(-2)));
					}
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						arr = XVar.Clone(CommonFunctions.getCustomSQLbyName((XVar)(root["tables"][0])));
						sql_query = XVar.Clone(arr[2]);
						sql_query_preview = XVar.Clone(arr[2]);
						sql_where = new XVar("");
						sql_group_by = new XVar("");
						break;
					}
					arr_fields_all = XVar.Clone(XVar.Array());
					if(XVar.Pack(!(XVar)(root["totals"].IsEmpty())))
					{
						dynamic fldnum = null;
						fldnum = new XVar(1);
						foreach (KeyValuePair<XVar, dynamic> _fld in root["totals"].GetEnumerator())
						{
							if(_fld.Value["show"] == "true")
							{
								dynamic alias = null;
								alias = XVar.Clone(MVCFunctions.Concat(" as ", _connection.addFieldWrappers((XVar)(MVCFunctions.Concat("f", fldnum)))));
								arr_fields_all.InitAndSetArrayItem(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_fld.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_fld.Value["name"])), alias), null);
								if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(_fld.Value["table"], ".", _fld.Value["name"]))))))))
								{
									arr_fields_nb.InitAndSetArrayItem(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_fld.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_fld.Value["name"])), alias), null);
								}
							}
							fldnum++;
						}
					}
					else
					{
						table_name = XVar.Clone(root["tables"][0]);
						arr_fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table_name)));
						j = new XVar(0);
						for(;j < CommonFunctions.pre8count((XVar)(arr_fields)); j++)
						{
							arr_fields_all.InitAndSetArrayItem(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(arr_fields[j]))), null);
							if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table_name, ".", arr_fields[j]))))))))
							{
								arr_fields_nb.InitAndSetArrayItem(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(arr_fields[j]))), null);
							}
						}
					}
					sql_query = new XVar("");
					sql_query = MVCFunctions.Concat(sql_query, " \n", make_from_clause((XVar)(var_type)));
					sql_query_preview = XVar.Clone(MVCFunctions.Concat("SELECT\n", MVCFunctions.implode(new XVar(", \n"), (XVar)(arr_fields_nb)), sql_query));
					sql_query = XVar.Clone(MVCFunctions.Concat("SELECT\n", MVCFunctions.implode(new XVar(", \n"), (XVar)(arr_fields_all)), sql_query));
					if(XVar.Pack(!(XVar)(root["where_condition"].IsEmpty())))
					{
						sql_where = MVCFunctions.Concat(sql_where, " \nWHERE ");
						foreach (KeyValuePair<XVar, dynamic> _arr in root["where_condition"].GetEnumerator())
						{
							CommonFunctions.WRSplitFieldName((XVar)(_arr.Value["field_opt"]), ref t, ref f);
							fld_name = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(t)), ".", _connection.addFieldWrappers((XVar)(f))));
							sql_where = MVCFunctions.Concat(sql_where, "( ", fld_name, _arr.Value["filter_value"]);
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(_arr.Value["first_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, _arr.Value["first_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(_arr.Value["second_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, _arr.Value["second_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(_arr.Value["third_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, _arr.Value["third_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, " ) AND ");
						}
						sql_where = XVar.Clone(MVCFunctions.substr((XVar)(sql_where), new XVar(0), new XVar(-5)));
					}
					break;
				case "webcharts":
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						arr = XVar.Clone(CommonFunctions.getCustomSQLbyName((XVar)(root["tables"][0])));
						sql_query = XVar.Clone(arr[2]);
						sql_query_preview = XVar.Clone(arr[2]);
						sql_where = new XVar("");
						sql_order_by = new XVar("");
						sql_order_by_preview = new XVar("");
						sql_group_by = new XVar("");
						break;
					}
					table_name = XVar.Clone(root["tables"][0]);
					arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
					numfield = new XVar(1);
					arr_label = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
					{
						dynamic arr_fields_join = XVar.Array();
						arr_fields_join = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(_tbl.Value)));
						j = new XVar(0);
						for(;j < CommonFunctions.pre8count((XVar)(arr_fields_join)); j++)
						{
							arr_fields.InitAndSetArrayItem(arr_fields_join[j], null);
							arr_fields_all.InitAndSetArrayItem(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_tbl.Value)), ".", _connection.addFieldWrappers((XVar)(arr_fields_join[j]))), null);
							arr_label.InitAndSetArrayItem(MVCFunctions.Concat("f", numfield), MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_tbl.Value)), ".", _connection.addFieldWrappers((XVar)(arr_fields_join[j]))));
							customLabels.InitAndSetArrayItem(MVCFunctions.Concat("f", numfield), MVCFunctions.Concat(_tbl.Value, "_", arr_fields_join[j]));
							numfield++;
						}
					}
					sql_query = new XVar("SELECT\n");
					sql_query_preview = new XVar("SELECT\n");
					if(XVar.Pack(!(XVar)(root["parameters"].IsEmpty())))
					{
						if(XVar.Pack(CommonFunctions.is_groupby_chart()))
						{
							dynamic tfield = null, ttable = null;
							foreach (KeyValuePair<XVar, dynamic> _arr in root["parameters"].GetEnumerator())
							{
								if(_arr.Value["name"] == "")
								{
									continue;
								}
								fld = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_arr.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_arr.Value["name"]))));
								if(_arr.Value["agr_func"] != "")
								{
									fld = XVar.Clone(MVCFunctions.Concat(_arr.Value["agr_func"], "(", fld, ")"));
									if((XVar)(_arr.Key < CommonFunctions.pre8count((XVar)(arr_fields)) - 1)  && (XVar)(_arr.Value["label"]))
									{
										fld = MVCFunctions.Concat(fld, " AS ", _connection.addFieldWrappers((XVar)(arr_label[MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_arr.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_arr.Value["name"])))])));
									}
									else
									{
										if(_arr.Value["agr_func"] != "GROUP BY")
										{
											fld = MVCFunctions.Concat(fld, " AS ", _connection.addFieldWrappers((XVar)(arr_label[MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_arr.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_arr.Value["name"])))])));
										}
									}
								}
								else
								{
									fld = MVCFunctions.Concat(fld, " AS ", _connection.addFieldWrappers((XVar)(arr_label[MVCFunctions.Concat(_connection.addTableWrappers((XVar)(_arr.Value["table"])), ".", _connection.addFieldWrappers((XVar)(_arr.Value["name"])))])));
								}
								sql_query = MVCFunctions.Concat(sql_query, fld, ", \n");
							}
							i = new XVar(0);
							for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
							{
								arr = XVar.Clone(root["group_by_condition"][i]);
								if((XVar)(arr["field_opt"] == "")  || (XVar)(arr["group_by_value"] == -1))
								{
									continue;
								}
								ttable = new XVar("");
								tfield = new XVar("");
								CommonFunctions.WRSplitFieldName((XVar)(arr["field_opt"]), ref ttable, ref tfield);
								fld = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(ttable)), ".", _connection.addFieldWrappers((XVar)(tfield))));
								if((XVar)(arr["group_by_value"] != -1)  && (XVar)(arr["group_by_value"] != "GROUP BY"))
								{
									fld = XVar.Clone(MVCFunctions.Concat(arr["group_by_value"], "(", fld, ")", " AS ", _connection.addFieldWrappers((XVar)(MVCFunctions.Concat(arr["group_by_value"], "_", arr_label[fld])))));
								}
								else
								{
									if(arr["group_by_value"] == "GROUP BY")
									{
										fld = MVCFunctions.Concat(fld, " AS ", _connection.addFieldWrappers((XVar)(arr_label[arr_fields_all[i]])));
									}
								}
								sql_query_preview = MVCFunctions.Concat(sql_query_preview, fld, ", \n");
							}
						}
						else
						{
							j = new XVar(0);
							for(;j < CommonFunctions.pre8count((XVar)(arr_fields_all)); j++)
							{
								if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(CommonFunctions.WRGetFieldType((XVar)(arr_fields_all[j])))))))
								{
									sql_query = MVCFunctions.Concat(sql_query, arr_fields_all[j], " AS ", _connection.addFieldWrappers((XVar)(arr_label[arr_fields_all[j]])), ", \n");
									sql_query_preview = MVCFunctions.Concat(sql_query_preview, arr_fields_all[j], " AS ", _connection.addFieldWrappers((XVar)(arr_label[arr_fields_all[j]])), ", \n");
								}
							}
						}
						sql_query = XVar.Clone(MVCFunctions.substr((XVar)(sql_query), new XVar(0), new XVar(-3)));
						sql_query_preview = XVar.Clone(MVCFunctions.substr((XVar)(sql_query_preview), new XVar(0), new XVar(-3)));
					}
					sql_query = MVCFunctions.Concat(sql_query, " \n", make_from_clause((XVar)(var_type)));
					sql_query_preview = MVCFunctions.Concat(sql_query_preview, " \n", make_from_clause((XVar)(var_type)));
					sql_where = new XVar("");
					if(XVar.Pack(!(XVar)(root["group_by_condition"][0].IsEmpty())))
					{
						dynamic arr_order = XVar.Array(), field_name = null, fld_name_preview = null, group_by_clause = null, having_clause = null;
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
						{
							arr = XVar.Clone(root["group_by_condition"][i]);
							fld = XVar.Clone(new XVar(0, "", 1, ""));
							CommonFunctions.WRSplitFieldName((XVar)(arr["field_opt"]), ref t, ref f);
							fld_name = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(t)), ".", _connection.addFieldWrappers((XVar)(f))));
							if(arr["filter_value"] == "")
							{
								continue;
							}
							if(XVar.Pack(MVCFunctions.strlen((XVar)(sql_where))))
							{
								sql_where = MVCFunctions.Concat(sql_where, " AND ");
							}
							sql_where = MVCFunctions.Concat(sql_where, "(", fld_name, arr["filter_value"]);
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(arr["first_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, arr["first_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(arr["second_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, arr["second_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, (XVar.Pack(arr["third_or_value"] == "") ? XVar.Pack("") : XVar.Pack(MVCFunctions.Concat(" OR ", fld_name, arr["third_or_value"]))));
							sql_where = MVCFunctions.Concat(sql_where, ")");
						}
						if(XVar.Pack(MVCFunctions.strlen((XVar)(sql_where))))
						{
							sql_where = XVar.Clone(MVCFunctions.Concat(" WHERE ", sql_where));
						}
						group_by_clause = new XVar("");
						having_clause = new XVar("");
						if(XVar.Pack(CommonFunctions.is_groupby_chart()))
						{
							i = new XVar(0);
							for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
							{
								arr = XVar.Clone(root["group_by_condition"][i]);
								table_name = new XVar("");
								field_name = new XVar("");
								CommonFunctions.WRSplitFieldName((XVar)(arr["field_opt"]), ref table_name, ref field_name);
								fld_name = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(field_name))));
								if(arr["group_by_value"] != "-1")
								{
									if(arr["group_by_value"] == "GROUP BY")
									{
										group_by_clause = MVCFunctions.Concat(group_by_clause, fld_name, ", ");
									}
									if(XVar.Pack(!(XVar)(arr["having_value"].IsEmpty())))
									{
										if((XVar)(arr["group_by_value"] != "GROUP BY")  && (XVar)(arr["group_by_value"] != "-1"))
										{
											fld_name = XVar.Clone(MVCFunctions.Concat(arr["group_by_value"], "(", fld_name, ")"));
										}
										having_clause = MVCFunctions.Concat(having_clause, fld_name, " ", arr["having_value"], " AND ");
									}
								}
							}
							if(group_by_clause != XVar.Pack(""))
							{
								group_by_clause = XVar.Clone(MVCFunctions.Concat("\nGROUP BY ", MVCFunctions.substr((XVar)(group_by_clause), new XVar(0), new XVar(-2))));
							}
							if(having_clause != XVar.Pack(""))
							{
								having_clause = XVar.Clone(MVCFunctions.Concat("\nHAVING ", MVCFunctions.substr((XVar)(having_clause), new XVar(0), new XVar(-5))));
							}
							sql_group_by = XVar.Clone(MVCFunctions.Concat(group_by_clause, having_clause));
						}
						arr_order = XVar.Clone(XVar.Array());
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
						{
							arr = XVar.Clone(root["group_by_condition"][i]);
							if((XVar)(arr["sort_dir"] == "-1")  || (XVar)((XVar)(CommonFunctions.is_groupby_chart())  && (XVar)(arr["group_by_value"] == -1)))
							{
								continue;
							}
							CommonFunctions.WRSplitFieldName((XVar)(arr["field_opt"]), ref table_name, ref field_name);
							if((XVar)(CommonFunctions.is_groupby_chart())  && (XVar)(arr["group_by_value"] != -1))
							{
								fld_name = XVar.Clone(MVCFunctions.Concat(arr["group_by_value"], "(", _connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(field_name)), ")"));
								fld_name_preview = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(field_name))));
							}
							else
							{
								fld_name_preview = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(field_name))));
								fld_name = XVar.Clone(MVCFunctions.Concat(_connection.addTableWrappers((XVar)(table_name)), ".", _connection.addFieldWrappers((XVar)(field_name))));
							}
							arr_order.InitAndSetArrayItem(new XVar("field", fld_name, "field_preview", fld_name_preview, "dir", arr["sort_dir"]), (int)arr["sort_order"]);
						}
						if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_order))))
						{
							dynamic arr_sortorders = XVar.Array();
							arr_sortorders = XVar.Clone(MVCFunctions.array_keys((XVar)(arr_order)));
							MVCFunctions.sort(ref arr_sortorders);
							foreach (KeyValuePair<XVar, dynamic> _i in arr_sortorders.GetEnumerator())
							{
								if(XVar.Pack(MVCFunctions.strlen((XVar)(sql_order_by_preview))))
								{
									sql_order_by_preview = MVCFunctions.Concat(sql_order_by_preview, ", ");
								}
								if(XVar.Pack(MVCFunctions.strlen((XVar)(sql_order_by))))
								{
									sql_order_by = MVCFunctions.Concat(sql_order_by, ", ");
								}
								sql_order_by_preview = MVCFunctions.Concat(sql_order_by_preview, arr_order[_i.Value]["field_preview"], " ", arr_order[_i.Value]["dir"]);
								sql_order_by = MVCFunctions.Concat(sql_order_by, arr_order[_i.Value]["field"], " ", arr_order[_i.Value]["dir"]);
							}
							sql_order_by_preview = XVar.Clone(MVCFunctions.Concat("\nORDER BY ", sql_order_by_preview));
							sql_order_by = XVar.Clone(MVCFunctions.Concat("\nORDER BY ", sql_order_by));
						}
					}
					break;
				default:
					break;
			}
			XSession.Session.InitAndSetArrayItem(customLabels, var_type, "customLabels");
			XSession.Session.InitAndSetArrayItem(sql_query, var_type, "sql");
			XSession.Session.InitAndSetArrayItem(sql_query_preview, var_type, "sql_preview");
			XSession.Session.InitAndSetArrayItem(sql_where, var_type, "where");
			XSession.Session.InitAndSetArrayItem(sql_order_by, var_type, "order_by");
			XSession.Session.InitAndSetArrayItem(sql_order_by_preview, var_type, "order_by_preview");
			XSession.Session.InitAndSetArrayItem(sql_group_by, var_type, "group_by");
			XSession.Session["object_sql"] = sql_query;
			return null;
		}
		public static XVar update_chart_group_by_condition()
		{
			dynamic arr_join_tables = XVar.Array(), arr_unset = XVar.Array(), group_by_condition = XVar.Array(), groupby_found = null, i = null, keys = XVar.Array(), root = XVar.Array();
			root = XSession.Session["webcharts"];
			arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
			groupby_found = new XVar(false);
			if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(root["group_by_condition"])))))
			{
				root.InitAndSetArrayItem(false, "group_by_toggle");
				return null;
			}
			arr_unset = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> arr in root["group_by_condition"].GetEnumerator())
			{
				dynamic appear = null, field = null, table = null;
				if(XVar.Equals(XVar.Pack(arr.Key), XVar.Pack("group_by_toggle")))
				{
					continue;
				}
				table = new XVar("");
				field = new XVar("");
				CommonFunctions.WRSplitFieldName((XVar)(arr.Value["field_opt"]), ref table, ref field);
				appear = new XVar(false);
				foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
				{
					dynamic fields = XVar.Array();
					if(_tbl.Value != table)
					{
						continue;
					}
					fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(_tbl.Value)));
					foreach (KeyValuePair<XVar, dynamic> f in fields.GetEnumerator())
					{
						if(field == f.Value)
						{
							appear = new XVar(true);
							break;
						}
					}
				}
				if(XVar.Pack(!(XVar)(appear)))
				{
					arr_unset.InitAndSetArrayItem(arr.Key, null);
				}
				else
				{
					if(arr.Value["group_by_value"] == "GROUP BY")
					{
						groupby_found = new XVar(true);
					}
				}
			}
			foreach (KeyValuePair<XVar, dynamic> fld in arr_unset.GetEnumerator())
			{
				root["group_by_condition"].Remove(fld.Value);
			}
			keys = XVar.Clone(MVCFunctions.array_keys((XVar)(root["group_by_condition"])));
			group_by_condition = XVar.Clone(XVar.Array());
			i = new XVar(0);
			foreach (KeyValuePair<XVar, dynamic> k in keys.GetEnumerator())
			{
				if(XVar.Pack(MVCFunctions.IsNumeric(k.Value)))
				{
					group_by_condition.InitAndSetArrayItem(root["group_by_condition"][k.Value], i++);
				}
				else
				{
					group_by_condition.InitAndSetArrayItem(root["group_by_condition"][k.Value], k.Value);
				}
			}
			root.InitAndSetArrayItem(group_by_condition, "group_by_condition");
			if(XVar.Pack(!(XVar)(groupby_found)))
			{
				root.InitAndSetArrayItem("false", "group_by_condition", "group_by_toggle");
				foreach (KeyValuePair<XVar, dynamic> arr in root["group_by_condition"].GetEnumerator())
				{
					if(XVar.Equals(XVar.Pack(arr.Key), XVar.Pack("group_by_toggle")))
					{
						continue;
					}
					root.InitAndSetArrayItem("", "group_by_condition", arr.Key, "group_by_value");
				}
			}
			return null;
		}
		public static XVar update_chart_parameters()
		{
			dynamic arr_join_tables = XVar.Array(), params_saved = null, root = XVar.Array();
			root = XSession.Session["webcharts"];
			params_saved = new XVar(0);
			arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
			if(XVar.Pack(!(XVar)(root["parameters"])))
			{
				return null;
			}
			foreach (KeyValuePair<XVar, dynamic> arr in root["parameters"].GetEnumerator())
			{
				dynamic appear = null;
				appear = new XVar(false);
				if(XVar.Pack(CommonFunctions.is_groupby_chart()))
				{
					dynamic i = null;
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
					{
						if(root["group_by_condition"][i]["field_opt"] != MVCFunctions.Concat(arr.Value["table"], ".", arr.Value["name"]))
						{
							continue;
						}
						if((XVar)(arr.Value["agr_func"] == root["group_by_condition"][i]["group_by_value"])  || (XVar)((XVar)(!(XVar)(arr.Value["agr_func"]))  && (XVar)(root["group_by_condition"][i]["group_by_value"] == "GROUP BY")))
						{
							appear = new XVar(true);
							break;
						}
					}
				}
				else
				{
					root.InitAndSetArrayItem("", "parameters", arr.Key, "agr_func");
					foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
					{
						dynamic fields = XVar.Array();
						if(_tbl.Value != arr.Value["table"])
						{
							continue;
						}
						fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(_tbl.Value)));
						foreach (KeyValuePair<XVar, dynamic> f in fields.GetEnumerator())
						{
							if(f.Value == arr.Value["name"])
							{
								appear = new XVar(true);
								break;
							}
						}
						if(XVar.Pack(appear))
						{
							break;
						}
					}
				}
				if(XVar.Pack(appear))
				{
					params_saved++;
					continue;
				}
				root.InitAndSetArrayItem("", "parameters", arr.Key, "name");
				root.InitAndSetArrayItem("", "parameters", arr.Key, "table");
				root.InitAndSetArrayItem("", "parameters", arr.Key, "agr_func");
				root.InitAndSetArrayItem("", "parameters", arr.Key, "label");
			}
			if(XVar.Pack(!(XVar)(root["parameters"][0]["name"])))
			{
				set_default_chart_parameter(new XVar(0), new XVar(false), new XVar(true));
				if(XVar.Pack(!(XVar)(root["parameters"][0]["name"])))
				{
					set_default_chart_parameter(new XVar(0), new XVar(true), new XVar(true));
				}
			}
			if(XVar.Pack(!(XVar)(root["parameters"][CommonFunctions.pre8count((XVar)(root["parameters"])) - 1]["name"])))
			{
				set_default_chart_parameter((XVar)(CommonFunctions.pre8count((XVar)(root["parameters"])) - 1), new XVar(true), new XVar(false));
			}
			return null;
		}
		public static XVar set_default_chart_parameter(dynamic _param_idx, dynamic _param_labelMode, dynamic _param_addLabel)
		{
			#region pass-by-value parameters
			dynamic idx = XVar.Clone(_param_idx);
			dynamic labelMode = XVar.Clone(_param_labelMode);
			dynamic addLabel = XVar.Clone(_param_addLabel);
			#endregion

			dynamic arr_join_tables = XVar.Array(), root = XVar.Array();
			root = XSession.Session["webcharts"];
			arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
			if(XVar.Pack(CommonFunctions.is_groupby_chart()))
			{
				dynamic grvalue = null, i = null, var_type = null;
				i = new XVar(0);
				for(;i < CommonFunctions.pre8count((XVar)(root["group_by_condition"])) - 1; i++)
				{
					if(XVar.Pack(!(XVar)(root["group_by_condition"][i]["group_by_value"])))
					{
						continue;
					}
					var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(root["group_by_condition"][i]["field_opt"])));
					grvalue = XVar.Clone(root["group_by_condition"][i]["group_by_value"]);
					if((XVar)((XVar)(!(XVar)(labelMode))  && (XVar)((XVar)(CommonFunctions.IsNumberType((XVar)(var_type)))  || (XVar)(grvalue != "GROUP BY")))  || (XVar)(labelMode))
					{
						dynamic field = null, table = null;
						table = new XVar("");
						field = new XVar("");
						CommonFunctions.WRSplitFieldName((XVar)(root["group_by_condition"][i]["field_opt"]), ref table, ref field);
						root.InitAndSetArrayItem(field, "parameters", idx, "name");
						root.InitAndSetArrayItem(table, "parameters", idx, "table");
						if(grvalue != "GROUP BY")
						{
							root.InitAndSetArrayItem(grvalue, "parameters", idx, "agr_func");
						}
						if(XVar.Pack(addLabel))
						{
							root.InitAndSetArrayItem(field, "parameters", idx, "label");
						}
						break;
					}
				}
			}
			else
			{
				foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
				{
					dynamic fields = XVar.Array();
					if(XVar.Pack(!(XVar)(labelMode)))
					{
						fields = XVar.Clone(CommonFunctions.GetNumberFieldsList((XVar)(_tbl.Value)));
					}
					else
					{
						fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(_tbl.Value)));
					}
					if(XVar.Pack(fields))
					{
						root.InitAndSetArrayItem(fields[0], "parameters", idx, "name");
						root.InitAndSetArrayItem(_tbl.Value, "parameters", idx, "table");
						root.InitAndSetArrayItem("", "parameters", idx, "agr_func");
						if(XVar.Pack(addLabel))
						{
							root.InitAndSetArrayItem(CommonFunctions.WRChartLabel((XVar)(MVCFunctions.Concat(_tbl.Value, ".", fields[0]))), "parameters", idx, "label");
						}
						break;
					}
				}
			}
			return null;
		}
		public static XVar update_report_group_fields()
		{
			dynamic arr_unset = XVar.Array(), changed = null, j = null, keys = XVar.Array(), newarr = XVar.Array(), root = XVar.Array(), tables = null;
			root = XSession.Session["webreports"];
			tables = XVar.Clone(CommonFunctions.getReportTablesList());
			changed = new XVar(false);
			arr_unset = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> fld in root["group_fields"].GetEnumerator())
			{
				dynamic field = null, table = null;
				table = new XVar("");
				field = new XVar("");
				if(fld.Value["name"] == "Summary")
				{
					continue;
				}
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					CommonFunctions.WRSplitFieldName((XVar)(fld.Value["name"]), ref table, ref field);
				}
				else
				{
					field = XVar.Clone(fld.Value["name"]);
					table = XVar.Clone(root["tables"][0]);
				}
				if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(table), (XVar)(tables))), XVar.Pack(false)))
				{
					dynamic fields = null;
					fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
					if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(fields))), XVar.Pack(false)))
					{
						continue;
					}
				}
				arr_unset.InitAndSetArrayItem(fld.Key, null);
				changed = new XVar(true);
			}
			foreach (KeyValuePair<XVar, dynamic> fld in arr_unset.GetEnumerator())
			{
				root["group_fields"].Remove(fld.Value);
			}
			if(XVar.Pack(!(XVar)(changed)))
			{
				return null;
			}
			j = new XVar(0);
			newarr = XVar.Clone(XVar.Array());
			keys = XVar.Clone(MVCFunctions.array_keys((XVar)(root["group_fields"])));
			foreach (KeyValuePair<XVar, dynamic> idx in keys.GetEnumerator())
			{
				newarr.InitAndSetArrayItem(root["group_fields"][idx.Value], j);
				j++;
			}
			root.InitAndSetArrayItem(newarr, "group_fields");
			return null;
		}
		public static XVar update_report_sort_fields()
		{
			dynamic arr_unset = XVar.Array(), changed = null, j = null, keys = XVar.Array(), newarr = XVar.Array(), root = XVar.Array(), tables = null;
			root = XSession.Session["webreports"];
			if(XVar.Pack(!(XVar)(root["sort_fields"])))
			{
				return null;
			}
			tables = XVar.Clone(CommonFunctions.getReportTablesList());
			changed = new XVar(false);
			arr_unset = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> fld in root["sort_fields"].GetEnumerator())
			{
				dynamic field = null, table = null;
				table = new XVar("");
				field = new XVar("");
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					CommonFunctions.WRSplitFieldName((XVar)(fld.Value["name"]), ref table, ref field);
				}
				else
				{
					field = XVar.Clone(fld.Value["name"]);
					table = XVar.Clone(root["tables"][0]);
				}
				if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(table), (XVar)(tables))), XVar.Pack(false)))
				{
					dynamic fields = null;
					fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table)));
					if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(fields))), XVar.Pack(false)))
					{
						continue;
					}
				}
				arr_unset.InitAndSetArrayItem(fld.Key, null);
			}
			foreach (KeyValuePair<XVar, dynamic> fld in arr_unset.GetEnumerator())
			{
				root["sort_fields"].Remove(fld.Value);
			}
			newarr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> fld in root["group_fields"].GetEnumerator())
			{
				if(fld.Value["name"] == "Summary")
				{
					continue;
				}
				newarr.InitAndSetArrayItem(new XVar("name", fld.Value["name"], "desc", "false"), null);
			}
			keys = XVar.Clone(MVCFunctions.array_keys((XVar)(root["sort_fields"])));
			j = XVar.Clone(CommonFunctions.pre8count((XVar)(newarr)));
			foreach (KeyValuePair<XVar, dynamic> idx in keys.GetEnumerator())
			{
				dynamic found = null;
				found = new XVar(false);
				foreach (KeyValuePair<XVar, dynamic> nfld in newarr.GetEnumerator())
				{
					if(nfld.Value["name"] == root["sort_fields"][idx.Value]["name"])
					{
						found = new XVar(true);
						break;
					}
				}
				if(XVar.Pack(found))
				{
					continue;
				}
				newarr.InitAndSetArrayItem(root["sort_fields"][idx.Value], j);
				j++;
			}
			root.InitAndSetArrayItem(newarr, "sort_fields");
			return null;
		}
		public static XVar make_from_clause(dynamic _param_type)
		{
			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			#endregion

			dynamic _connection = null, accessMode = null, firstJoin = null, fullouter = null, ret = null, root = XVar.Array();
			accessMode = XVar.Clone(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_Access);
			root = XSession.Session[var_type];
			_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				_connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(root["tables"][0])));
			}
			ret = XVar.Clone(_connection.addTableWrappers((XVar)(root["tables"][0])));
			fullouter = new XVar("");
			firstJoin = new XVar(true);
			if(XVar.Pack(MVCFunctions.is_array((XVar)(root["table_relations"]["relat"]))))
			{
				foreach (KeyValuePair<XVar, dynamic> r in root["table_relations"]["relat"].GetEnumerator())
				{
					dynamic joinon = null;
					if(MVCFunctions.trim((XVar)(r.Value["rel_type"])) == "FULL OUTER JOIN")
					{
						fullouter = MVCFunctions.Concat(fullouter, "\n,", _connection.addTableWrappers((XVar)(r.Value["right_table"])));
						continue;
					}
					if((XVar)(accessMode)  && (XVar)(!(XVar)(firstJoin)))
					{
						ret = XVar.Clone(MVCFunctions.Concat("(", ret, ")"));
					}
					firstJoin = new XVar(false);
					ret = MVCFunctions.Concat(ret, "\n", r.Value["rel_type"], " ", _connection.addTableWrappers((XVar)(r.Value["right_table"])), " ON ");
					joinon = new XVar("");
					foreach (KeyValuePair<XVar, dynamic> f in r.Value["left_fields"].GetEnumerator())
					{
						if(XVar.Pack(MVCFunctions.strlen((XVar)(joinon))))
						{
							joinon = MVCFunctions.Concat(joinon, " AND ");
						}
						joinon = MVCFunctions.Concat(joinon, _connection.addTableWrappers((XVar)(r.Value["left_table"])), ".", _connection.addFieldWrappers((XVar)(r.Value["left_fields"][f.Key])));
						joinon = MVCFunctions.Concat(joinon, "=");
						joinon = MVCFunctions.Concat(joinon, _connection.addTableWrappers((XVar)(r.Value["right_table"])), ".", _connection.addFieldWrappers((XVar)(r.Value["right_fields"][f.Key])));
					}
					ret = MVCFunctions.Concat(ret, joinon);
				}
			}
			return MVCFunctions.Concat("FROM ", ret, fullouter);
		}
		public static XVar Check_Crosstable_Group(dynamic _param_arr, dynamic _param_is_save)
		{
			#region pass-by-value parameters
			dynamic arr = XVar.Clone(_param_arr);
			dynamic is_save = XVar.Clone(_param_is_save);
			#endregion

			if((XVar)(CommonFunctions.pre8count((XVar)(arr["group_fields"])) == 0)  && (XVar)(is_save))
			{
				arr.InitAndSetArrayItem(XSession.Session["webreports"]["group_fields"], "group_fields");
			}
			if(arr["group_fields"][CommonFunctions.pre8count((XVar)(arr["group_fields"])) - 1]["cross_table"] == "true")
			{
				dynamic count_x = null, count_y = null, i = null;
				if((XVar)(CommonFunctions.pre8count((XVar)(arr["group_fields"])) - 1 < 2)  && (XVar)(is_save))
				{
					MVCFunctions.Echo("You must select at least one group fields");
					MVCFunctions.ob_flush();
					System.Web.HttpContext.Current.Response.End();
					throw new RunnerInlineOutputException();
				}
				count_x = new XVar(0);
				count_y = new XVar(0);
				i = new XVar(0);
				for(;i < CommonFunctions.pre8count((XVar)(arr["group_fields"])) - 1; i++)
				{
					if((XVar)(arr["group_fields"][i]["group_type"] == "x")  || (XVar)(arr["group_fields"][i]["group_type"] == "all"))
					{
						count_x++;
					}
					if((XVar)(arr["group_fields"][i]["group_type"] == "y")  || (XVar)(arr["group_fields"][i]["group_type"] == "all"))
					{
						count_y++;
					}
				}
				if((XVar)(count_x == XVar.Pack(0))  || (XVar)(count_y == XVar.Pack(0)))
				{
					MVCFunctions.Echo("You must select at least one axis");
					MVCFunctions.ob_flush();
					System.Web.HttpContext.Current.Response.End();
					throw new RunnerInlineOutputException();
				}
			}
			return null;
		}
		public static XVar Check_Crosstable_Totals(dynamic _param_arr, dynamic _param_is_crosstable)
		{
			#region pass-by-value parameters
			dynamic arr = XVar.Clone(_param_arr);
			dynamic is_crosstable = XVar.Clone(_param_is_crosstable);
			#endregion

			if((XVar)(is_crosstable == "true")  && (XVar)(!(XVar)(arr["totals"].IsEmpty())))
			{
				foreach (KeyValuePair<XVar, dynamic> value in arr["totals"].GetEnumerator())
				{
					if((XVar)((XVar)((XVar)(value.Value["min"] == "true")  || (XVar)(value.Value["max"] == "true"))  || (XVar)(value.Value["sum"] == "true"))  || (XVar)(value.Value["avg"] == "true"))
					{
						return null;
					}
				}
				MVCFunctions.Echo("You must check group functions");
				MVCFunctions.ob_flush();
				System.Web.HttpContext.Current.Response.End();
				throw new RunnerInlineOutputException();
			}
			return null;
		}
	}
}
