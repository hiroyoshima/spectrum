
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
			public static partial class Options_rspdlinea_view
			{
				static public XVar options()
				{
					return new XVar( "pdf", new XVar( "pdfView", false ),
"fields", new XVar( "gridFields", new XVar( 0, "ID",
1, "HdrID",
2, "LOC_UNIT_STA_A",
3, "LOC_STREET_STA_A",
4, "LOC_BRGY_STA_A",
5, "CITY/MUNICIPALITY_STA_A",
6, "PROVINCE_STA_A",
7, "ZIPCODE_STA_A",
8, "eDegA",
9, "eMinA",
10, "eSecA",
11, "nDegA",
12, "nMinA",
13, "nSecA",
14, "elevationA",
15, "aMakeTypeModelA",
16, "gainA",
17, "diameterA",
18, "beamwidthA",
19, "polarizationA",
20, "azimuthA",
21, "elevAngleA",
22, "heightAGLA",
23, "feederLengthA",
24, "callSignA" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar( "ID", new XVar( 0, "integrated_edit_field" ),
"HdrID", new XVar( 0, "integrated_edit_field1" ),
"LOC_UNIT_STA_A", new XVar( 0, "integrated_edit_field2" ),
"LOC_STREET_STA_A", new XVar( 0, "integrated_edit_field3" ),
"LOC_BRGY_STA_A", new XVar( 0, "integrated_edit_field4" ),
"CITY/MUNICIPALITY_STA_A", new XVar( 0, "integrated_edit_field5" ),
"PROVINCE_STA_A", new XVar( 0, "integrated_edit_field6" ),
"ZIPCODE_STA_A", new XVar( 0, "integrated_edit_field7" ),
"eDegA", new XVar( 0, "integrated_edit_field8" ),
"eMinA", new XVar( 0, "integrated_edit_field9" ),
"eSecA", new XVar( 0, "integrated_edit_field10" ),
"nDegA", new XVar( 0, "integrated_edit_field11" ),
"nMinA", new XVar( 0, "integrated_edit_field12" ),
"nSecA", new XVar( 0, "integrated_edit_field13" ),
"elevationA", new XVar( 0, "integrated_edit_field14" ),
"aMakeTypeModelA", new XVar( 0, "integrated_edit_field15" ),
"gainA", new XVar( 0, "integrated_edit_field16" ),
"diameterA", new XVar( 0, "integrated_edit_field17" ),
"beamwidthA", new XVar( 0, "integrated_edit_field18" ),
"polarizationA", new XVar( 0, "integrated_edit_field19" ),
"azimuthA", new XVar( 0, "integrated_edit_field20" ),
"elevAngleA", new XVar( 0, "integrated_edit_field21" ),
"heightAGLA", new XVar( 0, "integrated_edit_field22" ),
"feederLengthA", new XVar( 0, "integrated_edit_field23" ),
"callSignA", new XVar( 0, "integrated_edit_field24" ) ) ),
"pageLinks", new XVar( "edit", true,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", XVar.Array(),
"below-grid", new XVar( 0, "view_back_list",
1, "view_close",
2, "hamburger" ),
"top", new XVar( 0, "view_header" ),
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
23, "integrated_edit_field23",
24, "integrated_edit_field24" ) ),
"formXtTags", new XVar( "above-grid", XVar.Array() ),
"itemForms", new XVar( "view_back_list", "below-grid",
"view_close", "below-grid",
"hamburger", "below-grid",
"view_header", "top",
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
"integrated_edit_field23", "grid",
"integrated_edit_field24", "grid" ),
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
"cellId", "c3" ),
"integrated_edit_field24", new XVar( "location", "grid",
"cellId", "c3" ) ),
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "view_header", new XVar( 0, "view_header" ),
"view_back_list", new XVar( 0, "view_back_list" ),
"view_close", new XVar( 0, "view_close" ),
"hamburger", new XVar( 0, "hamburger" ),
"view_edit", new XVar( 0, "view_edit" ),
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
23, "integrated_edit_field23",
24, "integrated_edit_field24" ) ),
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
23, "integrated_edit_field23",
24, "integrated_edit_field24" ),
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
"misc", new XVar( "type", "view",
"breadcrumb", false,
"nextPrev", false ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "view",
"type", "view",
"layoutId", "nomenu",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "view-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1",
"colspan", 2 ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "view-below-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "view_back_list",
1, "view_close" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "hamburger" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "view-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "view_header" ) ) ),
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
23, "integrated_edit_field23",
24, "integrated_edit_field24" ) ) ),
"deferredItems", XVar.Array(),
"columnCount", 1,
"inlineLabels", false,
"separateLabels", false ) ),
"items", new XVar( "view_header", new XVar( "type", "view_header" ),
"view_back_list", new XVar( "type", "view_back_list" ),
"view_close", new XVar( "type", "view_close" ),
"hamburger", new XVar( "type", "hamburger",
"items", new XVar( 0, "view_edit" ) ),
"view_edit", new XVar( "type", "view_edit" ),
"integrated_edit_field", new XVar( "field", "ID",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field1", new XVar( "field", "HdrID",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field2", new XVar( "field", "LOC_UNIT_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field3", new XVar( "field", "LOC_STREET_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field4", new XVar( "field", "LOC_BRGY_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field5", new XVar( "field", "CITY/MUNICIPALITY_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field6", new XVar( "field", "PROVINCE_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field7", new XVar( "field", "ZIPCODE_STA_A",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field8", new XVar( "field", "eDegA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field9", new XVar( "field", "eMinA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field10", new XVar( "field", "eSecA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field11", new XVar( "field", "nDegA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field12", new XVar( "field", "nMinA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field13", new XVar( "field", "nSecA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field14", new XVar( "field", "elevationA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field15", new XVar( "field", "aMakeTypeModelA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field16", new XVar( "field", "gainA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field17", new XVar( "field", "diameterA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field18", new XVar( "field", "beamwidthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field19", new XVar( "field", "polarizationA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field20", new XVar( "field", "azimuthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field21", new XVar( "field", "elevAngleA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field22", new XVar( "field", "heightAGLA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field23", new XVar( "field", "feederLengthA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field24", new XVar( "field", "callSignA",
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