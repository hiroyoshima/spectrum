
		// dbo.province
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
			public static partial class Options_province_print
			{
				static public XVar options()
				{
					return new XVar( "pdf", new XVar( "pdfView", false ),
"details", new XVar( "dbo.city", new XVar( "displayPreview", 1 ) ),
"totals", new XVar( "id", new XVar( "totalsType", "" ),
"province", new XVar( "totalsType", "" ),
"region", new XVar( "totalsType", "" ) ),
"fields", new XVar( "gridFields", new XVar( 0, "province",
1, "region" ),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar( "province", new XVar( 0, "simple_grid_field1",
1, "simple_grid_field2" ),
"region", new XVar( 0, "simple_grid_field",
1, "simple_grid_field3" ) ),
"hideEmptyFields", XVar.Array() ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "above-grid", new XVar( 0, "print_pages" ),
"below-grid", XVar.Array(),
"top", new XVar( 0, "print_header",
1, "print_subheader" ),
"grid", new XVar( 0, "simple_grid_field2",
1, "simple_grid_field1",
2, "simple_grid_field3",
3, "simple_grid_field",
4, "details_preview" ) ),
"formXtTags", new XVar( "above-grid", new XVar( 0, "print_pages" ),
"below-grid", XVar.Array() ),
"itemForms", new XVar( "print_pages", "above-grid",
"print_header", "top",
"print_subheader", "top",
"simple_grid_field2", "grid",
"simple_grid_field1", "grid",
"simple_grid_field3", "grid",
"simple_grid_field", "grid",
"details_preview", "grid" ),
"itemLocations", new XVar( "simple_grid_field2", new XVar( "location", "grid",
"cellId", "headcell_field" ),
"simple_grid_field1", new XVar( "location", "grid",
"cellId", "cell_field" ),
"simple_grid_field3", new XVar( "location", "grid",
"cellId", "headcell_field1" ),
"simple_grid_field", new XVar( "location", "grid",
"cellId", "cell_field1" ),
"details_preview", new XVar( "location", "grid",
"cellId", "cell_dpreview" ) ),
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "print_header", new XVar( 0, "print_header" ),
"print_subheader", new XVar( 0, "print_subheader" ),
"print_pages", new XVar( 0, "print_pages" ),
"grid_field", new XVar( 0, "simple_grid_field1",
1, "simple_grid_field" ),
"grid_field_label", new XVar( 0, "simple_grid_field2",
1, "simple_grid_field3" ),
"details_preview", new XVar( 0, "details_preview" ) ),
"cellMaps", new XVar( "grid", new XVar( "cells", new XVar( "headcell_field", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "province_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field2" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"headcell_field1", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 0 ),
"tags", new XVar( 0, "region_fieldheadercolumn" ),
"items", new XVar( 0, "simple_grid_field3" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "province_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field1" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_field1", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 1 ),
"tags", new XVar( 0, "region_fieldcolumn" ),
"items", new XVar( 0, "simple_grid_field" ),
"fixedAtServer", false,
"fixedAtClient", false ),
"cell_dpreview", new XVar( "cols", new XVar( 0, 0,
1, 1 ),
"rows", new XVar( 0, 2 ),
"tags", XVar.Array(),
"items", new XVar( 0, "details_preview" ),
"fixedAtServer", true,
"fixedAtClient", false ),
"footcell_field", new XVar( "cols", new XVar( 0, 0 ),
"rows", new XVar( 0, 3 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ),
"footcell_field1", new XVar( "cols", new XVar( 0, 1 ),
"rows", new XVar( 0, 3 ),
"tags", XVar.Array(),
"items", XVar.Array(),
"fixedAtServer", false,
"fixedAtClient", false ) ),
"width", 2,
"height", 4 ) ) ),
"loginForm", new XVar( "loginForm", 3 ),
"page", new XVar( "verticalBar", false,
"labeledButtons", new XVar( "update_records", new XVar(  ),
"print_pages", new XVar( "print_pages", new XVar( "tag", "PRINT_PAGES",
"type", 2 ) ),
"register_activate_message", new XVar(  ),
"details_found", new XVar(  ) ),
"gridType", 0,
"recsPerRow", 1,
"hasCustomButtons", false,
"customButtons", XVar.Array(),
"hasNotifications", false,
"menus", XVar.Array(),
"calcTotalsFor", 1 ),
"misc", new XVar( "type", "print",
"breadcrumb", false ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"dataGrid", new XVar( "groupFields", XVar.Array() ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "print",
"type", "print",
"layoutId", "basic",
"disabled", 0,
"default", 0,
"forms", new XVar( "above-grid", new XVar( "modelId", "print-above-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "print_pages" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"below-grid", new XVar( "modelId", "print-below-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "print-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c2", new XVar( "model", "c2",
"items", new XVar( 0, "print_header",
1, "print_subheader" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "horizontal-grid",
"grid", new XVar( 0, new XVar( "section", "head",
"cells", new XVar( 0, new XVar( "cell", "headcell_field" ),
1, new XVar( "cell", "headcell_field1" ) ) ),
1, new XVar( "section", "body",
"cells", new XVar( 0, new XVar( "cell", "cell_field" ),
1, new XVar( "cell", "cell_field1" ) ) ),
2, new XVar( "cells", new XVar( 0, new XVar( "cell", "cell_dpreview",
"colspan", 2 ) ),
"section", "body" ),
3, new XVar( "section", "foot",
"cells", new XVar( 0, new XVar( "cell", "footcell_field" ),
1, new XVar( "cell", "footcell_field1" ) ) ) ),
"cells", new XVar( "headcell_field", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field2" ),
"field", "province",
"columnName", "field" ),
"cell_field", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field1" ),
"field", "province",
"columnName", "field" ),
"footcell_field", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"headcell_field1", new XVar( "model", "headcell_field",
"items", new XVar( 0, "simple_grid_field3" ),
"field", "region",
"columnName", "field" ),
"cell_field1", new XVar( "model", "cell_field",
"items", new XVar( 0, "simple_grid_field" ),
"field", "region",
"columnName", "field" ),
"footcell_field1", new XVar( "model", "footcell_field",
"items", XVar.Array() ),
"cell_dpreview", new XVar( "model", "cell_dpreview",
"items", new XVar( 0, "details_preview" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "print_header", new XVar( "type", "print_header" ),
"print_subheader", new XVar( "type", "print_subheader" ),
"print_pages", new XVar( "type", "print_pages" ),
"simple_grid_field1", new XVar( "field", "province",
"type", "grid_field" ),
"simple_grid_field2", new XVar( "type", "grid_field_label",
"field", "province" ),
"simple_grid_field", new XVar( "field", "region",
"type", "grid_field" ),
"simple_grid_field3", new XVar( "type", "grid_field_label",
"field", "region" ),
"details_preview", new XVar( "type", "details_preview",
"table", "dbo.city",
"items", XVar.Array(),
"popup", false ) ),
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