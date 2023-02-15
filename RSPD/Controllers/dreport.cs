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
		public ActionResult dreport()
		{
			try
			{
				dynamic _connection = null, advHref = null, arr_xml_fields = XVar.Array(), bparams = null, cross_table = null, crosstableObj = null, data = XVar.Array(), editmode = null, field = null, grid_row = XVar.Array(), group = null, i = null, includes = null, j = null, modePrint = null, num_uniq = null, num_uniq2 = null, pageObject = null, param = null, preview = null, render_mode = null, reoportQResult = null, reportFilename = null, reportName = null, rname = null, sClause = null, searchType = null, selector = null, sessPrefix = null, strSQL = null, style = null, styleStr = null, templatefile = null, uniq = null, var_params = XVar.Array(), var_type = null, viewControls = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				CommonFunctions.add_nocache_headers();
				if((XVar)(MVCFunctions.postvalue(new XVar("rname")))  || (XVar)(XSession.Session["webreports"]["settings"]["name"]))
				{
					rname = XVar.Clone(MVCFunctions.postvalue(new XVar("rname")));
					if((XVar)((XVar)(!(XVar)(rname))  && (XVar)(XSession.Session["webreports"]["settings"]["name"]))  && (XVar)(MVCFunctions.postvalue("edit") == "style"))
					{
						rname = XVar.Clone(XSession.Session["webreports"]["settings"]["name"]);
					}
					data = XVar.Clone(CommonFunctions.wrGetEntityRecord((XVar)(rname), new XVar(Constants.WR_REPORT)));
					if(XVar.Pack(!(XVar)(data)))
					{
						MVCFunctions.Header((XVar)(MVCFunctions.Concat("location: ", MVCFunctions.GetTableLink(new XVar("webreport")))));
					}
					else
					{
						CommonFunctions.Reload_Report((XVar)(MVCFunctions.postvalue(new XVar("rname"))));
					}
				}
				includes = new XVar("");
				includes = MVCFunctions.Concat(includes, "<script language=\"JavaScript\" src=\"include/loadfirst.js?40550\"></script>\r\n");
				includes = MVCFunctions.Concat(includes, "<script type=\"text/javascript\" src=\"include/lang/", CommonFunctions.getLangFileName((XVar)(CommonFunctions.mlang_getcurrentlang())), ".js\"></script>");
				cross_table = new XVar("false");
				modePrint = new XVar(false);
				if(MVCFunctions.postvalue("mode") == "print")
				{
					modePrint = new XVar(true);
				}
				render_mode = new XVar(Constants.MODE_LIST);
				if(XVar.Pack(modePrint))
				{
					render_mode = new XVar(Constants.MODE_EXPORT);
					if(MVCFunctions.postvalue("format") == "excel")
					{
						MVCFunctions.Header("Content-Type", "application/vnd.ms-excel");
						MVCFunctions.Header((XVar)(MVCFunctions.Concat("Content-Disposition: attachment;Filename=", MVCFunctions.postvalue(new XVar("rname")), ".xls")));
						MVCFunctions.Echo("<html>");
						MVCFunctions.Echo("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
						MVCFunctions.Echo(MVCFunctions.Concat("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=", GlobalVars.cCharset, "\">"));
					}
					else
					{
						if(MVCFunctions.postvalue("format") == "word")
						{
							MVCFunctions.Header("Content-Type", "application/vnd.ms-word");
							MVCFunctions.Header((XVar)(MVCFunctions.Concat("Content-Disposition: attachment;Filename=", MVCFunctions.postvalue(new XVar("rname")), ".doc")));
							MVCFunctions.Echo("<html>");
							MVCFunctions.Echo(MVCFunctions.Concat("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=", GlobalVars.cCharset, "\">"));
						}
						else
						{
							render_mode = new XVar(Constants.MODE_PRINT);
						}
					}
				}
				num_uniq = new XVar(0);
				num_uniq2 = new XVar(4);
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(new XVar("pageType", "", "id", 0));
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "tName");
				GlobalVars.pageObject = XVar.Clone(new WebreportPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.addCommonJs();
				bparams = XVar.Clone(XVar.Array());
				xt.assign_method(new XVar("bodyend"), (XVar)(GlobalVars.pageObject), new XVar("assignBodyEnd"));
				editmode = XVar.Clone(MVCFunctions.postvalue("edit") == "style");
				if(XVar.Pack(!(XVar)(editmode)))
				{
					GlobalVars.rpt_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue(new XVar("rname"))), new XVar(Constants.WR_REPORT)));
				}
				else
				{
					GlobalVars.rpt_array = XVar.Clone(XSession.Session["webreports"]);
				}
				if(XVar.Pack(!(XVar)(XSession.Session["webobject"])))
				{
					XSession.Session["webobject"] = XVar.Array();
				}
				XSession.Session.InitAndSetArrayItem(GlobalVars.rpt_array["table_type"], "webobject", "table_type");
				if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("crosstable_refresh")))))
				{
					reportFilename = XVar.Clone(MVCFunctions.GetTableLink(new XVar("dreport")));
				}
				cross_table = XVar.Clone(GlobalVars.rpt_array["group_fields"][CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1]["cross_table"]);
				if(cross_table == "true")
				{
					GlobalVars.init_crosstable_webreport();
					includes = MVCFunctions.Concat(includes, "<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/crosstable.js")), "\"></script>");
					includes = MVCFunctions.Concat(includes, "<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/json.js")), "\"></script>");
				}
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(GlobalVars.rpt_array["tables"][0])), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				GlobalVars.gSettings = XVar.Clone(new ProjectSettings((XVar)(GlobalVars.rpt_array["tables"][0]), new XVar(Constants.PAGE_REPORT)));
				GlobalVars.tbl = XVar.Clone(GlobalVars.rpt_array["tables"][0]);
				GlobalVars.strTableName = XVar.Clone(GlobalVars.tbl);
				GlobalVars.arrDBFieldsList = XVar.Clone(XVar.Array());
				i = new XVar(1);
				foreach (KeyValuePair<XVar, dynamic> val in GlobalVars.rpt_array["totals"].GetEnumerator())
				{
					GlobalVars.arrDBFieldsList.InitAndSetArrayItem(MVCFunctions.Concat("f", i), MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(val.Value["table"], ".", val.Value["name"]))));
					i++;
				}
				viewControls = XVar.Clone(new ViewControlsContainer((XVar)(GlobalVars.gSettings), new XVar(Constants.PAGE_REPORT)));
				sessPrefix = new XVar("");
				if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
				{
					sessPrefix = XVar.Clone(MVCFunctions.Concat("webreport", MVCFunctions.postvalue(new XVar("rname"))));
				}
				else
				{
					sessPrefix = XVar.Clone(GlobalVars.tbl);
				}
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				else
				{
					if((XVar)(GlobalVars.rpt_array["settings"]["status"] == "private")  && (XVar)(GlobalVars.rpt_array["owner"] != Security.getUserName()))
					{
						MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this report", "</p>"));
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				if(1 < CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())))
				{
					dynamic arr_reports = XVar.Array();
					arr_reports = XVar.Clone(XVar.Array());
					arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_REPORT)));
					foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
					{
						if((XVar)((XVar)((XVar)(rpt.Value["owner"] != Security.getUserName())  || (XVar)(rpt.Value["owner"] == ""))  && (XVar)(rpt.Value["view"] == 0))  && (XVar)(GlobalVars.rpt_array["settings"]["name"] == rpt.Value["name"]))
						{
							MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this report", "</p>"));
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
					}
				}
				arr_xml_fields = XVar.Clone(new XVar(0, "group_fields", 1, "totals", 2, "sort_fields"));
				foreach (KeyValuePair<XVar, dynamic> xml_field in arr_xml_fields.GetEnumerator())
				{
					if(XVar.Pack(!(XVar)(GlobalVars.rpt_array[xml_field.Value].IsEmpty())))
					{
						dynamic keyToModify = XVar.Array();
						keyToModify = XVar.Clone(XVar.Array());
						foreach (KeyValuePair<XVar, dynamic> _data in GlobalVars.rpt_array[xml_field.Value].GetEnumerator())
						{
							keyToModify.InitAndSetArrayItem(XVar.Array(), _data.Key);
							foreach (KeyValuePair<XVar, dynamic> val in _data.Value.GetEnumerator())
							{
								if(_data.Value[val.Key] == "true")
								{
									keyToModify.InitAndSetArrayItem(true, _data.Key, val.Key);
								}
								else
								{
									if(_data.Value[val.Key] == "false")
									{
										keyToModify.InitAndSetArrayItem(false, _data.Key, val.Key);
									}
								}
							}
						}
						foreach (KeyValuePair<XVar, dynamic> _data in keyToModify.GetEnumerator())
						{
							foreach (KeyValuePair<XVar, dynamic> val in _data.Value.GetEnumerator())
							{
								GlobalVars.rpt_array.InitAndSetArrayItem(val.Value, xml_field.Value, _data.Key, val.Key);
							}
						}
					}
				}
				GlobalVars.rpt_array.InitAndSetArrayItem((XVar.Pack(GlobalVars.rpt_array["miscellaneous"]["print_friendly"] == "true") ? XVar.Pack(true) : XVar.Pack(false)), "miscellaneous", "print_friendly");
				reoportQResult = XVar.Clone(CommonFunctions.wrGetStyleRS((XVar)(rname)));
				styleStr = new XVar("");
				while(XVar.Pack(data = XVar.Clone(reoportQResult.fetchAssoc())))
				{
					var_type = XVar.Clone(data["type"]);
					style = XVar.Clone(data["style_str"]);
					field = XVar.Clone(data["field"]);
					group = XVar.Clone(data["group"]);
					uniq = XVar.Clone(data["uniq"]);
					if(var_type == "table")
					{
						selector = new XVar("#legend td");
					}
					else
					{
						if((XVar)(!(XVar)(field))  && (XVar)(group))
						{
							selector = XVar.Clone(MVCFunctions.Concat("#legend td.class", group, "g"));
						}
						else
						{
							if((XVar)(field)  && (XVar)(!(XVar)(group)))
							{
								selector = XVar.Clone(MVCFunctions.Concat("#legend td.class", field, "f"));
							}
							else
							{
								if((XVar)((XVar)(!(XVar)(uniq))  && (XVar)(field))  && (XVar)(group))
								{
									selector = XVar.Clone(MVCFunctions.Concat("#legend td.class", group, "g", field, "f0u"));
								}
								else
								{
									selector = XVar.Clone(MVCFunctions.Concat("#legend td.class", group, "g", field, "f", uniq, "u"));
								}
							}
						}
					}
					styleStr = MVCFunctions.Concat(styleStr, selector, " { ", style, " }\r\n");
				}
				xt.assign(new XVar("styleStr"), (XVar)(styleStr));
				if(XVar.Pack(editmode))
				{
					xt.assign(new XVar("b_is_report_name"), (XVar)(GlobalVars.rpt_array["settings"]["name"] != ""));
					xt.assign(new XVar("b_is_report_save"), (XVar)(XSession.Session["webreports"]["tmp_active"] != "x"));
				}
				if(XVar.Pack(!(XVar)(modePrint)))
				{
					dynamic tosearch = null;
					if((XVar)(!(XVar)(MVCFunctions.POSTSize()))  && (XVar)(MVCFunctions.GETSize() == 1))
					{
						if(XVar.Pack(MVCFunctions.GETKeyExists("rname")))
						{
							dynamic sess_unset = XVar.Array();
							sess_unset = XVar.Clone(XVar.Array());
							foreach (KeyValuePair<XVar, dynamic> value in XSession.Session.GetEnumerator())
							{
								if((XVar)(MVCFunctions.substr((XVar)(value.Key), new XVar(0), (XVar)(MVCFunctions.strlen((XVar)(sessPrefix)) + 1)) == MVCFunctions.Concat(sessPrefix, "_"))  && (XVar)(XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(MVCFunctions.substr((XVar)(value.Key), (XVar)(MVCFunctions.strlen((XVar)(sessPrefix)) + 1))), new XVar("_"))), XVar.Pack(false))))
								{
									sess_unset.InitAndSetArrayItem(value.Key, null);
								}
							}
							foreach (KeyValuePair<XVar, dynamic> key in sess_unset.GetEnumerator())
							{
								XSession.Session.Remove(key.Value);
							}
						}
					}
					if((XVar)(MVCFunctions.postvalue("a") == "advsearch")  || (XVar)(MVCFunctions.postvalue("a") == "integrated"))
					{
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchnot")] = XVar.Array();
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchopt")] = XVar.Array();
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor")] = XVar.Array();
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")] = XVar.Array();
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtable")] = XVar.Array();
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfortype")] = XVar.Array();
						XSession.Session.Remove(MVCFunctions.Concat(sessPrefix, "_asearchtype"));
						tosearch = new XVar(0);
					}
					if(MVCFunctions.postvalue("a") == "advsearch")
					{
						dynamic asearchfield = XVar.Array(), asearchtable = XVar.Array();
						asearchfield = XVar.Clone(MVCFunctions.postvalue(new XVar("asearchfield")));
						asearchtable = XVar.Clone(MVCFunctions.postvalue(new XVar("asearchtable")));
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] = MVCFunctions.postvalue(new XVar("type"));
						if(XVar.Pack(!(XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")])))
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] = "and";
						}
						foreach (KeyValuePair<XVar, dynamic> _field in asearchfield.GetEnumerator())
						{
							dynamic asopt = null, gfield = null, value1 = null, value2 = null, var_not = null;
							if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
							{
								XSession.Session.InitAndSetArrayItem(asearchtable[_field.Key], MVCFunctions.Concat(sessPrefix, "_asearchtable"), _field.Value);
							}
							gfield = XVar.Clone(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(_field.Value)), "_1"));
							asopt = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("asearchopt_", gfield))));
							value1 = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value_", gfield))));
							var_type = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("type_", gfield))));
							value2 = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value1_", gfield))));
							var_not = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("not_", gfield))));
							if((XVar)(MVCFunctions.strlen((XVar)(value1)))  || (XVar)(asopt == "Empty"))
							{
								tosearch = new XVar(1);
								XSession.Session.InitAndSetArrayItem(asopt, MVCFunctions.Concat(sessPrefix, "_asearchopt"), _field.Value);
								if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(value1)))))
								{
									XSession.Session.InitAndSetArrayItem(value1, MVCFunctions.Concat(sessPrefix, "_asearchfor"), _field.Value);
								}
								else
								{
									XSession.Session.InitAndSetArrayItem(CommonFunctions.combinevalues((XVar)(value1)), MVCFunctions.Concat(sessPrefix, "_asearchfor"), _field.Value);
								}
								XSession.Session.InitAndSetArrayItem(var_type, MVCFunctions.Concat(sessPrefix, "_asearchfortype"), _field.Value);
								if(XVar.Pack(value2))
								{
									XSession.Session.InitAndSetArrayItem(value2, MVCFunctions.Concat(sessPrefix, "_asearchfor2"), _field.Value);
								}
								XSession.Session.InitAndSetArrayItem(var_not == "on", MVCFunctions.Concat(sessPrefix, "_asearchnot"), _field.Value);
							}
						}
					}
					else
					{
						if(MVCFunctions.postvalue("a") == "integrated")
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] = MVCFunctions.postvalue(new XVar("criteria"));
							if(XVar.Pack(!(XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")])))
							{
								XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] = "and";
							}
							j = new XVar(1);
							while(XVar.Pack(field = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("field", j))))))
							{
								tosearch = new XVar(1);
								XSession.Session.InitAndSetArrayItem(MVCFunctions.trim((XVar)(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("type", j))))), MVCFunctions.Concat(sessPrefix, "_asearchfortype"), field);
								XSession.Session.InitAndSetArrayItem(MVCFunctions.trim((XVar)(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value", j, "1"))))), MVCFunctions.Concat(sessPrefix, "_asearchfor"), field);
								XSession.Session.InitAndSetArrayItem((XVar.Pack(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("option", j)))) ? XVar.Pack(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("option", j)))) : XVar.Pack("Contains")), MVCFunctions.Concat(sessPrefix, "_asearchopt"), field);
								XSession.Session.InitAndSetArrayItem(MVCFunctions.trim((XVar)(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value", j, "2"))))), MVCFunctions.Concat(sessPrefix, "_asearchfor2"), field);
								XSession.Session.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("not", j))) == "on", MVCFunctions.Concat(sessPrefix, "_asearchnot"), field);
								j++;
							}
						}
					}
					if((XVar)(MVCFunctions.postvalue("a") == "advsearch")  || (XVar)(MVCFunctions.postvalue("a") == "integrated"))
					{
						if(XVar.Pack(tosearch))
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_search")] = 2;
						}
						else
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_search")] = 0;
						}
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")] = 1;
					}
				}
				if(XVar.Pack(MVCFunctions.postvalue("orderby")))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_orderby")] = MVCFunctions.postvalue("orderby");
				}
				if(XVar.Pack(MVCFunctions.postvalue("pagesize")))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")] = MVCFunctions.postvalue("pagesize");
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")] = 1;
				}
				if(XVar.Pack(MVCFunctions.postvalue("goto")))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")] = MVCFunctions.postvalue("goto");
				}
				includes = MVCFunctions.Concat(includes, "\r\n\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery.ui.all.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/stylesheet.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css?v=2.0.4")), "\" type=\"text/css\" media=\"screen\">\r\n\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.custom.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js?v=2.0.4")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.cookie.js")), "\"></script>\r\n\t");
				if(XVar.Pack(editmode))
				{
					includes = MVCFunctions.Concat(includes, "<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/actionscript.js")), "\"></script>");
				}
				includes = MVCFunctions.Concat(includes, "\r\n\t<script type=\"text/javascript\">\r\n\tvar bSelected = false,\r\n\t\tTEXT_FIRST = \"First\",\r\n\t\tTEXT_PREVIOUS = \"Previous\",\r\n\t\tTEXT_NEXT = \"Next\",\r\n\t\tTEXT_LAST = \"Last\",\r\n\t\tdefURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\r\n\tfunction GetGotoPageUrlString(nPageNumber,sUrlText){\r\n\t\treturn '<a href=\"JavaScript:GotoPage('+nPageNumber+');\" style=\"text-decoration: none;\">'+sUrlText+'</a>';\r\n\t}\r\n\r\n\tfunction WritePagination(mypage, maxpages, id){\r\n\t\tvar paginationHTML = \"\";\r\n\r\n\t\tif (maxpages > 1 && mypage <= maxpages){\r\n\r\n\t\t\tvar counterstart = mypage - 9;\r\n\t\t\tif (mypage % 10 != 0){\r\n\t\t\t\tcounterstart = mypage - (mypage%10) + 1;\r\n\t\t\t}\r\n\t\t\tvar counterend = counterstart + 9;\r\n\t\t\tif (counterend > maxpages){\r\n\t\t\t\tcounterend = maxpages;\r\n\t\t\t}\r\n\t\t\tif (counterstart != 1){\r\n\t\t\t\tpaginationHTML += GetGotoPageUrlString(1,\"First\")+\"&nbsp;:&nbsp;\"+GetGotoPageUrlString(counterstart - 1,\"Prev\")+\"&nbsp;\";\r\n\t\t\t}\r\n\t\t\tpaginationHTML += \"<b>[</b>\";\r\n\r\n\t\t\tvar pad = \"\";\r\n\t\t\tvar counter\t= counterstart;\r\n\t\t\tfor(;counter<=counterend;counter++)\r\n\t\t\t{\r\n\t\t\t\tif (counter != mypage)\r\n\t\t\t\t\tpaginationHTML += \"&nbsp;\" + GetGotoPageUrlString(counter,pad + counter);\r\n\t\t\t\telse\r\n\t\t\t\t\tpaginationHTML += \"&nbsp;<b>\" + pad + counter + \"</b>\";\r\n\t\t\t}\r\n\t\t\tpaginationHTML += \"&nbsp;<b>]</b>\";\r\n\r\n\t\t\tif (counterend != maxpages)\r\n\t\t\t\tpaginationHTML += \"&nbsp;\" + GetGotoPageUrlString (counterend + 1,\"Next\") + \"&nbsp;:&nbsp;\" + GetGotoPageUrlString(maxpages,\"Last\");\r\n\r\n\t\t\t$(\"#pagination\"+id).html(paginationHTML);\r\n\t\t}\r\n\t}\r\n\r\n\t$(document).ready(function(){\r\n\r\n\t\t\t$(\"a#preview\").fancybox({\r\n\t\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t\t});\r\n\r\n\t");
				if(XSession.Session["webreports"]["group_fields"][CommonFunctions.pre8count((XVar)(XSession.Session["webreports"]["group_fields"])) - 1]["cross_table"] == "true")
				{
					includes = MVCFunctions.Concat(includes, "$(\"#row5,#row6\").hide();", "\r\n");
				}
				if((XVar)(CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())) < 2)  || (XVar)((XVar)(XSession.Session["webreports"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webreports"]["settings"]["status"] == "private")))
				{
					includes = MVCFunctions.Concat(includes, "$(\"td[id=row9]\").hide();");
				}
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					includes = MVCFunctions.Concat(includes, "$(\"td[id=row11]\").hide();", "\n");
				}
				if(XVar.Pack(!(XVar)(modePrint)))
				{
					if((XVar)(CommonFunctions.is_wr_project())  || (XVar)(CommonFunctions.is_wr_custom()))
					{
						includes = MVCFunctions.Concat(includes, "$(\"td[id=row1], td[id=row2]\").hide();", "\r\n");
					}
					if(XSession.Session["webreports"]["settings"]["title"] == "")
					{
						includes = MVCFunctions.Concat(includes, "\r\n\t\t\tfor (var i=2; i<=9; i++){\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").hide();\r\n\t\t\t};\r\n\t\t");
					}
				}
				else
				{
					includes = MVCFunctions.Concat(includes, "setTimeout(function() {window.print();}, 1000);");
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
				{
					advHref = new XVar("dsearch");
				}
				else
				{
					advHref = XVar.Clone(MVCFunctions.Concat(MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.rpt_array["short_table_name"])), "_search"));
				}
				sClause = new XVar("");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("q"))))
				{
					sClause = XVar.Clone(MVCFunctions.Concat("&q=", MVCFunctions.postvalue(new XVar("q"))));
				}
				includes = MVCFunctions.Concat(includes, "\r\n\r\n\t$(\"#export_to_excel\").click(function(){\r\n\t\t\twindow.location.href = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?mode=print&all=1&format=excel&rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("rname")))), sClause, "&\"+initCrossTableParams();\r\n\t\t\treturn false;\r\n\t\t});\r\n\r\n\t$(\"#export_to_word\").click(function(){\r\n\t\t\twindow.location.href = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?mode=print&all=1&format=word&rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("rname")))), sClause, "&\"+initCrossTableParams();\r\n\t\t\treturn false;\r\n\t\t});\r\n\t$(\"#advButton\").click(function(){\r\n\t\t\twindow.location.href = \"", MVCFunctions.GetTableLink((XVar)(advHref)), "?rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("rname")))), "&\"+initCrossTableParams();\r\n\t\t});\r\n\r\n\t$(\"#printButton\").click(function(){\r\n\t\t\twindow.open(\"", MVCFunctions.GetTableLink(new XVar("dreport")), "?mode=print&all=1&rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("rname")))), sClause, "&\"+initCrossTableParams(),\"wPrint\");\r\n\t\t\treturn false;\r\n\t\t});\r\n\tfunction initCrossTableParams(){\r\n\t\tvar pos2, advAttr = \"\",\r\n\t\t\tshref = window.location.href,\r\n\t\t\tpos = shref.indexOf(\"&axis_x\", 0);\r\n\r\n\t\tif (pos >= 0) {\r\n\t\t\tshref = shref.substr(0, pos);\r\n\t\t\tpos2 = shref.indexOf(\"a=\", 0);\r\n\t\t\tif ( pos2 >= 0 ) {\r\n\t\t\t\tshref = shref.substr( pos2 );\r\n\t\t\t}\r\n\t\t}\r\n\t\tif ( $(\"#select_group_x\").length ) {\r\n\t\t\tvar axis_x = $(\"#select_group_x\").val(),\r\n\t\t\t\taxis_y = $(\"#select_group_y\").val(),\r\n\t\t\t\tfield = $(\"#select_data\").val(),\r\n\t\t\t\tgrfunc_value = 0;\r\n\r\n\t\t\t$(\"input[name=group_func]:checked\").each( function() {\r\n\t\t\t\tgrfunc_value = this.value;\r\n\t\t\t});\r\n\t\t\tadvAttr = \"axis_x=\" + axis_x + \"&axis_y=\" + axis_y + \"&field=\" + field + \"&group_func=\" + grfunc_value;\r\n\t\t}\r\n\t\treturn advAttr;\r\n\t};\r\n});\r\n</script>");
				xt.assign(new XVar("includes"), (XVar)(includes));
				_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					_connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(GlobalVars.rpt_array["tables"][0])));
				}
				strSQL = new XVar("");
				if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
				{
					dynamic sWhere = null, strOrderBy = null, strWhereClause = null;
					GlobalVars.gstrOrderBy = new XVar("");
					if(XVar.Pack(!(XVar)(GlobalVars.rpt_array["sort_fields"].IsEmpty())))
					{
						GlobalVars.gstrOrderBy = new XVar("ORDER BY ");
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["sort_fields"].GetEnumerator())
						{
							GlobalVars.gstrOrderBy = MVCFunctions.Concat(GlobalVars.gstrOrderBy, _connection.addFieldWrappers((XVar)(fld.Value["name"])));
							if(XVar.Pack(fld.Value["desc"]))
							{
								GlobalVars.gstrOrderBy = MVCFunctions.Concat(GlobalVars.gstrOrderBy, " DESC, ");
							}
							else
							{
								GlobalVars.gstrOrderBy = MVCFunctions.Concat(GlobalVars.gstrOrderBy, " ASC, ");
							}
						}
						GlobalVars.gstrOrderBy = XVar.Clone(MVCFunctions.substr((XVar)(GlobalVars.gstrOrderBy), new XVar(0), new XVar(-2)));
					}
					strOrderBy = XVar.Clone(GlobalVars.gstrOrderBy);
					strWhereClause = new XVar("");
					sWhere = new XVar("");
					if(XVar.Pack(!(XVar)(editmode)))
					{
						sWhere = XVar.Clone(CommonFunctions.CalcSearchParam((XVar)(sessPrefix)));
					}
					strWhereClause = XVar.Clone(CommonFunctions.whereAdd((XVar)(strWhereClause), (XVar)(sWhere)));
					if(XVar.Pack(sWhere))
					{
						GlobalVars.rpt_array["where"] = MVCFunctions.Concat(GlobalVars.rpt_array["where"], (XVar.Pack(GlobalVars.rpt_array["where"]) ? XVar.Pack(MVCFunctions.Concat(" AND (", sWhere, ")")) : XVar.Pack(MVCFunctions.Concat(" WHERE (", sWhere, ")"))));
					}
					strSQL = XVar.Clone(MVCFunctions.Concat(GlobalVars.rpt_array["sql"], GlobalVars.rpt_array["where"], GlobalVars.rpt_array["order_by"]));
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_sql")] = GlobalVars.rpt_array["sql"];
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_where")] = GlobalVars.rpt_array["where"];
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_order")] = GlobalVars.rpt_array["order_by"];
				}
				xt.assign(new XVar("userid"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(Security.getUserName()))));
				xt.assign(new XVar("guest"), (XVar)(Security.isGuest()));
				if(XVar.Pack(CommonFunctions.is_wr_custom()))
				{
					if(CommonFunctions.GetDatabaseType() != Constants.nDATABASE_Oracle)
					{
						dynamic sqlquery = null;
						sqlquery = XVar.Clone(GlobalVars.rpt_array["sql"]);
						if(CommonFunctions.GetDatabaseType() == Constants.nDATABASE_MSSQLServer)
						{
							dynamic pos = null;
							pos = XVar.Clone(MVCFunctions.strrpos((XVar)(MVCFunctions.strtoupper((XVar)(sqlquery))), new XVar("ORDER BY")));
							if(XVar.Pack(pos))
							{
								sqlquery = XVar.Clone(MVCFunctions.substr((XVar)(sqlquery), new XVar(0), (XVar)(pos)));
							}
						}
						strSQL = XVar.Clone(MVCFunctions.Concat("select * from (", sqlquery, ") as ", _connection.addFieldWrappers(new XVar("t")), " ", GlobalVars.rpt_array["where"], GlobalVars.rpt_array["order_by"]));
					}
					else
					{
						strSQL = XVar.Clone(MVCFunctions.Concat("select * from (", GlobalVars.rpt_array["sql"], ")", GlobalVars.rpt_array["where"], GlobalVars.rpt_array["order_by"]));
					}
				}
				grid_row = XVar.Clone(XVar.Array());
				if(cross_table != "true")
				{
					dynamic PageSize = null, aGroupFields = XVar.Array(), aTotFields = XVar.Array(), align_skip = null, align_summary = XVar.Array(), arr = XVar.Array(), arr_alias = XVar.Array(), arr_group = XVar.Array(), arr_group_close = XVar.Array(), arr_group_field_colors = XVar.Array(), arr_group_fields = XVar.Array(), arr_group_headers = XVar.Array(), arr_group_headers_values = XVar.Array(), arr_group_summary = XVar.Array(), arr_not_group_fields = XVar.Array(), arr_page_order_fields = XVar.Array(), arr_value = null, arr_value_close = null, aval = null, avg = null, buf = null, color1 = null, color2 = null, firstnewgroup = null, globaltotals_count = null, globaltotals_dispmax = XVar.Array(), globaltotals_dispmin = XVar.Array(), globaltotals_max = XVar.Array(), globaltotals_min = XVar.Array(), globaltotals_sum = XVar.Array(), globaltotalsavg_count = XVar.Array(), group_count = null, group_kol = null, group_kol1 = null, group_name_ = null, groupno = null, groupstart = XVar.Array(), grouptotals_count = XVar.Array(), grouptotals_dispmax = XVar.Array(), grouptotals_dispmin = XVar.Array(), grouptotals_max = XVar.Array(), grouptotals_min = XVar.Array(), grouptotals_sum = XVar.Array(), grouptotalsavg_count = XVar.Array(), groupvalue = XVar.Array(), iteration = null, k = null, length = null, m = null, maxpages = null, mypage = null, name_ = null, newgroup = null, newgroup_ = XVar.Array(), ngFieldNames = null, num_uniq_outline = null, page_summary_fields_avg = XVar.Array(), page_summary_fields_max = XVar.Array(), page_summary_fields_min = XVar.Array(), page_summary_fields_sum = XVar.Array(), pageend = null, pagestart = null, pagetotals_count = null, pagetotals_dispmax = XVar.Array(), pagetotals_dispmin = XVar.Array(), pagetotals_max = XVar.Array(), pagetotals_min = XVar.Array(), pagetotals_sum = XVar.Array(), pagetotalsavg_count = XVar.Array(), row = XVar.Array(), rowclose = XVar.Array(), rowinfo = XVar.Array(), rs = null, start = null, sum = null, summary = XVar.Array(), sval = null;
					ProjectSettings pSet;
					groupno = new XVar(0);
					if(XVar.Pack(!(XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")])))
					{
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")] = 1;
					}
					if(XVar.Pack(!(XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")])))
					{
						if(0 < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1)
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")] = 5;
						}
						else
						{
							XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")] = 20;
						}
					}
					if((XVar)(modePrint)  && (XVar)(MVCFunctions.postvalue("all")))
					{
						PageSize = XVar.Clone(-1);
					}
					else
					{
						PageSize = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")]);
					}
					pagestart = XVar.Clone((XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")] - 1) * XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")] + 1);
					pageend = XVar.Clone((pagestart + XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagesize")]) - 1);
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
					{
						arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
						if(i == XVar.Pack(0))
						{
							grouptotals_count = XVar.Clone(XVar.Array());
							grouptotals_min = XVar.Clone(XVar.Array());
							grouptotals_max = XVar.Clone(XVar.Array());
							grouptotals_dispmin = XVar.Clone(XVar.Array());
							grouptotals_dispmax = XVar.Clone(XVar.Array());
							grouptotals_sum = XVar.Clone(XVar.Array());
							grouptotalsavg_count = XVar.Clone(XVar.Array());
						}
						grouptotals_sum.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotalsavg_count.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotals_min.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotals_max.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotals_dispmin.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotals_dispmax.InitAndSetArrayItem(XVar.Array(), arr["name"]);
						grouptotals_count.InitAndSetArrayItem(0, arr["name"]);
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if(XVar.Pack(fld.Value["show"]))
							{
								grouptotals_sum.InitAndSetArrayItem(0, arr["name"], fldname((XVar)(fld.Value)));
								grouptotalsavg_count.InitAndSetArrayItem(0, arr["name"], fldname((XVar)(fld.Value)));
							}
						}
					}
					summary = XVar.Clone(MVCFunctions.array_slice((XVar)(GlobalVars.rpt_array["group_fields"]), new XVar(-1)));
					if(XVar.Pack(summary[0]["sps"]))
					{
						xt.assign(new XVar("page_summary_block"), new XVar(true));
					}
					if(XVar.Pack(summary[0]["sgs"]))
					{
						xt.assign(new XVar("global_summary_block"), new XVar(true));
					}
					if(XVar.Pack(summary[0]["sds"]))
					{
						xt.assign(new XVar("details_summary_block"), new XVar(true));
					}
					if((XVar)(summary[0]["sps"])  && (XVar)(summary[0]["sgs"]))
					{
						xt.assign(new XVar("summary_footer"), new XVar(true));
					}
					if(XVar.Pack(summary[0]["sps"]))
					{
						pagetotals_count = new XVar(0);
						pagetotals_min = XVar.Clone(XVar.Array());
						pagetotals_max = XVar.Clone(XVar.Array());
						pagetotals_dispmin = XVar.Clone(XVar.Array());
						pagetotals_dispmax = XVar.Clone(XVar.Array());
						pagetotals_sum = XVar.Clone(XVar.Array());
						pagetotalsavg_count = XVar.Clone(XVar.Array());
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if(XVar.Pack(fld.Value["show"]))
							{
								pagetotals_sum.InitAndSetArrayItem(0, fldname((XVar)(fld.Value)));
								pagetotalsavg_count.InitAndSetArrayItem(0, fldname((XVar)(fld.Value)));
							}
						}
					}
					if(XVar.Pack(summary[0]["sgs"]))
					{
						globaltotals_count = new XVar(0);
						globaltotals_min = XVar.Clone(XVar.Array());
						globaltotals_max = XVar.Clone(XVar.Array());
						globaltotals_dispmin = XVar.Clone(XVar.Array());
						globaltotals_dispmax = XVar.Clone(XVar.Array());
						globaltotals_sum = XVar.Clone(XVar.Array());
						globaltotalsavg_count = XVar.Clone(XVar.Array());
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if(XVar.Pack(fld.Value["show"]))
							{
								globaltotals_sum.InitAndSetArrayItem(0, fldname((XVar)(fld.Value)));
								globaltotalsavg_count.InitAndSetArrayItem(0, fldname((XVar)(fld.Value)));
							}
						}
					}
					if(XVar.Pack(CommonFunctions.is_wr_project()))
					{
						dynamic dataSourse = null, sqlData = XVar.Array(), subsetDataCommand = null, tName = null;
						tName = XVar.Clone(GlobalVars.rpt_array["tables"][0]);
						dataSourse = XVar.Clone(CommonFunctions.getDataSource((XVar)(tName)));
						subsetDataCommand = XVar.Clone(CommonFunctions.getProjectWRSubsetDataCommand((XVar)(tName), (XVar)(GlobalVars.rpt_array["sort_fields"]), (XVar)(GlobalVars.gSettings), (XVar)(editmode)));
						sqlData = XVar.Clone(dataSourse.prepareSQL((XVar)(subsetDataCommand)));
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_sql")] = sqlData["sql"];
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_where")] = sqlData["where"];
						XSession.Session[MVCFunctions.Concat(sessPrefix, "_order")] = sqlData["order"];
						rs = XVar.Clone(dataSourse.getList((XVar)(subsetDataCommand)));
					}
					else
					{
						CommonFunctions.LogInfo((XVar)(strSQL));
						rs = XVar.Clone(_connection.query((XVar)(strSQL)));
					}
					start = new XVar(true);
					align_skip = new XVar(false);
					groupstart = XVar.Clone(XVar.Array());
					groupvalue = XVar.Clone(XVar.Array());
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
					{
						arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
						groupstart.InitAndSetArrayItem(0, arr["name"]);
						groupvalue.InitAndSetArrayItem("", arr["name"]);
					}
					rowinfo = XVar.Clone(XVar.Array());
					GlobalVars.fields_type = XVar.Clone(XVar.Array());
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						GlobalVars.fields_type = XVar.Clone(CommonFunctions.WRGetAllCustomFieldType());
					}
					pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(XSession.Session["webobject"]["table"]), new XVar(Constants.PAGE_REPORT)));
					viewControls = XVar.Clone(new ViewControlsContainer((XVar)(pSet), new XVar(Constants.PAGE_REPORT)));
					while(XVar.Pack(data = XVar.Clone(rs.fetchAssoc())))
					{
						firstnewgroup = new XVar(true);
						newgroup_ = XVar.Clone(XVar.Array());
						row = XVar.Clone(XVar.Array());
						arr_group = XVar.Clone(XVar.Array());
						arr_value = XVar.Clone(XVar.Array());
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
						{
							arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
							newgroup_.InitAndSetArrayItem(false, arr["name"]);
							arr_group.InitAndSetArrayItem(XVar.Array(), i);
							arr_group.InitAndSetArrayItem(false, i, "newgroup");
							arr_group.InitAndSetArrayItem(MVCFunctions.GoodFieldName((XVar)(arr["name"])), i, "name");
							arr_group.InitAndSetArrayItem(arr["group_order"], i, "group_order");
							arr_group.InitAndSetArrayItem(1 + 6 * (arr["group_order"] - 1), i, "groupId4");
							arr_group.InitAndSetArrayItem(arr["int_type"], i, "int_type");
							arr_group.InitAndSetArrayItem(arr["ss"], i, "ss");
							arr_group.InitAndSetArrayItem(arr["color1"], i, "color1");
							arr_group.InitAndSetArrayItem(arr["color2"], i, "color2");
						}
						newgroup = new XVar(false);
						if((XVar)(start)  || (XVar)(groupstart[GlobalVars.rpt_array["group_fields"][0]["name"]] != GetGroupStart((XVar)(GlobalVars.rpt_array["group_fields"][0]["name"]), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(GlobalVars.rpt_array["group_fields"][0]["name"]))))))))
						{
							newgroup_.InitAndSetArrayItem(true, GlobalVars.rpt_array["group_fields"][0]["name"]);
							newgroup = new XVar(true);
						}
						i = new XVar(1);
						for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
						{
							if((XVar)(newgroup)  || (XVar)(groupstart[GlobalVars.rpt_array["group_fields"][i]["name"]] != GetGroupStart((XVar)(GlobalVars.rpt_array["group_fields"][i]["name"]), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(GlobalVars.rpt_array["group_fields"][i]["name"]))))))))
							{
								newgroup_.InitAndSetArrayItem(true, GlobalVars.rpt_array["group_fields"][i]["name"]);
								newgroup = new XVar(true);
							}
						}
						rowclose = XVar.Clone(XVar.Array());
						arr_group_close = XVar.Clone(XVar.Array());
						arr_value_close = XVar.Clone(XVar.Array());
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
						{
							arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
							if((XVar)(editmode)  || (XVar)((XVar)(!(XVar)(start))  && (XVar)(newgroup_[arr["name"]])))
							{
								rowclose.InitAndSetArrayItem(true, MVCFunctions.Concat("endgroup_", MVCFunctions.GoodFieldName((XVar)(arr["name"]))));
								rowclose.InitAndSetArrayItem(groupvalue[arr["name"]], MVCFunctions.Concat("1", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_grval"));
								rowclose.InitAndSetArrayItem(grouptotals_count[arr["name"]], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total_cnt"));
								arr_group_close.InitAndSetArrayItem(MVCFunctions.GoodFieldName((XVar)(arr["name"])), i, "name");
								arr_group_close.InitAndSetArrayItem(arr["group_order"], i, "group_order");
								arr_group_close.InitAndSetArrayItem(arr["int_type"], i, "int_type");
								arr_group_close.InitAndSetArrayItem(arr["ss"], i, "ss");
								arr_group_close.InitAndSetArrayItem(arr["color1"], i, "color1");
								arr_group_close.InitAndSetArrayItem(arr["color2"], i, "color2");
								arr_group_close.InitAndSetArrayItem(true, i, "endgroup");
								arr_group_close.InitAndSetArrayItem(groupvalue[arr["name"]], i, "grval");
								arr_group_close.InitAndSetArrayItem(grouptotals_count[arr["name"]], i, "total_cnt");
								foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
								{
									if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["sum"]))
									{
										sum = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), grouptotals_sum[arr["name"]][fldname((XVar)(fld.Value))]));
										sval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(sum), new XVar("")));
										rowclose.InitAndSetArrayItem(sval, MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_sum"));
										arr_group_close.InitAndSetArrayItem(sval, i, "group_total_sum", "data", 0, fldname((XVar)(fld.Value)));
									}
								}
								if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar("avg"), new XVar("min"), new XVar("max"), new XVar("")))
								{
									if(XVar.Pack(grouptotals_count[arr["name"]]))
									{
										foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
										{
											if(XVar.Pack(fld.Value["show"]))
											{
												if(XVar.Pack(fld.Value["avg"]))
												{
													aval = new XVar("");
													if(XVar.Pack(grouptotalsavg_count[arr["name"]][fldname((XVar)(fld.Value))]))
													{
														avg = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), grouptotals_sum[arr["name"]][fldname((XVar)(fld.Value))] / grouptotalsavg_count[arr["name"]][fldname((XVar)(fld.Value))]));
														aval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(avg), new XVar("")));
													}
													rowclose.InitAndSetArrayItem(aval, MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_avg"));
													arr_group_close.InitAndSetArrayItem(aval, i, "group_total_avg", "data", 0, fldname((XVar)(fld.Value)));
												}
												if(XVar.Pack(fld.Value["min"]))
												{
													rowclose.InitAndSetArrayItem(grouptotals_dispmin[arr["name"]][fldname((XVar)(fld.Value))], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_min"));
													arr_group_close.InitAndSetArrayItem(grouptotals_dispmin[arr["name"]][fldname((XVar)(fld.Value))], i, "group_total_min", "data", 0, fldname((XVar)(fld.Value)));
												}
												if(XVar.Pack(fld.Value["max"]))
												{
													rowclose.InitAndSetArrayItem(grouptotals_dispmax[arr["name"]][fldname((XVar)(fld.Value))], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_max"));
													arr_group_close.InitAndSetArrayItem(grouptotals_dispmax[arr["name"]][fldname((XVar)(fld.Value))], i, "group_total_max", "data", 0, fldname((XVar)(fld.Value)));
												}
											}
										}
									}
								}
							}
						}
						if(XVar.Pack(!(XVar)(0 < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1)))
						{
							groupno++;
						}
						if((XVar)((XVar)(PageSize < XVar.Pack(0))  || (XVar)((XVar)(pagestart <= groupno)  && (XVar)(groupno <= pageend)))  && (XVar)(CommonFunctions.pre8count((XVar)(rowclose))))
						{
							rowclose.InitAndSetArrayItem(arr_group_close, "group", "data");
							rowclose.InitAndSetArrayItem(MVCFunctions.array_reverse((XVar)(arr_group_close)), "group_desc", "data");
							rowinfo.InitAndSetArrayItem(rowclose, null);
						}
						start = new XVar(false);
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
						{
							arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
							if(XVar.Pack(newgroup_[arr["name"]]))
							{
								dynamic groupdisplay = XVar.Array();
								if(i == XVar.Pack(0))
								{
									groupno++;
								}
								row.InitAndSetArrayItem(true, MVCFunctions.Concat("newgroup_", MVCFunctions.GoodFieldName((XVar)(arr["name"]))));
								arr_group.InitAndSetArrayItem(true, i, "newgroup");
								arr_group.InitAndSetArrayItem(firstnewgroup, i, "firstnewgroup");
								firstnewgroup = new XVar(false);
								groupstart.InitAndSetArrayItem(GetGroupStart((XVar)(arr["name"]), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(arr["name"])))))), arr["name"]);
								groupdisplay.InitAndSetArrayItem(GetGroupStart((XVar)(arr["name"]), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(arr["name"])))))), arr["name"]);
								groupvalue.InitAndSetArrayItem(GetGroupDisplay((XVar)(arr["name"]), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(arr["name"])))))), arr["name"]);
								row.InitAndSetArrayItem(groupvalue[arr["name"]], MVCFunctions.Concat("1", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_grval"));
								arr_group.InitAndSetArrayItem(MVCFunctions.runner_htmlspecialchars((XVar)(groupvalue[arr["name"]])), i, "grval");
								arr_group.InitAndSetArrayItem(1 + 6 * i, i, "groupId");
								grouptotals_count.InitAndSetArrayItem(0, arr["name"]);
								foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
								{
									if(XVar.Pack(fld.Value["show"]))
									{
										grouptotals_sum.InitAndSetArrayItem(0, arr["name"], fldname((XVar)(fld.Value)));
										grouptotalsavg_count.InitAndSetArrayItem(0, arr["name"], fldname((XVar)(fld.Value)));
									}
								}
							}
						}
						if((XVar)(PageSize < XVar.Pack(0))  || (XVar)((XVar)(pagestart <= groupno)  && (XVar)(groupno <= pageend)))
						{
							dynamic arrFields = XVar.Array(), arrKeys = XVar.Array(), bNoNewGroup = null, keylink = null;
							row.InitAndSetArrayItem(true, "row_data");
							keylink = new XVar("");
							arrKeys = XVar.Clone(GlobalVars.gSettings.getTableKeys());
							if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
							{
								dynamic arrKeysTbl = XVar.Array();
								arrKeysTbl = XVar.Clone(CommonFunctions.DBGetTableKeys((XVar)(GlobalVars.rpt_array["tables"][0])));
								arrKeys = XVar.Clone(XVar.Array());
								foreach (KeyValuePair<XVar, dynamic> _k in arrKeysTbl.GetEnumerator())
								{
									arrKeys.InitAndSetArrayItem(MVCFunctions.Concat(GlobalVars.rpt_array["tables"][0], ".", _k.Value), _k.Key);
								}
							}
							j = new XVar(0);
							for(;j < CommonFunctions.pre8count((XVar)(arrKeys)); j++)
							{
								keylink = MVCFunctions.Concat(keylink, "&key", j + 1, "=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(arrKeys[j])))))))));
							}
							arrFields = XVar.Clone(XVar.Array());
							foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
							{
								if(XVar.Pack(fld.Value["show"]))
								{
									dynamic value = null;
									value = new XVar("");
									if((XVar)(fld.Value["view_format"] == Constants.FORMAT_DATABASE_IMAGE)  && (XVar)(CommonFunctions.is_wr_project()))
									{
										if(render_mode != Constants.MODE_EXPORT)
										{
											if(XVar.Pack(fld.Value["show_thumbnail"]))
											{
												value = MVCFunctions.Concat(value, "<a target=_blank href=\"", MVCFunctions.GetTableLink(new XVar("imager")), "?table=", GlobalVars.rpt_array["short_table_name"], "&field=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fldname((XVar)(fld.Value)))))), "", keylink, "\">");
												value = MVCFunctions.Concat(value, "<img border=0");
												value = MVCFunctions.Concat(value, " src=\"", MVCFunctions.GetTableLink(new XVar("imager")), "?table=", GlobalVars.rpt_array["short_table_name"], "&field=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fld.Value["strThumbnail"])))), "", keylink, "&alt=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fldname((XVar)(fld.Value)))))), "\">");
												value = MVCFunctions.Concat(value, "</a>");
											}
											else
											{
												value = new XVar("<img");
												if(XVar.Pack(fld.Value["listformatobj_imgwidth"]))
												{
													value = MVCFunctions.Concat(value, " width=", fld.Value["listformatobj_imgwidth"]);
												}
												if(XVar.Pack(fld.Value["listformatobj_imgheight"]))
												{
													value = MVCFunctions.Concat(value, " height=", fld.Value["listformatobj_imgheight"]);
												}
												value = MVCFunctions.Concat(value, " border=0");
												value = MVCFunctions.Concat(value, " src=\"", MVCFunctions.GetTableLink(new XVar("imager")), "?table=", GlobalVars.rpt_array["short_table_name"], "&field=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fldname((XVar)(fld.Value)))))), "", keylink, "\">");
											}
										}
									}
									else
									{
										if((XVar)(fld.Value["view_format"] == Constants.FORMAT_DATABASE_IMAGE)  && (XVar)(!(XVar)(CommonFunctions.is_wr_project())))
										{
											if(render_mode != Constants.MODE_EXPORT)
											{
												if(XVar.Pack(CommonFunctions.is_wr_custom()))
												{
													value = new XVar("LONG BINARY DATA - CANNOT BE DISPLAYED");
												}
												else
												{
													value = new XVar("<img");
													value = MVCFunctions.Concat(value, " border=0");
													value = MVCFunctions.Concat(value, " src=\"", MVCFunctions.GetTableLink(new XVar("dimager")), "?rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(MVCFunctions.postvalue(new XVar("rname")))))), "&field=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fldname((XVar)(fld.Value)))))), "&alias=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(GlobalVars.arrDBFieldsList[MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value))))])))), keylink, "\">");
												}
											}
										}
										else
										{
											if(fld.Value["view_format"] == Constants.FORMAT_FILE_IMAGE)
											{
												if(render_mode != Constants.MODE_EXPORT)
												{
													if(XVar.Pack(CommonFunctions.CheckImageExtension((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))))))))
													{
														if(XVar.Pack(fld.Value["show_thumbnail"]))
														{
															dynamic thumbname = null;
															thumbname = XVar.Clone(MVCFunctions.Concat(fld.Value["thumbnail"], db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))))));
															if((XVar)(MVCFunctions.substr((XVar)(fld.Value["hlprefix"]), new XVar(0), new XVar(7)) != "http://")  && (XVar)(!(XVar)(MVCFunctions.file_exists((XVar)(MVCFunctions.getabspath((XVar)(MVCFunctions.Concat(fld.Value["hlprefix"], thumbname))))))))
															{
																thumbname = XVar.Clone(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))));
															}
															value = XVar.Clone(MVCFunctions.Concat("<a target=_blank href=\"", MVCFunctions.runner_htmlspecialchars((XVar)(CommonFunctions.AddLinkPrefix((XVar)(GlobalVars.gSettings), (XVar)(fldname((XVar)(fld.Value))), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))))), "\">"));
															value = MVCFunctions.Concat(value, "<img");
															if(thumbname == db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))
															{
																if(XVar.Pack(fld.Value["listformatobj_imgwidth"]))
																{
																	value = MVCFunctions.Concat(value, " width=", fld.Value["listformatobj_imgwidth"]);
																}
																if(XVar.Pack(fld.Value["listformatobj_imgheight"]))
																{
																	value = MVCFunctions.Concat(value, " height=", fld.Value["listformatobj_imgheight"]);
																}
															}
															value = MVCFunctions.Concat(value, " border=0");
															value = MVCFunctions.Concat(value, " src=\"", MVCFunctions.runner_htmlspecialchars((XVar)(CommonFunctions.AddLinkPrefix((XVar)(GlobalVars.gSettings), (XVar)(fldname((XVar)(fld.Value))), (XVar)(thumbname)))), "\"></a>");
														}
														else
														{
															value = new XVar("<img");
															if(XVar.Pack(fld.Value["listformatobj_imgwidth"]))
															{
																value = MVCFunctions.Concat(value, " width=", fld.Value["listformatobj_imgwidth"]);
															}
															if(XVar.Pack(fld.Value["listformatobj_imgheight"]))
															{
																value = MVCFunctions.Concat(value, " height=", fld.Value["listformatobj_imgheight"]);
															}
															value = MVCFunctions.Concat(value, " border=0");
															value = MVCFunctions.Concat(value, " src=\"", MVCFunctions.runner_htmlspecialchars((XVar)(CommonFunctions.AddLinkPrefix((XVar)(GlobalVars.gSettings), (XVar)(fldname((XVar)(fld.Value))), (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))))), "\">");
														}
													}
												}
											}
											else
											{
												if(fld.Value["view_format"] == Constants.FORMAT_DATABASE_FILE)
												{
													if(render_mode != Constants.MODE_EXPORT)
													{
														dynamic filename = null;
														if(XVar.Pack(fld.Value["listformatobj_filename"]))
														{
															filename = XVar.Clone(db_fld_value((XVar)(data), (XVar)(fld.Value["listformatobj_filename"])));
															if(XVar.Pack(!(XVar)(filename)))
															{
																filename = new XVar("file.bin");
															}
														}
														else
														{
															filename = new XVar("file.bin");
														}
														if(XVar.Pack(MVCFunctions.strlen((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))))))))
														{
															value = XVar.Clone(MVCFunctions.Concat("<a href=\"", MVCFunctions.GetTableLink((XVar)(GlobalVars.rpt_array["short_table_name"]), new XVar("getfile")), "?filename=", MVCFunctions.RawUrlEncode((XVar)(filename)), "&field=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(fldname((XVar)(fld.Value)))))), keylink, "\">"));
															value = MVCFunctions.Concat(value, MVCFunctions.runner_htmlspecialchars((XVar)(filename)));
															value = MVCFunctions.Concat(value, "</a>");
														}
													}
												}
												else
												{
													if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
													{
														value = XVar.Clone(CommonFunctions.WRProcessLargeText((XVar)(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar(""))), (XVar)(fldname((XVar)(fld.Value))), (XVar)(CommonFunctions.pre8count((XVar)(rowinfo))), new XVar(100), (XVar)(render_mode), (XVar)(fld.Value["label"])));
													}
													else
													{
														if((XVar)((XVar)(fld.Value["edit_format"] == Constants.EDIT_FORMAT_LOOKUP_WIZARD)  || (XVar)(fld.Value["edit_format"] == Constants.EDIT_FORMAT_RADIO))  && (XVar)((XVar)(fld.Value["lookupobj_lookuptype"] == Constants.LT_LOOKUPTABLE)  || (XVar)(fld.Value["lookupobj_lookuptype"] == Constants.LT_QUERY)))
														{
															if(XVar.Pack(!(XVar)(viewControls.viewControls[fldname((XVar)(fld.Value))])))
															{
																viewControls.viewControls.InitAndSetArrayItem(new ViewLookupWizardField((XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))), (XVar)(viewControls), new XVar(null)), fldname((XVar)(fld.Value)));
															}
															value = XVar.Clone(viewControls.showDBValue((XVar)(viewControls), (XVar)(data), (XVar)(keylink)));
														}
														else
														{
															if((XVar)((XVar)((XVar)((XVar)((XVar)(fld.Value["view_format"] != Constants.FORMAT_CUSTOM)  && (XVar)(fld.Value["view_format"] != Constants.FORMAT_FILE_IMAGE))  && (XVar)(fld.Value["view_format"] != Constants.FORMAT_FILE))  && (XVar)(fld.Value["view_format"] != Constants.FORMAT_HYPERLINK))  && (XVar)(fld.Value["view_format"] != Constants.FORMAT_EMAILHYPERLINK))  && (XVar)(fld.Value["view_format"] != Constants.FORMAT_CHECKBOX))
															{
																value = XVar.Clone(CommonFunctions.WRProcessLargeText((XVar)(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar(""))), (XVar)(fldname((XVar)(fld.Value))), (XVar)(CommonFunctions.pre8count((XVar)(rowinfo))), (XVar)(GlobalVars.gSettings.getNumberOfChars((XVar)(fldname((XVar)(fld.Value))))), (XVar)(render_mode), (XVar)(fld.Value["label"])));
															}
															else
															{
																value = XVar.Clone(viewControls.getControl((XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")));
															}
														}
													}
												}
											}
										}
									}
									if(XVar.Pack(summary[0]["sds"]))
									{
										row.InitAndSetArrayItem(value, MVCFunctions.Concat("1", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_value"));
										arrFields.InitAndSetArrayItem(value, "data", 0, fldname((XVar)(fld.Value)));
									}
									i = new XVar(0);
									for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
									{
										arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
										if((XVar)(summary[0]["sds"])  || (XVar)((XVar)(arr["name"] == fldname((XVar)(fld.Value)))  && (XVar)(arr["int_type"] == 0)))
										{
											if(XVar.Pack(summary[0]["sds"]))
											{
												arr_group.InitAndSetArrayItem(value, i, "value", "data", 0, fldname((XVar)(fld.Value)));
											}
											if((XVar)(arr["name"] == fldname((XVar)(fld.Value)))  && (XVar)(arr["int_type"] == 0))
											{
												if(XVar.Pack(row[MVCFunctions.Concat("newgroup_", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))))]))
												{
													row.InitAndSetArrayItem(value, MVCFunctions.Concat("1", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_grval"));
													groupvalue.InitAndSetArrayItem(value, fldname((XVar)(fld.Value)));
												}
											}
										}
									}
								}
							}
							i = new XVar(0);
							for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
							{
								arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
								foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
								{
									if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["sum"])  || (XVar)(fld.Value["avg"])))
									{
										grouptotals_sum[arr["name"]][fldname((XVar)(fld.Value))] += db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))));
										if(XVar.Pack(!(XVar)(XVar.Equals(XVar.Pack(db_fld_value((XVar)(data), (XVar)(fldname((XVar)(fld.Value))))), XVar.Pack(null)))))
										{
											grouptotalsavg_count[arr["name"]][fldname((XVar)(fld.Value))]++;
										}
									}
								}
								if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar("min"), new XVar("max"), new XVar("")))
								{
									if(XVar.Pack(!(XVar)(grouptotals_count[arr["name"]])))
									{
										foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
										{
											if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["min"]))
											{
												grouptotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), arr["name"], fldname((XVar)(fld.Value)));
												grouptotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), arr["name"], fldname((XVar)(fld.Value)));
											}
											if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["max"]))
											{
												grouptotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), arr["name"], fldname((XVar)(fld.Value)));
												grouptotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), arr["name"], fldname((XVar)(fld.Value)));
											}
										}
									}
									else
									{
										foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
										{
											if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["min"])  || (XVar)(fld.Value["max"])))
											{
												if(XVar.Pack(fld.Value["min"]))
												{
													if((XVar)((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) < grouptotals_min[arr["name"]][fldname((XVar)(fld.Value))])  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(grouptotals_min[arr["name"]][fldname((XVar)(fld.Value))] == ""))
													{
														grouptotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), arr["name"], fldname((XVar)(fld.Value)));
														grouptotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), arr["name"], fldname((XVar)(fld.Value)));
													}
												}
												if(XVar.Pack(fld.Value["max"]))
												{
													if((XVar)((XVar)(grouptotals_max[arr["name"]][fldname((XVar)(fld.Value))] < db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(grouptotals_max[arr["name"]][fldname((XVar)(fld.Value))] == ""))
													{
														grouptotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), arr["name"], fldname((XVar)(fld.Value)));
														grouptotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), arr["name"], fldname((XVar)(fld.Value)));
													}
												}
											}
										}
									}
								}
								grouptotals_count[arr["name"]]++;
							}
							if(XVar.Pack(summary[0]["sps"]))
							{
								foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
								{
									if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["sum"])  || (XVar)(fld.Value["avg"])))
									{
										pagetotals_sum[fldname((XVar)(fld.Value))] += db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))));
										if(XVar.Pack(!(XVar)(XVar.Equals(XVar.Pack(db_fld_value((XVar)(data), (XVar)(fldname((XVar)(fld.Value))))), XVar.Pack(null)))))
										{
											pagetotalsavg_count[fldname((XVar)(fld.Value))]++;
										}
									}
								}
								if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar("min"), new XVar("max"), new XVar("")))
								{
									if(XVar.Pack(!(XVar)(pagetotals_count)))
									{
										foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
										{
											if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["min"]))
											{
												pagetotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
												pagetotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
											}
											if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["max"]))
											{
												pagetotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
												pagetotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
											}
										}
									}
									else
									{
										foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
										{
											if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["min"])  || (XVar)(fld.Value["max"])))
											{
												if(XVar.Pack(fld.Value["min"]))
												{
													if((XVar)((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) < pagetotals_min[fldname((XVar)(fld.Value))])  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(pagetotals_min[fldname((XVar)(fld.Value))] == ""))
													{
														pagetotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
														pagetotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
													}
												}
												if(XVar.Pack(fld.Value["max"]))
												{
													if((XVar)((XVar)(pagetotals_max[fldname((XVar)(fld.Value))] < db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(pagetotals_max[fldname((XVar)(fld.Value))] == ""))
													{
														pagetotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
														pagetotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
													}
												}
											}
										}
									}
								}
								pagetotals_count++;
							}
							row.InitAndSetArrayItem(arr_group, "group", "data");
							row.InitAndSetArrayItem(MVCFunctions.array_reverse((XVar)(arr_group)), "group_desc", "data");
							row.InitAndSetArrayItem(arrFields, "totals");
							bNoNewGroup = new XVar(true);
							foreach (KeyValuePair<XVar, dynamic> groupItem in arr_group.GetEnumerator())
							{
								if(XVar.Pack(groupItem.Value["newgroup"]))
								{
									bNoNewGroup = new XVar(false);
									break;
								}
							}
							row.InitAndSetArrayItem(bNoNewGroup, "nonewgroup");
							rowinfo.InitAndSetArrayItem(row, null);
						}
						if(XVar.Pack(summary[0]["sgs"]))
						{
							foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
							{
								if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["sum"])  || (XVar)(fld.Value["avg"])))
								{
									globaltotals_sum[fldname((XVar)(fld.Value))] += db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value))))));
									if(XVar.Pack(!(XVar)(XVar.Equals(XVar.Pack(db_fld_value((XVar)(data), (XVar)(fldname((XVar)(fld.Value))))), XVar.Pack(null)))))
									{
										globaltotalsavg_count[fldname((XVar)(fld.Value))]++;
									}
								}
							}
							if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar("min"), new XVar("max"), new XVar("")))
							{
								if(XVar.Pack(!(XVar)(globaltotals_count)))
								{
									foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
									{
										if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["min"]))
										{
											globaltotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
											globaltotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
										}
										if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["max"]))
										{
											globaltotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
											globaltotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
										}
									}
								}
								else
								{
									foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
									{
										if((XVar)(fld.Value["show"])  && (XVar)((XVar)(fld.Value["min"])  || (XVar)(fld.Value["max"])))
										{
											if(XVar.Pack(fld.Value["min"]))
											{
												if((XVar)((XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) < globaltotals_min[fldname((XVar)(fld.Value))])  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(globaltotals_min[fldname((XVar)(fld.Value))] == ""))
												{
													globaltotals_min.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
													globaltotals_dispmin.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
												}
											}
											if(XVar.Pack(fld.Value["max"]))
											{
												if((XVar)((XVar)(globaltotals_max[fldname((XVar)(fld.Value))] < db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))))  && (XVar)(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))) != ""))  || (XVar)(globaltotals_max[fldname((XVar)(fld.Value))] == ""))
												{
													globaltotals_max.InitAndSetArrayItem(db_fld_value((XVar)(data), (XVar)(getDBFieldName((XVar)(fldname((XVar)(fld.Value)))))), fldname((XVar)(fld.Value)));
													globaltotals_dispmax.InitAndSetArrayItem(viewControls.getControl((XVar)(getDBFieldName((XVar)(gfldname((XVar)(fld.Value))))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(data), new XVar("")), fldname((XVar)(fld.Value)));
												}
											}
										}
									}
								}
							}
							globaltotals_count++;
						}
						if(XVar.Pack(editmode))
						{
							break;
						}
					}
					if((XVar)(PageSize < XVar.Pack(0))  || (XVar)((XVar)(pagestart <= groupno)  && (XVar)(groupno <= pageend)))
					{
						rowclose = XVar.Clone(XVar.Array());
						arr_group_close = XVar.Clone(XVar.Array());
						arr_value_close = XVar.Clone(XVar.Array());
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
						{
							arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
							rowclose.InitAndSetArrayItem(true, MVCFunctions.Concat("endgroup_", MVCFunctions.GoodFieldName((XVar)(arr["name"]))));
							rowclose.InitAndSetArrayItem(groupvalue[arr["name"]], MVCFunctions.Concat("1", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_grval"));
							rowclose.InitAndSetArrayItem(grouptotals_count[arr["name"]], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total_cnt"));
							arr_group_close.InitAndSetArrayItem(MVCFunctions.GoodFieldName((XVar)(arr["name"])), i, "name");
							arr_group_close.InitAndSetArrayItem(arr["group_order"], i, "group_order");
							arr_group_close.InitAndSetArrayItem(arr["int_type"], i, "int_type");
							arr_group_close.InitAndSetArrayItem(arr["ss"], i, "ss");
							arr_group_close.InitAndSetArrayItem(arr["color1"], i, "color1");
							arr_group_close.InitAndSetArrayItem(arr["color2"], i, "color2");
							arr_group_close.InitAndSetArrayItem(true, i, "endgroup");
							arr_group_close.InitAndSetArrayItem(groupvalue[arr["name"]], i, "grval");
							arr_group_close.InitAndSetArrayItem(grouptotals_count[arr["name"]], i, "total_cnt");
							foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
							{
								if((XVar)(fld.Value["show"])  && (XVar)(fld.Value["sum"]))
								{
									dynamic rval = null;
									sum = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), grouptotals_sum[arr["name"]][fldname((XVar)(fld.Value))]));
									rval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(sum), new XVar("")));
									rowclose.InitAndSetArrayItem(rval, MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_sum"));
									arr_group_close.InitAndSetArrayItem(rval, i, "group_total_sum", "data", 0, fldname((XVar)(fld.Value)));
								}
							}
							if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar("avg"), new XVar("min"), new XVar("max"), new XVar("")))
							{
								if(XVar.Pack(grouptotals_count[arr["name"]]))
								{
									foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
									{
										if(XVar.Pack(fld.Value["show"]))
										{
											if(XVar.Pack(fld.Value["avg"]))
											{
												aval = new XVar("");
												if(XVar.Pack(grouptotalsavg_count[arr["name"]][fldname((XVar)(fld.Value))]))
												{
													avg = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), grouptotals_sum[arr["name"]][fldname((XVar)(fld.Value))] / grouptotalsavg_count[arr["name"]][fldname((XVar)(fld.Value))]));
													aval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(avg), new XVar("")));
												}
												rowclose.InitAndSetArrayItem(aval, MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_avg"));
												arr_group_close.InitAndSetArrayItem(aval, i, "group_total_avg", "data", 0, fldname((XVar)(fld.Value)));
											}
											if(XVar.Pack(fld.Value["min"]))
											{
												rowclose.InitAndSetArrayItem(grouptotals_dispmin[arr["name"]][fldname((XVar)(fld.Value))], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_min"));
												arr_group_close.InitAndSetArrayItem(grouptotals_dispmin[arr["name"]][fldname((XVar)(fld.Value))], i, "group_total_min", "data", 0, fldname((XVar)(fld.Value)));
											}
											if(XVar.Pack(fld.Value["max"]))
											{
												rowclose.InitAndSetArrayItem(grouptotals_dispmax[arr["name"]][fldname((XVar)(fld.Value))], MVCFunctions.Concat("group", MVCFunctions.GoodFieldName((XVar)(arr["name"])), "_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_max"));
												arr_group_close.InitAndSetArrayItem(grouptotals_dispmax[arr["name"]][fldname((XVar)(fld.Value))], i, "group_total_max", "data", 0, fldname((XVar)(fld.Value)));
											}
										}
									}
								}
							}
						}
						if(XVar.Pack(CommonFunctions.pre8count((XVar)(rowclose))))
						{
							rowclose.InitAndSetArrayItem(arr_group_close, "group", "data");
							rowclose.InitAndSetArrayItem(MVCFunctions.array_reverse((XVar)(arr_group_close)), "group_desc", "data");
							rowinfo.InitAndSetArrayItem(rowclose, null);
						}
					}
					if(XVar.Pack(summary[0]["sps"]))
					{
						xt.assign(new XVar("page_total_cnt"), (XVar)(pagetotals_count));
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if(XVar.Pack(fld.Value["show"]))
							{
								if(XVar.Pack(fld.Value["sum"]))
								{
									sum = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), pagetotals_sum[fldname((XVar)(fld.Value))]));
									sval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(sum), new XVar("")));
									xt.assign((XVar)(MVCFunctions.Concat("page_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_sum")), (XVar)(sval));
									GlobalVars.rpt_array.InitAndSetArrayItem(sval, "totals", fld.Key, "page_total_sum");
								}
								if((XVar)((XVar)(fld.Value["avg"])  || (XVar)(fld.Value["min"]))  || (XVar)(fld.Value["max"]))
								{
									if(XVar.Pack(pagetotals_count))
									{
										if(XVar.Pack(fld.Value["avg"]))
										{
											aval = new XVar("");
											if(XVar.Pack(pagetotalsavg_count[fldname((XVar)(fld.Value))]))
											{
												avg = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), pagetotals_sum[fldname((XVar)(fld.Value))] / pagetotalsavg_count[fldname((XVar)(fld.Value))]));
												aval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(avg), new XVar("")));
											}
											xt.assign((XVar)(MVCFunctions.Concat("page_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_avg")), (XVar)(aval));
											GlobalVars.rpt_array.InitAndSetArrayItem(aval, "totals", fld.Key, "page_total_avg");
										}
										if(XVar.Pack(fld.Value["min"]))
										{
											xt.assign((XVar)(MVCFunctions.Concat("page_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_min")), (XVar)(pagetotals_dispmin[fldname((XVar)(fld.Value))]));
											GlobalVars.rpt_array.InitAndSetArrayItem(pagetotals_dispmin[fldname((XVar)(fld.Value))], "totals", fld.Key, "page_total_min");
										}
										if(XVar.Pack(fld.Value["max"]))
										{
											xt.assign((XVar)(MVCFunctions.Concat("page_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_max")), (XVar)(pagetotals_dispmax[fldname((XVar)(fld.Value))]));
											GlobalVars.rpt_array.InitAndSetArrayItem(pagetotals_dispmax[fldname((XVar)(fld.Value))], "totals", fld.Key, "page_total_max");
										}
									}
								}
							}
						}
					}
					if(XVar.Pack(summary[0]["sgs"]))
					{
						xt.assign(new XVar("global_total_cnt"), (XVar)(globaltotals_count));
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if(XVar.Pack(fld.Value["show"]))
							{
								if(XVar.Pack(fld.Value["sum"]))
								{
									sum = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), globaltotals_sum[fldname((XVar)(fld.Value))]));
									sval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(sum), new XVar("")));
									xt.assign((XVar)(MVCFunctions.Concat("global_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_sum")), (XVar)(sval));
									GlobalVars.rpt_array.InitAndSetArrayItem(sval, "totals", fld.Key, "global_total_sum");
								}
								if((XVar)((XVar)(fld.Value["avg"])  || (XVar)(fld.Value["min"]))  || (XVar)(fld.Value["max"]))
								{
									if(XVar.Pack(globaltotals_count))
									{
										if(XVar.Pack(fld.Value["avg"]))
										{
											aval = new XVar("");
											if(XVar.Pack(globaltotalsavg_count[fldname((XVar)(fld.Value))]))
											{
												avg = XVar.Clone(new XVar(fldname((XVar)(fld.Value)), globaltotals_sum[fldname((XVar)(fld.Value))] / globaltotalsavg_count[fldname((XVar)(fld.Value))]));
												aval = XVar.Clone(viewControls.getControl((XVar)(fldname((XVar)(fld.Value))), (XVar)(fld.Value["view_format"])).showDBValue((XVar)(avg), new XVar("")));
											}
											xt.assign((XVar)(MVCFunctions.Concat("global_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_avg")), (XVar)(aval));
											GlobalVars.rpt_array.InitAndSetArrayItem(aval, "totals", fld.Key, "global_total_avg");
										}
										if(XVar.Pack(fld.Value["min"]))
										{
											xt.assign((XVar)(MVCFunctions.Concat("global_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_min")), (XVar)(globaltotals_dispmin[fldname((XVar)(fld.Value))]));
											GlobalVars.rpt_array.InitAndSetArrayItem(globaltotals_dispmin[fldname((XVar)(fld.Value))], "totals", fld.Key, "global_total_min");
										}
										if(XVar.Pack(fld.Value["max"]))
										{
											xt.assign((XVar)(MVCFunctions.Concat("global_total", MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld.Value)))), "_max")), (XVar)(globaltotals_dispmax[fldname((XVar)(fld.Value))]));
											GlobalVars.rpt_array.InitAndSetArrayItem(globaltotals_dispmax[fldname((XVar)(fld.Value))], "totals", fld.Key, "global_total_max");
										}
									}
								}
							}
						}
					}
					if(XVar.Pack(groupno))
					{
						xt.assign(new XVar("rowsfound"), new XVar(true));
					}
					mypage = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_pagenumber")]);
					maxpages = XVar.Clone((XVar)Math.Ceiling((double)(groupno / PageSize)));
					if(1 < maxpages)
					{
						xt.assign(new XVar("pagination"), (XVar)(MVCFunctions.Concat("<div id=\"pagination1\"></div>\r\n\t\t\t<script language=\"JavaScript\">WritePagination(", mypage, ",", maxpages, ", 1);\r\n\t\t\t\tfunction GotoPage(nPageNumber){\r\n\t\t\t\t\twindow.location='", MVCFunctions.GetTableLink(new XVar("dreport")), "?rname=", MVCFunctions.postvalue(new XVar("rname")), "&goto='+nPageNumber;\r\n\t\t\t\t}\r\n\t\t\t</script>")));
					}
					if(0 < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1)
					{
						xt.assign(new XVar("gpp1_selected"), (XVar)((XVar.Pack(PageSize == 1) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp3_selected"), (XVar)((XVar.Pack(PageSize == 3) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp5_selected"), (XVar)((XVar.Pack(PageSize == 5) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp10_selected"), (XVar)((XVar.Pack(PageSize == 10) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp50_selected"), (XVar)((XVar.Pack(PageSize == 50) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp100_selected"), (XVar)((XVar.Pack(PageSize == 100) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp0_selected"), (XVar)((XVar.Pack(PageSize == -1) ? XVar.Pack("selected") : XVar.Pack(""))));
					}
					else
					{
						xt.assign(new XVar("rpp10_selected"), (XVar)((XVar.Pack(PageSize == 10) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("rpp20_selected"), (XVar)((XVar.Pack(PageSize == 20) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("rpp50_selected"), (XVar)((XVar.Pack(PageSize == 50) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("rpp100_selected"), (XVar)((XVar.Pack(PageSize == 100) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("rpp500_selected"), (XVar)((XVar.Pack(PageSize == 500) ? XVar.Pack("selected") : XVar.Pack(""))));
						xt.assign(new XVar("gpp0_selected"), (XVar)((XVar.Pack(PageSize == -1) ? XVar.Pack("selected") : XVar.Pack(""))));
					}
					foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
					{
						GlobalVars.rpt_array.InitAndSetArrayItem(MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.rpt_array["totals"][fld.Key]["label"])), "totals", fld.Key, "label");
					}
					aGroupFields = XVar.Clone(XVar.Array());
					ngFieldNames = XVar.Clone(XVar.Array());
					arr_page_order_fields = XVar.Clone(XVar.Array());
					arr_not_group_fields = XVar.Clone(XVar.Array());
					arr_group_fields = XVar.Clone(XVar.Array());
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
					{
						aGroupFields.InitAndSetArrayItem(GlobalVars.rpt_array["group_fields"][i]["name"], null);
					}
					aTotFields = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
					{
						aTotFields.InitAndSetArrayItem(fldname((XVar)(fld.Value)), null);
					}
					ngFieldNames = XVar.Clone(MVCFunctions.array_diff((XVar)(aTotFields), (XVar)(aGroupFields)));
					arr_alias = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> gr_name in aGroupFields.GetEnumerator())
					{
						foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
						{
							if((XVar)(gr_name.Value == fldname((XVar)(fld.Value)))  && (XVar)(!(XVar)(MVCFunctions.in_array((XVar)(fldname((XVar)(fld.Value))), (XVar)(arr_alias)))))
							{
								arr_alias.InitAndSetArrayItem(fldname((XVar)(fld.Value)), null);
								arr_page_order_fields.InitAndSetArrayItem(fld.Value, "data", null);
							}
						}
					}
					foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(fldname((XVar)(fld.Value))), (XVar)(ngFieldNames))))
						{
							arr_page_order_fields.InitAndSetArrayItem(fld.Value, "data", null);
							if(XVar.Pack(fld.Value["show"]))
							{
								arr_not_group_fields.InitAndSetArrayItem(fld.Value, null);
							}
						}
						if((XVar)(GlobalVars.rpt_array["miscellaneous"]["type"] == "outline")  && (XVar)(MVCFunctions.in_array((XVar)(fldname((XVar)(fld.Value))), (XVar)(aGroupFields))))
						{
							arr_group_fields.InitAndSetArrayItem(fld.Value, "data", null);
						}
					}
					foreach (KeyValuePair<XVar, dynamic> value in arr_page_order_fields["data"].GetEnumerator())
					{
						arr_page_order_fields.InitAndSetArrayItem(value.Key + 1, "data", value.Key, "fieldId");
					}
					align_summary = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> value in arr_not_group_fields.GetEnumerator())
					{
						arr_not_group_fields.InitAndSetArrayItem(value.Key + 1, value.Key, "fieldId4");
					}
					align_summary.InitAndSetArrayItem(arr_not_group_fields, "data");
					if(GlobalVars.rpt_array["miscellaneous"]["type"] != "outline")
					{
						xt.assignbyref(new XVar("page_order_fields"), (XVar)(arr_page_order_fields));
					}
					else
					{
						foreach (KeyValuePair<XVar, dynamic> value in arr_group_fields["data"].GetEnumerator())
						{
							arr_group_fields.InitAndSetArrayItem(value.Key + 1, "data", value.Key, "fieldId");
						}
						xt.assignbyref(new XVar("group_page_order_fields"), (XVar)(arr_group_fields));
						xt.assignbyref(new XVar("page_order_fields"), (XVar)(align_summary));
					}
					xt.assignbyref(new XVar("not_group_fields"), (XVar)(align_summary));
					arr_group_field_colors = XVar.Clone(XVar.Array());
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
					{
						iteration = XVar.Clone(i + 1);
						color1 = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]["color1"]);
						color2 = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]["color2"]);
						arr_group_field_colors.InitAndSetArrayItem(new XVar("iteration", iteration, "color1", color1, "color2", color2), "data", null);
					}
					xt.assignbyref(new XVar("group_field_colors"), (XVar)(arr_group_field_colors));
					xt.assign(new XVar("groupFieldsCnt"), (XVar)(CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1));
					if(1 < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])))
					{
						xt.assign(new XVar("groups_per_page_block"), new XVar(true));
					}
					else
					{
						xt.assign(new XVar("records_per_page_block"), new XVar(true));
					}
					xt.assign(new XVar("testAgr"), (XVar)(testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar(""))));
					xt.assign(new XVar("align_testAgr"), (XVar)((testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("")) - CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"]))) + 1));
					if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("")))
					{
						xt.assign(new XVar("aggregation_block"), new XVar(true));
					}
					xt.assign(new XVar("testAgrMin"), (XVar)(testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar("min"), new XVar(""), new XVar(""))));
					if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar("min"), new XVar(""), new XVar("")))
					{
						xt.assign(new XVar("min_aggregation_block"), new XVar(true));
					}
					xt.assign(new XVar("testAgrSum"), (XVar)(testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("sum"))));
					if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("sum")))
					{
						xt.assign(new XVar("sum_aggregation_block"), new XVar(true));
					}
					xt.assign(new XVar("testAgrAvg"), (XVar)(testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar("avg"), new XVar(""), new XVar(""), new XVar(""))));
					if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar("avg"), new XVar(""), new XVar(""), new XVar("")))
					{
						xt.assign(new XVar("avg_aggregation_block"), new XVar(true));
					}
					xt.assign(new XVar("testAgrMax"), (XVar)(testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar("max"), new XVar(""))));
					if(0 < testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar("max"), new XVar("")))
					{
						xt.assign(new XVar("max_aggregation_block"), new XVar(true));
					}
					i = new XVar(0);
					for(;i < CommonFunctions.pre8count((XVar)(rowinfo)); i++)
					{
						num_uniq2++;
						length = new XVar(0);
						group_kol = XVar.Clone(CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])));
						group_kol1 = XVar.Clone(group_kol);
						if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
						{
							group_kol1 = new XVar(0);
						}
						group_count = new XVar(0);
						if(XVar.Pack(!(XVar)(rowinfo[i]["not_group_fields_values"])))
						{
							rowinfo.InitAndSetArrayItem(new XVar("data", XVar.Array()), i, "not_group_fields_values");
						}
						k = new XVar(0);
						for(;k < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); k++)
						{
							name_ = XVar.Clone(arr_not_group_fields[k]["name"]);
							if(XVar.Pack(CommonFunctions.is_wr_db()))
							{
								name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[k]["table"], ".", arr_not_group_fields[k]["name"]));
							}
							if(GlobalVars.rpt_array["miscellaneous"]["type"] != "align")
							{
								while(XVar.Pack(!(XVar)(arr_page_order_fields["data"][group_count + group_kol1]["show"])))
								{
									group_count++;
								}
							}
							group_count++;
							rowinfo.InitAndSetArrayItem(XVar.Array(), i, "not_group_fields_values", "data", length);
							rowinfo.InitAndSetArrayItem(group_count + group_kol1, i, "not_group_fields_values", "data", length, "fieldNum");
							if(XVar.Pack(rowinfo[i].KeyExists("totals")))
							{
								rowinfo.InitAndSetArrayItem(rowinfo[i]["totals"]["data"][0][name_], i, "not_group_fields_values", "data", length, "field_value");
								if((XVar)(GlobalVars.rpt_array["miscellaneous"]["type"] == "outline")  || (XVar)(GlobalVars.rpt_array["miscellaneous"]["type"] == "align"))
								{
									rowinfo.InitAndSetArrayItem(arr_not_group_fields[k]["label"], i, "not_group_fields_values", "data", length, "field_label");
								}
							}
							length = XVar.Clone(CommonFunctions.pre8count((XVar)(rowinfo[i]["not_group_fields_values"]["data"])));
						}
						if(GlobalVars.rpt_array["miscellaneous"]["type"] == "block")
						{
							if((XVar)(summary[0]["sds"])  && (XVar)(rowinfo[i]["nonewgroup"]))
							{
								rowinfo.InitAndSetArrayItem(true, i, "no_newgroup_block");
							}
						}
						j = new XVar(0);
						for(;j < CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])); j++)
						{
							num_uniq++;
							arr_group_headers = XVar.Clone(new XVar("data", XVar.Array()));
							rowinfo.InitAndSetArrayItem(j + 1, i, "group", "data", j, "iteration");
							rowinfo.InitAndSetArrayItem(2 + j * 6, i, "group", "data", j, "groupIdCo");
							rowinfo.InitAndSetArrayItem(4, i, "group", "data", j, "group_in_uniq");
							if(GlobalVars.rpt_array["miscellaneous"]["type"] == "outline")
							{
								rowinfo.InitAndSetArrayItem(5, i, "group", "data", j, "group_in_uniq_outline");
							}
							group_name_ = XVar.Clone(rowinfo[i]["group"]["data"][j]["name"]);
							rowinfo.InitAndSetArrayItem(rowinfo[i]["group"]["data"][j]["value"]["data"][0][group_name_], i, "group", "data", j, "group_field_value");
							if(XVar.Pack(rowinfo[i]["group"]["data"][j]["int_type"]))
							{
								rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "group_level");
							}
							else
							{
								rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "default_level");
							}
							if(1 < rowinfo[i]["group"]["data"][j]["group_order"])
							{
								rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "right_border");
							}
							else
							{
								rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "left_border");
							}
							if(GlobalVars.rpt_array["miscellaneous"]["type"] == "stepped")
							{
								if(XVar.Pack(rowinfo[i]["group"]["data"][j]["newgroup"]))
								{
									buf = new XVar("");
									if(j == XVar.Pack(0))
									{
										foreach (KeyValuePair<XVar, dynamic> arr_field_info in arr_page_order_fields["data"].GetEnumerator())
										{
											if(XVar.Pack(arr_field_info.Value["show"]))
											{
												buf = MVCFunctions.Concat(buf, "<td fieldname=\"", arr_field_info.Key + 1, "\" groupname=\"", Constants.FieldHeaders, "\" class=\"class", Constants.FieldHeaders, "g class", arr_field_info.Key + 1, "f class", Constants.FieldHeaders, "g", arr_field_info.Key + 1, "f0u\">", arr_field_info.Value["label"], "</td>\n");
											}
										}
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "first_group_block");
										rowinfo.InitAndSetArrayItem(buf, i, "group", "data", j, "first_group_html");
									}
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])); k++)
									{
										arr_group_headers_values = XVar.Clone(XVar.Array());
										arr_group_headers_values.InitAndSetArrayItem(k + 1, "fieldId");
										if(rowinfo[i]["group"]["data"][k]["name"] == rowinfo[i]["group"]["data"][j]["name"])
										{
											arr_group_headers_values.InitAndSetArrayItem(true, "groups_equal_block");
											arr_group_headers_values.InitAndSetArrayItem((testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("")) - rowinfo[i]["group"]["data"][j]["group_order"]) + 1, "head_colspan");
										}
										else
										{
											if(rowinfo[i]["group"]["data"][k]["group_order"] < rowinfo[i]["group"]["data"][j]["group_order"])
											{
												arr_group_headers_values.InitAndSetArrayItem(true, "groups_order_block");
												arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["group_order"], "head_group_order");
												arr_group_headers_values.InitAndSetArrayItem(k + 1, "fieldId");
												arr_group_headers_values.InitAndSetArrayItem(2 + (rowinfo[i]["group"]["data"][k]["group_order"] - 1) * 6, "groupId");
												arr_group_headers_values.InitAndSetArrayItem(j, "group_in_uniq");
											}
										}
										if(0 < CommonFunctions.pre8count((XVar)(arr_group_headers_values)))
										{
											arr_group_headers.InitAndSetArrayItem(arr_group_headers_values, "data", null);
										}
									}
									rowinfo.InitAndSetArrayItem(arr_group_headers, i, "group", "data", j, "group_headers");
								}
							}
							if(GlobalVars.rpt_array["miscellaneous"]["type"] == "block")
							{
								if((XVar)(rowinfo[i]["group"]["data"][j]["int_type"])  && (XVar)(summary[0]["sds"]))
								{
									rowinfo.InitAndSetArrayItem(rowinfo[i]["group"]["data"][j]["value"]["data"][0][group_name_], i, "group", "data", j, "field_value");
								}
								else
								{
									rowinfo.InitAndSetArrayItem("&nbsp;", i, "group", "data", j, "field_value");
								}
								if((XVar)(rowinfo[i]["group"]["data"][j]["newgroup"])  && (XVar)(rowinfo[i]["group"]["data"][j]["firstnewgroup"]))
								{
									dynamic group_name_2_ = null;
									rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "first_newgroup");
									buf = new XVar("");
									if(j == XVar.Pack(0))
									{
										foreach (KeyValuePair<XVar, dynamic> arr_field_info in arr_page_order_fields["data"].GetEnumerator())
										{
											if(XVar.Pack(arr_field_info.Value["show"]))
											{
												buf = MVCFunctions.Concat(buf, "<td fieldname=\"", arr_field_info.Key + 1, "\" groupname=\"", Constants.FieldHeaders, "\" class=\"class", Constants.FieldHeaders, "g class", arr_field_info.Key + 1, "f class", Constants.FieldHeaders, "g", arr_field_info.Key + 1, "f0u\">", arr_field_info.Value["label"], "</td>\n");
											}
										}
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "first_group_block");
										rowinfo.InitAndSetArrayItem(buf, i, "group", "data", j, "first_group_html");
									}
									m = new XVar(0);
									for(;m < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); m++)
									{
										name_ = XVar.Clone(arr_not_group_fields[m]["name"]);
										if(XVar.Pack(CommonFunctions.is_wr_db()))
										{
											name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[m]["table"], ".", arr_not_group_fields[m]["name"]));
										}
										if(XVar.Pack(summary[0]["sds"]))
										{
											if(XVar.Pack(rowinfo[i].KeyExists("totals")))
											{
												rowinfo.InitAndSetArrayItem(new XVar("field_value", rowinfo[i]["totals"]["data"][0][name_]), i, "not_group_fields_values_block", "data", null);
											}
										}
										else
										{
											rowinfo.InitAndSetArrayItem(new XVar("field_value", "&nbsp;"), i, "not_group_fields_values_block", "data", null);
										}
										rowinfo.InitAndSetArrayItem(++(group_kol1), i, "not_group_fields_values_block", "data", CommonFunctions.pre8count((XVar)(rowinfo[i]["not_group_fields_values_block"]["data"])) - 1, "fieldNum");
									}
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])); k++)
									{
										arr_group_headers_values = XVar.Clone(XVar.Array());
										arr_group_headers_values.InitAndSetArrayItem(k + 1, "fieldId");
										arr_group_headers_values.InitAndSetArrayItem(1 + 6 * k, "groupId2");
										arr_group_headers_values.InitAndSetArrayItem(2 + 6 * k, "groupId3");
										arr_group_headers_values.InitAndSetArrayItem(j + 1, "group2_in_uniq");
										group_name_2_ = XVar.Clone(rowinfo[i]["group"]["data"][k]["name"]);
										if(rowinfo[i]["group"]["data"][j]["group_order"] <= rowinfo[i]["group"]["data"][k]["group_order"])
										{
											arr_group_headers_values.InitAndSetArrayItem(true, "true_groups_order_block");
											arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["group_order"], "group2_group_order");
											arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["grval"], "group2_grval");
											if((XVar)(rowinfo[i]["group"]["data"][k]["int_type"])  && (XVar)(summary[0]["sds"]))
											{
												arr_group_headers_values.InitAndSetArrayItem(true, "groups_sds_block");
												arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["value"]["data"][0][group_name_2_], "group2_field_value");
											}
										}
										else
										{
											arr_group_headers_values.InitAndSetArrayItem(true, "false_groups_order_block");
											arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["group_order"], "group2_group_order");
											if((XVar)(rowinfo[i]["group"]["data"][k]["int_type"])  && (XVar)(summary[0]["sds"]))
											{
												arr_group_headers_values.InitAndSetArrayItem(true, "groups_sds_block");
												arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["value"]["data"][0][group_name_2_], "group2_field_value");
											}
											else
											{
												arr_group_headers_values.InitAndSetArrayItem(true, "groups_sds_block_else");
											}
										}
										if(0 < CommonFunctions.pre8count((XVar)(arr_group_headers_values)))
										{
											arr_group_headers.InitAndSetArrayItem(arr_group_headers_values, "data", null);
										}
									}
									rowinfo.InitAndSetArrayItem(arr_group_headers, i, "group", "data", j, "group_headers");
								}
							}
							if(GlobalVars.rpt_array["miscellaneous"]["type"] == "outline")
							{
								if(XVar.Pack(rowinfo[i]["group"]["data"][j]["newgroup"]))
								{
									rowinfo.InitAndSetArrayItem((testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("")) - rowinfo[i]["group"]["data"][j]["group_order"]) + 1, i, "group", "data", j, "head_colspan");
									arr_group_headers_values.InitAndSetArrayItem(1 + 6 * k, "groupId4");
									foreach (KeyValuePair<XVar, dynamic> arr_field_info in arr_page_order_fields["data"].GetEnumerator())
									{
										if(gfldname((XVar)(arr_field_info.Value)) == group_name_)
										{
											rowinfo.InitAndSetArrayItem(arr_field_info.Value["label"], i, "group", "data", j, "group_label");
										}
									}
									if(j == XVar.Pack(0))
									{
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "first_group_block");
									}
									if(j == CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])) - 1)
									{
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "last_group_block");
									}
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])); k++)
									{
										arr_group_headers_values.InitAndSetArrayItem(k + 1, "fieldId");
										arr_group_headers_values = XVar.Clone(XVar.Array());
										arr_group_headers_values.InitAndSetArrayItem(rowinfo[i]["group"]["data"][k]["group_order"], "group2_group_order");
										arr_group_headers_values.InitAndSetArrayItem(j, "group2_in_uniq");
										arr_group_headers_values.InitAndSetArrayItem(1 + 6 * k, "groupId2");
										arr_group_headers_values.InitAndSetArrayItem(2 + 6 * k, "groupId3");
										if(rowinfo[i]["group"]["data"][k]["group_order"] < rowinfo[i]["group"]["data"][j]["group_order"])
										{
											arr_group_headers_values.InitAndSetArrayItem(true, "groups_order_block");
										}
										if(0 < CommonFunctions.pre8count((XVar)(arr_group_headers_values)))
										{
											arr_group_headers.InitAndSetArrayItem(arr_group_headers_values, "data", null);
										}
									}
									rowinfo.InitAndSetArrayItem(arr_group_headers, i, "group", "data", j, "group_headers");
								}
							}
							if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
							{
								if(XVar.Pack(rowinfo[i]["group"]["data"][j]["newgroup"]))
								{
									foreach (KeyValuePair<XVar, dynamic> arr_field_info in arr_page_order_fields["data"].GetEnumerator())
									{
										if(gfldname((XVar)(arr_field_info.Value)) == group_name_)
										{
											rowinfo.InitAndSetArrayItem(arr_field_info.Value["label"], i, "group", "data", j, "group_label");
										}
										rowinfo.InitAndSetArrayItem(arr_field_info.Key + 1, i, "group", "data", j, "fieldId");
									}
									if(j == XVar.Pack(0))
									{
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "first_group_block");
									}
									if(j == CommonFunctions.pre8count((XVar)(rowinfo[i]["group"]["data"])) - 1)
									{
										rowinfo.InitAndSetArrayItem(true, i, "group", "data", j, "last_group_block");
									}
								}
							}
						}
						arr_group_summary = XVar.Clone(XVar.Array());
						num_uniq_outline = new XVar(0);
						j = new XVar(0);
						for(;j < CommonFunctions.pre8count((XVar)(rowinfo[i]["group_desc"]["data"])); j++)
						{
							group_name_ = XVar.Clone(rowinfo[i]["group_desc"]["data"][j]["name"]);
							if((XVar)(rowinfo[i]["group_desc"]["data"][j]["ss"])  && (XVar)(rowinfo[i]["group_desc"]["data"][j]["endgroup"]))
							{
								dynamic field_name_ = null, group_summary_fields_avg = XVar.Array(), group_summary_fields_max = XVar.Array(), group_summary_fields_min = XVar.Array(), group_summary_fields_sum = XVar.Array(), group_summary_totals = XVar.Array(), td_columns = null;
								group_summary_fields_sum = XVar.Clone(XVar.Array());
								num_uniq2++;
								if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); k++)
									{
										group_summary_fields_sum.InitAndSetArrayItem(XVar.Array(), k);
										group_summary_fields_sum.InitAndSetArrayItem(k + 1, k, "iteration");
										group_summary_fields_sum.InitAndSetArrayItem(5 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdSum");
										group_summary_fields_sum.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
										name_ = XVar.Clone(arr_not_group_fields[k]["name"]);
										if(XVar.Pack(CommonFunctions.is_wr_db()))
										{
											name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[k]["table"], ".", arr_not_group_fields[k]["name"]));
										}
										if(k == XVar.Pack(0))
										{
											group_summary_fields_sum.InitAndSetArrayItem(true, k, "first_block");
										}
										else
										{
											group_summary_fields_sum.InitAndSetArrayItem(true, k, "not_first_block");
										}
										if(XVar.Pack(arr_not_group_fields[k]["sum"]))
										{
											group_summary_fields_sum.InitAndSetArrayItem(true, k, "sum_field_flag");
											group_summary_fields_sum.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_sum"]["data"][0][name_], k, "group_total_sum_value");
										}
									}
								}
								else
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); k++)
									{
										field_name_ = XVar.Clone(fldname((XVar)(arr_page_order_fields["data"][k])));
										group_summary_fields_sum.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(arr_page_order_fields["data"][k]["show"]))
										{
											group_summary_fields_sum.InitAndSetArrayItem(k + 1, k, "iteration");
											group_summary_fields_sum.InitAndSetArrayItem(5 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdSum");
											group_summary_fields_sum.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
											group_summary_fields_sum.InitAndSetArrayItem(num_uniq2 - 4, k, "group_in_uniq_block");
											if(MVCFunctions.GoodFieldName((XVar)(field_name_)) == group_name_)
											{
												group_summary_fields_sum.InitAndSetArrayItem(true, k, "group_field_flag");
												group_summary_fields_sum.InitAndSetArrayItem("", k, "left_border");
												if(1 < rowinfo[i]["group_desc"]["data"][j]["group_order"])
												{
													group_summary_fields_sum.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
												}
											}
											else
											{
												if(XVar.Pack(arr_page_order_fields["data"][k]["sum"]))
												{
													group_summary_fields_sum.InitAndSetArrayItem(true, k, "sum_field_flag");
													group_summary_fields_sum.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_sum"]["data"][0][field_name_], k, "group_total_sum_value");
												}
												else
												{
													if(k < rowinfo[i]["group_desc"]["data"][j]["group_order"])
													{
														group_summary_fields_sum.InitAndSetArrayItem(2 + k * 6, k, "groupIdSum");
														group_summary_fields_sum.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
														group_summary_fields_sum.InitAndSetArrayItem(2 + j * 6, k, "groupIdSum3");
														group_summary_fields_sum.InitAndSetArrayItem(true, k, "border_flag");
														if(XVar.Pack(0) < k)
														{
															group_summary_fields_sum.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
														}
														else
														{
															group_summary_fields_sum.InitAndSetArrayItem("border-left:solid 1px #cccccc;", k, "left_border");
														}
													}
													else
													{
														group_summary_fields_sum.InitAndSetArrayItem(true, k, "default_flag");
													}
												}
											}
										}
									}
								}
								if(0 < CommonFunctions.pre8count((XVar)(group_summary_fields_sum)))
								{
									rowinfo.InitAndSetArrayItem(group_summary_fields_sum, i, "group_desc", "data", j, "group_summary_fields_sum", "data");
								}
								num_uniq2++;
								group_summary_fields_avg = XVar.Clone(XVar.Array());
								if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); k++)
									{
										name_ = XVar.Clone(arr_not_group_fields[k]["name"]);
										group_summary_fields_avg.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(CommonFunctions.is_wr_db()))
										{
											name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[k]["table"], ".", arr_not_group_fields[k]["name"]));
										}
										group_summary_fields_avg.InitAndSetArrayItem(6 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdAvg");
										group_summary_fields_avg.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
										group_summary_fields_avg.InitAndSetArrayItem(k + 1, k, "iteration");
										if(k == XVar.Pack(0))
										{
											group_summary_fields_avg.InitAndSetArrayItem(true, k, "first_block");
										}
										else
										{
											group_summary_fields_avg.InitAndSetArrayItem(true, k, "not_first_block");
										}
										if(XVar.Pack(arr_not_group_fields[k]["avg"]))
										{
											group_summary_fields_avg.InitAndSetArrayItem(true, k, "avg_field_flag");
											group_summary_fields_avg.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_avg"]["data"][0][name_], k, "group_total_avg_value");
										}
									}
								}
								else
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); k++)
									{
										field_name_ = XVar.Clone(fldname((XVar)(arr_page_order_fields["data"][k])));
										group_summary_fields_avg.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(arr_page_order_fields["data"][k]["show"]))
										{
											group_summary_fields_avg.InitAndSetArrayItem(6 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdAvg");
											group_summary_fields_avg.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
											group_summary_fields_avg.InitAndSetArrayItem(num_uniq2 - 4, k, "group_in_uniq_block");
											group_summary_fields_avg.InitAndSetArrayItem(k + 1, k, "iteration");
											if(MVCFunctions.GoodFieldName((XVar)(field_name_)) == group_name_)
											{
												group_summary_fields_avg.InitAndSetArrayItem(true, k, "group_field_flag");
												group_summary_fields_avg.InitAndSetArrayItem("", k, "left_border");
												if(1 < rowinfo[i]["group_desc"]["data"][j]["group_order"])
												{
													group_summary_fields_avg.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
												}
											}
											else
											{
												if(XVar.Pack(arr_page_order_fields["data"][k]["avg"]))
												{
													group_summary_fields_avg.InitAndSetArrayItem(true, k, "avg_field_flag");
													group_summary_fields_avg.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_avg"]["data"][0][field_name_], k, "group_total_avg_value");
												}
												else
												{
													if(k < rowinfo[i]["group_desc"]["data"][j]["group_order"])
													{
														group_summary_fields_avg.InitAndSetArrayItem(2 + k * 6, k, "groupIdAvg");
														group_summary_fields_avg.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
														group_summary_fields_avg.InitAndSetArrayItem(2 + j * 6, k, "groupIdAvg3");
														group_summary_fields_avg.InitAndSetArrayItem(true, k, "border_flag");
														if(XVar.Pack(0) < k)
														{
															group_summary_fields_avg.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
														}
														else
														{
															group_summary_fields_avg.InitAndSetArrayItem("border-left:solid 1px #cccccc;", k, "left_border");
														}
													}
													else
													{
														group_summary_fields_avg.InitAndSetArrayItem(true, k, "default_flag");
													}
												}
											}
										}
									}
								}
								if(0 < CommonFunctions.pre8count((XVar)(group_summary_fields_avg)))
								{
									rowinfo.InitAndSetArrayItem(group_summary_fields_avg, i, "group_desc", "data", j, "group_summary_fields_avg", "data");
								}
								num_uniq2++;
								group_summary_fields_min = XVar.Clone(XVar.Array());
								if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); k++)
									{
										group_summary_fields_min.InitAndSetArrayItem(XVar.Array(), k);
										name_ = XVar.Clone(arr_not_group_fields[k]["name"]);
										if(XVar.Pack(CommonFunctions.is_wr_db()))
										{
											name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[k]["table"], ".", arr_not_group_fields[k]["name"]));
										}
										group_summary_fields_min.InitAndSetArrayItem(k + 1, k, "iteration");
										group_summary_fields_min.InitAndSetArrayItem(3 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdMin");
										group_summary_fields_min.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
										if(k == XVar.Pack(0))
										{
											group_summary_fields_min.InitAndSetArrayItem(true, k, "first_block");
										}
										else
										{
											group_summary_fields_min.InitAndSetArrayItem(true, k, "not_first_block");
										}
										if(XVar.Pack(arr_not_group_fields[k]["min"]))
										{
											group_summary_fields_min.InitAndSetArrayItem(true, k, "min_field_flag");
											group_summary_fields_min.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_min"]["data"][0][name_], k, "group_total_min_value");
										}
									}
								}
								else
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); k++)
									{
										field_name_ = XVar.Clone(fldname((XVar)(arr_page_order_fields["data"][k])));
										group_summary_fields_min.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(arr_page_order_fields["data"][k]["show"]))
										{
											group_summary_fields_min.InitAndSetArrayItem(k + 1, k, "iteration");
											group_summary_fields_min.InitAndSetArrayItem(3 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdMin");
											group_summary_fields_min.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
											group_summary_fields_min.InitAndSetArrayItem(num_uniq2 - 4, k, "group_in_uniq_block");
											if(MVCFunctions.GoodFieldName((XVar)(field_name_)) == group_name_)
											{
												group_summary_fields_min.InitAndSetArrayItem(true, k, "group_field_flag");
												group_summary_fields_min.InitAndSetArrayItem("", k, "left_border");
												if(1 < rowinfo[i]["group_desc"]["data"][j]["group_order"])
												{
													group_summary_fields_min.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
												}
											}
											else
											{
												if(XVar.Pack(arr_page_order_fields["data"][k]["min"]))
												{
													group_summary_fields_min.InitAndSetArrayItem(true, k, "min_field_flag");
													group_summary_fields_min.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_min"]["data"][0][field_name_], k, "group_total_min_value");
												}
												else
												{
													if(k < rowinfo[i]["group_desc"]["data"][j]["group_order"])
													{
														group_summary_fields_min.InitAndSetArrayItem(2 + k * 6, k, "groupIdMin");
														group_summary_fields_min.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
														group_summary_fields_min.InitAndSetArrayItem(2 + j * 6, k, "groupIdMin3");
														group_summary_fields_min.InitAndSetArrayItem(true, k, "border_flag");
														if(XVar.Pack(0) < k)
														{
															group_summary_fields_min.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
														}
														else
														{
															group_summary_fields_min.InitAndSetArrayItem("border-left:solid 1px #cccccc;", k, "left_border");
														}
													}
													else
													{
														group_summary_fields_min.InitAndSetArrayItem(true, k, "default_flag");
													}
												}
											}
										}
									}
								}
								if(0 < CommonFunctions.pre8count((XVar)(group_summary_fields_min)))
								{
									rowinfo.InitAndSetArrayItem(group_summary_fields_min, i, "group_desc", "data", j, "group_summary_fields_min", "data");
								}
								num_uniq2++;
								group_summary_fields_max = XVar.Clone(XVar.Array());
								if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); k++)
									{
										name_ = XVar.Clone(arr_not_group_fields[k]["name"]);
										group_summary_fields_max.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(CommonFunctions.is_wr_db()))
										{
											name_ = XVar.Clone(MVCFunctions.Concat(arr_not_group_fields[k]["table"], ".", arr_not_group_fields[k]["name"]));
										}
										group_summary_fields_max.InitAndSetArrayItem(k + 1, k, "iteration");
										group_summary_fields_max.InitAndSetArrayItem(4 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdMax");
										group_summary_fields_max.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
										if(k == XVar.Pack(0))
										{
											group_summary_fields_max.InitAndSetArrayItem(true, k, "first_block");
										}
										else
										{
											group_summary_fields_max.InitAndSetArrayItem(true, k, "not_first_block");
										}
										if(XVar.Pack(arr_not_group_fields[k]["max"]))
										{
											group_summary_fields_max.InitAndSetArrayItem(true, k, "max_field_flag");
											group_summary_fields_max.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_max"]["data"][0][name_], k, "group_total_max_value");
										}
									}
								}
								else
								{
									k = new XVar(0);
									for(;k < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); k++)
									{
										field_name_ = XVar.Clone(fldname((XVar)(arr_page_order_fields["data"][k])));
										group_summary_fields_max.InitAndSetArrayItem(XVar.Array(), k);
										if(XVar.Pack(arr_page_order_fields["data"][k]["show"]))
										{
											group_summary_fields_max.InitAndSetArrayItem(k + 1, k, "iteration");
											group_summary_fields_max.InitAndSetArrayItem(4 + ((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) * 6, k, "groupIdMax");
											group_summary_fields_max.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
											group_summary_fields_max.InitAndSetArrayItem(num_uniq2 - 4, k, "group_in_uniq_block");
											if(MVCFunctions.GoodFieldName((XVar)(field_name_)) == group_name_)
											{
												group_summary_fields_max.InitAndSetArrayItem(true, k, "group_field_flag");
												group_summary_fields_max.InitAndSetArrayItem("", k, "left_border");
												if(1 < rowinfo[i]["group_desc"]["data"][j]["group_order"])
												{
													group_summary_fields_max.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
												}
											}
											else
											{
												if(XVar.Pack(arr_page_order_fields["data"][k]["max"]))
												{
													group_summary_fields_max.InitAndSetArrayItem(true, k, "max_field_flag");
													group_summary_fields_max.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j]["group_total_max"]["data"][0][field_name_], k, "group_total_max_value");
												}
												else
												{
													if(k < rowinfo[i]["group_desc"]["data"][j]["group_order"])
													{
														group_summary_fields_max.InitAndSetArrayItem(2 + k * 6, k, "groupIdMax");
														group_summary_fields_max.InitAndSetArrayItem(num_uniq2, k, "group_in_uniq");
														group_summary_fields_max.InitAndSetArrayItem(2 + j * 6, k, "groupIdMax3");
														group_summary_fields_max.InitAndSetArrayItem(true, k, "border_flag");
														if(XVar.Pack(0) < k)
														{
															group_summary_fields_max.InitAndSetArrayItem("border-left:1px solid black;", k, "left_border");
														}
														else
														{
															group_summary_fields_max.InitAndSetArrayItem("border-left:solid 1px #cccccc;", k, "left_border");
														}
													}
													else
													{
														group_summary_fields_max.InitAndSetArrayItem(true, k, "default_flag");
													}
												}
											}
										}
									}
								}
								if(0 < CommonFunctions.pre8count((XVar)(group_summary_fields_max)))
								{
									rowinfo.InitAndSetArrayItem(group_summary_fields_max, i, "group_desc", "data", j, "group_summary_fields_max", "data");
								}
								group_summary_totals = XVar.Clone(XVar.Array());
								k = new XVar(0);
								for(;k < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); k++)
								{
									if(gfldname((XVar)(arr_page_order_fields["data"][k])) == rowinfo[i]["group_desc"]["data"][j]["name"])
									{
										dynamic group_order_ = null;
										group_summary_totals.InitAndSetArrayItem(XVar.Array(), k);
										group_order_ = XVar.Clone(rowinfo[i]["group_desc"]["data"][j]["group_order"]);
										if(1 < group_order_)
										{
											group_summary_totals.InitAndSetArrayItem(true, k, "left_border");
										}
										group_summary_totals.InitAndSetArrayItem((testAgr((XVar)(GlobalVars.rpt_array["totals"]), new XVar(""), new XVar(""), new XVar(""), new XVar("")) - group_order_) + 1, k, "colspan_expr");
										group_summary_totals.InitAndSetArrayItem(arr_page_order_fields["data"][k]["label"], k, "label");
										group_summary_totals.InitAndSetArrayItem(((CommonFunctions.pre8count((XVar)(rowinfo[0]["group"]["data"])) - 1) - j) + 36, k, "groupIdSummary");
									}
								}
								if(0 < CommonFunctions.pre8count((XVar)(group_summary_totals)))
								{
									rowinfo.InitAndSetArrayItem(group_summary_totals, i, "group_desc", "data", j, "group_summary_totals", "data");
								}
								td_columns = new XVar("");
								num_uniq2++;
								num_uniq_outline++;
								m = new XVar(0);
								for(;m < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - (j + 2); m++)
								{
									if(GlobalVars.rpt_array["miscellaneous"]["type"] == "block")
									{
										td_columns = MVCFunctions.Concat(td_columns, "<td class=\"group_", m + 1, " class", 2 + m * 6, "g class", m + 1, "f class", 2 + m * 6, "g", m + 1, "f", num_uniq2 - 9, "u\" groupname=\"", 2 + m * 6, "\" fieldname=\"", m + 1, "\" uniqe=\"", num_uniq2 - 9, "\" style=\"border-style:none; border-left:1px solid #000; border-right:1px solid #000;");
									}
									else
									{
										td_columns = MVCFunctions.Concat(td_columns, "<td class=\"group_", m + 1, " class", 2 + m * 6, "g class", m + 1, "f class", 2 + m * 6, "g", m + 1, "f", num_uniq2 - 5, "u\" groupname=\"", 2 + m * 6, "\" fieldname=\"", m + 1, "\" uniqe=\"", num_uniq2 - 5, "\" style=\"border-style:none; border-left:1px solid #000; border-right:1px solid #000;");
									}
									if(GlobalVars.rpt_array["miscellaneous"]["type"] != "block")
									{
										if(1 < m)
										{
											td_columns = MVCFunctions.Concat(td_columns, "border-left:1px solid black;");
										}
										else
										{
											td_columns = MVCFunctions.Concat(td_columns, "border-left:1px solid #ccc;");
										}
									}
									td_columns = MVCFunctions.Concat(td_columns, "\"></td>");
								}
								if(td_columns != XVar.Pack(""))
								{
									rowinfo.InitAndSetArrayItem(td_columns, i, "group_desc", "data", j, "td_columns");
								}
								arr_group_summary.InitAndSetArrayItem(rowinfo[i]["group_desc"]["data"][j], null);
							}
						}
						if(XVar.Pack(arr_group_summary))
						{
							rowinfo.InitAndSetArrayItem(arr_group_summary, i, "group_summary_block", "data");
						}
						rowinfo[i].Remove("group_desc");
					}
					if(XVar.Pack(rowinfo))
					{
						if(XVar.Pack(!(XVar)(rowinfo[0]["group"]["data"])))
						{
							buf = new XVar("");
							foreach (KeyValuePair<XVar, dynamic> arr_field_info in arr_page_order_fields["data"].GetEnumerator())
							{
								if(XVar.Pack(arr_field_info.Value["show"]))
								{
									buf = MVCFunctions.Concat(buf, "<td fieldname=\"", arr_field_info.Key + 1, "\" groupname=\"", Constants.FieldHeaders, "\" class=\"class", Constants.FieldHeaders, "g class", arr_field_info.Key + 1, "f class", Constants.FieldHeaders, "g", arr_field_info.Key + 1, "f0u\">", arr_field_info.Value["label"], "</td>\n");
								}
							}
							rowinfo.InitAndSetArrayItem(true, 0, "newgroup");
							rowinfo.InitAndSetArrayItem(true, 0, "group", "data", 0, "first_group_block");
							rowinfo.InitAndSetArrayItem(buf, 0, "group", "data", 0, "first_group_html");
						}
					}
					page_summary_fields_sum = XVar.Clone(XVar.Array());
					page_summary_fields_avg = XVar.Clone(XVar.Array());
					page_summary_fields_min = XVar.Clone(XVar.Array());
					page_summary_fields_max = XVar.Clone(XVar.Array());
					if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); i++)
						{
							page_summary_fields_sum.InitAndSetArrayItem(arr_not_group_fields[i], "data", i);
							page_summary_fields_sum.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(i == XVar.Pack(0))
							{
								page_summary_fields_sum.InitAndSetArrayItem(true, "data", i, "first_field_flag");
							}
							if(XVar.Pack(page_summary_fields_sum["data"][i]["sum"]))
							{
								page_summary_fields_sum.InitAndSetArrayItem(true, "data", i, "sum_field_flag");
							}
						}
					}
					else
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); i++)
						{
							page_summary_fields_sum.InitAndSetArrayItem(arr_page_order_fields["data"][i], "data", i);
							page_summary_fields_sum.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(XVar.Pack(page_summary_fields_sum["data"][i]["show"]))
							{
								if(i == XVar.Pack(0))
								{
									page_summary_fields_sum.InitAndSetArrayItem(true, "data", i, "first_field_flag");
								}
								else
								{
									if(XVar.Pack(page_summary_fields_sum["data"][i]["sum"]))
									{
										page_summary_fields_sum.InitAndSetArrayItem(true, "data", i, "sum_field_flag");
									}
									else
									{
										page_summary_fields_sum.InitAndSetArrayItem(true, "data", i, "default_flag");
									}
								}
							}
						}
					}
					if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); i++)
						{
							page_summary_fields_avg.InitAndSetArrayItem(arr_not_group_fields[i], "data", i);
							page_summary_fields_avg.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(i == XVar.Pack(0))
							{
								page_summary_fields_avg.InitAndSetArrayItem(true, "data", i, "first_field_flag");
							}
							if(XVar.Pack(page_summary_fields_avg["data"][i]["avg"]))
							{
								page_summary_fields_avg.InitAndSetArrayItem(true, "data", i, "avg_field_flag");
							}
						}
					}
					else
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); i++)
						{
							page_summary_fields_avg.InitAndSetArrayItem(arr_page_order_fields["data"][i], "data", i);
							page_summary_fields_avg.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(XVar.Pack(page_summary_fields_avg["data"][i]["show"]))
							{
								if(i == XVar.Pack(0))
								{
									page_summary_fields_avg.InitAndSetArrayItem(true, "data", i, "first_field_flag");
								}
								else
								{
									if(XVar.Pack(page_summary_fields_avg["data"][i]["avg"]))
									{
										page_summary_fields_avg.InitAndSetArrayItem(true, "data", i, "avg_field_flag");
									}
									else
									{
										page_summary_fields_avg.InitAndSetArrayItem(true, "data", i, "default_flag");
									}
								}
							}
						}
					}
					if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); i++)
						{
							page_summary_fields_min.InitAndSetArrayItem(arr_not_group_fields[i], "data", i);
							page_summary_fields_min.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(i == XVar.Pack(0))
							{
								page_summary_fields_min.InitAndSetArrayItem(true, "data", i, "first_field_flag");
							}
							if(XVar.Pack(page_summary_fields_min["data"][i]["min"]))
							{
								page_summary_fields_min.InitAndSetArrayItem(true, "data", i, "min_field_flag");
							}
						}
					}
					else
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); i++)
						{
							page_summary_fields_min.InitAndSetArrayItem(arr_page_order_fields["data"][i], "data", i);
							page_summary_fields_min.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(XVar.Pack(page_summary_fields_min["data"][i]["show"]))
							{
								if(i == XVar.Pack(0))
								{
									page_summary_fields_min.InitAndSetArrayItem(true, "data", i, "first_field_flag");
								}
								else
								{
									if(XVar.Pack(page_summary_fields_min["data"][i]["min"]))
									{
										page_summary_fields_min.InitAndSetArrayItem(true, "data", i, "min_field_flag");
									}
									else
									{
										page_summary_fields_min.InitAndSetArrayItem(true, "data", i, "default_flag");
									}
								}
							}
						}
					}
					if(GlobalVars.rpt_array["miscellaneous"]["type"] == "align")
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_not_group_fields)); i++)
						{
							page_summary_fields_max.InitAndSetArrayItem(arr_not_group_fields[i], "data", i);
							page_summary_fields_max.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(i == XVar.Pack(0))
							{
								page_summary_fields_max.InitAndSetArrayItem(true, "data", i, "first_field_flag");
							}
							if(XVar.Pack(page_summary_fields_max["data"][i]["max"]))
							{
								page_summary_fields_max.InitAndSetArrayItem(true, "data", i, "max_field_flag");
							}
						}
					}
					else
					{
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_page_order_fields["data"])); i++)
						{
							page_summary_fields_max.InitAndSetArrayItem(arr_page_order_fields["data"][i], "data", i);
							page_summary_fields_max.InitAndSetArrayItem(i + 1, "data", i, "fieldId");
							if(XVar.Pack(page_summary_fields_max["data"][i]["show"]))
							{
								if(i == XVar.Pack(0))
								{
									page_summary_fields_max.InitAndSetArrayItem(true, "data", i, "first_field_flag");
								}
								else
								{
									if(XVar.Pack(page_summary_fields_max["data"][i]["max"]))
									{
										page_summary_fields_max.InitAndSetArrayItem(true, "data", i, "max_field_flag");
									}
									else
									{
										page_summary_fields_max.InitAndSetArrayItem(true, "data", i, "default_flag");
									}
								}
							}
						}
					}
					xt.assignbyref(new XVar("page_summary_fields_sum"), (XVar)(page_summary_fields_sum));
					xt.assignbyref(new XVar("page_summary_fields_avg"), (XVar)(page_summary_fields_avg));
					xt.assignbyref(new XVar("page_summary_fields_min"), (XVar)(page_summary_fields_min));
					xt.assignbyref(new XVar("page_summary_fields_max"), (XVar)(page_summary_fields_max));
					grid_row.InitAndSetArrayItem(rowinfo, "data");
				}
				else
				{
					if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("edit")))))
					{
						dynamic arr_res = XVar.Array(), cross_array = XVar.Array(), first_field = null, res = null;
						cross_array = XVar.Clone(new XVar("tables", GlobalVars.rpt_array["tables"], "group_fields", GlobalVars.rpt_array["group_fields"], "totals", GlobalVars.rpt_array["totals"], "table_type", GlobalVars.rpt_array["table_type"], "wrdb", CommonFunctions.is_wr_db(), "arrDBFieldsList", GlobalVars.arrDBFieldsList));
						if(XVar.Pack(CommonFunctions.is_wr_project()))
						{
							cross_array.InitAndSetArrayItem(GlobalVars.rpt_array["sort_fields"], "sort_fields");
						}
						crosstableObj = XVar.Clone(new CrossTableWebReport((XVar)(cross_array), (XVar)(strSQL)));
						if(XVar.Pack(MVCFunctions.postvalue(new XVar("crosstable_refresh"))))
						{
							crosstableObj.ajax_refresh_crosstable((XVar)(MVCFunctions.GetTableLink(new XVar("dreport"), new XVar(""), (XVar)(MVCFunctions.Concat("rname=", MVCFunctions.postvalue(new XVar("rname")))))));
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
						xt.assign(new XVar("select_group_x"), (XVar)(MVCFunctions.Concat("<select id=select_group_x onchange=\"refresh_group('", MVCFunctions.postvalue(new XVar("rname")), "', '", reportFilename, "');\">", crosstableObj.getGroupFields(new XVar("x")), "</select>")));
						xt.assign(new XVar("select_group_y"), (XVar)(MVCFunctions.Concat("<select id=select_group_y onchange=\"refresh_group('", MVCFunctions.postvalue(new XVar("rname")), "', '", reportFilename, "');\">", crosstableObj.getGroupFields(new XVar("y")), "</select>")));
						grid_row.InitAndSetArrayItem(crosstableObj.getCrossTableData(), "data");
						arr_res = XVar.Clone(crosstableObj.getValuesControl());
						res = XVar.Clone(arr_res[0]);
						first_field = XVar.Clone(arr_res[1]);
						if(XVar.Pack(res))
						{
							dynamic group_func = null;
							xt.assign(new XVar("data_value"), new XVar(true));
							xt.assign(new XVar("select_data"), (XVar)(MVCFunctions.Concat("<select name=select_data id=select_data onchange=\"refresh_crosstable('", reportFilename, "?rname=", MVCFunctions.postvalue(new XVar("rname")), "');return false;\">", res, "</select>")));
							xt.assign(new XVar("group_func"), (XVar)(crosstableObj.getRadioGroupFunctions((XVar)(MVCFunctions.Concat(reportFilename, "?rname=", MVCFunctions.postvalue(new XVar("rname")))))));
							group_func = XVar.Clone(crosstableObj.getTotalsName((XVar)(crosstableObj.getCurrentGroupFunction())));
							xt.assign(new XVar("totals"), (XVar)(group_func));
						}
						if(XVar.Pack(grid_row["data"]))
						{
							dynamic sum_x = null, sum_y = null;
							xt.assign(new XVar("grid_row"), (XVar)(grid_row));
							xt.assignbyref(new XVar("group_header"), (XVar)(crosstableObj.getCrossTableHeader()));
							sum_x = XVar.Clone(GlobalVars.rpt_array["group_fields"][CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1]["sum_x"]);
							sum_y = XVar.Clone(GlobalVars.rpt_array["group_fields"][CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1]["sum_y"]);
							if(XVar.Pack(sum_y))
							{
								xt.assign(new XVar("td_row_summary"), new XVar(true));
							}
							if(XVar.Pack(sum_x))
							{
								xt.assign(new XVar("td_col_summary"), new XVar(true));
							}
							if((XVar)(sum_x)  && (XVar)(sum_y))
							{
								xt.assign(new XVar("td_total_summary"), new XVar(true));
							}
							xt.assignbyref(new XVar("col_summary"), (XVar)(crosstableObj.getCrossTableSummary()));
							xt.assignbyref(new XVar("total_summary"), (XVar)(crosstableObj.getTotalSummary()));
						}
					}
				}
				xt.assign(new XVar("grid_block"), new XVar(true));
				if(XVar.Pack(grid_row["data"]))
				{
					xt.assign(new XVar("data_block"), new XVar(true));
					xt.assignbyref(new XVar("grid_row"), (XVar)(grid_row));
					xt.assign(new XVar("records_display_block"), new XVar(true));
				}
				else
				{
					xt.assign(new XVar("message_block"), new XVar(true));
					xt.assign(new XVar("message"), new XVar("No results found."));
				}
				xt.assign(new XVar("top_menu_block"), new XVar(true));
				strSQL = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_sql")]);
				preview = new XVar("");
				if((XVar)(cross_table == "true")  && (XVar)(modePrint))
				{
					xt.assign(new XVar("report_cross_header"), (XVar)(crosstableObj.getPrintCrossHeader()));
				}
				if(XVar.Pack(GlobalVars.rpt_array["miscellaneous"]["print_friendly"]))
				{
					xt.assign(new XVar("print_friendly_block"), new XVar(true));
				}
				if(XVar.Pack(CommonFunctions.testAdvSearch((XVar)(GlobalVars.rpt_array["tables"][0]))))
				{
					xt.assign(new XVar("adv_search_block"), new XVar(true));
				}
				reportName = new XVar("");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("rname"))))
				{
					reportName = XVar.Clone(MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("rname")))));
				}
				else
				{
					reportName = XVar.Clone(MVCFunctions.runner_htmlspecialchars((XVar)(XSession.Session["webreports"]["settings"]["name"])));
				}
				xt.assign(new XVar("reportName"), (XVar)(reportName));
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("q"))))
				{
					xt.assign(new XVar("searchClause"), (XVar)(MVCFunctions.Concat("&q=", MVCFunctions.postvalue(new XVar("q")))));
				}
				xt.assign(new XVar("reportNamejs"), (XVar)(CommonFunctions.jsreplace((XVar)(MVCFunctions.postvalue(new XVar("rname"))))));
				xt.assign(new XVar("reportTitle"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.rpt_array["settings"]["title"]))));
				xt.assign(new XVar("shortTableName"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.rpt_array["short_table_name"]))));
				xt.assign(new XVar("shortTableNamejs"), (XVar)(CommonFunctions.jsreplace((XVar)(GlobalVars.rpt_array["short_table_name"]))));
				searchType = XVar.Clone((XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())) ? XVar.Pack(MVCFunctions.GetTableLink(new XVar("dsearch"))) : XVar.Pack(MVCFunctions.GetTableLink((XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.rpt_array["short_table_name"]))), new XVar("search")))));
				xt.assign(new XVar("searchHref"), (XVar)(MVCFunctions.Concat("href='", searchType, "?rname=", reportName, "'")));
				xt.assign(new XVar("ext"), new XVar("aspx"));
				if(MVCFunctions.postvalue(new XVar("param")) == "preview")
				{
					preview = new XVar("_preview");
				}
				switch(((XVar)GlobalVars.rpt_array["miscellaneous"]["type"]).ToString())
				{
					case "stepped":
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport", preview))));
						break;
					case "block":
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport1", preview))));
						break;
					case "outline":
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport2", preview))));
						break;
					case "align":
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport3", preview))));
						break;
					case "tabular":
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport6", preview))));
						break;
					default:
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport", preview))));
						break;
				}
				if(cross_table == "true")
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("edit"))))
					{
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("dreport5_style")));
					}
					else
					{
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), (XVar)(MVCFunctions.Concat("dreport5", preview))));
					}
				}
				if(XVar.Pack(modePrint))
				{
					templatefile = XVar.Clone(MVCFunctions.str_replace(new XVar("report"), new XVar("print"), (XVar)(templatefile)));
				}
				if(XVar.Pack(modePrint))
				{
					if(XVar.Pack(MVCFunctions.postvalue("format")))
					{
						xt.assign(new XVar("stylesheetlink"), new XVar(false));
					}
					else
					{
						xt.assign(new XVar("stylesheetlink"), new XVar(true));
					}
				}
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("excellink_attrs"), new XVar("id=export_to_excel"));
				xt.assign(new XVar("wordlink_attrs"), new XVar("id=export_to_word"));
				xt.assign(new XVar("advButton_attrs"), new XVar("id=advButton"));
				if((XVar)(MVCFunctions.postvalue("format") == "excel")  || (XVar)(MVCFunctions.postvalue("format") == "word"))
				{
					xt.assign(new XVar("style_block"), new XVar(false));
				}
				else
				{
					xt.assign(new XVar("style_block"), new XVar(true));
				}
				xt.assign(new XVar("bottom_pagination_block"), new XVar(true));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("editor_style_block"), new XVar(false));
				xt.assign(new XVar("editor_block"), new XVar(false));
				if(XVar.Pack(XSession.Session["back_to_menu"]))
				{
					xt.assign(new XVar("back_to_menu"), new XVar(true));
				}
				else
				{
					xt.assign(new XVar("back_to_menu"), new XVar(false));
				}
				if(XVar.Pack(!(XVar)(editmode)))
				{
					xt.display((XVar)(templatefile));
				}
				else
				{
					xt.assign(new XVar("bottom_pagination_block"), new XVar(false));
					xt.assign(new XVar("records_display_block"), new XVar(false));
					xt.assign(new XVar("top_menu_block"), new XVar(false));
					xt.assign(new XVar("editor_style_block"), new XVar(true));
					xt.assign(new XVar("editor_block"), new XVar(true));
					xt.assign(new XVar("legend_disp"), new XVar(true));
					xt.display((XVar)(templatefile));
				}
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
		public static XVar GetGroupStart(dynamic _param_field, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			dynamic arr = XVar.Array(), i = null;
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
			{
				arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
				foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
				{
					if(arr["name"] == fldname((XVar)(fld.Value)))
					{
						dynamic ftype = null;
						if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
						{
							ftype = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(fld.Value["table"], ".", fld.Value["name"]))));
						}
						else
						{
							ftype = XVar.Clone(GlobalVars.fields_type[fld.Value["name"]]);
						}
						if(field == arr["name"])
						{
							if(arr["int_type"] == 0)
							{
								return value;
							}
							else
							{
								if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
								{
									return value - value  %  arr["int_type"];
								}
								else
								{
									if(XVar.Pack(CommonFunctions.IsCharType((XVar)(ftype))))
									{
										return MVCFunctions.substr((XVar)(value), new XVar(0), (XVar)(arr["int_type"]));
									}
									else
									{
										if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
										{
											dynamic tm = XVar.Array();
											tm = XVar.Clone(CommonFunctions.db2time((XVar)(value)));
											if(XVar.Pack(!(XVar)(tm)))
											{
												return "";
											}
											if(arr["int_type"] == 1)
											{
												return tm[0];
											}
											else
											{
												if(arr["int_type"] == 2)
												{
													return tm[0] * 4 + (XVar)Math.Floor((double)(tm[1] / 3));
												}
												else
												{
													if(arr["int_type"] == 3)
													{
														return tm[0] * 12 + tm[1];
													}
													else
													{
														if(arr["int_type"] == 4)
														{
															return CommonFunctions.getweeknumber((XVar)(tm));
														}
														else
														{
															if(arr["int_type"] == 5)
															{
																return (tm[0] * 12 + tm[1]) * 31 + tm[2];
															}
															else
															{
																if(arr["int_type"] == 6)
																{
																	return ((tm[0] * 12 + tm[1]) * 31 + tm[2]) * 24 + tm[3];
																}
																else
																{
																	if(arr["int_type"] == 7)
																	{
																		return (((tm[0] * 12 + tm[1]) * 31 + tm[2]) * 24 + tm[3]) * 60 + tm[4];
																	}
																	else
																	{
																		return value;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}
		public static XVar GetGroupDisplay(dynamic _param_field, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			dynamic arr = XVar.Array(), i = null;
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(GlobalVars.rpt_array["group_fields"])) - 1; i++)
			{
				arr = XVar.Clone(GlobalVars.rpt_array["group_fields"][i]);
				foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
				{
					if(arr["name"] == fldname((XVar)(fld.Value)))
					{
						dynamic ftype = null;
						if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
						{
							ftype = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(fld.Value["table"], ".", fld.Value["name"]))));
						}
						else
						{
							ftype = XVar.Clone(GlobalVars.fields_type[fld.Value["name"]]);
						}
						if(field == arr["name"])
						{
							dynamic prefix = null;
							if(arr["int_type"] == 0)
							{
								prefix = new XVar("");
								if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_db())))
								{
									prefix = XVar.Clone(MVCFunctions.Concat(GlobalVars.rpt_array["tables"][0], "_"));
								}
								else
								{
									field = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(field)));
								}
								if(GlobalVars.rpt_array["totals"][MVCFunctions.Concat(prefix, field)]["curr"] == "true")
								{
									return CommonFunctions.str_format_currency((XVar)(value));
								}
								else
								{
									return value;
								}
							}
							else
							{
								dynamic start = null, var_end = null;
								if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
								{
									start = XVar.Clone(value - value  %  arr["int_type"]);
									var_end = XVar.Clone(start + arr["int_type"]);
									prefix = new XVar("");
									if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_db())))
									{
										prefix = XVar.Clone(MVCFunctions.Concat(GlobalVars.rpt_array["tables"][0], "_"));
									}
									else
									{
										field = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(field)));
									}
									if(GlobalVars.rpt_array["totals"][MVCFunctions.Concat(prefix, field)]["curr"] == "true")
									{
										return MVCFunctions.Concat(CommonFunctions.str_format_currency((XVar)(start)), " - ", CommonFunctions.str_format_currency((XVar)(var_end)));
									}
									else
									{
										return MVCFunctions.Concat(start, " - ", var_end);
									}
								}
								else
								{
									if(XVar.Pack(CommonFunctions.IsCharType((XVar)(ftype))))
									{
										return MVCFunctions.substr((XVar)(value), new XVar(0), (XVar)(arr["int_type"]));
									}
									else
									{
										if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
										{
											dynamic tm = XVar.Array();
											tm = XVar.Clone(CommonFunctions.db2time((XVar)(value)));
											if(XVar.Pack(!(XVar)(tm)))
											{
												return "";
											}
											if(arr["int_type"] == 1)
											{
												return tm[0];
											}
											else
											{
												if(arr["int_type"] == 2)
												{
													return MVCFunctions.Concat(tm[0], "/Q", (XVar)Math.Floor((double)((tm[1] - 1) / 4 + 1)));
												}
												else
												{
													if(arr["int_type"] == 3)
													{
														return MVCFunctions.Concat(GlobalVars.locale_info[MVCFunctions.Concat("LOCALE_SABBREVMONTHNAME", tm[1])], " ", tm[0]);
													}
													else
													{
														if(arr["int_type"] == 4)
														{
															start = XVar.Clone(CommonFunctions.getweekstart((XVar)(tm)));
															var_end = XVar.Clone(CommonFunctions.adddays((XVar)(start), new XVar(6)));
															return MVCFunctions.Concat(CommonFunctions.format_shortdate((XVar)(start)), " - ", CommonFunctions.format_shortdate((XVar)(var_end)));
														}
														else
														{
															if(arr["int_type"] == 5)
															{
																return CommonFunctions.format_shortdate((XVar)(tm));
															}
															else
															{
																if(arr["int_type"] == 6)
																{
																	tm.InitAndSetArrayItem(0, 4);
																	tm.InitAndSetArrayItem(0, 5);
																	return CommonFunctions.str_format_datetime((XVar)(tm));
																}
																else
																{
																	if(arr["int_type"] == 7)
																	{
																		tm.InitAndSetArrayItem(0, 5);
																		return CommonFunctions.str_format_datetime((XVar)(tm));
																	}
																	else
																	{
																		return CommonFunctions.str_format_datetime((XVar)(tm));
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}
		public static XVar testAgr(dynamic _param_array, dynamic _param_avg = null, dynamic _param_min = null, dynamic _param_max = null, dynamic _param_sum = null)
		{
			#region default values
			if(_param_avg as Object == null) _param_avg = new XVar("");
			if(_param_min as Object == null) _param_min = new XVar("");
			if(_param_max as Object == null) _param_max = new XVar("");
			if(_param_sum as Object == null) _param_sum = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic array = XVar.Clone(_param_array);
			dynamic avg = XVar.Clone(_param_avg);
			dynamic min = XVar.Clone(_param_min);
			dynamic max = XVar.Clone(_param_max);
			dynamic sum = XVar.Clone(_param_sum);
			#endregion

			dynamic cnt = null;
			cnt = new XVar(0);
			foreach (KeyValuePair<XVar, dynamic> arr in array.GetEnumerator())
			{
				if((XVar)((XVar)((XVar)(avg == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))  && (XVar)(max == XVar.Pack("")))  && (XVar)(sum == XVar.Pack("")))
				{
					cnt += (XVar.Pack(arr.Value["show"]) ? XVar.Pack(1) : XVar.Pack(0));
				}
				else
				{
					if((XVar)((XVar)(avg == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))  && (XVar)(sum == XVar.Pack("")))
					{
						cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)(arr.Value["max"])) ? XVar.Pack(1) : XVar.Pack(0));
					}
					else
					{
						if((XVar)((XVar)(avg == XVar.Pack(""))  && (XVar)(max == XVar.Pack("")))  && (XVar)(sum == XVar.Pack("")))
						{
							cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)(arr.Value["min"])) ? XVar.Pack(1) : XVar.Pack(0));
						}
						else
						{
							if((XVar)((XVar)(max == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))  && (XVar)(sum == XVar.Pack("")))
							{
								cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)(arr.Value["avg"])) ? XVar.Pack(1) : XVar.Pack(0));
							}
							else
							{
								if((XVar)((XVar)(avg == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))  && (XVar)(max == XVar.Pack("")))
								{
									cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)(arr.Value["sum"])) ? XVar.Pack(1) : XVar.Pack(0));
								}
								else
								{
									if((XVar)(avg == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))
									{
										cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["max"])  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
									}
									else
									{
										if((XVar)(min == XVar.Pack(""))  && (XVar)(max == XVar.Pack("")))
										{
											cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
										}
										else
										{
											if((XVar)(max == XVar.Pack(""))  && (XVar)(sum == XVar.Pack("")))
											{
												cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["min"]))) ? XVar.Pack(1) : XVar.Pack(0));
											}
											else
											{
												if((XVar)(avg == XVar.Pack(""))  && (XVar)(sum == XVar.Pack("")))
												{
													cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["min"])  || (XVar)(arr.Value["max"]))) ? XVar.Pack(1) : XVar.Pack(0));
												}
												else
												{
													if((XVar)(avg == XVar.Pack(""))  && (XVar)(max == XVar.Pack("")))
													{
														cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["min"])  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
													}
													else
													{
														if((XVar)(sum == XVar.Pack(""))  && (XVar)(min == XVar.Pack("")))
														{
															cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)(arr.Value["max"])  || (XVar)(arr.Value["avg"]))) ? XVar.Pack(1) : XVar.Pack(0));
														}
														else
														{
															if(avg == XVar.Pack(""))
															{
																cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)((XVar)(arr.Value["min"])  || (XVar)(arr.Value["max"]))  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
															}
															else
															{
																if(min == XVar.Pack(""))
																{
																	cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["max"]))  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
																}
																else
																{
																	if(max == XVar.Pack(""))
																	{
																		cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["min"]))  || (XVar)(arr.Value["sum"]))) ? XVar.Pack(1) : XVar.Pack(0));
																	}
																	else
																	{
																		if(sum == XVar.Pack(""))
																		{
																			cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["min"]))  || (XVar)(arr.Value["max"]))) ? XVar.Pack(1) : XVar.Pack(0));
																		}
																		else
																		{
																			cnt += (XVar.Pack((XVar)(arr.Value["show"])  && (XVar)((XVar)((XVar)(arr.Value["avg"])  || (XVar)(arr.Value["min"]))  || (XVar)(arr.Value["max"]))) ? XVar.Pack(1) : XVar.Pack(0));
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return cnt;
		}
		public static XVar func_debug(dynamic _param_val)
		{
			#region pass-by-value parameters
			dynamic val = XVar.Clone(_param_val);
			#endregion

			if(XVar.Pack(MVCFunctions.is_array((XVar)(val))))
			{
				MVCFunctions.print_r((XVar)(val));
			}
			else
			{
				MVCFunctions.Echo(MVCFunctions.Concat(val, "\n"));
			}
			return null;
		}
		public static XVar fldname(dynamic fld)
		{
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				return MVCFunctions.Concat(fld["table"], ".", fld["name"]);
			}
			else
			{
				return fld["name"];
			}
			return null;
		}
		public static XVar gfldname(dynamic fld)
		{
			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				return MVCFunctions.GoodFieldName((XVar)(fldname((XVar)(fld))));
			}
			return fldname((XVar)(fld));
		}
		public static XVar db_fld_value(dynamic data, dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(CommonFunctions.is_wr_db()))
			{
				return data[MVCFunctions.GoodFieldName((XVar)(field))];
			}
			return data[field];
		}
		public static XVar getDBFieldName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_db())))
			{
				return name;
			}
			else
			{
				return GlobalVars.arrDBFieldsList[MVCFunctions.GoodFieldName((XVar)(name))];
			}
			return null;
		}
	}
}
