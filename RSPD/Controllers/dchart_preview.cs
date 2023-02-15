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
		public ActionResult dchart_preview()
		{
			try
			{
				dynamic chartParams = XVar.Array(), chartPreview = null, chrt_array = XVar.Array(), cname = null, height = null, load_flash_player = null, refresh = null, show_dchart = null, templatefile = null, width = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				GlobalVars.strTableName = new XVar("");
				cname = XVar.Clone(MVCFunctions.postvalue(new XVar("cname")));
				chrt_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue(new XVar("cname"))), new XVar(Constants.WR_CHART)));
				if(XVar.Pack(!(XVar)(chrt_array)))
				{
					MVCFunctions.Header((XVar)(MVCFunctions.Concat("location: ", MVCFunctions.GetTableLink(new XVar("webreport")))));
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				else
				{
					CommonFunctions.Reload_Chart((XVar)(MVCFunctions.postvalue(new XVar("cname"))));
				}
				xt = XVar.UnPackXTempl(new XTempl());
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", chrt_array["settings"]["short_table_name"], ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.isLogged())))
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
				if(1 < CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())))
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
				width = new XVar(780);
				height = new XVar(570);
				refresh = new XVar(0);
				chartParams = XVar.Clone(XVar.Array());
				chartParams.InitAndSetArrayItem(width, "width");
				chartParams.InitAndSetArrayItem(height, "height");
				chartParams.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("cname")), "chartName");
				chartParams.InitAndSetArrayItem("showchart", "containerId");
				chartParams.InitAndSetArrayItem(chrt_array["chart_type"]["type"], "chartType");
				chartParams.InitAndSetArrayItem(refresh, "refreshTime");
				chartParams.InitAndSetArrayItem(MVCFunctions.Concat(MVCFunctions.GetTableLink(new XVar("dchartdata")), "?cname=", MVCFunctions.postvalue(new XVar("cname")), chartPreview, "&ctype=", chrt_array["chart_type"]["type"]), "xmlFile");
				show_dchart = XVar.Clone(MVCFunctions.Concat("<div id=\"", chartParams["containerId"], "\" style=\"width:", width, "px;height:", height, "px\"></div>"));
				show_dchart = MVCFunctions.Concat(show_dchart, "<script type=\"text/javascript\" language=\"javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("libs/js/anychart.min.js")), "\"></script>");
				show_dchart = MVCFunctions.Concat(show_dchart, "<script type=\"text/javascript\" language=\"javascript\">\r\n\t(function(){\r\n\t\tvar params = ", MVCFunctions.my_json_encode((XVar)(chartParams)), ";\r\n\t\tcreateChart( params );\r\n\t})();\r\n\t</script>");
				load_flash_player = XVar.Clone(MVCFunctions.Concat("\r\n<script type=\"text/javascript\">\r\n\tvar svgSupported = window.SVGAngle != undefined;\r\n\t\tvar str=\"\";\r\n\t\tif (!svgSupported)\r\n\t\t{\r\n\t\t\tstr = \"<center>\";\r\n\t\t\tstr += \"", "", "<br /><br />\";\r\n\t\t\tstr += \"<a href=\\\"http://www.adobe.com/go/getflashplayer\\\"><img border=\\\"0\\\" src=\\\"http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif\\\" /></a><br />\";\r\n\t\t\tstr += \"</center>\";\t\t\r\n\t\t}\r\n\t\tif (typeof(ActiveXObject) != \"undefined\") {\r\n\t\t\ttry { a = new ActiveXObject(\"ShockwaveFlash.ShockwaveFlash\");d = a.GetVariable(\"$version\"); }\r\n\t\t\tcatch (e) { d = false; }\r\n\t\t\tif (!d) {\r\n\t\t\t\t$(\"div.center_div\").html( str );\t\r\n\t\t\t}\t\t\t\r\n\t\t} else if ((navigator.product == \"Gecko\" && window.find && !navigator.savePreferences)\r\n\t\t\t|| (navigator.userAgent.indexOf(\"WebKit\") != -1 || navigator.userAgent.indexOf(\"Konqueror\") != -1))\r\n\t\t{\r\n\t\t\tdiv = $(\"div[id*='__chart_generated_container__']\");\r\n\t\t\tif ( div[0] == undefined ) {\r\n\t\t\t\t$(\"div.center_div\").html( str );\t\t\t\r\n\t\t\t} else {\r\n\t\t\t\t$(div).appendTo(\"div.center_div\");\r\n\t\t\t}\r\n\t\t}\r\n</script>"));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("chart_constructor"), (XVar)(show_dchart));
				xt.assign(new XVar("load_flash_player"), (XVar)(load_flash_player));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("dchart_preview")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
