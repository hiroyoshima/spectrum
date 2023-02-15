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
		public ActionResult webreport()
		{
			try
			{
				dynamic arrPrivateCharts = XVar.Array(), arrPrivateReports = XVar.Array(), arrSharedCharts = XVar.Array(), arrSharedReports = XVar.Array(), arr_UserGroups = null, arr_charts = XVar.Array(), arr_reports = XVar.Array(), arr_tables_custom = null, arr_tables_db = null, arr_tables_project = null, b_includes = null, cMaxTitleLength = null, create_butt = null, h_includes = null, private_charts = null, private_reports = null, shared_charts = null, shared_reports = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(CommonFunctions.isLoggedAsGuest()))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
				}
				cMaxTitleLength = new XVar(30);
				XSession.Session["back_to_menu"] = "true";
				XSession.Session["webreports_oldname"] = "";
				xt = XVar.UnPackXTempl(new XTempl());
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				arr_UserGroups = XVar.Clone(CommonFunctions.GetUserGroup());
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n$(document).ready(function(){\r\n\t$(\"#alert\").dialog({\r\n\t\ttitle: \"Message\",\r\n\t\tdraggable: false,\r\n\t\tresizable: false,\r\n\t\tbgiframe: true,\r\n\t\tautoOpen: false,\r\n\t\tmodal: true,\r\n\t\tbuttons: {\r\n\t\t\tOk: function() {\r\n\t\t\t\t$(this).dialog(\"close\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n\r\n\t$(\".view\").each(function(){\r\n\t\tvar type = $(this).attr(\"type\");\r\n\t\tvar scriptName = (type == \"report\") ? \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?rname=\" : \"", MVCFunctions.GetTableLink(new XVar("dchart")), "?cname=\";\r\n\t\tvar name = $(this).parent(\"span\").attr(\"id\");\r\n\t\tthis.href = scriptName + name;\r\n\t});\r\n\t\r\n\t\r\n\t$(\".del\").click(function(){\r\n\t\tvar type = $(this).attr(\"type\"),\r\n\t\t\tscriptName = (type == \"report\") ? \"dreport\" : \"dchart\",\r\n\t\t\tname = $(this).parent(\"span\").attr(\"id\"),\r\n\t\t\ttitle = $(this).parent(\"span\").attr(\"title\");\r\n\t\t\t\r\n\t\tvar mess = (type == \"report\") ? \"", "Do you really want to delete report %s ?", "\" : \"", "Do you really want to delete chart %s ?", "\";");
				b_includes = MVCFunctions.Concat(b_includes, "mess=mess.replace(\"%s\",title);\r\n\t\t$(\"#alert\")\r\n\t\t\t.html(\"<p>\"+mess+\"</p>\")\r\n\t\t\t.dialog(\"option\", \"buttons\", {\r\n\t\t\t\t\"", "No", "\": function() { $(this).dialog(\"close\"); },", "\"", "Delete");
				b_includes = MVCFunctions.Concat(b_includes, "\": function() {\r\n\t\t\t\t\t$.ajax({\r\n\t\t\t\t\t\ttype: \"POST\",\r\n\t\t\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\t\t\tdata: {\r\n\t\t\t\t\t\t\tdel: 1,\r\n\t\t\t\t\t\t\tweb: \"web\"+type+\"s\",\r\n\t\t\t\t\t\t\tname: \"\"+name,\r\n\t\t\t\t\t\t\towner: (type == \"report\") ? reportsList[name][\"owner\"] : chartsList[name][\"owner\"],\r\n\t\t\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t\t\twindow.location.reload();\r\n\t\t\t\t\t\t\t} else {\r\n\t\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\terror: function() {\r\n\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Try again later", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t});\t\t\t\t\r\n\t\t\t\t}\r\n\t\t\t})\r\n\t\t\t.dialog(\"open\");\t\t\r\n\t});\r\n\t\r\n\t$(\"#return_app\").click(function(){\r\n\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n    });");
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_UserGroups)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#admin_sql\").click(function(){\r\n\t\t\t$(\"#alert\").dialog(\"option\",\"title\",\"", "Enter password", "\");\r\n\t\t\t$(\"#alert\")\r\n\t\t\t\t.html(\"", "Password", ":&nbsp;<input type=password id=admin_password size=30 value=\\\"\\\">\")\r\n\t\t\t\t.dialog(\"option\", \"buttons\", {\r\n\t\t\t\t\t\"", "Cancel", "\": function() { $(this).dialog(\"close\"); },\r\n\t\t\t\t\t\"", "OK", "\": function() {\r\n\t\t\t\t\t\t$.ajax({\r\n\t\t\t\t\t\t\ttype: \"POST\",\r\n\t\t\t\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\t\t\t\t\tdata: {\r\n\t\t\t\t\t\t\t\tname: \"password\",\r\n\t\t\t\t\t\t\t\tpassword: $(\"#admin_password\").val(),\r\n\t\t\t\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t\t\t\twindow.location=\"", MVCFunctions.GetTableLink(new XVar("webreport_sql")), "\";\r\n\t\t\t\t\t\t\t\t} else {\r\n\t\t\t\t\t\t\t\t\t$(\"#alert\").dialog(\"option\", \"buttons\", {\"", "Cancel", "\": function() { $(this).dialog(\"close\");}});\r\n\t\t\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Invalid password", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t});\t\t\t\t\r\n\t\t\t\t\t}\r\n\t\t\t\t})\r\n\t\t\t\t.dialog(\"open\");\t\r\n\t\t});");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#admin_sql\").click(function(){\r\n\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport_sql")), "\";\r\n\t\t});");
				}
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#users_list\").click(function(){\r\n\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport_users_list")), "\";\r\n\t\t});");
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_UserGroups)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#admin_page\").click(function(){\r\n\t\t\t$(\"#alert\").dialog(\"option\",\"title\",\"", "Enter password", "\");\r\n\t\t\t$(\"#alert\")\r\n\t\t\t\t.html(\"", "Password", ":&nbsp;<input type=password id=admin_password size=30 value=\\\"\\\">\")\r\n\t\t\t\t.dialog(\"option\", \"buttons\", {\r\n\t\t\t\t\t\"", "Cancel", "\": function() { $(this).dialog(\"close\"); },\r\n\t\t\t\t\t\"", "OK", "\": function() {\r\n\t\t\t\t\t\t$.ajax({\r\n\t\t\t\t\t\t\ttype: \"POST\",\r\n\t\t\t\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\t\t\t\t\tdata: {\r\n\t\t\t\t\t\t\t\tname: \"password\",\r\n\t\t\t\t\t\t\t\tpassword: $(\"#admin_password\").val(),\r\n\t\t\t\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\t\t\t\twindow.location=\"", MVCFunctions.GetTableLink(new XVar("webreport_admin")), "\";\r\n\t\t\t\t\t\t\t\t} else {\r\n\t\t\t\t\t\t\t\t\t$(\"#alert\").dialog(\"option\", \"buttons\", {\"", "Cancel", "\": function() { $(this).dialog(\"close\");}});\r\n\t\t\t\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Invalid password", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t});\t\t\t\t\r\n\t\t\t\t\t}\r\n\t\t\t\t})\r\n\t\t\t\t.dialog(\"open\");\t\r\n\t\t});");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#admin_page\").click(function(){\r\n\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport_admin")), "\";});");
				}
				b_includes = MVCFunctions.Concat(b_includes, "$(\".edit\").click(function(){\r\n\t\tvar type = $(this).attr(\"type\");\r\n\t\tvar scriptName = (type == \"report\") ? \"", MVCFunctions.GetTableLink(new XVar("webreport0")), "\" : \"", MVCFunctions.GetTableLink(new XVar("webchart0")), "\";\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("get-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\ttype: \"open\",\r\n\t\t\t\tweb: \"web\"+type+\"s\",\r\n\t\t\t\tname: $(this).parent(\"span\").attr(\"id\"),\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\twindow.location = scriptName;\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\terror: function() {\r\n\t\t\t\t$(\"#alert\").html(\"<p>", "Try again later", "</p>\").dialog(\"open\");\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\r\n\t$(\"#report_createbtn, #chart_createbtn\").click(function(){\r\n\t\tvar type = $(this).attr(\"wtype\");\r\n\t\tvar scriptName = (type == \"report\") ? \"", MVCFunctions.GetTableLink(new XVar("webreport0")), "\" : \"", MVCFunctions.GetTableLink(new XVar("webchart0")), "\";\r\n\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("get-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\ttype: \"new\",\r\n\t\t\t\tweb: \"web\"+type+\"s\",\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\twindow.location = scriptName;\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\t\t\t\t\t\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\terror: function() {\r\n\t\t\t\t$(\"#alert\").html(\"<p>", "Try again later", "</p>\").dialog(\"open\");\t\t\t\t\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n});", "\r\n");
				shared_reports = new XVar("");
				private_reports = new XVar("");
				shared_charts = new XVar("");
				private_charts = new XVar("");
				arr_reports = XVar.Clone(XVar.Array());
				arrPrivateReports = XVar.Clone(XVar.Array());
				arrSharedReports = XVar.Clone(XVar.Array());
				arr_charts = XVar.Clone(XVar.Array());
				arrPrivateCharts = XVar.Clone(XVar.Array());
				arrSharedCharts = XVar.Clone(XVar.Array());
				arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_REPORT)));
				foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
				{
					if((XVar)((XVar)(MVCFunctions.trim((XVar)(rpt.Value["owner"])) != Security.getUserName())  || (XVar)(MVCFunctions.trim((XVar)(rpt.Value["owner"])) == ""))  && (XVar)(rpt.Value["status"] == "public"))
					{
						arrSharedReports.InitAndSetArrayItem(rpt.Value, null);
					}
					else
					{
						if(MVCFunctions.trim((XVar)(rpt.Value["owner"])) == Security.getUserName())
						{
							arrPrivateReports.InitAndSetArrayItem(rpt.Value, null);
						}
					}
				}
				arr_charts = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_CHART)));
				foreach (KeyValuePair<XVar, dynamic> chart in arr_charts.GetEnumerator())
				{
					if((XVar)((XVar)(MVCFunctions.trim((XVar)(chart.Value["owner"])) != Security.getUserName())  || (XVar)(MVCFunctions.trim((XVar)(chart.Value["owner"])) == ""))  && (XVar)(chart.Value["status"] == "public"))
					{
						arrSharedCharts.InitAndSetArrayItem(chart.Value, null);
					}
					else
					{
						if(MVCFunctions.trim((XVar)(chart.Value["owner"])) == Security.getUserName())
						{
							arrPrivateCharts.InitAndSetArrayItem(chart.Value, null);
						}
					}
				}
				arr_tables_db = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("db")));
				arr_tables_project = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("project")));
				arr_tables_custom = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("custom")));
				if(XVar.Pack(Security.permissionsAvailable()))
				{
					foreach (KeyValuePair<XVar, dynamic> rpt in arrSharedReports.GetEnumerator())
					{
						if((XVar)(rpt.Value["status"] == "public")  && (XVar)((XVar)(rpt.Value["view"])  || (XVar)(rpt.Value["edit"])))
						{
							shared_reports = MVCFunctions.Concat(shared_reports, "<div style=\"margin-bottom:5px;\">");
							shared_reports = MVCFunctions.Concat(shared_reports, "<span class=\"ritem\" id=\"", rpt.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(rpt.Value["title"])), "\">");
							shared_reports = MVCFunctions.Concat(shared_reports, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(rpt.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(rpt.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(rpt.Value["title"])));
							if(XVar.Pack(rpt.Value["view"]))
							{
								shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action view\" type=\"report\" href=\"#\">[", "View", "]</a>");
							}
							if(XVar.Pack(rpt.Value["edit"]))
							{
								if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
								{
									shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action edit\" type=\"report\" href=\"#\">[", "Edit", "]</a>");
								}
								shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action del\" type=\"report\" href=\"#\">[", "Delete", "]</a>");
							}
							shared_reports = MVCFunctions.Concat(shared_reports, "</span>");
							shared_reports = MVCFunctions.Concat(shared_reports, "</div>", "\r\n");
						}
					}
					foreach (KeyValuePair<XVar, dynamic> chart in arrSharedCharts.GetEnumerator())
					{
						if((XVar)(chart.Value["status"] == "public")  && (XVar)((XVar)(chart.Value["view"])  || (XVar)(chart.Value["edit"])))
						{
							shared_charts = MVCFunctions.Concat(shared_charts, "<div style=\"margin-bottom:5px;\">");
							shared_charts = MVCFunctions.Concat(shared_charts, "<span class=\"ritem\" id=\"", chart.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(chart.Value["title"])), "\">");
							shared_charts = MVCFunctions.Concat(shared_charts, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(chart.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(chart.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(chart.Value["title"])));
							if(XVar.Pack(chart.Value["view"]))
							{
								shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action view\" type=\"chart\" href=\"#\">[", "View", "]</a>");
							}
							if(XVar.Pack(chart.Value["edit"]))
							{
								if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
								{
									shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action edit\" type=\"chart\" href=\"#\">[", "Edit", "]</a>");
								}
								shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action del\" type=\"chart\" href=\"#\">[", "Delete", "]</a>");
							}
							shared_charts = MVCFunctions.Concat(shared_charts, "</span>");
							shared_charts = MVCFunctions.Concat(shared_charts, "</div>", "\r\n");
						}
					}
				}
				else
				{
					foreach (KeyValuePair<XVar, dynamic> rpt in arrSharedReports.GetEnumerator())
					{
						shared_reports = MVCFunctions.Concat(shared_reports, "<div style=\"margin-bottom:5px;\">");
						shared_reports = MVCFunctions.Concat(shared_reports, "<span class=\"ritem\" id=\"", rpt.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(rpt.Value["title"])), "\">");
						shared_reports = MVCFunctions.Concat(shared_reports, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(rpt.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(rpt.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(rpt.Value["title"])));
						shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action view\" type=\"report\" href=\"#\">[", "View", "]</a>");
						if(MVCFunctions.trim((XVar)(rpt.Value["owner"])) == Security.getUserName())
						{
							if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
							{
								shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action edit\" type=\"report\" href=\"#\">[", "Edit", "]</a>");
							}
							shared_reports = MVCFunctions.Concat(shared_reports, "<a class=\"action del\" type=\"report\" href=\"#\">[", "Delete", "]</a>");
						}
						shared_reports = MVCFunctions.Concat(shared_reports, "</span>");
						shared_reports = MVCFunctions.Concat(shared_reports, "</div>", "\r\n");
					}
					foreach (KeyValuePair<XVar, dynamic> chart in arrSharedCharts.GetEnumerator())
					{
						shared_charts = MVCFunctions.Concat(shared_charts, "<div style=\"margin-bottom:5px;\">");
						shared_charts = MVCFunctions.Concat(shared_charts, "<span class=\"ritem\" id=\"", chart.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(chart.Value["title"])), "\">");
						shared_charts = MVCFunctions.Concat(shared_charts, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(chart.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(chart.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(chart.Value["title"])));
						shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action view\" type=\"chart\" href=\"#\">[", "View", "]</a>");
						if(MVCFunctions.trim((XVar)(chart.Value["owner"])) == Security.getUserName())
						{
							if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
							{
								shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action edit\" type=\"chart\" href=\"#\">[", "Edit", "]</a>");
							}
							shared_charts = MVCFunctions.Concat(shared_charts, "<a class=\"action del\" type=\"chart\" href=\"#\">[", "Delete", "]</a>");
						}
						shared_charts = MVCFunctions.Concat(shared_charts, "</span>");
						shared_charts = MVCFunctions.Concat(shared_charts, "</div>", "\r\n");
					}
				}
				foreach (KeyValuePair<XVar, dynamic> rpt in arrPrivateReports.GetEnumerator())
				{
					if(rpt.Value["status"] == "public")
					{
						private_reports = MVCFunctions.Concat(private_reports, "<div style=\"margin-bottom:5px;\">");
						private_reports = MVCFunctions.Concat(private_reports, "<span class=\"ritem\" id=\"", rpt.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(rpt.Value["title"])), "\">");
						private_reports = MVCFunctions.Concat(private_reports, "<img src=\"images/unlock16.png\" title=\"", "Public report", "\"/>");
						private_reports = MVCFunctions.Concat(private_reports, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(rpt.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(rpt.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(rpt.Value["title"])));
						private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action view\" type=\"report\" href=\"#\">[", "View", "]</a>");
						if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
						{
							private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action edit\" type=\"report\" href=\"#\">[", "Edit", "]</a>");
						}
						private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action del\" type=\"report\" href=\"#\">[", "Delete", "]</a>");
						private_reports = MVCFunctions.Concat(private_reports, "</span>");
						private_reports = MVCFunctions.Concat(private_reports, "</div>", "\r\n");
					}
					else
					{
						private_reports = MVCFunctions.Concat(private_reports, "<div style=\"margin-bottom:5px;\">");
						private_reports = MVCFunctions.Concat(private_reports, "<span class=\"ritem\" id=\"", rpt.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(rpt.Value["title"])), "\">");
						private_reports = MVCFunctions.Concat(private_reports, "<img src=\"images/lock16.png\" title=\"", "Private report", "\"/>");
						private_reports = MVCFunctions.Concat(private_reports, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(rpt.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(rpt.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(rpt.Value["title"])));
						private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action view\" type=\"report\" href=\"#\">[", "View", "]</a>");
						if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
						{
							private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action edit\" type=\"report\" href=\"#\">[", "Edit", "]</a>");
						}
						private_reports = MVCFunctions.Concat(private_reports, "<a class=\"action del\" type=\"report\" href=\"#\">[", "Delete", "]</a>");
						private_reports = MVCFunctions.Concat(private_reports, "</span>");
						private_reports = MVCFunctions.Concat(private_reports, "</div>", "\r\n");
					}
				}
				foreach (KeyValuePair<XVar, dynamic> chart in arrPrivateCharts.GetEnumerator())
				{
					if(chart.Value["status"] == "public")
					{
						private_charts = MVCFunctions.Concat(private_charts, "<div style=\"margin-bottom:5px;\">");
						private_charts = MVCFunctions.Concat(private_charts, "<span class=\"ritem\" id=\"", chart.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(chart.Value["title"])), "\">");
						private_charts = MVCFunctions.Concat(private_charts, "<img src=\"images/unlock16.png\" title=\"", "Public chart", "\"/>");
						private_charts = MVCFunctions.Concat(private_charts, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(chart.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(chart.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(chart.Value["title"])));
						private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action view\" type=\"chart\" href=\"#\">[", "View", "]</a>");
						if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
						{
							private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action edit\" type=\"chart\" href=\"#\">[", "Edit", "]</a>");
						}
						private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action del\" type=\"chart\" href=\"#\">[", "Delete", "]</a>");
						private_charts = MVCFunctions.Concat(private_charts, "</span>");
						private_charts = MVCFunctions.Concat(private_charts, "</div>", "\r\n");
					}
					else
					{
						private_charts = MVCFunctions.Concat(private_charts, "<div style=\"margin-bottom:5px;\">");
						private_charts = MVCFunctions.Concat(private_charts, "<span class=\"ritem\" id=\"", chart.Value["name"], "\" title=\"", MVCFunctions.runner_htmlspecialchars((XVar)(chart.Value["title"])), "\">");
						private_charts = MVCFunctions.Concat(private_charts, "<img src=\"images/lock16.png\" title=\"", "Private chart", "\"/>");
						private_charts = MVCFunctions.Concat(private_charts, (XVar.Pack(cMaxTitleLength + 5 < MVCFunctions.strlen((XVar)(chart.Value["title"]))) ? XVar.Pack(MVCFunctions.Concat(MVCFunctions.substr((XVar)(chart.Value["title"]), new XVar(0), (XVar)(cMaxTitleLength)), "...")) : XVar.Pack(chart.Value["title"])));
						private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action view\" type=\"chart\" href=\"#\">[", "View", "]</a>");
						if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
						{
							private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action edit\" type=\"chart\" href=\"#\">[", "Edit", "]</a>");
						}
						private_charts = MVCFunctions.Concat(private_charts, "<a class=\"action del\" type=\"chart\" href=\"#\">[", "Delete", "]</a>");
						private_charts = MVCFunctions.Concat(private_charts, "</span>");
						private_charts = MVCFunctions.Concat(private_charts, "</div>", "\r\n");
					}
				}
				xt.assign(new XVar("css_height_report"), new XVar("height:100px;"));
				xt.assign(new XVar("css_height_chart"), new XVar("height:100px;"));
				if((XVar)((XVar)(6 < CommonFunctions.pre8count((XVar)(arrPrivateReports)))  || (XVar)(6 < CommonFunctions.pre8count((XVar)(arrSharedReports))))  || (XVar)((XVar)(6 < CommonFunctions.pre8count((XVar)(arrPrivateCharts)))  || (XVar)(6 < MVCFunctions.count(arrSharedCharts))))
				{
					xt.assign(new XVar("css_height_report"), new XVar("height:200px;"));
					xt.assign(new XVar("css_height_chart"), new XVar("height:200px;"));
				}
				b_includes = MVCFunctions.Concat(b_includes, "var reportsList = new Array();", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "var chartsList = new Array();", "\r\n");
				foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
				{
					b_includes = MVCFunctions.Concat(b_includes, "reportsList[\"", rpt.Value["name"], "\"] = new Array();", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "reportsList[\"", rpt.Value["name"], "\"][\"status\"] = \"", rpt.Value["status"], "\";", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "reportsList[\"", rpt.Value["name"], "\"][\"owner\"] = \"", rpt.Value["owner"], "\";", "\r\n");
				}
				foreach (KeyValuePair<XVar, dynamic> chart in arr_charts.GetEnumerator())
				{
					b_includes = MVCFunctions.Concat(b_includes, "chartsList[\"", chart.Value["name"], "\"] = new Array();", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "chartsList[\"", chart.Value["name"], "\"][\"status\"] = \"", chart.Value["status"], "\";", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "chartsList[\"", chart.Value["name"], "\"][\"owner\"] = \"", chart.Value["owner"], "\";", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "</script>", "\r\n");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				if((XVar)(CommonFunctions.isWRAdmin())  || (XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_UserGroups)))))
				{
					create_butt = XVar.Clone(MVCFunctions.Concat("<a id=\"admin_page\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"admin_page\" href=\"#\">", "Admin Area", "</a>"));
					xt.assign(new XVar("admin_page"), (XVar)(create_butt));
				}
				if(XVar.Pack(!(XVar)(GlobalVars.wr_is_standalone)))
				{
					create_butt = XVar.Clone(MVCFunctions.Concat("<a id=\"return_app\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"return_app\" href=\"#\">", "Back to main application", "</a>"));
					xt.assign(new XVar("back_to_app"), (XVar)(create_butt));
				}
				if((XVar)(GlobalVars.wr_is_standalone)  && (XVar)(CommonFunctions.isWRAdmin()))
				{
					create_butt = XVar.Clone(MVCFunctions.Concat("<a id=\"users_list\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"users_list\" href=\"#\">", "Users list", "</a>"));
					xt.assign(new XVar("users_list_page"), (XVar)(create_butt));
				}
				if(XVar.Pack(Security.hasLogin()))
				{
					dynamic strLogin = null;
					if(XVar.Pack(CommonFunctions.isLoggedAsGuest()))
					{
						strLogin = XVar.Clone(MVCFunctions.Concat("<A class=tablelinks href=\"", MVCFunctions.GetTableLink(new XVar("login")), "\">Log in</A>"));
					}
					else
					{
						strLogin = XVar.Clone(MVCFunctions.Concat("Logged on as", " <b>", XSession.Session["UserName"], "</b>&nbsp;&nbsp;&nbsp;<A class=tablelinks href=\"", MVCFunctions.GetTableLink(new XVar("login")), "?a=logout\">", "Log out", "</A>"));
					}
					xt.assign(new XVar("login_mess"), (XVar)(strLogin));
				}
				if((XVar)(CommonFunctions.isWRAdmin())  || (XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_UserGroups)))))
				{
					create_butt = XVar.Clone(MVCFunctions.Concat("<a id=\"admin_sql\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"admin_sql\" href=\"#\">", "Custom SQL", "</a>"));
					xt.assign(new XVar("admin_sql"), (XVar)(create_butt));
				}
				else
				{
					xt.assign(new XVar("admin_sql"), new XVar(false));
				}
				if((XVar)((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))  || (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))
				{
					create_butt = XVar.Clone(MVCFunctions.Concat("<a id=\"report_createbtn\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"report_createbtn\" wtype=\"report\" href=\"#\">", "Create Report", "</a>"));
					create_butt = MVCFunctions.Concat(create_butt, "<a id=\"chart_createbtn\" class=\"rnr-button\" onmouseover=\"this.focus();\" name=\"chart_createbtn\" wtype=\"chart\" href=\"#\">", "Create chart", "</a>");
					xt.assign(new XVar("create_report_chart"), (XVar)(create_butt));
				}
				else
				{
					if((XVar)(GlobalVars.wr_is_standalone)  && (XVar)(!(XVar)(CommonFunctions.isWRAdmin())))
					{
						xt.assign(new XVar("create_report_chart"), new XVar(MVCFunctions.Concat("<b>", "You do not have permissions to create reports and charts. Contact administrator in this regard.", "</b>")));
					}
				}
				if((XVar)(Security.isGuest())  && (XVar)(GlobalVars.wr_is_standalone))
				{
					xt.assign(new XVar("create_report_chart"), new XVar(MVCFunctions.Concat("<b>", "You do not have permissions to create reports and charts. Contact administrator in this regard.", "</b>")));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("shared_reports"), (XVar)(shared_reports));
				xt.assign(new XVar("private_reports"), (XVar)(private_reports));
				xt.assign(new XVar("shared_charts"), (XVar)(shared_charts));
				xt.assign(new XVar("private_charts"), (XVar)(private_charts));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
