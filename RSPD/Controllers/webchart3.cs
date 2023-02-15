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
		public ActionResult webchart3()
		{
			try
			{
				dynamic arr = XVar.Array(), b_includes = null, h_includes = null, rLinks = null, ri = null, table_name = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(XSession.Session["webcharts"]["tables"][0])), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
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
				xt.assign(new XVar("b_is_chart_save"), (XVar)(XSession.Session["webcharts"]["tmp_active"] != "x"));
				xt.assign(new XVar("b_is_chart_name"), (XVar)(XSession.Session["webcharts"]["settings"]["name"] != ""));
				xt.assign(new XVar("chart_name"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">", "\r\n");
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart4")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart2")), "\";\r\n\t", "\r\n");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart4")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart0")), "\";\r\n\t", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0;\r\n\r\n$(document).ready(function(){\r\n\t\r\n\t\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {\r\n\t\t\tchart_type : {\r\n\t\t\t\ttype : $(\"img.selected\").attr(\"id\")\r\n\t\t\t}\r\n\t\t};\r\n\t\t\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\t\r\n\t$(\".ctt > img\").click(function(){\r\n\t\t$(\".ctt > img\").each(function(){\r\n\t\t\t$(this).removeClass(\"selected\");\r\n\t\t});\r\n\t\t$(this).addClass(\"selected\");\r\n\t});\r\n\t\r\n\t$(\".ctt > img\").dblclick(function(){\r\n\t\t$(\"#nextbtn\").click();\r\n\t});\r\n\t\r\n\t$(\"#row3\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\t\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n\t\r\n", "\r\n");
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar activeXDetectRules = [\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.7\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.6\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash\"}\r\n    ];\r\n\tvar getActiveXObject = function(name){\r\n        var obj = -1;\r\n        try{\r\n            obj = new ActiveXObject(name);\r\n        }catch(err){\r\n            obj = {activeXError:true};\r\n        }\r\n        return obj;\r\n    };\r\n\tif(navigator.plugins && navigator.plugins.length>0)\r\n\t{\r\n\t\tvar type = \"application/x-shockwave-flash\";\r\n\t\tvar mimeTypes = navigator.mimeTypes;\r\n\t\tif(!mimeTypes || !mimeTypes[type] || !mimeTypes[type].enabledPlugin || !mimeTypes[type].enabledPlugin.description)\r\n\t\t{\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\r\n\telse if(navigator.appVersion.indexOf(\"Mac\")==-1 && window.execScript)\r\n\t{\r\n\t\tvar isFlash = false;\r\n\t\tfor(var i=0; i<activeXDetectRules.length; i++){\r\n                var obj = getActiveXObject(activeXDetectRules[i].name);\r\n                if(!obj.activeXError){\r\n\t\t\t\t\tisFlash = true;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\tif(!isFlash){\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\t\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webchart")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = NEXT_PAGE_URL;\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = PREV_PAGE_URL;\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row3\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\" ) {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tname: \"chart_type\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif( id == \"savebtn\" )\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Chart Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row3\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"chart_type\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				arr = XVar.Clone(XSession.Session["webcharts"]["chart_type"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t\t$(document).ready(function(){\r\n\t\t\t$(\".ctt > img\").each(function(){\r\n\t\t\t\t$(this).removeClass(\"selected\");\r\n\t\t\t});\r\n\t\t\t$(\"img#", arr["type"], "\").addClass(\"selected\");\r\n\t\t});\r\n\t</script>");
				}
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("chart_name_preview"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				table_name = XVar.Clone(XSession.Session["webcharts"]["tables"][0]);
				xt.assign(new XVar("table_name"), (XVar)(table_name));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart3")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
