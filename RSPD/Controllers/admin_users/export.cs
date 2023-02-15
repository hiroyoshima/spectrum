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
	public partial class admin_usersController : BaseController
	{
		public ActionResult export()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				admin_users_Variables.Apply();
				if(XVar.Pack(Security.hasLogin()))
				{
					dynamic strtablename = null;
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(strtablename), new XVar("P")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(Constants.PAGE_EXPORT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("exportFields")), "selectedFields");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("type")), "exportType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("records")) == "all", "allPagesMode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("records")) == "page", "currentPageMode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("selection")), "selection");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("delimiter")), "csvDelimiter");
				if(MVCFunctions.postvalue(new XVar("txtformatting")) == "raw")
				{
					var_params.InitAndSetArrayItem(true, "useRawValues");
				}
				var_params.InitAndSetArrayItem(ExportPage.readModeFromRequest(), "mode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				GlobalVars.pageObject = XVar.Clone(new ExportPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
