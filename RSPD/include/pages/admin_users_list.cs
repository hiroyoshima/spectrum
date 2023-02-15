
		// admin_users
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
			public static partial class Options_admin_users_list
			{
				static public XVar options()
				{
					return new XVar( "list", new XVar( "inlineAdd", false,
"detailsAdd", false,
"inlineEdit", false,
"spreadsheetMode", false,
"addToBottom", false,
"delete", true,
"updateSelected", false,
"clickSort", true,
"sortDropdown", false,
"showHideFields", false,
"reorderFields", false,
"fieldFilter", false ),
"listSearch", new XVar( "alwaysOnPanelFields", XVar.Array(),
"searchPanel", true,
"fixedSearchPanel", false,
"simpleSearchOptions", false,
"searchSaving", false ),
"totals", new XVar( "ID", new XVar( "totalsType", "" ),
"username", new XVar( "totalsType", "" ),
"password", new XVar( "totalsType", "" ),
"email", new XVar( "totalsType", "" ),
"fullname", new XVar( "totalsType", "" ),
"groupid", new XVar( "totalsType", "" ),
"active", new XVar( "totalsType", "" ),
"ext_security_id", new XVar( "totalsType", "" ),
"company", new XVar( "totalsType", "" ),
"position", new XVar( "totalsType", "" ),
"branch", new XVar( "totalsType", "" ),
"groupPermission", new XVar( "totalsType", "" ) ),
"fields", new XVar( "gridFields", new XVar( 0, "username",
1, "email",
2, "fullname",
3, "active",
4, "groupPermission",
5, "branch" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", new XVar( 0, "username",
1, "groupPermission",
2, "branch",
3, "password",
4, "fullname",
5, "email",
6, "active" ),
"filterFields", XVar.Array(),
"inlineAddFields", XVar.Array(),
"inlineEditFields", XVar.Array(),
"fieldItems", new XVar( "username", new XVar( 0, "simple_grid_field1",
1, "simple_grid_field2" ),
"email", new XVar( 0, "simple_grid_field3",
1, "simple_grid_field5" ),
"fullname", new XVar( 0, "simple_grid_field4",
1, "simple_grid_field8" ),
"active", new XVar( 0, "simple_grid_field6",
1, "simple_grid_field9" ),
"groupPermission", new XVar( 0, "simple_grid_field",
1, "simple_grid_field10" ),
"branch", new XVar( 0, "simple_grid_field7",
1, "simple_grid_field11" ) ),
"hideEmptyFields", XVar.Array(),
"fieldFilterFields", XVar.Array() ),
"pageLinks", new XVar( "edit", true,
"add", true,
"view", true,
"print", true ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", new XVar( 0, "add",
1, "delete",
2, "details_found",
3, "page_size",
4, "print_panel" ),
"below-grid", new XVar( 0, "pagination" ),
"left", new XVar( 0, "logo",
1, "expand_button",
2, "menu",
3, "search_panel" ),
"supertop", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "breadcrumb",
3, "simple_search",
4, "list_options",
5, "username_button" ),
"top", XVar.Array(),
"grid", new XVar( 0, "simple_grid_field2",
1, "simple_grid_field1",
2, "simple_grid_field5",
3, "simple_grid_field3",
4, "simple_grid_field8",
5, "simple_grid_field4",
6, "simple_grid_field9",
7, "simple_grid_field6",
8, "simple_grid_field10",
9, "simple_grid_field",
10, "simple_grid_field11",
11, "simple_grid_field7",
12, "grid_checkbox_head",
13, "grid_checkbox",
14, "grid_edit",
15, "grid_view" ) ),
"formXtTags", new XVar( "above-grid", new XVar( 0, "add_link",
1, "deleteselected_link",
2, "details_found",
3, "recsPerPage",
4, "print_friendly" ),
"below-grid", new XVar( 0, "pagination" ),
"top", XVar.Array() ),
"itemForms", new XVar( "add", "above-grid",
"delete", "above-grid",
"details_found", "above-grid",
"page_size", "above-grid",
"print_panel", "above-grid",
"pagination", "below-grid",
"logo", "left",
"expand_button", "left",
"menu", "left",
"search_panel", "left",
"expand_menu_button", "supertop",
"collapse_button", "supertop",
"breadcrumb", "supertop",
"simple_search", "supertop",
"list_options", "supertop",
"username_button", "supertop",
"simple_grid_field2", "grid",
"simple_grid_field1", "grid",
"simple_grid_field5", "grid",
"simple_grid_field3", "grid",
"simple_grid_field8", "grid",
"simple_grid_field4", "grid",
"simple_grid_field9", "grid",
"simple_grid_field6", "grid",
"simple_grid_field10", "grid",
"simple_grid_field", "grid",
"simple_grid_field11", "grid",
"simple_grid_field7", "grid",
"grid_checkbox_head", "grid",
"grid_checkbox", "grid",
"grid_edit", "grid",
"grid_view", "grid" ),
"itemLocations", new XVar( "simple_grid_field2", new XVar( "location", "grid",
"cellId", "headcell_field" ),
"simple_grid_field1", new XVar( "location", "grid",
"cellId", "cell_field" ),
"simple_grid_field5", new XVar( "location", "grid",
"cellId", "headcell_field1" ),
"simple_grid_field3", new XVar( "location", "grid",
"cellId", "cell_field1" ),
"simple_grid_field8", new XVar( "location", "grid",
"cellId", "headcell_field2" ),
"simple_grid_field4", new XVar( "location", "grid",
"cellId", "cell_field2" ),
"simple_grid_field9", new XVar( "location", "grid",
"cellId", "headcell_field3" ),
"simple_grid_field6", new XVar( "location", "grid",
"cellId", "cell_field3" ),
"simple_grid_field10", new XVar( "location", "grid",
"cellId", "headcell_field4" ),
"simple_grid_field", new XVar( "location", "grid",
"cellId", "cell_field4" ),
"simple_grid_field11", new XVar( "location", "grid",
"cellId", "headcell_field5" ),
"simple_grid_field7", new XVar( "location", "grid",
"cellId", "cell_field5" ),
"grid_checkbox_head", new XVar( "location", "grid",
"cellId", "headcell_checkbox" ),
"grid_checkbox", new XVar( "location", "grid",
"cellId", "cell_checkbox" ),
"grid_edit", new XVar( "location", "grid",
"cellId", "cell_icons" ),
"grid_view", new XVar( "location", "grid",
"cellId", "cell_icons" ) ),
"itemVisiblity", new XVar( "breadcrumb", 5,
"expand_menu_button", 2,
"print_panel", 5,
"expand_button", 5 ) ),
"itemsByType", new XVar( "page_size", new XVar( 0, "page_size" ),
"details_found", new XVar( 0, "details_found" ),
"breadcrumb", new XVar( 0, "breadcrumb" ),
"logo", new XVar( 0, "logo" ),
"menu", new XVar( 0, "menu" ),
"simple_search", new XVar( 0, "simple_search" ),
"pagination", new XVar( 0, "pagination" ),
"search_panel", new XVar( 0, "search_panel" ),
"list_options", new XVar( 0, "list_options" ),
"show_search_panel", new XVar( 0, "show_search_panel" ),
"hide_search_panel", new XVar( 0, "hide_search_panel" ),
"search_panel_field", new XVar( 0, "search_panel_field1",
1, "search_panel_field2",
2, "search_panel_field4",
3, "search_panel_field6",
4, "search_panel_field7",
5, "search_panel_field",
6, "search_panel_field8" ),
"username_button", new XVar( 0, "username_button" ),
"exit_adminarea_link", new XVar( 0, "exit_adminarea_link" ),
"userinfo_link", new XVar( 0, "userinfo_link" ),
"logout_link", new XVar( 0, "logout_link" ),
"expand_menu_button", new XVar( 0, "expand_menu_button" ),
"collapse_button", new XVar( 0, "collapse_button" ),
"add", new XVar( 0, "add" ),
"print_panel", new XVar( 0, "print_panel" ),
"print_scope", new XVar( 0, "print_scope" ),
"print_button", new XVar( 0, "print_button" ),
"print_records", new XVar( 0, "print_records" ),
"export", new XVar( 0, "export" ),
"-", new XVar( 0, "-",
1, "-1",
2, "-2",
3, "-3" ),
"export_selected", new XVar( 0, "export_selected" ),
"import", new XVar( 0, "import" ),
"delete", new XVar( 0, "delete" ),
"delete_selected", new XVar( 0, "delete_selected" ),
"advsearch_link", new XVar( 0, "advsearch_link" ),
"grid_field", new XVar( 0, "simple_grid_field1",
1, "simple_grid_field3",
2, "simple_grid_field4",
3, "simple_grid_field6",
4, "simple_grid_field",
5, "simple_grid_field7" ),
"grid_field_label", new XVar( 0, "simple_grid_field2",
1, "simple_grid_field5",
2, "simple_grid_field8",
3, "simple_grid_field9",
4, "simple_grid_field10",
5, "simple_grid_field11" ),
"grid_checkbox", new XVar( 0, "grid_checkbox" ),
"grid_checkbox_head", new XVar( 0, "grid_checkbox_head" ),
"grid_edit", new XVar( 0, "grid_edit" ),
"grid_view", new XVar( 0, "grid_view" ),
"expand_button", new XVar( 0, "expand_button" ) ),
"cellMaps", new XVar( "grid", new XVar( "cells", new XVar( "headcell_icons", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 0 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_checkbox", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "checkbox_column" ),
"items", new XVar( 0, "grid_checkbox_head" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field", new XVar( "cols", new XVar( 0, 2 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "username_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field2" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field1", new XVar( "cols", new XVar( 0, 3 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "email_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field5" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field2", new XVar( "cols", new XVar( 0, 4 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "fullname_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field8" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field3", new XVar( "cols", new XVar( 0, 5 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "active_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field9" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field4", new XVar( "cols", new XVar( 0, 6 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "groupPermission_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field10" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field5", new XVar( "cols", new XVar( 0, 7 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "branch_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field11" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_icons", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "edit_column",
1, "view_column" ),
"items", new XVar( 0, "grid_edit",
1, "grid_view" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_checkbox", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "checkbox_column" ),
"items", new XVar( 0, "grid_checkbox" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field", new XVar( "cols", new XVar( 0, 2 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "username_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field1" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field1", new XVar( "cols", new XVar( 0, 3 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "email_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field3" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field2", new XVar( "cols", new XVar( 0, 4 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "fullname_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field4" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field3", new XVar( "cols", new XVar( 0, 5 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "active_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field6" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field4", new XVar( "cols", new XVar( 0, 6 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "groupPermission_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field5", new XVar( "cols", new XVar( 0, 7 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "branch_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field7" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_icons", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_checkbox", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field", new XVar( "cols", new XVar( 0, 2 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field1", new XVar( "cols", new XVar( 0, 3 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field2", new XVar( "cols", new XVar( 0, 4 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field3", new XVar( "cols", new XVar( 0, 5 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field4", new XVar( "cols", new XVar( 0, 6 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field5", new XVar( "cols", new XVar( 0, 7 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ) ),
"width", 8,
"height", 3 ) ) ),
"loginForm", new XVar( "loginForm", 3 ),
"page", new XVar( "verticalBar", true,
"labeledButtons", new XVar( "update_records", new XVar(  ),
"print_pages", new XVar(  ),
"register_activate_message", new XVar(  ),
"details_found", new XVar( "details_found", new XVar( "tag", "DISPLAYING",
"type", 2 ) ) ),
"gridType", 0,
"recsPerRow", 1,
"hasCustomButtons", false,
"customButtons", XVar.Array(),
"hasNotifications", false,
"menus", new XVar( 0, new XVar( "id", "main",
"horizontal", false ) ),
"calcTotalsFor", 1 ),
"misc", new XVar( "type", "list",
"breadcrumb", true ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"dataGrid", new XVar( "groupFields", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "list",
"type", "list",
"layoutId", "leftbar",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "list-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "add",
1, "delete" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "details_found",
1, "page_size",
2, "print_panel" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "list-below-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "pagination" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"left", new XVar( "modelId", "leftbar-menu",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c0" ) ),
"section", "" ),
1, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c0", new XVar( "model", "c0",
"items", new XVar( 0, "logo",
1, "expand_button" ) ),
"c1", new XVar( "model", "c1",
"items", new XVar( 0, "menu",
1, "search_panel" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"supertop", new XVar( "modelId", "leftbar-top",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "breadcrumb" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "simple_search",
1, "list_options",
2, "username_button" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "list-sidebar-top",
"grid", XVar.Array(),
"cells", new XVar(  ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "horizontal-grid",
"grid", new XVar( 0, new XVar( "section", "head",
"cells", new XVar( 0, new XVar( "cell", "headcell_icons" ),
1, new XVar( "cell", "headcell_checkbox" ),
2, new XVar( "cell", "headcell_field" ),
3, new XVar( "cell", "headcell_field1" ),
4, new XVar( "cell", "headcell_field2" ),
5, new XVar( "cell", "headcell_field3" ),
6, new XVar( "cell", "headcell_field4" ),
7, new XVar( "cell", "headcell_field5" ) ) ),
1, new XVar( "section", "body",
"cells", new XVar( 0, new XVar( "cell", "cell_icons" ),
1, new XVar( "cell", "cell_checkbox" ),
2, new XVar( "cell", "cell_field" ),
3, new XVar( "cell", "cell_field1" ),
4, new XVar( "cell", "cell_field2" ),
5, new XVar( "cell", "cell_field3" ),
6, new XVar( "cell", "cell_field4" ),
7, new XVar( "cell", "cell_field5" ) ) ),
2, new XVar( "section", "foot",
"cells", new XVar( 0, new XVar( "cell", "footcell_icons" ),
1, new XVar( "cell", "footcell_checkbox" ),
2, new XVar( "cell", "footcell_field" ),
3, new XVar( "cell", "footcell_field1" ),
4, new XVar( "cell", "footcell_field2" ),
5, new XVar( "cell", "footcell_field3" ),
6, new XVar( "cell", "footcell_field4" ),
7, new XVar( "cell", "footcell_field5" ) ) ) ),
"cells", new XVar( "headcell_field", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field2" ),
"field", "username",
"columnName", "field" ),
"cell_field", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field1" ),
"field", "username",
"columnName", "field" ),
"footcell_field", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field1", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field5" ),
"field", "email",
"columnName", "field" ),
"cell_field1", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field3" ),
"field", "email",
"columnName", "field" ),
"footcell_field1", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field2", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field8" ),
"field", "fullname",
"columnName", "field" ),
"cell_field2", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field4" ),
"field", "fullname",
"columnName", "field" ),
"footcell_field2", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field3", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field9" ),
"field", "active",
"columnName", "field" ),
"cell_field3", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field6" ),
"field", "active",
"columnName", "field" ),
"footcell_field3", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field4", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field10" ),
"field", "groupPermission",
"columnName", "field" ),
"cell_field4", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field" ),
"field", "groupPermission",
"columnName", "field" ),
"footcell_field4", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field5", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field11" ),
"field", "branch",
"columnName", "field" ),
"cell_field5", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field7" ),
"field", "branch",
"columnName", "field" ),
"footcell_field5", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_checkbox", new XVar( "model", "headcell_checkbox",
"items", new XVar( 0, "grid_checkbox_head" ) ),
"cell_checkbox", new XVar( "model", "cell_checkbox",
"items", new XVar( 0, "grid_checkbox" ) ),
"footcell_checkbox", new XVar( "model", "footcell_checkbox",
"items", XVar.Array() ),
"headcell_icons", new XVar( "model", "headcell_icons",
"items", XVar.Array() ),
"cell_icons", new XVar( "model", "cell_icons",
"items", new XVar( 0, "grid_edit",
1, "grid_view" ) ),
"footcell_icons", new XVar( "model", "footcell_icons",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "page_size", new XVar( "type", "page_size" ),
"details_found", new XVar( "type", "details_found" ),
"breadcrumb", new XVar( "type", "breadcrumb" ),
"logo", new XVar( "type", "logo" ),
"menu", new XVar( "type", "menu" ),
"simple_search", new XVar( "type", "simple_search" ),
"pagination", new XVar( "type", "pagination" ),
"search_panel", new XVar( "type", "search_panel",
"items", new XVar( 0, "search_panel_field7",
1, "search_panel_field",
2, "search_panel_field8",
3, "search_panel_field6",
4, "search_panel_field4",
5, "search_panel_field2",
6, "search_panel_field1" ) ),
"list_options", new XVar( "type", "list_options",
"items", new XVar( 0, "export_selected",
1, "delete_selected",
2, "-3",
3, "advsearch_link",
4, "show_search_panel",
5, "hide_search_panel",
6, "-1",
7, "export",
8, "-2",
9, "import" ) ),
"show_search_panel", new XVar( "type", "show_search_panel" ),
"hide_search_panel", new XVar( "type", "hide_search_panel" ),
"search_panel_field1", new XVar( "field", "active",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"search_panel_field2", new XVar( "field", "email",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"search_panel_field4", new XVar( "field", "fullname",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"search_panel_field6", new XVar( "field", "password",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"search_panel_field7", new XVar( "field", "username",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"username_button", new XVar( "type", "username_button",
"items", new XVar( 0, "userinfo_link",
1, "logout_link",
2, "exit_adminarea_link" ) ),
"exit_adminarea_link", new XVar( "type", "exit_adminarea_link" ),
"userinfo_link", new XVar( "type", "userinfo_link" ),
"logout_link", new XVar( "type", "logout_link" ),
"expand_menu_button", new XVar( "type", "expand_menu_button" ),
"collapse_button", new XVar( "type", "collapse_button" ),
"add", new XVar( "type", "add" ),
"print_panel", new XVar( "type", "print_panel",
"items", new XVar( 0, "print_scope",
1, "print_records",
2, "print_button" ) ),
"print_scope", new XVar( "type", "print_scope" ),
"print_button", new XVar( "type", "print_button" ),
"print_records", new XVar( "type", "print_records" ),
"export", new XVar( "type", "export" ),
"-", new XVar( "type", "-" ),
"export_selected", new XVar( "type", "export_selected" ),
"-1", new XVar( "type", "-" ),
"import", new XVar( "type", "import" ),
"-2", new XVar( "type", "-" ),
"delete", new XVar( "type", "delete" ),
"delete_selected", new XVar( "type", "delete_selected" ),
"advsearch_link", new XVar( "type", "advsearch_link" ),
"-3", new XVar( "type", "-" ),
"search_panel_field", new XVar( "field", "groupPermission",
"type", "search_panel_field",
"alwaysOnPanel", false,
"required", false ),
"search_panel_field8", new XVar( "field", "branch",
"type", "search_panel_field",
"required", false,
"alwaysOnPanel", false ),
"simple_grid_field1", new XVar( "field", "username",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field2", new XVar( "type", "grid_field_label",
"field", "username" ),
"simple_grid_field3", new XVar( "field", "email",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field5", new XVar( "type", "grid_field_label",
"field", "email" ),
"simple_grid_field4", new XVar( "field", "fullname",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field8", new XVar( "type", "grid_field_label",
"field", "fullname" ),
"simple_grid_field6", new XVar( "field", "active",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field9", new XVar( "type", "grid_field_label",
"field", "active" ),
"simple_grid_field", new XVar( "field", "groupPermission",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field10", new XVar( "type", "grid_field_label",
"field", "groupPermission" ),
"simple_grid_field7", new XVar( "field", "branch",
"type", "grid_field",
"inlineAdd", false,
"inlineEdit", false ),
"simple_grid_field11", new XVar( "type", "grid_field_label",
"field", "branch" ),
"grid_checkbox", new XVar( "type", "grid_checkbox" ),
"grid_checkbox_head", new XVar( "type", "grid_checkbox_head" ),
"grid_edit", new XVar( "type", "grid_edit" ),
"grid_view", new XVar( "type", "grid_view" ),
"expand_button", new XVar( "type", "expand_button" ) ),
"dbProps", new XVar(  ),
"spreadsheetGrid", false,
"version", 13,
"imageItem", new XVar( "type", "page_image" ),
"imageBgColor", "#f2f2f2",
"controlsBgColor", "white",
"imagePosition", "right",
"listTotals", 1 );
				}
			}
		}