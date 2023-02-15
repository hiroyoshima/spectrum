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
	public partial class admin_rightsController : BaseController
	{
		public ActionResult list()
		{
			try
			{
				dynamic mask = null, options = XVar.Array(), pageMask = XVar.Array(), pageObject = null, table = null, tables = XVar.Array();
				XTempl xt;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				admin_rights_Variables.Apply();
				if(XVar.Pack(!(XVar)(Security.processAdminPageSecurity(new XVar(false)))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				tables = XVar.Clone(XVar.Array());
				pageMask = XVar.Clone(XVar.Array());
				table = new XVar("dbo.sysdiagrams");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "sysdiagrams", 1, MVCFunctions.Concat(" ", "Sysdiagrams")), table);
				table = new XVar("dbo.rspdHeader");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "dbo_rspdheader", 1, MVCFunctions.Concat(" ", "RSPD Form")), table);
				table = new XVar("dbo.company");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "dbo_company", 1, MVCFunctions.Concat(" ", "Company")), table);
				table = new XVar("dbo.radioEquipment");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "radioequipment", 1, MVCFunctions.Concat(" ", "Radio Equipment")), table);
				table = new XVar("Dashboard");
				mask = new XVar("");
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "dashboard", 1, MVCFunctions.Concat(" ", "Dashboard")), table);
				table = new XVar("dbo.baranggay");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "baranggay", 1, MVCFunctions.Concat(" ", "Baranggay")), table);
				table = new XVar("dbo.city");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "city", 1, MVCFunctions.Concat(" ", "City")), table);
				table = new XVar("dbo.province");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "province", 1, MVCFunctions.Concat(" ", "Province")), table);
				table = new XVar("FAS Report");
				mask = new XVar("");
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "fas_report", 1, MVCFunctions.Concat(" ", "FAS Report")), table);
				table = new XVar("dbo.spectrum_beta_users");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_beta_users", 1, MVCFunctions.Concat(" ", "Spectrum Beta Users")), table);
				table = new XVar("dbo.stage");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "stage", 1, MVCFunctions.Concat(" ", "Stage")), table);
				table = new XVar("dbo.stageStatus");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "stagestatus", 1, MVCFunctions.Concat(" ", "Stage Status")), table);
				table = new XVar("dbo.spectrum_betauggroups");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_betauggroups", 1, MVCFunctions.Concat(" ", "Spectrum Betauggroups")), table);
				table = new XVar("dbo.spectrum_beta_audit");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_beta_audit", 1, MVCFunctions.Concat(" ", "Spectrum Beta Audit")), table);
				table = new XVar("dbo.spectrum_beta_settings");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_beta_settings", 1, MVCFunctions.Concat(" ", "Spectrum Beta Settings")), table);
				table = new XVar("dbo.spectrum_betaugmembers");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_betaugmembers", 1, MVCFunctions.Concat(" ", "Spectrum Betaugmembers")), table);
				table = new XVar("dbo.spectrum_betaugrights");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "spectrum_betaugrights", 1, MVCFunctions.Concat(" ", "Spectrum Betaugrights")), table);
				table = new XVar("dbo.transactionSetup");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "transactionsetup", 1, MVCFunctions.Concat(" ", "Transaction Setup")), table);
				table = new XVar("dbo.rspd_application_received");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "rspd_application_received", 1, MVCFunctions.Concat(" ", "Rspd Application Received")), table);
				table = new XVar("dbo.applicationsRecieved");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "applicationsrecieved", 1, MVCFunctions.Concat(" ", "Applications Recieved")), table);
				table = new XVar("dbo.branch");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "branch", 1, MVCFunctions.Concat(" ", "Branch")), table);
				table = new XVar("users");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "users", 1, MVCFunctions.Concat(" ", "Users")), table);
				table = new XVar("dbo.classStation");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "classstation", 1, MVCFunctions.Concat(" ", "Class Station")), table);
				table = new XVar("applicationEndorsed");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "applicationendorsed", 1, MVCFunctions.Concat(" ", "Application Endorsed")), table);
				table = new XVar("applicationUnderAssessment");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "applicationunderassessment", 1, MVCFunctions.Concat(" ", "Application Under Assessment")), table);
				table = new XVar("applicationUnderTechnicalEvaluation");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "applicationundertechnicalevaluation", 1, MVCFunctions.Concat(" ", "Application Under Technical Evaluation")), table);
				table = new XVar("dbo.region");
				mask = new XVar("");
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("add")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_add"))))
				{
					mask = MVCFunctions.Concat(mask, "A");
				}
				if((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("edit")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("inline_edit"))))
				{
					mask = MVCFunctions.Concat(mask, "E");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("delete"))))
				{
					mask = MVCFunctions.Concat(mask, "D");
				}
				if(XVar.Pack(CommonFunctions.pageEnabled((XVar)(table), new XVar("import"))))
				{
					mask = MVCFunctions.Concat(mask, "I");
				}
				if((XVar)((XVar)((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("view")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("list"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("chart"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("report"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("dashboard"))))
				{
					mask = MVCFunctions.Concat(mask, "S");
				}
				if((XVar)((XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("print")))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("rprint"))))  || (XVar)(CommonFunctions.pageEnabled((XVar)(table), new XVar("export"))))
				{
					mask = MVCFunctions.Concat(mask, "P");
				}
				pageMask.InitAndSetArrayItem(mask, table);
				tables.InitAndSetArrayItem(new XVar(0, "region", 1, MVCFunctions.Concat(" ", "Region")), table);
				if(XVar.Pack(CommonFunctions.pageEnabled(new XVar(Constants.GLOBAL_PAGES), new XVar("menu"))))
				{
					pageMask.InitAndSetArrayItem("S", Constants.GLOBAL_PAGES);
				}
				else
				{
					pageMask.InitAndSetArrayItem("", Constants.GLOBAL_PAGES);
				}
				tables.InitAndSetArrayItem(new XVar(0, MVCFunctions.GoodFieldName(new XVar(Constants.GLOBAL_PAGES_SHORT)), 1, MVCFunctions.Concat(" ", Constants.GLOBAL_PAGES)), Constants.GLOBAL_PAGES);
				xt = XVar.UnPackXTempl(new XTempl());
				options = XVar.Clone(XVar.Array());
				options.InitAndSetArrayItem("admin_rights_list", "pageType");
				options.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				options.InitAndSetArrayItem((XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) ? XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) : XVar.Pack(1)), "id");
				options.InitAndSetArrayItem(Constants.RIGHTS_PAGE, "mode");
				options.InitAndSetArrayItem(xt, "xt");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				options.InitAndSetArrayItem(tables, "tables");
				options.InitAndSetArrayItem(pageMask, "pageMasks");
				GlobalVars.pageObject = XVar.Clone(ListPage.createListPage((XVar)(GlobalVars.strTableName), (XVar)(options)));
				if(MVCFunctions.postvalue(new XVar("a")) == "saveRights")
				{
					dynamic modifiedRights = null;
					if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					modifiedRights = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("data")))));
					GlobalVars.pageObject.saveRights((XVar)(modifiedRights));
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
