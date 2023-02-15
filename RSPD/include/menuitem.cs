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
	public partial class MenuItem : XClass
	{
		public dynamic id;
		public dynamic href;
		public dynamic var_params;
		public dynamic var_type;
		public dynamic name;
		public dynamic nameType;
		public dynamic style;
		public dynamic table;
		public dynamic linkType;
		public dynamic pageType;
		public dynamic pageId = XVar.Pack("");
		public dynamic title;
		public dynamic openType;
		public dynamic children = XVar.Array();
		public dynamic parentItem = XVar.Pack(null);
		public dynamic pageName = XVar.Pack("");
		public dynamic menuTableMap;
		public dynamic currentItem = XVar.Pack(false);
		public dynamic menuId = XVar.Pack("");
		public dynamic comments;
		public dynamic icon;
		public dynamic iconType;
		public dynamic iconShow;
		public dynamic color;
		public MenuItem(dynamic menuItemInfo, dynamic menuNodes, dynamic menuParent, dynamic menuTableMap, dynamic _param_menuId)
		{
			#region pass-by-value parameters
			dynamic menuId = XVar.Clone(_param_menuId);
			#endregion

			this.menuId = XVar.Clone(menuId);
			this.menuTableMap = menuTableMap;
			this.id = XVar.Clone(menuItemInfo["id"]);
			this.name = XVar.Clone(menuItemInfo["name"]);
			this.var_type = XVar.Clone(menuItemInfo["type"]);
			this.href = XVar.Clone(menuItemInfo["href"]);
			this.title = XVar.Clone(menuItemInfo["title"]);
			this.comments = XVar.Clone(menuItemInfo["comments"]);
			this.color = XVar.Clone(menuItemInfo["color"]);
			this.style = XVar.Clone(menuItemInfo["style"]);
			this.table = XVar.Clone(menuItemInfo["table"]);
			this.var_params = XVar.Clone(menuItemInfo["params"]);
			this.linkType = XVar.Clone(menuItemInfo["linkType"]);
			this.nameType = XVar.Clone(menuItemInfo["nameType"]);
			this.pageType = XVar.Clone(menuItemInfo["pageType"]);
			this.pageId = XVar.Clone(menuItemInfo["pageId"]);
			this.openType = XVar.Clone(menuItemInfo["openType"]);
			this.icon = XVar.Clone(menuItemInfo["icon"]);
			this.iconType = XVar.Clone(menuItemInfo["iconType"]);
			this.iconShow = XVar.Clone(menuItemInfo["iconShow"]);
			this.buildTreeMenuStructure((XVar)(menuNodes));
			if((XVar)(this.var_type != "Separator")  && (XVar)(this.table))
			{
				dynamic pageType = null;
				pageType = XVar.Clone(MVCFunctions.strtolower((XVar)(this.pageType)));
				if(XVar.Pack(!(XVar)(this.menuTableMap.KeyExists(this.table))))
				{
					this.menuTableMap.InitAndSetArrayItem(XVar.Array(), this.table);
				}
				this.menuTableMap[this.table][pageType]++;
			}
		}
		public virtual XVar AddChild(dynamic child)
		{
			dynamic res = null;
			res = new XVar(true);
			if(XVar.Pack(GlobalVars.globalEvents.exists(new XVar("ModifyMenuItem"))))
			{
				res = XVar.Clone(GlobalVars.globalEvents.ModifyMenuItem((XVar)(child)));
			}
			if(XVar.Pack(res))
			{
				this.children.InitAndSetArrayItem(child, null);
				child.parentItem = XVar.Clone(this);
			}
			return null;
		}
		public virtual XVar setUrl(dynamic _param_href)
		{
			#region pass-by-value parameters
			dynamic href = XVar.Clone(_param_href);
			#endregion

			this.href = XVar.Clone(href);
			if(this.linkType == "Internal")
			{
				this.linkType = new XVar("External");
			}
			return null;
		}
		public virtual XVar getUrl()
		{
			return this.href;
		}
		public virtual XVar setParams(dynamic _param_params)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			this.var_params = XVar.Clone(var_params);
			return null;
		}
		public virtual XVar getParams()
		{
			return this.var_params;
		}
		public virtual XVar setTitle(dynamic _param_title)
		{
			#region pass-by-value parameters
			dynamic title = XVar.Clone(_param_title);
			#endregion

			this.title = XVar.Clone(title);
			return null;
		}
		public virtual XVar getTitle()
		{
			return this.title;
		}
		public virtual XVar setTable(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			this.table = XVar.Clone(table);
			return null;
		}
		public virtual XVar getTable()
		{
			return this.table;
		}
		public virtual XVar setPageType(dynamic _param_pType)
		{
			#region pass-by-value parameters
			dynamic pType = XVar.Clone(_param_pType);
			#endregion

			this.pageType = XVar.Clone(pType);
			return null;
		}
		public virtual XVar getPageType()
		{
			return this.pageType;
		}
		public virtual XVar setPage(dynamic _param_pageId)
		{
			#region pass-by-value parameters
			dynamic pageId = XVar.Clone(_param_pageId);
			#endregion

			this.pageId = XVar.Clone(pageId);
			return null;
		}
		public virtual XVar getPage()
		{
			return this.pageId;
		}
		public virtual XVar openNewWindow(dynamic _param_newWindow = null)
		{
			#region default values
			if(_param_newWindow as Object == null) _param_newWindow = new XVar(true);
			#endregion

			#region pass-by-value parameters
			dynamic newWindow = XVar.Clone(_param_newWindow);
			#endregion

			dynamic oldValue = null;
			oldValue = XVar.Clone(this.openType == "NewWindow");
			this.openType = XVar.Clone((XVar.Pack(newWindow) ? XVar.Pack("NewWindow") : XVar.Pack("None")));
			return oldValue;
		}
		public virtual XVar getLinkType()
		{
			return this.linkType;
		}
		public virtual XVar buildTreeMenuStructure(dynamic menuNodes)
		{
			dynamic i = null;
			while(GlobalVars.menuNodesIndex < MVCFunctions.count(menuNodes))
			{
				i = XVar.Clone(GlobalVars.menuNodesIndex);
				if(menuNodes[i]["parent"] != this.id)
				{
					break;
				}
				++(GlobalVars.menuNodesIndex);
				this.AddChild((XVar)(new MenuItem((XVar)(menuNodes[i]), (XVar)(menuNodes), this, (XVar)(this.menuTableMap), (XVar)(this.menuId))));
			}
			return null;
		}
		public virtual XVar linkAvailable()
		{
			return CommonFunctions.menuLinkAvailable((XVar)(this.table), (XVar)(this.pageType), (XVar)(this.pageId));
		}
		public virtual XVar showAsGroup()
		{
			dynamic i = null;
			if(XVar.Pack(!(XVar)(this.isGroup())))
			{
				return false;
			}
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.children); i++)
			{
				if(XVar.Pack(this.children[i].showAsGroup()))
				{
					return true;
				}
				else
				{
					if((XVar)(this.children[i].showAsLink())  && (XVar)(!(XVar)(this.children[i].isSeparator())))
					{
						return true;
					}
				}
			}
			return false;
		}
		public virtual XVar showAsLink()
		{
			if((XVar)(this.linkType == "External")  && (XVar)(0 < MVCFunctions.strlen((XVar)(this.href))))
			{
				return true;
			}
			if(this.linkType == "Separator")
			{
				return true;
			}
			if((XVar)(this.linkType == "Internal")  && (XVar)(this.linkAvailable()))
			{
				return true;
			}
			return false;
		}
		public virtual XVar isGroup()
		{
			return this.var_type == "Group";
		}
		public virtual XVar isSeparator()
		{
			return this.var_type == "Separator";
		}
		public virtual XVar getIconHTML()
		{
			if(XVar.Pack(!(XVar)(this.icon)))
			{
				return "";
			}
			if(this.iconType == Constants.ICON_BOOTSTRAP_GLYPH)
			{
				return MVCFunctions.Concat("<span class=\"menu-icon glyphicon ", this.icon, "\"></span>");
			}
			else
			{
				if(this.iconType == Constants.ICON_FONT_AWESOME)
				{
					return MVCFunctions.Concat("<span class=\"menu-icon fa ", this.icon, "\"></span>");
				}
				else
				{
					if(this.iconType == Constants.ICON_FILE)
					{
						return MVCFunctions.Concat("<img class=\"menu-icon\" src=\"", MVCFunctions.GetRootPathForResources((XVar)(MVCFunctions.Concat("images/menuicons/", this.icon))), "\">");
					}
				}
			}
			return null;
		}
		public virtual XVar getMenuXtData(dynamic _param_activeId, dynamic _param_menuMode, dynamic _param_level = null)
		{
			#region default values
			if(_param_level as Object == null) _param_level = new XVar(1);
			#endregion

			#region pass-by-value parameters
			dynamic activeId = XVar.Clone(_param_activeId);
			dynamic menuMode = XVar.Clone(_param_menuMode);
			dynamic level = XVar.Clone(_param_level);
			#endregion

			dynamic child = null, children = XVar.Array(), expanded = null, i = null, ret = XVar.Array(), showSubmenu = null;
			if((XVar)((XVar)((XVar)(this.id)  && (XVar)(!(XVar)(this.showAsGroup())))  && (XVar)(!(XVar)(this.showAsLink())))  && (XVar)(!(XVar)(this.isSeparator())))
			{
				return false;
			}
			showSubmenu = new XVar(true);
			ret = XVar.Clone(this.getXtLinkAttrs((XVar)(menuMode)));
			ret.InitAndSetArrayItem(true, MVCFunctions.Concat("item_menulink", level));
			ret.InitAndSetArrayItem(this.id, "item_id");
			ret.InitAndSetArrayItem((XVar.Pack(this.id == activeId) ? XVar.Pack("active") : XVar.Pack("")), "item_current");
			children = XVar.Clone(XVar.Array());
			expanded = new XVar(false);
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.children); i++)
			{
				child = XVar.Clone(this.children[i].getMenuXtData((XVar)(activeId), (XVar)(menuMode), (XVar)(level + 1)));
				if(!XVar.Equals(XVar.Pack(child), XVar.Pack(false)))
				{
					children.InitAndSetArrayItem(child, null);
					if(XVar.Pack(!(XVar)(expanded)))
					{
						expanded = XVar.Clone(this.children[i].hasActiveChildren((XVar)(activeId)));
					}
				}
			}
			ret.InitAndSetArrayItem((XVar.Pack(expanded) ? XVar.Pack("in") : XVar.Pack("")), "submenu_class");
			ret.InitAndSetArrayItem(new XVar("data", children), MVCFunctions.Concat("item_children", level));
			ret.InitAndSetArrayItem(0 < MVCFunctions.count(children), MVCFunctions.Concat("item_haschildren", level));
			ret.InitAndSetArrayItem(0 < MVCFunctions.count(children), MVCFunctions.Concat("item_showchildren", level));
			return ret;
		}
		public virtual XVar findActiveItem(dynamic _param_savedItemId, dynamic _param_hostTable, dynamic _param_hostPageType)
		{
			#region pass-by-value parameters
			dynamic savedItemId = XVar.Clone(_param_savedItemId);
			dynamic hostTable = XVar.Clone(_param_hostTable);
			dynamic hostPageType = XVar.Clone(_param_hostPageType);
			#endregion

			if(XVar.Pack(this.activeItem((XVar)(savedItemId), (XVar)(hostTable), (XVar)(hostPageType))))
			{
				return this;
			}
			foreach (KeyValuePair<XVar, dynamic> child in this.children.GetEnumerator())
			{
				dynamic activeChild = null;
				activeChild = XVar.Clone(child.Value.findActiveItem((XVar)(savedItemId), (XVar)(hostTable), (XVar)(hostPageType)));
				if(XVar.Pack(activeChild))
				{
					return activeChild;
				}
			}
			return null;
		}
		protected virtual XVar hasActiveChildren(dynamic _param_activeId)
		{
			#region pass-by-value parameters
			dynamic activeId = XVar.Clone(_param_activeId);
			#endregion

			if(this.id == activeId)
			{
				return true;
			}
			foreach (KeyValuePair<XVar, dynamic> child in this.children.GetEnumerator())
			{
				if(XVar.Pack(child.Value.hasActiveChildren((XVar)(activeId))))
				{
					return true;
				}
			}
			return false;
		}
		protected virtual XVar activeItem(dynamic _param_savedActiveId, dynamic _param_hostTable, dynamic _param_hostPageType)
		{
			#region pass-by-value parameters
			dynamic savedActiveId = XVar.Clone(_param_savedActiveId);
			dynamic hostTable = XVar.Clone(_param_hostTable);
			dynamic hostPageType = XVar.Clone(_param_hostPageType);
			#endregion

			if(hostTable != this.table)
			{
				return false;
			}
			if(hostPageType == MVCFunctions.strtolower((XVar)(this.pageType)))
			{
				return (XVar)(!(XVar)(savedActiveId))  || (XVar)(savedActiveId == this.id);
			}
			else
			{
				if((XVar)(!(XVar)(this.hostPageInMenu((XVar)(hostTable), (XVar)(hostPageType))))  && (XVar)(this.highestPriorityItem()))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar getMenuItemAttributes(dynamic _param_menuMode)
		{
			#region pass-by-value parameters
			dynamic menuMode = XVar.Clone(_param_menuMode);
			#endregion

			dynamic attrs = XVar.Array();
			attrs = XVar.Clone(XVar.Array());
			if(XVar.Pack(this.showAsGroup()))
			{
				if(XVar.Pack(this.isTreelike((XVar)(menuMode))))
				{
					attrs.InitAndSetArrayItem("menu-collapse", "data-toggle");
					attrs.InitAndSetArrayItem(MVCFunctions.Concat("#submenu", this.id), "data-target");
				}
				else
				{
					attrs.InitAndSetArrayItem("nested-dropdown", "data-toggle");
					attrs.InitAndSetArrayItem("true", "aria-haspopup");
					attrs.InitAndSetArrayItem("false", "aria-expanded");
				}
			}
			attrs.InitAndSetArrayItem(MVCFunctions.Concat("itemlink", this.id), "id");
			attrs.InitAndSetArrayItem(this.title, "itemtitle");
			if(this.style != "")
			{
				attrs.InitAndSetArrayItem(this.style, "style");
			}
			if(this.openType == "NewWindow")
			{
				attrs.InitAndSetArrayItem("external", "rel");
				attrs.InitAndSetArrayItem("_blank", "target");
				attrs.InitAndSetArrayItem("External", "link");
			}
			if((XVar)(this.linkType == "Internal")  && (XVar)(this.pageType == "webreports"))
			{
				attrs.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("webreport")), "href");
				attrs.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("webreport")), "value");
			}
			else
			{
				if(this.linkType == "Internal")
				{
					dynamic getParams = null, var_params = XVar.Array();
					var_params = XVar.Clone(XVar.Array());
					if(this.pageId != "")
					{
						var_params.InitAndSetArrayItem(MVCFunctions.Concat("page=", this.pageId), null);
					}
					if(1 < this.menuTableMap[this.table][MVCFunctions.strtolower((XVar)(this.pageType))])
					{
						var_params.InitAndSetArrayItem(MVCFunctions.Concat("menuItemId=", this.id), null);
					}
					if(XVar.Pack(this.var_params))
					{
						var_params.InitAndSetArrayItem(this.var_params, null);
					}
					getParams = XVar.Clone(MVCFunctions.implode(new XVar("&"), (XVar)(var_params)));
					attrs.InitAndSetArrayItem(MVCFunctions.GetTableLink((XVar)(CommonFunctions.GetTableURL((XVar)(this.table))), (XVar)(MVCFunctions.strtolower((XVar)(this.pageType))), (XVar)(getParams)), "href");
					attrs.InitAndSetArrayItem(MVCFunctions.GetTableLink((XVar)(CommonFunctions.GetTableURL((XVar)(this.table))), (XVar)(MVCFunctions.strtolower((XVar)(this.pageType))), (XVar)(getParams)), "value");
				}
				else
				{
					if(this.linkType == "External")
					{
						attrs.InitAndSetArrayItem(this.href, "href");
						attrs.InitAndSetArrayItem(this.href, "value");
					}
				}
			}
			return attrs;
		}
		protected virtual XVar getXtLinkAttrs(dynamic _param_menuMode)
		{
			#region pass-by-value parameters
			dynamic menuMode = XVar.Clone(_param_menuMode);
			#endregion

			dynamic attrs = XVar.Array(), groupOnlyAttrs = XVar.Array(), groupOnlyMode = null, icon = null, link_attrs = null, option_attrs = null, ret = XVar.Array(), separator = null, title = null;
			separator = XVar.Clone(this.isSeparator());
			ret = XVar.Clone(XVar.Array());
			title = XVar.Clone(this.title);
			ret.InitAndSetArrayItem(this.showAsGroup(), "item_expand_icon");
			icon = XVar.Clone(this.getIconHTML());
			ret.InitAndSetArrayItem((XVar.Pack((XVar)(icon)  && (XVar)(this.iconShow == 1)) ? XVar.Pack(MVCFunctions.Concat(icon, " ")) : XVar.Pack("")), "item_icon");
			ret.InitAndSetArrayItem((XVar.Pack(icon) ? XVar.Pack(MVCFunctions.Concat(icon, " ")) : XVar.Pack("")), "item_collicon");
			ret.InitAndSetArrayItem((XVar.Pack((XVar)(!(XVar)(icon))  && (XVar)(!(XVar)(separator))) ? XVar.Pack(MVCFunctions.substr((XVar)(MVCFunctions.trim((XVar)(this.title))), new XVar(0), new XVar(1))) : XVar.Pack("")), "item_firstcap");
			attrs = XVar.Clone(this.getMenuItemAttributes((XVar)(menuMode)));
			if(XVar.Pack(!(XVar)(separator)))
			{
				ret.InitAndSetArrayItem(MVCFunctions.runner_htmlspecialchars((XVar)(this.title)), "item_tooltip");
				ret.InitAndSetArrayItem(title, "item_title");
			}
			else
			{
				ret.InitAndSetArrayItem("", "item_tooltip");
				ret.InitAndSetArrayItem("", "item_title");
				attrs.InitAndSetArrayItem(true, "data-separator");
			}
			groupOnlyAttrs = XVar.Clone(XVar.Array());
			groupOnlyAttrs.InitAndSetArrayItem(true, "id");
			groupOnlyAttrs.InitAndSetArrayItem(true, "title");
			groupOnlyAttrs.InitAndSetArrayItem(true, "style");
			groupOnlyAttrs.InitAndSetArrayItem(true, "class");
			groupOnlyAttrs.InitAndSetArrayItem(true, "data-toggle");
			groupOnlyAttrs.InitAndSetArrayItem(true, "data-target");
			groupOnlyAttrs.InitAndSetArrayItem(true, "aria-haspopup");
			groupOnlyAttrs.InitAndSetArrayItem(true, "aria-expanded");
			groupOnlyMode = XVar.Clone((XVar)(!(XVar)(this.showAsLink()))  && (XVar)(this.showAsGroup()));
			if((XVar)(groupOnlyMode)  && (XVar)(!(XVar)(this.isTreelike((XVar)(menuMode)))))
			{
				dynamic childWithLink = null;
				childWithLink = XVar.Clone(this.getFirstChildWithLink());
				if(XVar.Pack(childWithLink))
				{
					dynamic linkChildAttrs = XVar.Array();
					groupOnlyAttrs.InitAndSetArrayItem(true, "href");
					linkChildAttrs = XVar.Clone(childWithLink.getMenuItemAttributes((XVar)(menuMode)));
					attrs.InitAndSetArrayItem(linkChildAttrs["href"], "href");
				}
			}
			option_attrs = new XVar("");
			link_attrs = new XVar("");
			foreach (KeyValuePair<XVar, dynamic> value in attrs.GetEnumerator())
			{
				if((XVar)(groupOnlyMode)  && (XVar)(!(XVar)(groupOnlyAttrs[value.Key])))
				{
					continue;
				}
				if(XVar.Pack(!(XVar)(value.Value)))
				{
					continue;
				}
				if((XVar)(value.Key == "value")  || (XVar)(value.Key == "link"))
				{
					option_attrs = MVCFunctions.Concat(option_attrs, " ", value.Key, "=\"", value.Value, "\"");
				}
				else
				{
					link_attrs = MVCFunctions.Concat(link_attrs, " ", value.Key, "=\"", value.Value, "\"");
				}
			}
			if(XVar.Pack(groupOnlyMode))
			{
				option_attrs = new XVar("disabled");
			}
			ret.InitAndSetArrayItem(link_attrs, "item_attrs");
			ret.InitAndSetArrayItem(option_attrs, "item_optionattrs");
			return ret;
		}
		public virtual XVar getFirstChildWithLink()
		{
			if(XVar.Pack(this.showAsLink()))
			{
				return this;
			}
			foreach (KeyValuePair<XVar, dynamic> child in this.children.GetEnumerator())
			{
				if(XVar.Pack(child.Value.showAsLink()))
				{
					return child.Value;
				}
			}
			foreach (KeyValuePair<XVar, dynamic> child in this.children.GetEnumerator())
			{
				dynamic childWithLink = null;
				childWithLink = XVar.Clone(child.Value.getFirstChildWithLink());
				if(XVar.Pack(childWithLink))
				{
					return childWithLink;
				}
			}
			return null;
		}
		public virtual XVar assignGroupOnly(dynamic xt_packed)
		{
			#region packeted values
			XTempl xt = XVar.UnPackXTempl(xt_packed);
			#endregion

			dynamic attrForAssign = null;
			xt.assign((XVar)(MVCFunctions.Concat("item", this.id, "_title")), (XVar)(this.title));
			attrForAssign = XVar.Clone(MVCFunctions.Concat(" id=\"itemlink", this.id, "\" itemtitle=\"", this.title, "\" ", (XVar.Pack(this.style) ? XVar.Pack(MVCFunctions.Concat(" style=\"cursor:default;text-decoration:none; ", this.style, "\"")) : XVar.Pack(""))));
			xt.assign((XVar)(MVCFunctions.Concat("item", this.id, "_menulink_attrs")), (XVar)(attrForAssign));
			xt.assign((XVar)(MVCFunctions.Concat("item", this.id, "_optionattrs")), new XVar("disabled"));
			return null;
		}
		public virtual XVar highestPriorityItem()
		{
			dynamic i = null, pageTypesInMenu = null, priorityIdx = null, priorityList = XVar.Array();
			if(XVar.Pack(!(XVar)(this.menuTableMap.KeyExists(this.table))))
			{
				return false;
			}
			priorityList = XVar.Clone(new XVar(0, "list", 1, "chart", 2, "report", 3, "search", 4, "add", 5, "print"));
			pageTypesInMenu = XVar.Clone(MVCFunctions.array_keys((XVar)(this.menuTableMap[this.table])));
			priorityIdx = XVar.Clone(MVCFunctions.array_search((XVar)(MVCFunctions.strtolower((XVar)(this.pageType))), (XVar)(priorityList)));
			if(XVar.Equals(XVar.Pack(priorityIdx), XVar.Pack(false)))
			{
				priorityIdx = XVar.Clone(MVCFunctions.count(priorityList));
			}
			i = new XVar(0);
			for(;i < priorityIdx; ++(i))
			{
				if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(priorityList[i]), (XVar)(pageTypesInMenu))), XVar.Pack(false)))
				{
					return false;
				}
			}
			return true;
		}
		public virtual XVar hostPageInMenu(dynamic _param_hostTable, dynamic _param_hostPageType)
		{
			#region pass-by-value parameters
			dynamic hostTable = XVar.Clone(_param_hostTable);
			dynamic hostPageType = XVar.Clone(_param_hostPageType);
			#endregion

			return this.menuTableMap[hostTable].KeyExists(hostPageType);
		}
		public virtual XVar changeKeysInLowerCaseFromArr(dynamic _param_arr)
		{
			#region pass-by-value parameters
			dynamic arr = XVar.Clone(_param_arr);
			#endregion

			dynamic lowArr = XVar.Array();
			lowArr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
			{
				lowArr.InitAndSetArrayItem(MVCFunctions.strtolower((XVar)(val.Key)), null);
			}
			return lowArr;
		}
		public virtual XVar clearMenuSession()
		{
			if(XVar.Pack(XSession.Session.KeyExists("menuItemId")))
			{
				XSession.Session.Remove("menuItemId");
			}
			return null;
		}
		public static XVar setMenuSession()
		{
			if(XVar.Pack(MVCFunctions.postvalue(new XVar("menuItemId"))))
			{
				XSession.Session["menuItemId"] = MVCFunctions.postvalue(new XVar("menuItemId"));
			}
			return null;
		}
		public virtual XVar getItemDescendants(dynamic descendants, dynamic _param_level = null)
		{
			#region default values
			if(_param_level as Object == null) _param_level = new XVar(0);
			#endregion

			#region pass-by-value parameters
			dynamic level = XVar.Clone(_param_level);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> child in this.children.GetEnumerator())
			{
				descendants.InitAndSetArrayItem(child.Value, null);
				if(XVar.Pack(level))
				{
					child.Value.getItemDescendants((XVar)(descendants), (XVar)(level - 1));
				}
			}
			return null;
		}
		public virtual XVar isWelcome()
		{
			return this.menuId == Constants.WELCOME_MENU;
		}
		public virtual XVar isTreelike(dynamic _param_menuMode)
		{
			#region pass-by-value parameters
			dynamic menuMode = XVar.Clone(_param_menuMode);
			#endregion

			return (XVar)(Constants.MENU_VERTICAL == menuMode)  && (XVar)(ProjectSettings.isMenuTreelike((XVar)(this.menuId)));
		}
		public static XVar findItemById(dynamic _param_root, dynamic _param_id)
		{
			#region pass-by-value parameters
			dynamic root = XVar.Clone(_param_root);
			dynamic id = XVar.Clone(_param_id);
			#endregion

			if(root.id == id)
			{
				return root;
			}
			foreach (KeyValuePair<XVar, dynamic> child in root.children.GetEnumerator())
			{
				dynamic item = null;
				item = XVar.Clone(MenuItem.findItemById((XVar)(child.Value), (XVar)(id)));
				if(XVar.Pack(item))
				{
					return item;
				}
			}
			return null;
		}
		public static XVar maxChildId(dynamic _param_root)
		{
			#region pass-by-value parameters
			dynamic root = XVar.Clone(_param_root);
			#endregion

			dynamic max = null;
			max = XVar.Clone(root.id);
			foreach (KeyValuePair<XVar, dynamic> child in root.children.GetEnumerator())
			{
				max = XVar.Clone(MVCFunctions.max((XVar)(max), (XVar)(MenuItem.maxChildId((XVar)(child.Value)))));
			}
			return max;
		}
		public static XVar cloneNode(dynamic _param_item)
		{
			#region pass-by-value parameters
			dynamic item = XVar.Clone(_param_item);
			#endregion

			dynamic childNodes = null, cloneItem = null, menuNode = null, parent = null;
			menuNode = XVar.Clone(XVar.Array());
			childNodes = XVar.Clone(XVar.Array());
			parent = XVar.Clone(XVar.Array());
			cloneItem = XVar.Clone(new MenuItem((XVar)(menuNode), (XVar)(childNodes), (XVar)(parent), (XVar)(item.menuTableMap), new XVar(null)));
			cloneItem.id = XVar.Clone(item.id);
			cloneItem.name = XVar.Clone(item.name);
			cloneItem.var_type = XVar.Clone(item.var_type);
			cloneItem.href = XVar.Clone(item.href);
			cloneItem.title = XVar.Clone(item.title);
			cloneItem.comments = XVar.Clone(item.comments);
			cloneItem.color = XVar.Clone(item.color);
			cloneItem.style = XVar.Clone(item.color);
			cloneItem.table = XVar.Clone(item.table);
			cloneItem.var_params = XVar.Clone(item.var_params);
			cloneItem.linkType = XVar.Clone(item.linkType);
			cloneItem.nameType = XVar.Clone(item.nameType);
			cloneItem.pageType = XVar.Clone(item.pageType);
			cloneItem.pageId = XVar.Clone(item.pageId);
			cloneItem.openType = XVar.Clone(item.openType);
			cloneItem.icon = XVar.Clone(item.icon);
			cloneItem.iconType = XVar.Clone(item.iconType);
			cloneItem.iconShow = XVar.Clone(item.iconShow);
			cloneItem.menuId = XVar.Clone(item.id);
			cloneItem.menuTableMap = item.menuTableMap;
			return cloneItem;
		}
	}
}
