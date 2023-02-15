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
		public ActionResult webreport6()
		{
			try
			{
				dynamic aCheckSortFields = XVar.Array(), aChecked = XVar.Array(), aSelSortFields = XVar.Array(), aSortFields = XVar.Array(), arr = XVar.Array(), arr_tables = XVar.Array(), b_includes = null, h_includes = null, i = null, rLinks = null, ri = null, sSortFields = null, sort_fields = XVar.Array(), templatefile = null, tmpOut = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.getUserName())))
				{
					XSession.Session["MyURL"] = MVCFunctions.GetTableLink(new XVar("webreport"));
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(XSession.Session["webreports"]["tables"][0])), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
				}
				CommonFunctions.Reload_Report((XVar)(MVCFunctions.postvalue(new XVar("rname"))));
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
				arr_tables = XVar.Clone(CommonFunctions.getReportTablesList());
				sort_fields = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> t in arr_tables.GetEnumerator())
				{
					dynamic tfields = XVar.Array();
					tfields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t.Value)));
					foreach (KeyValuePair<XVar, dynamic> f in tfields.GetEnumerator())
					{
						if(XVar.Pack(CommonFunctions.is_wr_db()))
						{
							sort_fields.InitAndSetArrayItem(MVCFunctions.Concat(t.Value, ".", f.Value), null);
						}
						else
						{
							sort_fields.InitAndSetArrayItem(f.Value, null);
						}
					}
				}
				aSelSortFields = XVar.Clone(XVar.Array());
				arr = XVar.Clone(XSession.Session["webreports"]["group_fields"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr) - 1; i++)
					{
						aSelSortFields.InitAndSetArrayItem(arr[i]["name"], i, "name");
						aSelSortFields.InitAndSetArrayItem("false", i, "desc");
					}
				}
				arr = XVar.Clone(XSession.Session["webreports"]["sort_fields"]);
				if(XVar.Pack(!(XVar)(arr.IsEmpty())))
				{
					i = new XVar(0);
					for(;i < MVCFunctions.count(arr); i++)
					{
						aCheckSortFields.InitAndSetArrayItem(arr[i]["name"], i, "name");
						aCheckSortFields.InitAndSetArrayItem(arr[i]["desc"], i, "desc");
					}
				}
				h_includes = new XVar("");
				b_includes = new XVar("");
				h_includes = MVCFunctions.Concat(h_includes, "\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/dstyle.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/css/jquery-ui.css")), "\" type=\"text/css\">\r\n\t<link rel=\"stylesheet\" href=\"", MVCFunctions.GetRootPathForResources(new XVar("include/fancybox/jquery.fancybox.css")), "\" type=\"text/css\" media=\"screen\">\r\n\t\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.dimensions.pack.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.easing.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.fancybox.pack.js")), "\"></script>\r\n    <script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery-ui.js")), "\"></script>\r\n\t<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/json.js")), "\"></script>\r\n", "\r\n");
				xt.assign(new XVar("h_includes"), (XVar)(h_includes));
				b_includes = MVCFunctions.Concat(b_includes, "\r\n<script type=\"text/javascript\">\r\nvar timeout\t= 200;\r\nvar closetimer\t= 0;\r\nvar relation_stack = [];\r\n\r\n$(document).ready(function(){\r\n\t$(\"a#sql_query\").fancybox({\r\n\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 800,\r\n\t\t\t\theight : 550,\r\n\t\t\t\toverlayShow: true\r\n\t});\r\n\t\t$(\"a#preview\").fancybox({\r\n\t\t\tfitToView: false,\r\n\t\t\t\tautoSize: false,\r\n\t\t\t\twidth : 820,\r\n\t\t\t\theight : 660,\r\n\t\t\t\toverlayShow: true\r\n\t\t});\r\n\t\r\n\t");
				b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\r\n\tfunction collect_input_data() {\r\n\t\tvar output = {};\r\n\t\toutput.sort_fields = [];\r\n\t\t$(\"select[id^=field]\").each(function(i){\r\n\t\t\tif ( $(this).val() != \"\" ) {\r\n\t\t\t\toutput.sort_fields[i] = {\r\n\t\t\t\t\tname : $(this).val(),\r\n\t\t\t\t\tdesc : $(this).parent(\"td\").next(\"td\").find(\"input\").prop(\"checked\").toString()\r\n\t\t\t\t};\r\n\t\t\t}\r\n\t\t});\r\n\t\treturn JSON.stringify(output);\t\t\r\n\t}\r\n\t\r\n\t$(\"#sqlbtn\").click(function(){\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\t\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\tdata: {\r\n\t\t\t\tname: \"sort_fields\",\r\n\t\t\t\tweb: \"webreports\",\r\n\t\t\t\tstr_xml: output,\r\n\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t},\r\n\t\t\tsuccess: function(msg){\r\n\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t$(\"#sql_query\").click();\r\n\t\t\t\t} else {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\t});\t\r\n\t\r\n\t$(\"#row6\")\r\n\t\t.css(\"cursor\", \"default\")\r\n\t\t.css(\"font-weight\", \"bold\");\r\n\r\n\t$(\"td[id^=row]\").mouseover(function(){\r\n\t\tfor(var i=0; i<=11; i++) {\r\n\t\t\tif(i == this.id.replace(\"row\", \"\")) {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#92BEEB\");\r\n\t\t\t}\r\n\t\t\telse {\r\n\t\t\t\t$(\"td[id=row\" + i + \"]\").css(\"background-color\",\"#F4F7FB\");\r\n\t\t\t}\r\n\t\t}\r\n\t});\r\n \r\n\r\n", "\r\n");
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
				b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(\"#nextbtn, #backbtn, td[id^=row],#savebtn,#saveasbtn,#previewbtn\").click(function(){\r\n\t\tvar URL=\"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t", rLinks, "\r\n\t\tif( this.id == \"nextbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\r\n\t\tif( this.id == \"backbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport5")), "\";\r\n\t\tif( this.id == \"saveasbtn\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport8"), new XVar(""), new XVar("saveas=1")), "\";\r\n\t\tif( this.id.substr(0,3)==\"row\" && this.id !=\"row6\" )\r\n\t\t\tURL = rlinks[this.id.replace('row','')];\r\n\t\tif( this.id ==\"row10\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\tif( this.id ==\"row11\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("menu")), "\";\r\n\t\tif ( this.id == \"row7\" )\r\n\t\t\tURL = \"", MVCFunctions.GetTableLink(new XVar("dreport")), "?edit=style&rname=", XSession.Session["webreports"]["settings"]["name"], "\";\t\t\t\r\n\t\t\r\n\t\tvar output = collect_input_data();\r\n\t\tvar_save=0;\r\n\t\tif( this.id == \"savebtn\")\r\n\t\t\tvar_save=1\r\n\t\tif( this.id == \"savebtn\" || this.id == \"previewbtn\") {\r\n\t\t\tid=this.id;\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsave: var_save,\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tname: \"sort_fields\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\tif(id==\"savebtn\")\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t$(\"#alert\")\r\n\t\t\t\t\t\t\t\t.html(\"<p>", "Report Saved", "</p>\")\r\n\t\t\t\t\t\t\t\t.dialog(\"option\", \"close\", function(){\r\n\t\t\t\t\t\t\t\t\twindow.location = \"", MVCFunctions.GetTableLink(new XVar("webreport")), "\";\r\n\t\t\t\t\t\t\t\t})\r\n\t\t\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t$(\"#preview\").click();\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\terror: function() {\r\n\t\t\t\t\t$(\"#alert\").html(\"<p>", "Some problems appear during saving", "</p>\").dialog(\"open\");\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\r\n\t\tthisid=this.id;\r\n\t\tif(this.id != \"row6\" && this.id !=\"savebtn\" && this.id !=\"previewbtn\") {\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-state")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"sort_fields\",\r\n\t\t\t\t\tweb: \"webreports\",\r\n\t\t\t\t\tstr_xml: output,\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.location = URL;\r\n\t\t\t\t\t} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\").dialog(\"open\");\r\n\t\t\t\t\t\tif( thisid == \"row10\" || thisid == \"row11\" )\r\n\t\t\t\t\t\t\twindow.location=URL;\t\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\t});\r\n});\r\n</script>", "\r\n");
				sSortFields = new XVar("");
				foreach (KeyValuePair<XVar, dynamic> fld in sort_fields.GetEnumerator())
				{
					sSortFields = MVCFunctions.Concat(sSortFields, "<option value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(fld.Value)), "\">", fld.Value, "</option>", "\r\n");
				}
				i = new XVar(0);
				for(;i < 5; i++)
				{
					aSortFields.InitAndSetArrayItem(sSortFields, null);
					aChecked.InitAndSetArrayItem("", null);
				}
				arr = XVar.Clone(aSelSortFields);
				if(XVar.Pack(!(XVar)(aCheckSortFields.IsEmpty())))
				{
					tmpOut = XVar.Clone(MVCFunctions.array_slice((XVar)(aCheckSortFields), (XVar)(MVCFunctions.count(arr))));
				}
				if(XVar.Pack(!(XVar)(tmpOut.IsEmpty())))
				{
					arr = XVar.Clone(MVCFunctions.array_merge((XVar)(arr), (XVar)(tmpOut)));
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(arr); i++)
				{
					sSortFields = new XVar("");
					foreach (KeyValuePair<XVar, dynamic> fld in sort_fields.GetEnumerator())
					{
						dynamic selected = null;
						selected = XVar.Clone((XVar.Pack(fld.Value == arr[i]["name"]) ? XVar.Pack("selected") : XVar.Pack("")));
						sSortFields = MVCFunctions.Concat(sSortFields, "<option ", selected, " value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(fld.Value)), "\">", fld.Value, "</option>", "\r\n");
					}
					aSortFields.InitAndSetArrayItem(sSortFields, i);
					aChecked.InitAndSetArrayItem((XVar.Pack(arr[i]["desc"] == "true") ? XVar.Pack("checked") : XVar.Pack("")), i);
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(aSortFields); i++)
				{
					xt.assign((XVar)(MVCFunctions.Concat("sortFields", i + 1)), (XVar)(aSortFields[i]));
					xt.assign((XVar)(MVCFunctions.Concat("desc", i + 1)), (XVar)(aChecked[i]));
				}
				i = new XVar(0);
				for(;i < MVCFunctions.count(aSelSortFields); i++)
				{
					b_includes = MVCFunctions.Concat(b_includes, "<script type=\"text/javascript\">\r\n\t\t$(document).ready(function(){", "\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"tbody > tr\", \"#tsf\").eq(", i, ").find(\"td\").eq(0).find(\"select\").get(0).disabled = true;", "\n");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"tbody > tr\", \"#tsf\").eq(", i, ").find(\"td\").eq(1).find(\"input\").get(0).disabled = true;", "\n");
					b_includes = MVCFunctions.Concat(b_includes, "});\r\n\t</script>");
				}
				xt.assign(new XVar("report_name_preview"), (XVar)(XSession.Session["webreports"]["settings"]["name"]));
				xt.assign(new XVar("b_includes"), (XVar)(b_includes));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("webreport6")));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
