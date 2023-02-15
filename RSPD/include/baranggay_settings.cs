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
	public static partial class Settings_baranggay
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["baranggay"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".ShortName"] = "baranggay";
			tdataArray["baranggay"][".OwnerID"] = "";
			tdataArray["baranggay"][".OriginalTable"] = "dbo.baranggay";
			tdataArray["baranggay"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["baranggay"][".originalPagesByType"] = tdataArray["baranggay"][".pagesByType"];
			tdataArray["baranggay"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["baranggay"][".originalPages"] = tdataArray["baranggay"][".pages"];
			tdataArray["baranggay"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["baranggay"][".originalDefaultPages"] = tdataArray["baranggay"][".defaultPages"];
			fieldLabelsArray["baranggay"] = SettingsMap.GetArray();
			fieldToolTipsArray["baranggay"] = SettingsMap.GetArray();
			pageTitlesArray["baranggay"] = SettingsMap.GetArray();
			placeHoldersArray["baranggay"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["baranggay"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["baranggay"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["baranggay"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["baranggay"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["baranggay"]["English"]["id"] = "Id";
				fieldToolTipsArray["baranggay"]["English"]["id"] = "";
				placeHoldersArray["baranggay"]["English"]["id"] = "";
				fieldLabelsArray["baranggay"]["English"]["barangay"] = "Barangay";
				fieldToolTipsArray["baranggay"]["English"]["barangay"] = "";
				placeHoldersArray["baranggay"]["English"]["barangay"] = "";
				fieldLabelsArray["baranggay"]["English"]["city"] = "City";
				fieldToolTipsArray["baranggay"]["English"]["city"] = "";
				placeHoldersArray["baranggay"]["English"]["city"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["baranggay"]["English"])))
				{
					tdataArray["baranggay"][".isUseToolTips"] = true;
				}
			}
			tdataArray["baranggay"][".NCSearch"] = true;
			tdataArray["baranggay"][".shortTableName"] = "baranggay";
			tdataArray["baranggay"][".nSecOptions"] = 0;
			tdataArray["baranggay"][".mainTableOwnerID"] = "";
			tdataArray["baranggay"][".entityType"] = 0;
			tdataArray["baranggay"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["baranggay"][".strOriginalTableName"] = "dbo.baranggay";
			tdataArray["baranggay"][".showAddInPopup"] = false;
			tdataArray["baranggay"][".showEditInPopup"] = false;
			tdataArray["baranggay"][".showViewInPopup"] = false;
			tdataArray["baranggay"][".listAjax"] = false;
			tdataArray["baranggay"][".audit"] = true;
			tdataArray["baranggay"][".locking"] = false;
			GlobalVars.pages = tdataArray["baranggay"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["baranggay"][".edit"] = true;
				tdataArray["baranggay"][".afterEditAction"] = 1;
				tdataArray["baranggay"][".closePopupAfterEdit"] = 1;
				tdataArray["baranggay"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["baranggay"][".add"] = true;
				tdataArray["baranggay"][".afterAddAction"] = 1;
				tdataArray["baranggay"][".closePopupAfterAdd"] = 1;
				tdataArray["baranggay"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["baranggay"][".list"] = true;
			}
			tdataArray["baranggay"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["baranggay"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["baranggay"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["baranggay"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["baranggay"][".printFriendly"] = true;
			}
			tdataArray["baranggay"][".showSimpleSearchOptions"] = true;
			tdataArray["baranggay"][".allowShowHideFields"] = true;
			tdataArray["baranggay"][".allowFieldsReordering"] = true;
			tdataArray["baranggay"][".isUseAjaxSuggest"] = true;


			tdataArray["baranggay"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["baranggay"][".buttonsAdded"] = false;
			tdataArray["baranggay"][".addPageEvents"] = false;
			tdataArray["baranggay"][".isUseTimeForSearch"] = false;
			tdataArray["baranggay"][".badgeColor"] = "4682b4";
			tdataArray["baranggay"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".googleLikeFields"].Add("id");
			tdataArray["baranggay"][".googleLikeFields"].Add("barangay");
			tdataArray["baranggay"][".googleLikeFields"].Add("city");
			tdataArray["baranggay"][".tableType"] = "list";
			tdataArray["baranggay"][".printerPageOrientation"] = 0;
			tdataArray["baranggay"][".nPrinterPageScale"] = 100;
			tdataArray["baranggay"][".nPrinterSplitRecords"] = 40;
			tdataArray["baranggay"][".geocodingEnabled"] = false;
			tdataArray["baranggay"][".pageSize"] = 20;
			tdataArray["baranggay"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["baranggay"][".strOrderBy"] = tstrOrderBy;
			tdataArray["baranggay"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["baranggay"][".sqlHead"] = "SELECT id,  	barangay,  	city";
			tdataArray["baranggay"][".sqlFrom"] = "FROM dbo.baranggay";
			tdataArray["baranggay"][".sqlWhereExpr"] = "";
			tdataArray["baranggay"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["baranggay"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["baranggay"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["baranggay"][".highlightSearchResults"] = true;
			tableKeysArray["baranggay"] = SettingsMap.GetArray();
			tableKeysArray["baranggay"].Add("id");
			tdataArray["baranggay"][".Keys"] = tableKeysArray["baranggay"];
			tdataArray["baranggay"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.baranggay";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_baranggay","id");
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
			tdataArray["baranggay"]["id"] = fdata;
			tdataArray["baranggay"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "barangay";
			fdata["GoodName"] = "barangay";
			fdata["ownerTable"] = "dbo.baranggay";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_baranggay","barangay");
			fdata["FieldType"] = 200;
			fdata["strField"] = "barangay";
			fdata["sourceSingle"] = "barangay";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "barangay";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=150");
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
			tdataArray["baranggay"]["barangay"] = fdata;
			tdataArray["baranggay"][".searchableFields"].Add("barangay");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "city";
			fdata["GoodName"] = "city";
			fdata["ownerTable"] = "dbo.baranggay";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_baranggay","city");
			fdata["FieldType"] = 3;
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
			tdataArray["baranggay"]["city"] = fdata;
			tdataArray["baranggay"][".searchableFields"].Add("city");
			GlobalVars.tables_data["dbo.baranggay"] = tdataArray["baranggay"];
			GlobalVars.field_labels["dbo_baranggay"] = fieldLabelsArray["baranggay"];
			GlobalVars.fieldToolTips["dbo_baranggay"] = fieldToolTipsArray["baranggay"];
			GlobalVars.placeHolders["dbo_baranggay"] = placeHoldersArray["baranggay"];
			GlobalVars.page_titles["dbo_baranggay"] = pageTitlesArray["baranggay"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.baranggay"));
			GlobalVars.detailsTablesData["dbo.baranggay"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.baranggay"] = SettingsMap.GetArray();


			strOriginalDetailsTable = "dbo.city";
			masterParams = SettingsMap.GetArray();
			masterParams["mDataSourceTable"] = "dbo.city";
			masterParams["mOriginalTable"] = strOriginalDetailsTable;
			masterParams["mShortTable"] = "city";
			masterParams["masterKeys"] = SettingsMap.GetArray();
			masterParams["detailKeys"] = SettingsMap.GetArray();
			masterParams["type"] = Constants.PAGE_LIST;
			GlobalVars.masterTablesData["dbo.baranggay"][0] = masterParams;
			GlobalVars.masterTablesData["dbo.baranggay"][0]["masterKeys"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.baranggay"][0]["masterKeys"].Add("zipcode");
			GlobalVars.masterTablesData["dbo.baranggay"][0]["detailKeys"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.baranggay"][0]["detailKeys"].Add("city");

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	barangay,  	city";
protoArray["0"]["m_strFrom"] = "FROM dbo.baranggay";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.baranggay", "m_srcTableName", "dbo.baranggay"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.baranggay";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "barangay", "m_strTable", "dbo.baranggay", "m_srcTableName", "dbo.baranggay"));

protoArray["8"]["m_sql"] = "barangay";
protoArray["8"]["m_srcTableName"] = "dbo.baranggay";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "city", "m_strTable", "dbo.baranggay", "m_srcTableName", "dbo.baranggay"));

protoArray["10"]["m_sql"] = "city";
protoArray["10"]["m_srcTableName"] = "dbo.baranggay";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.baranggay";
protoArray["13"]["m_srcTableName"] = "dbo.baranggay";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("id");
protoArray["13"]["m_columns"].Add("barangay");
protoArray["13"]["m_columns"].Add("city");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.baranggay";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "dbo.baranggay";
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
protoArray["0"]["m_srcTableName"] = "dbo.baranggay";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["baranggay"] = obj;

				
		
			tdataArray["baranggay"][".sqlquery"] = queryData_Array["baranggay"];
			tdataArray["baranggay"][".hasEvents"] = false;
		}
	}

}
