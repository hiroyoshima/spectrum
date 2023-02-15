
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
			public static partial class Options_rspdlineb_export
			{
				static public XVar options()
				{
					return new XVar( "totals", new XVar( "ID", new XVar( "totalsType", "" ),
"HdrID", new XVar( "totalsType", "" ),
"LOC_UNIT_STA_B", new XVar( "totalsType", "" ),
"LOC_STREET_STA_B", new XVar( "totalsType", "" ),
"LOC_BRGY_STA_B", new XVar( "totalsType", "" ),
"CITY/MUNICIPALITY_STA_B", new XVar( "totalsType", "" ),
"PROVINCE_STA_B", new XVar( "totalsType", "" ),
"ZIPCODE_STA_B", new XVar( "totalsType", "" ),
"eDegB", new XVar( "totalsType", "" ),
"eMinB", new XVar( "totalsType", "" ),
"eSecB", new XVar( "totalsType", "" ),
"nDegB", new XVar( "totalsType", "" ),
"nMinB", new XVar( "totalsType", "" ),
"nSecB", new XVar( "totalsType", "" ),
"elevationB", new XVar( "totalsType", "" ),
"aMakeTypeModelB", new XVar( "totalsType", "" ),
"gainB", new XVar( "totalsType", "" ),
"diameterB", new XVar( "totalsType", "" ),
"beamwidthB", new XVar( "totalsType", "" ),
"polarizationB", new XVar( "totalsType", "" ),
"azimuthB", new XVar( "totalsType", "" ),
"elevAngleB", new XVar( "totalsType", "" ),
"heightAGLB", new XVar( "totalsType", "" ),
"feederLengthB", new XVar( "totalsType", "" ),
"callSignB", new XVar( "totalsType", "" ) ),
"fields", new XVar( "gridFields", new XVar( 0, "ID",
1, "HdrID",
2, "LOC_UNIT_STA_B",
3, "LOC_STREET_STA_B",
4, "LOC_BRGY_STA_B",
5, "CITY/MUNICIPALITY_STA_B",
6, "PROVINCE_STA_B",
7, "ZIPCODE_STA_B",
8, "eDegB",
9, "eMinB",
10, "eSecB",
11, "nDegB",
12, "nMinB",
13, "nSecB",
14, "elevationB",
15, "aMakeTypeModelB",
16, "gainB",
17, "diameterB",
18, "beamwidthB",
19, "polarizationB",
20, "azimuthB",
21, "elevAngleB",
22, "heightAGLB",
23, "feederLengthB",
24, "callSignB" ),
"exportFields", new XVar( 0, "ID",
1, "HdrID",
2, "LOC_UNIT_STA_B",
3, "LOC_STREET_STA_B",
4, "LOC_BRGY_STA_B",
5, "CITY/MUNICIPALITY_STA_B",
6, "PROVINCE_STA_B",
7, "ZIPCODE_STA_B",
8, "eDegB",
9, "eMinB",
10, "eSecB",
11, "nDegB",
12, "nMinB",
13, "nSecB",
14, "elevationB",
15, "aMakeTypeModelB",
16, "gainB",
17, "diameterB",
18, "beamwidthB",
19, "polarizationB",
20, "azimuthB",
21, "elevAngleB",
22, "heightAGLB",
23, "feederLengthB",
24, "callSignB" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar( "ID", new XVar( 0, "export_field" ),
"HdrID", new XVar( 0, "export_field1" ),
"LOC_UNIT_STA_B", new XVar( 0, "export_field2" ),
"LOC_STREET_STA_B", new XVar( 0, "export_field3" ),
"LOC_BRGY_STA_B", new XVar( 0, "export_field4" ),
"CITY/MUNICIPALITY_STA_B", new XVar( 0, "export_field5" ),
"PROVINCE_STA_B", new XVar( 0, "export_field6" ),
"ZIPCODE_STA_B", new XVar( 0, "export_field7" ),
"eDegB", new XVar( 0, "export_field8" ),
"eMinB", new XVar( 0, "export_field9" ),
"eSecB", new XVar( 0, "export_field10" ),
"nDegB", new XVar( 0, "export_field11" ),
"nMinB", new XVar( 0, "export_field12" ),
"nSecB", new XVar( 0, "export_field13" ),
"elevationB", new XVar( 0, "export_field14" ),
"aMakeTypeModelB", new XVar( 0, "export_field15" ),
"gainB", new XVar( 0, "export_field16" ),
"diameterB", new XVar( 0, "export_field17" ),
"beamwidthB", new XVar( 0, "export_field18" ),
"polarizationB", new XVar( 0, "export_field19" ),
"azimuthB", new XVar( 0, "export_field20" ),
"elevAngleB", new XVar( 0, "export_field21" ),
"heightAGLB", new XVar( 0, "export_field22" ),
"feederLengthB", new XVar( 0, "export_field23" ),
"callSignB", new XVar( 0, "export_field24" ) ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "supertop", XVar.Array(),
"top", new XVar( 0, "export_header" ),
"grid", new XVar( 0, "export_field",
1, "export_field1",
2, "export_field2",
3, "export_field3",
4, "export_field4",
5, "export_field5",
6, "export_field6",
7, "export_field7",
8, "export_field8",
9, "export_field9",
10, "export_field10",
11, "export_field11",
12, "export_field12",
13, "export_field13",
14, "export_field14",
15, "export_field15",
16, "export_field16",
17, "export_field17",
18, "export_field18",
19, "export_field19",
20, "export_field20",
21, "export_field21",
22, "export_field22",
23, "export_field23",
24, "export_field24" ),
"footer", new XVar( 0, "export_export",
1, "export_cancel" ) ),
"formXtTags", new XVar( "supertop", XVar.Array() ),
"itemForms", new XVar( "export_header", "top",
"export_field", "grid",
"export_field1", "grid",
"export_field2", "grid",
"export_field3", "grid",
"export_field4", "grid",
"export_field5", "grid",
"export_field6", "grid",
"export_field7", "grid",
"export_field8", "grid",
"export_field9", "grid",
"export_field10", "grid",
"export_field11", "grid",
"export_field12", "grid",
"export_field13", "grid",
"export_field14", "grid",
"export_field15", "grid",
"export_field16", "grid",
"export_field17", "grid",
"export_field18", "grid",
"export_field19", "grid",
"export_field20", "grid",
"export_field21", "grid",
"export_field22", "grid",
"export_field23", "grid",
"export_field24", "grid",
"export_export", "footer",
"export_cancel", "footer" ),
"itemLocations", new XVar(  ),
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "export_header", new XVar( 0, "export_header" ),
"export_export", new XVar( 0, "export_export" ),
"export_cancel", new XVar( 0, "export_cancel" ),
"export_field", new XVar( 0, "export_field",
1, "export_field1",
2, "export_field2",
3, "export_field3",
4, "export_field4",
5, "export_field5",
6, "export_field6",
7, "export_field7",
8, "export_field8",
9, "export_field9",
10, "export_field10",
11, "export_field11",
12, "export_field12",
13, "export_field13",
14, "export_field14",
15, "export_field15",
16, "export_field16",
17, "export_field17",
18, "export_field18",
19, "export_field19",
20, "export_field20",
21, "export_field21",
22, "export_field22",
23, "export_field23",
24, "export_field24" ) ),
"cellMaps", new XVar(  ) ),
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
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"export", new XVar( "format", 2,
"selectFields", false,
"delimiter", ",",
"selectDelimiter", false,
"exportFileTypes", new XVar( "excel", true,
"word", true,
"csv", true,
"xml", false ) ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "export",
"type", "export",
"layoutId", "first",
"disabled", 0,
"default", 0,
"forms", new XVar( "supertop", new XVar( "modelId", "panel-top",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "export-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "export_header" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "export-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "export_field",
1, "export_field1",
2, "export_field2",
3, "export_field3",
4, "export_field4",
5, "export_field5",
6, "export_field6",
7, "export_field7",
8, "export_field8",
9, "export_field9",
10, "export_field10",
11, "export_field11",
12, "export_field12",
13, "export_field13",
14, "export_field14",
15, "export_field15",
16, "export_field16",
17, "export_field17",
18, "export_field18",
19, "export_field19",
20, "export_field20",
21, "export_field21",
22, "export_field22",
23, "export_field23",
24, "export_field24" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"footer", new XVar( "modelId", "export-footer",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "export_export",
1, "export_cancel" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "export_header", new XVar( "type", "export_header" ),
"export_export", new XVar( "type", "export_export" ),
"export_cancel", new XVar( "type", "export_cancel" ),
"export_field", new XVar( "field", "ID",
"type", "export_field" ),
"export_field1", new XVar( "field", "HdrID",
"type", "export_field" ),
"export_field2", new XVar( "field", "LOC_UNIT_STA_B",
"type", "export_field" ),
"export_field3", new XVar( "field", "LOC_STREET_STA_B",
"type", "export_field" ),
"export_field4", new XVar( "field", "LOC_BRGY_STA_B",
"type", "export_field" ),
"export_field5", new XVar( "field", "CITY/MUNICIPALITY_STA_B",
"type", "export_field" ),
"export_field6", new XVar( "field", "PROVINCE_STA_B",
"type", "export_field" ),
"export_field7", new XVar( "field", "ZIPCODE_STA_B",
"type", "export_field" ),
"export_field8", new XVar( "field", "eDegB",
"type", "export_field" ),
"export_field9", new XVar( "field", "eMinB",
"type", "export_field" ),
"export_field10", new XVar( "field", "eSecB",
"type", "export_field" ),
"export_field11", new XVar( "field", "nDegB",
"type", "export_field" ),
"export_field12", new XVar( "field", "nMinB",
"type", "export_field" ),
"export_field13", new XVar( "field", "nSecB",
"type", "export_field" ),
"export_field14", new XVar( "field", "elevationB",
"type", "export_field" ),
"export_field15", new XVar( "field", "aMakeTypeModelB",
"type", "export_field" ),
"export_field16", new XVar( "field", "gainB",
"type", "export_field" ),
"export_field17", new XVar( "field", "diameterB",
"type", "export_field" ),
"export_field18", new XVar( "field", "beamwidthB",
"type", "export_field" ),
"export_field19", new XVar( "field", "polarizationB",
"type", "export_field" ),
"export_field20", new XVar( "field", "azimuthB",
"type", "export_field" ),
"export_field21", new XVar( "field", "elevAngleB",
"type", "export_field" ),
"export_field22", new XVar( "field", "heightAGLB",
"type", "export_field" ),
"export_field23", new XVar( "field", "feederLengthB",
"type", "export_field" ),
"export_field24", new XVar( "field", "callSignB",
"type", "export_field" ) ),
"dbProps", new XVar(  ),
"version", 13,
"imageItem", new XVar( "type", "page_image" ),
"imageBgColor", "#f2f2f2",
"controlsBgColor", "white",
"imagePosition", "right",
"listTotals", 1,
"exportFormat", 2,
"exportDelimiter", ",",
"exportSelectDelimiter", false,
"exportSelectFields", false );
				}
			}
		}