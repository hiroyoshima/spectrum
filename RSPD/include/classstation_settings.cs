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
	public static partial class Settings_classstation
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["classstation"] = SettingsMap.GetArray();
			tdataArray["classstation"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["classstation"][".ShortName"] = "classstation";
			tdataArray["classstation"][".OwnerID"] = "";
			tdataArray["classstation"][".OriginalTable"] = "dbo.classStation";
			tdataArray["classstation"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["classstation"][".originalPagesByType"] = tdataArray["classstation"][".pagesByType"];
			tdataArray["classstation"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["classstation"][".originalPages"] = tdataArray["classstation"][".pages"];
			tdataArray["classstation"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["classstation"][".originalDefaultPages"] = tdataArray["classstation"][".defaultPages"];
			fieldLabelsArray["classstation"] = SettingsMap.GetArray();
			fieldToolTipsArray["classstation"] = SettingsMap.GetArray();
			pageTitlesArray["classstation"] = SettingsMap.GetArray();
			placeHoldersArray["classstation"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["classstation"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["classstation"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["classstation"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["classstation"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["classstation"]["English"]["id"] = "Id";
				fieldToolTipsArray["classstation"]["English"]["id"] = "";
				placeHoldersArray["classstation"]["English"]["id"] = "";
				fieldLabelsArray["classstation"]["English"]["classStationService"] = "Class Station or Service";
				fieldToolTipsArray["classstation"]["English"]["classStationService"] = "";
				placeHoldersArray["classstation"]["English"]["classStationService"] = "";
				fieldLabelsArray["classstation"]["English"]["application_type"] = "Application Type";
				fieldToolTipsArray["classstation"]["English"]["application_type"] = "";
				placeHoldersArray["classstation"]["English"]["application_type"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["classstation"]["English"])))
				{
					tdataArray["classstation"][".isUseToolTips"] = true;
				}
			}
			tdataArray["classstation"][".NCSearch"] = true;
			tdataArray["classstation"][".shortTableName"] = "classstation";
			tdataArray["classstation"][".nSecOptions"] = 0;
			tdataArray["classstation"][".mainTableOwnerID"] = "";
			tdataArray["classstation"][".entityType"] = 0;
			tdataArray["classstation"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["classstation"][".strOriginalTableName"] = "dbo.classStation";
			tdataArray["classstation"][".showAddInPopup"] = false;
			tdataArray["classstation"][".showEditInPopup"] = false;
			tdataArray["classstation"][".showViewInPopup"] = false;
			tdataArray["classstation"][".listAjax"] = false;
			tdataArray["classstation"][".audit"] = false;
			tdataArray["classstation"][".locking"] = false;
			GlobalVars.pages = tdataArray["classstation"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["classstation"][".edit"] = true;
				tdataArray["classstation"][".afterEditAction"] = 1;
				tdataArray["classstation"][".closePopupAfterEdit"] = 1;
				tdataArray["classstation"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["classstation"][".add"] = true;
				tdataArray["classstation"][".afterAddAction"] = 1;
				tdataArray["classstation"][".closePopupAfterAdd"] = 1;
				tdataArray["classstation"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["classstation"][".list"] = true;
			}
			tdataArray["classstation"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["classstation"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["classstation"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["classstation"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["classstation"][".printFriendly"] = true;
			}
			tdataArray["classstation"][".showSimpleSearchOptions"] = true;
			tdataArray["classstation"][".allowShowHideFields"] = true;
			tdataArray["classstation"][".allowFieldsReordering"] = true;
			tdataArray["classstation"][".isUseAjaxSuggest"] = true;


			tdataArray["classstation"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["classstation"][".buttonsAdded"] = false;
			tdataArray["classstation"][".addPageEvents"] = false;
			tdataArray["classstation"][".isUseTimeForSearch"] = false;
			tdataArray["classstation"][".badgeColor"] = "EDCA00";
			tdataArray["classstation"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["classstation"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["classstation"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["classstation"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["classstation"][".googleLikeFields"].Add("id");
			tdataArray["classstation"][".googleLikeFields"].Add("classStationService");
			tdataArray["classstation"][".googleLikeFields"].Add("application_type");
			tdataArray["classstation"][".tableType"] = "list";
			tdataArray["classstation"][".printerPageOrientation"] = 0;
			tdataArray["classstation"][".nPrinterPageScale"] = 100;
			tdataArray["classstation"][".nPrinterSplitRecords"] = 40;
			tdataArray["classstation"][".geocodingEnabled"] = false;
			tdataArray["classstation"][".pageSize"] = 20;
			tdataArray["classstation"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["classstation"][".strOrderBy"] = tstrOrderBy;
			tdataArray["classstation"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["classstation"][".sqlHead"] = "SELECT id,  	classStationService,  	application_type";
			tdataArray["classstation"][".sqlFrom"] = "FROM dbo.classStation";
			tdataArray["classstation"][".sqlWhereExpr"] = "";
			tdataArray["classstation"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["classstation"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["classstation"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["classstation"][".highlightSearchResults"] = true;
			tableKeysArray["classstation"] = SettingsMap.GetArray();
			tableKeysArray["classstation"].Add("id");
			tdataArray["classstation"][".Keys"] = tableKeysArray["classstation"];
			tdataArray["classstation"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.classStation";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_classStation","id");
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
			tdataArray["classstation"]["id"] = fdata;
			tdataArray["classstation"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "classStationService";
			fdata["GoodName"] = "classStationService";
			fdata["ownerTable"] = "dbo.classStation";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_classStation","classStationService");
			fdata["FieldType"] = 200;
			fdata["strField"] = "classStationService";
			fdata["sourceSingle"] = "classStationService";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "classStationService";
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
			tdataArray["classstation"]["classStationService"] = fdata;
			tdataArray["classstation"][".searchableFields"].Add("classStationService");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "application_type";
			fdata["GoodName"] = "application_type";
			fdata["ownerTable"] = "dbo.classStation";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_classStation","application_type");
			fdata["FieldType"] = 200;
			fdata["strField"] = "application_type";
			fdata["sourceSingle"] = "application_type";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "application_type";
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
			tdataArray["classstation"]["application_type"] = fdata;
			tdataArray["classstation"][".searchableFields"].Add("application_type");
			GlobalVars.tables_data["dbo.classStation"] = tdataArray["classstation"];
			GlobalVars.field_labels["dbo_classStation"] = fieldLabelsArray["classstation"];
			GlobalVars.fieldToolTips["dbo_classStation"] = fieldToolTipsArray["classstation"];
			GlobalVars.placeHolders["dbo_classStation"] = placeHoldersArray["classstation"];
			GlobalVars.page_titles["dbo_classStation"] = pageTitlesArray["classstation"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.classStation"));
			GlobalVars.detailsTablesData["dbo.classStation"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.classStation"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	classStationService,  	application_type";
protoArray["0"]["m_strFrom"] = "FROM dbo.classStation";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.classStation", "m_srcTableName", "dbo.classStation"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.classStation";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "classStationService", "m_strTable", "dbo.classStation", "m_srcTableName", "dbo.classStation"));

protoArray["8"]["m_sql"] = "classStationService";
protoArray["8"]["m_srcTableName"] = "dbo.classStation";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "application_type", "m_strTable", "dbo.classStation", "m_srcTableName", "dbo.classStation"));

protoArray["10"]["m_sql"] = "application_type";
protoArray["10"]["m_srcTableName"] = "dbo.classStation";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.classStation";
protoArray["13"]["m_srcTableName"] = "dbo.classStation";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("id");
protoArray["13"]["m_columns"].Add("classStationService");
protoArray["13"]["m_columns"].Add("application_type");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.classStation";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "dbo.classStation";
protoArray["14"] = SettingsMap.GetArray();
protoArray["14"]["m_sql"] = "";
protoArray["14"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["14"]["m_column"] = obj;
protoArray["14"]["m_contained"] = SettingsMap.GetArray();
protoArray["14"]["m_strCase"] = "";
protoArray["14"]["m_havingmode"] = false;
protoArray["14"]["m_inBrackets"] = false;
protoArray["14"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["14"]);

protoArray["12"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["12"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.classStation";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["classstation"] = obj;

				
		
			tdataArray["classstation"][".sqlquery"] = queryData_Array["classstation"];
			tdataArray["classstation"][".hasEvents"] = false;
		}
	}

}
