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
	public partial class fas_reportController : BaseController
	{
		public ActionResult report()
		{
			try
			{
				dynamic pageMode = null, pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("FAS Report");
				GlobalVars.requestPage = new XVar("list");
				GlobalVars.init_dbcommon();
				CommonFunctions.add_nocache_headers();
				fas_report_Variables.Apply();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("S")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				pageMode = XVar.Clone(ReportPage.readReportModeFromRequest());
				xt = XVar.UnPackXTempl(new XTempl((XVar)(pageMode != Constants.REPORT_SIMPLE)));
				GlobalVars.gSettings = XVar.Clone(new ProjectSettings((XVar)(GlobalVars.strTableName)));
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(pageMode, "mode");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(Constants.PAGE_REPORT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(GlobalVars.gSettings.getRecordsPerPageArray(), "arrRecsPerPage");
				var_params.InitAndSetArrayItem(GlobalVars.gSettings.getGroupsPerPageArray(), "arrGroupsPerPage");
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("x")), "x");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("y")), "y");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("data")), "dataField");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("op")), "operation");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("xtype")), "xType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("ytype")), "yType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("axis")), "selectedAxis");
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("crosstable_refresh"))))
				{
					var_params.InitAndSetArrayItem(true, "crosstableRefresh");
				}
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterpagetype")), "masterPageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				if(XVar.Pack(pageMode = new XVar(Constants.REPORT_DASHBOARD)))
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				GlobalVars.pageObject = XVar.Clone(new ReportPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				if(XVar.Pack(GlobalVars.pageObject.processSaveSearch()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.process();
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
