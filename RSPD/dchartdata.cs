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
		public XVar dchartdata()
		{
			try
			{
				dynamic chartObj = null, chrt_array = XVar.Array(), chrt_strXML = null, param = XVar.Array(), webchart = null, xml = null;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(CommonFunctions.isLogged())))
					{
						Security.saveRedirectURL();
						MVCFunctions.HeaderRedirect(new XVar("login"), new XVar(""), new XVar("message=expired"));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xml = XVar.Clone(new xml());
				chrt_strXML = new XVar("");
				if(XVar.Pack(CommonFunctions.checkTableName((XVar)(MVCFunctions.postvalue(new XVar("chartname"))))))
				{
					Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", MVCFunctions.postvalue(new XVar("chartname")), ""),
						"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
					chrt_strXML = XVar.Clone(CommonFunctions.GetChartXML((XVar)(MVCFunctions.postvalue(new XVar("chartname")))));
					chrt_array = XVar.Clone(xml.xml_to_array((XVar)(chrt_strXML)));
					if(XVar.Pack(!(XVar)(XSession.Session["webobject"])))
					{
						XSession.Session["webobject"] = XVar.Array();
					}
					XSession.Session.InitAndSetArrayItem("project", "webobject", "table_type");
					XSession.Session["object_sql"] = "";
				}
				webchart = new XVar(false);
				if(XVar.Pack(!(XVar)(chrt_strXML)))
				{
					dynamic sessPrefix = null;
					sessPrefix = XVar.Clone(MVCFunctions.Concat("webchart", MVCFunctions.postvalue(new XVar("cname"))));
					chrt_strXML = XVar.Clone(CommonFunctions.wrLoadSelectedEntity((XVar)(MVCFunctions.postvalue(new XVar("cname"))), new XVar(Constants.WR_CHART)));
					webchart = new XVar(true);
					chrt_array = XVar.Clone(xml.xml_to_array((XVar)(chrt_strXML)));
					if(XVar.Pack(CommonFunctions.is_wr_project()))
					{
						Assembly.GetExecutingAssembly().GetType(MVCFunctions.Concat("runnerDotNet.", MVCFunctions.Concat("", chrt_array["settings"]["short_table_name"], ""),
							"_Variables")).InvokeMember("Apply", BindingFlags.InvokeMethod, null, null, null);
					}
				}
				param = XVar.Clone(XVar.Array());
				param.InitAndSetArrayItem(webchart, "webchart");
				param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("showDetails")), "showDetails");
				param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("chartPreview")), "chartPreview");
				param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashChart")), "dashChart");
				param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pageId")), "pageId");
				param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(param["masterTable"]))
				{
					param.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				if(XVar.Pack(param["dashChart"]))
				{
					dynamic var_params = XVar.Array();
					param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashTName")), "dashTName");
					param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashElName")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				if(XVar.Pack(webchart))
				{
					param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("cname")), "cname");
					switch(((XVar)chrt_array["chart_type"]["type"]).ToString())
					{
						case "3d_column":
							chrt_array.InitAndSetArrayItem("2d_column", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "is3d");
							chrt_array.InitAndSetArrayItem("false", "appearance", "isstacked");
							break;
						case "3d_bar":
							chrt_array.InitAndSetArrayItem("2d_bar", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "is3d");
							chrt_array.InitAndSetArrayItem("false", "appearance", "isstacked");
							break;
						case "3d_column_stacked":
							chrt_array.InitAndSetArrayItem("2d_column", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "is3d");
							chrt_array.InitAndSetArrayItem("true", "appearance", "isstacked");
							break;
						case "3d_bar_stacked":
							chrt_array.InitAndSetArrayItem("2d_bar", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "is3d");
							chrt_array.InitAndSetArrayItem("true", "appearance", "isstacked");
							break;
						case "2d_column_stacked":
							chrt_array.InitAndSetArrayItem("2d_column", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "isstacked");
							chrt_array.InitAndSetArrayItem("false", "appearance", "is3d");
							break;
						case "2d_bar_stacked":
							chrt_array.InitAndSetArrayItem("2d_bar", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "isstacked");
							chrt_array.InitAndSetArrayItem("false", "appearance", "is3d");
							break;
						case "line":
							chrt_array.InitAndSetArrayItem("line", "chart_type", "type");
							if(XVar.Pack(!(XVar)(chrt_array["appearance"].KeyExists("linestyle"))))
							{
								chrt_array.InitAndSetArrayItem(0, "appearance", "linestyle");
							}
							break;
						case "spline":
							chrt_array.InitAndSetArrayItem("line", "chart_type", "type");
							chrt_array.InitAndSetArrayItem(1, "appearance", "linestyle");
							break;
						case "step_line":
							chrt_array.InitAndSetArrayItem("line", "chart_type", "type");
							chrt_array.InitAndSetArrayItem(2, "appearance", "linestyle");
							break;
						case "area_stacked":
							chrt_array.InitAndSetArrayItem("area", "chart_type", "type");
							chrt_array.InitAndSetArrayItem("true", "appearance", "isstacked");
							break;
					}
				}
				else
				{
					param.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("chartname")), "cname");
				}
				if(chrt_array["chart_type"]["type"] == "candle")
				{
					chrt_array.InitAndSetArrayItem("candlestick", "chart_type", "type");
				}
				switch(((XVar)chrt_array["chart_type"]["type"]).ToString())
				{
					case "2d_column":
						param.InitAndSetArrayItem(true, "2d");
						param.InitAndSetArrayItem(false, "bar");
						param.InitAndSetArrayItem(false, "stacked");
						if((XVar)(chrt_array["appearance"]["is3d"] == "true")  || (XVar)(chrt_array["appearance"]["is3d"] == 1))
						{
							param.InitAndSetArrayItem(false, "2d");
						}
						if((XVar)(chrt_array["appearance"]["isstacked"] == "true")  || (XVar)(chrt_array["appearance"]["isstacked"] == 1))
						{
							param.InitAndSetArrayItem(true, "stacked");
						}
						chartObj = XVar.Clone(new Chart_Bar((XVar)(chrt_array), (XVar)(param)));
						break;
					case "2d_bar":
						param.InitAndSetArrayItem(true, "2d");
						param.InitAndSetArrayItem(true, "bar");
						param.InitAndSetArrayItem(false, "stacked");
						if((XVar)(chrt_array["appearance"]["is3d"] == "true")  || (XVar)(chrt_array["appearance"]["is3d"] == 1))
						{
							param.InitAndSetArrayItem(false, "2d");
						}
						if((XVar)(chrt_array["appearance"]["isstacked"] == "true")  || (XVar)(chrt_array["appearance"]["isstacked"] == 1))
						{
							param.InitAndSetArrayItem(true, "stacked");
						}
						chartObj = XVar.Clone(new Chart_Bar((XVar)(chrt_array), (XVar)(param)));
						break;
					case "line":
						if(chrt_array["appearance"]["linestyle"] == 0)
						{
							param.InitAndSetArrayItem("line", "type_line");
						}
						else
						{
							if(chrt_array["appearance"]["linestyle"] == 2)
							{
								param.InitAndSetArrayItem("step_line", "type_line");
							}
							else
							{
								param.InitAndSetArrayItem("spline", "type_line");
							}
						}
						chartObj = XVar.Clone(new Chart_Line((XVar)(chrt_array), (XVar)(param)));
						break;
					case "area":
						param.InitAndSetArrayItem(false, "stacked");
						if((XVar)(chrt_array["appearance"]["isstacked"] == "true")  || (XVar)(chrt_array["appearance"]["isstacked"] == 1))
						{
							param.InitAndSetArrayItem(true, "stacked");
						}
						chartObj = XVar.Clone(new Chart_Area((XVar)(chrt_array), (XVar)(param)));
						break;
					case "2d_pie":
						param.InitAndSetArrayItem(true, "2d");
						if((XVar)(chrt_array["appearance"]["is3d"] == "true")  || (XVar)(chrt_array["appearance"]["is3d"] == 1))
						{
							param.InitAndSetArrayItem(false, "2d");
						}
						param.InitAndSetArrayItem(true, "pie");
						chartObj = XVar.Clone(new Chart_Pie((XVar)(chrt_array), (XVar)(param)));
						break;
					case "2d_doughnut":
						param.InitAndSetArrayItem(false, "pie");
						param.InitAndSetArrayItem(true, "2d");
						if((XVar)(chrt_array["appearance"]["is3d"] == "true")  || (XVar)(chrt_array["appearance"]["is3d"] == 1))
						{
							param.InitAndSetArrayItem(false, "2d");
						}
						chartObj = XVar.Clone(new Chart_Pie((XVar)(chrt_array), (XVar)(param)));
						break;
					case "combined":
						chartObj = XVar.Clone(new Chart_Combined((XVar)(chrt_array), (XVar)(param)));
						break;
					case "funnel":
						param.InitAndSetArrayItem(chrt_array["appearance"]["accumulstyle"], "funnel_type");
						param.InitAndSetArrayItem(false, "funnel_inv");
						if((XVar)(chrt_array["appearance"]["accumulinvert"] == "true")  || (XVar)(chrt_array["appearance"]["accumulinvert"] == 1))
						{
							param.InitAndSetArrayItem(true, "funnel_inv");
						}
						chartObj = XVar.Clone(new Chart_Funnel((XVar)(chrt_array), (XVar)(param)));
						break;
					case "bubble":
						param.InitAndSetArrayItem(true, "2d");
						if((XVar)(chrt_array["appearance"]["is3d"] == "true")  || (XVar)(chrt_array["appearance"]["is3d"] == 1))
						{
							param.InitAndSetArrayItem(false, "2d");
						}
						param.InitAndSetArrayItem(1, "oppos");
						if((XVar)(chrt_array["appearance"]["bubbletransp"] == "true")  || (XVar)(chrt_array["appearance"]["bubbletransp"] == 1))
						{
							param.InitAndSetArrayItem(0.300000, "oppos");
						}
						chartObj = XVar.Clone(new Chart_Bubble((XVar)(chrt_array), (XVar)(param)));
						break;
					case "gauge":
						if(chrt_array["appearance"]["gaugestyle"] == 0)
						{
							param.InitAndSetArrayItem("circular-gauge", "gaugeType");
						}
						else
						{
							param.InitAndSetArrayItem("linear-gauge", "gaugeType");
						}
						if(chrt_array["appearance"]["gaugestyle"] == 1)
						{
							param.InitAndSetArrayItem("horizontal", "layout");
						}
						else
						{
							param.InitAndSetArrayItem("", "layout");
						}
						chartObj = XVar.Clone(new Chart_Gauge((XVar)(chrt_array), (XVar)(param)));
						break;
					case "ohlc":
						param.InitAndSetArrayItem("ohcl", "ohcl_type");
						chartObj = XVar.Clone(new Chart_Ohlc((XVar)(chrt_array), (XVar)(param)));
						break;
					case "candlestick":
						param.InitAndSetArrayItem("candlestick", "ohcl_type");
						chartObj = XVar.Clone(new Chart_Ohlc((XVar)(chrt_array), (XVar)(param)));
						break;
				}
				if(MVCFunctions.postvalue(new XVar("action")) == "refresh")
				{
					MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(chartObj.get_data())));
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				MVCFunctions.Header("Content-Type", "application/json");
				chartObj.write();
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
