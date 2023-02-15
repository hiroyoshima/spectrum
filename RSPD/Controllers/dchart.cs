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
		public ActionResult dchart()
		{
			try
			{
				dynamic chartParams = XVar.Array(), chartPreview = null, chart_name_js = null, chrt_array = XVar.Array(), cname = null, height = null, load_flash_player = null, refresh = null, searchType = null, sessPrefix = null, show_dchart = null, templatefile = null, tosearch = null, width = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				GlobalVars.strTableName = new XVar("");
				cname = XVar.Clone(MVCFunctions.postvalue(new XVar("cname")));
				if(XVar.Pack(!(XVar)(cname)))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				chrt_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(cname), new XVar(Constants.WR_CHART)));
				if(XVar.Pack(!(XVar)(chrt_array)))
				{
					MVCFunctions.Header((XVar)(MVCFunctions.Concat("location: ", MVCFunctions.GetTableLink(new XVar("webreport")))));
				}
				else
				{
					CommonFunctions.Reload_Chart((XVar)(cname));
				}
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", chrt_array["settings"]["short_table_name"], ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				sessPrefix = XVar.Clone(MVCFunctions.Concat("webchart", cname));
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				else
				{
					if((XVar)(chrt_array["settings"]["status"] == "private")  && (XVar)(chrt_array["settings"]["owner"] != Security.getUserName()))
					{
						MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this chart", "</p>"));
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				if(1 < MVCFunctions.count(CommonFunctions.GetUserGroups()))
				{
					dynamic arr_reports = XVar.Array();
					arr_reports = XVar.Clone(XVar.Array());
					arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_CHART)));
					foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
					{
						if((XVar)((XVar)((XVar)(rpt.Value["owner"] != Security.getUserName())  || (XVar)(rpt.Value["owner"] == ""))  && (XVar)(rpt.Value["view"] == 0))  && (XVar)(chrt_array["settings"]["name"] == rpt.Value["name"]))
						{
							MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this chart", "</p>"));
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
					}
				}
				if((XVar)(!(XVar)(MVCFunctions.POSTSize()))  && (XVar)(MVCFunctions.GETSize() <= 1))
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
					foreach (KeyValuePair<XVar, dynamic> field in asearchfield.GetEnumerator())
					{
						dynamic asopt = null, gfield = null, value1 = null, value2 = null, var_not = null, var_type = null;
						if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
						{
							XSession.Session.InitAndSetArrayItem(asearchtable[field.Key], MVCFunctions.Concat(sessPrefix, "_asearchtable"), field.Value);
						}
						gfield = XVar.Clone(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(field.Value)), "_1"));
						asopt = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("asearchopt_", gfield))));
						value1 = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value_", gfield))));
						var_type = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("type_", gfield))));
						value2 = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value1_", gfield))));
						var_not = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("not_", gfield))));
						if((XVar)(MVCFunctions.strlen((XVar)(value1)))  || (XVar)(asopt == "Empty"))
						{
							tosearch = new XVar(1);
							XSession.Session.InitAndSetArrayItem(asopt, MVCFunctions.Concat(sessPrefix, "_asearchopt"), field.Value);
							if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(value1)))))
							{
								XSession.Session.InitAndSetArrayItem(value1, MVCFunctions.Concat(sessPrefix, "_asearchfor"), field.Value);
							}
							else
							{
								XSession.Session.InitAndSetArrayItem(CommonFunctions.combinevalues((XVar)(value1)), MVCFunctions.Concat(sessPrefix, "_asearchfor"), field.Value);
							}
							XSession.Session.InitAndSetArrayItem(var_type, MVCFunctions.Concat(sessPrefix, "_asearchfortype"), field.Value);
							if(XVar.Pack(value2))
							{
								XSession.Session.InitAndSetArrayItem(value2, MVCFunctions.Concat(sessPrefix, "_asearchfor2"), field.Value);
							}
							XSession.Session.InitAndSetArrayItem(var_not == "on", MVCFunctions.Concat(sessPrefix, "_asearchnot"), field.Value);
						}
					}
				}
				else
				{
					if(MVCFunctions.postvalue("a") == "integrated")
					{
						dynamic field = null, j = null;
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
				xt = XVar.UnPackXTempl(new XTempl());
				xt.assign(new XVar("userid"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(Security.getUserName()))));
				xt.assign(new XVar("guest"), (XVar)(Security.isGuest()));
				if(XVar.Pack(Security.dynamicPermissions()))
				{
					xt.assign(new XVar("admin"), (XVar)(XSession.Session["IsAdmin"]));
				}
				chartPreview = new XVar("");
				width = new XVar(800);
				height = new XVar(640);
				refresh = new XVar(0);
				if(chrt_array["appearance"]["autoupdate"] == "true")
				{
					refresh = XVar.Clone(chrt_array["appearance"]["update_interval"] * 60);
				}
				chartParams = XVar.Clone(XVar.Array());
				chartParams.InitAndSetArrayItem(width, "width");
				chartParams.InitAndSetArrayItem(height, "height");
				chartParams.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("cname")), "chartName");
				chartParams.InitAndSetArrayItem("showchart", "containerId");
				chartParams.InitAndSetArrayItem(chrt_array["chart_type"]["type"], "chartType");
				chartParams.InitAndSetArrayItem(refresh, "refreshTime");
				chartParams.InitAndSetArrayItem(MVCFunctions.Concat(MVCFunctions.GetTableLink(new XVar("dchartdata")), "?cname=", MVCFunctions.postvalue(new XVar("cname")), chartPreview, "&ctype=", chrt_array["chart_type"]["type"]), "xmlFile");
				chartParams.InitAndSetArrayItem(XVar.Array(), "settings");
				chartParams.InitAndSetArrayItem(XVar.Array(), "settings", "seriesColor");
				foreach (KeyValuePair<XVar, dynamic> s in chrt_array["parameters"].GetEnumerator())
				{
					if(s.Value["series_color"] != "")
					{
						chartParams.InitAndSetArrayItem(s.Value["series_color"], "settings", "seriesColor", null);
					}
				}
				show_dchart = XVar.Clone(MVCFunctions.Concat("<div id=\"", chartParams["containerId"], "\" style=\"width:", width, "px;height:", height, "px\"></div>"));
				show_dchart = MVCFunctions.Concat(show_dchart, "<script type=\"text/javascript\" language=\"javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("libs/js/anychart.min.js")), "\"></script>");
				show_dchart = MVCFunctions.Concat(show_dchart, "<script type=\"text/javascript\" language=\"javascript\">\r\n\t(function(){\r\n\t\tvar params = ", MVCFunctions.my_json_encode((XVar)(chartParams)), ";\r\n\t\tcreateChart( params );\r\n\t})();\r\n\t</script>");
				load_flash_player = XVar.Clone(MVCFunctions.Concat("\r\n<script type=\"text/javascript\">\r\n\t$(document).ready(function(){\r\n\t\tvar svgSupported = window.SVGAngle != undefined;\r\n\t\tvar str=\"\";\r\n\t\tif (!svgSupported)\r\n\t\t{\r\n\t\t\tstr = \"<center>\";\r\n\t\t\tstr += \"", "", "<br /><br />\";\r\n\t\t\tstr += \"<a href=\\\"http://www.adobe.com/go/getflashplayer\\\"><img border=\\\"0\\\" src=\\\"http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif\\\" /></a><br />\";\r\n\t\t\tstr += \"</center>\";\t\t\r\n\t\t}\r\n\t\tif (typeof(ActiveXObject) != \"undefined\") {\r\n\t\t\ttry { a = new ActiveXObject(\"ShockwaveFlash.ShockwaveFlash\");d = a.GetVariable(\"$version\"); }\r\n\t\t\tcatch (e) { d = false; }\r\n\t\t\tif (!d) {\r\n\t\t\t\t$(\"div.center_div\").html( str );\t\r\n\t\t\t\t$(\"#ExpPDF\").hide();\r\n\t\t\t}\t\t\t\r\n\t\t} else if ((navigator.product == \"Gecko\" && window.find && !navigator.savePreferences)\r\n\t\t\t|| (navigator.userAgent.indexOf(\"WebKit\") != -1 || navigator.userAgent.indexOf(\"Konqueror\") != -1))\r\n\t\t{\r\n\t\t\tdiv = $(\"div[id*='__chart_generated_container__']\");\r\n\t\t\tif ( div[0] == undefined ) {\r\n\t\t\t\t$(\"div.center_div\").html( str );\t\t\t\r\n\t\t\t\t$(\"#ExpPDF\").hide();\r\n\t\t\t} else {\r\n\t\t\t\tif($(\"div.center_div\").find(\"object\").length==0)\r\n\t\t\t\t\t$(\"#ExpPDF\").hide();\r\n\t\t\t\t$(div).appendTo(\"div.center_div\");\r\n\t\t\t}\r\n\t\t}\t\r\n\t});\r\n</script>"));
				if(XVar.Pack(XSession.Session["back_to_menu"]))
				{
					xt.assign(new XVar("back_to_menu"), new XVar(true));
				}
				else
				{
					xt.assign(new XVar("back_to_menu"), new XVar(false));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("chart_block"), new XVar(true));
				xt.assign(new XVar("chart_constructor"), (XVar)(show_dchart));
				xt.assign(new XVar("load_flash_player"), (XVar)(load_flash_player));
				if(XVar.Pack(!(XVar)(CommonFunctions.IsStoredProcedure((XVar)(chrt_array["sql"])))))
				{
					xt.assign(new XVar("testAdvSearch"), (XVar)(CommonFunctions.testAdvSearch((XVar)(chrt_array["tables"][0]))));
				}
				else
				{
					xt.assign(new XVar("testAdvSearch"), new XVar(false));
				}
				chart_name_js = XVar.Clone(CommonFunctions.jsreplace((XVar)(MVCFunctions.postvalue(new XVar("cname")))));
				xt.assign(new XVar("chart_name_js"), (XVar)(chart_name_js));
				xt.assign(new XVar("chart_title"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(chrt_array["title"]))));
				xt.assign(new XVar("short_table_name"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(chrt_array["settings"]["short_table_name"]))));
				xt.assign(new XVar("short_table_name_js"), (XVar)(CommonFunctions.jsreplace((XVar)(chrt_array["settings"]["short_table_name"]))));
				xt.assign(new XVar("ext"), new XVar("aspx"));
				searchType = XVar.Clone((XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())) ? XVar.Pack(MVCFunctions.GetTableLink(new XVar("dsearch"))) : XVar.Pack(MVCFunctions.GetTableLink((XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(chrt_array["settings"]["short_table_name"]))), new XVar("search")))));
				xt.assign(new XVar("searchHref"), (XVar)(MVCFunctions.Concat("href='", searchType, "?cname=", chart_name_js, "'")));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("dchart")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
