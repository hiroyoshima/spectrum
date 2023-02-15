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
		public XVar get_state()
		{
			try
			{
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if((XVar)(MVCFunctions.POSTKeyExists("type"))  && (XVar)(MVCFunctions.POSTKeyExists("web")))
				{
					if(MVCFunctions.postvalue("type") == "new")
					{
						XSession.Session.Remove(MVCFunctions.postvalue("web"));
						XSession.Session[MVCFunctions.postvalue("web")] = XVar.Array();
						XSession.Session.InitAndSetArrayItem("db", MVCFunctions.postvalue("web"), "table_type");
						MVCFunctions.Echo("OK");
					}
					else
					{
						if(MVCFunctions.postvalue("type") == "open")
						{
							dynamic arr = XVar.Array(), arr_reports = XVar.Array(), xml = null;
							xml = XVar.Clone(new xml());
							arr = XVar.Clone(XVar.Array());
							if(MVCFunctions.postvalue("web") == "webreports")
							{
								if(1 < MVCFunctions.count(CommonFunctions.GetUserGroups()))
								{
									arr_reports = XVar.Clone(XVar.Array());
									arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_REPORT)));
									foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
									{
										if((XVar)((XVar)((XVar)(rpt.Value["owner"] != Security.getUserName())  || (XVar)(rpt.Value["owner"] == ""))  && (XVar)(rpt.Value["view"] == 0))  && (XVar)(XSession.Session["webreports"]["settings"]["name"] == rpt.Value["name"]))
										{
											MVCFunctions.Echo(MVCFunctions.Concat("<p>", "You don't have permissions to view this report", "</p>"));
											MVCFunctions.Echo(new XVar(""));
											return MVCFunctions.GetBuferContentAndClearBufer();
										}
									}
								}
								arr = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue("name")), new XVar(Constants.WR_REPORT)));
								if(XVar.Pack(!(XVar)(arr["table_type"])))
								{
									if(XVar.Pack(arr["db_based"]))
									{
										arr.InitAndSetArrayItem("db", "table_type");
									}
									else
									{
										arr.InitAndSetArrayItem("project", "table_type");
									}
								}
								XSession.Session["webreports"] = arr;
								CommonFunctions.update_report_totals();
								XSession.Session.InitAndSetArrayItem(XSession.Session["webreports"]["table_type"], "webobject", "table_type");
								XSession.Session.InitAndSetArrayItem(XSession.Session["webreports"]["settings"]["name"], "webobject", "name");
							}
							else
							{
								if(1 < MVCFunctions.count(CommonFunctions.GetUserGroups()))
								{
									arr_reports = XVar.Clone(XVar.Array());
									arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_CHART)));
									foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
									{
										if((XVar)((XVar)((XVar)(rpt.Value["owner"] != Security.getUserName())  || (XVar)(rpt.Value["owner"] == ""))  && (XVar)(rpt.Value["view"] == 0))  && (XVar)(XSession.Session["webcharts"]["settings"]["name"] == rpt.Value["name"]))
										{
											MVCFunctions.Echo(MVCFunctions.Concat("<p>", "", "</p>"));
											MVCFunctions.Echo(new XVar(""));
											return MVCFunctions.GetBuferContentAndClearBufer();
										}
									}
								}
								arr = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue("name")), new XVar(Constants.WR_CHART)));
								if(XVar.Pack(!(XVar)(arr["table_type"])))
								{
									if(XVar.Pack(arr["db_based"]))
									{
										arr.InitAndSetArrayItem("db", "table_type");
									}
									else
									{
										arr.InitAndSetArrayItem("project", "table_type");
									}
								}
								XSession.Session["webcharts"] = arr;
								XSession.Session["webcharts"] = CommonFunctions.Convert_Old_Chart((XVar)(XSession.Session["webcharts"]));
								XSession.Session.InitAndSetArrayItem(XSession.Session["webcharts"]["table_type"], "webobject", "table_type");
								XSession.Session.InitAndSetArrayItem(XSession.Session["webcharts"]["settings"]["name"], "webobject", "name");
							}
							MVCFunctions.Echo("OK");
						}
					}
					XSession.Session.InitAndSetArrayItem(XSession.Session[MVCFunctions.postvalue("web")]["table_type"], "webobject", "table_type");
				}
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
