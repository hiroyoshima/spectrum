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
		public static XVar GetMenuNodesadminarea()
		{
			dynamic menuNode = XVar.Array(), menuNodes = XVar.Array();
			menuNodes = XVar.Clone(XVar.Array());
			menuNode = XVar.Clone(XVar.Array());
			menuNode.InitAndSetArrayItem("1", "id");
			menuNode.InitAndSetArrayItem("admin_rights", "name");
			menuNode.InitAndSetArrayItem("Leaf", "type");
			menuNode.InitAndSetArrayItem("admin_rights", "table");
			menuNode.InitAndSetArrayItem("", "style");
			menuNode.InitAndSetArrayItem("", "params");
			menuNode.InitAndSetArrayItem("0", "parent");
			menuNode.InitAndSetArrayItem("Text", "nameType");
			menuNode.InitAndSetArrayItem("External", "linkType");
			menuNode.InitAndSetArrayItem("AdminArea", "pageType");
			menuNode.InitAndSetArrayItem("None", "openType");
			menuNode.InitAndSetArrayItem("Permissions", "title");
			menuNode.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("admin_rights"), new XVar("list")), "href");
			menuNodes.InitAndSetArrayItem(menuNode, null);
			menuNode = XVar.Clone(XVar.Array());
			menuNode.InitAndSetArrayItem("2", "id");
			menuNode.InitAndSetArrayItem("admin_members", "name");
			menuNode.InitAndSetArrayItem("Leaf", "type");
			menuNode.InitAndSetArrayItem("admin_members", "table");
			menuNode.InitAndSetArrayItem("", "style");
			menuNode.InitAndSetArrayItem("", "params");
			menuNode.InitAndSetArrayItem("0", "parent");
			menuNode.InitAndSetArrayItem("Text", "nameType");
			menuNode.InitAndSetArrayItem("External", "linkType");
			menuNode.InitAndSetArrayItem("AdminArea", "pageType");
			menuNode.InitAndSetArrayItem("None", "openType");
			menuNode.InitAndSetArrayItem("Assign users to groups", "title");
			menuNode.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("admin_members"), new XVar("list")), "href");
			menuNodes.InitAndSetArrayItem(menuNode, null);
			menuNode = XVar.Clone(XVar.Array());
			menuNode.InitAndSetArrayItem("3", "id");
			menuNode.InitAndSetArrayItem("admin_users", "name");
			menuNode.InitAndSetArrayItem("Leaf", "type");
			menuNode.InitAndSetArrayItem("admin_users", "table");
			menuNode.InitAndSetArrayItem("", "style");
			menuNode.InitAndSetArrayItem("", "params");
			menuNode.InitAndSetArrayItem("0", "parent");
			menuNode.InitAndSetArrayItem("Text", "nameType");
			menuNode.InitAndSetArrayItem("External", "linkType");
			menuNode.InitAndSetArrayItem("AdminArea", "pageType");
			menuNode.InitAndSetArrayItem("None", "openType");
			menuNode.InitAndSetArrayItem("Add/Edit users", "title");
			menuNode.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("admin_users"), new XVar("list")), "href");
			menuNodes.InitAndSetArrayItem(menuNode, null);
			GlobalVars.menuNodesCache.InitAndSetArrayItem(menuNodes, "adminarea");
			return null;
		}
	}
}
