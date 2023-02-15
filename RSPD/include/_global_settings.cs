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
	public static partial class GlobalSettings
	{
		public static void Apply()
		{
			GlobalVars.tdataGLOBAL = XVar.Clone(XVar.Array());
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(MVCFunctions.my_json_decode(new XVar("{\"admin_members_list\":[\"admin_members_list\"],\"admin_rights_list\":[\"admin_rights_list\"],\"login\":[\"login\"],\"menu\":[\"menu\"],\"userinfo\":[\"userinfo\"]}")), ".pagesByType");
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(GlobalVars.tdataGLOBAL[".pagesByType"], ".originalPagesByType");
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(CommonFunctions.types2pages((XVar)(MVCFunctions.my_json_decode(new XVar("{\"admin_members_list\":[\"admin_members_list\"],\"admin_rights_list\":[\"admin_rights_list\"],\"login\":[\"login\"],\"menu\":[\"menu\"],\"userinfo\":[\"userinfo\"]}")))), ".pages");
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(GlobalVars.tdataGLOBAL[".pages"], ".originalPages");
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(MVCFunctions.my_json_decode(new XVar("{\"admin_members_list\":\"admin_members_list\",\"admin_rights_list\":\"admin_rights_list\",\"login\":\"login\",\"menu\":\"menu\",\"userinfo\":\"userinfo\"}")), ".defaultPages");
			GlobalVars.tdataGLOBAL.InitAndSetArrayItem(GlobalVars.tdataGLOBAL[".defaultPages"], ".originalDefaultPages");
			GlobalVars.tables_data.InitAndSetArrayItem(GlobalVars.tdataGLOBAL, "<global>");
			GlobalVars.detailsTablesData.InitAndSetArrayItem(XVar.Array(), "<global>");
			GlobalVars.masterTablesData.InitAndSetArrayItem(XVar.Array(), "<global>");
		}
	}

}
