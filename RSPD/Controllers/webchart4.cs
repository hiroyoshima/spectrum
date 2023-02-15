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
		public ActionResult webchart4()
		{
			try
			{
				dynamic arr = XVar.Array(), arr_data_series = XVar.Array(), arr_label_series = XVar.Array(), b_includes = null, dataSeries = null, h_includes = null, rLinks = null, ri = null, root = XVar.Array(), strLabel = null, table_name = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				root = XSession.Session["webcharts"];
				CommonFunctions.Reload_Chart((XVar)(MVCFunctions.postvalue(new XVar("cname"))));
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
				}
				xt = XVar.UnPackXTempl(new XTempl());
				table_name = XVar.Clone(root["tables"][0]);
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
				xt.assign(new XVar("chart_name"), (XVar)(root["settings"]["name"]));
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/stylesheet.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\r\narr_color = new Array();\r\n\r\narr_color[\"0\"]=\"#FFFFFF\";\r\n\r\narr_color[\"1\"]=\"#FF0000\";\r\narr_color[\"2\"]=\"#008000\";\r\narr_color[\"3\"]=\"#0000FF\";\r\n\r\narr_color[\"4\"]=\"#DC143C\";\r\narr_color[\"5\"]=\"#2E8B57\";\r\narr_color[\"6\"]=\"#6A5ACD\";\r\n\r\narr_color[\"7\"]=\"#FF7F50\";\r\narr_color[\"8\"]=\"#7FFF00\";\r\narr_color[\"9\"]=\"#5F9EA0\";\r\n\r\narr_color[\"10\"]=\"#FF8C00\";\r\narr_color[\"11\"]=\"#8FBC8B\";\r\narr_color[\"12\"]=\"#00008B\";\r\n\r\narr_color[\"13\"]=\"#FF1493\";\r\narr_color[\"14\"]=\"#556B2F\";\r\narr_color[\"15\"]=\"#00BFFF\";\r\n\r\narr_color[\"16\"]=\"#FF69B4\";\r\narr_color[\"17\"]=\"#008B8B\";\r\narr_color[\"18\"]=\"#ADD8E6\";\r\n\r\narr_color[\"19\"]=\"#F08080\";\r\narr_color[\"20\"]=\"#32CD32\";\r\narr_color[\"21\"]=\"#4169E1\";\r\n\r\narr_color[\"22\"]=\"#A52A2A\";\r\narr_color[\"23\"]=\"#006400\";\r\narr_color[\"24\"]=\"#6495ED\";\r\n\r\nvar timeout\t= 200,\r\n\tclosetimer\t= 0,\r\n\tfld_labels = new Array();\r\n", "\r\n");
				dataSeries = new XVar("");
				arr_data_series = XVar.Clone(XVar.Array());
				arr_label_series = XVar.Clone(XVar.Array());
				CommonFunctions.get_chart_series_fields(ref arr_data_series, ref arr_label_series);
				foreach (KeyValuePair<XVar, dynamic> _arr in arr_data_series.GetEnumerator())
				{
					dataSeries = MVCFunctions.Concat(dataSeries, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(_arr.Value["field"])), "\">", MVCFunctions.runner_htmlspecialchars((XVar)(_arr.Value["field"])), "</option>");
					b_includes = MVCFunctions.Concat(b_includes, "fld_labels['", CommonFunctions.jsreplace((XVar)(_arr.Value["field"])), "'] = '", CommonFunctions.jsreplace((XVar)(_arr.Value["label"])), "';", "\r\n");
				}
				xt.assign(new XVar("dataSeries"), (XVar)(dataSeries));
				strLabel = new XVar("");
				foreach (KeyValuePair<XVar, dynamic> _arr in arr_label_series.GetEnumerator())
				{
					strLabel = MVCFunctions.Concat(strLabel, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(_arr.Value["field"])), "\">", MVCFunctions.runner_htmlspecialchars((XVar)(_arr.Value["field"])), "</option>");
				}
				xt.assign(new XVar("label"), (XVar)(strLabel));
				b_includes = MVCFunctions.Concat(b_includes, "\r\nvar timeout\t= 200,\r\nclosetimer\t= 0,\r\nclosetimerpicker = 0,\r\ntimeoutpicker = 300;\r\n$(document).ready(function(){\r\n\r\n\t\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\r\n\tfunction add_dataseries(num)\r\n\t{\r\n\t\tif($(\"tr[id^=ds]\").length!=num)\r\n\t\t\treturn;\r\n\t\tdataseries=$(\"tr[id=clone]\").clone();\r\n\t\tdataseries.insertBefore(\"#ds\");\r\n\t\tdataseries.attr(\"id\",\"ds\"+num);\r\n\t\tdataseries.find(\"td:eq(1)\").html(\"Data Series \"+num);\r\n\t\t");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "ohlc")  && (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\t\tdataseries.find(\"td:eq(3)\").attr(\"id\",\"label_title_\"+num);\r\n\t\t\tdataseries.find(\"td:eq(4)\").attr(\"id\",\"label_value_\"+num);\t\t\r\n\t\t\tdataseries.find(\"input:eq(0)\").attr(\"id\",\"series_label_\"+num);\t\t\t\t\t\r\n\t\t\tdataseries.find(\"select:eq(0)\").attr(\"id\",\"field\"+num);\r\n\t\t\tdataseries.find(\"select:eq(0)\").attr(\"name\",\"field\"+num);\r\n\t\t\t$(\"select[id=field\"+num+\"]\").bind(\"change\", function(){\r\n\t\t\t\t\tadd_field_change(this);\r\n\t\t\t});");
					if(XSession.Session["webcharts"]["chart_type"]["type"] == "gauge")
					{
						b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\t\tgaugeseries=$(\"tr[id=clone_range]\").clone();\r\n\t\t\tgaugeseries.insertBefore(\"#ds\");\r\n\t\t\tgaugeseries.attr(\"id\",\"tr_range\"+num);\r\n\t\t\tgaugeseries.find(\"input:eq(0)\").attr(\"name\",\"gaugeMinValue\"+num);\r\n\t\t\tgaugeseries.find(\"input:eq(1)\").attr(\"name\",\"gaugeMaxValue\"+num);\r\n\t\t\tgaugeseries.show();\r\n\t");
					}
					else
					{
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\tdataseries.find(\"td:eq(5)\").attr(\"id\",\"picker_div\"+num);\r\n\t\t\tdataseries.find(\"td:eq(6)\").attr(\"id\",\"picker_selector\"+num);\r\n\t\t\tdataseries.find(\"div:eq(0)\").attr(\"id\",\"picker\"+num);\r\n\t\t\tdataseries.find(\"#picker\"+num).css(\"background-color\", arr_color[num]);\r\n\t\t\tdataseries.find(\".selector,.ColorPickerDivSample\").click(function(){\r\n\t\t\t\tclick_color_event(this);\r\n\t\t\t});\r\n\t\t\tdataseries.find(\"td[id^=picker]\").hide();\r\n\t\t\tdataseries.find(\"td[id^=label_title]\").hide();\r\n\t\t\tdataseries.find(\"td[id^=label_value]\").hide();\r\n\t\t\tdataseries.find(\"td[id^=label_title]\").prev(\"td\").attr(\"colSpan\",5);");
					}
					if(XSession.Session["webcharts"]["chart_type"]["type"] == "bubble")
					{
						b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\t\tsizeseries=$(\"tr[id=clone_size]\").clone();\r\n\t\t\tsizeseries.insertAfter(\"#ds\"+num);\r\n\t\t\tsizeseries.attr(\"id\",\"\");\r\n\t\t\tsizeseries.find(\"td:eq(1)\").html(\"Size Series \"+num);\r\n\t\t\tsizeseries.find(\"select:eq(0)\").attr(\"id\",\"size\"+num);\r\n\t\t\tsizeseries.find(\"select:eq(0)\").attr(\"name\",\"size\"+num);\r\n\t\t\tsizeseries.show();\r\n\t\t\t");
					}
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\tdataseries1=$(\"tr[id=clone1]\").clone();\r\n\t\t\tdataseries1.insertBefore(\"#ds\");\r\n\t\t\t\r\n\t\t\tdataseries2=$(\"tr[id=clone2]\").clone();\r\n\t\t\tdataseries2.insertBefore(\"#ds\");\r\n\t\t\t\r\n\t\t\tdataseries3=$(\"tr[id=clone3]\").clone();\r\n\t\t\tdataseries3.insertBefore(\"#ds\");\r\n\t\t\t\r\n\t\t\tdataseries1.attr(\"id\",\"\");\r\n\t\t\tdataseries2.attr(\"id\",\"\");\r\n\t\t\tdataseries3.attr(\"id\",\"\");\r\n\t\t\tdataseries1.find(\"select:eq(0)\").attr(\"id\",\"field_open\"+num);\r\n\t\t\tdataseries1.find(\"select:eq(0)\").attr(\"name\",\"field_open\"+num);\r\n\t\t\tdataseries1.find(\"select:eq(1)\").attr(\"id\",\"field_close\"+num);\r\n\t\t\tdataseries1.find(\"select:eq(1)\").attr(\"name\",\"field_close\"+num);\r\n\t\t\tdataseries2.find(\"select:eq(0)\").attr(\"id\",\"field_high\"+num);\r\n\t\t\tdataseries2.find(\"select:eq(0)\").attr(\"name\",\"field_high\"+num);\r\n\t\t\tdataseries2.find(\"select:eq(1)\").attr(\"id\",\"field_low\"+num);\r\n\t\t\tdataseries2.find(\"select:eq(1)\").attr(\"name\",\"field_low\"+num);\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t$(\"select[id^=field]\").bind(\"change\", function(){\r\n\t\t\t\tif($(this).attr(\"id\").length>5)\r\n\t\t\t\t\tadd_field_change(this);\r\n\t\t\t});\r\n\t\t\t\r\n\t\t\t\r\n\t\t\tdataseries3.find(\"td:eq(1)\").attr(\"id\",\"label_title_\"+num);\r\n\t\t\tdataseries3.find(\"td:eq(2)\").attr(\"id\",\"label_value_\"+num);\t\r\n\t\t\t\r\n\t\t\tdataseries3.find(\"td:eq(4)\").attr(\"id\",\"picker1_div\"+num);\r\n\t\t\tdataseries3.find(\"td:eq(5)\").attr(\"id\",\"picker1_selector\"+num);\r\n\t\t\tdataseries3.find(\"td:eq(6)\").attr(\"id\",\"picker2_div\"+num);\r\n\t\t\tdataseries3.find(\"td:eq(7)\").attr(\"id\",\"picker2_selector\"+num);\r\n\t\t\t\r\n\t\t\tdataseries3.find(\"div:eq(0)\").attr(\"id\",\"picker1_\"+num);\r\n\t\t\tdataseries3.find(\"div:eq(1)\").attr(\"id\",\"picker2_\"+num);\r\n\t\t\t\r\n\t\t\tdataseries3.find(\"#picker1_\"+num).css(\"background-color\", arr_color[num]);\r\n\t\t\tdataseries3.find(\"#picker2_\"+num).css(\"background-color\", arr_color[num]);\r\n\t\t\t\r\n\t\t\tdataseries3.find(\"input:eq(0)\").attr(\"id\",\"series_label_\"+num);\t\t\r\n\t\t\tdataseries3.find(\".selector,.ColorPickerDivSample\").click(function(){\r\n\t\t\t\tclick_color_event(this);\r\n\t\t\t});\r\n\t\t\tdataseries3.find(\"td[id^=picker]\").hide();\r\n\t\t\tdataseries3.find(\"td[id^=label_title]\").hide();\r\n\t\t\tdataseries3.find(\"td[id^=label_value]\").hide();\r\n\t\t\tdataseries1.show();\r\n\t\t\tdataseries2.show();\r\n\t\t\tdataseries3.show();\r\n\t\t\t");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\tdataseries.show();\r\n\t\t\r\n\t\tseparat=$(\"tr[id=clone_separator]\").clone();\r\n\t\tseparat.attr(\"id\",\"tr_separator\"+num);\r\n\t\tseparat.insertBefore(\"#ds\");\r\n\t\tseparat.show();\r\n\t}\r\n\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.parameters = [];\r\n\t\toutput.fields = [];\r\n\t\tcount=0;\r\n\t\t$(\"tr[id^=ds]\").each(function(i){\r\n\t\t\tvar func, reg_match,parts,sfield,stable,ssize,label, color, field_open, field_close, field_high, field_low, color2, color1;\r\n\t\t\treg_match = $(\"select[id^=field]\",this).val();\r\n\t\t\tif (reg_match != null)\r\n\t\t\t\treg_match = reg_match.match(/(.*)\\((.*)\\)/i);\r\n\t\t\tif (reg_match != null) \r\n\t\t\t{\r\n\t\t\t\tparts =\treg_match[2].split(\".\");\r\n\t\t\t\tsfield=parts[parts.length-1];\r\n\t\t\t\tstable = reg_match[2];\r\n\t\t\t\tstable = stable.substring(0,stable.length-sfield.length-1);\r\n\t\t\t\tlabel=$(\"input[id=series_label_\"+(i+1)+\"]\").val();\r\n\t\t\t\tcolor=rgbToHex($(\"#picker\"+(i+1)).css(\"background-color\"));\r\n\t\t\t\tfunc = reg_match[1];\r\n\t\t\t} \r\n\t\t\telse \r\n\t\t\t{\r\n\t\t\t\tparts = $(\"select[id^=field]\",this).val();\r\n\t\t\t\tif(parts!=null)\r\n\t\t\t\t{\r\n\t\t\t\t\tparts = parts.split(\".\");\r\n\t\t\t\t\tsfield=parts[parts.length-1];\r\n\t\t\t\t\tstable = $(\"select[id^=field]\",this).val();\r\n\t\t\t\t\tstable = stable.substring(0,stable.length-sfield.length-1);\r\n\t\t\t\t\tlabel=$(\"input[id^=series_label_\"+(i+1)+\"]\",this).val();\r\n\t\t\t\t\tcolor=rgbToHex($(\"#picker\"+(i+1)).css(\"background-color\"));\r\n\t\t\t\t}\r\n\t\t\t\tfunc = \"\";\r\n\t\t\t}\r\n\r\n\t\t\ttrn=$(this).next(\"tr\");");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t//finance\r\n\t\t\tvar fin_fields = new Array();\r\n\t\t\tfin_tr=trn;\r\n\t\t\tfin_fields[0]=\"field_open\";\r\n\t\t\tfin_fields[1]=\"field_close\";\r\n\t\t\tfin_fields[2]=\"field_high\";\r\n\t\t\tfin_fields[3]=\"field_low\";\r\n\t\t\tfin_fields[4]=\"label\";\r\n\t\t\t\r\n\t\t\tfor(j=0;j<5;j++)\r\n\t\t\t{\t\r\n\t\t\t\tif(j<4)\r\n\t\t\t\t{\r\n\t\t\t\t\treg_match = $(fin_tr).find(\"select[id=\"+fin_fields[j]+\"\"+(i+1)+\"]\",this).val();\r\n\t\t\t\t\tif (reg_match != null)\r\n\t\t\t\t\t\treg_match = reg_match.match(/(.*)\\((.*)\\)/i);\r\n\t\t\t\t\tif (reg_match != null) \r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tparts =\treg_match[2].split(\".\");\r\n\t\t\t\t\t\tsfield=parts[parts.length-1];\r\n\t\t\t\t\t\tstable = reg_match[2];\r\n\t\t\t\t\t\tstable = stable.substring(0,stable.length-sfield.length-1);\r\n\t\t\t\t\t} \r\n\t\t\t\t\telse \r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tparts = $(fin_tr).find(\"select[id=\"+fin_fields[j]+\"\"+(i+1)+\"]\",this).val();\r\n\t\t\t\t\t\tif(parts!=null)\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\tparts = parts.split(\".\");\r\n\t\t\t\t\t\t\tsfield=parts[parts.length-1];\r\n\t\t\t\t\t\t\tstable = $(\"select[id=\"+fin_fields[j]+\"\"+(i+1)+\"]\").val();\r\n\t\t\t\t\t\t\tstable = stable.substring(0,stable.length-sfield.length-1);\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n\t\t\t\t\teval(fin_fields[j]+\"=sfield;\");\r\n\t\t\t\t\tif(j==1 || j==3)\r\n\t\t\t\t\t\tfin_tr=$(fin_tr).next(\"tr\");\r\n\t\t\t\t}\r\n\t\t\t\telse\r\n\t\t\t\t{\r\n\t\t\t\t\tlabel=$(\"input[id=series_label_\"+(i+1)+\"]\").val();\r\n\t\t\t\t\tcolor1=rgbToHex($(\"#picker1_\"+(i+1)).css(\"background-color\"));\r\n\t\t\t\t\tcolor2=rgbToHex($(\"#picker2_\"+(i+1)).css(\"background-color\"));\r\n\t\t\t\t\tbreak;\r\n\t\t\t\t}\r\n\t\t\t}");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\t\t\t\r\n\t\t\t\r\n\t\t\t//bubble size\r\n\t\t\treg_match = $(trn).find(\"select[id^=size]\",this).val();\r\n\t\t\tif (reg_match != null)\r\n\t\t\t\treg_match = reg_match.match(/(.*)\\((.*)\\)/i);\r\n\t\t\tif (reg_match != null) \r\n\t\t\t{\r\n\t\t\t\tparts =\treg_match[2].split(\".\");\r\n\t\t\t\tssize=parts[parts.length-1];\r\n\t\t\t} \r\n\t\t\telse \r\n\t\t\t{\r\n\t\t\t\tparts = $(trn).find(\"select[id^=size]\",this).val();\r\n\t\t\t\tif(parts!=null)\r\n\t\t\t\t{\r\n\t\t\t\t\tparts = parts.split(\".\");\r\n\t\t\t\t\tssize=parts[parts.length-1];\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\t\r\n\t\t\t//gauge range\r\n\t\t\tgminvalue=$(trn).find(\"input[name^=gaugeMinValue]\").val();\r\n\t\t\tgmaxvalue=$(trn).find(\"input[name^=gaugeMaxValue]\").val();\r\n\t\t\t\r\n\t\t\t//gauge color \r\n\t\t\tk=0;\r\n\t\t\tvar gcolorzone = [];\r\n\t\t\tgcolorzone[0] = {\r\n\t\t\t\t\t\tgaugeColor : \"FF0000\",\r\n\t\t\t\t\t\tgaugeBeginColor : \"\",\r\n\t\t\t\t\t\tgaugeEndColor : \"\"\r\n\t\t\t\t\t};\r\n\t\t\t$(\"tr[name=tr_color\"+(i+1)+\"]\").each(function(j){\r\n\t\t\t\tif($(this).find(\"tr[minus=yes]\").attr(\"minus\")==\"yes\")\r\n\t\t\t\t{\r\n\t\t\t\t\tgcolorzone[k] = {\r\n\t\t\t\t\t\tgaugeColor : rgbToHex($(this).find(\"div[name=gaugeColor\"+(i+1)+\"]\").css(\"background-color\")) || \"\",\r\n\t\t\t\t\t\tgaugeBeginColor : $(this).find(\"input[name=gaugeBeginColor\"+(i+1)+\"]\").val() || \"\",\r\n\t\t\t\t\t\tgaugeEndColor : $(this).find(\"input[name=gaugeEndColor\"+(i+1)+\"]\").val() || \"\"\r\n\t\t\t\t\t};\r\n\t\t\t\t\tk++;\r\n\t\t\t\t}\r\n\t\t\t});");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "ohlc")  && (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "if(sfield!=\"\")");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "if(field_open!=\"\" && field_close!=\"\" && field_high!=\"\" && field_low!=\"\")");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t{\r\n\t\t\t\toutput.parameters[count] = {\r\n\t\t\t\t\tname     : sfield || \"\",\r\n\t\t\t\t\tsize     : ssize || \"\",\r\n\t\t\t\t\tgaugeMinValue     : gminvalue || \"\",\r\n\t\t\t\t\tgaugeMaxValue     : gmaxvalue || \"\",\r\n\t\t\t\t\tgaugeColorZone     : gcolorzone || \"\",\r\n\t\t\t\t\ttable    : stable || \"\",\r\n\t\t\t\t\tagr_func : func,\r\n\t\t\t\t\tseries_color\t: color || \"\",\r\n\t\t\t\t\tlabel    : label || \"\",\r\n\t\t\t\t\tohlcOpen : field_open || \"\",\r\n\t\t\t\t\tohlcClose : field_close || \"\",\r\n\t\t\t\t\tohlcHigh : field_high || \"\",\r\n\t\t\t\t\tohlcLow : field_low || \"\",\r\n\t\t\t\t\tohlcColor : color1 || \"\",\r\n\t\t\t\t\tohlcCandleColor : color2 || \"\"\r\n\t\t\t\t\t\r\n\t\t\t\t};\r\n\t\t\t\t// needed for compliance with previous version\r\n\t\t\t\toutput.fields[count] = {\r\n\t\t\t\t\tname   : sfield || \"\",\r\n\t\t\t\t\tlabel  : label || \"\",\r\n\t\t\t\t\tsearch : \"\"\r\n\t\t\t\t};\r\n\t\t\t\tcount++;\r\n\t\t\t}\r\n\t\t});\r\n\t\treturn JSON.stringify(output);\t\t\t\r\n\t}\r\n\r\n\t$(\"td[id^=label_title]\").hide();\r\n\t$(\"td[id^=label_value]\").hide();\r\n\t$(\"td[id^=picker]\").hide();");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id^=label_title]\").next(\"td\").next(\"td\").attr(\"colSpan\",2);");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[id^=label_title]\").prev(\"td\").attr(\"colSpan\",5);");
				}
				b_includes = MVCFunctions.Concat(b_includes, "$(\"div[id^=picker]\").css(\"background-color\", \"#FF0000\");\r\n\t\r\n\t$(\"select[id^=field]\").bind(\"change\", function(){\r\n\t\tif($(this).attr(\"id\").length>5)\r\n\t\t\tadd_field_change(this);\r\n\t});\r\n\t\r\n\tfunction add_field_change(th)\r\n\t{\r\n\t\tvar value = $(th).val(),\r\n\t\t\ttr = $(th).parents(\"tr:first\");");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\tif($(tr).prev(\"tr:[id^=ds]\").length==0)\r\n\t\t\ttr=$(tr).prev(\"tr\").prev(\"tr:[id^=ds]\")\r\n\t\telse\r\n\t\t\ttr=$(tr).prev(\"tr:[id^=ds]\");\r\n\t\t\r\n\t\ttr_input1=$(tr).next(\"tr\");\r\n\t\ttr_input2=$(tr).next(\"tr\").next(\"tr\");\r\n\r\n\t\tval1=$(tr_input1).find(\"select:eq(0)\").val();\r\n\t\tval2=$(tr_input1).find(\"select:eq(1)\").val();\r\n\t\tval3=$(tr_input2).find(\"select:eq(0)\").val();\r\n\t\tval4=$(tr_input2).find(\"select:eq(1)\").val();\r\n\t\t\r\n\t\tif(val1==\"\" || val2==\"\" || val3==\"\" || val4==\"\")\r\n\t\t\tvalue=\"\";\r\n\t\tid=$(tr).attr(\"id\").replace(\"ds\",\"\");\r\n\t\ttr=$(tr).next(\"tr\").next(\"tr\").next(\"tr\");\r\n\t");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\tif ( value != \"\" && value != null)\r\n\t\t{\r\n\t\t\t$(tr).find(\"td[id^=label_title]\").show();\r\n\t\t\t$(tr).find(\"td[id^=label_value]\").show();\r\n\t\t\t$(tr).find(\"td[id^=picker_div]\").show();");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"td[id^=label_title]\").next(\"td\").next(\"td\").attr(\"colSpan\",2);");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"td[id^=label_title]\").prev(\"td\").attr(\"colSpan\",1);");
				}
				b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"td[id^=picker_selector]\").show();\r\n\t\t\t$(tr).find(\"input[id^=series_label]\").val(fld_labels[value]);\r\n\t\t\tif($(th).attr(\"id\")!=\"field\")\r\n\t\t\t{\r\n\t\t\t\tnum=$(th).attr(\"id\").replace(\"field\",\"\");");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t$(tr).find(\"input[id^=series_label]\").val(\"Data Series \"+id);\r\n\t\t\t\t$(tr).find(\"td[id^=picker1_div]\").show();\r\n\t\t\t\t$(tr).find(\"td[id^=picker1_selector]\").show();");
					if(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick")
					{
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t$(tr).find(\"td[id^=picker2_div]\").show();\r\n\t\t\t\t$(tr).find(\"td[id^=picker2_selector]\").show();\r\n\t\t");
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\tnum=num.replace(\"_open\",\"\");\r\n\t\t\t\tnum=num.replace(\"_close\",\"\");\r\n\t\t\t\tnum=num.replace(\"_high\",\"\");\r\n\t\t\t\tnum=num.replace(\"_low\",\"\");\r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, "add_dataseries(parseInt(num)+1);\r\n\t\t\t}\r\n\t\t\t", "\r\n");
				if(XSession.Session["webcharts"]["chart_type"]["type"] == "gauge")
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\tds_id=$(tr).attr(\"id\");\r\n\t\t\tds_id=ds_id.replace(\"ds\",\"\");\r\n\t\t\tif($(\"tr[name=tr_color\"+ds_id+\"]\").attr(\"name\")==undefined)\r\n\t\t\t{\r\n\t\t\t\tadd_new_color(ds_id);\r\n\t\t\t}\r\n\t\t\t", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t} \r\n\t\telse \r\n\t\t{");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(tr).find(\"td[id^=picker1_div]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=picker1_selector]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=picker2_div]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=picker2_selector]\").hide();\r\n\t");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(tr).find(\"td[id^=picker_div]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=picker_selector]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=label_title]\").hide();\r\n\t\t\t$(tr).find(\"td[id^=label_value]\").hide();");
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"td[id^=label_title]\").next(\"td\").next(\"td\").attr(\"colSpan\",4);");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"td[id^=label_title]\").prev(\"td\").attr(\"colSpan\",5);");
				}
				b_includes = MVCFunctions.Concat(b_includes, "$(tr).find(\"input[id^=series_label]\").val(\"\");", "\r\n");
				if(XSession.Session["webcharts"]["chart_type"]["type"] == "bubble")
				{
					b_includes = MVCFunctions.Concat(b_includes, "trn = $(tr).next(\"tr\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(trn).find(\"select[id ^=size]\")[0].selectedIndex = 0;", "\r\n");
				}
				if(XSession.Session["webcharts"]["chart_type"]["type"] == "gauge")
				{
					b_includes = MVCFunctions.Concat(b_includes, "ds_id=$(tr).attr(\"id\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "ds_id=ds_id.replace(\"ds\",\"\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[name=tr_color\"+ds_id+\"]\").remove();", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"input[name=gaugeMinValue\"+ds_id+\"]\").val(\"\");", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"input[name=gaugeMaxValue\"+ds_id+\"]\").val(\"\");", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t}\r\n\t}\r\n\t\r\n\tfunction add_new_color(ds_id)\r\n\t{\r\n\t\ttr_color=$(\"tr[name=tr_color]\").clone();\r\n\t\ttr_color.insertBefore(\"#tr_separator\"+ds_id);\r\n\t\ttr_color.attr(\"name\",\"tr_color\"+ds_id);\r\n\t\ttr_color.find(\"input[name=gaugeBeginColor]\").attr(\"name\",\"gaugeBeginColor\"+ds_id);\r\n\t\ttr_color.find(\"input[name=gaugeEndColor]\").attr(\"name\",\"gaugeEndColor\"+ds_id);\r\n\t\ttr_color.find(\"input[name=minus]\").attr(\"name\",\"minus\"+ds_id);\r\n\t\ttr_color.find(\"div[name=gaugeColor]\").attr(\"name\",\"gaugeColor\"+ds_id);\r\n\t\tdiv_len=$(\"div[name=gaugeColor\"+ds_id+\"]\").length;\r\n\t\tdiv_len=div_len-parseInt(div_len/24);\r\n\t\ttr_color.find(\"div[name=gaugeColor\"+ds_id+\"]\").css(\"background-color\", arr_color[div_len]);\r\n\t\ttr_color.find(\".selector,.ColorPickerDivSample\").click(function(){\r\n\t\t\tclick_color_event(this);\r\n\t\t});\r\n\t\ttr_color.find(\"input[name=gaugeEndColor\"+ds_id+\"]\").keydown(function(){\r\n\t\t\tendcolor_event(this);\r\n\t\t});\r\n\t\ttr_color.find(\"input[name=gaugeBeginColor\"+ds_id+\"]\").keydown(function(){\r\n\t\t\tbegincolor_event(this);\r\n\t\t});\r\n\t\ttr_color.find(\"input[name=minus\"+ds_id+\"]\").click(function(){\r\n\t\t\t$(this).parents(\"tr:first\").parents(\"tr:first\").hide();\r\n\t\t\t$(this).parents(\"tr:first\").attr(\"minus\",\"\");\r\n\t\t});\r\n\t\ttr_color.show();\r\n\t}\r\n\t\r\n\tfunction endcolor_event(th)\r\n\t{\r\n\t\ttr = $(th).parents(\"tr:first\");\r\n\t\tid=$(th).attr(\"name\").replace(\"gaugeEndColor\",\"\");\r\n\t\tif(tr.find(\"input[name=gaugeBeginColor\"+id+\"]\").val()!=\"\" && tr.attr(\"minus\")!=\"yes\")\r\n\t\t{\r\n\t\t\ttr.attr(\"minus\",\"yes\");\r\n\t\t\ttr.find(\"input[name=minus\"+id+\"]\").show();\r\n\t\t\tadd_new_color(id);\r\n\t\t}\r\n\t}\r\n\t\r\n\tfunction begincolor_event(th,ev)\r\n\t{\r\n\t\ttr = $(th).parents(\"tr:first\");\r\n\t\tid=$(th).attr(\"name\").replace(\"gaugeBeginColor\",\"\");\r\n\t\tif(tr.find(\"input[name=gaugeEndColor\"+id+\"]\").val()!=\"\" && tr.attr(\"minus\")!=\"yes\")\r\n\t\t{\r\n\t\t\ttr.attr(\"minus\",\"yes\");\r\n\t\t\ttr.find(\"input[name=minus\"+id+\"]\").show();\r\n\t\t\tadd_new_color(id);\r\n\t\t}\r\n\t}\r\n\t\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"parameters\",\r\n\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\t\r\n\t\r\n\t$(\"#row4\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=9; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n\t\r\n\r\n", "\r\n");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.colorPickerMouse());
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.JumpTo());
				if((XVar)(MVCFunctions.count(CommonFunctions.GetUserGroups()) < 2)  || (XVar)((XVar)(root["settings"].KeyExists("status"))  && (XVar)(root["settings"]["status"] == "private")))
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
				if(root["settings"]["title"] == "")
				{
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\tfor (var i=2; i<=7; i++){\r\n\t\t\t$(\"td[id=row\" + i + \"]\").hide();\r\n\t\t};\r\n\t", "\r\n");
				}
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webchart", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\tvar activeXDetectRules = [\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.7\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash.6\"},\r\n            {\"name\":\"ShockwaveFlash.ShockwaveFlash\"}\r\n    ];\r\n\tvar getActiveXObject = function(name){\r\n        var obj = -1;\r\n        try{\r\n            obj = new ActiveXObject(name);\r\n        }catch(err){\r\n            obj = {activeXError:true};\r\n        }\r\n        return obj;\r\n    };\r\n\tif(navigator.plugins && navigator.plugins.length>0)\r\n\t{\r\n\t\tvar type = \"application/x-shockwave-flash\";\r\n\t\tvar mimeTypes = navigator.mimeTypes;\r\n\t\tif(!mimeTypes || !mimeTypes[type] || !mimeTypes[type].enabledPlugin || !mimeTypes[type].enabledPlugin.description)\r\n\t\t{\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\r\n\telse if(navigator.appVersion.indexOf(\"Mac\")==-1 && window.execScript)\r\n\t{\r\n\t\tvar isFlash = false;\r\n\t\tfor(var i=0; i<activeXDetectRules.length; i++){\r\n                var obj = getActiveXObject(activeXDetectRules[i].name);\r\n                if(!obj.activeXError){\r\n\t\t\t\t\tisFlash = true;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\tif(!isFlash){\r\n\t\t\t$(\"#previewbtn\").parent(\"span\").hide();\r\n\t\t\t$(\"#previewbtn\").hide();\r\n\t\t}\r\n\t}\t\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tif($(\"#colorPickerVtd\"))\r\n\t\t\t$(\"#colorPickerVtd\").hide();\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webchart")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart5")), "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart3")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webchart6"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row4\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row8\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row9\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\") {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tname: \"parameters\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif( id == \"savebtn\" )\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Chart Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row4\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"parameters\",\r\n\t\t\t\t\tweb: \"webcharts\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row8\" || thisid == \"row9\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});", "\r\n");
				arr = XVar.Clone(root["parameters"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					dynamic computed_value = null, i = null, label_name = null;
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr) - 1; i++)
					{
						if(XVar.Pack(CommonFunctions.is_wr_custom()))
						{
							table_name = new XVar("");
						}
						else
						{
							table_name = XVar.Clone(MVCFunctions.Concat(arr[i]["table"], "."));
						}
						computed_value = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["name"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["name"]))));
						b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\tadd_dataseries(", i + 1, ");\r\n\t\t\t$(\"select[id=field", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(computed_value)), "');");
						if(XVar.Pack(arr[i]["series_color"]))
						{
							b_includes = MVCFunctions.Concat(b_includes, "$(\"#picker", i + 1, "\").css(\"background-color\", \"#", arr[i]["series_color"], "\");", "\r\n");
						}
						if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
						{
							dynamic value_Close = null, value_High = null, value_Low = null, value_Open = null;
							value_Open = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["ohlcOpen"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["ohlcOpen"]))));
							value_Close = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["ohlcClose"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["ohlcClose"]))));
							value_High = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["ohlcHigh"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["ohlcHigh"]))));
							value_Low = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["ohlcLow"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["ohlcLow"]))));
							b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t$(\"select[id=field_open", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(value_Open)), "');\r\n\t\t\t$(\"select[id=field_close", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(value_Close)), "');\r\n\t\t\t$(\"select[id=field_high", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(value_High)), "');\r\n\t\t\t$(\"select[id=field_low", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(value_Low)), "');");
							if((XVar)(arr[i]["ohlcColor"])  || (XVar)(arr[i]["ohlcCandleColor"]))
							{
								b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t$(\"#picker1_", i + 1, "\").css(\"background-color\", \"#", arr[i]["ohlcColor"], "\");\r\n\t\t\t\t$(\"#picker2_", i + 1, "\").css(\"background-color\", \"#", arr[i]["ohlcCandleColor"], "\");\r\n\t\t\t\t", "\r\n");
							}
						}
						if(XSession.Session["webcharts"]["chart_type"]["type"] == "bubble")
						{
							dynamic size_value = null;
							size_value = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["size"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["size"]))));
							b_includes = MVCFunctions.Concat(b_includes, "$(\"select[id=size", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(size_value)), "');\r\n\t\t\t", "\r\n");
						}
						if(XSession.Session["webcharts"]["chart_type"]["type"] == "gauge")
						{
							dynamic j = null;
							b_includes = MVCFunctions.Concat(b_includes, "$(\"input[name=gaugeMinValue", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["gaugeMinValue"])), "');", "\r\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"input[name=gaugeMaxValue", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["gaugeMaxValue"])), "');", "\r\n");
							j = new XVar(0);
							for(;j < MVCFunctions.count(arr[i]["gaugeColorZone"]); j++)
							{
								b_includes = MVCFunctions.Concat(b_includes, "add_new_color(", i + 1, ");", "\r\n");
								b_includes = MVCFunctions.Concat(b_includes, "$(\"input[name=gaugeBeginColor", i + 1, "]:last\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["gaugeColorZone"][j]["gaugeBeginColor"])), "');\r\n\t\t\t\t$(\"input[name=gaugeEndColor", i + 1, "]:last\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["gaugeColorZone"][j]["gaugeEndColor"])), "');\r\n\t\t\t\t$(\"div[name=gaugeColor", i + 1, "]:last\").css(\"background-color\",\"#", arr[i]["gaugeColorZone"][j]["gaugeColor"], "\");");
								if(!XVar.Equals(XVar.Pack(j), XVar.Pack(0)))
								{
									b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t\t\t\ttr = $(\"input[name=gaugeBeginColor", i + 1, "]:last\").parents(\"tr:first\");\r\n\t\t\t\t\ttr.attr(\"minus\",\"yes\");\r\n\t\t\t\t\ttr.find(\"input[name=minus", i + 1, "]:last\").show();", "\r\n");
								}
							}
							b_includes = MVCFunctions.Concat(b_includes, "add_new_color(", i + 1, ");", "\r\n");
						}
					}
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						label_name = new XVar("");
					}
					else
					{
						label_name = XVar.Clone(MVCFunctions.Concat(arr[MVCFunctions.count(arr) - 1]["table"], "."));
					}
					b_includes = MVCFunctions.Concat(b_includes, "\t\t\r\n\t$(\"select[id=field]\").val('", CommonFunctions.jsreplace((XVar)(MVCFunctions.Concat(label_name, arr[MVCFunctions.count(arr) - 1]["name"]))), "');\r\n\t$(\"select[id^=field]\").change();\r\n\t", "\r\n");
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr) - 1; i++)
					{
						if(XVar.Pack(CommonFunctions.is_wr_custom()))
						{
							table_name = new XVar("");
						}
						else
						{
							table_name = XVar.Clone(MVCFunctions.Concat(arr[i]["table"], "."));
						}
						computed_value = XVar.Clone((XVar.Pack(arr[i]["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(arr[i]["agr_func"], "(", table_name, arr[i]["name"], ")")) : XVar.Pack(MVCFunctions.Concat(table_name, arr[i]["name"]))));
						if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "ohlc")  && (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "candlestick"))
						{
							b_includes = MVCFunctions.Concat(b_includes, "if($(\"select[id=field", i + 1, "]\").val()=='", CommonFunctions.jsreplace((XVar)(computed_value)), "')\r\n\t\t\t$(\"input[id=series_label_", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["label"])), "');", "\r\n");
						}
						else
						{
							b_includes = MVCFunctions.Concat(b_includes, "$(\"input[id=series_label_", i + 1, "]\").val('", CommonFunctions.jsreplace((XVar)(arr[i]["label"])), "');", "\r\n");
						}
					}
				}
				b_includes = MVCFunctions.Concat(b_includes, "});\r\n</script>", "\r\n");
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					xt.assign(new XVar("disable"), new XVar("disabled"));
				}
				if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "gauge")  && (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] != "bubble"))
				{
					xt.assign(new XVar("separator"), new XVar("style='display:none'"));
				}
				if(XSession.Session["webcharts"]["chart_type"]["type"] != "bubble")
				{
					xt.assign(new XVar("span_style"), new XVar("style='display:none'"));
				}
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("chart_name_preview"), (XVar)(XSession.Session["webcharts"]["settings"]["name"]));
				if(XSession.Session["webcharts"]["chart_type"]["type"] == "gauge")
				{
					templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart4_gauge")));
				}
				else
				{
					if((XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "ohlc")  || (XVar)(XSession.Session["webcharts"]["chart_type"]["type"] == "candlestick"))
					{
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart4_ohlc")));
					}
					else
					{
						templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webchart4")));
					}
				}
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
