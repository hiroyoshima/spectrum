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
		public ActionResult webreport1()
		{
			try
			{
				dynamic arr = XVar.Array(), arr_fields = XVar.Array(), arr_parts = XVar.Array(), arr_rel = XVar.Array(), arr_relations = XVar.Array(), arr_tables = XVar.Array(), b_includes = null, fields_table_selected = null, h_includes = null, i = null, j = null, rLinks = null, ri = null, strLeftWrapper = null, strRightWrapper = null, t = null, table_selected = null, tables = null, templatefile = null;
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
				arr_tables = XVar.Clone(CommonFunctions.DBGetTablesListByGroup(new XVar("db")));
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
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				table_selected = XVar.Clone(XSession.Session["webreports"]["tables"][0]);
				xt.assign(new XVar("table_selected"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(table_selected))));
				fields_table_selected = new XVar("");
				arr_fields = XVar.Clone(CommonFunctions.WRGetFieldsList((XVar)(table_selected)));
				foreach (KeyValuePair<XVar, dynamic> fld_name in arr_fields.GetEnumerator())
				{
					fields_table_selected = MVCFunctions.Concat(fields_table_selected, fld_name.Value, ", ");
				}
				fields_table_selected = XVar.Clone(MVCFunctions.substr((XVar)(fields_table_selected), new XVar(0), (XVar)(MVCFunctions.strlen((XVar)(fields_table_selected)) - 2)));
				xt.assign(new XVar("fields_table_selected"), (XVar)(fields_table_selected));
				arr_rel = XVar.Clone(XSession.Session["webreports"]["table_relations"]);
				if(XVar.Pack(!(XVar)(arr_rel.IsEmpty())))
				{
					arr_relations = XVar.Clone(MVCFunctions.array_slice((XVar)(MVCFunctions.explode(new XVar("@END@"), (XVar)(arr_rel["relations"]))), new XVar(0), new XVar(-1)));
				}
				strLeftWrapper = new XVar("[");
				strRightWrapper = new XVar("]");
				tables = new XVar("");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type='text/javascript'>\r\nvar left_wrapper = '", strLeftWrapper, "';\r\nvar right_wrapper = '", strRightWrapper, "';\r\nvar arr_tables_fields = new Array();", "\n");
				i = new XVar(0);
				for(;i < MVCFunctions.count(arr_tables); i++)
				{
					t = XVar.Clone(arr_tables[i]);
					if(t != table_selected)
					{
						dynamic flag = null;
						flag = new XVar(0);
						if(XVar.Pack(!(XVar)(arr_rel.IsEmpty())))
						{
							foreach (KeyValuePair<XVar, dynamic> rel in arr_relations.GetEnumerator())
							{
								arr_parts = XVar.Clone(MVCFunctions.explode(new XVar("@SEP@"), (XVar)(rel.Value)));
								if(arr_parts[1] == t)
								{
									flag = new XVar(1);
								}
							}
						}
						if(flag == XVar.Pack(0))
						{
							tables = MVCFunctions.Concat(tables, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(t)), "\">", t, "</option>");
						}
					}
					arr_fields = XVar.Clone(XVar.Array());
					arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t)));
					b_includes = MVCFunctions.Concat(b_includes, "arr_tables_fields['", CommonFunctions.jsreplace((XVar)(t)), "'] = new Array();", "\n");
					j = new XVar(0);
					for(;j < MVCFunctions.count(arr_fields); j++)
					{
						b_includes = MVCFunctions.Concat(b_includes, "arr_tables_fields['", CommonFunctions.jsreplace((XVar)(t)), "'][", j, "] = '", CommonFunctions.jsreplace((XVar)(arr_fields[j])), "';", "\n");
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "</script>");
				xt.assign(new XVar("tables"), (XVar)(tables));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0,\r\n\trelation_stack = [],\r\n\ttable_stack = [],\r\n\trel = [];\r\n\r\n$(document).ready(function(){\r\n\t\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar s = \"\", t = \"\", r=[];\r\n\t\t\r\n\t\tfor (i in relation_stack) {\r\n\t\t\tif (relation_stack[i] != undefined) {\r\n\t\t\t\ts += i + \"@SEP@\" + relation_stack[i] + \"@END@\";\r\n\t\t\t}\r\n\t\t}\r\n\t\tfor (i in table_stack) {\r\n\t\t\tif (table_stack[i] != undefined) {\r\n\t\t\t\tt += i + \",\";\r\n\t\t\t}\r\n\t\t}\t\t\r\n\t\t\r\n\t\t$(\"#rel_list\").children().each(function(){\r\n\t\t\tr[r.length]=this.rel;\r\n\t\t});\r\n\t\t\r\n\t\tvar output = {\r\n\t\t\ttable_relations : {\r\n\t\t\t\tleft_table  : $(\"#left_tables\").val(),\r\n\t\t\t\tright_table : $(\"#right_tables\").val(),\r\n\t\t\t\tleft_field  : $(\"#left_fields_1\").val(),\r\n\t\t\t\tright_field : $(\"#right_fields_1\").val(),\r\n\t\t\t\tjoin_type   : $(\"#join_select\").val(),\r\n\t\t\t\trelations   : s,\r\n\t\t\t\tjoin_tables : t,\r\n\t\t\t\trelat: r\r\n\t\t\t}\r\n\t\t};\r\n\t\r\n\t\treturn JSON.stringify(output);\r\n\t}\t\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"table_relations\",\r\n\t\t\t\tweb: \"webreports\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\t\t\r\n\t$(\"#addrel_btn\").click(function(){\r\n\t\tvar rel_txt,\r\n\t\t\ttbl_left = $(\"#left_tables\").val(),\r\n\t\t\ttbl_right = $(\"#right_tables\").val(),\r\n\t\t\trightFieldSelector = \"select[id^=right_fields_]\",\r\n\t\t\tleftFieldSelector = \"select[id^=left_fields_]\";\r\n\t\t\r\n\t\tif ( tbl_left == -1 ) {\r\n\t\t\t$(\"#alert\").html(\"<p>", "Select left table", "</p>\").dialog(\"open\");\r\n\t\t\treturn;\r\n\t\t}\r\n\t\tif ( tbl_right == -1 ) {\r\n\t\t\t$(\"#alert\").html(\"<p>", "Select right table", "</p>\").dialog(\"open\");\r\n\t\t\treturn;\r\n\t\t}\r\n\t\t// add check if field is selected\r\n\t\t\r\n\t\trel_txt = $(\"#join_select\").val() + left_wrapper + tbl_right + right_wrapper + \" ON \";\r\n\t\t$(\".myselector\").each(function(){\r\n\t\t\tif ($(leftFieldSelector, this).val() != null && $(leftFieldSelector, this).val() != \"-1\"\r\n\t\t\t\t&& $(rightFieldSelector,this).val() != null && $(rightFieldSelector,this).val() != \"-1\")\r\n\t\t\t{\r\n\t\t\t\trel_txt += left_wrapper + tbl_left + right_wrapper + \".\";\r\n\t\t\t\trel_txt += left_wrapper + $(leftFieldSelector,this).val() + right_wrapper + \" = \";\r\n\t\t\t\trel_txt += left_wrapper + tbl_right + right_wrapper + \".\";\r\n\t\t\t\trel_txt += left_wrapper + $(rightFieldSelector,this).val() + right_wrapper;\r\n\t\t\t\trel_txt += \" AND \"\r\n\t\t\t}\r\n\t\t});\r\n\t\trel_txt = rel_txt.substr(0,rel_txt.length-5);\r\n\t\tif (relation_stack[rel_txt] != undefined) {\r\n\t\t\t$(\"#alert\").html(\"<p>", "The relation with selected parameters already exists", "</p>\").dialog(\"open\");\r\n\t\t\treturn;\r\n\t\t}\t\t\r\n\t\t\r\n\t\trel={\"left_table\":tbl_left,\r\n\t\t\t\t \"right_table\":tbl_right,\r\n\t\t\t\t \"left_fields\":[],\r\n\t\t\t\t \"right_fields\":[],\r\n\t\t\t\t \"rel_type\":$(\"#join_select\").val()};\r\n\t\t\r\n\t\t$(\".myselector\").each(function(){\r\n\t\t\tif ($(leftFieldSelector,this).val() != null && $(leftFieldSelector,this).val() != \"-1\"\r\n\t\t\t\t\t&& $(rightFieldSelector,this).val() != null && $(rightFieldSelector,this).val() != \"-1\")\r\n\t\t\t{\r\n\t\t\t\trel.left_fields[rel.left_fields.length] = $(leftFieldSelector,this).val();\r\n\t\t\t\trel.right_fields[rel.right_fields.length] = $(rightFieldSelector,this).val();\r\n\t\t\t}\r\n\t\t});\r\n\t\t\r\n\t\trelation_stack[rel_txt] = tbl_right;\r\n\t\t\r\n\r\n\t\toption = new Option(rel_txt,tbl_right);\r\n\t\toption.rel=rel;\r\n\t\tvar objSel=document.getElementById(\"rel_list\");\r\n\t\tobjSel.options[objSel.length]=option;\r\n\r\n\r\n\t\tif (table_stack[tbl_right] == undefined) {\r\n\t\t\ttable_stack[tbl_right] = 1;\r\n\t\t\t$(\"#left_tables\").append(\"<option value=\\\"\"+tbl_right+\"\\\">\"+tbl_right+\"</option>\");\t\t\t\r\n\t\t\t$(\"#right_tables option:selected\").remove();\r\n\t\t\t$(rightFieldSelector).empty();\r\n\t\t\t//$(leftFieldSelector).empty();\r\n\t\t\tvar counter = 0;\r\n\t\t\t$(leftFieldSelector).each(function(){\r\n\t\t\t\tif(counter++)\r\n\t\t\t\t\t$(this).parentsUntil(\"table\", \"tr\").remove();\r\n\t\t\t});\r\n\t\t} else {\r\n\t\t\ttable_stack[tbl_right] = table_stack[tbl_right] + 1;\r\n\t\t}\r\n\t});\r\n\t\r\n\t$(\"#remrel_btn\").click(function(){\r\n\t\tvar rel, val, db, \r\n\t\ttbl_left = $(\"#left_tables\").val(),\r\n\t\ttbl_right = $(\"#right_tables\").val();\r\n\t\tif ($(\"#rel_list\").children(\":selected\").length > 0) {\r\n\t\t\trel = $(\"#rel_list\").children(\":selected\");\r\n\t\t\tval = $(rel).text();\r\n\t\t\tdb = $(rel).val();\r\n\t\t\tif(db!=\"\")\r\n\t\t\t{\r\n\t\t\t\t$(\"#right_tables\").append(\"<option value=\\\"\"+db+\"\\\">\"+db+\"</option>\");\t\t\t\r\n\t\t\t\t$(\"#left_tables\").find(\"option:contains(\"+db+\")\").remove();\r\n\r\n\t\t\t}\r\n\t\t\tif (table_stack[relation_stack[val]] == 1) {\r\n\t\t\t\ttable_stack[relation_stack[val]] = undefined;\r\n\t\t\t} else {\r\n\t\t\t\ttable_stack[relation_stack[val]] = table_stack[relation_stack[val]] - 1;\r\n\t\t\t}\r\n\t\t\trelation_stack[val] = undefined;\r\n\t\t\t$(rel).remove();\r\n\t\t} else {\r\n\t\t\t$(\"#alert\").html(\"<p>", "Select relation you want to remove", "</p>\").dialog(\"open\");\r\n\t\t\treturn;\r\n\t\t}\r\n\t});\r\n\t\r\n\t$(\".table_fields\").change(function(){\r\n\t\tvar s = \"\",\r\n\t\t\tt = $(this).val(),\r\n\t\t\tid = this.id.replace(\"_tables\",\"\");\r\n\t\t\t\r\n\t\tif (t == \"-1\") {\r\n\t\t\t$(\"#\"+id+\"_fields_1\").html(\"\");\r\n\t\t\treturn;\r\n\t\t}\r\n\t\tvar theSel=document.getElementById(id+\"_fields_1\");\r\n\t\t$(\"#\"+id+\"_fields_1\").empty();\r\n\t\tfor (var i=0; i < arr_tables_fields[t].length; i++) {\r\n\t\t\ttheSel.options[theSel.length] = new Option(arr_tables_fields[t][i], arr_tables_fields[t][i]);\r\n\t\t}\r\n\t\tif(id==\"right\")\r\n\t\t{\r\n\t\t\tth=$(\"#\"+id+\"_fields_1\")[0];\r\n\t\t\tlive_change(th);\r\n\t\t}\r\n\t\t$(\"#\"+id+\"_fields_1\").get(0).disabled = false;\r\n\t});\r\n\t\r\n\t$(\".fld_names\").change(function(){\r\n\t\tlive_change(this);\r\n\t});\t\r\n\t\r\n\t$(\"#row1\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(MVCFunctions.count(CommonFunctions.GetUserGroups()) < 2)  || (XVar)((XVar)(XSession.Session["webreports"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webreports"]["settings"]["status"] == "private")))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id=row9]\").hide();", "\r\n");
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport2")), "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport0")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row1\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( this.id == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\t\t\t\r\n\t\r\n\t\tvar output = collect_input_data();\r\n\t\tthisid=this.id;\r\n\t\t\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\" ) {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"table_relations\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif( id == \"savebtn\" )\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\r\n\t\tif(this.id != \"row1\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"table_relations\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				arr = XVar.Clone(XSession.Session["webreports"]["table_relations"]);
				b_includes = MVCFunctions.Concat(b_includes, "<script type='text/javascript'>\r\n\t$(document).ready(function(){");
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					dynamic c = null;
					arr_relations = XVar.Clone(MVCFunctions.array_slice((XVar)(MVCFunctions.explode(new XVar("@END@"), (XVar)(arr["relations"]))), new XVar(0), new XVar(-1)));
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$('#left_tables').val('", CommonFunctions.jsreplace((XVar)(arr["left_table"])), "');\r\n\t\t\tif ($('#left_tables').val() != '-1') \r\n\t\t\t{\r\n\t\t\t\t$('#left_tables').change();\t\t\t\t\r\n\t\t\t}\r\n\t\t\t$('#right_tables').val('", CommonFunctions.jsreplace((XVar)(arr["right_table"])), "');\r\n\t\t\tif ($('#right_tables').val() != '-1') \r\n\t\t\t{\r\n\t\t\t\t$('#right_tables').change();\t\t\t\t\r\n\t\t\t}\t\t\t\r\n\t\t\t$('#left_fields_1').val('", CommonFunctions.jsreplace((XVar)(arr["left_field"])), "');\r\n\t\t\t$('#right_fields_1').val('", CommonFunctions.jsreplace((XVar)(arr["right_field"])), "');\r\n\t\t\t$('#right_fields_1').change();\r\n\t\t\t$('#join_select').val('", CommonFunctions.jsreplace((XVar)(arr["join_type"])), "');", "\r\n");
					c = new XVar(0);
					if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(arr["relat"])))))
					{
						arr_relations = XVar.Clone(XVar.Array());
					}
					foreach (KeyValuePair<XVar, dynamic> rel in arr_relations.GetEnumerator())
					{
						arr_parts = XVar.Clone(MVCFunctions.explode(new XVar("@SEP@"), (XVar)(rel.Value)));
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\trelation_stack['", CommonFunctions.jsreplace((XVar)(arr_parts[0])), "'] = '", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "';");
						foreach (KeyValuePair<XVar, dynamic> value in arr["relat"].GetEnumerator())
						{
							if(value.Key == c)
							{
								b_includes = MVCFunctions.Concat(b_includes, "var rel={'left_table':'", CommonFunctions.jsreplace((XVar)(value.Value["left_table"])), "',\r\n\t\t\t\t\t\t\t\t\t\t'right_table':'", CommonFunctions.jsreplace((XVar)(value.Value["right_table"])), "',\r\n\t\t\t\t\t\t\t\t\t\t'left_fields':[],\r\n\t\t\t\t\t\t\t\t\t\t'right_fields':[],\r\n\t\t\t\t\t\t\t\t\t\t'rel_type':'", value.Value["rel_type"], "'};", "\r\n");
								foreach (KeyValuePair<XVar, dynamic> val in value.Value["left_fields"].GetEnumerator())
								{
									b_includes = MVCFunctions.Concat(b_includes, "rel.left_fields[", val.Key, "]='", CommonFunctions.jsreplace((XVar)(val.Value)), "';");
								}
								foreach (KeyValuePair<XVar, dynamic> val in value.Value["right_fields"].GetEnumerator())
								{
									b_includes = MVCFunctions.Concat(b_includes, "rel.right_fields[", val.Key, "]='", CommonFunctions.jsreplace((XVar)(val.Value)), "';");
								}
							}
						}
						b_includes = MVCFunctions.Concat(b_includes, "option = new Option('", CommonFunctions.jsreplace((XVar)(arr_parts[0])), "','", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "');\r\n\t\t\t\toption.rel=rel;\r\n\t\t\t\tvar objSel=document.getElementById('rel_list');\r\n\t\t\t\tobjSel.options[objSel.length]=option;\r\n\t\t\t\t\r\n\t\t\t\tif (table_stack['", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "'] == undefined) \r\n\t\t\t\t{\r\n\t\t\t\t\ttable_stack['", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "'] = 1;\r\n\t\t\t\t\t$('#left_tables').append(\"<option value='", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "'>", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "</option>\");\r\n\t\t\t\t} \r\n\t\t\t\telse \r\n\t\t\t\t{\r\n\t\t\t\t\ttable_stack['", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "'] = table_stack['", CommonFunctions.jsreplace((XVar)(arr_parts[1])), "'] + 1;\r\n\t\t\t\t}\t\t\r\n\t\t\t\t", "\r\n");
						c++;
					}
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#left_tables\").val($(\"#left_tables\")[0].options[1].value);\r\n\t\t$(\"#left_tables\").change();");
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n\r\nfunction live_change(th)\r\n{\r\n\t\tvar id = th.id.substr(th.id.length-1),\r\n\t\t\ttr  = $(th).parent().parent(),\r\n\t\t\tnew_id = 0,\r\n\t\t\tnew_tr = \"\";\r\n\r\n\t\tif ( $(\"td > select\",tr).eq(0).val() != null && $(\"td > select\",tr).eq(0).val() != \"-1\"\r\n\t\t\t&& $(\"td > select\",tr).eq(1).val() != null && $(\"td > select\",tr).eq(1).val() != \"-1\") {\r\n\t\t\tnew_id = parseInt(id)+1;\r\n\t\t\tif ($(\"#left_fields_\"+new_id).length > 0) {\r\n\t\t\t\treturn;\r\n\t\t\t}\r\n\t\t\tnew_tr += \"<tr class='myselector'><td></td>\";\r\n\t\t\tnew_tr += \"<td><select class=\\\"fld_names\\\" id=\\\"left_fields_\"+new_id+\"\\\" name=\\\"left_fields_\"+new_id+\"\\\" style=\\\"width:150px\\\" onchange=\\\"live_change(this);\\\">\";\r\n\t\t\tif (new_id == 2) {\r\n\t\t\t\tnew_tr += \"<option value=\\\"-1\\\"></option>\";\r\n\t\t\t}\r\n\t\t\tnew_tr += $(\"td > select\",tr).eq(0).html();\r\n\t\t\tnew_tr += \"</select></td>\";\r\n\t\t\tnew_tr += \"<td></td>\";\r\n\t\t\tnew_tr += \"<td><select class=\\\"fld_names\\\" id=\\\"right_fields_\"+new_id+\"\\\" name=\\\"right_fields_\"+new_id+\"\\\" style=\\\"width:150px\\\" onchange=\\\"live_change(this);\\\">\";\r\n\t\t\tif (new_id == 2) {\r\n\t\t\t\tnew_tr += \"<option value=\\\"-1\\\"></option>\";\r\n\t\t\t}\r\n\t\t\tnew_tr += $(\"td > select\",tr).eq(1).html();\r\n\t\t\tnew_tr += \"</select></td>\";\r\n\t\t\tnew_tr += \"</tr>\";\r\n\t\t\t$(new_tr).insertAfter(tr);\r\n\t\t\t$(\"#left_fields_\"+new_id).get(0).selectedIndex=0;\r\n\t\t\t$(\"#right_fields_\"+new_id).get(0).selectedIndex=0;\r\n\t\t}\r\n}\r\n\r\n</script>", "\r\n");
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport1")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
