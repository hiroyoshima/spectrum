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
	public static partial class Settings_region
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["region"] = SettingsMap.GetArray();
			tdataArray["region"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["region"][".ShortName"] = "region";
			tdataArray["region"][".OwnerID"] = "";
			tdataArray["region"][".OriginalTable"] = "dbo.region";
			tdataArray["region"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["region"][".originalPagesByType"] = tdataArray["region"][".pagesByType"];
			tdataArray["region"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["region"][".originalPages"] = tdataArray["region"][".pages"];
			tdataArray["region"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["region"][".originalDefaultPages"] = tdataArray["region"][".defaultPages"];
			fieldLabelsArray["region"] = SettingsMap.GetArray();
			fieldToolTipsArray["region"] = SettingsMap.GetArray();
			pageTitlesArray["region"] = SettingsMap.GetArray();
			placeHoldersArray["region"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["region"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["region"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["region"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["region"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["region"]["English"]["id"] = "Id";
				fieldToolTipsArray["region"]["English"]["id"] = "";
				placeHoldersArray["region"]["English"]["id"] = "";
				fieldLabelsArray["region"]["English"]["region"] = "Region";
				fieldToolTipsArray["region"]["English"]["region"] = "";
				placeHoldersArray["region"]["English"]["region"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["region"]["English"])))
				{
					tdataArray["region"][".isUseToolTips"] = true;
				}
			}
			tdataArray["region"][".NCSearch"] = true;
			tdataArray["region"][".shortTableName"] = "region";
			tdataArray["region"][".nSecOptions"] = 0;
			tdataArray["region"][".mainTableOwnerID"] = "";
			tdataArray["region"][".entityType"] = 0;
			tdataArray["region"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["region"][".strOriginalTableName"] = "dbo.region";
			tdataArray["region"][".showAddInPopup"] = false;
			tdataArray["region"][".showEditInPopup"] = false;
			tdataArray["region"][".showViewInPopup"] = false;
			tdataArray["region"][".listAjax"] = false;
			tdataArray["region"][".audit"] = false;
			tdataArray["region"][".locking"] = false;
			GlobalVars.pages = tdataArray["region"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["region"][".edit"] = true;
				tdataArray["region"][".afterEditAction"] = 1;
				tdataArray["region"][".closePopupAfterEdit"] = 1;
				tdataArray["region"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["region"][".add"] = true;
				tdataArray["region"][".afterAddAction"] = 1;
				tdataArray["region"][".closePopupAfterAdd"] = 1;
				tdataArray["region"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["region"][".list"] = true;
			}
			tdataArray["region"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["region"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["region"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["region"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["region"][".printFriendly"] = true;
			}
			tdataArray["region"][".showSimpleSearchOptions"] = true;
			tdataArray["region"][".allowShowHideFields"] = true;
			tdataArray["region"][".allowFieldsReordering"] = true;
			tdataArray["region"][".isUseAjaxSuggest"] = true;


			tdataArray["region"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["region"][".buttonsAdded"] = false;
			tdataArray["region"][".addPageEvents"] = false;
			tdataArray["region"][".isUseTimeForSearch"] = false;
			tdataArray["region"][".badgeColor"] = "CD853F";
			tdataArray["region"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["region"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["region"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["region"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["region"][".googleLikeFields"].Add("id");
			tdataArray["region"][".googleLikeFields"].Add("region");
			tdataArray["region"][".tableType"] = "list";
			tdataArray["region"][".printerPageOrientation"] = 0;
			tdataArray["region"][".nPrinterPageScale"] = 100;
			tdataArray["region"][".nPrinterSplitRecords"] = 40;
			tdataArray["region"][".geocodingEnabled"] = false;
			tdataArray["region"][".pageSize"] = 20;
			tdataArray["region"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["region"][".strOrderBy"] = tstrOrderBy;
			tdataArray["region"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["region"][".sqlHead"] = "SELECT id,  	region";
			tdataArray["region"][".sqlFrom"] = "FROM dbo.region";
			tdataArray["region"][".sqlWhereExpr"] = "";
			tdataArray["region"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["region"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["region"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["region"][".highlightSearchResults"] = true;
			tableKeysArray["region"] = SettingsMap.GetArray();
			tableKeysArray["region"].Add("id");
			tdataArray["region"][".Keys"] = tableKeysArray["region"];
			tdataArray["region"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.region";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_region","id");
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
			tdataArray["region"]["id"] = fdata;
			tdataArray["region"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "region";
			fdata["GoodName"] = "region";
			fdata["ownerTable"] = "dbo.region";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_region","region");
			fdata["FieldType"] = 200;
			fdata["strField"] = "region";
			fdata["sourceSingle"] = "region";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "region";
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
			tdataArray["region"]["region"] = fdata;
			tdataArray["region"][".searchableFields"].Add("region");
			GlobalVars.tables_data["dbo.region"] = tdataArray["region"];
			GlobalVars.field_labels["dbo_region"] = fieldLabelsArray["region"];
			GlobalVars.fieldToolTips["dbo_region"] = fieldToolTipsArray["region"];
			GlobalVars.placeHolders["dbo_region"] = placeHoldersArray["region"];
			GlobalVars.page_titles["dbo_region"] = pageTitlesArray["region"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.region"));
			GlobalVars.detailsTablesData["dbo.region"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.region"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	region";
protoArray["0"]["m_strFrom"] = "FROM dbo.region";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.region", "m_srcTableName", "dbo.region"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.region";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "region", "m_strTable", "dbo.region", "m_srcTableName", "dbo.region"));

protoArray["8"]["m_sql"] = "region";
protoArray["8"]["m_srcTableName"] = "dbo.region";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["10"] = SettingsMap.GetArray();
protoArray["10"]["m_link"] = "SQLL_MAIN";
protoArray["11"] = SettingsMap.GetArray();
protoArray["11"]["m_strName"] = "dbo.region";
protoArray["11"]["m_srcTableName"] = "dbo.region";
protoArray["11"]["m_columns"] = SettingsMap.GetArray();
protoArray["11"]["m_columns"].Add("id");
protoArray["11"]["m_columns"].Add("region");
obj = new SQLTable(protoArray["11"]);

protoArray["10"]["m_table"] = obj;
protoArray["10"]["m_sql"] = "dbo.region";
protoArray["10"]["m_alias"] = "";
protoArray["10"]["m_srcTableName"] = "dbo.region";
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
protoArray["0"]["m_srcTableName"] = "dbo.region";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["region"] = obj;

				
		
			tdataArray["region"][".sqlquery"] = queryData_Array["region"];
			tdataArray["region"][".hasEvents"] = false;
		}
	}

}
