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
		public ActionResult webreport2()
		{
			try
			{
				dynamic arr = XVar.Array(), arr_fields = XVar.Array(), arr_join_tables = XVar.Array(), b_includes = null, field = null, fields = null, h_includes = null, i = null, j = null, rLinks = null, ri = null, t = null, templatefile = null;
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
				if(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(XSession.Session["webreports"]["table_relations"]["join_tables"]), new XVar(","))), XVar.Pack(false)))
				{
					arr_join_tables = XVar.Clone(MVCFunctions.array_slice((XVar)(MVCFunctions.explode(new XVar(","), (XVar)(XSession.Session["webreports"]["table_relations"]["join_tables"]))), new XVar(0), new XVar(-1)));
				}
				arr_join_tables.InitAndSetArrayItem(XSession.Session["webreports"]["tables"][0], null);
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
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				fields = new XVar("");
				i = new XVar(0);
				for(;i < MVCFunctions.count(arr_join_tables); i++)
				{
					t = XVar.Clone(arr_join_tables[i]);
					arr_fields = XVar.Clone(XVar.Array());
					arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t)));
					j = new XVar(0);
					for(;j < MVCFunctions.count(arr_fields); j++)
					{
						field = XVar.Clone(arr_fields[j]);
						if(25 < MVCFunctions.strlen((XVar)(field)))
						{
							field = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(field), new XVar(25)), "..."));
						}
						fields = MVCFunctions.Concat(fields, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.Concat(t, ".", field))), "\">", t, ".", field, "</option>");
					}
				}
				xt.assign(new XVar("fields"), (XVar)(fields));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200;\r\nvar closetimer\t= 0;\r\nvar relation_stack = 0;\r\n\r\n$(document).ready(function(){\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.where_condition = [];\r\n\t\tvar idx=0;\r\n\t\t$(\".condition-row\").each(function(){\r\n\t\t\tif ($(this).find(\"td.field_value select\").val() != \"-1\" && $(this).find(\"td.filter_value input\").val() != \"\" && $(this).find(\"td.field_value select\").val() != undefined && $(this).find(\"td.filter_value input\").val() != undefined) \r\n\t\t\t{\r\n\t\t\t\toutput.where_condition[idx] = {};\r\n\t\t\t\t$(this).find(\"input:text,select\").each(function(){\r\n\t\t\t\t\toutput.where_condition[idx][$(this).attr(\"id\")] = $(this).val();\r\n\t\t\t\t});\r\n\t\t\t\tidx++;\r\n\t\t\t}\r\n\t\t});\r\n\r\n\t\treturn JSON.stringify(output);\r\n\t}\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"where_condition\",\r\n\t\t\t\tweb: \"webreports\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\t\r\n\tfor (var i=1; i < 10; i++) {\r\n\t\tvar tr_elem = $(\".condition-row\").eq(0).clone();\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){this.value=\"\";});\r\n\t\t$(tr_elem).attr(\"id\",\"cond_row_\"+i);\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){\r\n\t\t\tthis.disabled = true;\r\n\t\t});\r\n\t\t$(\"#table_wh\").append(tr_elem);\r\n\t\t$(tr_elem).hide();\r\n\t}\r\n\r\n\t$(\".field_value select\").change(function(){\r\n\t\tif ($(this).val() == \"-1\") \r\n\t\t{\r\n\t\t\t$(this).parents(\"tr:first\").find(\"input\").each(function(){\r\n\t\t\t\t$(this).val(\"\");\r\n\t\t\t});\r\n\t\t\t$(this).parents(\"tr:first\").find(\"select\").each(function()\r\n\t\t\t{\r\n\t\t\t\tvar oldVal=$(this).val();\r\n\t\t\t\t$(this).val(\"-1\");\r\n\t\t\t\tif(oldVal && oldVal!=\"-1\")\r\n\t\t\t\t\t$(this).trigger(\"change\");\r\n\t\t\t});\r\n\t\t\t$(this).parents(\"tr:first\").hide();\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tenableRow($(this).parents(\"tr:first\").get(0),true);\r\n\t\t\tshowNewRow();\r\n\t\t}\r\n\t});\t\r\n\t\r\n/*\r\n\t$(\".filter_value\").keyup(function(){\r\n\t\tif ($(\"input\",this).val() == \"\") {\r\n\t\t\t$(this).parent(\"tr\").next().find(\"input, select\").each(function(){\r\n\t\t\t\tthis.disabled = true;\r\n\t\t\t});\r\n\t\t\t$(this).parent(\"tr\").next().hide();\t\t\t\r\n\t\t} else {\r\n\t\t\t$(this).parent(\"tr\").next().find(\"input, select\").each(function(){\r\n\t\t\t\tthis.disabled = false;\r\n\t\t\t});\r\n\t\t\t$(this).parent(\"tr\").next().show();\t\t\t\r\n\t\t}\r\n\t});\t\r\n*/\t\r\n\t$(\"#row2\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == $(this).attr(\"id\").replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n", "\r\n");
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\r\n\t\tvar flag = true;\r\n/*\r\n\t\t$(\".filter_value input:enabled\").each(function(){\r\n\t\t\tif ($(this).val() == \"\" && $(this).parents(\"tr\").find(\".field_value select\").val() != \"-1\") {\r\n\t\t\t\tflag = false;\r\n\t\t\t}\r\n\t\t});\r\n\t\tif (!flag) {\r\n\t\t\t$(\"#alert\").html(\"<p>Complete Filter field for selected column</p>\").dialog(\"open\");\r\n\t\t\treturn;\r\n\t\t}\r\n*/\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( $(this).attr(\"id\") == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport3")), "\";\r\n\t\tif( $(this).attr(\"id\") == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport1")), "\";\r\n\t\tif( $(this).attr(\"id\") == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( $(this).attr(\"id\").substr(0,3)==\"row\" && $(this).attr(\"id\") != \"row2\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( $(this).attr(\"id\") == \"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( $(this).attr(\"id\") == \"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( $(this).attr(\"id\") == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\t\t\t\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tthisid=$(this).attr(\"id\");\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( $(this).attr(\"id\") == \"savebtn\" || $(this).attr(\"id\") == \"previewbtn\" ) {\r\n\t\t\tid=$(this).attr(\"id\");\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"where_condition\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif(id==\"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\t\r\n\r\n\t\tif($(this).attr(\"id\") !=\"row2\" && $(this).attr(\"id\") !=\"savebtn\" && $(this).attr(\"id\") !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"where_condition\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n\r\nfunction showNewRow()\r\n{\r\n\tvar lastDisplayed=undefined;\r\n\tvar existsEmpty=false;\r\n\t$(\"tr.condition-row\").each(function() {\r\n\t\tif($(\"select[name=field_opt]\",this).val()!=\"-1\")\r\n\t\t\treturn;\r\n\t\tif($(this).css(\"display\")!=\"none\")\r\n\t\t\texistsEmpty=true;\r\n\t});\r\n\tif(existsEmpty)\r\n\t\treturn;\r\n\tvar firstHidden=$(\"select[name=field_opt][value=-1]:first\").parents(\"tr\").get(0);\r\n\t\r\n//\tappend it to the end\t\r\n\t$(\"#table_wh\").append(firstHidden);\r\n\tenableRow(firstHidden,true);\r\n}\r\n\r\nfunction enableRow(tr,enable)\r\n{\r\n\t$(tr).show();\r\n\t$(\"input, select\",tr).each(function(){\r\n\t\tif(this.name==\"field_opt\")\r\n\t\t\tthis.disabled=false;\r\n\t\telse if ((this.name == \"group_by_value\" || this.name == \"having_value\")) \r\n\t\t\tthis.disabled=!enable || !$(\"#group_by_toggle\")[0].checked;\r\n\t\telse\r\n\t\t\tthis.disabled = !enable;\r\n\t});\r\n\tif($(\"td.sort_dir select\",tr).val() && $(\"td.sort_dir select\",tr).val()!=\"-1\")\r\n\t\t$(\"td.sort_order select\",tr).show();\r\n\telse\r\n\t\t$(\"td.sort_order select\",tr).hide();\r\n\t\r\n}\r\n\r\n</script>", "\r\n");
				arr = XVar.Clone(XSession.Session["webreports"]["where_condition"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					b_includes = MVCFunctions.Concat(b_includes, "<script type='text/javascript'>\r\n\t\t$(document).ready(function(){", "\r\n");
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr); i++)
					{
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\ttr_elem = $('.condition-row').eq('", i, "');\r\n\t\t$(tr_elem).show();\r\n\t\t$(tr_elem).find('input, select').each(function(){\r\n\t\t\tthis.disabled = false;\r\n\t\t});\r\n\t\t$(tr_elem).find('select#field_opt').val('", CommonFunctions.jsreplace((XVar)(arr[i]["field_opt"])), "');\r\n\t\t$(tr_elem).find('input#filter_value').val('", CommonFunctions.jsreplace((XVar)(arr[i]["filter_value"])), "');\r\n\t\t$(tr_elem).find('input#first_or_value').val('", CommonFunctions.jsreplace((XVar)(arr[i]["first_or_value"])), "');\r\n\t\t$(tr_elem).find('input#second_or_value').val('", CommonFunctions.jsreplace((XVar)(arr[i]["second_or_value"])), "');\r\n\t\t$(tr_elem).find('input#third_or_value').val('", CommonFunctions.jsreplace((XVar)(arr[i]["third_or_value"])), "');\r\n\t\t", "\r\n");
					}
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\ttr_elem = $(\".condition-row\").eq(", MVCFunctions.count(arr), ");\r\n\t\t$(tr_elem).show();\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){\r\n\t\t\tthis.disabled = false;\r\n\t\t});\r\n\t});\r\n\t</script>", "\r\n");
				}
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport2")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
