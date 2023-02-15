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
		public ActionResult webreport4()
		{
			try
			{
				dynamic aSelGroupFields = XVar.Array(), aTableFields = XVar.Array(), arr = XVar.Array(), arr_fields = XVar.Array(), arr_join_tables = XVar.Array(), b_includes = null, cnt = null, disableLabel = null, field = null, h_includes = null, is_crosstable_report = null, rLinks = null, ri = null, table_name = null, templatefile = null, tgFields = null, types = null;
				ProjectSettings pSet;
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
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
					{
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				aSelGroupFields = XVar.Clone(XVar.Array());
				arr = XVar.Clone(XSession.Session["webreports"]["group_fields"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					dynamic i = null;
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr) - 1; i++)
					{
						aSelGroupFields.InitAndSetArrayItem(arr[i]["name"], null);
					}
				}
				is_crosstable_report = XVar.Clone(arr[MVCFunctions.count(arr) - 1]["cross_table"]);
				aTableFields = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> grval in aSelGroupFields.GetEnumerator())
				{
					foreach (KeyValuePair<XVar, dynamic> val in XSession.Session["webreports"]["totals"].GetEnumerator())
					{
						field = XVar.Clone(val.Value["name"]);
						if(XVar.Pack(CommonFunctions.is_wr_db()))
						{
							field = XVar.Clone(MVCFunctions.Concat(val.Value["table"], ".", field));
						}
						if(field == grval.Value)
						{
							aTableFields.InitAndSetArrayItem(new XVar("table", val.Value["table"], "field", val.Value["name"]), null);
						}
					}
				}
				arr_fields = XVar.Clone(XVar.Array());
				arr_fields = XVar.Clone(XSession.Session["webreports"]["totals"]);
				foreach (KeyValuePair<XVar, dynamic> val in arr_fields.GetEnumerator())
				{
					field = XVar.Clone(val.Value["name"]);
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						field = XVar.Clone(MVCFunctions.Concat(val.Value["table"], ".", field));
					}
					if(XVar.Pack(!(XVar)(MVCFunctions.in_array((XVar)(field), (XVar)(aSelGroupFields)))))
					{
						aTableFields.InitAndSetArrayItem(new XVar("table", val.Value["table"], "field", val.Value["name"]), null);
					}
				}
				table_name = XVar.Clone(XSession.Session["webreports"]["tables"][0]);
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
				tgFields = new XVar("");
				types = new XVar("");
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200;\r\nvar closetimer\t= 0;\r\nvar relation_stack = [];\r\n\r\n$(document).ready(function(){\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\r\n\t$(\"input[id^=all]\").click(function(){\r\n\t\tthisid=this.id.replace(\"all\",\"\");\r\n\t\tif($(this).prop(\"checked\"))\r\n\t\t\t$(\"input[name^=val_\"+thisid+\"]\").prop(\"checked\",true);\r\n\t\telse\r\n\t\t\t$(\"input[name^=val_\"+thisid+\"]\").prop(\"checked\",false);\r\n\t});\r\n\t\r\n\t$(\"input[name^=val_]\").click(function(){\r\n\t\tthisname=this.name;\r\n\t\tcheck_all=true;\r\n\t\t$(\"input[name=\"+thisname+\"]\").each(function(i){\r\n\t\t\tif(!$(this).prop(\"checked\"))\r\n\t\t\t\tcheck_all=false;\r\n\t\t});\r\n\t\t$(\"#all\"+thisname.replace(\"val_\",\"\")).prop(\"checked\",check_all);\r\n\t});\r\n\t\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.totals = {};\r\n\t\t$(\"tr[class*=tbody]\", \"#trt\").each(function(i){\r\n\t\t\tvar parts = $(\"td\",this).eq(1).text().split(\".\");\r\n\t\t\tvar sfield=parts[parts.length-1];\r\n\t\t\tvar stable = $(\"td\",this).eq(1).text();\r\n\t\t\tstable = stable.substring(0,stable.length-sfield.length-1);\r\n\t\t\tif($(\"td\",this).eq(8).find(\"input\").prop(\"checked\"))\r\n\t\t\t\tvf=\"", Constants.FORMAT_CURRENCY, "\";\r\n\t\t\telse\r\n\t\t\t\tvf=$(\"td\",this).eq(9).find(\"input\").eq(0).val();\r\n\t\t\toutput.totals[this.id] = {\r\n\t\t\t\tname : sfield, \r\n\t\t\t\ttable : stable,\r\n\t\t\t\tlabel : $(\"td\",this).eq(2).find(\"input\").val(),\r\n\t\t\t\tshow : $(\"td\",this).eq(3).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tmin : $(\"td\",this).eq(4).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tmax : $(\"td\",this).eq(5).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tsum : $(\"td\",this).eq(6).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tavg : $(\"td\",this).eq(7).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tcurr : $(\"td\",this).eq(8).find(\"input\").prop(\"checked\").toString(),\r\n\t\t\t\tsearch : \"\",\r\n\t\t\t\tview_format : vf,\r\n\t\t\t\tedit_format : $(\"td\",this).eq(9).find(\"input\").eq(1).val(),\r\n\t\t\t\tdisplay_field : $(\"td\",this).eq(9).find(\"input\").eq(2).val(),\r\n\t\t\t\tlinkfield : $(\"td\",this).eq(9).find(\"input\").eq(3).val(),\r\n\t\t\t\tshow_thumbnail : $(\"td\",this).eq(9).find(\"input\").eq(4).val(),\r\n\t\t\t\tneed_encode : $(\"td\",this).eq(9).find(\"input\").eq(5).val(),\r\n\t\t\t\tthumbnail : $(\"td\",this).eq(9).find(\"input\").eq(6).val(),\r\n\t\t\t\tlistformatobj_imgwidth : $(\"td\",this).eq(9).find(\"input\").eq(7).val(),\r\n\t\t\t\tlistformatobj_imgheight : $(\"td\",this).eq(9).find(\"input\").eq(8).val(),\r\n\t\t\t\thlprefix : $(\"td\",this).eq(8).find(\"input\").eq(10).val(),\r\n\t\t\t\tlistformatobj_filename : $(\"td\",this).eq(9).find(\"input\").eq(10).val(),\r\n\t\t\t\tlookupobj_lookuptype : $(\"td\",this).eq(9).find(\"input\").eq(11).val(),\r\n\t\t\t\teditformatobj_lookupobj_customdispaly : $(\"td\",this).eq(9).find(\"input\").eq(12).val(),\r\n\t\t\t\teditformatobj_lookupobj_table : $(\"td\",this).eq(9).find(\"input\").eq(13).val(),\r\n\t\t\t\teditformatobj_lookupobj_where : $(\"td\",this).eq(9).find(\"input\").eq(14).val()\r\n\t\t\t};\r\n\t\t});\r\n\t\treturn JSON.stringify(output);\r\n\t}\t\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"totals\",\r\n\t\t\t\tweb: \"webreports\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\t\r\n\t\r\n\t$(\"#row4\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n\r\n", "\r\n");
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
				if(is_crosstable_report == "true")
				{
					b_includes = MVCFunctions.Concat(b_includes, "$(\"td[name=show_fields]\").hide();", "\r\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#row5,#row6\").hide();", "\r\n");
				}
				rLinks = new XVar("var rlinks = {};\r\n");
				ri = new XVar(0);
				for(;ri < 10; ri++)
				{
					rLinks = MVCFunctions.Concat(rLinks, "rlinks['", ri, "'] = '", MVCFunctions.GetTableLink((XVar)(MVCFunctions.Concat("webreport", ri))), "';\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row], #savebtn, #saveasbtn, #previewbtn\").click(function(){\r\n\t\tvar URL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"nextbtn\" )", "\r\n");
				if(is_crosstable_report == "true")
				{
					b_includes = MVCFunctions.Concat(b_includes, "URL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";", "\r\n");
				}
				else
				{
					b_includes = MVCFunctions.Concat(b_includes, "URL = \"", MVCFunctions.GetTableLink(new XVar("webreport5")), "\";", "\r\n");
				}
				b_includes = MVCFunctions.Concat(b_includes, "\t\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport3")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\t\t\t\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id != \"row4\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id == \"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id == \"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( this.id == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\t\t\t\r\n\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1;\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\") {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"totals\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif(id==\"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t\t\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row4\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"totals\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				cnt = new XVar(0);
				if(XVar.Pack(CommonFunctions.is_wr_custom()))
				{
					GlobalVars.fields_type = XVar.Clone(XVar.Array());
					GlobalVars.fields_type = XVar.Clone(CommonFunctions.WRGetAllCustomFieldType());
				}
				disableLabel = new XVar("");
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					disableLabel = new XVar("disabled");
				}
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table_name)));
				foreach (KeyValuePair<XVar, dynamic> _arr in aTableFields.GetEnumerator())
				{
					dynamic adClass = null, blobCheck = null, blobClass = null, blobDisabled = null, disabled = null, field_type = null, prefix = null, val_avg = null, val_curr = null, val_max = null, val_min = null, val_show = null, val_sum = null, var_class = null, vf = null;
					cnt++;
					disabled = new XVar("");
					var_class = new XVar("active");
					blobDisabled = new XVar("");
					blobClass = new XVar("active");
					blobCheck = new XVar("checked");
					adClass = new XVar("active");
					field = XVar.Clone(_arr.Value["field"]);
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						field = XVar.Clone(MVCFunctions.Concat(_arr.Value["table"], ".", field));
					}
					if((XVar)(!(XVar)(aSelGroupFields.IsEmpty()))  && (XVar)(is_crosstable_report != "true"))
					{
						if(XVar.Pack(MVCFunctions.in_array((XVar)(field), (XVar)(aSelGroupFields))))
						{
							disabled = new XVar("disabled");
							var_class = new XVar("inactive");
							blobClass = new XVar("");
						}
					}
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
					{
						field_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(_arr.Value["table"], ".", _arr.Value["field"]))));
					}
					else
					{
						field_type = XVar.Clone(GlobalVars.fields_type[_arr.Value["field"]]);
					}
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						_arr.Value.InitAndSetArrayItem(table_name, "table");
					}
					if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(field_type))))
					{
						blobDisabled = new XVar("disabled");
						var_class = new XVar("");
						blobClass = new XVar("inactive");
						adClass = new XVar("inactive");
						blobCheck = new XVar("");
					}
					if((XVar)(var_class == "active")  && (XVar)(blobClass == "active"))
					{
						blobClass = new XVar("");
					}
					tgFields = MVCFunctions.Concat(tgFields, "<tr id=\"", MVCFunctions.GoodFieldName((XVar)(MVCFunctions.Concat(_arr.Value["table"], ".", _arr.Value["field"]))), "\" class=\"tbody\">\r\n\t\t<td width=\"10px\" style=\"border:0px\">\r\n\t\t\t\t<div style=\"height:7px\">");
					if(disabled == XVar.Pack(""))
					{
						tgFields = MVCFunctions.Concat(tgFields, "<img src=\"", MVCFunctions.GetRootPathForResources(new XVar("images/arr_up.jpg")), "\" onclick=\"total_td_move(this,'up');return false;\" style=\"cursor:pointer\">");
					}
					tgFields = MVCFunctions.Concat(tgFields, "</div>\r\n\t<div style=\"height:2px\">&nbsp;</div>\r\n\t<div style=\"height:7px\">");
					val_show = new XVar("");
					val_min = new XVar("");
					val_max = new XVar("");
					val_sum = new XVar("");
					val_avg = new XVar("");
					val_curr = new XVar("");
					if(disabled == XVar.Pack(""))
					{
						tgFields = MVCFunctions.Concat(tgFields, "<img src=\"", MVCFunctions.GetRootPathForResources(new XVar("images/arr_down.jpg")), "\" onclick=\"total_td_move(this,'down');return false;\" style=\"cursor:pointer\">");
						val_show = new XVar("val_show");
						if(blobDisabled == XVar.Pack(""))
						{
							val_min = new XVar("val_min");
							val_max = new XVar("val_max");
							val_sum = new XVar("val_sum");
							val_avg = new XVar("val_avg");
							val_curr = new XVar("val_curr");
						}
					}
					prefix = new XVar("");
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						prefix = XVar.Clone(MVCFunctions.Concat(XSession.Session["webreports"]["tables"][0], "_"));
					}
					if(XSession.Session["webreports"]["totals"][MVCFunctions.Concat(prefix, _arr.Value["field"])]["curr"] == "true")
					{
						vf = new XVar(Constants.FORMAT_CURRENCY);
					}
					else
					{
						vf = XVar.Clone(CommonFunctions.GetGenericViewFormat((XVar)(_arr.Value["table"]), (XVar)(_arr.Value["field"])));
					}
					tgFields = MVCFunctions.Concat(tgFields, "</div>\r\n\t\t</td>\r\n\t\t<td >", field, "</td> \r\n\t\t<td ><input type=\"text\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(pSet.label((XVar)(_arr.Value["field"])))), "\" name=\"\" ", disableLabel, "></td>\r\n\t\t<td align=\"center\"  name=show_fields ", var_class, MVCFunctions.substr((XVar)(blobClass), new XVar(2)), "\"><input ", disabled, " checked type=\"checkbox\" name=\"", val_show, "\" ></td>\r\n\t\t<td align=\"center\" ", var_class, blobClass, "\"><input ", blobDisabled, disabled, " type=\"checkbox\" name=\"", val_min, "\" ></td>\r\n\t\t<td align=\"center\" ", var_class, blobClass, "\"><input ", blobDisabled, disabled, " type=\"checkbox\" name=\"", val_max, "\" ></td>\r\n\t\t<td align=\"center\" ", var_class, blobClass, "\"><input ", blobDisabled, disabled, " type=\"checkbox\" name=\"", val_sum, "\" ></td>\r\n\t\t<td align=\"center\" ", var_class, blobClass, "\"><input ", blobDisabled, disabled, " type=\"checkbox\" name=\"", val_avg, "\" ></td>\r\n\t\t<td align=\"center\" ", var_class, blobClass, "\"><input ", blobDisabled, " type=\"checkbox\" name=\"", val_curr, "\" ></td>\r\n\t\t<td style=\"display:none;\">\r\n\t\t\t<input type=\"text\" id=\"vf", cnt, "\" name=\"vf", cnt, "\" value=\"", vf, "\" >\r\n\t\t\t<input type=\"text\" id=\"ef", cnt, "\" name=\"ef", cnt, "\" value=\"", CommonFunctions.GetGenericEditFormat((XVar)(_arr.Value["table"]), (XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"display_field_", cnt, "\" name=\"display_field_", cnt, "\" value=\"", pSet.getDisplayField((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"linkfield_", cnt, "\" name=\"linkfield_", cnt, "\" value=\"", pSet.getLinkField((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"show_thumbnail_", cnt, "\" name=\"show_thumbnail_", cnt, "\" value=\"", pSet.showThumbnail((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"need_encode_", cnt, "\" name=\"need_encode_", cnt, "\" value=\"", pSet.NeedEncode((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"thumbnail_", cnt, "\" name=\"thumbnail_", cnt, "\" value=\"", pSet.getStrThumbnail((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"listformatobj_imgwidth_", cnt, "\" name=\"listformatobj_imgwidth_", cnt, "\" value=\"", pSet.getImageWidth((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"listformatobj_imgheight_", cnt, "\" name=\"listformatobj_imgheight_", cnt, "\" value=\"", pSet.getImageHeight((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"hlprefix_", cnt, "\" name=\"hlprefix_", cnt, "\" value=\"", pSet.getLinkPrefix((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"listformatobj_filename_", cnt, "\" name=\"listformatobj_filename_", cnt, "\" value=\"", pSet.getFilenameField((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"lookupobj_lookuptype_", cnt, "\" name=\"lookupobj_lookuptype_", cnt, "\" value=\"", pSet.getLookupType((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"editformatobj_lookupobj_customdispaly_", cnt, "\" name=\"editformatobj_lookupobj_customdispaly_", cnt, "\" value=\"", pSet.getDisplayField((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"editformatobj_lookupobj_table_", cnt, "\" name=\"editformatobj_lookupobj_table_", cnt, "\" value=\"", pSet.getLookupTable((XVar)(_arr.Value["field"])), "\" >\r\n\t\t\t<input type=\"text\" id=\"editformatobj_lookupobj_where_", cnt, "\" name=\"editformatobj_lookupobj_where_", cnt, "\" value=\"", CommonFunctions.prepareLookupWhere((XVar)(_arr.Value["field"]), (XVar)(pSet)), "\" >\r\n\t\t</td>\r\n\t</tr>");
				}
				arr = XVar.Clone(XSession.Session["webreports"]["totals"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t\t$(document).ready(function(){", "\n");
					foreach (KeyValuePair<XVar, dynamic> totals in arr.GetEnumerator())
					{
						dynamic total_name = null;
						if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
						{
							b_includes = MVCFunctions.Concat(b_includes, "$('tr[id=", totals.Key, "]', '#trt').find('td').eq(1).text('", CommonFunctions.jsreplace((XVar)(MVCFunctions.Concat(totals.Value["table"], ".", totals.Value["name"]))), "');", "\n");
						}
						b_includes = MVCFunctions.Concat(b_includes, "$('tr[id=", totals.Key, "]', '#trt').find('td').eq(2).find('input').val('", CommonFunctions.jsreplace((XVar)(totals.Value["label"])), "');", "\n");
						total_name = XVar.Clone(totals.Value["name"]);
						if(XVar.Pack(CommonFunctions.is_wr_db()))
						{
							total_name = XVar.Clone(MVCFunctions.Concat(totals.Value["table"], ".", totals.Value["name"]));
						}
						if((XVar)(!(XVar)(MVCFunctions.in_array((XVar)(total_name), (XVar)(aSelGroupFields))))  || (XVar)(is_crosstable_report == "true"))
						{
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(3).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["show"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(4).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["min"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(5).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["max"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(6).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["sum"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(7).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["avg"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
							b_includes = MVCFunctions.Concat(b_includes, "$(\"tr[id=", totals.Key, "]\", \"#trt\").find(\"td\").eq(8).find(\"input\").attr(\"checked\",", (XVar.Pack(totals.Value["curr"] == "true") ? XVar.Pack("true") : XVar.Pack("false")), ");", "\n");
						}
					}
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\tarr=new Array;\r\n\tarr[0]=\"show\"\r\n\tarr[1]=\"min\"\r\n\tarr[2]=\"max\"\r\n\tarr[3]=\"sum\"\r\n\tarr[4]=\"avg\"\r\n\tarr[5]=\"curr\"\r\n\tfor(i=0;i<6;i++)\r\n\t{\r\n\t\tthisname=arr[i];\r\n\t\tcheck_all=true;\r\n\t\t$(\"input[name=val_\"+thisname+\"]\").each(function(j){\r\n\t\t\tif(!$(this).prop(\"checked\"))\r\n\t\t\t\tcheck_all=false;\r\n\t\t});\r\n\t\t$(\"#all\"+thisname).prop(\"checked\", check_all);\r\n\t}");
					b_includes = MVCFunctions.Concat(b_includes, "});");
					b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.MoveTdTotal());
					b_includes = MVCFunctions.Concat(b_includes, "</script>");
				}
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("tgFields"), (XVar)(tgFields));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport4")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
