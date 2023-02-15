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
		public ActionResult webreport_sql()
		{
			try
			{
				dynamic arr_custom = XVar.Array(), b_includes = null, h_includes = null, sql_list = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(CommonFunctions.isWRAdmin())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("webreport")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				xt = XVar.UnPackXTempl(new XTempl());
				XSession.Session.InitAndSetArrayItem("custom", "webobject", "table_type");
				b_includes = new XVar("");
				h_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n$(document).ready(function(){\r\n\t$(\"a#a_editsql\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 850,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t$(\"a#a_resultsql\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 850,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t$(\"a#a_addsql\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 850,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "$(\"#backbtn\").click(function(){\r\n\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\treturn;\r\n\t\t});\r\n\t$(\"#fancy_overlay\").unbind();\r\n\t$(\"#addsql\").click(function(){\r\n\t\t$(\"#a_addsql\").click();\r\n\t});\r\n\t$(\"#editsql\").click(function(){\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"getcustomsql\",\r\n\t\t\t\toutput: $(\"#sql_list option:selected\").val(),\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg)\r\n\t\t\t{\r\n\t\t\t\t$(\"#a_editsql\").click();\r\n\t\t\t}\r\n\t\t});\r\n\t\t\r\n\t});\r\n\t$(\"#deletesql\").click(function(){\r\n\t\t$(\"#sql_list\").change();\r\n\t\tmess=\"<p>", "Do you really want to delete custom query %s ?", "</p>\";\r\n\t\tmess=mess.replace(\"%s\",$(\"#sql_list option:selected\").text());\r\n\t\t$(\"#alert\")\r\n\t\t\t.html(mess)\r\n\t\t\t.dialog(\"option\", \"buttons\", {\r\n\t\t\t\t\"No\": function() { $(this).dialog(\"close\"); },\r\n\t\t\t\t\"Delete\": function() {\r\n\t\t\t\t\t$.ajax({\r\n\t\t\t\t\t\ttype: \"POST\",\r\n\t\t\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\t\t\t\tdata: {\r\n\t\t\t\t\t\t\tname: \"deletesql\",\r\n\t\t\t\t\t\t\tidsql: $(\"#sql_list option:selected\").val(),\r\n\t\t\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t\t\twindow.location.reload();\r\n\t\t\t\t\t\t\t} else {\r\n\t\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\terror: function() {\r\n\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Try again later", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t});\t\t\t\t\r\n\t\t\t\t}\r\n\t\t\t})\r\n\t\t\t.dialog(\"open\");\r\n\t});\r\n\t$(\"#resultsql\").click(function(){\r\n\t\t$(\"#sql_list\").change();\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("web_query")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"resultsql\",\r\n\t\t\t\toutput: $(\"#sql_list option:selected\").val(),\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg)\r\n\t\t\t{\r\n\t\t\t\t$(\"#a_resultsql\").click();\r\n\t\t\t}\r\n\t\t});\r\n\t\t\r\n\t});\r\n\t$(\"#sql_list\").change(function(){\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"getcustomsql\",\r\n\t\t\t\toutput: $(\"#sql_list option:selected\").val(),\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg)\r\n\t\t\t{\r\n\t\t\t\t$(\"#sql_content\").html(msg);\r\n\t\t\t}\r\n\t\t});\r\n\t});");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("name"))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#sql_list option\").each(function(i){\r\n\t\tif($(this).text()==\"", MVCFunctions.str_replace(new XVar("\""), new XVar("\\\""), (XVar)(MVCFunctions.postvalue(new XVar("name")))), "\")\r\n\t\t\t$(this).attr(\"selected\",\"yes\");\r\n\t});\r\n\t");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#sql_list\").get(0).selectedIndex=0;\r\n\t$(\"#sql_list option:first\").attr(\"selected\", \"yes\");\r\n\t");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#sql_list\").change();");
				arr_custom = XVar.Clone(CommonFunctions.WRGetListCustomSQL());
				sql_list = new XVar("<select name=sql_list id=sql_list size=20 style='width:500px;font-size:11pt;'>");
				foreach (KeyValuePair<XVar, dynamic> value in arr_custom.GetEnumerator())
				{
					sql_list = MVCFunctions.Concat(sql_list, "<option value=\"", value.Value["id"], "\">", MVCFunctions.runner_htmlspecialchars((XVar)(value.Value["sqlname"])), "</option>");
				}
				sql_list = MVCFunctions.Concat(sql_list, "</select>");
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_custom)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#editsql,#deletesql,#resultsql\").attr(\"disabled\",\"disabled\")\r\n\t\t\t\t\t\t\t\t\t\t\t.css(\"color\",\"#847C7C\")\r\n\t\t\t\t\t\t\t\t\t\t\t.css(\"cursor\",\"default\");\r\n\t\t\r\n\t");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n});\r\n</script>", "\r\n");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					xt.assign(new XVar("saveexit"), new XVar(false));
				}
				else
				{
					xt.assign(new XVar("saveexit"), new XVar(true));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("sql_list"), (XVar)(sql_list));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport_sql")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
