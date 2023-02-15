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
		public ActionResult session_expired()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				CommonFunctions.add_nocache_headers();
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(Constants.PAGE_SESSION_EXPIRED, "pageType");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "tName");
				var_params.InitAndSetArrayItem(SessionExpiredPage.readExpiredModeFromRequest(), "mode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("sessionControl")), "sessionControl");
				GlobalVars.pageObject = XVar.Clone(new SessionExpiredPage((XVar)(var_params)));
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
