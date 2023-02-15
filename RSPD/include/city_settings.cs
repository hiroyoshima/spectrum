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
	public static partial class Settings_city
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["city"] = SettingsMap.GetArray();
			tdataArray["city"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["city"][".ShortName"] = "city";
			tdataArray["city"][".OwnerID"] = "";
			tdataArray["city"][".OriginalTable"] = "dbo.city";
			tdataArray["city"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"masterlist\":[\"masterlist\"],\"masterprint\":[\"masterprint\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["city"][".originalPagesByType"] = tdataArray["city"][".pagesByType"];
			tdataArray["city"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"masterlist\":[\"masterlist\"],\"masterprint\":[\"masterprint\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["city"][".originalPages"] = tdataArray["city"][".pages"];
			tdataArray["city"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"masterlist\":\"masterlist\",\"masterprint\":\"masterprint\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["city"][".originalDefaultPages"] = tdataArray["city"][".defaultPages"];
			fieldLabelsArray["city"] = SettingsMap.GetArray();
			fieldToolTipsArray["city"] = SettingsMap.GetArray();
			pageTitlesArray["city"] = SettingsMap.GetArray();
			placeHoldersArray["city"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["city"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["city"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["city"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["city"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["city"]["English"]["id"] = "Id";
				fieldToolTipsArray["city"]["English"]["id"] = "";
				placeHoldersArray["city"]["English"]["id"] = "";
				fieldLabelsArray["city"]["English"]["city"] = "City";
				fieldToolTipsArray["city"]["English"]["city"] = "";
				placeHoldersArray["city"]["English"]["city"] = "";
				fieldLabelsArray["city"]["English"]["province"] = "Province";
				fieldToolTipsArray["city"]["English"]["province"] = "";
				placeHoldersArray["city"]["English"]["province"] = "";
				fieldLabelsArray["city"]["English"]["zipcode"] = "Zipcode";
				fieldToolTipsArray["city"]["English"]["zipcode"] = "";
				placeHoldersArray["city"]["English"]["zipcode"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["city"]["English"])))
				{
					tdataArray["city"][".isUseToolTips"] = true;
				}
			}
			tdataArray["city"][".NCSearch"] = true;
			tdataArray["city"][".shortTableName"] = "city";
			tdataArray["city"][".nSecOptions"] = 0;
			tdataArray["city"][".mainTableOwnerID"] = "";
			tdataArray["city"][".entityType"] = 0;
			tdataArray["city"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["city"][".strOriginalTableName"] = "dbo.city";
			tdataArray["city"][".showAddInPopup"] = false;
			tdataArray["city"][".showEditInPopup"] = false;
			tdataArray["city"][".showViewInPopup"] = false;
			tdataArray["city"][".listAjax"] = false;
			tdataArray["city"][".audit"] = true;
			tdataArray["city"][".locking"] = false;
			GlobalVars.pages = tdataArray["city"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["city"][".edit"] = true;
				tdataArray["city"][".afterEditAction"] = 1;
				tdataArray["city"][".closePopupAfterEdit"] = 1;
				tdataArray["city"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["city"][".add"] = true;
				tdataArray["city"][".afterAddAction"] = 1;
				tdataArray["city"][".closePopupAfterAdd"] = 1;
				tdataArray["city"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["city"][".list"] = true;
			}
			tdataArray["city"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["city"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["city"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["city"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["city"][".printFriendly"] = true;
			}
			tdataArray["city"][".showSimpleSearchOptions"] = true;
			tdataArray["city"][".allowShowHideFields"] = true;
			tdataArray["city"][".allowFieldsReordering"] = true;
			tdataArray["city"][".isUseAjaxSuggest"] = true;


			tdataArray["city"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["city"][".buttonsAdded"] = false;
			tdataArray["city"][".addPageEvents"] = false;
			tdataArray["city"][".isUseTimeForSearch"] = false;
			tdataArray["city"][".badgeColor"] = "00c2c5";
			tdataArray["city"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["city"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["city"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["city"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["city"][".googleLikeFields"].Add("id");
			tdataArray["city"][".googleLikeFields"].Add("city");
			tdataArray["city"][".googleLikeFields"].Add("province");
			tdataArray["city"][".googleLikeFields"].Add("zipcode");
			tdataArray["city"][".tableType"] = "list";
			tdataArray["city"][".printerPageOrientation"] = 0;
			tdataArray["city"][".nPrinterPageScale"] = 100;
			tdataArray["city"][".nPrinterSplitRecords"] = 40;
			tdataArray["city"][".geocodingEnabled"] = false;
			tdataArray["city"][".pageSize"] = 20;
			tdataArray["city"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["city"][".strOrderBy"] = tstrOrderBy;
			tdataArray["city"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["city"][".sqlHead"] = "SELECT id,  	city,  	province,  	zipcode";
			tdataArray["city"][".sqlFrom"] = "FROM dbo.city";
			tdataArray["city"][".sqlWhereExpr"] = "";
			tdataArray["city"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["city"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["city"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["city"][".highlightSearchResults"] = true;
			tableKeysArray["city"] = SettingsMap.GetArray();
			tableKeysArray["city"].Add("id");
			tdataArray["city"][".Keys"] = tableKeysArray["city"];
			tdataArray["city"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.city";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_city","id");
			fdata["FieldType"] = 3;
			fdata["AutoInc"] = true;
			fdata["strField"] = "id";
			fdata["sourceSingle"] = "id";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "id";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Text field");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["IsRequired"] = true;
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["HTML5InuptType"] = "text";
			edata["EditParams"] = "";
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"].Add(CommonFunctions.getJsValidatorName(new XVar("Number")));
			edata["validateAs"]["basicValidate"].Add("IsRequired");
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "Contains";
			fdata["searchOptionsList"] = new XVar(0, "Contains", 1, "Equals", 2, "Starts with", 3, "More than", 4, "Less than", 5, "Between", 6, "Empty", 7, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["city"]["id"] = fdata;
			tdataArray["city"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "city";
			fdata["GoodName"] = "city";
			fdata["ownerTable"] = "dbo.city";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_city","city");
			fdata["FieldType"] = 200;
			fdata["strField"] = "city";
			fdata["sourceSingle"] = "city";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "city";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Text field");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["HTML5InuptType"] = "text";
			edata["EditParams"] = "";
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=50");
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "Contains";
			fdata["searchOptionsList"] = new XVar(0, "Contains", 1, "Equals", 2, "Starts with", 3, "More than", 4, "Less than", 5, "Between", 6, "Empty", 7, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["city"]["city"] = fdata;
			tdataArray["city"][".searchableFields"].Add("city");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "province";
			fdata["GoodName"] = "province";
			fdata["ownerTable"] = "dbo.city";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_city","province");
			fdata["FieldType"] = 200;
			fdata["strField"] = "province";
			fdata["sourceSingle"] = "province";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "province";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Lookup wizard");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["LookupType"] = 2;
			edata["LookupTable"] = "dbo.province";
			edata["autoCompleteFieldsOnEdit"] = 0;
			edata["autoCompleteFields"] = SettingsMap.GetArray();
			edata["LCType"] = 0;
			edata["LinkField"] = "province";
			edata["LinkFieldType"] = 0;
			edata["DisplayField"] = "province";
			edata["LookupOrderBy"] = "";
			edata["SelectSize"] = 1;
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "Equals";
			fdata["searchOptionsList"] = new XVar(0, "Contains", 1, "Equals", 2, "Starts with", 3, "More than", 4, "Less than", 5, "Between", 6, "Empty", 7, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["city"]["province"] = fdata;
			tdataArray["city"][".searchableFields"].Add("province");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "zipcode";
			fdata["GoodName"] = "zipcode";
			fdata["ownerTable"] = "dbo.city";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_city","zipcode");
			fdata["FieldType"] = 3;
			fdata["strField"] = "zipcode";
			fdata["sourceSingle"] = "zipcode";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "zipcode";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Text field");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["HTML5InuptType"] = "text";
			edata["EditParams"] = "";
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"].Add(CommonFunctions.getJsValidatorName(new XVar("Number")));
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "Contains";
			fdata["searchOptionsList"] = new XVar(0, "Contains", 1, "Equals", 2, "Starts with", 3, "More than", 4, "Less than", 5, "Between", 6, "Empty", 7, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["city"]["zipcode"] = fdata;
			tdataArray["city"][".searchableFields"].Add("zipcode");
			GlobalVars.tables_data["dbo.city"] = tdataArray["city"];
			GlobalVars.field_labels["dbo_city"] = fieldLabelsArray["city"];
			GlobalVars.fieldToolTips["dbo_city"] = fieldToolTipsArray["city"];
			GlobalVars.placeHolders["dbo_city"] = placeHoldersArray["city"];
			GlobalVars.page_titles["dbo_city"] = pageTitlesArray["city"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.city"));
			GlobalVars.detailsTablesData["dbo.city"] = SettingsMap.GetArray();


			dIndex = 0;
			detailsParam = SettingsMap.GetArray();
			detailsParam["dDataSourceTable"] = "dbo.baranggay";
			detailsParam["dOriginalTable"] = "dbo.baranggay";
			detailsParam["dType"] = Constants.PAGE_LIST;
			detailsParam["dShortTable"] = "baranggay";
			detailsParam["dCaptionTable"] = CommonFunctions.GetTableCaption(new XVar("dbo_baranggay"));
			detailsParam["masterKeys"] = SettingsMap.GetArray();
			detailsParam["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.city"][dIndex] = detailsParam;
			GlobalVars.detailsTablesData["dbo.city"][dIndex]["masterKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.city"][dIndex]["masterKeys"].Add("zipcode");
			GlobalVars.detailsTablesData["dbo.city"][dIndex]["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.city"][dIndex]["detailKeys"].Add("city");
			GlobalVars.masterTablesData["dbo.city"] = SettingsMap.GetArray();


			strOriginalDetailsTable = "dbo.province";
			masterParams = SettingsMap.GetArray();
			masterParams["mDataSourceTable"] = "dbo.province";
			masterParams["mOriginalTable"] = strOriginalDetailsTable;
			masterParams["mShortTable"] = "province";
			masterParams["masterKeys"] = SettingsMap.GetArray();
			masterParams["detailKeys"] = SettingsMap.GetArray();
			masterParams["type"] = Constants.PAGE_LIST;
			GlobalVars.masterTablesData["dbo.city"][0] = masterParams;
			GlobalVars.masterTablesData["dbo.city"][0]["masterKeys"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.city"][0]["masterKeys"].Add("id");
			GlobalVars.masterTablesData["dbo.city"][0]["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.city"][0]["detailKeys"].Add("province");

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	city,  	province,  	zipcode";
protoArray["0"]["m_strFrom"] = "FROM dbo.city";
protoArray["0"]["m_strWhere"] = "";
protoArray["0"]["m_strOrderBy"] = "";
	
		
protoArray["0"]["cipherer"] = null;
protoArray["2"] = SettingsMap.GetArray();
protoArray["2"]["m_sql"] = "";
protoArray["2"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["2"]["m_column"] = obj;
protoArray["2"]["m_contained"] = SettingsMap.GetArray();
protoArray["2"]["m_strCase"] = "";
protoArray["2"]["m_havingmode"] = false;
protoArray["2"]["m_inBrackets"] = false;
protoArray["2"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["2"]);

protoArray["0"]["m_where"] = obj;
protoArray["4"] = SettingsMap.GetArray();
protoArray["4"]["m_sql"] = "";
protoArray["4"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["4"]["m_column"] = obj;
protoArray["4"]["m_contained"] = SettingsMap.GetArray();
protoArray["4"]["m_strCase"] = "";
protoArray["4"]["m_havingmode"] = false;
protoArray["4"]["m_inBrackets"] = false;
protoArray["4"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["4"]);

protoArray["0"]["m_having"] = obj;
protoArray["0"]["m_fieldlist"] = SettingsMap.GetArray();
protoArray["6"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.city", "m_srcTableName", "dbo.city"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.city";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "city", "m_strTable", "dbo.city", "m_srcTableName", "dbo.city"));

protoArray["8"]["m_sql"] = "city";
protoArray["8"]["m_srcTableName"] = "dbo.city";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "province", "m_strTable", "dbo.city", "m_srcTableName", "dbo.city"));

protoArray["10"]["m_sql"] = "province";
protoArray["10"]["m_srcTableName"] = "dbo.city";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "zipcode", "m_strTable", "dbo.city", "m_srcTableName", "dbo.city"));

protoArray["12"]["m_sql"] = "zipcode";
protoArray["12"]["m_srcTableName"] = "dbo.city";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["14"] = SettingsMap.GetArray();
protoArray["14"]["m_link"] = "SQLL_MAIN";
protoArray["15"] = SettingsMap.GetArray();
protoArray["15"]["m_strName"] = "dbo.city";
protoArray["15"]["m_srcTableName"] = "dbo.city";
protoArray["15"]["m_columns"] = SettingsMap.GetArray();
protoArray["15"]["m_columns"].Add("id");
protoArray["15"]["m_columns"].Add("city");
protoArray["15"]["m_columns"].Add("province");
protoArray["15"]["m_columns"].Add("zipcode");
obj = new SQLTable(protoArray["15"]);

protoArray["14"]["m_table"] = obj;
protoArray["14"]["m_sql"] = "dbo.city";
protoArray["14"]["m_alias"] = "";
protoArray["14"]["m_srcTableName"] = "dbo.city";
protoArray["16"] = SettingsMap.GetArray();
protoArray["16"]["m_sql"] = "";
protoArray["16"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["16"]["m_column"] = obj;
protoArray["16"]["m_contained"] = SettingsMap.GetArray();
protoArray["16"]["m_strCase"] = "";
protoArray["16"]["m_havingmode"] = false;
protoArray["16"]["m_inBrackets"] = false;
protoArray["16"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["16"]);

protoArray["14"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["14"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.city";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["city"] = obj;

				
		
			tdataArray["city"][".sqlquery"] = queryData_Array["city"];
			tdataArray["city"][".hasEvents"] = false;
		}
	}

}
