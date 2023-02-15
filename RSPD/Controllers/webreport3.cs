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
		public ActionResult webreport3()
		{
			try
			{
				dynamic aChecked = null, aColor1 = XVar.Array(), aColor2 = XVar.Array(), aGrTypes = XVar.Array(), aGroupFields = XVar.Array(), aTypes = XVar.Array(), arr = XVar.Array(), arr_tables = XVar.Array(), b_includes = null, group_fields = XVar.Array(), h_includes = null, i = null, is_crosstable_report = null, rLinks = null, ri = null, sGroupFields = null, templatefile = null, types = null;
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
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(XSession.Session["webreports"]["tables"][0])), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				xt = XVar.UnPackXTempl(new XTempl());
				arr_tables = XVar.Clone(CommonFunctions.getReportTablesList());
				group_fields = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> t in arr_tables.GetEnumerator())
				{
					dynamic tfields = XVar.Array();
					tfields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t.Value)));
					foreach (KeyValuePair<XVar, dynamic> f in tfields.GetEnumerator())
					{
						if(XVar.Pack(CommonFunctions.is_wr_db()))
						{
							group_fields.InitAndSetArrayItem(MVCFunctions.Concat(t.Value, ".", f.Value), null);
						}
						else
						{
							group_fields.InitAndSetArrayItem(f.Value, null);
						}
					}
				}
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
				sGroupFields = new XVar("");
				types = new XVar("");
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/stylesheet.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "\r\narr_color = new Array();\r\n\r\narr_color[\"0\"]=\"FFFFFF\";\r\n\r\narr_color[\"1\"]=\"FF0000\";\r\narr_color[\"2\"]=\"008000\";\r\narr_color[\"3\"]=\"0000FF\";\r\n\r\narr_color[\"4\"]=\"DC143C\";\r\narr_color[\"5\"]=\"2E8B57\";\r\narr_color[\"6\"]=\"6A5ACD\";\r\n\r\narr_color[\"7\"]=\"FF7F50\";\r\narr_color[\"8\"]=\"7FFF00\";\r\narr_color[\"9\"]=\"5F9EA0\";\r\n\r\narr_color[\"10\"]=\"FF8C00\";\r\narr_color[\"11\"]=\"8FBC8B\";\r\narr_color[\"12\"]=\"00008B\";\r\n\r\narr_color[\"13\"]=\"FF1493\";\r\narr_color[\"14\"]=\"556B2F\";\r\narr_color[\"15\"]=\"00BFFF\";\r\n\r\narr_color[\"16\"]=\"FF69B4\";\r\narr_color[\"17\"]=\"008B8B\";\r\narr_color[\"18\"]=\"ADD8E6\";\r\n\r\narr_color[\"19\"]=\"F08080\";\r\narr_color[\"20\"]=\"32CD32\";\r\narr_color[\"21\"]=\"4169E1\";\r\n\r\narr_color[\"22\"]=\"A52A2A\";\r\narr_color[\"23\"]=\"006400\";\r\narr_color[\"24\"]=\"6495ED\";\r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "fld_types = new Array();", "\r\n");
				if(XVar.Pack(CommonFunctions.is_wr_custom()))
				{
					GlobalVars.fields_type = XVar.Clone(XVar.Array());
					GlobalVars.fields_type = XVar.Clone(CommonFunctions.WRGetAllCustomFieldType());
				}
				foreach (KeyValuePair<XVar, dynamic> fld in group_fields.GetEnumerator())
				{
					dynamic var_type = null;
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
					{
						var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(fld.Value)));
					}
					else
					{
						var_type = XVar.Clone(GlobalVars.fields_type[fld.Value]);
					}
					if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(var_type))))
					{
						b_includes = MVCFunctions.Concat(b_includes, "fld_types['", CommonFunctions.jsreplace((XVar)(fld.Value)), "'] = \"number\";", "\r\n");
					}
					else
					{
						if(XVar.Pack(CommonFunctions.IsCharType((XVar)(var_type))))
						{
							b_includes = MVCFunctions.Concat(b_includes, "fld_types['", CommonFunctions.jsreplace((XVar)(fld.Value)), "'] = \"string\";", "\r\n");
						}
						else
						{
							if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(var_type))))
							{
								b_includes = MVCFunctions.Concat(b_includes, "fld_types['", CommonFunctions.jsreplace((XVar)(fld.Value)), "'] = \"date\";", "\r\n");
							}
						}
					}
				}
				if(XVar.Pack(CommonFunctions.is_wr_db()))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport4")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport2")), "\";\r\n\t", "\r\n");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar NEXT_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport4")), "\",\r\n\t\tPREV_PAGE_URL = \"", MVCFunctions.GetTableLink(new XVar("webreport0")), "\";\r\n\t", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\nvar timeout\t= 200,\r\n\tclosetimerpicker\t= 0,\r\n\tclosetimer=0,\r\n\ttimeoutpicker\t = 300,\r\n\trelation_stack = [],\r\n\tint_types = new Array(\r\n\t\t[0, \"Normal\"],\r\n\t\t[10, \"10s\"],\r\n\t\t[50, \"50s\"],\r\n\t\t[100, \"100s\"],\r\n\t\t[500, \"500s\"],\r\n\t\t[1000, \"1000s\"]\r\n\t),\r\n\tstr_types = new Array(\r\n\t\t[0, \"Normal\"],\r\n\t\t[1, \"1st Letter\"],\r\n\t\t[2, \"2 Initial Letters\"],\r\n\t\t[3, \"3 Initial Letters\"],\r\n\t\t[4, \"4 Initial Letters\"],\r\n\t\t[5, \"5 Initial Letters\"]\r\n\t),\r\n\tdate_types = new Array(\r\n\t\t[0, \"Normal\"],\r\n\t\t[1, \"Year\"],\r\n\t\t[2, \"Quarter\"],\r\n\t\t[3, \"Month\"],\r\n\t\t[4, \"Week\"],\r\n\t\t[5, \"Day\"],\r\n\t\t[6, \"Hour\"],\r\n\t\t[7, \"Minute\"]\r\n\t);\r\n\r\n$(document).ready(function(){\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tfunction add_dataseries(th)\r\n\t{\r\n\t\ttotal_fields=$(\"select[id^=field]\").length;\r\n\t\tthis_id=parseInt($(th).attr(\"id\").replace(\"field\",\"\"));\r\n\t\tif($(th)[0].selectedIndex==0)\r\n\t\t{\r\n\t\t\tcolor=\"FFFFFF\";\r\n\t\t\tif(this_id<25) \r\n\t\t\t\tcolor=arr_color[this_id];\r\n\t\t\t$(\"#picker\"+this_id).css(\"background-color\",color);\r\n\t\t\tfor(i=this_id+1;i<=total_fields;i++)\r\n\t\t\t\t$(\"#groupfield\"+i).remove();\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tif($(\"select[id=field\"+total_fields+\"]\")[0].selectedIndex!=0)\r\n\t\t\t{\r\n\t\t\t\tgroupfield=$(\"tr[id=clone]\").clone();\r\n\t\t\t\tgroupfield.insertBefore(\"#end_of_group_fields\");\r\n\t\t\t\tgroupfield.attr(\"id\",\"groupfield\"+parseInt(total_fields+1));\r\n\t\t\t\tgroupfield.find(\"input:eq(0)\").attr(\"id\",\"go\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"name\",\"go\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"value\",parseInt(total_fields+1));\r\n\t\t\t\tgroupfield.find(\"select:eq(0)\").attr(\"id\",\"field\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"name\",\"field\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.change(function(){\r\n\t\t\t\t\t\tadd_dataseries(this);\r\n\t\t\t\t\t})[0].selectedIndex = 0;\r\n\t\t\t\tgroupfield.find(\"select:eq(1)\").attr(\"id\",\"type\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"name\",\"type\"+parseInt(total_fields+1));\r\n\t\t\t\tgroupfield.find(\"select:eq(2)\").attr(\"id\",\"group_type\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"name\",\"group_type\"+parseInt(total_fields+1));\r\n\t\t\t\tgroupfield.find(\"input:eq(1)\").attr(\"id\",\"ss\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.attr(\"name\",\"ss\"+parseInt(total_fields+1));\r\n\t\t\t\tcolor = \"FFFFFF\";\r\n\t\t\t\tif((total_fields+1)<25) \r\n\t\t\t\t\tcolor = arr_color[total_fields+1];\r\n\t\t\t\tarr = HexToDec(color);\r\n\t\t\t\tred = parseInt( arr[0] * 0.85 );\r\n\t\t\t\tgreen = parseInt( arr[1] * 0.85 );\r\n\t\t\t\tblue = parseInt( arr[2] * 0.85 );\r\n\t\t\t\thex = DecToHex( red, green, blue );\r\n\t\t\t\tgroupfield.find(\"div:eq(0)\").attr(\"id\",\"picker\"+parseInt(total_fields+1))\r\n\t\t\t\t\t.css(\"background-color\",color)\r\n\t\t\t\t\t.attr(\"color1\",color)\r\n\t\t\t\t\t.attr(\"color2\",hex)\r\n\t\t\t\t\t.click(function(){\r\n\t\t\t\t\t\tclick_color_event(this);\r\n\t\t\t\t\t});\r\n\t\t\t\tgroupfield.find(\".selector\").click(function(){\r\n\t\t\t\t\tclick_color_event(this);\r\n\t\t\t\t});\r\n\t\t\t\tgroupfield.show();\r\n\t\t\t}\r\n\t\t}\r\n\t\t$(\"select[id=type\" + this_id + \"]\").empty();\r\n\t  \tswitch ( fld_types[th.value] ) {\r\n\t\t\tcase \"number\":\r\n\t\t\t\tfor (var i=0; i < int_types.length; i++) {\r\n\t\t\t\t\t$(\"select[id=type\" + this_id + \"]\").append('<option value=\"' + int_types[i][0] + '\">' + int_types[i][1] + '</option>');\r\n\t\t\t\t}\r\n\t\t\t\t$(\"select[id=type\" + this_id + \"]\")[0].selectedIndex = 0;\r\n\t\t\t\tbreak;\r\n\t\t\tcase \"string\":\r\n\t\t\t\tfor (var i=0; i < str_types.length; i++) {\r\n\t\t\t\t\t$(\"select[id=type\" + this_id + \"]\").append(\"<option value=\\\"\" + str_types[i][0] + \"\\\">\" + str_types[i][1] +\"</option>\");\r\n\t\t\t\t}\r\n\t\t\t\t$(\"select[id=type\" + this_id + \"]\")[0].selectedIndex = 0;\r\n\t\t\t\tbreak;\r\n\t\t\tcase \"date\":\r\n\t\t\t\tfor (var i=0; i < date_types.length; i++) {\r\n\t\t\t\t\t$(\"select[id=type\" + this_id + \"]\").append('<option value=\"' + date_types[i][0] + '\">' + date_types[i][1] + '</option>');\r\n\t\t\t\t}\r\n\t\t\t\t$(\"select[id=type\" + this_id + \"]\")[0].selectedIndex = 0;\r\n\t\t\t\tbreak;\r\n\t\t\tdefault:\r\n\t\t\t\tbreak;\r\n\t\t}\r\n\t}\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.group_fields = [];\r\n\t\tk=0;\r\n\t\t$(\"tr[id^=groupfield]\").each(function(i){\r\n\t\t\tval_field=$(this).find(\"select:eq(0)\").val();\r\n\t\t\tflag=true;\r\n\t\t\t$(\"tr[id^=groupfield]\").each(function(j){\r\n\t\t\t\tif(j >= i)\r\n\t\t\t\t\treturn false;\r\n\t\t\t\tif(j<i && val_field==$(this).find(\"select:eq(0)\").val()){\r\n\t\t\t\t\tflag = false;\r\n\t\t\t\t\treturn false;\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t\tif ( $(this).find(\"select:eq(0)\").val() != \"\" && $(this).find(\"select:eq(0)\").val() != undefined && flag) {\r\n\t\t\t\toutput.group_fields[k] = {\r\n\t\t\t\t\tname        : $(\"select[id^=field]\",this).val(),\r\n\t\t\t\t\tint_type    : $(\"select[id^=type]\",this).val(),\r\n\t\t\t\t\tss          : $(\"input[id^=ss]\",this).prop(\"checked\").toString(),\r\n\t\t\t\t\tgroup_order : $(\"input[id^=go]\",this).val(),\r\n\t\t\t\t\tgroup_type      : $(\"select[id^=group_type]\",this).val(),\r\n\t\t\t\t\tcolor1      : $(\"div[id^=picker]\",this).attr(\"color1\"),\r\n\t\t\t\t\tcolor2      : $(\"div[id^=picker]\",this).attr(\"color2\")\r\n\t\t\t\t};\r\n\t\t\t\tk++;\r\n\t\t\t}\r\n\t\t});\r\n\t\toutput.group_fields.push({\r\n\t\t\tname : \"Summary\",\r\n\t\t\tcross_table\t: $(\"#select_cross\")[0].checked.toString(),\r\n\t\t\tsps  : $(\"#sps\").prop(\"checked\").toString(),\r\n\t\t\tsds  : $(\"#sds\").prop(\"checked\").toString(),\r\n\t\t\tsgs  : $(\"#sgs\").prop(\"checked\").toString(),\r\n\t\t\tsum_x  : $(\"#sum_x\").prop(\"checked\").toString(),\r\n\t\t\tsum_y  : $(\"#sum_y\").prop(\"checked\").toString(),\r\n\t\t\tsum_total  : $(\"#sum_total\").prop(\"checked\").toString()\r\n\t\t\t});\r\n\t\treturn JSON.stringify(output);\r\n\t}");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.colorPickerMouse());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\r\n\t$(\"#sum_x,#sum_y\").click(function(){\r\n\t\tif(!$(\"#sum_x\")[0].checked || !$(\"#sum_y\")[0].checked)\r\n\t\t{\r\n\t\t\t$(\"#sum_total\")[0].checked=false;\r\n\t\t\t$(\"#sum_total\")[0].disabled=true;\r\n\t\t}\r\n\t\telse\r\n\t\t\t$(\"#sum_total\")[0].disabled=false;\r\n\t});\r\n\t$(\"#select_cross\").click(function(){\r\n\t\tshow_hide_cross_table_report($(this)[0].checked);\r\n\t});\r\n\tfunction show_hide_cross_table_report(ch)\r\n\t{\r\n\t\tif(ch)\r\n\t\t{\r\n\t\t\t$(\"td[name=report_col],th[name=report_col],table[name=report_col]\").hide();\r\n\t\t\t$(\"td[name=cross_col],th[name=cross_col],table[name=cross_col]\").show();\r\n\t\t\tif($(\"#field2\").length>0)\r\n\t\t\t{\r\n\t\t\t\tif($(\"#field2\")[0].selectedIndex==0)\r\n\t\t\t\t{\r\n\t\t\t\t\t$(\"#field2\")[0].selectedIndex=2;\r\n\t\t\t\t\t$(\"#field2\").change();\r\n\t\t\t\t\t$(\"#group_type2\")[0].selectedIndex=1;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t$(\"#row5,#row6\").hide();\r\n\t\t\tif(!$(\"#sum_x\")[0].checked || !$(\"#sum_y\")[0].checked)\r\n\t\t\t{\r\n\t\t\t\t$(\"#sum_total\")[0].checked=false;\r\n\t\t\t\t$(\"#sum_total\")[0].disabled=true;\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t\t$(\"#sum_total\")[0].disabled=false;\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\t$(\"td[name=report_col],th[name=report_col],table[name=report_col]\").show();\r\n\t\t\t$(\"td[name=cross_col],th[name=cross_col],table[name=cross_col]\").hide();\r\n\t\t\t$(\"#row5,#row6\").show();\r\n\t\t}\r\n\t}\r\n\t$(\"select[id^=field]\").change(function(){\r\n\t  \tadd_dataseries(this);\r\n\t});\t\r\n\t$(\"#row3\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n\r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(MVCFunctions.count(CommonFunctions.GetUserGroups()) < 2)  || (XVar)((XVar)(XSession.Session["webreports"]["settings"].KeyExists("status"))  && (XVar)(XSession.Session["webreports"]["settings"]["status"] == "private")))
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
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webreport", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tif($(\"#colorPickerVtd\"))\r\n\t\t\t$(\"#colorPickerVtd\").hide();\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = NEXT_PAGE_URL;\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = PREV_PAGE_URL;\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row3\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( this.id == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\r\n\t\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\" ) {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"group_fields\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif(id==\"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row3\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"group_fields\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});", "\r\n");
				foreach (KeyValuePair<XVar, dynamic> fld in group_fields.GetEnumerator())
				{
					sGroupFields = MVCFunctions.Concat(sGroupFields, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(fld.Value)), "\">", fld.Value, "</option>", "\r\n");
				}
				aGroupFields = XVar.Clone(XVar.Array());
				aTypes = XVar.Clone(XVar.Array());
				aChecked = XVar.Clone(XVar.Array());
				aColor1 = XVar.Clone(XVar.Array());
				aColor2 = XVar.Clone(XVar.Array());
				aGrTypes = XVar.Clone(XVar.Array());
				arr = XVar.Clone(XSession.Session["webreports"]["group_fields"]);
				if(MVCFunctions.count(arr) == 1)
				{
					dynamic arr_fields = XVar.Array(), gfield = null, table = null;
					arr.InitAndSetArrayItem(arr[0], null);
					table = XVar.Clone(XSession.Session["webreports"]["tables"][0]);
					arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(table)));
					gfield = XVar.Clone(arr_fields[0]);
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						gfield = XVar.Clone(MVCFunctions.Concat(table, ".", arr_fields[0]));
					}
					arr.InitAndSetArrayItem(new XVar(0, new XVar("name", gfield, "int_type", "0", "ss", "true", "group_order", "1", "color1", "FF0000", "color2", "CC0000")), 0);
				}
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					dynamic akeys = XVar.Array(), j = null, key = null, summIdx = null;
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr) - 1; i++)
					{
						sGroupFields = new XVar("");
						key = new XVar(0);
						j = new XVar(0);
						foreach (KeyValuePair<XVar, dynamic> fld in group_fields.GetEnumerator())
						{
							if(fld.Value == arr[i]["name"])
							{
								key = XVar.Clone(j + 1);
							}
							sGroupFields = MVCFunctions.Concat(sGroupFields, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(fld.Value)), "\">", fld.Value, "</option>", "\r\n");
							j++;
						}
						aGroupFields.InitAndSetArrayItem(sGroupFields, i);
						aTypes.InitAndSetArrayItem(arr[i]["int_type"], i);
						aColor1.InitAndSetArrayItem(arr[i]["color1"], i);
						aColor2.InitAndSetArrayItem(arr[i]["color2"], i);
						aGrTypes.InitAndSetArrayItem(arr[i]["group_type"], i);
						if(arr[i]["ss"] == "true")
						{
							b_includes = MVCFunctions.Concat(b_includes, "$(\"#ss", i + 1, "\")[0].checked=true;");
						}
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#field", i + 1, "\")[0].selectedIndex=", key, ";\r\n\t\tadd_dataseries($(\"#field", i + 1, "\"));\r\n\t\t", "\r\n");
					}
					akeys = XVar.Clone(MVCFunctions.array_keys((XVar)(arr)));
					summIdx = XVar.Clone(akeys[MVCFunctions.count(akeys) - 1]);
					xt.assign(new XVar("sps"), (XVar)((XVar.Pack(arr[summIdx]["sps"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
					xt.assign(new XVar("sds"), (XVar)((XVar.Pack(arr[summIdx]["sds"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
					xt.assign(new XVar("sgs"), (XVar)((XVar.Pack(arr[summIdx]["sgs"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
					xt.assign(new XVar("sum_x"), (XVar)((XVar.Pack(arr[summIdx]["sum_x"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
					xt.assign(new XVar("sum_y"), (XVar)((XVar.Pack(arr[summIdx]["sum_y"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
					xt.assign(new XVar("sum_total"), (XVar)((XVar.Pack(arr[summIdx]["sum_total"] == "true") ? XVar.Pack("checked") : XVar.Pack(""))));
				}
				else
				{
					xt.assign(new XVar("sps"), new XVar(""));
					xt.assign(new XVar("sds"), new XVar("checked"));
					xt.assign(new XVar("sgs"), new XVar(""));
					xt.assign(new XVar("sum_x"), new XVar("checked"));
					xt.assign(new XVar("sum_y"), new XVar("checked"));
					xt.assign(new XVar("sum_total"), new XVar("checked"));
				}
				is_crosstable_report = new XVar("");
				if(MVCFunctions.count(group_fields) < 3)
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#select_cross\").parent().parent().hide();\r\n\t\t\t\t\t$(\"#select_cross\")[0].checked=false");
				}
				else
				{
					is_crosstable_report = XVar.Clone(arr[MVCFunctions.count(arr) - 1]["cross_table"]);
				}
				if(is_crosstable_report == "true")
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#select_cross\")[0].checked=true;\r\n\t\t$(\"#row5,#row6\").hide();show_hide_cross_table_report(true);\r\n\t", "\r\n");
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(aGroupFields); i++)
				{
					xt.assign((XVar)(MVCFunctions.Concat("groupFields", i + 1)), (XVar)(aGroupFields[i]));
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"select[id^=field]\").change();", "\r\n");
				i = new XVar(0);
				for(;i < MVCFunctions.count(aTypes); i++)
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"select[id=type", i + 1, "]\").children().each(function(i){\r\n\t\tif ( $(this).attr(\"value\") == \"", aTypes[i], "\" ) {\r\n\t\t\tsetTimeout(\"$('select[id=type", i + 1, "]')[0].selectedIndex = \" + i + \";\",500);\r\n\t\t}\r\n\t});", "\r\n");
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(aGrTypes); i++)
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"select[id=group_type", i + 1, "]\").children().each(function(i){\r\n\t\tif ( $(this).attr(\"value\") == \"", aGrTypes[i], "\" ) {\r\n\t\t\tsetTimeout(\"$('select[id=group_type", i + 1, "]')[0].selectedIndex = \" + i + \";\",500);\r\n\t\t}\r\n\t});", "\r\n");
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(aColor1); i++)
				{
					b_includes = MVCFunctions.Concat(b_includes, " var picker", i + 1, " = $(\"div[id=picker", i + 1, "]\");\r\n\t");
					if(aColor1[i] != "")
					{
						b_includes = MVCFunctions.Concat(b_includes, "picker", i + 1, ".css(\"background-color\",\"#", aColor1[i], "\");", "\r\n");
					}
					b_includes = MVCFunctions.Concat(b_includes, "picker", i + 1, ".attr(\"color1\", \"", aColor1[i], "\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "picker", i + 1, ".attr(\"color2\", \"", aColor2[i], "\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "if( $(\"#field", i + 1, "\").attr(\"disabled\") ){", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "picker", i + 1, ".css(\"cursor\",\"default\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "picker", i + 1, ".parent().next(\"td\").find(\"img\").css(\"cursor\",\"default\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "}", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n</script>");
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport3")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
