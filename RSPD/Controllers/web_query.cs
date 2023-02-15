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
		public ActionResult web_query()
		{
			try
			{
				dynamic arr_tables = XVar.Array(), b_includes = null, data = XVar.Array(), errstr = null, num_rows = null, qResult = null, res_body = null, res_error = null, res_head = null, result = null, sql_query = null, sql_query_all = null, sql_query_display = null, templatefile = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				xt = XVar.UnPackXTempl(new XTempl());
				GlobalVars.gSettings = new XVar(null);
				res_head = new XVar("");
				res_body = new XVar("");
				res_error = new XVar("");
				if((XVar)((XVar)((XVar)(!(XVar)(CommonFunctions.is_wr_custom()))  || (XVar)(!(XVar)(CommonFunctions.isWRAdmin())))  || (XVar)(!(XVar)(MVCFunctions.postvalue(new XVar("sql")))))  && (XVar)(MVCFunctions.postvalue(new XVar("sql")) != "add"))
				{
					dynamic var_type = null;
					var_type = XVar.Clone((XVar.Pack(MVCFunctions.postvalue(new XVar("type")) == "webcharts") ? XVar.Pack("webcharts") : XVar.Pack("webreports")));
					b_includes = new XVar("<script>");
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(document).ready(function(){\r\n\t\t$(\"#sql_button\").hide();\r\n\t\t");
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#sql_name\").hide();\r\n\t\t$(\"#check_button\").hide();\r\n\t\t$(\"#sql_textarea\").attr(\"readonly\",\"readonly\");\r\n\t});\r\n\t");
					b_includes = MVCFunctions.Concat(b_includes, "</script>");
					xt.assign(new XVar("b_includes"), (XVar)(b_includes));
					if(XVar.Pack(CommonFunctions.is_wr_project()))
					{
						if(var_type == "webreports")
						{
							arr_tables = XVar.Clone(CommonFunctions.getReportTablesList());
						}
						else
						{
							arr_tables = XVar.Clone(CommonFunctions.getChartTablesList());
						}
						foreach (KeyValuePair<XVar, dynamic> _tbl in arr_tables.GetEnumerator())
						{
							Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", CommonFunctions.GetTableURL((XVar)(_tbl.Value)), ""),
								"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
						}
						GlobalVars.gSettings = XVar.Clone(new ProjectSettings((XVar)(arr_tables[0]), new XVar(Constants.PAGE_REPORT)));
					}
					else
					{
						GlobalVars.gSettings = XVar.Clone(new ProjectSettings((XVar)(GlobalVars.strTableName), new XVar(Constants.PAGE_REPORT)));
					}
					if(XVar.Pack(!(XVar)(CommonFunctions.is_wr_project())))
					{
						dynamic order_by = null;
						sql_query_display = XVar.Clone(MVCFunctions.Concat(XSession.Session[var_type]["sql"], XSession.Session[var_type]["where"], XSession.Session[var_type]["group_by"], XSession.Session[var_type]["order_by"]));
						if(XVar.Pack(MVCFunctions.strlen((XVar)(XSession.Session[var_type]["sql_preview"]))))
						{
							sql_query = XVar.Clone(XSession.Session[var_type]["sql_preview"]);
						}
						else
						{
							sql_query = XVar.Clone(XSession.Session[var_type]["sql"]);
						}
						if(XVar.Pack(MVCFunctions.strlen((XVar)(XSession.Session[var_type]["order_by_preview"]))))
						{
							order_by = XVar.Clone(XSession.Session[var_type]["order_by_preview"]);
						}
						else
						{
							order_by = XVar.Clone(XSession.Session[var_type]["order_by"]);
						}
						sql_query = MVCFunctions.Concat(sql_query, XSession.Session[var_type]["where"], XSession.Session[var_type]["group_by"], order_by);
						sql_query_display = XVar.Clone(sql_query);
					}
					else
					{
						dynamic gstrSQL = null;
						SQLQuery gQuery;
						gQuery = XVar.UnPackSQLQuery(GlobalVars.gSettings.getSQLQuery());
						gstrSQL = XVar.Clone(gQuery.gSQLWhere(new XVar("")));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar("select "), new XVar(MVCFunctions.Concat("\n", "select ")), (XVar)(gstrSQL)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" from "), new XVar(MVCFunctions.Concat("\n", "from ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" inner "), new XVar(MVCFunctions.Concat("\n", "inner ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" right "), new XVar(MVCFunctions.Concat("\n", "right ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" full "), new XVar(MVCFunctions.Concat("\n", "full ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" where "), new XVar(MVCFunctions.Concat("\n", "where ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" order by "), new XVar(MVCFunctions.Concat("\n", "order by ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" group by "), new XVar(MVCFunctions.Concat("\n", "group by ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar("SELECT "), new XVar(MVCFunctions.Concat("\n", "SELECT ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" FROM "), new XVar(MVCFunctions.Concat("\n", "FROM ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" INNER "), new XVar(MVCFunctions.Concat("\n", "INNER ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar("RIGHT "), new XVar(MVCFunctions.Concat("\n", "RIGHT ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" FULL "), new XVar(MVCFunctions.Concat("\n", "FULL ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" WHERE "), new XVar(MVCFunctions.Concat("\n", "WHERE ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" ORDER BY "), new XVar(MVCFunctions.Concat("\n", "ORDER BY ")), (XVar)(sql_query)));
						sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar(" GROUP BY "), new XVar(MVCFunctions.Concat("\n", "GROUP BY ")), (XVar)(sql_query)));
						sql_query_display = XVar.Clone(sql_query);
					}
					xt.assign(new XVar("sql_query"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(sql_query_display))));
				}
				else
				{
					dynamic page = null;
					XSession.Session.InitAndSetArrayItem("custom", "webobject", "table_type");
					page = XVar.Clone((XVar.Pack(MVCFunctions.postvalue(new XVar("type")) == "webcharts") ? XVar.Pack(MVCFunctions.GetTableLink(new XVar("webchart0"))) : XVar.Pack(MVCFunctions.GetTableLink(new XVar("webreport0")))));
					sql_query_display = XVar.Clone(XSession.Session["customSQL"]);
					sql_query = XVar.Clone(XSession.Session["customSQL"]);
					if(MVCFunctions.postvalue(new XVar("sql")) == "add")
					{
						dynamic _connection = null, prefix = null, sname = null, sql = null;
						_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
						sname = new XVar("Query");
						prefix = new XVar(0);
						while(XVar.Pack(true))
						{
							if(XVar.Pack(0) < prefix)
							{
								sname = XVar.Clone(MVCFunctions.Concat("Query_", prefix));
							}
							sql = XVar.Clone(MVCFunctions.Concat("select count(*) from ", _connection.addTableWrappers(new XVar("webreport_sql")), " where ", _connection.addFieldWrappers(new XVar("sqlname")), "=", _connection.prepareString((XVar)(sname))));
							data = XVar.Clone(_connection.query((XVar)(sql)).fetchNumeric());
							if(0 < data[0])
							{
								prefix++;
							}
							else
							{
								break;
							}
						}
						XSession.Session["idSQL"] = "";
						XSession.Session["nameSQL"] = sname;
						XSession.Session["customSQL"] = "";
						sql_query_display = new XVar("");
						sql_query = new XVar("");
					}
					else
					{
						if(MVCFunctions.postvalue(new XVar("sql")) == "makesql")
						{
							sql_query_display = XVar.Clone(MVCFunctions.postvalue(new XVar("output")));
							sql_query = XVar.Clone(MVCFunctions.postvalue(new XVar("output")));
						}
					}
					b_includes = new XVar("<script>");
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t$(document).ready(function(){");
					b_includes = MVCFunctions.Concat(b_includes, CommonFunctions.alertDialog());
					b_includes = MVCFunctions.Concat(b_includes, "\r\n\t\t$(\"#cancel_sql\").click(function(){\r\n\t\t\twindow.parent.$.fancybox.close();\r\n\t\t});\r\n\t\t$(\"#save_sql\").click(function(){\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("save-admin")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tname: \"sqledit\",\r\n\t\t\t\t\tsqlcontent: $(\"#sql_textarea\").val(),\r\n\t\t\t\t\tnamesql: $(\"#sql_name\").val(),\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg){\r\n\t\t\t\t\tif ( msg == \"OK\" ) {\r\n\t\t\t\t\t\twindow.parent.$.fancybox.close();");
					if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("page")))))
					{
						b_includes = MVCFunctions.Concat(b_includes, "if(!$(\"#go_permiss\").attr(\"checked\"))\r\n\t\t\t\t\t\t\twindow.parent.location.href=\"", MVCFunctions.GetTableLink(new XVar("webreport_sql")), "?name=\"+$(\"#sql_name\").val();\r\n\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\twindow.parent.location.href=\"", MVCFunctions.GetTableLink(new XVar("webreport_admin")), "?username=", MVCFunctions.RawUrlEncode((XVar)(Security.getUserName())), "&queryname=\"+$(\"#sql_name\").val();");
					}
					else
					{
						b_includes = MVCFunctions.Concat(b_includes, "window.parent.location.href=\"", page, "?sqlname=\"+$(\"#sql_name\").val();");
					}
					b_includes = MVCFunctions.Concat(b_includes, "} else {\r\n\t\t\t\t\t\t$(\"#alert\").html(\"<p>\"+msg+\"</p>\")\r\n\t\t\t\t\t\t.dialog(\"option\", \"buttons\", {\"OK\": function() { $(this).dialog(\"close\");}})\r\n\t\t\t\t\t\t.dialog(\"open\");\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t});\r\n\t\t$(\"#view_sql\").click(function(){\r\n\t\t\t$(\"#table-container\").html(\"\");\r\n\t\t\t$.ajax({\r\n\t\t\t\ttype: \"POST\",\r\n\t\t\t\turl: \"", MVCFunctions.GetTableLink(new XVar("web_query")), "\",\r\n\t\t\t\tdata: {\r\n\t\t\t\t\tsql: \"makesql\",\r\n\t\t\t\t\toutput: $(\"#sql_textarea\").val(),\r\n\t\t\t\t\trnd: (new Date().getTime())\r\n\t\t\t\t},\r\n\t\t\t\tsuccess: function(msg)\r\n\t\t\t\t{\r\n\t\t\t\t\t$(\"#table-container\").html(msg);\r\n\t\t\t\t}\r\n\t\t\t});\r\n\t\t});");
					if(MVCFunctions.postvalue(new XVar("sql")) == "result")
					{
						b_includes = MVCFunctions.Concat(b_includes, "$(\"#view_sql\").click();");
					}
					if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("check")))))
					{
						b_includes = MVCFunctions.Concat(b_includes, "$(\"#check_button\").hide();");
					}
					b_includes = MVCFunctions.Concat(b_includes, "});");
					b_includes = MVCFunctions.Concat(b_includes, "$(\"#sql_button\").show();");
					b_includes = MVCFunctions.Concat(b_includes, "</script>");
					xt.assign(new XVar("b_includes"), (XVar)(b_includes));
					xt.assign(new XVar("sql_name"), (XVar)(XSession.Session["nameSQL"]));
				}
				xt.assign(new XVar("wr_pagestylepath"), (XVar)(GlobalVars.wr_pagestylepath));
				xt.assign(new XVar("sql_query"), (XVar)(MVCFunctions.runner_htmlspecialchars((XVar)(sql_query_display))));
				sql_query_all = XVar.Clone(sql_query);
				XSession.Session["object_sql"] = sql_query;
				GlobalVars.conn = XVar.Clone(GlobalVars.cman.getForWebReports());
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					GlobalVars.conn = XVar.Clone(GlobalVars.cman.byTable((XVar)(arr_tables[0])));
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.IsStoredProcedure((XVar)(sql_query)))))
				{
					if(GlobalVars.conn.dbType == Constants.nDATABASE_MSSQLServer)
					{
						dynamic pos = null;
						pos = XVar.Clone(MVCFunctions.strrpos((XVar)(MVCFunctions.strtoupper((XVar)(sql_query_all))), new XVar("ORDER BY")));
						if(XVar.Pack(pos))
						{
							sql_query_all = XVar.Clone(MVCFunctions.substr((XVar)(sql_query_all), new XVar(0), (XVar)(pos)));
						}
					}
					if(XVar.Pack(sql_query))
					{
						if(GlobalVars.conn.dbType == Constants.nDATABASE_MySQL)
						{
							if(XVar.Pack(!(XVar)(MVCFunctions.strpos((XVar)(MVCFunctions.strtolower((XVar)(sql_query))), new XVar(" limit ")))))
							{
								sql_query = MVCFunctions.Concat(sql_query, " LIMIT 50");
							}
						}
						else
						{
							if((XVar)(GlobalVars.conn.dbType == Constants.nDATABASE_MSSQLServer)  || (XVar)(GlobalVars.conn.dbType == Constants.nDATABASE_Access))
							{
								if(XVar.Pack(!(XVar)(MVCFunctions.strpos((XVar)(MVCFunctions.strtolower((XVar)(sql_query))), new XVar(" distinct ")))))
								{
									if(XVar.Pack(!(XVar)(MVCFunctions.strpos((XVar)(MVCFunctions.strtolower((XVar)(sql_query))), new XVar(" top ")))))
									{
										sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar("SELECT"), new XVar("SELECT TOP 50"), (XVar)(MVCFunctions.strtoupper((XVar)(sql_query)))));
									}
								}
								else
								{
									if(XVar.Pack(!(XVar)(MVCFunctions.strpos((XVar)(MVCFunctions.strtolower((XVar)(sql_query))), new XVar(" top ")))))
									{
										sql_query = XVar.Clone(MVCFunctions.str_replace(new XVar("SELECT DISTINCT"), new XVar("SELECT DISTINCT TOP 50"), (XVar)(MVCFunctions.strtoupper((XVar)(sql_query)))));
									}
								}
							}
							else
							{
								if(GlobalVars.conn.dbType == Constants.nDATABASE_Oracle)
								{
								}
								else
								{
									if(GlobalVars.conn.dbType == Constants.nDATABASE_PostgreSQL)
									{
									}
								}
							}
						}
					}
				}
				num_rows = new XVar(50);
				errstr = new XVar("");
				if(XVar.Pack(sql_query))
				{
					qResult = XVar.Clone(GlobalVars.conn.query((XVar)(sql_query)));
					data = XVar.Clone(qResult.fetchAssoc());
				}
				if((XVar)(!(XVar)(data))  || (XVar)(!(XVar)(sql_query)))
				{
					if((XVar)(GlobalVars.conn.dbType == Constants.nDATABASE_Oracle)  && (XVar)(!(XVar)(sql_query)))
					{
						errstr = new XVar("Query was empty");
					}
					if(MVCFunctions.postvalue(new XVar("sql")) != "makesql")
					{
						xt.assign(new XVar("sql_error_block"), new XVar(true));
						xt.assign(new XVar("sql_error"), (XVar)(errstr));
					}
					else
					{
						result = XVar.Clone(errstr);
					}
				}
				else
				{
					dynamic firstTime = null, i = null, total_rows = null;
					firstTime = new XVar(true);
					i = new XVar(0);
					GlobalVars.fields_type = XVar.Clone(XVar.Array());
					if(XVar.Pack(CommonFunctions.is_wr_custom()))
					{
						GlobalVars.fields_type = XVar.Clone(CommonFunctions.WRGetAllCustomFieldType());
					}
					while((XVar)(i < num_rows)  && (XVar)(data))
					{
						i++;
						if(XVar.Pack(firstTime))
						{
							foreach (KeyValuePair<XVar, dynamic> key in MVCFunctions.array_keys((XVar)(data)).GetEnumerator())
							{
								dynamic gKey = null;
								if(XVar.Pack(CommonFunctions.is_wr_project()))
								{
									if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(GlobalVars.gSettings.getFieldType((XVar)(key.Value))))))
									{
										continue;
									}
								}
								else
								{
									if(XVar.Pack(CommonFunctions.is_wr_custom()))
									{
										if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(GlobalVars.fields_type[key.Value]))))
										{
											continue;
										}
									}
								}
								if(XVar.Pack(GlobalVars.gSettings))
								{
									gKey = XVar.Clone(GlobalVars.gSettings.label((XVar)(key.Value)));
								}
								else
								{
									gKey = XVar.Clone(key.Value);
								}
								res_head = MVCFunctions.Concat(res_head, "<th>", MVCFunctions.runner_htmlspecialchars((XVar)(gKey)), "</th>");
							}
						}
						res_body = MVCFunctions.Concat(res_body, "<tr>");
						foreach (KeyValuePair<XVar, dynamic> val in data.GetEnumerator())
						{
							dynamic s = null;
							if(XVar.Pack(CommonFunctions.is_wr_project()))
							{
								if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(GlobalVars.gSettings.getFieldType((XVar)(val.Key))))))
								{
									continue;
								}
							}
							else
							{
								if(XVar.Pack(CommonFunctions.is_wr_custom()))
								{
									if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(GlobalVars.fields_type[val.Key]))))
									{
										continue;
									}
								}
								else
								{
									if(XVar.Pack(MVCFunctions.is_array((XVar)(val.Value))))
									{
										res_body = MVCFunctions.Concat(res_body, "<td><span></span></td>");
										continue;
									}
								}
							}
							s = XVar.Clone(val.Value);
							if(100 < MVCFunctions.strlen((XVar)(s)))
							{
								s = XVar.Clone(MVCFunctions.substr((XVar)(s), new XVar(0), new XVar(100)));
							}
							res_body = MVCFunctions.Concat(res_body, "<td><span>", MVCFunctions.runner_htmlspecialchars((XVar)(s)), "</span></td>");
						}
						res_body = MVCFunctions.Concat(res_body, "</tr>");
						data = XVar.Clone(qResult.fetchAssoc());
						firstTime = new XVar(false);
					}
					if(XVar.Pack(!(XVar)(CommonFunctions.IsStoredProcedure((XVar)(sql_query_all)))))
					{
						dynamic rs = null;
						if(GlobalVars.conn.dbType != Constants.nDATABASE_Oracle)
						{
							rs = XVar.Clone(GlobalVars.conn.query((XVar)(MVCFunctions.Concat("select count(*) from (", sql_query_all, ") as t"))).fetchNumeric());
						}
						else
						{
							rs = XVar.Clone(GlobalVars.conn.query((XVar)(MVCFunctions.Concat("select count(*) from (", sql_query_all, ")"))).fetchNumeric());
						}
						total_rows = new XVar(0);
						if(XVar.Pack(data = XVar.Clone(rs)))
						{
							total_rows = XVar.Clone(data[0]);
						}
					}
					if(XVar.Pack(0) < i)
					{
						if(XVar.Pack(!(XVar)(CommonFunctions.IsStoredProcedure((XVar)(sql_query)))))
						{
							if(MVCFunctions.postvalue(new XVar("sql")) == "makesql")
							{
								result = XVar.Clone(MVCFunctions.Concat("<div><b>", total_rows, "</b> records"));
								if(50 < total_rows)
								{
									result = MVCFunctions.Concat(result, " (displaying first 50)");
								}
								result = MVCFunctions.Concat(result, "</div>");
								result = MVCFunctions.Concat(result, "<table class=\"sql_result\" cellpadding=\"1\" cellspacing=\"1\" border=\"0\">");
								result = MVCFunctions.Concat(result, "<tr><thead><tr>", res_head, "</tr></thead>");
								result = MVCFunctions.Concat(result, "<tbody>", res_body, "</tbody>");
								result = MVCFunctions.Concat(result, "</tr></table>");
							}
							else
							{
								xt.assign(new XVar("res_head"), (XVar)(res_head));
								xt.assign(new XVar("res_body"), (XVar)(res_body));
								xt.assign(new XVar("sql_result_block"), new XVar(true));
								xt.assign(new XVar("total_count"), (XVar)(total_rows));
								if(50 < total_rows)
								{
									xt.assign(new XVar("first_rec"), new XVar(true));
								}
							}
						}
						else
						{
							if(MVCFunctions.postvalue(new XVar("sql")) == "makesql")
							{
								result = new XVar("<div>");
								if(i < 50)
								{
									result = MVCFunctions.Concat(result, "<b>", i, "</b> records");
								}
								else
								{
									result = MVCFunctions.Concat(result, "Displaying first 50 records");
								}
								result = MVCFunctions.Concat(result, "</div>");
								result = MVCFunctions.Concat(result, "<table class=\"sql_result\" cellpadding=\"1\" cellspacing=\"1\" border=\"0\">");
								result = MVCFunctions.Concat(result, "<tr><thead><tr>", res_head, "</tr></thead>");
								result = MVCFunctions.Concat(result, "<tbody>", res_body, "</tbody>");
								result = MVCFunctions.Concat(result, "</tr></table>");
							}
							else
							{
								total_rows = XVar.Clone(i);
								xt.assign(new XVar("res_head"), (XVar)(res_head));
								xt.assign(new XVar("res_body"), (XVar)(res_body));
								xt.assign(new XVar("sql_result_block"), new XVar(true));
								xt.assign(new XVar("total_count"), (XVar)(total_rows));
							}
						}
					}
					else
					{
						xt.assign(new XVar("sql_message_block"), new XVar(true));
						result = new XVar("<p>No records to display</p>");
					}
				}
				if(MVCFunctions.postvalue(new XVar("sql")) == "makesql")
				{
					MVCFunctions.Echo(result);
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				else
				{
					templatefile = XVar.Clone(MVCFunctions.GetTemplateName(new XVar(""), new XVar("web_query")));
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
