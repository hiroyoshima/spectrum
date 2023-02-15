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
	public static partial class Settings_branch
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["branch"] = SettingsMap.GetArray();
			tdataArray["branch"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["branch"][".ShortName"] = "branch";
			tdataArray["branch"][".OwnerID"] = "";
			tdataArray["branch"][".OriginalTable"] = "dbo.branch";
			tdataArray["branch"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["branch"][".originalPagesByType"] = tdataArray["branch"][".pagesByType"];
			tdataArray["branch"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["branch"][".originalPages"] = tdataArray["branch"][".pages"];
			tdataArray["branch"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["branch"][".originalDefaultPages"] = tdataArray["branch"][".defaultPages"];
			fieldLabelsArray["branch"] = SettingsMap.GetArray();
			fieldToolTipsArray["branch"] = SettingsMap.GetArray();
			pageTitlesArray["branch"] = SettingsMap.GetArray();
			placeHoldersArray["branch"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["branch"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["branch"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["branch"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["branch"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["branch"]["English"]["id"] = "Id";
				fieldToolTipsArray["branch"]["English"]["id"] = "";
				placeHoldersArray["branch"]["English"]["id"] = "";
				fieldLabelsArray["branch"]["English"]["branchName"] = "Branch Name";
				fieldToolTipsArray["branch"]["English"]["branchName"] = "";
				placeHoldersArray["branch"]["English"]["branchName"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["branch"]["English"])))
				{
					tdataArray["branch"][".isUseToolTips"] = true;
				}
			}
			tdataArray["branch"][".NCSearch"] = true;
			tdataArray["branch"][".shortTableName"] = "branch";
			tdataArray["branch"][".nSecOptions"] = 0;
			tdataArray["branch"][".mainTableOwnerID"] = "";
			tdataArray["branch"][".entityType"] = 0;
			tdataArray["branch"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["branch"][".strOriginalTableName"] = "dbo.branch";
			tdataArray["branch"][".showAddInPopup"] = false;
			tdataArray["branch"][".showEditInPopup"] = false;
			tdataArray["branch"][".showViewInPopup"] = false;
			tdataArray["branch"][".listAjax"] = false;
			tdataArray["branch"][".audit"] = false;
			tdataArray["branch"][".locking"] = false;
			GlobalVars.pages = tdataArray["branch"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["branch"][".edit"] = true;
				tdataArray["branch"][".afterEditAction"] = 1;
				tdataArray["branch"][".closePopupAfterEdit"] = 1;
				tdataArray["branch"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["branch"][".add"] = true;
				tdataArray["branch"][".afterAddAction"] = 1;
				tdataArray["branch"][".closePopupAfterAdd"] = 1;
				tdataArray["branch"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["branch"][".list"] = true;
			}
			tdataArray["branch"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["branch"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["branch"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["branch"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["branch"][".printFriendly"] = true;
			}
			tdataArray["branch"][".showSimpleSearchOptions"] = true;
			tdataArray["branch"][".allowShowHideFields"] = true;
			tdataArray["branch"][".allowFieldsReordering"] = true;
			tdataArray["branch"][".isUseAjaxSuggest"] = true;


			tdataArray["branch"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["branch"][".buttonsAdded"] = false;
			tdataArray["branch"][".addPageEvents"] = false;
			tdataArray["branch"][".isUseTimeForSearch"] = false;
			tdataArray["branch"][".badgeColor"] = "DAA520";
			tdataArray["branch"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["branch"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["branch"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["branch"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["branch"][".googleLikeFields"].Add("id");
			tdataArray["branch"][".googleLikeFields"].Add("branchName");
			tdataArray["branch"][".tableType"] = "list";
			tdataArray["branch"][".printerPageOrientation"] = 0;
			tdataArray["branch"][".nPrinterPageScale"] = 100;
			tdataArray["branch"][".nPrinterSplitRecords"] = 40;
			tdataArray["branch"][".geocodingEnabled"] = false;
			tdataArray["branch"][".pageSize"] = 20;
			tdataArray["branch"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["branch"][".strOrderBy"] = tstrOrderBy;
			tdataArray["branch"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["branch"][".sqlHead"] = "SELECT id,  	branchName";
			tdataArray["branch"][".sqlFrom"] = "FROM dbo.branch";
			tdataArray["branch"][".sqlWhereExpr"] = "";
			tdataArray["branch"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["branch"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["branch"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["branch"][".highlightSearchResults"] = true;
			tableKeysArray["branch"] = SettingsMap.GetArray();
			tableKeysArray["branch"].Add("id");
			tdataArray["branch"][".Keys"] = tableKeysArray["branch"];
			tdataArray["branch"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.branch";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_branch","id");
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
			tdataArray["branch"]["id"] = fdata;
			tdataArray["branch"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "branchName";
			fdata["GoodName"] = "branchName";
			fdata["ownerTable"] = "dbo.branch";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_branch","branchName");
			fdata["FieldType"] = 200;
			fdata["strField"] = "branchName";
			fdata["sourceSingle"] = "branchName";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "branchName";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=100");
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
			tdataArray["branch"]["branchName"] = fdata;
			tdataArray["branch"][".searchableFields"].Add("branchName");
			GlobalVars.tables_data["dbo.branch"] = tdataArray["branch"];
			GlobalVars.field_labels["dbo_branch"] = fieldLabelsArray["branch"];
			GlobalVars.fieldToolTips["dbo_branch"] = fieldToolTipsArray["branch"];
			GlobalVars.placeHolders["dbo_branch"] = placeHoldersArray["branch"];
			GlobalVars.page_titles["dbo_branch"] = pageTitlesArray["branch"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.branch"));
			GlobalVars.detailsTablesData["dbo.branch"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.branch"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	branchName";
protoArray["0"]["m_strFrom"] = "FROM dbo.branch";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.branch", "m_srcTableName", "dbo.branch"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.branch";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "branchName", "m_strTable", "dbo.branch", "m_srcTableName", "dbo.branch"));

protoArray["8"]["m_sql"] = "branchName";
protoArray["8"]["m_srcTableName"] = "dbo.branch";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["10"] = SettingsMap.GetArray();
protoArray["10"]["m_link"] = "SQLL_MAIN";
protoArray["11"] = SettingsMap.GetArray();
protoArray["11"]["m_strName"] = "dbo.branch";
protoArray["11"]["m_srcTableName"] = "dbo.branch";
protoArray["11"]["m_columns"] = SettingsMap.GetArray();
protoArray["11"]["m_columns"].Add("id");
protoArray["11"]["m_columns"].Add("branchName");
obj = new SQLTable(protoArray["11"]);

protoArray["10"]["m_table"] = obj;
protoArray["10"]["m_sql"] = "dbo.branch";
protoArray["10"]["m_alias"] = "";
protoArray["10"]["m_srcTableName"] = "dbo.branch";
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
protoArray["0"]["m_srcTableName"] = "dbo.branch";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["branch"] = obj;

				
		
			tdataArray["branch"][".sqlquery"] = queryData_Array["branch"];
			tdataArray["branch"][".hasEvents"] = false;
		}
	}

}
