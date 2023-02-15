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
		public ActionResult changepwd()
		{
			try
			{
				dynamic pageObject = null, token = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				token = XVar.Clone(MVCFunctions.postvalue(new XVar("token")));
				Security.processLogoutRequest();
				if((XVar)(!(XVar)(token))  && (XVar)((XVar)(!(XVar)(CommonFunctions.isLogged()))  || (XVar)(Security.isGuest())))
				{
					Security.saveRedirectURL();
					MVCFunctions.HeaderRedirect(new XVar("login"), new XVar(""), new XVar("message=expired"));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(token, "token");
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(Security.loginTable(), "tName");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				var_params.InitAndSetArrayItem(Constants.PAGE_CHANGEPASS, "pageType");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				var_params.InitAndSetArrayItem(ChangePasswordPage.readActionFromRequest(), "action");
				var_params.InitAndSetArrayItem(ChangePasswordPage.readModeFromRequest(), "mode");
				GlobalVars.pageObject = XVar.Clone(new ChangePasswordPage((XVar)(var_params)));
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
