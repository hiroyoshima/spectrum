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
	public partial class admin_membersController : BaseController
	{
		public ActionResult list()
		{
			try
			{
				dynamic options = XVar.Array(), pageObject = null;
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				admin_members_Variables.Apply();
				if(XVar.Pack(!(XVar)(Security.processAdminPageSecurity(new XVar(false)))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				xt = XVar.UnPackXTempl(new XTempl());
				options = XVar.Clone(XVar.Array());
				options.InitAndSetArrayItem(Constants.PAGE_ADMIN_MEMBERS, "pageType");
				options.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				options.InitAndSetArrayItem(Constants.MEMBERS_PAGE, "mode");
				options.InitAndSetArrayItem(xt, "xt");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				options.InitAndSetArrayItem(Constants.stDB, "providerType");
				GlobalVars.pageObject = XVar.Clone(ListPage.createListPage((XVar)(GlobalVars.strTableName), (XVar)(options)));
				if(MVCFunctions.postvalue(new XVar("a")) == "saveMembers")
				{
					dynamic modifiedMembers = null;
					if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					modifiedMembers = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("values")))));
					GlobalVars.pageObject.saveMembers((XVar)(modifiedMembers));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.prepareForBuildPage();
				GlobalVars.pageObject.showPage();
				ViewBag.xt = xt;
				return View(xt.GetViewPath());
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
