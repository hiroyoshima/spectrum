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
	public static partial class Settings_spectrum_betaugrights
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".ShortName"] = "spectrum_betaugrights";
			tdataArray["spectrum_betaugrights"][".OwnerID"] = "";
			tdataArray["spectrum_betaugrights"][".OriginalTable"] = "dbo.spectrum_betaugrights";
			tdataArray["spectrum_betaugrights"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["spectrum_betaugrights"][".originalPagesByType"] = tdataArray["spectrum_betaugrights"][".pagesByType"];
			tdataArray["spectrum_betaugrights"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["spectrum_betaugrights"][".originalPages"] = tdataArray["spectrum_betaugrights"][".pages"];
			tdataArray["spectrum_betaugrights"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["spectrum_betaugrights"][".originalDefaultPages"] = tdataArray["spectrum_betaugrights"][".defaultPages"];
			fieldLabelsArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			fieldToolTipsArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			pageTitlesArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			placeHoldersArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["spectrum_betaugrights"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["spectrum_betaugrights"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["spectrum_betaugrights"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["spectrum_betaugrights"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["spectrum_betaugrights"]["English"]["TableName"] = "Table Name";
				fieldToolTipsArray["spectrum_betaugrights"]["English"]["TableName"] = "";
				placeHoldersArray["spectrum_betaugrights"]["English"]["TableName"] = "";
				fieldLabelsArray["spectrum_betaugrights"]["English"]["GroupID"] = "Group ID";
				fieldToolTipsArray["spectrum_betaugrights"]["English"]["GroupID"] = "";
				placeHoldersArray["spectrum_betaugrights"]["English"]["GroupID"] = "";
				fieldLabelsArray["spectrum_betaugrights"]["English"]["AccessMask"] = "Access Mask";
				fieldToolTipsArray["spectrum_betaugrights"]["English"]["AccessMask"] = "";
				placeHoldersArray["spectrum_betaugrights"]["English"]["AccessMask"] = "";
				fieldLabelsArray["spectrum_betaugrights"]["English"]["Page"] = "Page";
				fieldToolTipsArray["spectrum_betaugrights"]["English"]["Page"] = "";
				placeHoldersArray["spectrum_betaugrights"]["English"]["Page"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["spectrum_betaugrights"]["English"])))
				{
					tdataArray["spectrum_betaugrights"][".isUseToolTips"] = true;
				}
			}
			tdataArray["spectrum_betaugrights"][".NCSearch"] = true;
			tdataArray["spectrum_betaugrights"][".shortTableName"] = "spectrum_betaugrights";
			tdataArray["spectrum_betaugrights"][".nSecOptions"] = 0;
			tdataArray["spectrum_betaugrights"][".mainTableOwnerID"] = "";
			tdataArray["spectrum_betaugrights"][".entityType"] = 0;
			tdataArray["spectrum_betaugrights"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["spectrum_betaugrights"][".strOriginalTableName"] = "dbo.spectrum_betaugrights";
			tdataArray["spectrum_betaugrights"][".showAddInPopup"] = false;
			tdataArray["spectrum_betaugrights"][".showEditInPopup"] = false;
			tdataArray["spectrum_betaugrights"][".showViewInPopup"] = false;
			tdataArray["spectrum_betaugrights"][".listAjax"] = false;
			tdataArray["spectrum_betaugrights"][".audit"] = false;
			tdataArray["spectrum_betaugrights"][".locking"] = false;
			GlobalVars.pages = tdataArray["spectrum_betaugrights"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["spectrum_betaugrights"][".edit"] = true;
				tdataArray["spectrum_betaugrights"][".afterEditAction"] = 1;
				tdataArray["spectrum_betaugrights"][".closePopupAfterEdit"] = 1;
				tdataArray["spectrum_betaugrights"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["spectrum_betaugrights"][".add"] = true;
				tdataArray["spectrum_betaugrights"][".afterAddAction"] = 1;
				tdataArray["spectrum_betaugrights"][".closePopupAfterAdd"] = 1;
				tdataArray["spectrum_betaugrights"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["spectrum_betaugrights"][".list"] = true;
			}
			tdataArray["spectrum_betaugrights"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["spectrum_betaugrights"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["spectrum_betaugrights"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["spectrum_betaugrights"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["spectrum_betaugrights"][".printFriendly"] = true;
			}
			tdataArray["spectrum_betaugrights"][".showSimpleSearchOptions"] = true;
			tdataArray["spectrum_betaugrights"][".allowShowHideFields"] = true;
			tdataArray["spectrum_betaugrights"][".allowFieldsReordering"] = true;
			tdataArray["spectrum_betaugrights"][".isUseAjaxSuggest"] = true;


			tdataArray["spectrum_betaugrights"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["spectrum_betaugrights"][".buttonsAdded"] = false;
			tdataArray["spectrum_betaugrights"][".addPageEvents"] = false;
			tdataArray["spectrum_betaugrights"][".isUseTimeForSearch"] = false;
			tdataArray["spectrum_betaugrights"][".badgeColor"] = "8FBC8B";
			tdataArray["spectrum_betaugrights"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".googleLikeFields"].Add("TableName");
			tdataArray["spectrum_betaugrights"][".googleLikeFields"].Add("GroupID");
			tdataArray["spectrum_betaugrights"][".googleLikeFields"].Add("AccessMask");
			tdataArray["spectrum_betaugrights"][".googleLikeFields"].Add("Page");
			tdataArray["spectrum_betaugrights"][".tableType"] = "list";
			tdataArray["spectrum_betaugrights"][".printerPageOrientation"] = 0;
			tdataArray["spectrum_betaugrights"][".nPrinterPageScale"] = 100;
			tdataArray["spectrum_betaugrights"][".nPrinterSplitRecords"] = 40;
			tdataArray["spectrum_betaugrights"][".geocodingEnabled"] = false;
			tdataArray["spectrum_betaugrights"][".pageSize"] = 20;
			tdataArray["spectrum_betaugrights"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["spectrum_betaugrights"][".strOrderBy"] = tstrOrderBy;
			tdataArray["spectrum_betaugrights"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugrights"][".sqlHead"] = "SELECT TableName,  	GroupID,  	AccessMask,  	Page";
			tdataArray["spectrum_betaugrights"][".sqlFrom"] = "FROM dbo.spectrum_betaugrights";
			tdataArray["spectrum_betaugrights"][".sqlWhereExpr"] = "";
			tdataArray["spectrum_betaugrights"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["spectrum_betaugrights"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["spectrum_betaugrights"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["spectrum_betaugrights"][".highlightSearchResults"] = true;
			tableKeysArray["spectrum_betaugrights"] = SettingsMap.GetArray();
			tableKeysArray["spectrum_betaugrights"].Add("TableName");
			tableKeysArray["spectrum_betaugrights"].Add("GroupID");
			tdataArray["spectrum_betaugrights"][".Keys"] = tableKeysArray["spectrum_betaugrights"];
			tdataArray["spectrum_betaugrights"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "TableName";
			fdata["GoodName"] = "TableName";
			fdata["ownerTable"] = "dbo.spectrum_betaugrights";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugrights","TableName");
			fdata["FieldType"] = 200;
			fdata["strField"] = "TableName";
			fdata["sourceSingle"] = "TableName";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "TableName";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=255");
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
			tdataArray["spectrum_betaugrights"]["TableName"] = fdata;
			tdataArray["spectrum_betaugrights"][".searchableFields"].Add("TableName");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "GroupID";
			fdata["GoodName"] = "GroupID";
			fdata["ownerTable"] = "dbo.spectrum_betaugrights";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugrights","GroupID");
			fdata["FieldType"] = 3;
			fdata["strField"] = "GroupID";
			fdata["sourceSingle"] = "GroupID";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "GroupID";
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
			tdataArray["spectrum_betaugrights"]["GroupID"] = fdata;
			tdataArray["spectrum_betaugrights"][".searchableFields"].Add("GroupID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "AccessMask";
			fdata["GoodName"] = "AccessMask";
			fdata["ownerTable"] = "dbo.spectrum_betaugrights";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugrights","AccessMask");
			fdata["FieldType"] = 200;
			fdata["strField"] = "AccessMask";
			fdata["sourceSingle"] = "AccessMask";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "AccessMask";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=10");
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
			tdataArray["spectrum_betaugrights"]["AccessMask"] = fdata;
			tdataArray["spectrum_betaugrights"][".searchableFields"].Add("AccessMask");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "Page";
			fdata["GoodName"] = "Page";
			fdata["ownerTable"] = "dbo.spectrum_betaugrights";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugrights","Page");
			fdata["FieldType"] = 201;
			fdata["strField"] = "Page";
			fdata["sourceSingle"] = "Page";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "Page";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Text area");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 0;
			edata["nRows"] = 100;
			edata["nCols"] = 200;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["CreateThumbnail"] = true;
			edata["StrThumbnail"] = "th";
			edata["ThumbnailSize"] = 600;
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
			tdataArray["spectrum_betaugrights"]["Page"] = fdata;
			tdataArray["spectrum_betaugrights"][".searchableFields"].Add("Page");
			GlobalVars.tables_data["dbo.spectrum_betaugrights"] = tdataArray["spectrum_betaugrights"];
			GlobalVars.field_labels["dbo_spectrum_betaugrights"] = fieldLabelsArray["spectrum_betaugrights"];
			GlobalVars.fieldToolTips["dbo_spectrum_betaugrights"] = fieldToolTipsArray["spectrum_betaugrights"];
			GlobalVars.placeHolders["dbo_spectrum_betaugrights"] = placeHoldersArray["spectrum_betaugrights"];
			GlobalVars.page_titles["dbo_spectrum_betaugrights"] = pageTitlesArray["spectrum_betaugrights"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.spectrum_betaugrights"));
			GlobalVars.detailsTablesData["dbo.spectrum_betaugrights"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.spectrum_betaugrights"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "TableName,  	GroupID,  	AccessMask,  	Page";
protoArray["0"]["m_strFrom"] = "FROM dbo.spectrum_betaugrights";
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
obj = new SQLField(new XVar("m_strName", "TableName", "m_strTable", "dbo.spectrum_betaugrights", "m_srcTableName", "dbo.spectrum_betaugrights"));

protoArray["6"]["m_sql"] = "TableName";
protoArray["6"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "GroupID", "m_strTable", "dbo.spectrum_betaugrights", "m_srcTableName", "dbo.spectrum_betaugrights"));

protoArray["8"]["m_sql"] = "GroupID";
protoArray["8"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "AccessMask", "m_strTable", "dbo.spectrum_betaugrights", "m_srcTableName", "dbo.spectrum_betaugrights"));

protoArray["10"]["m_sql"] = "AccessMask";
protoArray["10"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Page", "m_strTable", "dbo.spectrum_betaugrights", "m_srcTableName", "dbo.spectrum_betaugrights"));

protoArray["12"]["m_sql"] = "Page";
protoArray["12"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["14"] = SettingsMap.GetArray();
protoArray["14"]["m_link"] = "SQLL_MAIN";
protoArray["15"] = SettingsMap.GetArray();
protoArray["15"]["m_strName"] = "dbo.spectrum_betaugrights";
protoArray["15"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
protoArray["15"]["m_columns"] = SettingsMap.GetArray();
protoArray["15"]["m_columns"].Add("TableName");
protoArray["15"]["m_columns"].Add("GroupID");
protoArray["15"]["m_columns"].Add("AccessMask");
protoArray["15"]["m_columns"].Add("Page");
obj = new SQLTable(protoArray["15"]);

protoArray["14"]["m_table"] = obj;
protoArray["14"]["m_sql"] = "dbo.spectrum_betaugrights";
protoArray["14"]["m_alias"] = "";
protoArray["14"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
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
protoArray["0"]["m_srcTableName"] = "dbo.spectrum_betaugrights";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["spectrum_betaugrights"] = obj;

				
		
			tdataArray["spectrum_betaugrights"][".sqlquery"] = queryData_Array["spectrum_betaugrights"];
			tdataArray["spectrum_betaugrights"][".hasEvents"] = false;
		}
	}

}
