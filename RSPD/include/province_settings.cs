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
	public static partial class Settings_province
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["province"] = SettingsMap.GetArray();
			tdataArray["province"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["province"][".ShortName"] = "province";
			tdataArray["province"][".OwnerID"] = "";
			tdataArray["province"][".OriginalTable"] = "dbo.province";
			tdataArray["province"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"masterlist\":[\"masterlist\"],\"masterprint\":[\"masterprint\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["province"][".originalPagesByType"] = tdataArray["province"][".pagesByType"];
			tdataArray["province"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"masterlist\":[\"masterlist\"],\"masterprint\":[\"masterprint\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["province"][".originalPages"] = tdataArray["province"][".pages"];
			tdataArray["province"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"masterlist\":\"masterlist\",\"masterprint\":\"masterprint\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["province"][".originalDefaultPages"] = tdataArray["province"][".defaultPages"];
			fieldLabelsArray["province"] = SettingsMap.GetArray();
			fieldToolTipsArray["province"] = SettingsMap.GetArray();
			pageTitlesArray["province"] = SettingsMap.GetArray();
			placeHoldersArray["province"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["province"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["province"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["province"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["province"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["province"]["English"]["id"] = "Id";
				fieldToolTipsArray["province"]["English"]["id"] = "";
				placeHoldersArray["province"]["English"]["id"] = "";
				fieldLabelsArray["province"]["English"]["province"] = "Province";
				fieldToolTipsArray["province"]["English"]["province"] = "";
				placeHoldersArray["province"]["English"]["province"] = "";
				fieldLabelsArray["province"]["English"]["region"] = "Region";
				fieldToolTipsArray["province"]["English"]["region"] = "";
				placeHoldersArray["province"]["English"]["region"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["province"]["English"])))
				{
					tdataArray["province"][".isUseToolTips"] = true;
				}
			}
			tdataArray["province"][".NCSearch"] = true;
			tdataArray["province"][".shortTableName"] = "province";
			tdataArray["province"][".nSecOptions"] = 0;
			tdataArray["province"][".mainTableOwnerID"] = "";
			tdataArray["province"][".entityType"] = 0;
			tdataArray["province"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["province"][".strOriginalTableName"] = "dbo.province";
			tdataArray["province"][".showAddInPopup"] = false;
			tdataArray["province"][".showEditInPopup"] = false;
			tdataArray["province"][".showViewInPopup"] = false;
			tdataArray["province"][".listAjax"] = false;
			tdataArray["province"][".audit"] = true;
			tdataArray["province"][".locking"] = false;
			GlobalVars.pages = tdataArray["province"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["province"][".edit"] = true;
				tdataArray["province"][".afterEditAction"] = 1;
				tdataArray["province"][".closePopupAfterEdit"] = 1;
				tdataArray["province"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["province"][".add"] = true;
				tdataArray["province"][".afterAddAction"] = 1;
				tdataArray["province"][".closePopupAfterAdd"] = 1;
				tdataArray["province"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["province"][".list"] = true;
			}
			tdataArray["province"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["province"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["province"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["province"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["province"][".printFriendly"] = true;
			}
			tdataArray["province"][".showSimpleSearchOptions"] = true;
			tdataArray["province"][".allowShowHideFields"] = true;
			tdataArray["province"][".allowFieldsReordering"] = true;
			tdataArray["province"][".isUseAjaxSuggest"] = true;


			tdataArray["province"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["province"][".buttonsAdded"] = false;
			tdataArray["province"][".addPageEvents"] = false;
			tdataArray["province"][".isUseTimeForSearch"] = false;
			tdataArray["province"][".badgeColor"] = "BC8F8F";
			tdataArray["province"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["province"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["province"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["province"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["province"][".googleLikeFields"].Add("id");
			tdataArray["province"][".googleLikeFields"].Add("province");
			tdataArray["province"][".googleLikeFields"].Add("region");
			tdataArray["province"][".tableType"] = "list";
			tdataArray["province"][".printerPageOrientation"] = 0;
			tdataArray["province"][".nPrinterPageScale"] = 100;
			tdataArray["province"][".nPrinterSplitRecords"] = 40;
			tdataArray["province"][".geocodingEnabled"] = false;
			tdataArray["province"][".pageSize"] = 20;
			tdataArray["province"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["province"][".strOrderBy"] = tstrOrderBy;
			tdataArray["province"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["province"][".sqlHead"] = "SELECT id,  	province,  	region";
			tdataArray["province"][".sqlFrom"] = "FROM dbo.province";
			tdataArray["province"][".sqlWhereExpr"] = "";
			tdataArray["province"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["province"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["province"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["province"][".highlightSearchResults"] = true;
			tableKeysArray["province"] = SettingsMap.GetArray();
			tableKeysArray["province"].Add("id");
			tdataArray["province"][".Keys"] = tableKeysArray["province"];
			tdataArray["province"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.province";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_province","id");
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
			tdataArray["province"]["id"] = fdata;
			tdataArray["province"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "province";
			fdata["GoodName"] = "province";
			fdata["ownerTable"] = "dbo.province";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_province","province");
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
			tdataArray["province"]["province"] = fdata;
			tdataArray["province"][".searchableFields"].Add("province");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "region";
			fdata["GoodName"] = "region";
			fdata["ownerTable"] = "dbo.province";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_province","region");
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
			edata = new XVar("EditFormat", "Lookup wizard");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["LookupType"] = 2;
			edata["LookupTable"] = "dbo.region";
			edata["autoCompleteFieldsOnEdit"] = 0;
			edata["autoCompleteFields"] = SettingsMap.GetArray();
			edata["LCType"] = 0;
			edata["LinkField"] = "region";
			edata["LinkFieldType"] = 0;
			edata["DisplayField"] = "region";
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
			tdataArray["province"]["region"] = fdata;
			tdataArray["province"][".searchableFields"].Add("region");
			GlobalVars.tables_data["dbo.province"] = tdataArray["province"];
			GlobalVars.field_labels["dbo_province"] = fieldLabelsArray["province"];
			GlobalVars.fieldToolTips["dbo_province"] = fieldToolTipsArray["province"];
			GlobalVars.placeHolders["dbo_province"] = placeHoldersArray["province"];
			GlobalVars.page_titles["dbo_province"] = pageTitlesArray["province"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.province"));
			GlobalVars.detailsTablesData["dbo.province"] = SettingsMap.GetArray();


			dIndex = 0;
			detailsParam = SettingsMap.GetArray();
			detailsParam["dDataSourceTable"] = "dbo.city";
			detailsParam["dOriginalTable"] = "dbo.city";
			detailsParam["dType"] = Constants.PAGE_LIST;
			detailsParam["dShortTable"] = "city";
			detailsParam["dCaptionTable"] = CommonFunctions.GetTableCaption(new XVar("dbo_city"));
			detailsParam["masterKeys"] = SettingsMap.GetArray();
			detailsParam["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.province"][dIndex] = detailsParam;
			GlobalVars.detailsTablesData["dbo.province"][dIndex]["masterKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.province"][dIndex]["masterKeys"].Add("id");
			GlobalVars.detailsTablesData["dbo.province"][dIndex]["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.detailsTablesData["dbo.province"][dIndex]["detailKeys"].Add("province");
			GlobalVars.masterTablesData["dbo.province"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	province,  	region";
protoArray["0"]["m_strFrom"] = "FROM dbo.province";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.province", "m_srcTableName", "dbo.province"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.province";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "province", "m_strTable", "dbo.province", "m_srcTableName", "dbo.province"));

protoArray["8"]["m_sql"] = "province";
protoArray["8"]["m_srcTableName"] = "dbo.province";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "region", "m_strTable", "dbo.province", "m_srcTableName", "dbo.province"));

protoArray["10"]["m_sql"] = "region";
protoArray["10"]["m_srcTableName"] = "dbo.province";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.province";
protoArray["13"]["m_srcTableName"] = "dbo.province";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("id");
protoArray["13"]["m_columns"].Add("province");
protoArray["13"]["m_columns"].Add("region");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.province";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "dbo.province";
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
protoArray["0"]["m_srcTableName"] = "dbo.province";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["province"] = obj;

				
		
			tdataArray["province"][".sqlquery"] = queryData_Array["province"];
			tdataArray["province"][".hasEvents"] = false;
		}
	}

}
