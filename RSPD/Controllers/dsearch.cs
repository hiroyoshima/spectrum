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
		public ActionResult dsearch()
		{
			try
			{
				dynamic aGroupFields = XVar.Array(), aTotFields = XVar.Array(), all_checkbox = null, any_checkbox = null, arr_alias = XVar.Array(), arr_join_tables = XVar.Array(), arr_not_group_fields = XVar.Array(), arr_page_order_fields = XVar.Array(), arr_unset = XVar.Array(), body = XVar.Array(), contents_block = XVar.Array(), editformats = XVar.Array(), fld_type = null, i = null, id = null, includes = null, inspect_fields = XVar.Array(), jscode = null, ngFieldNames = null, pageName = null, pageObject = null, sessPrefix = null, templatefile = null, var_params = XVar.Array(), xml_array = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				CommonFunctions.add_nocache_headers();
				GlobalVars.strTableName = new XVar("");
				xml_array = XVar.Clone(XVar.Array());
				sessPrefix = new XVar("");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("rname"))))
				{
					xml_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue(new XVar("rname"))), new XVar(Constants.WR_REPORT)));
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
					{
						sessPrefix = XVar.Clone(MVCFunctions.Concat("webreport", MVCFunctions.postvalue(new XVar("rname"))));
					}
				}
				else
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("cname"))))
					{
						xml_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue(new XVar("cname"))), new XVar(Constants.WR_CHART)));
						sessPrefix = XVar.Clone(MVCFunctions.Concat("webchart", MVCFunctions.postvalue(new XVar("cname"))));
					}
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.isLogged())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("login"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				else
				{
					if((XVar)(xml_array["settings"]["status"] == "private")  && (XVar)(xml_array["owner"] != XSession.Session["UserID"]))
					{
						MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this report", "</p>"));
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				if(!XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(xml_array["table_relations"]["join_tables"]), new XVar(","))), XVar.Pack(false)))
				{
					arr_join_tables = XVar.Clone(MVCFunctions.array_slice((XVar)(MVCFunctions.explode(new XVar(","), (XVar)(xml_array["table_relations"]["join_tables"]))), new XVar(0), new XVar(-1)));
				}
				arr_join_tables.InitAndSetArrayItem(xml_array["tables"][0], null);
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					foreach (KeyValuePair<XVar, dynamic> _tbl in arr_join_tables.GetEnumerator())
					{
					}
				}
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("rname"))))
				{
					inspect_fields = XVar.Clone(xml_array["totals"]);
				}
				else
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("cname"))))
					{
						dynamic arr_fields = XVar.Array(), j = null, k = null, slabel = null, t = null;
						inspect_fields = XVar.Clone(XVar.Array());
						i = new XVar(0);
						for(;i < CommonFunctions.pre8count((XVar)(arr_join_tables)); i++)
						{
							t = XVar.Clone(arr_join_tables[i]);
							arr_fields = XVar.Clone(CommonFunctions.WRGetNBFieldsList((XVar)(t)));
							j = new XVar(0);
							for(;j < CommonFunctions.pre8count((XVar)(arr_fields)); j++)
							{
								slabel = XVar.Clone(arr_fields[j]);
								k = new XVar(0);
								for(;k < CommonFunctions.pre8count((XVar)(xml_array["parameters"])) - 1; k++)
								{
									if(xml_array["parameters"][k]["name"] == slabel)
									{
										slabel = XVar.Clone(xml_array["parameters"][k]["label"]);
										break;
									}
								}
								inspect_fields.InitAndSetArrayItem(new XVar("table", t, "name", arr_fields[j], "show", "true", "label", slabel), null);
							}
						}
					}
				}
				pageName = XVar.Clone(MVCFunctions.GetTableLink(new XVar("dsearch")));
				includes = new XVar("");
				jscode = new XVar("");
				xt = XVar.UnPackXTempl(new XTempl());
				id = XVar.Clone(CommonFunctions.postvalue_number(new XVar("id")));
				if(MVCFunctions.intval((XVar)(id)) == 0)
				{
					id = new XVar(1);
				}
				var_params = XVar.Clone(new XVar("pageType", Constants.PAGE_SEARCH, "id", id));
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				GlobalVars.pageObject = XVar.Clone(new WebreportPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				includes = XVar.Clone(MVCFunctions.Concat("<script type=\"text/javascript\" src=\"", MVCFunctions.GetRootPathForResources(new XVar("include/js/jquery.min.js")), "\"></script>"));
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_JAN='", CommonFunctions.jsreplace(new XVar("January")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_FEB='", CommonFunctions.jsreplace(new XVar("February")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_MAR='", CommonFunctions.jsreplace(new XVar("March")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_APR='", CommonFunctions.jsreplace(new XVar("April")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_MAY='", CommonFunctions.jsreplace(new XVar("May")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_JUN='", CommonFunctions.jsreplace(new XVar("June")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_JUL='", CommonFunctions.jsreplace(new XVar("July")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_AUG='", CommonFunctions.jsreplace(new XVar("August")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_SEP='", CommonFunctions.jsreplace(new XVar("September")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_OCT='", CommonFunctions.jsreplace(new XVar("October")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_NOV='", CommonFunctions.jsreplace(new XVar("November")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_MONTH_DEC='", CommonFunctions.jsreplace(new XVar("December")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_SU='", CommonFunctions.jsreplace(new XVar("Su")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_MO='", CommonFunctions.jsreplace(new XVar("Mo")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_TU='", CommonFunctions.jsreplace(new XVar("Tu")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_WE='", CommonFunctions.jsreplace(new XVar("We")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_TH='", CommonFunctions.jsreplace(new XVar("Th")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_FR='", CommonFunctions.jsreplace(new XVar("Fr")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_DAY_SA='", CommonFunctions.jsreplace(new XVar("Sa")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "TEXT_TODAY='", CommonFunctions.jsreplace(new XVar("today")), "';\r\n");
				jscode = MVCFunctions.Concat(jscode, "\r\nlocale_dateformat = \"", GlobalVars.locale_info["LOCALE_IDATE"], "\";\r\nlocale_datedelimiter = \"", GlobalVars.locale_info["LOCALE_SDATE"], "\";\r\nbLoading = false;\r\nTEXT_PLEASE_SELECT = \"", CommonFunctions.jsreplace(new XVar("Please select")), "\"; \r\ndetect = navigator.userAgent.toLowerCase();\r\ncheckIt = function(string)\r\n{\r\n\tplace = detect.indexOf(string) + 1;\r\n\tthestring = string;\r\n\treturn place;\r\n}\r\nShowHideControls = function ()\r\n{");
				foreach (KeyValuePair<XVar, dynamic> fld in inspect_fields.GetEnumerator())
				{
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						fld_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(fld.Value["table"], ".", fld.Value["name"]))));
					}
					else
					{
						if(XVar.Pack(CommonFunctions.is_wr_custom()))
						{
							fld_type = XVar.Clone(CommonFunctions.WRCustomGetFieldType((XVar)(fld.Value["table"]), (XVar)(fld.Value["name"])));
						}
						else
						{
							fld_type = XVar.Clone(CommonFunctions.GetFieldType((XVar)(fld.Value["name"]), (XVar)(fld.Value["table"])));
						}
					}
					if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(fld_type)))))
					{
						if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_custom())))
						{
							jscode = MVCFunctions.Concat(jscode, "\r\n\t\t\t\tdocument.getElementById(\"second_", MVCFunctions.GoodFieldName((XVar)(fld.Value["table"])), "_", MVCFunctions.GoodFieldName((XVar)(fld.Value["name"])), "\").style.display =  \r\n\t\t\t\t\tdocument.forms.editform.elements[\"asearchopt_", MVCFunctions.GoodFieldName((XVar)(fld.Value["table"])), "_", MVCFunctions.GoodFieldName((XVar)(fld.Value["name"])), "_1\"].value == \"Between\" ? \"\" : \"none\";\r\n\t\t\t");
						}
						else
						{
							jscode = MVCFunctions.Concat(jscode, "\r\n\t\t\t\tdocument.getElementById(\"second_", MVCFunctions.GoodFieldName((XVar)(fld.Value["name"])), "\").style.display =  \r\n\t\t\t\t\tdocument.forms.editform.elements[\"asearchopt_", MVCFunctions.GoodFieldName((XVar)(fld.Value["name"])), "_1\"].value == \"Between\" ? \"\" : \"none\";\r\n\t\t\t");
						}
					}
				}
				jscode = MVCFunctions.Concat(jscode, "\r\n\treturn false;\r\n}\r\nResetControls = function() {\r\n\tvar i;\r\n\te = document.forms[0].elements; \r\n\tfor (i=0;i<e.length;i++) \r\n\t{\r\n\t\tif (e[i].name!=\"type\" && e[i].className!=\"button\" && e[i].type!=\"hidden\")\r\n\t\t{\r\n\t\t\tif(e[i].type==\"select-one\")\r\n\t\t\t\te[i].selectedIndex=0;\r\n\t\t\telse if(e[i].type==\"select-multiple\")\r\n\t\t\t{\r\n\t\t\t\tvar j;\r\n\t\t\t\tfor(j=0;j<e[i].options.length;j++)\r\n\t\t\t\t\te[i].options[j].selected=false;\r\n\t\t\t}\r\n\t\t\telse if(e[i].type==\"checkbox\" || e[i].type==\"radio\")\r\n\t\t\t\te[i].checked=false;\r\n\t\t\telse \r\n\t\t\t\te[i].value = \"\"; \r\n\t\t}\r\n\t\telse if(e[i].name.substr(0,6)==\"value_\" && e[i].type==\"hidden\")\r\n\t\t\te[i].value = \"\"; \r\n\t}\r\n\tShowHideControls();\t\r\n\treturn false;\r\n};\r\nOnKeyDown = function(e){\r\n\tif(!e) e = window.event; \r\n\tif (e.keyCode == 13){\r\n\t\te.cancel = true;\r\n\t\tdocument.forms[0].submit();\r\n\t}\r\n};");
				if(XVar.Pack(CommonFunctions.is_wr_custom()))
				{
					jscode = MVCFunctions.Concat(jscode, "\r\n\t$(document).ready(function(){\r\n\t\t$(\".text\").hide();\r\n\t\t});\r\n\t");
				}
				all_checkbox = new XVar("value=\"and\"");
				any_checkbox = new XVar("value=\"or\"");
				if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchtype")] == "or")
				{
					any_checkbox = MVCFunctions.Concat(any_checkbox, " checked");
				}
				else
				{
					all_checkbox = MVCFunctions.Concat(all_checkbox, " checked");
				}
				xt.assign(new XVar("any_checkbox"), (XVar)(any_checkbox));
				xt.assign(new XVar("all_checkbox"), (XVar)(all_checkbox));
				editformats = XVar.Clone(XVar.Array());
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchopt")])))))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchopt")] = XVar.Array();
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchnot")])))))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchnot")] = XVar.Array();
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor")])))))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor")] = XVar.Array();
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")])))))
				{
					XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")] = XVar.Array();
				}
				aGroupFields = XVar.Clone(XVar.Array());
				ngFieldNames = XVar.Clone(XVar.Array());
				arr_page_order_fields = XVar.Clone(XVar.Array());
				arr_page_order_fields.InitAndSetArrayItem(XVar.Array(), "data");
				arr_not_group_fields = XVar.Clone(XVar.Array());
				i = new XVar(0);
				for(;i < CommonFunctions.pre8count((XVar)(xml_array["group_fields"])) - 1; i++)
				{
					aGroupFields.InitAndSetArrayItem(MVCFunctions.Concat(xml_array["tables"][0], "_", xml_array["group_fields"][i]["name"]), null);
				}
				aTotFields = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> fld in inspect_fields.GetEnumerator())
				{
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						fld_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(fld.Value["table"], ".", fld.Value["name"]))));
					}
					else
					{
						if(XVar.Pack(CommonFunctions.is_wr_custom()))
						{
							fld_type = XVar.Clone(CommonFunctions.WRCustomGetFieldType((XVar)(fld.Value["table"]), (XVar)(fld.Value["name"])));
						}
						else
						{
							fld_type = XVar.Clone(CommonFunctions.GetFieldType((XVar)(fld.Value["name"]), (XVar)(fld.Value["table"])));
						}
					}
					if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(fld_type)))))
					{
						aTotFields.InitAndSetArrayItem(MVCFunctions.Concat(fld.Value["table"], "_", fld.Value["name"]), null);
					}
				}
				ngFieldNames = XVar.Clone(MVCFunctions.array_diff((XVar)(aTotFields), (XVar)(aGroupFields)));
				arr_alias = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> gr_name in aGroupFields.GetEnumerator())
				{
					foreach (KeyValuePair<XVar, dynamic> fld in inspect_fields.GetEnumerator())
					{
						if((XVar)(gr_name.Value == MVCFunctions.Concat(fld.Value["table"], "_", fld.Value["name"]))  && (XVar)(!(XVar)(MVCFunctions.in_array((XVar)(MVCFunctions.Concat(fld.Value["table"], "_", fld.Value["name"])), (XVar)(arr_alias)))))
						{
							arr_alias.InitAndSetArrayItem(MVCFunctions.Concat(fld.Value["table"], "_", fld.Value["name"]), null);
							arr_page_order_fields.InitAndSetArrayItem(fld.Value, "data", null);
						}
					}
				}
				foreach (KeyValuePair<XVar, dynamic> fld in inspect_fields.GetEnumerator())
				{
					if(XVar.Pack(MVCFunctions.in_array((XVar)(MVCFunctions.Concat(fld.Value["table"], "_", fld.Value["name"])), (XVar)(ngFieldNames))))
					{
						arr_page_order_fields.InitAndSetArrayItem(fld.Value, "data", null);
						if(fld.Value["show"] == "true")
						{
							arr_not_group_fields.InitAndSetArrayItem(fld.Value, null);
						}
					}
				}
				arr_alias = XVar.Clone(XVar.Array());
				arr_unset = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> value in arr_page_order_fields["data"].GetEnumerator())
				{
					dynamic arr_options = XVar.Array(), editcont = null, editcont1 = XVar.Array(), fname = null, ftable = null, gname = null, gtable = null, opt = null, options = null, parameters = XVar.Array(), searchtype = null, table_field = null, var_not = null;
					ftable = XVar.Clone(arr_page_order_fields["data"][value.Key]["table"]);
					gtable = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(ftable)));
					fname = XVar.Clone(arr_page_order_fields["data"][value.Key]["name"]);
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						table_field = XVar.Clone(MVCFunctions.Concat(ftable, ".", fname));
						gname = XVar.Clone(MVCFunctions.Concat(gtable, "_", MVCFunctions.GoodFieldName((XVar)(fname))));
					}
					else
					{
						table_field = XVar.Clone(fname);
						gname = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(fname)));
					}
					if((XVar)(arr_alias.KeyExists(gname))  || (XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_DATABASE_IMAGE))
					{
						arr_unset.InitAndSetArrayItem(value.Key, null);
						continue;
					}
					else
					{
						arr_alias.InitAndSetArrayItem(1, fname);
					}
					opt = new XVar("");
					var_not = new XVar(false);
					if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_TEXT_AREA)  || (XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_PASSWORD))  || (XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_HIDDEN))  || (XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_READONLY))  || (XVar)(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)) == Constants.EDIT_FORMAT_FILE))
					{
						editformats.InitAndSetArrayItem(Constants.EDIT_FORMAT_TEXT_FIELD, table_field);
					}
					else
					{
						editformats.InitAndSetArrayItem(CommonFunctions.GetGenericEditFormat((XVar)(ftable), (XVar)(fname)), table_field);
					}
					editcont = XVar.Clone(XVar.Array());
					parameters = XVar.Clone(XVar.Array());
					if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_search")] == 2)
					{
						opt = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchopt")][table_field]);
						var_not = XVar.Clone(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchnot")][table_field]);
						parameters.InitAndSetArrayItem(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor")][table_field], "value");
					}
					parameters.InitAndSetArrayItem(table_field, "field");
					parameters.InitAndSetArrayItem("search", "mode");
					parameters.InitAndSetArrayItem(Constants.PAGE_SEARCH, "ptype");
					parameters.InitAndSetArrayItem(editformats[table_field], "format");
					parameters.InitAndSetArrayItem(1, "id");
					parameters.InitAndSetArrayItem(GlobalVars.pageObject, "pageObj");
					editcont = XVar.Clone(XTempl.create_function_assignment(new XVar("xt_buildeditcontrol"), (XVar)(parameters)));
					arr_page_order_fields.InitAndSetArrayItem(editcont, "data", value.Key, "editcontrol");
					editcont1 = XVar.Clone(XVar.Array());
					parameters.InitAndSetArrayItem(true, "second");
					parameters.InitAndSetArrayItem(1, "fieldNum");
					editcont1 = XVar.Clone(XTempl.create_function_assignment(new XVar("xt_buildeditcontrol"), (XVar)(parameters)));
					if(XSession.Session[MVCFunctions.Concat(sessPrefix, "_search")] == 2)
					{
						editcont1.InitAndSetArrayItem(XSession.Session[MVCFunctions.Concat(sessPrefix, "_asearchfor2")][table_field], "params", "value");
					}
					arr_page_order_fields.InitAndSetArrayItem(editcont1, "data", value.Key, "editcontrol1");
					if(XVar.Pack(CommonFunctions.is_wr_db()))
					{
						arr_page_order_fields.InitAndSetArrayItem(MVCFunctions.Concat("\r\n\t\t\t<input type=\"hidden\" name=\"asearchfield[]\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(ftable)), ".", MVCFunctions.runner_htmlspecialchars((XVar)(fname)), "\">\r\n\t\t\t<input type=\"hidden\" name=\"asearchtable[]\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(ftable)), "\">\r\n\t\t"), "data", value.Key, "fieldblock");
					}
					else
					{
						arr_page_order_fields.InitAndSetArrayItem(MVCFunctions.Concat("\r\n\t\t\t<input type=\"hidden\" name=\"asearchfield[]\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(fname)), "\">\r\n\t\t\t<input type=\"hidden\" name=\"asearchtable[]\" value=\"", MVCFunctions.runner_htmlspecialchars((XVar)(ftable)), "\">\r\n\t\t"), "data", value.Key, "fieldblock");
					}
					arr_page_order_fields.InitAndSetArrayItem((XVar.Pack(var_not) ? XVar.Pack(MVCFunctions.Concat("name=\"not_", gname, "_1\" checked")) : XVar.Pack(MVCFunctions.Concat("name=\"not_", gname, "_1\""))), "data", value.Key, "notbox");
					arr_page_order_fields.InitAndSetArrayItem(MVCFunctions.Concat("id=\"second_", gname, "\""), "data", value.Key, "second_id");
					arr_options = XVar.Clone(CommonFunctions.GetAdvSearchOptions((XVar)(ftable), (XVar)(fname)));
					options = new XVar("");
					foreach (KeyValuePair<XVar, dynamic> arr_opt in arr_options.GetEnumerator())
					{
						options = MVCFunctions.Concat(options, "<option value=\"", arr_opt.Value["type"], "\" ", (XVar.Pack(opt == arr_opt.Value["type"]) ? XVar.Pack("selected") : XVar.Pack("")), ">", arr_opt.Value["label"], "</option>");
					}
					searchtype = XVar.Clone(MVCFunctions.Concat("<select id=\"SearchOption\" name=\"asearchopt_", gname, "_1\" size=\"1\" onchange=\"return ShowHideControls();\">"));
					searchtype = MVCFunctions.Concat(searchtype, options);
					searchtype = MVCFunctions.Concat(searchtype, "</select>");
					arr_page_order_fields.InitAndSetArrayItem(searchtype, "data", value.Key, "searchtype");
				}
				foreach (KeyValuePair<XVar, dynamic> val in arr_unset.GetEnumerator())
				{
					arr_page_order_fields["data"].Remove(val.Value);
				}
				xt.assignbyref(new XVar("page_order_fields"), (XVar)(arr_page_order_fields));
				body = XVar.Clone(XVar.Array());
				body.InitAndSetArrayItem(includes, "begin");
				jscode = MVCFunctions.Concat(jscode, "ShowHideControls();");
				body.InitAndSetArrayItem(MVCFunctions.Concat("<script type=\"text/javascript\">", jscode, "</script>"), "end");
				xt.assignbyref(new XVar("body"), (XVar)(body));
				contents_block = XVar.Clone(XVar.Array());
				contents_block.InitAndSetArrayItem("<form method=\"POST\" ", "begin");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("rname"))))
				{
					dynamic crossAttr = null;
					crossAttr = new XVar("");
					if(MVCFunctions.postvalue(new XVar("axis_x")) != "")
					{
						crossAttr = XVar.Clone(MVCFunctions.Concat("&axis_x=", MVCFunctions.postvalue(new XVar("axis_x")), "&axis_y=", MVCFunctions.postvalue(new XVar("axis_y")), "&field=", MVCFunctions.postvalue(new XVar("field")), "&group_func=", MVCFunctions.postvalue(new XVar("group_func"))));
					}
					contents_block["begin"] = MVCFunctions.Concat(contents_block["begin"], "action=\"", MVCFunctions.GetTableLink(new XVar("dreport")), "?rname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(MVCFunctions.postvalue(new XVar("rname")))))), crossAttr, "\" ");
				}
				else
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("cname"))))
					{
						contents_block["begin"] = MVCFunctions.Concat(contents_block["begin"], "action=\"", MVCFunctions.GetTableLink(new XVar("dchart")), "?cname=", MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.RawUrlEncode((XVar)(MVCFunctions.postvalue(new XVar("cname")))))), "\" ");
					}
				}
				contents_block["begin"] = MVCFunctions.Concat(contents_block["begin"], "name=\"editform\"><input type=\"hidden\" id=\"a\" name=\"a\" value=\"advsearch\">");
				contents_block.InitAndSetArrayItem("</form>", "end");
				xt.assignbyref(new XVar("contents_block"), (XVar)(contents_block));
				xt.assign(new XVar("searchbutton_attrs"), new XVar("name=\"SearchButton\" onclick=\"document.forms.editform.submit();\""));
				xt.assign(new XVar("resetbutton_attrs"), new XVar("onclick=\"return ResetControls();\""));
				xt.assign(new XVar("backbutton_attrs"), new XVar("onclick=\"document.forms.editform.a.value='return'; document.forms.editform.submit();\""));
				xt.assign(new XVar("conditions_block"), new XVar(true));
				xt.assign(new XVar("search_button"), new XVar(true));
				xt.assign(new XVar("reset_button"), new XVar(true));
				xt.assign(new XVar("back_button"), new XVar(true));
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("dynamic"), new XVar("true"));
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("rname"))))
				{
					xt.assign(new XVar("rname"), (XVar)(MVCFunctions.postvalue(new XVar("rname"))));
				}
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("cname"))))
				{
					xt.assign(new XVar("cname"), (XVar)(MVCFunctions.postvalue(new XVar("cname"))));
				}
				templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("dsearch")));
				xt.assign(new XVar("reportTitle"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(xml_array["settings"]["title"]))));
				xt.display((XVar)(templatefile));
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
