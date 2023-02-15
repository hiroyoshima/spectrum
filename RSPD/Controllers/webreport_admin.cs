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
		public ActionResult webreport_admin()
		{
			try
			{
				dynamic arr_UserGroups = XVar.Array(), arr_tables_custom = XVar.Array(), arr_tables_db = XVar.Array(), arr_tables_project = XVar.Array(), b_includes = null, groupSelected = null, group_list = null, groups = XVar.Array(), h_includes = null, i = null, table_list = null, tables_admin_custom = XVar.Array(), tables_admin_db = XVar.Array(), tables_admin_project = XVar.Array(), templatefile = null, wr_user = null;
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
				tables_admin_db = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("db")));
				tables_admin_project = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("project")));
				tables_admin_custom = XVar.Clone(CommonFunctions.WRGetTableListAdmin(new XVar("custom")));
				arr_tables_db = XVar.Clone(CommonFunctions.DBGetTablesList());
				arr_tables_project = XVar.Clone(CommonFunctions.GetTablesListReport());
				arr_tables_custom = XVar.Clone(CommonFunctions.GetTablesListCustom());
				groups = XVar.Clone(XVar.Array());
				if(XVar.Pack(!(XVar)(GlobalVars.wr_is_standalone)))
				{
					arr_UserGroups = XVar.Clone(CommonFunctions.GetUserGroups());
				}
				else
				{
					arr_UserGroups = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> value in CommonFunctions.GetUserGroups().GetEnumerator())
					{
						if(value.Value[0] != "Guest")
						{
							arr_UserGroups.InitAndSetArrayItem(value.Value, null);
						}
					}
				}
				group_list = new XVar("");
				groupSelected = new XVar("");
				wr_user = XVar.Clone(MVCFunctions.postvalue(new XVar("username")));
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("editid1"))))
					{
						dynamic _connection = null, data = XVar.Array(), sql = null;
						_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
						sql = XVar.Clone(MVCFunctions.Concat("select ", _connection.addFieldWrappers(new XVar("username")), " from ", _connection.addTableWrappers(new XVar("webreport_users")), " where ", _connection.addFieldWrappers(new XVar("id")), "=", MVCFunctions.postvalue(new XVar("editid1"))));
						data = XVar.Clone(_connection.query((XVar)(sql)).fetchNumeric());
						if(XVar.Pack(CommonFunctions.pre8count((XVar)(data))))
						{
							wr_user = XVar.Clone(data[0]);
						}
					}
				}
				if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_UserGroups))))
				{
					MVCFunctions.usort((XVar)(arr_UserGroups), new XVar("sortUserGroup"));
					groups = XVar.Clone(arr_UserGroups);
					i = new XVar(0);
					if(XVar.Pack(!(XVar)(GlobalVars.wr_is_standalone)))
					{
						xt.assign(new XVar("group_header"), new XVar("User Groups"));
					}
					else
					{
						xt.assign(new XVar("group_header"), new XVar("Users"));
					}
					group_list = new XVar("<select name=select_group_list id=select_group_list size=3 style='width:150px;");
					group_list = MVCFunctions.Concat(group_list, "'>");
					foreach (KeyValuePair<XVar, dynamic> val in arr_UserGroups.GetEnumerator())
					{
						dynamic sel = null;
						sel = new XVar("");
						if((XVar)((XVar)(wr_user == XVar.Pack(""))  && (XVar)(i == XVar.Pack(0)))  || (XVar)(wr_user == val.Value[0]))
						{
							sel = new XVar(" selected");
							groupSelected = XVar.Clone(val.Value[0]);
						}
						group_list = MVCFunctions.Concat(group_list, "<option value=\"", i, "\"", sel, ">", MVCFunctions.runner_htmlspecialchars((XVar)(val.Value[1])), "</option>");
						i++;
					}
					group_list = MVCFunctions.Concat(group_list, "</select>");
				}
				else
				{
					groups.InitAndSetArrayItem(new XVar(0, "", 1, ""), null);
					group_list = MVCFunctions.Concat(group_list, "<select name=select_group_list id=select_group_list size=0 style='display:none'><option value=\"0\" selected>0</option></select>");
				}
				table_list = new XVar("");
				i = new XVar(0);
				foreach (KeyValuePair<XVar, dynamic> group_name in groups.GetEnumerator())
				{
					dynamic chbox = null;
					table_list = MVCFunctions.Concat(table_list, "<span id=\"group_db_", i, "\" ");
					if(groupSelected != group_name.Value[0])
					{
						table_list = MVCFunctions.Concat(table_list, "style='display:none;' ");
					}
					table_list = MVCFunctions.Concat(table_list, ">\n");
					foreach (KeyValuePair<XVar, dynamic> table in arr_tables_db.GetEnumerator())
					{
						chbox = new XVar("");
						foreach (KeyValuePair<XVar, dynamic> val in tables_admin_db.GetEnumerator())
						{
							if((XVar)(table.Value == val.Value["tablename"])  && (XVar)(group_name.Value[0] == val.Value["group"]))
							{
								chbox = new XVar(" checked");
							}
						}
						table_list = MVCFunctions.Concat(table_list, "<input type=\"checkbox\" dbname=\"db\" groupname=\"", MVCFunctions.runner_htmlspecialchars((XVar)(group_name.Value[0])), "\" id=\"adm_tables_", table.Key, "_", i, "_db\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(table.Value)), "\" ", chbox, ">&nbsp;&nbsp;", table.Value, "<br>\n");
					}
					table_list = MVCFunctions.Concat(table_list, "</span>\n");
					table_list = MVCFunctions.Concat(table_list, "<span id=\"group_project_", i, "\" ");
					table_list = MVCFunctions.Concat(table_list, "style='display:none;' ");
					table_list = MVCFunctions.Concat(table_list, ">\n");
					foreach (KeyValuePair<XVar, dynamic> table in arr_tables_project.GetEnumerator())
					{
						chbox = new XVar("");
						foreach (KeyValuePair<XVar, dynamic> val in tables_admin_project.GetEnumerator())
						{
							if((XVar)(table.Value == val.Value["tablename"])  && (XVar)(group_name.Value[0] == val.Value["group"]))
							{
								chbox = new XVar(" checked");
							}
						}
						table_list = MVCFunctions.Concat(table_list, "<input type=\"checkbox\" dbname=\"project\" groupname=\"", MVCFunctions.runner_htmlspecialchars((XVar)(group_name.Value[0])), "\" id=\"adm_tables_", table.Key, "_", i, "_project\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(table.Value)), "\" ", chbox, ">&nbsp;&nbsp;", table.Value, "<br>\n");
					}
					table_list = MVCFunctions.Concat(table_list, "</span>\n");
					table_list = MVCFunctions.Concat(table_list, "<span id=\"group_custom_", i, "\" ");
					table_list = MVCFunctions.Concat(table_list, "style='display:none;' ");
					table_list = MVCFunctions.Concat(table_list, ">\n");
					foreach (KeyValuePair<XVar, dynamic> table in arr_tables_custom.GetEnumerator())
					{
						dynamic custom_bold1 = null, custom_bold2 = null;
						chbox = new XVar("");
						foreach (KeyValuePair<XVar, dynamic> val in tables_admin_custom.GetEnumerator())
						{
							if((XVar)(table.Value["sqlname"] == val.Value["tablename"])  && (XVar)(group_name.Value[0] == val.Value["group"]))
							{
								chbox = new XVar(" checked");
							}
						}
						custom_bold1 = new XVar("");
						custom_bold2 = new XVar("");
						if(MVCFunctions.postvalue(new XVar("queryname")) == table.Value["sqlname"])
						{
							custom_bold1 = new XVar("<b>");
							custom_bold2 = new XVar("</b>");
						}
						table_list = MVCFunctions.Concat(table_list, "<input type=\"checkbox\" dbname=\"custom\" groupname=\"", MVCFunctions.runner_htmlspecialchars((XVar)(group_name.Value[0])), "\" id=\"adm_tables_", table.Key, "_", i, "_custom\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(table.Value["sqlname"])), "\" ", chbox, ">&nbsp;&nbsp;", custom_bold1, table.Value["sqlname"], custom_bold2, "<br>\n");
					}
					table_list = MVCFunctions.Concat(table_list, "</span>\n");
					i++;
				}
				b_includes = new XVar("");
				h_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/stylesheet.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n$(document).ready(function(){");
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#li_project\").hide();");
				}
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tli_selected=\"db\";\r\n\t$(function() {\r\n\t\t$(\"#radio_select_table\").tabs();\r\n\t});\r\n\t$(\"li\").css(\"list-style-type\",\"none\");\t\r\n\t$(\".selected\").css(\"padding-bottom\",\"0px\");\r\n\t$(\"#backbtn\").click(function(){\r\n\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\treturn;\r\n\t});\r\n\t$(\"#select_group_list\").click(function(){\r\n\t\tdb_type=li_selected;\r\n\t\t$(\"span[id^=group_\"+db_type+\"]\").css(\"display\",\"none\");\r\n\t\tgr=$(\"select[id=select_group_list] option:selected\").val();\r\n\t\t$(\"#group_\"+db_type+\"_\"+gr).css(\"display\",\"\");\r\n\t\tcheck_all_box();\r\n\t});\r\n\t\r\n\t$(\"#saveexitbtn\").click(function(){\r\n\t\ti=0;\r\n\t\toutput = {};\r\n\t\t$(\"input[id^=adm_tables]\").each(function()\r\n\t\t{\r\n\t\t\tif(this.checked)\r\n\t\t\t{\r\n\t\t\t\toutput[i] = {};\r\n\t\t\t\toutput[i][\"table\"]=this.value;\r\n\t\t\t\toutput[i][\"group\"]=$(this).attr(\"groupname\");\r\n\t\t\t\toutput[i][\"db_type\"]=$(this).attr(\"dbname\");\r\n\t\t\t\ti++;\r\n\t\t\t}\r\n\t\t}\r\n\t\t);\r\n\t\toutput=JSON.stringify(output);\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"admin_table\",\r\n\t\t\t\toutput: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg)\r\n\t\t\t{\r\n\t\t\t\tif ( msg == \"OK\" ) \r\n\t\t\t\t{\r\n\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\treturn false;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\t\r\n\t$(\"#ch_all\").click(function(){\r\n\t\tngroup=$(\"select[@id=select_group_list] option:selected\").val();\r\n\t\tif($(this).attr(\"checked\"))\r\n\t\t\t$(\"input[id$=_\"+ngroup+\"_\"+li_selected+\"]\").attr(\"checked\",true);\r\n\t\telse\r\n\t\t\t$(\"input[id$=_\"+ngroup+\"_\"+li_selected+\"]\").attr(\"checked\",false);\r\n\t});\r\n\t\r\n\t$(\"input[id^=adm_tables_]\").click(function(){\r\n\t\tcheck_all_box();\r\n\t});\r\n\t\r\n\t$(\"#radio_db,#radio_project,#radio_custom\").click(function(){\r\n\t\t$(\"#li_db\").removeClass(\"selected\");\r\n\t\t$(\"#li_project\").removeClass(\"selected\");\r\n\t\t$(\"#li_custom\").removeClass(\"selected\");\r\n\t\t$(\"#li_db\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_project\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_custom\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_db\").removeClass(\"ui-tabs-selected\");\r\n\t\t$(\"#li_project\").removeClass(\"ui-tabs-selected\");\r\n\t\t$(\"#li_custom\").removeClass(\"ui-tabs-selected\");\r\n\t\tdocument.getElementById(\"select_group_list\").style.height=\"auto\";\r\n\t\tgr=$(\"select[id=select_group_list] option:selected\").val();\r\n\t\tif(!gr)\r\n\t\t\tgr=0;\r\n\t\tif($(this).attr(\"id\")==\"radio_db\")\r\n\t\t{\r\n\t\t\t$(\"#li_db\").addClass(\"selected\");\r\n\t\t\t$(\"#li_db\").addClass(\"ui-state-active\");\r\n\t\t\t$(\"#li_db\").addClass(\"ui-tabs-selected\");\r\n\t\t\t$(\"span[id^=group_db_\"+gr+\"]\").css(\"display\",\"\");\r\n\t\t\t$(\"span[id^=group_project]\").css(\"display\",\"none\");\r\n\t\t\t$(\"span[id^=group_custom]\").css(\"display\",\"none\");\r\n\t\t\th_select=document.getElementById(\"group_db_\"+gr).offsetHeight;\r\n\t\t\th_group=document.getElementById(\"select_group_list\").offsetHeight;\r\n\t\t\tif(h_group<=h_select)\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_select;\r\n\t\t\telse\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_group;\r\n\t\t\tli_selected=\"db\";\r\n\t\t}\r\n\t\telse if($(this).attr(\"id\")==\"radio_project\")\r\n\t\t{\r\n\t\t\t$(\"#li_project\").addClass(\"selected\");\r\n\t\t\t$(\"#li_project\").addClass(\"ui-state-active\");\r\n\t\t\t$(\"#li_project\").addClass(\"ui-tabs-selected\");\r\n\t\t\t$(\"span[id^=group_db]\").css(\"display\",\"none\");\r\n\t\t\t$(\"span[id^=group_custom]\").css(\"display\",\"none\");\r\n\t\t\t$(\"span[id^=group_project_\"+gr+\"]\").css(\"display\",\"\");\r\n\t\t\th_select=document.getElementById(\"group_project_\"+gr).offsetHeight;\r\n\t\t\th_group=document.getElementById(\"select_group_list\").offsetHeight;\r\n\t\t\tif(h_group<=h_select)\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_select;\r\n\t\t\telse\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_group;\r\n\t\t\tli_selected=\"project\";\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\t$(\"#li_custom\").addClass(\"selected\");\r\n\t\t\t$(\"#li_custom\").addClass(\"ui-state-active\");\r\n\t\t\t$(\"#li_custom\").addClass(\"ui-tabs-selected\");\r\n\t\t\t$(\"span[id^=group_db]\").css(\"display\",\"none\");\r\n\t\t\t$(\"span[id^=group_project]\").css(\"display\",\"none\");\r\n\t\t\t$(\"span[id^=group_custom_\"+gr+\"]\").css(\"display\",\"\");\r\n\t\t\th_select=document.getElementById(\"group_custom_\"+gr).offsetHeight;\r\n\t\t\th_group=document.getElementById(\"select_group_list\").offsetHeight;\r\n\t\t\tif(h_group<=h_select)\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_select;\r\n\t\t\telse\r\n\t\t\t\tdocument.getElementById(\"select_group_list\").style.height=h_group;\r\n\t\t\tli_selected=\"custom\";\r\n\t\t}\r\n\t\t$(\".selected\").css(\"padding-bottom\",\"0px\");\r\n\t\tcheck_all_box();\r\n\t});\r\n\t\r\n\tfunction check_all_box(){\r\n\t\tcheck_all=true;\r\n\t\tngroup=$(\"select[@id=select_group_list] option:selected\").val();\r\n\t\t$(\"input[id$=_\"+ngroup+\"_\"+li_selected+\"]\").each(function(i){\r\n\t\t\tif(!$(this).attr(\"checked\"))\r\n\t\t\t\tcheck_all=false;\r\n\t\t});\r\n\t\t$(\"#ch_all\").attr(\"checked\",check_all);\r\n\t}\r\n\tcheck_all_box();\r\n\t");
				if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("queryname")))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#radio_db\").click();");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#radio_custom\").click();");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tsel_ind = $(\"#select_group_list\").get(0).selectedIndex;\r\n\tif(sel_ind<0)\r\n\t{\r\n\t\t$(\"#select_group_list\").get(0).selectedIndex=0;\r\n\t\tsel_ind=0;\r\n\t}\r\n\th_select=document.getElementById(\"group_db_\"+sel_ind).offsetHeight;\r\n\th_group=document.getElementById(\"select_group_list\").offsetHeight;\r\n\tif(h_group<=h_select)\r\n\t\tdocument.getElementById(\"select_group_list\").style.height=h_select;");
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#li_db\").hide();");
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#li_project\").hide();");
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom)))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#li_custom\").hide();");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n});\r\n</script>", "\r\n");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				if(XSession.Session["webreports"]["settings"]["title"] != "")
				{
					xt.assign(new XVar("report_title"), (XVar)(MVCFunctions.Concat(", ", "Title", ": ", XSession.Session["webreports"]["settings"]["title"])));
				}
				else
				{
					xt.assign(new XVar("report_title"), new XVar(""));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("table_list"), (XVar)(table_list));
				xt.assign(new XVar("group_list"), (XVar)(group_list));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport_admin")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
