
		// dbo.rspdLineB
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
			public static partial class Options_rspdlineb_edit
			{
				static public XVar options()
				{
					return new XVar( "master", new XVar( "dbo.rspdHeader", new XVar( "preview", false ) ),
"captcha", new XVar( "captcha", false ),
"fields", new XVar( "gridFields", new XVar( 0, "HdrID",
1, "LOC_UNIT_STA_B",
2, "LOC_STREET_STA_B",
3, "LOC_BRGY_STA_B",
4, "CITY/MUNICIPALITY_STA_B",
5, "PROVINCE_STA_B",
6, "ZIPCODE_STA_B",
7, "eDegB",
8, "eMinB",
9, "eSecB",
10, "nDegB",
11, "nMinB",
12, "nSecB",
13, "elevationB",
14, "aMakeTypeModelB",
15, "gainB",
16, "diameterB",
17, "beamwidthB",
18, "polarizationB",
19, "azimuthB",
20, "elevAngleB",
21, "heightAGLB",
22, "feederLengthB",
23, "callSignB" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"updateOnEditFields", XVar.Array(),
"fieldItems", new XVar( "HdrID", new XVar( 0, "integrated_edit_field" ),
"LOC_UNIT_STA_B", new XVar( 0, "integrated_edit_field1" ),
"LOC_STREET_STA_B", new XVar( 0, "integrated_edit_field2" ),
"LOC_BRGY_STA_B", new XVar( 0, "integrated_edit_field3" ),
"CITY/MUNICIPALITY_STA_B", new XVar( 0, "integrated_edit_field4" ),
"PROVINCE_STA_B", new XVar( 0, "integrated_edit_field5" ),
"ZIPCODE_STA_B", new XVar( 0, "integrated_edit_field6" ),
"eDegB", new XVar( 0, "integrated_edit_field7" ),
"eMinB", new XVar( 0, "integrated_edit_field8" ),
"eSecB", new XVar( 0, "integrated_edit_field9" ),
"nDegB", new XVar( 0, "integrated_edit_field10" ),
"nMinB", new XVar( 0, "integrated_edit_field11" ),
"nSecB", new XVar( 0, "integrated_edit_field12" ),
"elevationB", new XVar( 0, "integrated_edit_field13" ),
"aMakeTypeModelB", new XVar( 0, "integrated_edit_field14" ),
"gainB", new XVar( 0, "integrated_edit_field15" ),
"diameterB", new XVar( 0, "integrated_edit_field16" ),
"beamwidthB", new XVar( 0, "integrated_edit_field17" ),
"polarizationB", new XVar( 0, "integrated_edit_field18" ),
"azimuthB", new XVar( 0, "integrated_edit_field19" ),
"elevAngleB", new XVar( 0, "integrated_edit_field20" ),
"heightAGLB", new XVar( 0, "integrated_edit_field21" ),
"feederLengthB", new XVar( 0, "integrated_edit_field22" ),
"callSignB", new XVar( 0, "integrated_edit_field23" ) ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", true,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", new XVar( 0, "edit_message" ),
"below-grid", new XVar( 0, "edit_save",
1, "edit_back_list",
2, "edit_close",
3, "hamburger" ),
"top", new XVar( 0, "edit_header" ),
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
"itemForms", new XVar( "edit_message", "above-grid",
"edit_save", "below-grid",
"edit_back_list", "below-grid",
"edit_close", "below-grid",
"hamburger", "below-grid",
"edit_header", "top",
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
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "edit_header", new XVar( 0, "edit_header" ),
"hamburger", new XVar( 0, "hamburger" ),
"edit_reset", new XVar( 0, "edit_reset" ),
"edit_message", new XVar( 0, "edit_message" ),
"edit_save", new XVar( 0, "edit_save" ),
"edit_back_list", new XVar( 0, "edit_back_list" ),
"edit_close", new XVar( 0, "edit_close" ),
"edit_view", new XVar( 0, "edit_view" ),
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
23, "integrated_edit_field23" ) ),
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
"loginForm", new XVar( "loginForm", 3 ),
"page", new XVar( "verticalBar", false,
"labeledButtons", new XVar( "update_records", new XVar(  ),
"print_pages", new XVar(  ),
"register_activate_message", new XVar(  ),
"details_found", new XVar(  ) ),
"hasCustomButtons", false,
"customButtons", XVar.Array(),
"hasNotifications", false,
"menus", XVar.Array(),
"calcTotalsFor", 1 ),
"misc", new XVar( "type", "edit",
"breadcrumb", false,
"nextPrev", false ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"edit", new XVar( "updateSelected", false ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "edit",
"type", "edit",
"layoutId", "nomenu",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "edit-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "edit_message" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "edit-below-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "edit_save",
1, "edit_back_list",
2, "edit_close" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "hamburger" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "edit-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "edit_header" ) ) ),
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
"items", new XVar( "edit_header", new XVar( "type", "edit_header" ),
"hamburger", new XVar( "type", "hamburger",
"items", new XVar( 0, "edit_reset",
1, "edit_view" ) ),
"edit_reset", new XVar( "type", "edit_reset" ),
"edit_message", new XVar( "type", "edit_message" ),
"edit_save", new XVar( "type", "edit_save" ),
"edit_back_list", new XVar( "type", "edit_back_list" ),
"edit_close", new XVar( "type", "edit_close" ),
"edit_view", new XVar( "type", "edit_view" ),
"integrated_edit_field", new XVar( "field", "HdrID",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field1", new XVar( "field", "LOC_UNIT_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field2", new XVar( "field", "LOC_STREET_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field3", new XVar( "field", "LOC_BRGY_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field4", new XVar( "field", "CITY/MUNICIPALITY_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field5", new XVar( "field", "PROVINCE_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field6", new XVar( "field", "ZIPCODE_STA_B",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field7", new XVar( "field", "eDegB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field8", new XVar( "field", "eMinB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field9", new XVar( "field", "eSecB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field10", new XVar( "field", "nDegB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field11", new XVar( "field", "nMinB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field12", new XVar( "field", "nSecB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field13", new XVar( "field", "elevationB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field14", new XVar( "field", "aMakeTypeModelB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field15", new XVar( "field", "gainB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field16", new XVar( "field", "diameterB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field17", new XVar( "field", "beamwidthB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field18", new XVar( "field", "polarizationB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field19", new XVar( "field", "azimuthB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field20", new XVar( "field", "elevAngleB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field21", new XVar( "field", "heightAGLB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field22", new XVar( "field", "feederLengthB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field23", new XVar( "field", "callSignB",
"type", "integrated_edit_field",
"orientation", 0 ) ),
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