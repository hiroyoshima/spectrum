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
	public partial class CommonFunctions
	{
		public static XVar getLookupMainTableSettings(dynamic _param_lookupTable, dynamic _param_mainTableShortName, dynamic _param_mainField, dynamic _param_desiredPage = null)
		{
			#region default values
			if(_param_desiredPage as Object == null) _param_desiredPage = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic lookupTable = XVar.Clone(_param_lookupTable);
			dynamic mainTableShortName = XVar.Clone(_param_mainTableShortName);
			dynamic mainField = XVar.Clone(_param_mainField);
			dynamic desiredPage = XVar.Clone(_param_desiredPage);
			#endregion

			dynamic arr = XVar.Array(), effectivePage = null;
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists(lookupTable))))
			{
				return null;
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks[lookupTable].KeyExists(MVCFunctions.Concat(mainTableShortName, ".", mainField)))))
			{
				return null;
			}
			arr = GlobalVars.lookupTableLinks[lookupTable][MVCFunctions.Concat(mainTableShortName, ".", mainField)];
			effectivePage = XVar.Clone(desiredPage);
			if(XVar.Pack(!(XVar)(arr.KeyExists(effectivePage))))
			{
				effectivePage = new XVar(Constants.PAGE_EDIT);
				if(XVar.Pack(!(XVar)(arr.KeyExists(effectivePage))))
				{
					if((XVar)(desiredPage == XVar.Pack(""))  && (XVar)(0 < MVCFunctions.count(arr)))
					{
						effectivePage = XVar.Clone(arr[0]);
					}
					else
					{
						return null;
					}
				}
			}
			return new ProjectSettings((XVar)(arr[effectivePage]["table"]), (XVar)(effectivePage));
		}
		public static XVar InitLookupLinks()
		{
			GlobalVars.lookupTableLinks = XVar.Clone(XVar.Array());
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("dbo_rspdheader.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "dbo_rspdheader.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "ID", "page", "edit"), "dbo.FrequencyB", "dbo_rspdheader.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("dbo_rspdheader.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "dbo_rspdheader.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "dbo_rspdheader.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("dbo_rspdheader.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "dbo_rspdheader.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "dbo_rspdheader.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("dbo_rspdheader.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "dbo_rspdheader.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "city_a", "page", "edit"), "dbo.city", "dbo_rspdheader.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("dbo_rspdheader.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "dbo_rspdheader.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "province_a", "page", "edit"), "dbo.province", "dbo_rspdheader.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("dbo_rspdheader.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "dbo_rspdheader.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "city_b", "page", "edit"), "dbo.city", "dbo_rspdheader.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("dbo_rspdheader.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "dbo_rspdheader.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "province_b", "page", "edit"), "dbo.province", "dbo_rspdheader.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("dbo_rspdheader.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "dbo_rspdheader.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "stage", "page", "edit"), "dbo.stage", "dbo_rspdheader.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("dbo_rspdheader.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "dbo_rspdheader.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "dbo_rspdheader.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.classStation"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.classStation"].KeyExists("dbo_rspdheader.classStationService"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation", "dbo_rspdheader.classStationService");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "classStationService", "page", "edit"), "dbo.classStation", "dbo_rspdheader.classStationService", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("dbo_rspdheader.encoder"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "dbo_rspdheader.encoder");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "encoder", "page", "edit"), "dbo.spectrum_beta_users", "dbo_rspdheader.encoder", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("dbo_rspdheader.evaluator"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "dbo_rspdheader.evaluator");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "evaluator", "page", "edit"), "dbo.spectrum_beta_users", "dbo_rspdheader.evaluator", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.region"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.region"].KeyExists("dbo_rspdheader.regionA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region", "dbo_rspdheader.regionA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "regionA", "page", "edit"), "dbo.region", "dbo_rspdheader.regionA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.region"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.region"].KeyExists("dbo_rspdheader.regionB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region", "dbo_rspdheader.regionB");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspdHeader", "field", "regionB", "page", "edit"), "dbo.region", "dbo_rspdheader.regionB", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("city.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "city.province");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.city", "field", "province", "page", "edit"), "dbo.province", "city.province", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.region"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.region"].KeyExists("province.region"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.region", "province.region");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.province", "field", "region", "page", "edit"), "dbo.region", "province.region", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("fas_report.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "fas_report.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "companyNameA", "page", "search"), "dbo.company", "fas_report.companyNameA", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("fas_report.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "fas_report.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "barangay_a", "page", "search"), "dbo.baranggay", "fas_report.barangay_a", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("fas_report.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "fas_report.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "city_a", "page", "search"), "dbo.city", "fas_report.city_a", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("fas_report.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "fas_report.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "province_a", "page", "search"), "dbo.province", "fas_report.province_a", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("fas_report.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "fas_report.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "barangay_b", "page", "search"), "dbo.baranggay", "fas_report.barangay_b", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("fas_report.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "fas_report.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "city_b", "page", "search"), "dbo.city", "fas_report.city_b", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("fas_report.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "fas_report.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "FAS Report", "field", "province_b", "page", "search"), "dbo.province", "fas_report.province_b", "search");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_betauggroups"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_betauggroups");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_betauggroups"].KeyExists("admin_users.groupid"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_betauggroups", "admin_users.groupid");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "admin_users", "field", "groupid", "page", "edit"), "dbo.spectrum_betauggroups", "admin_users.groupid", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("admin_users.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "admin_users.company");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "admin_users", "field", "company", "page", "edit"), "dbo.company", "admin_users.company", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.branch"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.branch");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.branch"].KeyExists("admin_users.branch"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.branch", "admin_users.branch");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "admin_users", "field", "branch", "page", "edit"), "dbo.branch", "admin_users.branch", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("stagestatus.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "stagestatus.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.stageStatus", "field", "stage", "page", "edit"), "dbo.stage", "stagestatus.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("rspd_application_received.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "rspd_application_received.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "ID", "page", "edit"), "dbo.FrequencyB", "rspd_application_received.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("rspd_application_received.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "rspd_application_received.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "companyNameA", "page", "edit"), "dbo.company", "rspd_application_received.companyNameA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("rspd_application_received.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "rspd_application_received.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "rspd_application_received.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("rspd_application_received.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "rspd_application_received.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "rspd_application_received.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("rspd_application_received.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "rspd_application_received.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "barangay_a", "page", "edit"), "dbo.baranggay", "rspd_application_received.barangay_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("rspd_application_received.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "rspd_application_received.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "city_a", "page", "edit"), "dbo.city", "rspd_application_received.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("rspd_application_received.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "rspd_application_received.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "province_a", "page", "edit"), "dbo.province", "rspd_application_received.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("rspd_application_received.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "rspd_application_received.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "barangay_b", "page", "edit"), "dbo.baranggay", "rspd_application_received.barangay_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("rspd_application_received.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "rspd_application_received.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "city_b", "page", "edit"), "dbo.city", "rspd_application_received.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("rspd_application_received.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "rspd_application_received.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "province_b", "page", "edit"), "dbo.province", "rspd_application_received.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("rspd_application_received.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "rspd_application_received.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "stage", "page", "edit"), "dbo.stage", "rspd_application_received.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("rspd_application_received.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "rspd_application_received.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.rspd_application_received", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "rspd_application_received.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("applicationsrecieved.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "applicationsrecieved.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "ID", "page", "edit"), "dbo.FrequencyB", "applicationsrecieved.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("applicationsrecieved.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "applicationsrecieved.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "companyNameA", "page", "edit"), "dbo.company", "applicationsrecieved.companyNameA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationsrecieved.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationsrecieved.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "applicationsrecieved.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationsrecieved.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationsrecieved.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "applicationsrecieved.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationsrecieved.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationsrecieved.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "barangay_a", "page", "edit"), "dbo.baranggay", "applicationsrecieved.barangay_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationsrecieved.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationsrecieved.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "city_a", "page", "edit"), "dbo.city", "applicationsrecieved.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationsrecieved.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationsrecieved.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "province_a", "page", "edit"), "dbo.province", "applicationsrecieved.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationsrecieved.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationsrecieved.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "barangay_b", "page", "edit"), "dbo.baranggay", "applicationsrecieved.barangay_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationsrecieved.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationsrecieved.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "city_b", "page", "edit"), "dbo.city", "applicationsrecieved.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationsrecieved.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationsrecieved.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "province_b", "page", "edit"), "dbo.province", "applicationsrecieved.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("applicationsrecieved.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "applicationsrecieved.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "stage", "page", "edit"), "dbo.stage", "applicationsrecieved.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("applicationsrecieved.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "applicationsrecieved.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "dbo.applicationsRecieved", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "applicationsrecieved.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("applicationendorsed.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "applicationendorsed.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "ID", "page", "edit"), "dbo.FrequencyB", "applicationendorsed.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("applicationendorsed.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "applicationendorsed.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "companyNameA", "page", "edit"), "dbo.company", "applicationendorsed.companyNameA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationendorsed.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationendorsed.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "applicationendorsed.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationendorsed.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationendorsed.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "applicationendorsed.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationendorsed.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationendorsed.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "barangay_a", "page", "edit"), "dbo.baranggay", "applicationendorsed.barangay_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationendorsed.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationendorsed.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "city_a", "page", "edit"), "dbo.city", "applicationendorsed.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationendorsed.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationendorsed.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "province_a", "page", "edit"), "dbo.province", "applicationendorsed.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationendorsed.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationendorsed.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "barangay_b", "page", "edit"), "dbo.baranggay", "applicationendorsed.barangay_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationendorsed.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationendorsed.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "city_b", "page", "edit"), "dbo.city", "applicationendorsed.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationendorsed.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationendorsed.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "province_b", "page", "edit"), "dbo.province", "applicationendorsed.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("applicationendorsed.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "applicationendorsed.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "stage", "page", "edit"), "dbo.stage", "applicationendorsed.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("applicationendorsed.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "applicationendorsed.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "applicationendorsed.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.classStation"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.classStation"].KeyExists("applicationendorsed.classStationService"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation", "applicationendorsed.classStationService");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "classStationService", "page", "edit"), "dbo.classStation", "applicationendorsed.classStationService", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationendorsed.encoder"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationendorsed.encoder");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "encoder", "page", "edit"), "dbo.spectrum_beta_users", "applicationendorsed.encoder", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationendorsed.evaluator"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationendorsed.evaluator");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationEndorsed", "field", "evaluator", "page", "edit"), "dbo.spectrum_beta_users", "applicationendorsed.evaluator", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("applicationunderassessment.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "applicationunderassessment.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "ID", "page", "edit"), "dbo.FrequencyB", "applicationunderassessment.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("applicationunderassessment.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "applicationunderassessment.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "companyNameA", "page", "edit"), "dbo.company", "applicationunderassessment.companyNameA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationunderassessment.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationunderassessment.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "applicationunderassessment.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationunderassessment.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationunderassessment.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "applicationunderassessment.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationunderassessment.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationunderassessment.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "barangay_a", "page", "edit"), "dbo.baranggay", "applicationunderassessment.barangay_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationunderassessment.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationunderassessment.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "city_a", "page", "edit"), "dbo.city", "applicationunderassessment.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationunderassessment.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationunderassessment.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "province_a", "page", "edit"), "dbo.province", "applicationunderassessment.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationunderassessment.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationunderassessment.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "barangay_b", "page", "edit"), "dbo.baranggay", "applicationunderassessment.barangay_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationunderassessment.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationunderassessment.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "city_b", "page", "edit"), "dbo.city", "applicationunderassessment.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationunderassessment.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationunderassessment.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "province_b", "page", "edit"), "dbo.province", "applicationunderassessment.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("applicationunderassessment.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "applicationunderassessment.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "stage", "page", "edit"), "dbo.stage", "applicationunderassessment.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("applicationunderassessment.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "applicationunderassessment.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "applicationunderassessment.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.classStation"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.classStation"].KeyExists("applicationunderassessment.classStationService"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation", "applicationunderassessment.classStationService");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "classStationService", "page", "edit"), "dbo.classStation", "applicationunderassessment.classStationService", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationunderassessment.encoder"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationunderassessment.encoder");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "encoder", "page", "edit"), "dbo.spectrum_beta_users", "applicationunderassessment.encoder", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationunderassessment.evaluator"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationunderassessment.evaluator");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderAssessment", "field", "evaluator", "page", "edit"), "dbo.spectrum_beta_users", "applicationunderassessment.evaluator", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.FrequencyB"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.FrequencyB"].KeyExists("applicationundertechnicalevaluation.ID"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.FrequencyB", "applicationundertechnicalevaluation.ID");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "ID", "page", "edit"), "dbo.FrequencyB", "applicationundertechnicalevaluation.ID", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.company"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.company"].KeyExists("applicationundertechnicalevaluation.companyNameA"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.company", "applicationundertechnicalevaluation.companyNameA");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "companyNameA", "page", "edit"), "dbo.company", "applicationundertechnicalevaluation.companyNameA", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationundertechnicalevaluation.userCreate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.userCreate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "userCreate", "page", "edit"), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.userCreate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationundertechnicalevaluation.userUpdate"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.userUpdate");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "userUpdate", "page", "edit"), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.userUpdate", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationundertechnicalevaluation.barangay_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationundertechnicalevaluation.barangay_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "barangay_a", "page", "edit"), "dbo.baranggay", "applicationundertechnicalevaluation.barangay_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationundertechnicalevaluation.city_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationundertechnicalevaluation.city_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "city_a", "page", "edit"), "dbo.city", "applicationundertechnicalevaluation.city_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationundertechnicalevaluation.province_a"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationundertechnicalevaluation.province_a");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "province_a", "page", "edit"), "dbo.province", "applicationundertechnicalevaluation.province_a", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.baranggay"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.baranggay"].KeyExists("applicationundertechnicalevaluation.barangay_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.baranggay", "applicationundertechnicalevaluation.barangay_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "barangay_b", "page", "edit"), "dbo.baranggay", "applicationundertechnicalevaluation.barangay_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.city"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.city"].KeyExists("applicationundertechnicalevaluation.city_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.city", "applicationundertechnicalevaluation.city_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "city_b", "page", "edit"), "dbo.city", "applicationundertechnicalevaluation.city_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.province"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.province"].KeyExists("applicationundertechnicalevaluation.province_b"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.province", "applicationundertechnicalevaluation.province_b");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "province_b", "page", "edit"), "dbo.province", "applicationundertechnicalevaluation.province_b", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stage"].KeyExists("applicationundertechnicalevaluation.stage"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stage", "applicationundertechnicalevaluation.stage");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "stage", "page", "edit"), "dbo.stage", "applicationundertechnicalevaluation.stage", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.stageStatus"].KeyExists("applicationundertechnicalevaluation.stageStatus"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.stageStatus", "applicationundertechnicalevaluation.stageStatus");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "stageStatus", "page", "edit"), "dbo.stageStatus", "applicationundertechnicalevaluation.stageStatus", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.classStation"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.classStation"].KeyExists("applicationundertechnicalevaluation.classStationService"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.classStation", "applicationundertechnicalevaluation.classStationService");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "classStationService", "page", "edit"), "dbo.classStation", "applicationundertechnicalevaluation.classStationService", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationundertechnicalevaluation.encoder"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.encoder");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "encoder", "page", "edit"), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.encoder", "edit");
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks.KeyExists("dbo.spectrum_beta_users"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users");
			}
			if(XVar.Pack(!(XVar)(GlobalVars.lookupTableLinks["dbo.spectrum_beta_users"].KeyExists("applicationundertechnicalevaluation.evaluator"))))
			{
				GlobalVars.lookupTableLinks.InitAndSetArrayItem(XVar.Array(), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.evaluator");
			}
			GlobalVars.lookupTableLinks.InitAndSetArrayItem(new XVar("table", "applicationUnderTechnicalEvaluation", "field", "evaluator", "page", "edit"), "dbo.spectrum_beta_users", "applicationundertechnicalevaluation.evaluator", "edit");
			return null;
		}
	}
}
