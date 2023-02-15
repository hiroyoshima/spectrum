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
	public static partial class Settings_stage
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["stage"] = SettingsMap.GetArray();
			tdataArray["stage"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["stage"][".ShortName"] = "stage";
			tdataArray["stage"][".OwnerID"] = "";
			tdataArray["stage"][".OriginalTable"] = "dbo.stage";
			tdataArray["stage"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["stage"][".originalPagesByType"] = tdataArray["stage"][".pagesByType"];
			tdataArray["stage"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["stage"][".originalPages"] = tdataArray["stage"][".pages"];
			tdataArray["stage"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["stage"][".originalDefaultPages"] = tdataArray["stage"][".defaultPages"];
			fieldLabelsArray["stage"] = SettingsMap.GetArray();
			fieldToolTipsArray["stage"] = SettingsMap.GetArray();
			pageTitlesArray["stage"] = SettingsMap.GetArray();
			placeHoldersArray["stage"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["stage"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["stage"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["stage"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["stage"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["stage"]["English"]["ID"] = "ID";
				fieldToolTipsArray["stage"]["English"]["ID"] = "";
				placeHoldersArray["stage"]["English"]["ID"] = "";
				fieldLabelsArray["stage"]["English"]["StageDescription"] = "Stage Description";
				fieldToolTipsArray["stage"]["English"]["StageDescription"] = "";
				placeHoldersArray["stage"]["English"]["StageDescription"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["stage"]["English"])))
				{
					tdataArray["stage"][".isUseToolTips"] = true;
				}
			}
			tdataArray["stage"][".NCSearch"] = true;
			tdataArray["stage"][".shortTableName"] = "stage";
			tdataArray["stage"][".nSecOptions"] = 0;
			tdataArray["stage"][".mainTableOwnerID"] = "";
			tdataArray["stage"][".entityType"] = 0;
			tdataArray["stage"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["stage"][".strOriginalTableName"] = "dbo.stage";
			tdataArray["stage"][".showAddInPopup"] = false;
			tdataArray["stage"][".showEditInPopup"] = false;
			tdataArray["stage"][".showViewInPopup"] = false;
			tdataArray["stage"][".listAjax"] = false;
			tdataArray["stage"][".audit"] = true;
			tdataArray["stage"][".locking"] = false;
			GlobalVars.pages = tdataArray["stage"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["stage"][".edit"] = true;
				tdataArray["stage"][".afterEditAction"] = 1;
				tdataArray["stage"][".closePopupAfterEdit"] = 1;
				tdataArray["stage"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["stage"][".add"] = true;
				tdataArray["stage"][".afterAddAction"] = 1;
				tdataArray["stage"][".closePopupAfterAdd"] = 1;
				tdataArray["stage"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["stage"][".list"] = true;
			}
			tdataArray["stage"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["stage"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["stage"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["stage"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["stage"][".printFriendly"] = true;
			}
			tdataArray["stage"][".showSimpleSearchOptions"] = true;
			tdataArray["stage"][".allowShowHideFields"] = true;
			tdataArray["stage"][".allowFieldsReordering"] = true;
			tdataArray["stage"][".isUseAjaxSuggest"] = true;


			tdataArray["stage"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["stage"][".buttonsAdded"] = false;
			tdataArray["stage"][".addPageEvents"] = false;
			tdataArray["stage"][".isUseTimeForSearch"] = false;
			tdataArray["stage"][".badgeColor"] = "CFAE83";
			tdataArray["stage"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["stage"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["stage"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["stage"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["stage"][".googleLikeFields"].Add("ID");
			tdataArray["stage"][".googleLikeFields"].Add("StageDescription");
			tdataArray["stage"][".tableType"] = "list";
			tdataArray["stage"][".printerPageOrientation"] = 0;
			tdataArray["stage"][".nPrinterPageScale"] = 100;
			tdataArray["stage"][".nPrinterSplitRecords"] = 40;
			tdataArray["stage"][".geocodingEnabled"] = false;
			tdataArray["stage"][".pageSize"] = 20;
			tdataArray["stage"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["stage"][".strOrderBy"] = tstrOrderBy;
			tdataArray["stage"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["stage"][".sqlHead"] = "SELECT ID,  	StageDescription";
			tdataArray["stage"][".sqlFrom"] = "FROM dbo.stage";
			tdataArray["stage"][".sqlWhereExpr"] = "";
			tdataArray["stage"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["stage"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["stage"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["stage"][".highlightSearchResults"] = true;
			tableKeysArray["stage"] = SettingsMap.GetArray();
			tableKeysArray["stage"].Add("ID");
			tdataArray["stage"][".Keys"] = tableKeysArray["stage"];
			tdataArray["stage"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "ID";
			fdata["GoodName"] = "ID";
			fdata["ownerTable"] = "dbo.stage";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_stage","ID");
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
			tdataArray["stage"]["ID"] = fdata;
			tdataArray["stage"][".searchableFields"].Add("ID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "StageDescription";
			fdata["GoodName"] = "StageDescription";
			fdata["ownerTable"] = "dbo.stage";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_stage","StageDescription");
			fdata["FieldType"] = 200;
			fdata["strField"] = "StageDescription";
			fdata["sourceSingle"] = "StageDescription";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "StageDescription";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=50");
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
			tdataArray["stage"]["StageDescription"] = fdata;
			tdataArray["stage"][".searchableFields"].Add("StageDescription");
			GlobalVars.tables_data["dbo.stage"] = tdataArray["stage"];
			GlobalVars.field_labels["dbo_stage"] = fieldLabelsArray["stage"];
			GlobalVars.fieldToolTips["dbo_stage"] = fieldToolTipsArray["stage"];
			GlobalVars.placeHolders["dbo_stage"] = placeHoldersArray["stage"];
			GlobalVars.page_titles["dbo_stage"] = pageTitlesArray["stage"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.stage"));
			GlobalVars.detailsTablesData["dbo.stage"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.stage"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "ID,  	StageDescription";
protoArray["0"]["m_strFrom"] = "FROM dbo.stage";
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
obj = new SQLField(new XVar("m_strName", "ID", "m_strTable", "dbo.stage", "m_srcTableName", "dbo.stage"));

protoArray["6"]["m_sql"] = "ID";
protoArray["6"]["m_srcTableName"] = "dbo.stage";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "StageDescription", "m_strTable", "dbo.stage", "m_srcTableName", "dbo.stage"));

protoArray["8"]["m_sql"] = "StageDescription";
protoArray["8"]["m_srcTableName"] = "dbo.stage";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["10"] = SettingsMap.GetArray();
protoArray["10"]["m_link"] = "SQLL_MAIN";
protoArray["11"] = SettingsMap.GetArray();
protoArray["11"]["m_strName"] = "dbo.stage";
protoArray["11"]["m_srcTableName"] = "dbo.stage";
protoArray["11"]["m_columns"] = SettingsMap.GetArray();
protoArray["11"]["m_columns"].Add("ID");
protoArray["11"]["m_columns"].Add("StageDescription");
obj = new SQLTable(protoArray["11"]);

protoArray["10"]["m_table"] = obj;
protoArray["10"]["m_sql"] = "dbo.stage";
protoArray["10"]["m_alias"] = "";
protoArray["10"]["m_srcTableName"] = "dbo.stage";
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_sql"] = "";
protoArray["12"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["12"]["m_column"] = obj;
protoArray["12"]["m_contained"] = SettingsMap.GetArray();
protoArray["12"]["m_strCase"] = "";
protoArray["12"]["m_havingmode"] = false;
protoArray["12"]["m_inBrackets"] = false;
protoArray["12"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["12"]);

protoArray["10"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["10"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.stage";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["stage"] = obj;

				
		
			tdataArray["stage"][".sqlquery"] = queryData_Array["stage"];
			tdataArray["stage"][".hasEvents"] = false;
		}
	}

}
