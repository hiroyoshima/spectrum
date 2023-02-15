
		// applicationUnderAssessment
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
			public static partial class Options_applicationunderassessment_import
			{
				static public XVar options()
				{
					return new XVar( "fields", new XVar( "gridFields", new XVar( 0, "companyNameA",
1, "siteNameA",
2, "siteNameB",
3, "elevationA",
4, "elevationB",
5, "makeTypeModelA",
6, "gainA",
7, "diameterA",
8, "beamwidthA",
9, "polarizationA",
10, "azimuthA",
11, "elevAngleA",
12, "heightAGLA",
13, "feederLengthA",
14, "makeTypeModelB",
15, "gainB",
16, "diameterB",
17, "beamwidthB",
18, "polarizationB",
19, "azimuthB",
20, "elevAngleB",
21, "heightAGLB",
22, "feederLengthB",
23, "longtitudeA",
24, "longtitudeB",
25, "latitudeA",
26, "latitudeB",
27, "callSignA",
28, "callSignB",
29, "applicationType",
30, "unit_a",
31, "street_a",
32, "barangay_a",
33, "city_a",
34, "province_a",
35, "zipcode_a",
36, "unit_b",
37, "street_b",
38, "barangay_b",
39, "city_b",
40, "province_b",
41, "zipcode_b",
42, "siteIDA",
43, "siteIDB",
44, "stage",
45, "stageStatus",
46, "externalReferenceNo",
47, "classStationService",
48, "modeOfOperation",
49, "Remarks",
50, "dateOfApprovedBrief",
51, "recommendations",
52, "applicationCategory",
53, "address",
54, "natureOfService",
55, "rt",
56, "fx",
57, "fb",
58, "ml",
59, "p",
60, "bc",
61, "fc",
62, "fa",
63, "ma",
64, "tc",
65, "other_ClassSS",
66, "naturoOfRequest",
67, "serviceArea",
68, "caseNo",
69, "frequencyRange",
70, "directivity",
71, "encoder",
72, "evaluator",
73, "position" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar( "companyNameA", new XVar( 0, "import_field" ),
"siteIDA", new XVar( 0, "import_field1" ),
"siteNameA", new XVar( 0, "import_field2" ),
"siteNameB", new XVar( 0, "import_field3" ),
"siteIDB", new XVar( 0, "import_field4" ),
"elevationA", new XVar( 0, "import_field5" ),
"elevationB", new XVar( 0, "import_field6" ),
"makeTypeModelA", new XVar( 0, "import_field7" ),
"gainA", new XVar( 0, "import_field8" ),
"diameterA", new XVar( 0, "import_field9" ),
"beamwidthA", new XVar( 0, "import_field10" ),
"polarizationA", new XVar( 0, "import_field11" ),
"azimuthA", new XVar( 0, "import_field12" ),
"elevAngleA", new XVar( 0, "import_field13" ),
"heightAGLA", new XVar( 0, "import_field14" ),
"feederLengthA", new XVar( 0, "import_field15" ),
"makeTypeModelB", new XVar( 0, "import_field16" ),
"gainB", new XVar( 0, "import_field17" ),
"diameterB", new XVar( 0, "import_field18" ),
"beamwidthB", new XVar( 0, "import_field19" ),
"polarizationB", new XVar( 0, "import_field20" ),
"azimuthB", new XVar( 0, "import_field21" ),
"elevAngleB", new XVar( 0, "import_field22" ),
"heightAGLB", new XVar( 0, "import_field23" ),
"feederLengthB", new XVar( 0, "import_field24" ),
"longtitudeA", new XVar( 0, "import_field25" ),
"longtitudeB", new XVar( 0, "import_field26" ),
"latitudeA", new XVar( 0, "import_field27" ),
"latitudeB", new XVar( 0, "import_field28" ),
"callSignA", new XVar( 0, "import_field29" ),
"callSignB", new XVar( 0, "import_field30" ),
"applicationType", new XVar( 0, "import_field31" ),
"unit_a", new XVar( 0, "import_field32" ),
"street_a", new XVar( 0, "import_field33" ),
"barangay_a", new XVar( 0, "import_field34" ),
"city_a", new XVar( 0, "import_field35" ),
"province_a", new XVar( 0, "import_field36" ),
"zipcode_a", new XVar( 0, "import_field37" ),
"unit_b", new XVar( 0, "import_field38" ),
"street_b", new XVar( 0, "import_field39" ),
"barangay_b", new XVar( 0, "import_field40" ),
"city_b", new XVar( 0, "import_field41" ),
"province_b", new XVar( 0, "import_field42" ),
"zipcode_b", new XVar( 0, "import_field43" ),
"stage", new XVar( 0, "import_field44" ),
"stageStatus", new XVar( 0, "import_field45" ),
"externalReferenceNo", new XVar( 0, "import_field46" ),
"classStationService", new XVar( 0, "import_field47" ),
"modeOfOperation", new XVar( 0, "import_field48" ),
"Remarks", new XVar( 0, "import_field49" ),
"dateOfApprovedBrief", new XVar( 0, "import_field50" ),
"natureOfService", new XVar( 0, "import_field51" ),
"recommendations", new XVar( 0, "import_field52" ),
"applicationCategory", new XVar( 0, "import_field53" ),
"address", new XVar( 0, "import_field54" ),
"rt", new XVar( 0, "import_field55" ),
"fx", new XVar( 0, "import_field56" ),
"fb", new XVar( 0, "import_field57" ),
"ml", new XVar( 0, "import_field58" ),
"p", new XVar( 0, "import_field59" ),
"bc", new XVar( 0, "import_field60" ),
"fc", new XVar( 0, "import_field61" ),
"fa", new XVar( 0, "import_field62" ),
"ma", new XVar( 0, "import_field63" ),
"tc", new XVar( 0, "import_field64" ),
"other_ClassSS", new XVar( 0, "import_field65" ),
"naturoOfRequest", new XVar( 0, "import_field66" ),
"serviceArea", new XVar( 0, "import_field67" ),
"caseNo", new XVar( 0, "import_field68" ),
"frequencyRange", new XVar( 0, "import_field69" ),
"directivity", new XVar( 0, "import_field70" ),
"encoder", new XVar( 0, "import_field71" ),
"evaluator", new XVar( 0, "import_field72" ),
"position", new XVar( 0, "import_field73" ) ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "supertop", XVar.Array(),
"top", new XVar( 0, "import_header" ),
"grid", new XVar( 0, "import_field",
1, "import_field2",
2, "import_field3",
3, "import_field5",
4, "import_field6",
5, "import_field7",
6, "import_field8",
7, "import_field9",
8, "import_field10",
9, "import_field11",
10, "import_field12",
11, "import_field13",
12, "import_field14",
13, "import_field15",
14, "import_field16",
15, "import_field17",
16, "import_field18",
17, "import_field19",
18, "import_field20",
19, "import_field21",
20, "import_field22",
21, "import_field23",
22, "import_field24",
23, "import_field25",
24, "import_field26",
25, "import_field27",
26, "import_field28",
27, "import_field29",
28, "import_field30",
29, "import_field31",
30, "import_field32",
31, "import_field33",
32, "import_field34",
33, "import_field35",
34, "import_field36",
35, "import_field37",
36, "import_field38",
37, "import_field39",
38, "import_field40",
39, "import_field41",
40, "import_field42",
41, "import_field43",
42, "import_field1",
43, "import_field4",
44, "import_field44",
45, "import_field45",
46, "import_field46",
47, "import_field47",
48, "import_field48",
49, "import_field49",
50, "import_field50",
51, "import_field52",
52, "import_field53",
53, "import_field54",
54, "import_field51",
55, "import_field55",
56, "import_field56",
57, "import_field57",
58, "import_field58",
59, "import_field59",
60, "import_field60",
61, "import_field61",
62, "import_field62",
63, "import_field63",
64, "import_field64",
65, "import_field65",
66, "import_field66",
67, "import_field67",
68, "import_field68",
69, "import_field69",
70, "import_field70",
71, "import_field71",
72, "import_field72",
73, "import_field73" ) ),
"formXtTags", new XVar( "supertop", XVar.Array() ),
"itemForms", new XVar( "import_header", "top",
"import_field", "grid",
"import_field2", "grid",
"import_field3", "grid",
"import_field5", "grid",
"import_field6", "grid",
"import_field7", "grid",
"import_field8", "grid",
"import_field9", "grid",
"import_field10", "grid",
"import_field11", "grid",
"import_field12", "grid",
"import_field13", "grid",
"import_field14", "grid",
"import_field15", "grid",
"import_field16", "grid",
"import_field17", "grid",
"import_field18", "grid",
"import_field19", "grid",
"import_field20", "grid",
"import_field21", "grid",
"import_field22", "grid",
"import_field23", "grid",
"import_field24", "grid",
"import_field25", "grid",
"import_field26", "grid",
"import_field27", "grid",
"import_field28", "grid",
"import_field29", "grid",
"import_field30", "grid",
"import_field31", "grid",
"import_field32", "grid",
"import_field33", "grid",
"import_field34", "grid",
"import_field35", "grid",
"import_field36", "grid",
"import_field37", "grid",
"import_field38", "grid",
"import_field39", "grid",
"import_field40", "grid",
"import_field41", "grid",
"import_field42", "grid",
"import_field43", "grid",
"import_field1", "grid",
"import_field4", "grid",
"import_field44", "grid",
"import_field45", "grid",
"import_field46", "grid",
"import_field47", "grid",
"import_field48", "grid",
"import_field49", "grid",
"import_field50", "grid",
"import_field52", "grid",
"import_field53", "grid",
"import_field54", "grid",
"import_field51", "grid",
"import_field55", "grid",
"import_field56", "grid",
"import_field57", "grid",
"import_field58", "grid",
"import_field59", "grid",
"import_field60", "grid",
"import_field61", "grid",
"import_field62", "grid",
"import_field63", "grid",
"import_field64", "grid",
"import_field65", "grid",
"import_field66", "grid",
"import_field67", "grid",
"import_field68", "grid",
"import_field69", "grid",
"import_field70", "grid",
"import_field71", "grid",
"import_field72", "grid",
"import_field73", "grid" ),
"itemLocations", new XVar(  ),
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "import_header", new XVar( 0, "import_header" ),
"import_field", new XVar( 0, "import_field",
1, "import_field1",
2, "import_field2",
3, "import_field3",
4, "import_field4",
5, "import_field5",
6, "import_field6",
7, "import_field7",
8, "import_field8",
9, "import_field9",
10, "import_field10",
11, "import_field11",
12, "import_field12",
13, "import_field13",
14, "import_field14",
15, "import_field15",
16, "import_field16",
17, "import_field17",
18, "import_field18",
19, "import_field19",
20, "import_field20",
21, "import_field21",
22, "import_field22",
23, "import_field23",
24, "import_field24",
25, "import_field25",
26, "import_field26",
27, "import_field27",
28, "import_field28",
29, "import_field29",
30, "import_field30",
31, "import_field31",
32, "import_field32",
33, "import_field33",
34, "import_field34",
35, "import_field35",
36, "import_field36",
37, "import_field37",
38, "import_field38",
39, "import_field39",
40, "import_field40",
41, "import_field41",
42, "import_field42",
43, "import_field43",
44, "import_field44",
45, "import_field45",
46, "import_field46",
47, "import_field47",
48, "import_field48",
49, "import_field49",
50, "import_field50",
51, "import_field51",
52, "import_field52",
53, "import_field53",
54, "import_field54",
55, "import_field55",
56, "import_field56",
57, "import_field57",
58, "import_field58",
59, "import_field59",
60, "import_field60",
61, "import_field61",
62, "import_field62",
63, "import_field63",
64, "import_field64",
65, "import_field65",
66, "import_field66",
67, "import_field67",
68, "import_field68",
69, "import_field69",
70, "import_field70",
71, "import_field71",
72, "import_field72",
73, "import_field73" ) ),
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
"buttons", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "import",
"type", "import",
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
"top", new XVar( "modelId", "import-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "import_header" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "import-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "import_field",
1, "import_field2",
2, "import_field3",
3, "import_field5",
4, "import_field6",
5, "import_field7",
6, "import_field8",
7, "import_field9",
8, "import_field10",
9, "import_field11",
10, "import_field12",
11, "import_field13",
12, "import_field14",
13, "import_field15",
14, "import_field16",
15, "import_field17",
16, "import_field18",
17, "import_field19",
18, "import_field20",
19, "import_field21",
20, "import_field22",
21, "import_field23",
22, "import_field24",
23, "import_field25",
24, "import_field26",
25, "import_field27",
26, "import_field28",
27, "import_field29",
28, "import_field30",
29, "import_field31",
30, "import_field32",
31, "import_field33",
32, "import_field34",
33, "import_field35",
34, "import_field36",
35, "import_field37",
36, "import_field38",
37, "import_field39",
38, "import_field40",
39, "import_field41",
40, "import_field42",
41, "import_field43",
42, "import_field1",
43, "import_field4",
44, "import_field44",
45, "import_field45",
46, "import_field46",
47, "import_field47",
48, "import_field48",
49, "import_field49",
50, "import_field50",
51, "import_field52",
52, "import_field53",
53, "import_field54",
54, "import_field51",
55, "import_field55",
56, "import_field56",
57, "import_field57",
58, "import_field58",
59, "import_field59",
60, "import_field60",
61, "import_field61",
62, "import_field62",
63, "import_field63",
64, "import_field64",
65, "import_field65",
66, "import_field66",
67, "import_field67",
68, "import_field68",
69, "import_field69",
70, "import_field70",
71, "import_field71",
72, "import_field72",
73, "import_field73" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "import_header", new XVar( "type", "import_header" ),
"import_field", new XVar( "field", "companyNameA",
"type", "import_field" ),
"import_field1", new XVar( "field", "siteIDA",
"type", "import_field" ),
"import_field2", new XVar( "field", "siteNameA",
"type", "import_field" ),
"import_field3", new XVar( "field", "siteNameB",
"type", "import_field" ),
"import_field4", new XVar( "field", "siteIDB",
"type", "import_field" ),
"import_field5", new XVar( "field", "elevationA",
"type", "import_field" ),
"import_field6", new XVar( "field", "elevationB",
"type", "import_field" ),
"import_field7", new XVar( "field", "makeTypeModelA",
"type", "import_field" ),
"import_field8", new XVar( "field", "gainA",
"type", "import_field" ),
"import_field9", new XVar( "field", "diameterA",
"type", "import_field" ),
"import_field10", new XVar( "field", "beamwidthA",
"type", "import_field" ),
"import_field11", new XVar( "field", "polarizationA",
"type", "import_field" ),
"import_field12", new XVar( "field", "azimuthA",
"type", "import_field" ),
"import_field13", new XVar( "field", "elevAngleA",
"type", "import_field" ),
"import_field14", new XVar( "field", "heightAGLA",
"type", "import_field" ),
"import_field15", new XVar( "field", "feederLengthA",
"type", "import_field" ),
"import_field16", new XVar( "field", "makeTypeModelB",
"type", "import_field" ),
"import_field17", new XVar( "field", "gainB",
"type", "import_field" ),
"import_field18", new XVar( "field", "diameterB",
"type", "import_field" ),
"import_field19", new XVar( "field", "beamwidthB",
"type", "import_field" ),
"import_field20", new XVar( "field", "polarizationB",
"type", "import_field" ),
"import_field21", new XVar( "field", "azimuthB",
"type", "import_field" ),
"import_field22", new XVar( "field", "elevAngleB",
"type", "import_field" ),
"import_field23", new XVar( "field", "heightAGLB",
"type", "import_field" ),
"import_field24", new XVar( "field", "feederLengthB",
"type", "import_field" ),
"import_field25", new XVar( "field", "longtitudeA",
"type", "import_field" ),
"import_field26", new XVar( "field", "longtitudeB",
"type", "import_field" ),
"import_field27", new XVar( "field", "latitudeA",
"type", "import_field" ),
"import_field28", new XVar( "field", "latitudeB",
"type", "import_field" ),
"import_field29", new XVar( "field", "callSignA",
"type", "import_field" ),
"import_field30", new XVar( "field", "callSignB",
"type", "import_field" ),
"import_field31", new XVar( "field", "applicationType",
"type", "import_field" ),
"import_field32", new XVar( "field", "unit_a",
"type", "import_field" ),
"import_field33", new XVar( "field", "street_a",
"type", "import_field" ),
"import_field34", new XVar( "field", "barangay_a",
"type", "import_field" ),
"import_field35", new XVar( "field", "city_a",
"type", "import_field" ),
"import_field36", new XVar( "field", "province_a",
"type", "import_field" ),
"import_field37", new XVar( "field", "zipcode_a",
"type", "import_field" ),
"import_field38", new XVar( "field", "unit_b",
"type", "import_field" ),
"import_field39", new XVar( "field", "street_b",
"type", "import_field" ),
"import_field40", new XVar( "field", "barangay_b",
"type", "import_field" ),
"import_field41", new XVar( "field", "city_b",
"type", "import_field" ),
"import_field42", new XVar( "field", "province_b",
"type", "import_field" ),
"import_field43", new XVar( "field", "zipcode_b",
"type", "import_field" ),
"import_field44", new XVar( "field", "stage",
"type", "import_field" ),
"import_field45", new XVar( "field", "stageStatus",
"type", "import_field" ),
"import_field46", new XVar( "field", "externalReferenceNo",
"type", "import_field" ),
"import_field47", new XVar( "field", "classStationService",
"type", "import_field" ),
"import_field48", new XVar( "field", "modeOfOperation",
"type", "import_field" ),
"import_field49", new XVar( "field", "Remarks",
"type", "import_field" ),
"import_field50", new XVar( "field", "dateOfApprovedBrief",
"type", "import_field" ),
"import_field51", new XVar( "field", "natureOfService",
"type", "import_field" ),
"import_field52", new XVar( "field", "recommendations",
"type", "import_field" ),
"import_field53", new XVar( "field", "applicationCategory",
"type", "import_field" ),
"import_field54", new XVar( "field", "address",
"type", "import_field" ),
"import_field55", new XVar( "field", "rt",
"type", "import_field" ),
"import_field56", new XVar( "field", "fx",
"type", "import_field" ),
"import_field57", new XVar( "field", "fb",
"type", "import_field" ),
"import_field58", new XVar( "field", "ml",
"type", "import_field" ),
"import_field59", new XVar( "field", "p",
"type", "import_field" ),
"import_field60", new XVar( "field", "bc",
"type", "import_field" ),
"import_field61", new XVar( "field", "fc",
"type", "import_field" ),
"import_field62", new XVar( "field", "fa",
"type", "import_field" ),
"import_field63", new XVar( "field", "ma",
"type", "import_field" ),
"import_field64", new XVar( "field", "tc",
"type", "import_field" ),
"import_field65", new XVar( "field", "other_ClassSS",
"type", "import_field" ),
"import_field66", new XVar( "field", "naturoOfRequest",
"type", "import_field" ),
"import_field67", new XVar( "field", "serviceArea",
"type", "import_field" ),
"import_field68", new XVar( "field", "caseNo",
"type", "import_field" ),
"import_field69", new XVar( "field", "frequencyRange",
"type", "import_field" ),
"import_field70", new XVar( "field", "directivity",
"type", "import_field" ),
"import_field71", new XVar( "field", "encoder",
"type", "import_field" ),
"import_field72", new XVar( "field", "evaluator",
"type", "import_field" ),
"import_field73", new XVar( "field", "position",
"type", "import_field" ) ),
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