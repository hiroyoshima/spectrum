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
		public ActionResult webchart0()
		{
			try
			{
				dynamic arr_tables = XVar.Array(), arr_tables_custom = XVar.Array(), arr_tables_db = XVar.Array(), arr_tables_project = XVar.Array(), b_includes = null, h_includes = null, isCustom = null, rLinks = null, ri = null, root = XVar.Array(), selected = null, tables = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				CommonFunctions.Reload_Chart((XVar)(MVCFunctions.postvalue(new XVar("cname"))));
				xt = XVar.UnPackXTempl(new XTempl());
				arr_tables_db = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("db")));
				arr_tables_project = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("project")));
				arr_tables_custom = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("custom")));
				root = XSession.Session["webcharts"];
				XSession.Session[MVCFunctions.Concat("webchart", MVCFunctions.GoodFieldName((XVar)(root["settings"]["name"])), "_search")] = "";
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">", "\r\n");
				if((XVar)(CommonFunctions.is_wr_db())  && (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart1")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t", "\r\n");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart3")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0;\r\n\r\n$(document).ready(function(){");
				if(XVar.Pack(GlobalVars.wr_is_standalone))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#radio_project\").hide();");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "$(\"#radio_db,#radio_project,#radio_custom\").click(function(){\r\n\t\t$(\"#tables\").empty();\r\n\t\t$(\"#li_db\").removeClass(\"selected\").removeClass(\"ui-state-selected\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_project\").removeClass(\"selected\").removeClass(\"ui-state-selected\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_custom\").removeClass(\"selected\").removeClass(\"ui-state-selected\").removeClass(\"ui-state-active\");\r\n\t\t$(\"#li_db\").css(\"background\",\"\");\r\n\t\t$(\"#li_project\").css(\"background\",\"\");\r\n\t\t$(\"#li_custom\").css(\"background\",\"\");\r\n\t\tif($(this).attr(\"id\")==\"radio_db\")\r\n\t\t{\r\n\t\t\t$(\"#add_new_query\").hide();\r\n\t\t\t$(\"#li_db\").addClass(\"selected\").addClass(\"ui-state-selected\").addClass(\"ui-state-active\");;\r\n\t\t\tli_selected=\"db\";\r\n\t\t\t$(\"#tl\").html(\"", "Select table which you will use to create the chart:", "\");\r\n\t\t\tNEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart1")), "\";\r\n\t\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(\"td[id=row1], td[id=row2]\").show();", "\r\n");
				foreach (KeyValuePair<XVar, dynamic> _tbl in arr_tables_db.GetEnumerator())
				{
					selected = new XVar("");
					if(XVar.Pack(!(XVar)(root["tables"].IsEmpty())))
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(_tbl.Value), (XVar)(root["tables"]))))
						{
							selected = new XVar("selected");
						}
					}
					b_includes = MVCFunctions.Concat(b_includes, "$('<option ", selected, "></option>').attr('value', '", CommonFunctions.jsreplace((XVar)(_tbl.Value)), "').html('", CommonFunctions.jsreplace((XVar)(_tbl.Value)), "').appendTo($('#tables'));", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t}\r\n\t\telse if($(this).attr(\"id\")==\"radio_project\")\r\n\t\t{\r\n\t\t\t$(\"#add_new_query\").hide();\r\n\t\t\t$(\"#li_project\").addClass(\"selected\").addClass(\"ui-state-selected\").addClass(\"ui-state-active\");;\r\n\t\t\tli_selected=\"project\";\r\n\t\t\t$(\"#tl\").html(\"", "Select table which you will use to create the chart:", "\");\r\n\t\t\tNEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart3")), "\";\r\n\t\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(\"td[id=row1], td[id=row2]\").hide();", "\r\n");
				foreach (KeyValuePair<XVar, dynamic> _tbl in arr_tables_project.GetEnumerator())
				{
					selected = new XVar("");
					if(XVar.Pack(!(XVar)(root["tables"].IsEmpty())))
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(_tbl.Value), (XVar)(root["tables"]))))
						{
							selected = new XVar("selected");
						}
					}
					b_includes = MVCFunctions.Concat(b_includes, "$('<option ", selected, "></option>').attr('value', '", CommonFunctions.jsreplace((XVar)(_tbl.Value)), "').html('", CommonFunctions.jsreplace((XVar)(CommonFunctions.getCaptionTable((XVar)(_tbl.Value)))), (XVar.Pack(CommonFunctions.getCaptionTable((XVar)(_tbl.Value)) != _tbl.Value) ? XVar.Pack(MVCFunctions.Concat("&nbsp;(", CommonFunctions.jsreplace((XVar)(_tbl.Value)), ")")) : XVar.Pack("")), "').appendTo($('#tables'));", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t}\r\n\t\telse\r\n\t\t{");
				if((XVar)(CommonFunctions.isWRAdmin())  && (XVar)((XVar)(XSession.Session["webcharts"]["tmp_active"] == "x")  || (XVar)(root["settings"]["title"] == "")))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#add_new_query\").show();");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#add_new_query\").hide();");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\tli_selected=\"custom\";\r\n\t\t\t$(\"#li_custom\").addClass(\"selected\").addClass(\"ui-state-selected\").addClass(\"ui-state-active\");;\r\n\t\t\t$(\"#tl\").html(\"", "Select SQL query which you will use to create the chart:", "\");\r\n\t\t\tNEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webchart3")), "\";\r\n\t\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(\"td[id=row1], td[id=row2]\").hide();", "\r\n");
				foreach (KeyValuePair<XVar, dynamic> _tbl in arr_tables_custom.GetEnumerator())
				{
					selected = new XVar("");
					if(XVar.Pack(!(XVar)(root["tables"].IsEmpty())))
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(_tbl.Value["sqlname"]), (XVar)(root["tables"]))))
						{
							selected = new XVar("selected");
						}
					}
					if(MVCFunctions.postvalue(new XVar("sqlname")) == _tbl.Value["sqlname"])
					{
						selected = new XVar("selected");
					}
					b_includes = MVCFunctions.Concat(b_includes, "$('<option ", selected, "></option>').attr('value', '", CommonFunctions.jsreplace((XVar)(_tbl.Value["sqlname"])), "').html('", CommonFunctions.jsreplace((XVar)(CommonFunctions.getCaptionTable((XVar)(_tbl.Value["sqlname"])))), "').appendTo($('#tables'));", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t}\r\n\t$(\"li\").css(\"list-style-type\",\"none\");\t\r\n\t$(\".selected\").css(\"padding-bottom\",\"0px\");\r\n\tif($(\"#tables\").get(0).selectedIndex==-1)\r\n\t\t$(\"#tables\").get(0).selectedIndex=0;\r\n\tempty_table_list();\r\n\t});\r\n\t\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\r\n\tli_selected=\"db\";\r\n\t$(\"#tl\").attr(\"html\",\"Select table which you will use to create the chart:\");\r\n\t$(function() {\r\n\t\t$(\"#radio_select_table\").tabs();");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("sqlname"))))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t\tli_selected_start=\"custom\";\r\n\t\t\t\t\t$(\"#radio_custom\").click();\r\n\t\t\t\t\tli_selected=\"custom\";\r\n\t\t\t\t\t$(\"#tl\").html(\"", "Select SQL query which you will use to create the report:", "\");\r\n\t\t\t\t\t");
				}
				else
				{
					if((XVar)(CommonFunctions.is_wr_db())  && (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db))))
					{
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t\t\tli_selected_start=\"db\";\r\n\t\t\t\t\t\t$(\"#radio_db\").click();\r\n\t\t\t\t\t\tli_selected=\"db\";\r\n\t\t\t\t\t\t$(\"#tl\").html(\"", "Select table which you will use to create the chart:", "\");\r\n\t\t\t\t\t\t");
					}
					else
					{
						if((XVar)(CommonFunctions.is_wr_project())  && (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))
						{
							b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t\t\tli_selected_start=\"project\";\r\n\t\t\t\t\t\t$(\"#radio_project\").click();\r\n\t\t\t\t\t\tli_selected=\"project\";\r\n\t\t\t\t\t\t$(\"#tl\").html(\"", "Select table which you will use to create the chart:", "\");\r\n\t\t\t\t\t\t");
						}
						else
						{
							b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t\t\tli_selected_start=\"custom\";\r\n\t\t\t\t\t\t$(\"#radio_custom\").click();\r\n\t\t\t\t\t\tli_selected=\"custom\";\r\n\t\t\t\t\t\t$(\"#tl\").html(\"", "Select SQL query which you will use to create the report:", "\");\r\n\t\t\t\t\t\t");
						}
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n\t\r\n\tfunction empty_table_list()\r\n\t{\r\n\t\tif($(\"#tables\").val()==null)\r\n\t\t{\r\n\t\t\t$(\"#nextbtn,#sqlbtn,#jumpto\").css(\"display\",\"none\");\r\n\t\t\t$(\"#nextbtn,#sqlbtn,#jumpto\").parent(\"span\").css(\"display\",\"none\");\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\t$(\"#nextbtn,#sqlbtn,#jumpto\").css(\"display\",\"\");\r\n\t\t\t$(\"#nextbtn,#sqlbtn,#jumpto\").parent(\"span\").css(\"display\",\"\");\r\n\r\n\t\t}\r\n\t}\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.table_type=li_selected;\r\n\t\toutput.tables = [];\r\n\t\t$(\":selected\").each(function(i){\r\n\t\t\toutput.tables[i] = $(this).val();\r\n\t\t});\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"tables\",\r\n\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\t\r\n\t$(\"#row0\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n\t\r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())) < 2)  || (XVar)(root["settings"]["status"] != "public"))
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
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webchart", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"a#a_addsql\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 850,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\r\n\t$(\"#addsql\").click(function(){\r\n\t\t$(\"#a_addsql\").click();\r\n\t});\r\n\t\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = NEXT_PAGE_URL;\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = PREV_PAGE_URL;\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row0\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\r\n\t\tif (this.id == \"backbtn\" || this.id == \"row8\" || this.id == \"row9\") {\r\n\t\t\twindow.location = URL;\r\n\t\t\treturn;\r\n\t\t}\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tthisid=this.id;\r\n\t\tif(this.id !=\"row0\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"tables\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n\t\r\n\tif ($(\"option:selected\").length == 0) {\r\n\t\t$(\"select\").get(0).selectedIndex = 0;\r\n\t}\r\n\tempty_table_list();");
				tables = new XVar("");
				arr_tables = XVar.Clone(XVar.Array());
				if((XVar)(CommonFunctions.is_wr_db())  && (XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db))))
				{
					arr_tables = XVar.Clone(arr_tables_db);
					isCustom = new XVar(false);
				}
				else
				{
					if((XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project)))  && (XVar)(CommonFunctions.is_wr_project()))
					{
						arr_tables = XVar.Clone(arr_tables_project);
						isCustom = new XVar(false);
					}
					else
					{
						arr_tables = XVar.Clone(arr_tables_custom);
						isCustom = new XVar(true);
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n</script>", "\r\n");
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				foreach (KeyValuePair<XVar, dynamic> tbl_name in arr_tables.GetEnumerator())
				{
					dynamic isStorProc = null;
					if(XVar.Pack(isCustom))
					{
						GlobalVars.tbl = XVar.Clone(tbl_name.Value["sqlname"]);
						isStorProc = XVar.Clone(tbl_name.Value["isStorProc"]);
					}
					else
					{
						GlobalVars.tbl = XVar.Clone(tbl_name.Value);
						isStorProc = new XVar(false);
					}
					selected = new XVar("");
					if(XVar.Pack(!(XVar)(root["tables"].IsEmpty())))
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(GlobalVars.tbl), (XVar)(root["tables"]))))
						{
							selected = new XVar("selected");
						}
					}
					tables = MVCFunctions.Concat(tables, "<option ", selected, " value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(GlobalVars.tbl)), "\">", (XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())) ? XVar.Pack(GlobalVars.tbl) : XVar.Pack(CommonFunctions.getCaptionTable((XVar)(GlobalVars.tbl)))), (XVar.Pack(CommonFunctions.is_wr_project()) ? XVar.Pack((XVar.Pack(CommonFunctions.getCaptionTable((XVar)(GlobalVars.tbl)) != GlobalVars.tbl) ? XVar.Pack(MVCFunctions.Concat("&nbsp;(", GlobalVars.tbl, ")")) : XVar.Pack(""))) : XVar.Pack("")), "</option>", "\r\n");
				}
				if(root["settings"]["title"] != "")
				{
					xt.assign(new XVar("chart_title"), (XVar)(MVCFunctions.Concat(", ", "Title", ": ", root["settings"]["title"])));
				}
				else
				{
					xt.assign(new XVar("chart_title"), new XVar(""));
				}
				xt.assign(new XVar("tables"), (XVar)(tables));
				if((XVar)((XVar)((XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db))))  && (XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project)))))  || (XVar)((XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))  && (XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_project))))))  || (XVar)((XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_custom))))  && (XVar)(!(XVar)(CommonFunctions.pre8count((XVar)(arr_tables_db))))))
				{
					xt.assign(new XVar("radio_style"), new XVar("style='display:none';"));
				}
				if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_tables_db))))
				{
					xt.assign(new XVar("view_radio_db"), new XVar(true));
				}
				if(XVar.Pack(CommonFunctions.pre8count((XVar)(arr_tables_project))))
				{
					xt.assign(new XVar("view_radio_project"), new XVar(true));
				}
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart0")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
