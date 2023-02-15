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
	public static partial class Settings_stagestatus
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["stagestatus"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".ShortName"] = "stagestatus";
			tdataArray["stagestatus"][".OwnerID"] = "";
			tdataArray["stagestatus"][".OriginalTable"] = "dbo.stageStatus";
			tdataArray["stagestatus"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["stagestatus"][".originalPagesByType"] = tdataArray["stagestatus"][".pagesByType"];
			tdataArray["stagestatus"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["stagestatus"][".originalPages"] = tdataArray["stagestatus"][".pages"];
			tdataArray["stagestatus"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["stagestatus"][".originalDefaultPages"] = tdataArray["stagestatus"][".defaultPages"];
			fieldLabelsArray["stagestatus"] = SettingsMap.GetArray();
			fieldToolTipsArray["stagestatus"] = SettingsMap.GetArray();
			pageTitlesArray["stagestatus"] = SettingsMap.GetArray();
			placeHoldersArray["stagestatus"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["stagestatus"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["stagestatus"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["stagestatus"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["stagestatus"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["stagestatus"]["English"]["ID"] = "ID";
				fieldToolTipsArray["stagestatus"]["English"]["ID"] = "";
				placeHoldersArray["stagestatus"]["English"]["ID"] = "";
				fieldLabelsArray["stagestatus"]["English"]["stage"] = "Stage";
				fieldToolTipsArray["stagestatus"]["English"]["stage"] = "";
				placeHoldersArray["stagestatus"]["English"]["stage"] = "";
				fieldLabelsArray["stagestatus"]["English"]["status"] = "Status";
				fieldToolTipsArray["stagestatus"]["English"]["status"] = "";
				placeHoldersArray["stagestatus"]["English"]["status"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["stagestatus"]["English"])))
				{
					tdataArray["stagestatus"][".isUseToolTips"] = true;
				}
			}
			tdataArray["stagestatus"][".NCSearch"] = true;
			tdataArray["stagestatus"][".shortTableName"] = "stagestatus";
			tdataArray["stagestatus"][".nSecOptions"] = 0;
			tdataArray["stagestatus"][".mainTableOwnerID"] = "";
			tdataArray["stagestatus"][".entityType"] = 0;
			tdataArray["stagestatus"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["stagestatus"][".strOriginalTableName"] = "dbo.stageStatus";
			tdataArray["stagestatus"][".showAddInPopup"] = false;
			tdataArray["stagestatus"][".showEditInPopup"] = false;
			tdataArray["stagestatus"][".showViewInPopup"] = false;
			tdataArray["stagestatus"][".listAjax"] = false;
			tdataArray["stagestatus"][".audit"] = true;
			tdataArray["stagestatus"][".locking"] = false;
			GlobalVars.pages = tdataArray["stagestatus"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["stagestatus"][".edit"] = true;
				tdataArray["stagestatus"][".afterEditAction"] = 1;
				tdataArray["stagestatus"][".closePopupAfterEdit"] = 1;
				tdataArray["stagestatus"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["stagestatus"][".add"] = true;
				tdataArray["stagestatus"][".afterAddAction"] = 1;
				tdataArray["stagestatus"][".closePopupAfterAdd"] = 1;
				tdataArray["stagestatus"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["stagestatus"][".list"] = true;
			}
			tdataArray["stagestatus"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["stagestatus"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["stagestatus"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["stagestatus"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["stagestatus"][".printFriendly"] = true;
			}
			tdataArray["stagestatus"][".showSimpleSearchOptions"] = true;
			tdataArray["stagestatus"][".allowShowHideFields"] = true;
			tdataArray["stagestatus"][".allowFieldsReordering"] = true;
			tdataArray["stagestatus"][".isUseAjaxSuggest"] = true;


			tdataArray["stagestatus"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["stagestatus"][".buttonsAdded"] = false;
			tdataArray["stagestatus"][".addPageEvents"] = false;
			tdataArray["stagestatus"][".isUseTimeForSearch"] = false;
			tdataArray["stagestatus"][".badgeColor"] = "00C2C5";
			tdataArray["stagestatus"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".googleLikeFields"].Add("ID");
			tdataArray["stagestatus"][".googleLikeFields"].Add("stage");
			tdataArray["stagestatus"][".googleLikeFields"].Add("status");
			tdataArray["stagestatus"][".tableType"] = "list";
			tdataArray["stagestatus"][".printerPageOrientation"] = 0;
			tdataArray["stagestatus"][".nPrinterPageScale"] = 100;
			tdataArray["stagestatus"][".nPrinterSplitRecords"] = 40;
			tdataArray["stagestatus"][".geocodingEnabled"] = false;
			tdataArray["stagestatus"][".pageSize"] = 20;
			tdataArray["stagestatus"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["stagestatus"][".strOrderBy"] = tstrOrderBy;
			tdataArray["stagestatus"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["stagestatus"][".sqlHead"] = "SELECT ID,  	stage,  	status";
			tdataArray["stagestatus"][".sqlFrom"] = "FROM dbo.stageStatus";
			tdataArray["stagestatus"][".sqlWhereExpr"] = "";
			tdataArray["stagestatus"][".sqlTail"] = "";
			arrGridTabs = SettingsMap.GetArray();
			arrGridTabs.Add(new XVar("tabId", "", "name", "All data", "nameType", "Text", "where", "", "showRowCount", 0, "hideEmpty", 0));
			tdataArray["stagestatus"][".arrGridTabs"] = arrGridTabs;
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["stagestatus"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["stagestatus"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["stagestatus"][".highlightSearchResults"] = true;
			tableKeysArray["stagestatus"] = SettingsMap.GetArray();
			tableKeysArray["stagestatus"].Add("ID");
			tdataArray["stagestatus"][".Keys"] = tableKeysArray["stagestatus"];
			tdataArray["stagestatus"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "ID";
			fdata["GoodName"] = "ID";
			fdata["ownerTable"] = "dbo.stageStatus";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_stageStatus","ID");
			fdata["FieldType"] = 3;
			fdata["AutoInc"] = true;
			fdata["strField"] = "ID";
			fdata["sourceSingle"] = "ID";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "ID";
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
			tdataArray["stagestatus"]["ID"] = fdata;
			tdataArray["stagestatus"][".searchableFields"].Add("ID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "stage";
			fdata["GoodName"] = "stage";
			fdata["ownerTable"] = "dbo.stageStatus";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_stageStatus","stage");
			fdata["FieldType"] = 3;
			fdata["strField"] = "stage";
			fdata["sourceSingle"] = "stage";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "stage";
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
			edata["LookupTable"] = "dbo.stage";
			edata["autoCompleteFieldsOnEdit"] = 0;
			edata["autoCompleteFields"] = SettingsMap.GetArray();
			edata["LCType"] = 0;
			edata["LinkField"] = "ID";
			edata["LinkFieldType"] = 0;
			edata["DisplayField"] = "StageDescription";
			edata["LookupOrderBy"] = "";
			edata["SelectSize"] = 1;
			edata["IsRequired"] = true;
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"].Add("IsRequired");
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
			tdataArray["stagestatus"]["stage"] = fdata;
			tdataArray["stagestatus"][".searchableFields"].Add("stage");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "status";
			fdata["GoodName"] = "status";
			fdata["ownerTable"] = "dbo.stageStatus";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_stageStatus","status");
			fdata["FieldType"] = 200;
			fdata["strField"] = "status";
			fdata["sourceSingle"] = "status";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "status";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=100");
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
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
			tdataArray["stagestatus"]["status"] = fdata;
			tdataArray["stagestatus"][".searchableFields"].Add("status");
			GlobalVars.tables_data["dbo.stageStatus"] = tdataArray["stagestatus"];
			GlobalVars.field_labels["dbo_stageStatus"] = fieldLabelsArray["stagestatus"];
			GlobalVars.fieldToolTips["dbo_stageStatus"] = fieldToolTipsArray["stagestatus"];
			GlobalVars.placeHolders["dbo_stageStatus"] = placeHoldersArray["stagestatus"];
			GlobalVars.page_titles["dbo_stageStatus"] = pageTitlesArray["stagestatus"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.stageStatus"));
			GlobalVars.detailsTablesData["dbo.stageStatus"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.stageStatus"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "ID,  	stage,  	status";
protoArray["0"]["m_strFrom"] = "FROM dbo.stageStatus";
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
obj = new SQLField(new XVar("m_strName", "ID", "m_strTable", "dbo.stageStatus", "m_srcTableName", "dbo.stageStatus"));

protoArray["6"]["m_sql"] = "ID";
protoArray["6"]["m_srcTableName"] = "dbo.stageStatus";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "stage", "m_strTable", "dbo.stageStatus", "m_srcTableName", "dbo.stageStatus"));

protoArray["8"]["m_sql"] = "stage";
protoArray["8"]["m_srcTableName"] = "dbo.stageStatus";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "status", "m_strTable", "dbo.stageStatus", "m_srcTableName", "dbo.stageStatus"));

protoArray["10"]["m_sql"] = "status";
protoArray["10"]["m_srcTableName"] = "dbo.stageStatus";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.stageStatus";
protoArray["13"]["m_srcTableName"] = "dbo.stageStatus";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("ID");
protoArray["13"]["m_columns"].Add("stage");
protoArray["13"]["m_columns"].Add("status");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.stageStatus";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "dbo.stageStatus";
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
protoArray["0"]["m_srcTableName"] = "dbo.stageStatus";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["stagestatus"] = obj;

				
		
			tdataArray["stagestatus"][".sqlquery"] = queryData_Array["stagestatus"];
			tdataArray["stagestatus"][".hasEvents"] = true;
		}
	}

}
