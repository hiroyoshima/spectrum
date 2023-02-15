
		// Dashboard
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
			public static partial class Options_dashboard_dashboard
			{
				static public XVar options()
				{
					return new XVar( "fields", new XVar( "gridFields", XVar.Array(),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar(  ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "grid", new XVar( 0, "dashboard-item",
1, "dashboard-item1" ),
"left", new XVar( 0, "logo",
1, "expand_button",
2, "menu" ),
"supertop", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "breadcrumb",
3, "simple_search",
4, "username_button" ),
"top", XVar.Array() ),
"formXtTags", new XVar( "top", XVar.Array() ),
"itemForms", new XVar( "dashboard-item", "grid",
"dashboard-item1", "grid",
"logo", "left",
"expand_button", "left",
"menu", "left",
"expand_menu_button", "supertop",
"collapse_button", "supertop",
"breadcrumb", "supertop",
"simple_search", "supertop",
"username_button", "supertop" ),
"itemLocations", new XVar(  ),
"itemVisiblity", new XVar( "breadcrumb", 5,
"expand_menu_button", 2,
"expand_button", 5 ) ),
"itemsByType", new XVar( "breadcrumb", new XVar( 0, "breadcrumb" ),
"logo", new XVar( 0, "logo" ),
"menu", new XVar( 0, "menu" ),
"simple_search", new XVar( 0, "simple_search" ),
"expand_menu_button", new XVar( 0, "expand_menu_button" ),
"collapse_button", new XVar( 0, "collapse_button" ),
"username_button", new XVar( 0, "username_button" ),
"userinfo_link", new XVar( 0, "userinfo_link" ),
"logout_link", new XVar( 0, "logout_link" ),
"adminarea_link", new XVar( 0, "adminarea_link" ),
"dashboard-item", new XVar( 0, "dashboard-item",
1, "dashboard-item1" ),
"expand_button", new XVar( 0, "expand_button" ) ),
"cellMaps", new XVar(  ) ),
"loginForm", new XVar( "loginForm", 3 ),
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
"misc", new XVar( "type", "dashboard",
"breadcrumb", true ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"dashboard", new XVar( "elements", new XVar( 0, new XVar( "item", new XVar( "type", "dashboard-item",
"table", "dbo.rspd_application_received",
"dashType", 0,
"dashName", "dbo_rspd_application_received_grid",
"bsStyle", "primary",
"panelType", 1,
"icon", new XVar( "glyph", "tree-conifer" ),
"viewTab", true,
"editTab", true,
"addTab", true,
"initialTab", 0,
"hiddenDetails", new XVar(  ),
"detailsOptions", XVar.Array(),
"mapUpdateGridWhenMoved", true,
"height", "500px",
"reloadInterval", 0,
"detailsFilterByMaster", false,
"detailsMasterTable", null,
"viewRecord", true,
"inlineEdit", false,
"pageId", "list" ),
"elementName", "dbo_rspd_application_received_grid",
"table", "dbo.rspd_application_received",
"pageName", "list",
"type", 0,
"reload", 0,
"tabsPageTypes", XVar.Array(),
"pageNames", new XVar(  ),
"initialTabPageType", "view",
"inlineEdit", false,
"popupView", true,
"notUsedDetailTables", XVar.Array(),
"details", new XVar(  ),
"zoom", "undefined",
"updateMoved", true,
"masterTable", "",
"tabLocation", "above",
"panelStyle", "primary" ),
1, new XVar( "item", new XVar( "type", "dashboard-item",
"table", "dbo.rspdHeader",
"dashType", 6,
"dashName", "dbo_rspdHeader_map",
"bsStyle", "primary",
"panelType", 1,
"icon", new XVar( "fa", "star-o" ),
"viewTab", true,
"editTab", true,
"addTab", true,
"initialTab", 0,
"hiddenDetails", new XVar(  ),
"detailsOptions", XVar.Array(),
"mapUpdateGridWhenMoved", true,
"height", "500px",
"reloadInterval", 0,
"detailsFilterByMaster", false,
"detailsMasterTable", null,
"mapZoom", "10",
"mapLatField", "latitudeA",
"mapLonField", "longtitudeA",
"mapDescField", "siteNameA",
"mapMarkerIcon", "",
"mapShowLocation", true,
"mapLocationIcon", "" ),
"elementName", "dbo_rspdHeader_map",
"table", "dbo.rspdHeader",
"type", 6,
"reload", 0,
"tabsPageTypes", XVar.Array(),
"pageNames", new XVar(  ),
"initialTabPageType", "view",
"notUsedDetailTables", XVar.Array(),
"details", new XVar(  ),
"zoom", "10",
"latF", "latitudeA",
"lonF", "longtitudeA",
"descF", "siteNameA",
"iconF", "",
"updateMoved", true,
"showCurrentLocation", true,
"currentLocationIcon", "",
"masterTable", "",
"tabLocation", "above",
"panelStyle", "primary" ) ) ),
"dashSearch", new XVar( "searchFields", new XVar( "dbo_rspdHeader_ID", new XVar( 0, new XVar( "field", "ID",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_referenceID", new XVar( 0, new XVar( "field", "referenceID",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_applicationNo", new XVar( 0, new XVar( "field", "applicationNo",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_companyNameA", new XVar( 0, new XVar( "field", "companyNameA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_userCreate", new XVar( 0, new XVar( "field", "userCreate",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_userUpdate", new XVar( 0, new XVar( "field", "userUpdate",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_dateCreated", new XVar( 0, new XVar( "field", "dateCreated",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_dateUpdated", new XVar( 0, new XVar( "field", "dateUpdated",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_companyNameB", new XVar( 0, new XVar( "field", "companyNameB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_siteNameA", new XVar( 0, new XVar( "field", "siteNameA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_siteNameB", new XVar( 0, new XVar( "field", "siteNameB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_siteIDA", new XVar( 0, new XVar( "field", "siteIDA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_siteIDB", new XVar( 0, new XVar( "field", "siteIDB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_coordinateA", new XVar( 0, new XVar( "field", "coordinateA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_coordinateB", new XVar( 0, new XVar( "field", "coordinateB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_elevationA", new XVar( 0, new XVar( "field", "elevationA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_elevationB", new XVar( 0, new XVar( "field", "elevationB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_makeTypeModelA", new XVar( 0, new XVar( "field", "makeTypeModelA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_gainA", new XVar( 0, new XVar( "field", "gainA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_diameterA", new XVar( 0, new XVar( "field", "diameterA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_beamwidthA", new XVar( 0, new XVar( "field", "beamwidthA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_polarizationA", new XVar( 0, new XVar( "field", "polarizationA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_azimuthA", new XVar( 0, new XVar( "field", "azimuthA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_elevAngleA", new XVar( 0, new XVar( "field", "elevAngleA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_heightAGLA", new XVar( 0, new XVar( "field", "heightAGLA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_feederLengthA", new XVar( 0, new XVar( "field", "feederLengthA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_makeTypeModelB", new XVar( 0, new XVar( "field", "makeTypeModelB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_gainB", new XVar( 0, new XVar( "field", "gainB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_diameterB", new XVar( 0, new XVar( "field", "diameterB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_beamwidthB", new XVar( 0, new XVar( "field", "beamwidthB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_polarizationB", new XVar( 0, new XVar( "field", "polarizationB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_azimuthB", new XVar( 0, new XVar( "field", "azimuthB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_elevAngleB", new XVar( 0, new XVar( "field", "elevAngleB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_heightAGLB", new XVar( 0, new XVar( "field", "heightAGLB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_feederLengthB", new XVar( 0, new XVar( "field", "feederLengthB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_longtitudeA", new XVar( 0, new XVar( "field", "longtitudeA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_longtitudeB", new XVar( 0, new XVar( "field", "longtitudeB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_latitudeA", new XVar( 0, new XVar( "field", "latitudeA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_latitudeB", new XVar( 0, new XVar( "field", "latitudeB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_callSignA", new XVar( 0, new XVar( "field", "callSignA",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_callSignB", new XVar( 0, new XVar( "field", "callSignB",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_applicationType", new XVar( 0, new XVar( "field", "applicationType",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_unit_a", new XVar( 0, new XVar( "field", "unit_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_street_a", new XVar( 0, new XVar( "field", "street_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_barangay_a", new XVar( 0, new XVar( "field", "barangay_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_city_a", new XVar( 0, new XVar( "field", "city_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_province_a", new XVar( 0, new XVar( "field", "province_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_zipcode_a", new XVar( 0, new XVar( "field", "zipcode_a",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_unit_b", new XVar( 0, new XVar( "field", "unit_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_street_b", new XVar( 0, new XVar( "field", "street_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_barangay_b", new XVar( 0, new XVar( "field", "barangay_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_city_b", new XVar( 0, new XVar( "field", "city_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_province_b", new XVar( 0, new XVar( "field", "province_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_zipcode_b", new XVar( 0, new XVar( "field", "zipcode_b",
"table", "dbo.rspdHeader" ) ),
"dbo_rspdHeader_map", new XVar( 0, new XVar( "field", "map",
"table", "dbo.rspdHeader" ) ),
"dbo_rspd_application_received_view_data", new XVar( 0, new XVar( "field", "view_data",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_ID", new XVar( 0, new XVar( "field", "ID",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_referenceID", new XVar( 0, new XVar( "field", "referenceID",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_applicationNo", new XVar( 0, new XVar( "field", "applicationNo",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_companyNameA", new XVar( 0, new XVar( "field", "companyNameA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_userCreate", new XVar( 0, new XVar( "field", "userCreate",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_userUpdate", new XVar( 0, new XVar( "field", "userUpdate",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_dateCreated", new XVar( 0, new XVar( "field", "dateCreated",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_dateUpdated", new XVar( 0, new XVar( "field", "dateUpdated",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_companyNameB", new XVar( 0, new XVar( "field", "companyNameB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_siteNameA", new XVar( 0, new XVar( "field", "siteNameA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_siteNameB", new XVar( 0, new XVar( "field", "siteNameB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_siteIDA", new XVar( 0, new XVar( "field", "siteIDA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_siteIDB", new XVar( 0, new XVar( "field", "siteIDB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_coordinateA", new XVar( 0, new XVar( "field", "coordinateA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_coordinateB", new XVar( 0, new XVar( "field", "coordinateB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_elevationA", new XVar( 0, new XVar( "field", "elevationA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_elevationB", new XVar( 0, new XVar( "field", "elevationB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_makeTypeModelA", new XVar( 0, new XVar( "field", "makeTypeModelA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_gainA", new XVar( 0, new XVar( "field", "gainA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_diameterA", new XVar( 0, new XVar( "field", "diameterA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_beamwidthA", new XVar( 0, new XVar( "field", "beamwidthA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_polarizationA", new XVar( 0, new XVar( "field", "polarizationA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_azimuthA", new XVar( 0, new XVar( "field", "azimuthA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_elevAngleA", new XVar( 0, new XVar( "field", "elevAngleA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_heightAGLA", new XVar( 0, new XVar( "field", "heightAGLA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_feederLengthA", new XVar( 0, new XVar( "field", "feederLengthA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_makeTypeModelB", new XVar( 0, new XVar( "field", "makeTypeModelB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_gainB", new XVar( 0, new XVar( "field", "gainB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_diameterB", new XVar( 0, new XVar( "field", "diameterB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_beamwidthB", new XVar( 0, new XVar( "field", "beamwidthB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_polarizationB", new XVar( 0, new XVar( "field", "polarizationB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_azimuthB", new XVar( 0, new XVar( "field", "azimuthB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_elevAngleB", new XVar( 0, new XVar( "field", "elevAngleB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_heightAGLB", new XVar( 0, new XVar( "field", "heightAGLB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_feederLengthB", new XVar( 0, new XVar( "field", "feederLengthB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_longtitudeA", new XVar( 0, new XVar( "field", "longtitudeA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_longtitudeB", new XVar( 0, new XVar( "field", "longtitudeB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_latitudeA", new XVar( 0, new XVar( "field", "latitudeA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_latitudeB", new XVar( 0, new XVar( "field", "latitudeB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_callSignA", new XVar( 0, new XVar( "field", "callSignA",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_callSignB", new XVar( 0, new XVar( "field", "callSignB",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_applicationType", new XVar( 0, new XVar( "field", "applicationType",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_unit_a", new XVar( 0, new XVar( "field", "unit_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_street_a", new XVar( 0, new XVar( "field", "street_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_barangay_a", new XVar( 0, new XVar( "field", "barangay_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_city_a", new XVar( 0, new XVar( "field", "city_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_province_a", new XVar( 0, new XVar( "field", "province_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_zipcode_a", new XVar( 0, new XVar( "field", "zipcode_a",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_unit_b", new XVar( 0, new XVar( "field", "unit_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_street_b", new XVar( 0, new XVar( "field", "street_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_barangay_b", new XVar( 0, new XVar( "field", "barangay_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_city_b", new XVar( 0, new XVar( "field", "city_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_province_b", new XVar( 0, new XVar( "field", "province_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_zipcode_b", new XVar( 0, new XVar( "field", "zipcode_b",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_map", new XVar( 0, new XVar( "field", "map",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_stage", new XVar( 0, new XVar( "field", "stage",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_stageStatus", new XVar( 0, new XVar( "field", "stageStatus",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_externalReferenceNo", new XVar( 0, new XVar( "field", "externalReferenceNo",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_classStationService", new XVar( 0, new XVar( "field", "classStationService",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_modeOfOperation", new XVar( 0, new XVar( "field", "modeOfOperation",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_Remarks", new XVar( 0, new XVar( "field", "Remarks",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_dateOfApprovedBrief", new XVar( 0, new XVar( "field", "dateOfApprovedBrief",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_recommendations", new XVar( 0, new XVar( "field", "recommendations",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_applicationCategory", new XVar( 0, new XVar( "field", "applicationCategory",
"table", "dbo.rspd_application_received" ) ),
"dbo_rspd_application_received_address", new XVar( 0, new XVar( "field", "address",
"table", "dbo.rspd_application_received" ) ) ),
"allSearchFields", new XVar( 0, "dbo_rspdHeader_ID",
1, "dbo_rspdHeader_referenceID",
2, "dbo_rspdHeader_applicationNo",
3, "dbo_rspdHeader_companyNameA",
4, "dbo_rspdHeader_userCreate",
5, "dbo_rspdHeader_userUpdate",
6, "dbo_rspdHeader_dateCreated",
7, "dbo_rspdHeader_dateUpdated",
8, "dbo_rspdHeader_companyNameB",
9, "dbo_rspdHeader_siteNameA",
10, "dbo_rspdHeader_siteNameB",
11, "dbo_rspdHeader_siteIDA",
12, "dbo_rspdHeader_siteIDB",
13, "dbo_rspdHeader_coordinateA",
14, "dbo_rspdHeader_coordinateB",
15, "dbo_rspdHeader_elevationA",
16, "dbo_rspdHeader_elevationB",
17, "dbo_rspdHeader_makeTypeModelA",
18, "dbo_rspdHeader_gainA",
19, "dbo_rspdHeader_diameterA",
20, "dbo_rspdHeader_beamwidthA",
21, "dbo_rspdHeader_polarizationA",
22, "dbo_rspdHeader_azimuthA",
23, "dbo_rspdHeader_elevAngleA",
24, "dbo_rspdHeader_heightAGLA",
25, "dbo_rspdHeader_feederLengthA",
26, "dbo_rspdHeader_makeTypeModelB",
27, "dbo_rspdHeader_gainB",
28, "dbo_rspdHeader_diameterB",
29, "dbo_rspdHeader_beamwidthB",
30, "dbo_rspdHeader_polarizationB",
31, "dbo_rspdHeader_azimuthB",
32, "dbo_rspdHeader_elevAngleB",
33, "dbo_rspdHeader_heightAGLB",
34, "dbo_rspdHeader_feederLengthB",
35, "dbo_rspdHeader_longtitudeA",
36, "dbo_rspdHeader_longtitudeB",
37, "dbo_rspdHeader_latitudeA",
38, "dbo_rspdHeader_latitudeB",
39, "dbo_rspdHeader_callSignA",
40, "dbo_rspdHeader_callSignB",
41, "dbo_rspdHeader_applicationType",
42, "dbo_rspdHeader_unit_a",
43, "dbo_rspdHeader_street_a",
44, "dbo_rspdHeader_barangay_a",
45, "dbo_rspdHeader_city_a",
46, "dbo_rspdHeader_province_a",
47, "dbo_rspdHeader_zipcode_a",
48, "dbo_rspdHeader_unit_b",
49, "dbo_rspdHeader_street_b",
50, "dbo_rspdHeader_barangay_b",
51, "dbo_rspdHeader_city_b",
52, "dbo_rspdHeader_province_b",
53, "dbo_rspdHeader_zipcode_b",
54, "dbo_rspdHeader_map",
55, "dbo_rspd_application_received_view_data",
56, "dbo_rspd_application_received_ID",
57, "dbo_rspd_application_received_referenceID",
58, "dbo_rspd_application_received_applicationNo",
59, "dbo_rspd_application_received_companyNameA",
60, "dbo_rspd_application_received_userCreate",
61, "dbo_rspd_application_received_userUpdate",
62, "dbo_rspd_application_received_dateCreated",
63, "dbo_rspd_application_received_dateUpdated",
64, "dbo_rspd_application_received_companyNameB",
65, "dbo_rspd_application_received_siteNameA",
66, "dbo_rspd_application_received_siteNameB",
67, "dbo_rspd_application_received_siteIDA",
68, "dbo_rspd_application_received_siteIDB",
69, "dbo_rspd_application_received_coordinateA",
70, "dbo_rspd_application_received_coordinateB",
71, "dbo_rspd_application_received_elevationA",
72, "dbo_rspd_application_received_elevationB",
73, "dbo_rspd_application_received_makeTypeModelA",
74, "dbo_rspd_application_received_gainA",
75, "dbo_rspd_application_received_diameterA",
76, "dbo_rspd_application_received_beamwidthA",
77, "dbo_rspd_application_received_polarizationA",
78, "dbo_rspd_application_received_azimuthA",
79, "dbo_rspd_application_received_elevAngleA",
80, "dbo_rspd_application_received_heightAGLA",
81, "dbo_rspd_application_received_feederLengthA",
82, "dbo_rspd_application_received_makeTypeModelB",
83, "dbo_rspd_application_received_gainB",
84, "dbo_rspd_application_received_diameterB",
85, "dbo_rspd_application_received_beamwidthB",
86, "dbo_rspd_application_received_polarizationB",
87, "dbo_rspd_application_received_azimuthB",
88, "dbo_rspd_application_received_elevAngleB",
89, "dbo_rspd_application_received_heightAGLB",
90, "dbo_rspd_application_received_feederLengthB",
91, "dbo_rspd_application_received_longtitudeA",
92, "dbo_rspd_application_received_longtitudeB",
93, "dbo_rspd_application_received_latitudeA",
94, "dbo_rspd_application_received_latitudeB",
95, "dbo_rspd_application_received_callSignA",
96, "dbo_rspd_application_received_callSignB",
97, "dbo_rspd_application_received_applicationType",
98, "dbo_rspd_application_received_unit_a",
99, "dbo_rspd_application_received_street_a",
100, "dbo_rspd_application_received_barangay_a",
101, "dbo_rspd_application_received_city_a",
102, "dbo_rspd_application_received_province_a",
103, "dbo_rspd_application_received_zipcode_a",
104, "dbo_rspd_application_received_unit_b",
105, "dbo_rspd_application_received_street_b",
106, "dbo_rspd_application_received_barangay_b",
107, "dbo_rspd_application_received_city_b",
108, "dbo_rspd_application_received_province_b",
109, "dbo_rspd_application_received_zipcode_b",
110, "dbo_rspd_application_received_map",
111, "dbo_rspd_application_received_stage",
112, "dbo_rspd_application_received_stageStatus",
113, "dbo_rspd_application_received_externalReferenceNo",
114, "dbo_rspd_application_received_classStationService",
115, "dbo_rspd_application_received_modeOfOperation",
116, "dbo_rspd_application_received_Remarks",
117, "dbo_rspd_application_received_dateOfApprovedBrief",
118, "dbo_rspd_application_received_recommendations",
119, "dbo_rspd_application_received_applicationCategory",
120, "dbo_rspd_application_received_address" ),
"googleLikeFields", new XVar( 0, "dbo_rspdHeader_ID",
1, "dbo_rspdHeader_referenceID",
2, "dbo_rspdHeader_applicationNo",
3, "dbo_rspdHeader_companyNameA",
4, "dbo_rspdHeader_userCreate",
5, "dbo_rspdHeader_userUpdate",
6, "dbo_rspdHeader_dateCreated",
7, "dbo_rspdHeader_dateUpdated",
8, "dbo_rspdHeader_companyNameB",
9, "dbo_rspdHeader_siteNameA",
10, "dbo_rspdHeader_siteNameB",
11, "dbo_rspdHeader_siteIDA",
12, "dbo_rspdHeader_siteIDB",
13, "dbo_rspdHeader_coordinateA",
14, "dbo_rspdHeader_coordinateB",
15, "dbo_rspdHeader_elevationA",
16, "dbo_rspdHeader_elevationB",
17, "dbo_rspdHeader_makeTypeModelA",
18, "dbo_rspdHeader_gainA",
19, "dbo_rspdHeader_diameterA",
20, "dbo_rspdHeader_beamwidthA",
21, "dbo_rspdHeader_polarizationA",
22, "dbo_rspdHeader_azimuthA",
23, "dbo_rspdHeader_elevAngleA",
24, "dbo_rspdHeader_heightAGLA",
25, "dbo_rspdHeader_feederLengthA",
26, "dbo_rspdHeader_makeTypeModelB",
27, "dbo_rspdHeader_gainB",
28, "dbo_rspdHeader_diameterB",
29, "dbo_rspdHeader_beamwidthB",
30, "dbo_rspdHeader_polarizationB",
31, "dbo_rspdHeader_azimuthB",
32, "dbo_rspdHeader_elevAngleB",
33, "dbo_rspdHeader_heightAGLB",
34, "dbo_rspdHeader_feederLengthB",
35, "dbo_rspdHeader_longtitudeA",
36, "dbo_rspdHeader_longtitudeB",
37, "dbo_rspdHeader_latitudeA",
38, "dbo_rspdHeader_latitudeB",
39, "dbo_rspdHeader_callSignA",
40, "dbo_rspdHeader_callSignB",
41, "dbo_rspdHeader_applicationType" ) ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "dashboard",
"type", "dashboard",
"layoutId", "leftbar",
"disabled", 0,
"default", 0,
"forms", new XVar( "grid", new XVar( "modelId", "dashboard-grid",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c" ) ),
"section", "" ),
1, new XVar( "section", "",
"cells", new XVar( 0, new XVar( "cell", "c2" ),
1, new XVar( "cell", "c3" ) ) ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "dashboard-item" ),
"width", "" ),
"c", new XVar( "model", "c1",
"items", XVar.Array(),
"width", "" ),
"c2", new XVar( "model", "c1",
"items", new XVar( 0, "dashboard-item1" ),
"width", "" ),
"c3", new XVar( "model", "c1",
"items", XVar.Array(),
"width", "" ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"left", new XVar( "modelId", "leftbar-dashboard",
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
"supertop", new XVar( "modelId", "leftbar-top-dashboard",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "expand_menu_button",
1, "collapse_button",
2, "breadcrumb" ) ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "simple_search",
1, "username_button" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "dashboard-top",
"grid", XVar.Array(),
"cells", new XVar(  ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "breadcrumb", new XVar( "type", "breadcrumb" ),
"logo", new XVar( "type", "logo" ),
"menu", new XVar( "type", "menu" ),
"simple_search", new XVar( "type", "simple_search" ),
"expand_menu_button", new XVar( "type", "expand_menu_button" ),
"collapse_button", new XVar( "type", "collapse_button" ),
"username_button", new XVar( "type", "username_button",
"items", new XVar( 0, "userinfo_link",
1, "logout_link",
2, "adminarea_link" ) ),
"userinfo_link", new XVar( "type", "userinfo_link" ),
"logout_link", new XVar( "type", "logout_link" ),
"adminarea_link", new XVar( "type", "adminarea_link" ),
"dashboard-item", new XVar( "type", "dashboard-item",
"table", "dbo.rspd_application_received",
"dashType", 0,
"dashName", "dbo_rspd_application_received_grid",
"bsStyle", "primary",
"panelType", 1,
"icon", new XVar( "glyph", "tree-conifer" ),
"viewTab", true,
"editTab", true,
"addTab", true,
"initialTab", 0,
"hiddenDetails", new XVar(  ),
"detailsOptions", XVar.Array(),
"mapUpdateGridWhenMoved", true,
"height", "500px",
"reloadInterval", 0,
"detailsFilterByMaster", false,
"detailsMasterTable", null,
"viewRecord", true,
"inlineEdit", false,
"pageId", "list" ),
"dashboard-item1", new XVar( "type", "dashboard-item",
"table", "dbo.rspdHeader",
"dashType", 6,
"dashName", "dbo_rspdHeader_map",
"bsStyle", "primary",
"panelType", 1,
"icon", new XVar( "fa", "star-o" ),
"viewTab", true,
"editTab", true,
"addTab", true,
"initialTab", 0,
"hiddenDetails", new XVar(  ),
"detailsOptions", XVar.Array(),
"mapUpdateGridWhenMoved", true,
"height", "500px",
"reloadInterval", 0,
"detailsFilterByMaster", false,
"detailsMasterTable", null,
"mapZoom", "10",
"mapLatField", "latitudeA",
"mapLonField", "longtitudeA",
"mapDescField", "siteNameA",
"mapMarkerIcon", "",
"mapShowLocation", true,
"mapLocationIcon", "" ),
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