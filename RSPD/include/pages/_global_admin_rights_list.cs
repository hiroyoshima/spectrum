
		// <global>
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
			public static partial class Options____global____admin_rights_list
			{
				static public XVar options()
				{
					return new XVar( "fields", new XVar( "gridFields", XVar.Array(),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar(  ) ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", new XVar( 0, "rights_save",
1, "rights_reset",
2, "rights_displaying_tables",
3, "rights_ordering_tables",
4, "rights_add_group",
5, "rights_del_group",
6, "rights_rename_group",
7, "rights_copy_permissions" ),
"below-grid", XVar.Array(),
"supertop", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "username_button" ),
"left", new XVar( 0, "logo",
1, "expand_button",
2, "menu" ),
"top", XVar.Array(),
"grid", new XVar( 0, "rights_search",
1, "rights_name_a",
2, "rights_name_e",
3, "rights_name_d",
4, "rights_name_s",
5, "rights_name_p",
6, "rights_name_i",
7, "rights_name_m",
8, "rights_name_m1",
9, "rights_checkbox_page",
10, "rights_page",
11, "rights_checkbox_page_a",
12, "rights_checkbox_page_e",
13, "rights_checkbox_page_d",
14, "rights_checkbox_page_s",
15, "rights_checkbox_page_p",
16, "rights_checkbox_page_i",
17, "rights_expand_all",
18, "rights_checkbox_all_a",
19, "rights_checkbox_all_e",
20, "rights_checkbox_all_d",
21, "rights_checkbox_all_s",
22, "rights_checkbox_all_p",
23, "rights_checkbox_all_i",
24, "rights_checkbox_all_m",
25, "rights_checkbox_table",
26, "rights_table",
27, "rights_show_pages",
28, "rights_hide_pages",
29, "rights_group_expander",
30, "rights_checkbox_a",
31, "rights_checkbox_e",
32, "rights_checkbox_d",
33, "rights_checkbox_s",
34, "rights_checkbox_p",
35, "rights_checkbox_i",
36, "rights_checkbox_m" ) ),
"formXtTags", new XVar( "below-grid", XVar.Array(),
"top", XVar.Array() ),
"itemForms", new XVar( "rights_save", "above-grid",
"rights_reset", "above-grid",
"rights_displaying_tables", "above-grid",
"rights_ordering_tables", "above-grid",
"rights_add_group", "above-grid",
"rights_del_group", "above-grid",
"rights_rename_group", "above-grid",
"rights_copy_permissions", "above-grid",
"expand_menu_button", "supertop",
"collapse_button", "supertop",
"username_button", "supertop",
"logo", "left",
"expand_button", "left",
"menu", "left",
"rights_search", "grid",
"rights_name_a", "grid",
"rights_name_e", "grid",
"rights_name_d", "grid",
"rights_name_s", "grid",
"rights_name_p", "grid",
"rights_name_i", "grid",
"rights_name_m", "grid",
"rights_name_m1", "grid",
"rights_checkbox_page", "grid",
"rights_page", "grid",
"rights_checkbox_page_a", "grid",
"rights_checkbox_page_e", "grid",
"rights_checkbox_page_d", "grid",
"rights_checkbox_page_s", "grid",
"rights_checkbox_page_p", "grid",
"rights_checkbox_page_i", "grid",
"rights_expand_all", "grid",
"rights_checkbox_all_a", "grid",
"rights_checkbox_all_e", "grid",
"rights_checkbox_all_d", "grid",
"rights_checkbox_all_s", "grid",
"rights_checkbox_all_p", "grid",
"rights_checkbox_all_i", "grid",
"rights_checkbox_all_m", "grid",
"rights_checkbox_table", "grid",
"rights_table", "grid",
"rights_show_pages", "grid",
"rights_hide_pages", "grid",
"rights_group_expander", "grid",
"rights_checkbox_a", "grid",
"rights_checkbox_e", "grid",
"rights_checkbox_d", "grid",
"rights_checkbox_s", "grid",
"rights_checkbox_p", "grid",
"rights_checkbox_i", "grid",
"rights_checkbox_m", "grid" ),
"itemLocations", new XVar(  ),
"itemVisiblity", new XVar( "expand_menu_button", 2,
"expand_button", 5 ) ),
"itemsByType", new XVar( "rights_save", new XVar( 0, "rights_save" ),
"rights_reset", new XVar( 0, "rights_reset" ),
"rights_displaying_tables", new XVar( 0, "rights_displaying_tables" ),
"rights_ordering_tables", new XVar( 0, "rights_ordering_tables" ),
"rights_add_group", new XVar( 0, "rights_add_group" ),
"rights_del_group", new XVar( 0, "rights_del_group" ),
"rights_rename_group", new XVar( 0, "rights_rename_group" ),
"rights_copy_permissions", new XVar( 0, "rights_copy_permissions" ),
"rights_search", new XVar( 0, "rights_search" ),
"rights_name_a", new XVar( 0, "rights_name_a" ),
"rights_name_e", new XVar( 0, "rights_name_e" ),
"rights_name_d", new XVar( 0, "rights_name_d" ),
"rights_name_s", new XVar( 0, "rights_name_s" ),
"rights_name_p", new XVar( 0, "rights_name_p" ),
"rights_name_i", new XVar( 0, "rights_name_i" ),
"rights_name_m", new XVar( 0, "rights_name_m" ),
"rights_name_m1", new XVar( 0, "rights_name_m1" ),
"rights_checkbox_page", new XVar( 0, "rights_checkbox_page" ),
"rights_page", new XVar( 0, "rights_page" ),
"rights_checkbox_page_a", new XVar( 0, "rights_checkbox_page_a" ),
"rights_checkbox_page_e", new XVar( 0, "rights_checkbox_page_e" ),
"rights_checkbox_page_d", new XVar( 0, "rights_checkbox_page_d" ),
"rights_checkbox_page_s", new XVar( 0, "rights_checkbox_page_s" ),
"rights_checkbox_page_p", new XVar( 0, "rights_checkbox_page_p" ),
"rights_checkbox_page_i", new XVar( 0, "rights_checkbox_page_i" ),
"rights_expand_all", new XVar( 0, "rights_expand_all" ),
"rights_checkbox_all_a", new XVar( 0, "rights_checkbox_all_a" ),
"rights_checkbox_all_e", new XVar( 0, "rights_checkbox_all_e" ),
"rights_checkbox_all_d", new XVar( 0, "rights_checkbox_all_d" ),
"rights_checkbox_all_s", new XVar( 0, "rights_checkbox_all_s" ),
"rights_checkbox_all_p", new XVar( 0, "rights_checkbox_all_p" ),
"rights_checkbox_all_i", new XVar( 0, "rights_checkbox_all_i" ),
"rights_checkbox_all_m", new XVar( 0, "rights_checkbox_all_m" ),
"rights_checkbox_table", new XVar( 0, "rights_checkbox_table" ),
"rights_table", new XVar( 0, "rights_table" ),
"rights_show_pages", new XVar( 0, "rights_show_pages" ),
"rights_hide_pages", new XVar( 0, "rights_hide_pages" ),
"rights_group_expander", new XVar( 0, "rights_group_expander" ),
"rights_checkbox_a", new XVar( 0, "rights_checkbox_a" ),
"rights_checkbox_e", new XVar( 0, "rights_checkbox_e" ),
"rights_checkbox_d", new XVar( 0, "rights_checkbox_d" ),
"rights_checkbox_s", new XVar( 0, "rights_checkbox_s" ),
"rights_checkbox_p", new XVar( 0, "rights_checkbox_p" ),
"rights_checkbox_i", new XVar( 0, "rights_checkbox_i" ),
"rights_checkbox_m", new XVar( 0, "rights_checkbox_m" ),
"userinfo_link", new XVar( 0, "userinfo_link" ),
"logout_link", new XVar( 0, "logout_link" ),
"exit_adminarea_link", new XVar( 0, "exit_adminarea_link" ),
"logo", new XVar( 0, "logo" ),
"menu", new XVar( 0, "menu" ),
"username_button", new XVar( 0, "username_button" ),
"expand_menu_button", new XVar( 0, "expand_menu_button" ),
"collapse_button", new XVar( 0, "collapse_button" ),
"expand_button", new XVar( 0, "expand_button" ) ),
"cellMaps", new XVar(  ) ),
"page", new XVar( "verticalBar", true,
"labeledButtons", new XVar( "update_records", new XVar(  ),
"print_pages", new XVar(  ),
"register_activate_message", new XVar(  ),
"details_found", new XVar(  ) ),
"hasCustomButtons", false,
"customButtons", XVar.Array(),
"hasNotifications", false,
"menus", new XVar( 0, new XVar( "id", "main",
"horizontal", false ) ),
"calcTotalsFor", 1 ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "admin_rights_list",
"type", "admin_rights_list",
"layoutId", "leftbar",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "admin-rights-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ),
1, new XVar( "cells", new XVar( 0, new XVar( "cell", "c4",
"colspan", 2 ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "rights_save",
1, "rights_reset" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "rights_displaying_tables",
1, "rights_ordering_tables" ) ),
"c4", new XVar( "model", "c4",
"items", new XVar( 0, "rights_add_group",
1, "rights_del_group",
2, "rights_rename_group",
3, "rights_copy_permissions" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "admin-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"supertop", new XVar( "modelId", "admin-leftbar-top",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "expand_menu_button",
1, "collapse_button" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "username_button" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"left", new XVar( "modelId", "admin-leftbar-menu",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c0" ) ),
"section", "" ),
1, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c0", new XVar( "model", "c0",
"items", new XVar( 0, "logo",
1, "expand_button" ) ),
"c1", new XVar( "model", "c1",
"items", new XVar( 0, "menu" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "admin-header",
"grid", XVar.Array(),
"cells", new XVar(  ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "admin-rights-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "headcell_search" ),
1, new XVar( "cell", "headcell_a" ),
2, new XVar( "cell", "headcell_e" ),
3, new XVar( "cell", "headcell_d" ),
4, new XVar( "cell", "headcell_s" ),
5, new XVar( "cell", "headcell_p" ),
6, new XVar( "cell", "headcell_i" ),
7, new XVar( "cell", "headcell_m" ) ),
"section", "head" ),
1, new XVar( "cells", new XVar( 0, new XVar( "cell", "headcell_expand" ),
1, new XVar( "cell", "headcell_all_a" ),
2, new XVar( "cell", "headcell_all_e" ),
3, new XVar( "cell", "headcell_all_d" ),
4, new XVar( "cell", "headcell_all_s" ),
5, new XVar( "cell", "headcell_all_p" ),
6, new XVar( "cell", "headcell_all_i" ),
7, new XVar( "cell", "headcell_all_m" ) ),
"section", "head" ),
2, new XVar( "cells", new XVar( 0, new XVar( "cell", "cell_table" ),
1, new XVar( "cell", "cell_a" ),
2, new XVar( "cell", "cell_e" ),
3, new XVar( "cell", "cell_d" ),
4, new XVar( "cell", "cell_s" ),
5, new XVar( "cell", "cell_p" ),
6, new XVar( "cell", "cell_i" ),
7, new XVar( "cell", "cell_m" ) ),
"section", "body" ),
3, new XVar( "cells", new XVar( 0, new XVar( "cell", "cell_page" ),
1, new XVar( "cell", "cell_page_a" ),
2, new XVar( "cell", "cell_page_e" ),
3, new XVar( "cell", "cell_page_d" ),
4, new XVar( "cell", "cell_page_s" ),
5, new XVar( "cell", "cell_page_p" ),
6, new XVar( "cell", "cell_page_i" ),
7, new XVar( "cell", "cell_page_m" ) ),
"section", "page" ) ),
"cells", new XVar( "headcell_search", new XVar( "model", "headcell_search",
"items", new XVar( 0, "rights_search" ) ),
"headcell_a", new XVar( "model", "headcell_a",
"items", new XVar( 0, "rights_name_a" ) ),
"headcell_e", new XVar( "model", "headcell_e",
"items", new XVar( 0, "rights_name_e" ) ),
"headcell_d", new XVar( "model", "headcell_d",
"items", new XVar( 0, "rights_name_d" ) ),
"headcell_s", new XVar( "model", "headcell_s",
"items", new XVar( 0, "rights_name_s" ) ),
"headcell_p", new XVar( "model", "headcell_p",
"items", new XVar( 0, "rights_name_p" ) ),
"headcell_i", new XVar( "model", "headcell_i",
"items", new XVar( 0, "rights_name_i" ) ),
"headcell_m", new XVar( "model", "headcell_m",
"items", new XVar( 0, "rights_name_m",
1, "rights_name_m1" ) ),
"cell_page", new XVar( "model", "cell_page",
"items", new XVar( 0, "rights_checkbox_page",
1, "rights_page" ) ),
"cell_page_a", new XVar( "model", "cell_page_a",
"items", new XVar( 0, "rights_checkbox_page_a" ),
"permission", "A" ),
"cell_page_e", new XVar( "model", "cell_page_e",
"items", new XVar( 0, "rights_checkbox_page_e" ),
"permission", "E" ),
"cell_page_d", new XVar( "model", "cell_page_d",
"items", new XVar( 0, "rights_checkbox_page_d" ),
"permission", "D" ),
"cell_page_s", new XVar( "model", "cell_page_s",
"items", new XVar( 0, "rights_checkbox_page_s" ),
"permission", "S" ),
"cell_page_p", new XVar( "model", "cell_page_p",
"items", new XVar( 0, "rights_checkbox_page_p" ),
"permission", "P" ),
"cell_page_i", new XVar( "model", "cell_page_i",
"items", new XVar( 0, "rights_checkbox_page_i" ),
"permission", "I" ),
"cell_page_m", new XVar( "model", "cell_page_m",
"items", XVar.Array() ),
"headcell_expand", new XVar( "model", "headcell_expand",
"items", new XVar( 0, "rights_expand_all" ) ),
"headcell_all_a", new XVar( "model", "headcell_all_a",
"items", new XVar( 0, "rights_checkbox_all_a" ),
"permission", "A" ),
"headcell_all_e", new XVar( "model", "headcell_all_e",
"items", new XVar( 0, "rights_checkbox_all_e" ),
"permission", "E" ),
"headcell_all_d", new XVar( "model", "headcell_all_d",
"items", new XVar( 0, "rights_checkbox_all_d" ),
"permission", "D" ),
"headcell_all_s", new XVar( "model", "headcell_all_s",
"items", new XVar( 0, "rights_checkbox_all_s" ),
"permission", "S" ),
"headcell_all_p", new XVar( "model", "headcell_all_p",
"items", new XVar( 0, "rights_checkbox_all_p" ),
"permission", "P" ),
"headcell_all_i", new XVar( "model", "headcell_all_i",
"items", new XVar( 0, "rights_checkbox_all_i" ),
"permission", "I" ),
"headcell_all_m", new XVar( "model", "headcell_all_m",
"items", new XVar( 0, "rights_checkbox_all_m" ),
"permission", "M" ),
"cell_table", new XVar( "model", "cell_table",
"items", new XVar( 0, "rights_checkbox_table",
1, "rights_table",
2, "rights_show_pages",
3, "rights_hide_pages",
4, "rights_group_expander" ) ),
"cell_a", new XVar( "model", "cell_a",
"items", new XVar( 0, "rights_checkbox_a" ),
"permission", "A" ),
"cell_e", new XVar( "model", "cell_e",
"items", new XVar( 0, "rights_checkbox_e" ),
"permission", "E" ),
"cell_d", new XVar( "model", "cell_d",
"items", new XVar( 0, "rights_checkbox_d" ),
"permission", "D" ),
"cell_s", new XVar( "model", "cell_s",
"items", new XVar( 0, "rights_checkbox_s" ),
"permission", "S" ),
"cell_p", new XVar( "model", "cell_p",
"items", new XVar( 0, "rights_checkbox_p" ),
"permission", "P" ),
"cell_i", new XVar( "model", "cell_i",
"items", new XVar( 0, "rights_checkbox_i" ),
"permission", "I" ),
"cell_m", new XVar( "model", "cell_m",
"items", new XVar( 0, "rights_checkbox_m" ),
"permission", "M" ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "rights_save", new XVar( "type", "rights_save" ),
"rights_reset", new XVar( "type", "rights_reset" ),
"rights_displaying_tables", new XVar( "type", "rights_displaying_tables" ),
"rights_ordering_tables", new XVar( "type", "rights_ordering_tables" ),
"rights_add_group", new XVar( "type", "rights_add_group" ),
"rights_del_group", new XVar( "type", "rights_del_group" ),
"rights_rename_group", new XVar( "type", "rights_rename_group" ),
"rights_copy_permissions", new XVar( "type", "rights_copy_permissions" ),
"rights_search", new XVar( "type", "rights_search" ),
"rights_name_a", new XVar( "type", "rights_name_a" ),
"rights_name_e", new XVar( "type", "rights_name_e" ),
"rights_name_d", new XVar( "type", "rights_name_d" ),
"rights_name_s", new XVar( "type", "rights_name_s" ),
"rights_name_p", new XVar( "type", "rights_name_p" ),
"rights_name_i", new XVar( "type", "rights_name_i" ),
"rights_name_m", new XVar( "type", "rights_name_m" ),
"rights_name_m1", new XVar( "type", "rights_name_m1" ),
"rights_checkbox_page", new XVar( "type", "rights_checkbox_page" ),
"rights_page", new XVar( "type", "rights_page" ),
"rights_checkbox_page_a", new XVar( "type", "rights_checkbox_page_a" ),
"rights_checkbox_page_e", new XVar( "type", "rights_checkbox_page_e" ),
"rights_checkbox_page_d", new XVar( "type", "rights_checkbox_page_d" ),
"rights_checkbox_page_s", new XVar( "type", "rights_checkbox_page_s" ),
"rights_checkbox_page_p", new XVar( "type", "rights_checkbox_page_p" ),
"rights_checkbox_page_i", new XVar( "type", "rights_checkbox_page_i" ),
"rights_expand_all", new XVar( "type", "rights_expand_all" ),
"rights_checkbox_all_a", new XVar( "type", "rights_checkbox_all_a" ),
"rights_checkbox_all_e", new XVar( "type", "rights_checkbox_all_e" ),
"rights_checkbox_all_d", new XVar( "type", "rights_checkbox_all_d" ),
"rights_checkbox_all_s", new XVar( "type", "rights_checkbox_all_s" ),
"rights_checkbox_all_p", new XVar( "type", "rights_checkbox_all_p" ),
"rights_checkbox_all_i", new XVar( "type", "rights_checkbox_all_i" ),
"rights_checkbox_all_m", new XVar( "type", "rights_checkbox_all_m" ),
"rights_checkbox_table", new XVar( "type", "rights_checkbox_table" ),
"rights_table", new XVar( "type", "rights_table" ),
"rights_show_pages", new XVar( "type", "rights_show_pages" ),
"rights_hide_pages", new XVar( "type", "rights_hide_pages" ),
"rights_group_expander", new XVar( "type", "rights_group_expander" ),
"rights_checkbox_a", new XVar( "type", "rights_checkbox_a" ),
"rights_checkbox_e", new XVar( "type", "rights_checkbox_e" ),
"rights_checkbox_d", new XVar( "type", "rights_checkbox_d" ),
"rights_checkbox_s", new XVar( "type", "rights_checkbox_s" ),
"rights_checkbox_p", new XVar( "type", "rights_checkbox_p" ),
"rights_checkbox_i", new XVar( "type", "rights_checkbox_i" ),
"rights_checkbox_m", new XVar( "type", "rights_checkbox_m" ),
"userinfo_link", new XVar( "type", "userinfo_link" ),
"logout_link", new XVar( "type", "logout_link" ),
"exit_adminarea_link", new XVar( "type", "exit_adminarea_link" ),
"logo", new XVar( "type", "logo" ),
"menu", new XVar( "type", "menu" ),
"username_button", new XVar( "type", "username_button",
"items", new XVar( 0, "userinfo_link",
1, "logout_link",
2, "exit_adminarea_link" ) ),
"expand_menu_button", new XVar( "type", "expand_menu_button" ),
"collapse_button", new XVar( "type", "collapse_button" ),
"expand_button", new XVar( "type", "expand_button" ) ),
"dbProps", new XVar(  ),
"version", 13,
"imageItem", new XVar( "type", "page_image" ),
"imageBgColor", "#f2f2f2",
"controlsBgColor", "white",
"imagePosition", "right",
"listTotals", 1 );
				}
			}
		}