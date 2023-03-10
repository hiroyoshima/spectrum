
		// dbo.radioEquipment
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
			public static partial class Options_radioequipment_edit
			{
				static public XVar options()
				{
					return new XVar( "master", new XVar( "dbo.rspdHeader", new XVar( "preview", true ) ),
"captcha", new XVar( "captcha", false ),
"fields", new XVar( "gridFields", new XVar( 0, "makeModelA",
1, "capacityA",
2, "powerA",
3, "modA",
4, "BWEA",
5, "serialNoA",
6, "makeModelB",
7, "capacityB",
8, "powerB",
9, "modB",
10, "BWEB",
11, "serialNoB",
12, "txA",
13, "txB",
14, "rxA",
15, "rxB",
16, "frequencyRange",
17, "frequencyRangeB" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"updateOnEditFields", XVar.Array(),
"fieldItems", new XVar( "makeModelA", new XVar( 0, "integrated_edit_field" ),
"capacityA", new XVar( 0, "integrated_edit_field1" ),
"powerA", new XVar( 0, "integrated_edit_field2" ),
"modA", new XVar( 0, "integrated_edit_field3" ),
"BWEA", new XVar( 0, "integrated_edit_field4" ),
"serialNoA", new XVar( 0, "integrated_edit_field5" ),
"makeModelB", new XVar( 0, "integrated_edit_field6" ),
"capacityB", new XVar( 0, "integrated_edit_field7" ),
"powerB", new XVar( 0, "integrated_edit_field8" ),
"modB", new XVar( 0, "integrated_edit_field9" ),
"BWEB", new XVar( 0, "integrated_edit_field10" ),
"serialNoB", new XVar( 0, "integrated_edit_field11" ),
"txA", new XVar( 0, "integrated_edit_field13" ),
"txB", new XVar( 0, "integrated_edit_field14" ),
"rxA", new XVar( 0, "integrated_edit_field15" ),
"rxB", new XVar( 0, "integrated_edit_field16" ),
"frequencyRange", new XVar( 0, "integrated_edit_field12" ),
"frequencyRangeB", new XVar( 0, "integrated_edit_field17" ) ) ),
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
"grid", new XVar( 0, "master_info",
1, "integrated_edit_field",
2, "integrated_edit_field1",
3, "integrated_edit_field2",
4, "integrated_edit_field3",
5, "integrated_edit_field4",
6, "integrated_edit_field5",
7, "integrated_edit_field6",
8, "integrated_edit_field7",
9, "integrated_edit_field8",
10, "integrated_edit_field9",
11, "integrated_edit_field10",
12, "integrated_edit_field11",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field12",
18, "integrated_edit_field17" ) ),
"formXtTags", new XVar( "above-grid", new XVar( 0, "message_block" ) ),
"itemForms", new XVar( "edit_message", "above-grid",
"edit_save", "below-grid",
"edit_back_list", "below-grid",
"edit_close", "below-grid",
"hamburger", "below-grid",
"edit_header", "top",
"master_info", "grid",
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
"integrated_edit_field13", "grid",
"integrated_edit_field14", "grid",
"integrated_edit_field15", "grid",
"integrated_edit_field16", "grid",
"integrated_edit_field12", "grid",
"integrated_edit_field17", "grid" ),
"itemLocations", new XVar( "master_info", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field", new XVar( "location", "grid",
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
"integrated_edit_field13", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field14", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field15", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field16", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field12", new XVar( "location", "grid",
"cellId", "c3" ),
"integrated_edit_field17", new XVar( "location", "grid",
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
12, "integrated_edit_field13",
13, "integrated_edit_field14",
14, "integrated_edit_field15",
15, "integrated_edit_field16",
16, "integrated_edit_field12",
17, "integrated_edit_field17" ),
"master_info", new XVar( 0, "master_info" ) ),
"cellMaps", new XVar( "grid", new XVar( "cells", new XVar( "c3", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 0 ),
"tags", XVar.Array(),
"items", new XVar( 0, "master_info",
1, "integrated_edit_field",
2, "integrated_edit_field1",
3, "integrated_edit_field2",
4, "integrated_edit_field3",
5, "integrated_edit_field4",
6, "integrated_edit_field5",
7, "integrated_edit_field6",
8, "integrated_edit_field7",
9, "integrated_edit_field8",
10, "integrated_edit_field9",
11, "integrated_edit_field10",
12, "integrated_edit_field11",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field12",
18, "integrated_edit_field17" ),
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
"items", new XVar( 0, "master_info",
1, "integrated_edit_field",
2, "integrated_edit_field1",
3, "integrated_edit_field2",
4, "integrated_edit_field3",
5, "integrated_edit_field4",
6, "integrated_edit_field5",
7, "integrated_edit_field6",
8, "integrated_edit_field7",
9, "integrated_edit_field8",
10, "integrated_edit_field9",
11, "integrated_edit_field10",
12, "integrated_edit_field11",
13, "integrated_edit_field13",
14, "integrated_edit_field14",
15, "integrated_edit_field15",
16, "integrated_edit_field16",
17, "integrated_edit_field12",
18, "integrated_edit_field17" ) ) ),
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
"integrated_edit_field", new XVar( "field", "makeModelA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field1", new XVar( "field", "capacityA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field2", new XVar( "field", "powerA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field3", new XVar( "field", "modA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field4", new XVar( "field", "BWEA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field5", new XVar( "field", "serialNoA",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field6", new XVar( "field", "makeModelB",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field7", new XVar( "field", "capacityB",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field8", new XVar( "field", "powerB",
"type", "integrated_edit_field",
"orientation", 0,
"updateOnEdit", false ),
"integrated_edit_field9", new XVar( "field", "modB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field10", new XVar( "field", "BWEB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field11", new XVar( "field", "serialNoB",
"type", "integrated_edit_field",
"orientation", 0 ),
"master_info", new XVar( "type", "master_info",
"tables", new XVar( "dbo.rspdHeader", "true" ) ),
"integrated_edit_field13", new XVar( "field", "txA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field14", new XVar( "field", "txB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field15", new XVar( "field", "rxA",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field16", new XVar( "field", "rxB",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field12", new XVar( "field", "frequencyRange",
"type", "integrated_edit_field",
"orientation", 0 ),
"integrated_edit_field17", new XVar( "field", "frequencyRangeB",
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