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
		public ActionResult webreport9()
		{
			try
			{
				dynamic arr = XVar.Array(), arrUserGroups = XVar.Array(), b_includes = null, h_includes = null, rLinks = null, ri = null, templatefile = null, userGroups = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.GetTableLink(new XVar("webreport"));
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				CommonFunctions.Reload_Report((XVar)(MVCFunctions.postvalue(new XVar("rname"))));
				xt = XVar.UnPackXTempl(new XTempl());
				if(XSession.Session["webreports"]["settings"]["title"] != "")
				{
					dynamic title = null;
					title = XVar.Clone(XSession.Session["webreports"]["settings"]["title"]);
					if(25 < MVCFunctions.strlen((XVar)(title)))
					{
						title = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(title), new XVar(25)), "..."));
					}
					xt.assign(new XVar("report_title"), (XVar)(MVCFunctions.Concat(", ", "Title", ": ", title)));
				}
				else
				{
					xt.assign(new XVar("report_title"), new XVar(""));
				}
				if(XSession.Session["webreports"]["tables"][0] != "")
				{
					dynamic stable = null;
					stable = XVar.Clone(XSession.Session["webreports"]["tables"][0]);
					if(25 < MVCFunctions.strlen((XVar)(stable)))
					{
						stable = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(stable), new XVar(25)), "..."));
					}
					xt.assign(new XVar("report_table"), (XVar)(MVCFunctions.Concat(", ", "Table", ": ", stable)));
				}
				else
				{
					xt.assign(new XVar("report_table"), new XVar(""));
				}
				xt.assign(new XVar("b_is_report_save"), (XVar)(XSession.Session["webreports"]["tmp_active"] != "x"));
				xt.assign(new XVar("b_is_report_name"), (XVar)(XSession.Session["webreports"]["settings"]["name"] != ""));
				xt.assign(new XVar("report_name"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200;\r\nvar closetimer\t= 0;\r\nvar relation_stack = [];\r\n\r\n$(document).ready(function(){\r\n\t\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.permissions = [];\r\n\t\t$(\"#ugroups\").children().each(function(i){\r\n\t\t\toutput.permissions[i] = {\r\n\t\t\t\tid   : this.value,\r\n\t\t\t\tname : this.text.replace(/&lt;|&gt;|<|>/g,\"\"),\r\n\t\t\t\tview : $(\"#view_prm_\"+this.value).prop(\"checked\").toString(),\r\n\t\t\t\tedit : $(\"#edit_prm_\"+this.value).prop(\"checked\").toString()\r\n\t\t\t};\r\n\t\t});\r\n\t\t\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\t\r\n\t$.each(userGroups, function(i,n){\r\n\t\tvar checked = \"\";\r\n\t\tif ( n >= -1 ) {\r\n\t\t\tchecked = 'checked=\"true\"';\r\n\t\t}\r\n\t\tguest_d=\"\";");
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "if(n==\"Guest\")\r\n\t\t\t\tguest_d=\"disabled\";");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#viewBox\").append('<input id=\"view_prm_' + n + '\" type=\"checkbox\" style=\"display:none;\" ' + checked + ' name=\"add_prm_' + n + '\">');\r\n\t\t$(\"#editBox\").append('<input id=\"edit_prm_' + n + '\" '+guest_d+' type=\"checkbox\" style=\"display:none;\" ' + checked + ' name=\"edit_prm_' + n + '\">');\r\n\t});\r\n\r\n\t$(\"#ugroups\").change(function(){\r\n\t\tvar id = $(this).children(\":selected\").val();\r\n\t\t$(\"input[type=checkbox][id^=view_prm_]\").hide();\r\n\t\t$(\"input[type=checkbox][id^=edit_prm_]\").hide();\r\n\t\t$(\"#view_prm_\"+id).show();\r\n\t\t$(\"#edit_prm_\"+id).show();\r\n\t});\r\n\t\r\n\t$(\"#ugroups\")[0].selectedIndex = 0;\r\n\t$(\"#ugroups\").change();\t\r\n\t\r\n\t$(\"#row9\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(MVCFunctions.count(CommonFunctions.GetUserGroups()) < 2)  || (XVar)((XVar)(XSession.Session["webreports"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webreports"]["settings"]["c"] == "private")))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row9]\").hide();", "\r\n");
				}
				if((XVar)(CommonFunctions.is_wr_project())  || (XVar)(CommonFunctions.is_wr_custom()))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row1], td[id=row2]\").hide();", "\r\n");
				}
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row11]\").hide();", "\n");
				}
				if(XSession.Session["webreports"]["settings"]["title"] == "")
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\tfor (var i=2; i<=9; i++){\r\n\t\t\t$(\"td[id=row\" + i + \"]\").hide();\r\n\t\t};\r\n\t", "\r\n");
				}
				if(XSession.Session["webreports"]["group_fields"][MVCFunctions.count(XSession.Session["webreports"]["group_fields"]) - 1]["cross_table"] == "true")
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#row5,#row6\").hide();", "\r\n");
				}
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webreport", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#backbtn, td[id^=row], #savebtn, #saveasbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row9\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( this.id == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\t\t\t\r\n\t\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\tif( this.id == \"savebtn\" ) {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: 1,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"permissions\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row9\" && this.id !=\"savebtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"permissions\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\")\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">");
				b_includes = MVCFunctions.Concat(b_includes, "var userGroups = new Array();", "\r\n");
				userGroups = new XVar("");
				arrUserGroups = XVar.Clone(CommonFunctions.GetUserGroups());
				foreach (KeyValuePair<XVar, dynamic> _arr in arrUserGroups.GetEnumerator())
				{
					userGroups = MVCFunctions.Concat(userGroups, "<option value=\"", _arr.Value[0], "\">", MVCFunctions.runner_htmlspecialchars((XVar)(_arr.Value[1])), "</option>");
					b_includes = MVCFunctions.Concat(b_includes, "userGroups.push(\"", _arr.Value[0], "\");", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "</script>");
				arr = XVar.Clone(XSession.Session["webreports"]["permissions"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					dynamic i = null;
					b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t\t\t$(document).ready(function(){", "\n");
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr); i++)
					{
						b_includes = MVCFunctions.Concat(b_includes, "$(\"#view_prm_\"+\"", arr[i]["id"], "\").get(0).checked = ", arr[i]["view"], ";", "\n");
						b_includes = MVCFunctions.Concat(b_includes, "$(\"#edit_prm_\"+\"", arr[i]["id"], "\").get(0).checked = ", arr[i]["edit"], ";", "\n");
					}
					b_includes = MVCFunctions.Concat(b_includes, "});\r\n\t</script>");
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("userGroups"), (XVar)(userGroups));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport9")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
