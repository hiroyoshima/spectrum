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
		public ActionResult print()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				if((XVar)(MVCFunctions.postvalue("format") != "excel")  && (XVar)(MVCFunctions.postvalue("format") != "word"))
				{
					CommonFunctions.add_nocache_headers();
				}
				fas_report_Variables.Apply();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("P")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem((XVar.Pack(MVCFunctions.postvalue(new XVar("pdfjson"))) ? XVar.Pack(Constants.PRINT_PDFJSON) : XVar.Pack(Constants.REPORT_SIMPLE)), "mode");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(Constants.PAGE_RPRINT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("all")), "allPagesMode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pdf")), "pdfMode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("format")), "format");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("records")), "splitByGroups");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("x")), "x");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("y")), "y");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("data")), "dataField");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("op")), "operation");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("xtype")), "xType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("ytype")), "yType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pdfBackgroundImage")), "pdfBackgroundImage");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				GlobalVars.pageObject = XVar.Clone(new ReportPrintPage((XVar)(var_params)));
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
