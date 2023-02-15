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
	public static partial class Settings_dbo_company
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["dbo_company"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".ShortName"] = "dbo_company";
			tdataArray["dbo_company"][".OwnerID"] = "";
			tdataArray["dbo_company"][".OriginalTable"] = "dbo.company";
			tdataArray["dbo_company"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["dbo_company"][".originalPagesByType"] = tdataArray["dbo_company"][".pagesByType"];
			tdataArray["dbo_company"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["dbo_company"][".originalPages"] = tdataArray["dbo_company"][".pages"];
			tdataArray["dbo_company"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["dbo_company"][".originalDefaultPages"] = tdataArray["dbo_company"][".defaultPages"];
			fieldLabelsArray["dbo_company"] = SettingsMap.GetArray();
			fieldToolTipsArray["dbo_company"] = SettingsMap.GetArray();
			pageTitlesArray["dbo_company"] = SettingsMap.GetArray();
			placeHoldersArray["dbo_company"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["dbo_company"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["dbo_company"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["dbo_company"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["dbo_company"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["dbo_company"]["English"]["id"] = "Id";
				fieldToolTipsArray["dbo_company"]["English"]["id"] = "";
				placeHoldersArray["dbo_company"]["English"]["id"] = "";
				fieldLabelsArray["dbo_company"]["English"]["companyName"] = "Company Name";
				fieldToolTipsArray["dbo_company"]["English"]["companyName"] = "";
				placeHoldersArray["dbo_company"]["English"]["companyName"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["dbo_company"]["English"])))
				{
					tdataArray["dbo_company"][".isUseToolTips"] = true;
				}
			}
			tdataArray["dbo_company"][".NCSearch"] = true;
			tdataArray["dbo_company"][".shortTableName"] = "dbo_company";
			tdataArray["dbo_company"][".nSecOptions"] = 0;
			tdataArray["dbo_company"][".mainTableOwnerID"] = "";
			tdataArray["dbo_company"][".entityType"] = 0;
			tdataArray["dbo_company"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["dbo_company"][".strOriginalTableName"] = "dbo.company";
			tdataArray["dbo_company"][".showAddInPopup"] = false;
			tdataArray["dbo_company"][".showEditInPopup"] = false;
			tdataArray["dbo_company"][".showViewInPopup"] = false;
			tdataArray["dbo_company"][".listAjax"] = false;
			tdataArray["dbo_company"][".audit"] = true;
			tdataArray["dbo_company"][".locking"] = false;
			GlobalVars.pages = tdataArray["dbo_company"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["dbo_company"][".edit"] = true;
				tdataArray["dbo_company"][".afterEditAction"] = 1;
				tdataArray["dbo_company"][".closePopupAfterEdit"] = 1;
				tdataArray["dbo_company"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["dbo_company"][".add"] = true;
				tdataArray["dbo_company"][".afterAddAction"] = 1;
				tdataArray["dbo_company"][".closePopupAfterAdd"] = 1;
				tdataArray["dbo_company"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["dbo_company"][".list"] = true;
			}
			tdataArray["dbo_company"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["dbo_company"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["dbo_company"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["dbo_company"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["dbo_company"][".printFriendly"] = true;
			}
			tdataArray["dbo_company"][".showSimpleSearchOptions"] = true;
			tdataArray["dbo_company"][".allowShowHideFields"] = true;
			tdataArray["dbo_company"][".allowFieldsReordering"] = true;
			tdataArray["dbo_company"][".isUseAjaxSuggest"] = true;


			tdataArray["dbo_company"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["dbo_company"][".buttonsAdded"] = false;
			tdataArray["dbo_company"][".addPageEvents"] = false;
			tdataArray["dbo_company"][".isUseTimeForSearch"] = false;
			tdataArray["dbo_company"][".badgeColor"] = "4682B4";
			tdataArray["dbo_company"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".googleLikeFields"].Add("id");
			tdataArray["dbo_company"][".googleLikeFields"].Add("companyName");
			tdataArray["dbo_company"][".tableType"] = "list";
			tdataArray["dbo_company"][".printerPageOrientation"] = 0;
			tdataArray["dbo_company"][".nPrinterPageScale"] = 100;
			tdataArray["dbo_company"][".nPrinterSplitRecords"] = 40;
			tdataArray["dbo_company"][".geocodingEnabled"] = false;
			tdataArray["dbo_company"][".pageSize"] = 20;
			tdataArray["dbo_company"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["dbo_company"][".strOrderBy"] = tstrOrderBy;
			tdataArray["dbo_company"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["dbo_company"][".sqlHead"] = "SELECT id,  	companyName";
			tdataArray["dbo_company"][".sqlFrom"] = "FROM dbo.company";
			tdataArray["dbo_company"][".sqlWhereExpr"] = "";
			tdataArray["dbo_company"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["dbo_company"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["dbo_company"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["dbo_company"][".highlightSearchResults"] = true;
			tableKeysArray["dbo_company"] = SettingsMap.GetArray();
			tableKeysArray["dbo_company"].Add("id");
			tdataArray["dbo_company"][".Keys"] = tableKeysArray["dbo_company"];
			tdataArray["dbo_company"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.company";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_company","id");
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
			tdataArray["dbo_company"]["id"] = fdata;
			tdataArray["dbo_company"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "companyName";
			fdata["GoodName"] = "companyName";
			fdata["ownerTable"] = "dbo.company";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_company","companyName");
			fdata["FieldType"] = 200;
			fdata["strField"] = "companyName";
			fdata["sourceSingle"] = "companyName";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "companyName";
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
			tdataArray["dbo_company"]["companyName"] = fdata;
			tdataArray["dbo_company"][".searchableFields"].Add("companyName");
			GlobalVars.tables_data["dbo.company"] = tdataArray["dbo_company"];
			GlobalVars.field_labels["dbo_company"] = fieldLabelsArray["dbo_company"];
			GlobalVars.fieldToolTips["dbo_company"] = fieldToolTipsArray["dbo_company"];
			GlobalVars.placeHolders["dbo_company"] = placeHoldersArray["dbo_company"];
			GlobalVars.page_titles["dbo_company"] = pageTitlesArray["dbo_company"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.company"));
			GlobalVars.detailsTablesData["dbo.company"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.company"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	companyName";
protoArray["0"]["m_strFrom"] = "FROM dbo.company";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.company", "m_srcTableName", "dbo.company"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.company";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "companyName", "m_strTable", "dbo.company", "m_srcTableName", "dbo.company"));

protoArray["8"]["m_sql"] = "companyName";
protoArray["8"]["m_srcTableName"] = "dbo.company";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["10"] = SettingsMap.GetArray();
protoArray["10"]["m_link"] = "SQLL_MAIN";
protoArray["11"] = SettingsMap.GetArray();
protoArray["11"]["m_strName"] = "dbo.company";
protoArray["11"]["m_srcTableName"] = "dbo.company";
protoArray["11"]["m_columns"] = SettingsMap.GetArray();
protoArray["11"]["m_columns"].Add("id");
protoArray["11"]["m_columns"].Add("companyName");
obj = new SQLTable(protoArray["11"]);

protoArray["10"]["m_table"] = obj;
protoArray["10"]["m_sql"] = "dbo.company";
protoArray["10"]["m_alias"] = "";
protoArray["10"]["m_srcTableName"] = "dbo.company";
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
protoArray["0"]["m_srcTableName"] = "dbo.company";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["dbo_company"] = obj;

				
		
			tdataArray["dbo_company"][".sqlquery"] = queryData_Array["dbo_company"];
			tdataArray["dbo_company"][".hasEvents"] = false;
		}
	}

}
