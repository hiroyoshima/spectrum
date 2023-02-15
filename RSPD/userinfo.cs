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
		public ActionResult userinfo()
		{
			try
			{
				dynamic id = null, pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(!(XVar)(UserInfoPage.processUserInfoPageSecurity((XVar)(GlobalVars.strTableName)))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				xt = XVar.UnPackXTempl(new XTempl());
				id = XVar.Clone(CommonFunctions.postvalue_number(new XVar("id")));
				id = XVar.Clone((XVar.Pack(MVCFunctions.intval((XVar)(id)) == 0) ? XVar.Pack(1) : XVar.Pack(id)));
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(id, "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(Constants.PAGE_USERINFO, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(Security.loginTable(), "tName");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("a")), "action");
						

				var_params.InitAndSetArrayItem("captcha_1209xre", "captchaName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value_captcha_1209xre_", id))), "captchaValue");
				var_params.InitAndSetArrayItem(UserInfoPage.readPageModeFromRequest(), "mode");
				GlobalVars.pageObject = XVar.Clone(new UserInfoPage((XVar)(var_params)));
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
