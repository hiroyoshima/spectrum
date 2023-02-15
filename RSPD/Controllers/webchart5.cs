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
		public ActionResult webchart5()
		{
			try
			{
				dynamic aColor = XVar.Array(), accumulinvert_checked = null, accumulstyle_val = null, aqua_val = null, arr = XVar.Array(), autoupdate_checked = null, b_includes = null, cscroll_checked = null, cview_val = null, dec_val = null, foot_val = null, gaugestyle_val = null, h_includes = null, head_val = null, i = null, is3d_checked = null, isstacked_checked = null, linestyle_val = null, maxbarscroll_val = null, rLinks = null, ri = null, sanim_checked = null, saxes_checked = null, scur_checked = null, sgrid_checked = null, slegend_checked = null, slog_checked = null, sname_checked = null, sstacked_checked = null, sval_checked = null, table_name = null, templatefile = null, update_interval_val = null;
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
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/stylesheet.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0,\r\n\tclosetimerpicker = 0,\r\n\ttimeoutpicker = 300,\r\n\tdiv_id=0;\r\n\r\n$(document).ready(function(){\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {\r\n\t\t\tappearance : {\r\n\t\t\t\tslegend : $(\"input[id=slegend]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsgrid : $(\"input[id=sgrid]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsname : $(\"input[id=sname]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsval : $(\"input[id=sval]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsanim : $(\"input[id=sanim]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tscur : $(\"input[id=scur]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsstacked : $(\"input[id=sstacked]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tsaxes : $(\"input[id=saxes]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tslog : $(\"input[id=slog]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tdec : $(\"input[id=dec]\").val(),\r\n\t\t\t\thead : $(\"input[id=head]\").val(),\r\n\t\t\t\tfoot : $(\"input[id=foot]\").val(),\r\n\t\t\t\tlinestyle : $(\"select[id=linestyle]\").val(),\r\n\t\t\t\tgaugestyle : $(\"select[id=gaugestyle]\").val(),\r\n\t\t\t\taccumulstyle : $(\"select[id=accumulstyle]\").val(),\r\n\t\t\t\taqua : $(\"select[id=aqua]\").val(),\r\n\t\t\t\tcview : $(\"select[id=cview]\").val(),\r\n\t\t\t\taccumulinvert : $(\"input[id=accumulinvert]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tis3d : ($(\"input[id=is3d]\").prop(\"checked\") ? $(\"input[id=is3d]\").prop(\"checked\").toString(): \"\"),\r\n\t\t\t\tisstacked : ($(\"input[id=isstacked]\").prop(\"checked\") ? $(\"input[id=isstacked]\").prop(\"checked\").toString() : \"\"),\r\n\t\t\t\tautoupdate : $(\"input[id=autoupdate]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tcscroll : $(\"input[id=cscroll]\").prop(\"checked\").toString() || \"\",\r\n\t\t\t\tupdate_interval : $(\"input[id=update_interval]\").val(),\r\n\t\t\t\tmaxbarscroll : $(\"input[id=maxbarscroll]\").val()\r\n\t\t\t}\r\n\t\t};\r\n\t\tfor ( var i = 5; i <= 14; i++ ) {\r\n\t\t\toutput.appearance[\"color\"+i+\"1\"] = $(\"div[id=picker\"+i+\"]\").attr(\"color1\");\r\n\t\t\toutput.appearance[\"color\"+i+\"2\"] = $(\"div[id=picker\"+i+\"]\").attr(\"color2\");\r\n\t\t}\t\t\r\n\t\t\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\r\n\t$(\"#row5\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n\t\r\n\t$.each([5,6,7,8,9,10,11,12,13,14],function(i,n){\r\n\t\t$(\"#picker\"+n).css(\"background-color\", \"#FFFFFF\");\r\n\t\t$(\"#picker\"+n)[0].color1 = \"\";\r\n\t\t$(\"#picker\"+n)[0].color2 = \"\";                      \r\n\t});\r\n\t\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.colorPickerMouse());
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar activeXDetectRules = [\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.7\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.6\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash\"}\r\n    ];\r\n\tvar getActiveXObject = function(name){\r\n        var obj = -1;\r\n        try{\r\n            obj = new ActiveXObject(name);\r\n        }catch(err){\r\n            obj = {activeXError:true};\r\n        }\r\n        return obj;\r\n    };\r\n\tif(navigator.plugins && navigator.plugins.length>0)\r\n\t{\r\n\t\tvar type = \"application/x-shockwave-flash\";\r\n\t\tvar mimeTypes = navigator.mimeTypes;\r\n\t\tif(!mimeTypes || !mimeTypes[type] || !mimeTypes[type].enabledPlugin || !mimeTypes[type].enabledPlugin.description)\r\n\t\t{\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\r\n\telse if(navigator.appVersion.indexOf(\"Mac\")==-1 && window.execScript)\r\n\t{\r\n\t\tvar isFlash = false;\r\n\t\tfor(var i=0; i<activeXDetectRules.length; i++){\r\n                var obj = getActiveXObject(activeXDetectRules[i].name);\r\n                if(!obj.activeXError){\r\n\t\t\t\t\tisFlash = true;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\tif(!isFlash){\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\t\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6")), "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart4")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row5\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\" ) {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tname: \"appearance\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif(id == \"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Chart Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\tif(this.id == \"savebtn\")\r\n\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during preview", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\tif(this.id == \"savebtn\")\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\telse\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during preview", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row5\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"appearance\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				aColor = XVar.Clone(XVar.Array());
				i = new XVar(1);
				for(;i <= 14; i++)
				{
					aColor.InitAndSetArrayItem("", MVCFunctions.Concat("color", i, "1"));
					aColor.InitAndSetArrayItem("", MVCFunctions.Concat("color", i, "2"));
				}
				slegend_checked = new XVar("checked");
				sname_checked = new XVar("checked");
				sval_checked = new XVar("checked");
				sanim_checked = new XVar("checked");
				sgrid_checked = new XVar("");
				scur_checked = new XVar("");
				sstacked_checked = new XVar("");
				saxes_checked = new XVar("");
				slog_checked = new XVar("");
				isstacked_checked = new XVar("");
				is3d_checked = new XVar("");
				autoupdate_checked = new XVar("");
				update_interval_val = new XVar(5);
				cscroll_checked = new XVar("checked");
				maxbarscroll_val = new XVar(10);
				dec_val = new XVar(0);
				linestyle_val = new XVar(0);
				gaugestyle_val = new XVar(0);
				cview_val = new XVar(0);
				head_val = XVar.Clone(MVCFunctions.Concat("New Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))));
				foot_val = XVar.Clone(MVCFunctions.Concat("New Chart ", CommonFunctions.CheckLastID(new XVar(Constants.WR_CHART))));
				arr = XVar.Clone(XSession.Session["webcharts"]["appearance"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					i = new XVar(1);
					for(;i <= 14; i++)
					{
						aColor.InitAndSetArrayItem(arr[MVCFunctions.Concat("color", i, "1")], MVCFunctions.Concat("color", i, "1"));
						aColor.InitAndSetArrayItem(arr[MVCFunctions.Concat("color", i, "1")], MVCFunctions.Concat("color", i, "2"));
					}
					slegend_checked = XVar.Clone((XVar.Pack(arr["slegend"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					sgrid_checked = XVar.Clone((XVar.Pack(arr["sgrid"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					sname_checked = XVar.Clone((XVar.Pack(arr["sname"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					sval_checked = XVar.Clone((XVar.Pack(arr["sval"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					sanim_checked = XVar.Clone((XVar.Pack(arr["sanim"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					scur_checked = XVar.Clone((XVar.Pack(arr["scur"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					sstacked_checked = XVar.Clone((XVar.Pack(arr["sstacked"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					saxes_checked = XVar.Clone((XVar.Pack(arr["saxes"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					slog_checked = XVar.Clone((XVar.Pack(arr["slog"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					is3d_checked = XVar.Clone((XVar.Pack(arr["is3d"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					isstacked_checked = XVar.Clone((XVar.Pack(arr["isstacked"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					autoupdate_checked = XVar.Clone((XVar.Pack(arr["autoupdate"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					cscroll_checked = XVar.Clone((XVar.Pack(arr["cscroll"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					accumulinvert_checked = XVar.Clone((XVar.Pack(arr["accumulinvert"] == "true") ? XVar.Pack("checked") : XVar.Pack("")));
					accumulstyle_val = XVar.Clone(arr["accumulstyle"]);
					dec_val = XVar.Clone(arr["dec"]);
					aqua_val = XVar.Clone(arr["aqua"]);
					linestyle_val = XVar.Clone(arr["linestyle"]);
					gaugestyle_val = XVar.Clone(arr["gaugestyle"]);
					cview_val = XVar.Clone(arr["cview"]);
					head_val = XVar.Clone(arr["head"]);
					foot_val = XVar.Clone(arr["foot"]);
					update_interval_val = XVar.Clone(arr["update_interval"]);
					maxbarscroll_val = XVar.Clone(arr["maxbarscroll"]);
				}
				xt.assign(new XVar("slegend_checked"), (XVar)(slegend_checked));
				xt.assign(new XVar("sgrid_checked"), (XVar)(sgrid_checked));
				xt.assign(new XVar("sname_checked"), (XVar)(sname_checked));
				xt.assign(new XVar("sval_checked"), (XVar)(sval_checked));
				xt.assign(new XVar("sanim_checked"), (XVar)(sanim_checked));
				xt.assign(new XVar("scur_checked"), (XVar)(scur_checked));
				xt.assign(new XVar("sstacked_checked"), (XVar)(sstacked_checked));
				xt.assign(new XVar("saxes_checked"), (XVar)(saxes_checked));
				xt.assign(new XVar("slog_checked"), (XVar)(slog_checked));
				xt.assign(new XVar("isstacked_checked"), (XVar)(isstacked_checked));
				xt.assign(new XVar("is3d_checked"), (XVar)(is3d_checked));
				xt.assign(new XVar("autoupdate_checked"), (XVar)(autoupdate_checked));
				xt.assign(new XVar("cscroll_checked"), (XVar)(cscroll_checked));
				xt.assign(new XVar("accumulinvert_checked"), (XVar)(accumulinvert_checked));
				xt.assign(new XVar("dec_val"), (XVar)(dec_val));
				xt.assign(new XVar("head_val"), (XVar)(head_val));
				xt.assign(new XVar("foot_val"), (XVar)(foot_val));
				xt.assign(new XVar("maxbarscroll_val"), (XVar)(maxbarscroll_val));
				xt.assign(new XVar("update_interval_val"), (XVar)(update_interval_val));
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t$(document).ready(function(){\r\n\t\r\n\t\t\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n          $(\"select[id=aqua]\").find(\"option\").each(function(i){\r\n            if ( this.value == \"", aqua_val, "\" ) {\r\n              $(\"select[id=aqua]\")[0].selectedIndex = i;\r\n              return;\r\n            }\r\n          });\r\n          $(\"select[id=cview]\").find(\"option\").each(function(i){\r\n            if ( this.value == \"", cview_val, "\" ) {\r\n              $(\"select[id=cview]\")[0].selectedIndex = i;\r\n              return;\r\n            }\r\n          });\r\n\t\t  $(\"select[id=linestyle]\").find(\"option\").each(function(i){\r\n            if ( this.value == \"", linestyle_val, "\" ) {\r\n              $(\"select[id=linestyle]\")[0].selectedIndex = i;\r\n              return;\r\n            }\r\n          });\r\n\t\t  $(\"select[id=gaugestyle]\").find(\"option\").each(function(i){\r\n            if ( this.value == \"", gaugestyle_val, "\" ) {\r\n              $(\"select[id=gaugestyle]\")[0].selectedIndex = i;\r\n              return;\r\n            }\r\n          });\r\n\t\t  $(\"select[id=accumulstyle]\").find(\"option\").each(function(i){\r\n            if ( this.value == \"", accumulstyle_val, "\" ) {\r\n              $(\"select[id=accumulstyle]\")[0].selectedIndex = i;\r\n              return;\r\n            }\r\n          });\r\n\t\t  $(\"#autoupdate\").click(function()\r\n\t\t  {\r\n\t\t\t$(\"#sanim\").prop(\"checked\", false);\r\n\t\t  });\r\n\t\t  $(\"#sanim\").click(function()\r\n\t\t  {\r\n\t\t\t$(\"#autoupdate\").prop(\"checked\", false);\r\n\t\t  });\r\n\t\t  $(\"#isstacked\").click(function()\r\n\t\t  {\r\n\t\t\t$(\"#slog\").prop(\"checked\", false);\r\n\t\t  });\t\t  \r\n\t\t  $(\"#slog\").click(function()\r\n\t\t  {\r\n\t\t\t$(\"#isstacked\").prop(\"checked\", false);\r\n\t\t  });\t\r\n\t\t  \r\n", "\r\n");
				i = new XVar(5);
				for(;i <= 14; i++)
				{
					if(aColor[MVCFunctions.Concat("color", i, "1")] != "")
					{
						b_includes = MVCFunctions.Concat(b_includes, "$(\"div[id=picker", i, "]\").css(\"background-color\",\"#", aColor[MVCFunctions.Concat("color", i, "1")], "\");", "\r\n");
						b_includes = MVCFunctions.Concat(b_includes, "$(\"div[id=picker", i, "]\").attr(\"color1\",\"", aColor[MVCFunctions.Concat("color", i, "1")], "\");", "\r\n");
						b_includes = MVCFunctions.Concat(b_includes, "$(\"div[id=picker", i, "]\").attr(\"color2\",\"", aColor[MVCFunctions.Concat("color", i, "2")], "\");", "\r\n");
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n</script>");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("stacked"), (XVar)(MVCFunctions.Concat("<span id=\"td_stacked\" style=\"visibility:hidden\"><input type=\"checkbox\" ", sstacked_checked, " id=\"sstacked\" name=\"sstacked\" />&nbsp;", "100% Stacked", "</span>")));
				if((XVar)((XVar)((XVar)((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_column")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_bar"))  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "bubble"))  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_pie"))  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_doughnut"))
				{
					xt.assign(new XVar("chart_is_3d"), (XVar)(MVCFunctions.Concat("<input type=\"checkbox\" ", is3d_checked, " id=\"is3d\" name=\"is3d\">&nbsp;", "Chart 3D")));
				}
				else
				{
					xt.assign(new XVar("chart_is_3d"), new XVar(""));
				}
				if((XVar)((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_column")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "2d_bar"))  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "area"))
				{
					xt.assign(new XVar("chart_is_stacked"), (XVar)(MVCFunctions.Concat("<input type=\"checkbox\" ", isstacked_checked, " id=\"isstacked\" name=\"isstacked\">&nbsp;", "Chart stacked")));
				}
				else
				{
					xt.assign(new XVar("chart_is_stacked"), new XVar(""));
				}
				if(XVar.Pack(MVCFunctions.preg_match(new XVar("/bar/i"), (XVar)(XSession.Session["webcharts"]["chart_type"]["type"]))))
				{
					xt.assign(new XVar("aqua"), new XVar(MVCFunctions.Concat("Use Style", " <select name=\"aqua\" id=\"aqua\">\r\n\t\t<option value=\"0\">", "None", "</option>\r\n\t\t<option value=\"1\">", "AquaLight", "</option>\r\n\t\t<option value=\"2\">", "AquaDark", "</option>\r\n\t  </select>")));
					xt.assign(new XVar("cview"), new XVar(MVCFunctions.Concat("Chart Type", " <select name=\"cview\" id=\"cview\">\r\n\t\t<option value=\"0\">", "Column", "</option>\r\n\t\t<option value=\"1\">", "Cone", "</option>\r\n\t\t<option value=\"2\">", "Cylinder", "</option>\r\n\t\t<option value=\"3\">", "Pyramid", "</option>\r\n\t  </select>")));
				}
				else
				{
					xt.assign(new XVar("aqua"), new XVar(""));
					xt.assign(new XVar("cview"), new XVar(""));
				}
				if(XVar.Pack(MVCFunctions.preg_match(new XVar("/line/i"), (XVar)(XSession.Session["webcharts"]["chart_type"]["type"]))))
				{
					xt.assign(new XVar("line"), new XVar(MVCFunctions.Concat("&nbsp;&nbsp;&nbsp;&nbsp;", "Line Style", " <select name=\"linestyle\" id=\"linestyle\">\r\n\t\t<option value=\"0\">", "Normal", "</option>\r\n\t\t<option value=\"1\">", "Spline", "</option>\r\n\t\t<option value=\"2\">", "Step", "</option>\r\n\t  </select>")));
				}
				else
				{
					xt.assign(new XVar("line"), new XVar(""));
				}
				if(XVar.Pack(MVCFunctions.preg_match(new XVar("/funnel/i"), (XVar)(XSession.Session["webcharts"]["chart_type"]["type"]))))
				{
					xt.assign(new XVar("funnel"), new XVar("<td colspan=2>"));
					xt.assign(new XVar("tr_funnel"), new XVar(""));
				}
				else
				{
					xt.assign(new XVar("funnel"), new XVar("<td colspan=2 style=\"visibility:hidden;\">"));
					xt.assign(new XVar("tr_funnel"), new XVar("style=\"display:none\""));
				}
				if(XVar.Pack(MVCFunctions.preg_match(new XVar("/gauge/i"), (XVar)(XSession.Session["webcharts"]["chart_type"]["type"]))))
				{
					xt.assign(new XVar("gauge"), new XVar(MVCFunctions.Concat("Gauge style", " <select name=\"gaugestyle\" id=\"gaugestyle\">\r\n\t\t<option value=\"0\">", "Circle", "</option>\r\n\t\t<option value=\"1\">", "Horizontal", "</option>\r\n\t\t<option value=\"2\">", "Vertical", "</option>\r\n\t  </select>")));
				}
				else
				{
					xt.assign(new XVar("gauge"), new XVar(""));
				}
				xt.assign(new XVar("chart_name_preview"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				table_name = XVar.Clone(XSession.Session["webcharts"]["tables"][0]);
				xt.assign(new XVar("table_name"), (XVar)(table_name));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart5")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
