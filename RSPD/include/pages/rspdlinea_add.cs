
		// dbo.rspdLineA
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
			public static partial class Options_rspdlinea_add
			{
				static public XVar options()
				{
					return new XVar( "captcha", new XVar( "captcha", false ),
"fields", new XVar( "gridFields", new XVar( 0, "HdrID",
1, "LOC_UNIT_STA_A",
2, "LOC_STREET_STA_A",
3, "LOC_BRGY_STA_A",
4, "CITY/MUNICIPALITY_STA_A",
5, "PROVINCE_STA_A",
6, "ZIPCODE_STA_A",
7, "eDegA",
8, "eMinA",
9, "eSecA",
10, "nDegA",
11, "nMinA",
12, "nSecA",
13, "elevationA",
14, "aMakeTypeModelA",
15, "gainA",
16, "diameterA",
17, "beamwidthA",
18, "polarizationA",
19, "azimuthA",
20, "elevAngleA",
21, "heightAGLA",
22, "feederLengthA",
23, "callSignA" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar( "HdrID", new XVar( 0, "integrated_edit_field" ),
"LOC_UNIT_STA_A", new XVar( 0, "integrated_edit_field1" ),
"LOC_STREET_STA_A", new XVar( 0, "integrated_edit_field2" ),
"LOC_BRGY_STA_A", new XVar( 0, "integrated_edit_field3" ),
"CITY/MUNICIPALITY_STA_A", new XVar( 0, "integrated_edit_field4" ),
"PROVINCE_STA_A", new XVar( 0, "integrated_edit_field5" ),
"ZIPCODE_STA_A", new XVar( 0, "integrated_edit_field6" ),
"eDegA", new XVar( 0, "integrated_edit_field7" ),
"eMinA", new XVar( 0, "integrated_edit_field8" ),
"eSecA", new XVar( 0, "integrated_edit_field9" ),
"nDegA", new XVar( 0, "integrated_edit_field10" ),
"nMinA", new XVar( 0, "integrated_edit_field11" ),
"nSecA", new XVar( 0, "integrated_edit_field12" ),
"elevationA", new XVar( 0, "integrated_edit_field13" ),
"aMakeTypeModelA", new XVar( 0, "integrated_edit_field14" ),
"gainA", new XVar( 0, "integrated_edit_field15" ),
"diameterA", new XVar( 0, "integrated_edit_field16" ),
"beamwidthA", new XVar( 0, "integrated_edit_field17" ),
"polarizationA", new XVar( 0, "integrated_edit_field18" ),
"azimuthA", new XVar( 0, "integrated_edit_field19" ),
"elevAngleA", new XVar( 0, "integrated_edit_field20" ),
"heightAGLA", new XVar( 0, "integrated_edit_field21" ),
"feederLengthA", new XVar( 0, "integrated_edit_field22" ),
"callSignA", new XVar( 0, "integrated_edit_field23" ) ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", new XVar( 0, "add_message" ),
"below-grid", new XVar( 0, "add_save",
1, "add_reset",
2, "add_back_list",
3, "add_cancel" ),
"supertop", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "loginform_login",
3, "username_button" ),
"left", new XVar( 0, "logo",
1, "expand_button",
2, "menu" ),
"top", new XVar( 0, "add_header" ),
"grid", new XVar( 0, "integrated_edit_field",
1, "integrated_edit_field1",
2, "integrated_edit_field2",
3, "integrated_edit_field3",
4, "integrated_edit_field4",
5, "integrated_edit_field5",
6, "integrated_edit_field6",
7, "integrated_edit_field7",
8, "integrated_edit_field8",
9, "integrated_edit_field9",
10, "integrated_edit_field10",
11, "integrated_edit_field11",
12, "integrated_edit_field12",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field17",
18, "integrated_edit_field18",
19, "integrated_edit_field19",
20, "integrated_edit_field20",
21, "integrated_edit_field21",
22, "integrated_edit_field22",
23, "integrated_edit_field23" ) ),
"formXtTags", new XVar( "above-grid", new XVar( 0, "message_block" ) ),
"itemForms", new XVar( "add_message", "above-grid",
"add_save", "below-grid",
"add_reset", "below-grid",
"add_back_list", "below-grid",
"add_cancel", "below-grid",
"expand_menu_button", "supertop",
"collapse_button", "supertop",
"loginform_login", "supertop",
"username_button", "supertop",
"logo", "left",
"expand_button", "left",
"menu", "left",
"add_header", "top",
"integrated_edit_field", "grid",
"integrated_edit_field1", "grid",
"integrated_edit_field2", "grid",
"integrated_edit_field3", "grid",
"integrated_edit_field4", "grid",
"integrated_edit_field5", "grid",
"integrated_edit_field6", "grid",
"integrated_edit_field7", "grid",
"integrated_edit_field8", "grid",
"integrated_edit_field9", "grid",
"integrated_edit_field10", "grid",
"integrated_edit_field11", "grid",
"integrated_edit_field12", "grid",
"integrated_edit_field13", "grid",
"integrated_edit_field14", "grid",
"integrated_edit_field15", "grid",
"integrated_edit_field16", "grid",
"integrated_edit_field17", "grid",
"integrated_edit_field18", "grid",
"integrated_edit_field19", "grid",
"integrated_edit_field20", "grid",
"integrated_edit_field21", "grid",
"integrated_edit_field22", "grid",
"integrated_edit_field23", "grid" ),
"itemLocations", new XVar( "integrated_edit_field", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field1", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field2", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field3", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field4", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field5", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field6", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field7", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field8", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field9", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field10", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field11", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field12", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field13", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field14", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field15", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field16", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field17", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field18", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field19", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field20", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field21", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field22", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field23", new XVar( "location", "grid",
"cellId", "c3" ) ),
"itemVisiblity", new XVar( "expand_menu_button", 2,
"expand_button", 5 ) ),
"itemsByType", new XVar( "add_header", new XVar( 0, "add_header" ),
"add_back_list", new XVar( 0, "add_back_list" ),
"add_cancel", new XVar( 0, "add_cancel" ),
"add_message", new XVar( 0, "add_message" ),
"add_save", new XVar( 0, "add_save" ),
"add_reset", new XVar( 0, "add_reset" ),
"logo", new XVar( 0, "logo" ),
"menu", new XVar( 0, "menu" ),
"username_button", new XVar( 0, "username_button" ),
"loginform_login", new XVar( 0, "loginform_login" ),
"userinfo_link", new XVar( 0, "userinfo_link" ),
"logout_link", new XVar( 0, "logout_link" ),
"adminarea_link", new XVar( 0, "adminarea_link" ),
"expand_menu_button", new XVar( 0, "expand_menu_button" ),
"collapse_button", new XVar( 0, "collapse_button" ),
"integrated_edit_field", new XVar( 0, "integrated_edit_field",
1, "integrated_edit_field1",
2, "integrated_edit_field2",
3, "integrated_edit_field3",
4, "integrated_edit_field4",
5, "integrated_edit_field5",
6, "integrated_edit_field6",
7, "integrated_edit_field7",
8, "integrated_edit_field8",
9, "integrated_edit_field9",
10, "integrated_edit_field10",
11, "integrated_edit_field11",
12, "integrated_edit_field12",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field17",
18, "integrated_edit_field18",
19, "integrated_edit_field19",
20, "integrated_edit_field20",
21, "integrated_edit_field21",
22, "integrated_edit_field22",
23, "integrated_edit_field23" ),
"expand_button", new XVar( 0, "expand_button" ) ),
"cellMaps", new XVar( "grid", new XVar( "cells", new XVar( "c3", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 0 ),
"tags", XVar.Array(),
"items", new XVar( 0, "integrated_edit_field",
1, "integrated_edit_field1",
2, "integrated_edit_field2",
3, "integrated_edit_field3",
4, "integrated_edit_field4",
5, "integrated_edit_field5",
6, "integrated_edit_field6",
7, "integrated_edit_field7",
8, "integrated_edit_field8",
9, "integrated_edit_field9",
10, "integrated_edit_field10",
11, "integrated_edit_field11",
12, "integrated_edit_field12",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field17",
18, "integrated_edit_field18",
19, "integrated_edit_field19",
20, "integrated_edit_field20",
21, "integrated_edit_field21",
22, "integrated_edit_field22",
23, "integrated_edit_field23" ),
"fixedAtServer", true,
"fixedAtClient", false ) ),
"width", 1,
"height", 1 ) ) ),
"loginForm", new XVar( "loginForm", 0 ),
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
"misc", new XVar( "type", "add",
"breadcrumb", false ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "add",
"type", "add",
"layoutId", "leftbar",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "add-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "add_message" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "add-below-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "add_save",
1, "add_reset",
2, "add_back_list",
3, "add_cancel" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"supertop", new XVar( "modelId", "leftbar-top-edit",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "expand_menu_button",
1, "collapse_button" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "loginform_login",
1, "username_button" ) ) ),
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
"items", new XVar( 0, "menu" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "add-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "add_header" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "simple-edit",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c3" ) ),
"section", "" ) ),
"cells", new XVar( "c3", new XVar( "model", "c3",
"items", new XVar( 0, "integrated_edit_field",
1, "integrated_edit_field1",
2, "integrated_edit_field2",
3, "integrated_edit_field3",
4, "integrated_edit_field4",
5, "integrated_edit_field5",
6, "integrated_edit_field6",
7, "integrated_edit_field7",
8, "integrated_edit_field8",
9, "integrated_edit_field9",
10, "integrated_edit_field10",
11, "integrated_edit_field11",
12, "integrated_edit_field12",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field17",
18, "integrated_edit_field18",
19, "integrated_edit_field19",
20, "integrated_edit_field20",
21, "integrated_edit_field21",
22, "integrated_edit_field22",
23, "integrated_edit_field23" ) ) ),
"deferredItems", XVar.Array(),
"columnCount", 1,
"inlineLabels", false,
"separateLabels", false ) ),
"items", new XVar( "add_header", new XVar( "type", "add_header" ),
"add_back_list", new XVar( "type", "add_back_list" ),
"add_cancel", new XVar( "type", "add_cancel" ),
"add_message", new XVar( "type", "add_message" ),
"add_save", new XVar( "type", "add_save" ),
"add_reset", new XVar( "type", "add_reset" ),
"logo", new XVar( "type", "logo" ),
"menu", new XVar( "type", "menu" ),
"username_button", new XVar( "type", "username_button",
"items", new XVar( 0, "userinfo_link",
1, "logout_link",
2, "adminarea_link" ) ),
"loginform_login", new XVar( "type", "loginform_login",
"popup", false ),
"userinfo_link", new XVar( "type", "userinfo_link" ),
"logout_link", new XVar( "type", "logout_link" ),
"adminarea_link", new XVar( "type", "adminarea_link" ),
"expand_menu_button", new XVar( "type", "expand_menu_button" ),
"collapse_button", new XVar( "type", "collapse_button" ),
"integrated_edit_field", new XVar( "field", "HdrID",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field1", new XVar( "field", "LOC_UNIT_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field2", new XVar( "field", "LOC_STREET_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field3", new XVar( "field", "LOC_BRGY_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field4", new XVar( "field", "CITY/MUNICIPALITY_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field5", new XVar( "field", "PROVINCE_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field6", new XVar( "field", "ZIPCODE_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field7", new XVar( "field", "eDegA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field8", new XVar( "field", "eMinA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field9", new XVar( "field", "eSecA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field10", new XVar( "field", "nDegA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field11", new XVar( "field", "nMinA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field12", new XVar( "field", "nSecA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field13", new XVar( "field", "elevationA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field14", new XVar( "field", "aMakeTypeModelA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field15", new XVar( "field", "gainA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field16", new XVar( "field", "diameterA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field17", new XVar( "field", "beamwidthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field18", new XVar( "field", "polarizationA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field19", new XVar( "field", "azimuthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field20", new XVar( "field", "elevAngleA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field21", new XVar( "field", "heightAGLA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field22", new XVar( "field", "feederLengthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field23", new XVar( "field", "callSignA",
"type", "integrated_edit_field",
"orientation", 0 ),
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