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
		public ActionResult webchart2()
		{
			try
			{
				dynamic arr = XVar.Array(), arr_fields = XVar.Array(), arr_join_tables = XVar.Array(), b_includes = null, disp_field = null, field = null, fields = null, h_includes = null, i = null, j = null, rLinks = null, ri = null, t = null, templatefile = null;
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
				arr_join_tables = XVar.Clone(CommonFunctions.getChartTablesList());
				xt = XVar.UnPackXTempl(new XTempl());
				if(XSession.Session["webcharts"]["settings"]["title"] != "")
				{
					dynamic title = null;
					title = XVar.Clone(XSession.Session["webcharts"]["settings"]["title"]);
					if(25 < MVCFunctions.strlen((XVar)(title)))
					{
						title = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(title), new XVar(0), new XVar(25)), "..."));
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
						stable = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(stable), new XVar(0), new XVar(25)), "..."));
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
						disp_field = XVar.Clone(MVCFunctions.Concat(t, ".", field));
						if(25 < MVCFunctions.strlen((XVar)(disp_field)))
						{
							disp_field = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(disp_field), new XVar(0), new XVar(25)), "..."));
						}
						fields = MVCFunctions.Concat(fields, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(disp_field)), "\">", disp_field, "</option>");
					}
				}
				xt.assign(new XVar("fields"), (XVar)(fields));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200;\r\nvar closetimer\t= 0;\r\nvar relation_stack = 0;\r\n\r\n$(document).ready(function(){\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction collect_input_data() {\r\n//\tclean up all uncomplete rows\r\n\t\t$(\"td.field_value select\").each(function(){\r\n\t\t\tif($(this).val()==\"-1\")\r\n\t\t\t\t$(this).trigger(\"change\");\r\n\t\t});\r\n\t\tshowNewRow();\r\n\t\tvar output = {};\r\n\t\toutput.group_by_condition = {};\r\n\t\tvar j=0;\r\n\t\t$(\".condition-row\").each(function(){\r\n\t\t\tif ($(this).find(\"td.field_value select\").val() != \"-1\" && $(this).find(\"td.field_value select\").val() != null) \r\n\t\t\t{\r\n\t\t\t\toutput.group_by_condition[j] = {};\r\n\t\t\t\t$(this).find(\"input:text,select\").each(function(){\r\n\t\t\t\t\toutput.group_by_condition[j][$(this).attr(\"id\")] = $(this).val();\r\n\t\t\t\t});\r\n\t\t\t\tj++;\r\n\t\t\t}\r\n\t\t});\r\n\t\toutput.group_by_condition[\"group_by_toggle\"] = $(\"#group_by_toggle\").prop(\"checked\").toString();\r\n\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\t\r\n\t$(\"#sqlbtn\").bind(\"click\", function(){\r\n\t\tvar output = collect_input_data();\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"group_by_condition\",\r\n\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\r\n\t\r\n\tfor (var i=1; i < 10; i++) {\r\n\t\tvar tr_elem = $(\".condition-row\").eq(0).clone();\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){this.value=\"\";});\r\n\t\t$(tr_elem).attr(\"id\",\"cond_row_\"+i);\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){\r\n\t\t\tthis.disabled = true;\r\n\t\t});\r\n\t\t$(\"#table_wh\").append(tr_elem);\r\n\t\t$(tr_elem).hide();\r\n\t}\r\n\r\n\t$(\"td.field_value select\").change(function(){\r\n\r\n\t\tif ($(this).val() == \"-1\") \r\n\t\t{\r\n\t\t\t$(this).parents(\"tr:first\").find(\"input\").each(function(){\r\n\t\t\t\t$(this).val(\"\");\r\n\t\t\t});\r\n\t\t\t$(this).parents(\"tr:first\").find(\"select\").each(function()\r\n\t\t\t{\r\n\t\t\t\tvar oldVal=$(this).val();\r\n\t\t\t\t$(this).val(\"-1\");\r\n\t\t\t\tif(oldVal && oldVal!=\"-1\")\r\n\t\t\t\t\t$(this).trigger(\"change\");\r\n\t\t\t});\r\n\t\t\t$(this).parents(\"tr:first\").hide();\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tenableRow($(this).parents(\"tr:first\").get(0),true);\r\n\t\t\tshowNewRow();\r\n\t\t}\r\n\t});\t\r\n\t\r\n\t\r\n\t$(\"#group_by_toggle\").live(\"click\", function(){\r\n\t\tvar checked = $(this)[0].checked;\r\n\t\t$(\".condition-row\").each(function(){\r\n\t\t\t$(this).find(\"select#group_by_value\").attr(\"disabled\", !checked);\r\n\t\t\t$(this).find(\"input#having_value\").attr(\"disabled\", !checked);\r\n\t\t});\r\n\t});\r\n\t\r\n\t\r\n\t$(\"#row2\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n", "\r\n");
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar activeXDetectRules = [\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.7\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.6\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash\"}\r\n    ];\r\n\tvar getActiveXObject = function(name){\r\n        var obj = -1;\r\n        try{\r\n            obj = new ActiveXObject(name);\r\n        }catch(err){\r\n            obj = {activeXError:true};\r\n        }\r\n        return obj;\r\n    };\r\n\tif(navigator.plugins && navigator.plugins.length>0)\r\n\t{\r\n\t\tvar type = \"application/x-shockwave-flash\";\r\n\t\tvar mimeTypes = navigator.mimeTypes;\r\n\t\tif(!mimeTypes || !mimeTypes[type] || !mimeTypes[type].enabledPlugin || !mimeTypes[type].enabledPlugin.description)\r\n\t\t{\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\r\n\telse if(navigator.appVersion.indexOf(\"Mac\")==-1 && window.execScript)\r\n\t{\r\n\t\tvar isFlash = false;\r\n\t\tfor(var i=0; i<activeXDetectRules.length; i++){\r\n                var obj = getActiveXObject(activeXDetectRules[i].name);\r\n                if(!obj.activeXError){\r\n\t\t\t\t\tisFlash = true;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\tif(!isFlash){\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\t\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, ,#previewbtn\").click(function(){\r\n\t\r\n\t\tvar flag = true;\r\n\r\n\t\t//\tno validation required\t\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webchart")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart3")), "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart1")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row2\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\") {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tname: \"group_by_condition\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif( id == \"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Chart Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\t\t\t\t\t\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id !=\"row2\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"group_by_condition\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n\r\n\r\n\r\nfunction showNewRow()\r\n{\r\n\tif( 0 != $(\"select[name=field_opt]:visible\").filter( function() { \r\n\t\t\tvar value = $(this).val(); \r\n\t\t\treturn  value == \"-1\" || value == null;\r\n\t\t} ).length )\r\n\t\treturn;\r\n\r\n\tvar firstHidden=$(\"select[name=field_opt]:hidden:first\").parents(\"tr\").get(0);\r\n\t\r\n//\tappend it to the end\t\r\n\t$(\"#table_wh\").append(firstHidden);\r\n\tenableRow(firstHidden,true);\r\n}\r\n\r\nfunction enableRow(tr,enable)\r\n{\r\n\t$(tr).show();\r\n\t$(\"input, select\",tr).each(function(){\r\n\t\tif(this.name==\"field_opt\")\r\n\t\t\tthis.disabled=false;\r\n\t\telse if ((this.name == \"group_by_value\" || this.name == \"having_value\")) \r\n\t\t\tthis.disabled=!enable || !$(\"#group_by_toggle\")[0].checked;\r\n\t\telse\r\n\t\t\tthis.disabled = !enable;\r\n\t});\r\n\tif($(\"td.sort_dir select\",tr).val() && $(\"td.sort_dir select\",tr).val()!=\"-1\")\r\n\t\t$(\"td.sort_order select\",tr).show();\r\n\telse\r\n\t\t$(\"td.sort_order select\",tr).hide();\r\n\t\r\n}\r\n</script>", "\r\n");
				arr = XVar.Clone(XSession.Session["webcharts"]["group_by_condition"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t\t$(document).ready(function(){\r\n\t\t\t$(\"#group_by_toggle\")[0].checked = ", (XVar.Pack(arr["group_by_toggle"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ";\r\n\t\t", "\r\n");
					foreach (KeyValuePair<XVar, dynamic> tarr in arr.GetEnumerator())
					{
						if(XVar.Pack(!(XVar)(MVCFunctions.IsNumeric(tarr.Key))))
						{
							continue;
						}
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\ttr_elem = $(\".condition-row\").eq(", tarr.Key, ");\r\n\t\t$(tr_elem).show();\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){\r\n\t\t\tif ((this.id == \"group_by_value\" || this.id == \"having_value\") && !$(\"#group_by_toggle\")[0].checked) {\r\n\t\t\t\treturn;\r\n\t\t\t}\r\n\t\t\tthis.disabled = false;\r\n\t\t});\r\n\t\t$(tr_elem).find(\"select#field_opt\").val('", CommonFunctions.jsreplace((XVar)(arr[tarr.Key]["field_opt"])), "');\r\n\t\t$(tr_elem).find(\"input#filter_value\").val('", CommonFunctions.jsreplace((XVar)(arr[tarr.Key]["filter_value"])), "');\r\n\t\t$(tr_elem).find(\"input#first_or_value\").val('", CommonFunctions.jsreplace((XVar)(arr[tarr.Key]["first_or_value"])), "');\r\n\t\t$(tr_elem).find(\"input#second_or_value\").val('", CommonFunctions.jsreplace((XVar)(arr[tarr.Key]["second_or_value"])), "');\r\n\t\t$(tr_elem).find(\"input#third_or_value\").val('", CommonFunctions.jsreplace((XVar)(arr[tarr.Key]["third_or_value"])), "');\r\n\t\tsortDir = $(tr_elem).find(\"select#sort_dir\").get(0);\r\n\t\t$(sortDir).val(\"", arr[tarr.Key]["sort_dir"], "\");\r\n\t\tsortOrder=$(tr_elem).find(\"select#sort_order\").get(0);\r\n\t\tsortOrder.options[sortOrder.options.length]=new Option(\"\",\"", arr[tarr.Key]["sort_order"], "\");\r\n\t\t$(sortOrder).val(\"", arr[tarr.Key]["sort_order"], "\");\r\n\t\t$(tr_elem).find(\"select#group_by_value\").val(\"", arr[tarr.Key]["group_by_value"], "\");\r\n\t\t$(tr_elem).find(\"input#having_value\").val(\"", arr[tarr.Key]["having_value"], "\");\r\n\t\tif(!$(sortDir).val() || $(sortDir).val()==\"-1\")\r\n\t\t\t$(sortOrder).hide();\r\n\t\telse\r\n\t\t\t$(sortOrder).show();\r\n\t\t", "\r\n");
					}
					b_includes = MVCFunctions.Concat(b_includes, "\r\n/*\r\n\t\ttr_elem = $(\".condition-row\").eq(", MVCFunctions.count(arr) - 1, ");\r\n\t\t$(tr_elem).show();\r\n\t\t$(tr_elem).find(\"input, select\").each(function(){\r\n\t\t\tif ((this.id == \"group_by_value\" || this.id == \"having_value\") && !$(\"#group_by_toggle\")[0].checked) {\r\n\t\t\t\treturn;\r\n\t\t\t}\t\t\r\n\t\t\tthis.disabled = false;\r\n\t\t});\r\n*/\t\t\r\n\tshowNewRow();\r\n\twindow.refillOrderCombos = function(combo,shift)\r\n\t{\r\n\t\tvar newVal  = parseInt($(combo).val());\r\n\t\tvar changedElement=combo;\r\n\t\tvar optionsFound=new Array();\r\n\t\tvar optionsCount=0;\r\n//\tfind the options available\r\n\t\t$(\"td.sort_order select\").each( function() {\r\n\t\t\tvar curVal=parseInt($(this).val());\r\n\t\t\tif(curVal>0)\r\n\t\t\t{\r\n\t\t\t\toptionsFound[curVal]=true;\r\n\t\t\t\toptionsCount++;\r\n\t\t\t}\r\n\t\t});\r\n\t\tvar oldVal=-1;\r\n//\tfind the hole\r\n\t\tfor(i=1;i<optionsFound.length;i++)\r\n\t\t{\r\n\t\t\tif(!optionsFound[i])\r\n\t\t\t{\r\n\t\t\t\toldVal=i;\r\n\t\t\t\tbreak;\r\n\t\t\t}\r\n\t\t}\r\n//\tupdate all comboboxes\t\t\r\n\t\t$(\"td.sort_order select\").each( function() \r\n\t\t{\r\n//\tcalc options list and control value\r\n\t\t\tvar curVal=parseInt($(this).val());\r\n\t\t\tif(isNaN(curVal))\r\n\t\t\t\tcurVal=-1;\r\n//\tshift the value if needed\r\n\t\t\tif(shift)\r\n\t\t\t{\r\n\t\t\t\tvar hole=oldVal;\r\n\t\t\t\tif(hole<0)\r\n\t\t\t\t\thole=optionsFound.length;\r\n\t\t\t\tvar bump=newVal;\r\n\t\t\t\tif(newVal<0)\r\n\t\t\t\t\tbump=optionsFound.length;\r\n\t\t\t\tif(hole<bump)\r\n\t\t\t\t{\r\n\t\t\t\t\tif(curVal>hole && curVal<=bump && this!=changedElement)\r\n\t\t\t\t\t\tcurVal--;\r\n\t\t\t\t}\r\n\t\t\t\telse if(hole>bump)\r\n\t\t\t\t{\r\n\t\t\t\t\tif(curVal>=bump && curVal<hole && this!=changedElement)\r\n\t\t\t\t\t\tcurVal++;\r\n\t\t\t\t}\r\n\t\t\t}\r\n//\trecreate options\r\n\t\t\tthis.length=0;\r\n\t\t\tthis.options[0]=new Option(\"\",-1);\r\n\t\t\tvar largest=optionsCount;\r\n\t\t\tif(curVal<0)\r\n\t\t\t\tlargest++;\r\n\t\t\tif(largest<1)\r\n\t\t\t\tlargest=1;\r\n\t\t\tfor(i=1;i<=largest;i++)\r\n\t\t\t\tthis.options[i]=new Option(i,i);\r\n\t\t\tthis.selectedIndex=curVal;\r\n//\tupdate sort direction control\r\n\t\t\tvar sort_dir=$(\"td.sort_dir select\",$(this).parents(\"tr\").get(0)).get(0);\r\n\t\t\tif(!sort_dir)\r\n\t\t\t\treturn;\r\n\t\t\tif(curVal<0)\r\n\t\t\t{\r\n\t\t\t\t$(sort_dir).val(\"-1\");\r\n\t\t\t}\r\n\t\t});\r\n\t}\r\n\t$(\"td.sort_order select\").change(function(){\r\n\t\trefillOrderCombos(this,true);\r\n\t});\r\n\trefillOrderCombos($(\"td.sort_order:first select\")[0],false);\r\n\r\n\t$(\"td.sort_dir select\").change(function(){\r\n\t\tvar sort_order=$(\"td.sort_order select\",$(this).parents(\"tr\").get(0)).get(0);\r\n\t\tif(!$(this).val() || $(this).val()==\"-1\")\r\n\t\t{\r\n\t\t\t$(sort_order).val(\"-1\");\r\n\t\t\t$(sort_order).trigger(\"change\");\r\n\t\t\t$(sort_order).hide();\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tif($(sort_order).val()>0)\r\n\t\t\t\treturn;\r\n\t\t\t$(sort_order).show();\r\n//\tcount number of sort fields\r\n\t\t\tvar optionsCount=0;\r\n//\tfind the options available\r\n\t\t\t$(\"td.sort_order select\").each( function() {\r\n\t\t\t\tvar curVal=parseInt($(this).val());\r\n\t\t\t\tif(curVal>0)\r\n\t\t\t\t{\r\n\t\t\t\t\toptionsCount++;\r\n\t\t\t\t}\r\n\t\t\t});\r\n//\tset the max value\r\n\t\t\t$(sort_order).val(optionsCount+1);\r\n\t\t\t$(sort_order).trigger(\"change\");\r\n\t\t}\r\n\t});\r\n\tshowNewRow();\r\n});\r\n\r\n\r\n\t</script>", "\r\n");
				}
				xt.assign(new XVar("chart_name_preview"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart2")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
