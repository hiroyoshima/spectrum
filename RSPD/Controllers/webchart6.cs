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
		public ActionResult webchart6()
		{
			try
			{
				dynamic b_includes = null, chart_name = null, chart_status = null, chart_title = null, h_includes = null, rLinks = null, ri = null, show_status = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(XSession.Session["webcharts"]["tables"][0])), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				CommonFunctions.Reload_Chart((XVar)(MVCFunctions.postvalue(new XVar("cname"))));
				xt = XVar.UnPackXTempl(new XTempl());
				if(XSession.Session["webcharts"]["settings"]["title"] != "")
				{
					dynamic title = null;
					title = XVar.Clone(XSession.Session["webcharts"]["settings"]["title"]);
					if(25 < MVCFunctions.strlen((XVar)(title)))
					{
						title = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(title), new XVar(25)), "..."));
					}
					xt.assign(new XVar("chart_title"), (XVar)(MVCFunctions.Concat(", ", "Title", ": ", title)));
				}
				else
				{
					xt.assign(new XVar("chart_title"), new XVar(""));
				}
				if(XSession.Session["webcharts"]["tables"][0] != "")
				{
					dynamic stable = null;
					stable = XVar.Clone(XSession.Session["webcharts"]["tables"][0]);
					if(25 < MVCFunctions.strlen((XVar)(stable)))
					{
						stable = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(stable), new XVar(25)), "..."));
					}
					xt.assign(new XVar("chart_table"), (XVar)(MVCFunctions.Concat(", ", "Table", ": ", stable)));
				}
				else
				{
					xt.assign(new XVar("chart_table"), new XVar(""));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("b_is_chart_save"), (XVar)(XSession.Session["webcharts"]["tmp_active"] != "x"));
				xt.assign(new XVar("b_is_chart_name"), (XVar)(XSession.Session["webcharts"]["settings"]["name"] != ""));
				xt.assign(new XVar("chart_name"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0;\r\n\r\n$(document).ready(function(){\r\n\t\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {\r\n\t\t\tsettings : {\r\n\t\t\t\tname   : $(\"#cname\").val().replace(/\\W/g, \"_\"),\r\n\t\t\t\ttitle  : $(\"#ctitle\").val(),\r\n\t\t\t\tstatus : ( $(\"#cstatus\")[0].checked ) ? \"private\" : \"public\"\r\n\t\t\t}\r\n\t\t};\r\n\t\t\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\t\r\n\t\r\n\r\n\t$(\"#row6\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(MVCFunctions.count(CommonFunctions.GetUserGroups()) < 2)  || (XVar)((XVar)(XSession.Session["webcharts"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webcharts"]["settings"]["status"] == "private")))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row7]\").hide();", "\r\n");
				}
				if((XVar)(CommonFunctions.is_wr_project())  || (XVar)(CommonFunctions.is_wr_custom()))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row1], td[id=row2]\").hide();", "\r\n");
				}
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row9]\").hide();", "\n");
				}
				if(XSession.Session["webcharts"]["settings"]["title"] == "")
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\tfor (var i=2; i<=7; i++){\r\n\t\t\t$(\"td[id=row\" + i + \"]\").hide();\r\n\t\t};\r\n\t", "\r\n");
				}
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webchart", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart7")), "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart5")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6"), new XVar(""), new XVar("saveas=1")), "\";\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row6\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\r\n\t\tif ( $(\"#cname\").val() == \"\"  && this.id!=\"row8\" && this.id!=\"row9\" ) {\r\n\t\t\t$(\"#menujump\").hide();\r\n\t\t\t$(\"#alert\").html(\"<p>", "Set chart name", "</p>\").dialog(\"open\");\r\n\t\t\treturn false;\r\n\t\t}\r\n\t\t\r\n\t\tif ( $(\"#ctitle\").val() == \"\" && this.id!=\"row8\" && this.id!=\"row9\" ) {\r\n\t\t\t$(\"#menujump\").hide();\r\n\t\t\t$(\"#alert\").html(\"<p>", "Set chart title", "</p>\").dialog(\"open\");\r\n\t\t\treturn false;\r\n\t\t}\t\t\t\r\n\t\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\tif( this.id == \"savebtn\" ) {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: 1,\r\n\t\t\t\t\t");
				if(MVCFunctions.postvalue("saveas") == 1)
				{
					b_includes = MVCFunctions.Concat(b_includes, "saveas:1,");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tname: \"settings\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t.html(\"<p>", "Chart Saved", "</p>\")\r\n\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row6\" && this.id !=\"savebtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"settings\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n");
				if(1 < MVCFunctions.count(CommonFunctions.GetUserGroups()))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#cstatus\").click(function(){\r\n\t\t\tif ( this.checked == true ) {\r\n\t\t\t\t$(\"#nextbtn\").hide();\r\n\t\t\t\t$(\"#row7\").hide();\r\n\t\t\t} else {\r\n\t\t\t\t$(\"#nextbtn\").show();\r\n\t\t\t\t$(\"#row7\").show();\r\n\t\t\t}\r\n\t\t});\r\n\t");
				}
				chart_name = XVar.Clone((XVar.Pack(XSession.Session["webcharts"]["settings"].KeyExists("name")) ? XVar.Pack(XSession.Session["webcharts"]["settings"]["name"]) : XVar.Pack(MVCFunctions.Concat(MVCFunctions.GoodFieldName((XVar)(XSession.Session["webcharts"]["tables"][0])), "_", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))))));
				chart_title = XVar.Clone((XVar.Pack(XSession.Session["webcharts"]["settings"].KeyExists("title")) ? XVar.Pack(XSession.Session["webcharts"]["settings"]["title"]) : XVar.Pack(MVCFunctions.Concat(XSession.Session["webcharts"]["tables"][0], " Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))))));
				show_status = new XVar("style=\"display:line;\"");
				if((XVar)(XSession.Session["webcharts"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webcharts"]["settings"]["status"] == "private"))
				{
					chart_status = new XVar("checked");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#nextbtn\").hide();$(\"#nextprob\").hide();");
				}
				else
				{
					if(1 < MVCFunctions.count(CommonFunctions.GetUserGroups()))
					{
						chart_status = new XVar("");
					}
					else
					{
						chart_status = new XVar("");
						b_includes = MVCFunctions.Concat(b_includes, "$(\"#nextbtn\").hide();$(\"#nextprob\").hide();");
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n});\r\n</script>", "\r\n");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("chart_name"), (XVar)(chart_name));
				xt.assign(new XVar("chart_title"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(chart_title))));
				xt.assign(new XVar("chart_status"), (XVar)(chart_status));
				xt.assign(new XVar("show_status"), (XVar)(show_status));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart6")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
