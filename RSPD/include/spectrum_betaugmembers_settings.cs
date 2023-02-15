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
	public static partial class Settings_spectrum_betaugmembers
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".ShortName"] = "spectrum_betaugmembers";
			tdataArray["spectrum_betaugmembers"][".OwnerID"] = "";
			tdataArray["spectrum_betaugmembers"][".OriginalTable"] = "dbo.spectrum_betaugmembers";
			tdataArray["spectrum_betaugmembers"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["spectrum_betaugmembers"][".originalPagesByType"] = tdataArray["spectrum_betaugmembers"][".pagesByType"];
			tdataArray["spectrum_betaugmembers"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["spectrum_betaugmembers"][".originalPages"] = tdataArray["spectrum_betaugmembers"][".pages"];
			tdataArray["spectrum_betaugmembers"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["spectrum_betaugmembers"][".originalDefaultPages"] = tdataArray["spectrum_betaugmembers"][".defaultPages"];
			fieldLabelsArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			fieldToolTipsArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			pageTitlesArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			placeHoldersArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["spectrum_betaugmembers"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["spectrum_betaugmembers"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["spectrum_betaugmembers"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["spectrum_betaugmembers"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["spectrum_betaugmembers"]["English"]["UserName"] = "User Name";
				fieldToolTipsArray["spectrum_betaugmembers"]["English"]["UserName"] = "";
				placeHoldersArray["spectrum_betaugmembers"]["English"]["UserName"] = "";
				fieldLabelsArray["spectrum_betaugmembers"]["English"]["GroupID"] = "Group ID";
				fieldToolTipsArray["spectrum_betaugmembers"]["English"]["GroupID"] = "";
				placeHoldersArray["spectrum_betaugmembers"]["English"]["GroupID"] = "";
				fieldLabelsArray["spectrum_betaugmembers"]["English"]["Provider"] = "Provider";
				fieldToolTipsArray["spectrum_betaugmembers"]["English"]["Provider"] = "";
				placeHoldersArray["spectrum_betaugmembers"]["English"]["Provider"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["spectrum_betaugmembers"]["English"])))
				{
					tdataArray["spectrum_betaugmembers"][".isUseToolTips"] = true;
				}
			}
			tdataArray["spectrum_betaugmembers"][".NCSearch"] = true;
			tdataArray["spectrum_betaugmembers"][".shortTableName"] = "spectrum_betaugmembers";
			tdataArray["spectrum_betaugmembers"][".nSecOptions"] = 0;
			tdataArray["spectrum_betaugmembers"][".mainTableOwnerID"] = "";
			tdataArray["spectrum_betaugmembers"][".entityType"] = 0;
			tdataArray["spectrum_betaugmembers"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["spectrum_betaugmembers"][".strOriginalTableName"] = "dbo.spectrum_betaugmembers";
			tdataArray["spectrum_betaugmembers"][".showAddInPopup"] = false;
			tdataArray["spectrum_betaugmembers"][".showEditInPopup"] = false;
			tdataArray["spectrum_betaugmembers"][".showViewInPopup"] = false;
			tdataArray["spectrum_betaugmembers"][".listAjax"] = false;
			tdataArray["spectrum_betaugmembers"][".audit"] = false;
			tdataArray["spectrum_betaugmembers"][".locking"] = false;
			GlobalVars.pages = tdataArray["spectrum_betaugmembers"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["spectrum_betaugmembers"][".edit"] = true;
				tdataArray["spectrum_betaugmembers"][".afterEditAction"] = 1;
				tdataArray["spectrum_betaugmembers"][".closePopupAfterEdit"] = 1;
				tdataArray["spectrum_betaugmembers"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["spectrum_betaugmembers"][".add"] = true;
				tdataArray["spectrum_betaugmembers"][".afterAddAction"] = 1;
				tdataArray["spectrum_betaugmembers"][".closePopupAfterAdd"] = 1;
				tdataArray["spectrum_betaugmembers"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["spectrum_betaugmembers"][".list"] = true;
			}
			tdataArray["spectrum_betaugmembers"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["spectrum_betaugmembers"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["spectrum_betaugmembers"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["spectrum_betaugmembers"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["spectrum_betaugmembers"][".printFriendly"] = true;
			}
			tdataArray["spectrum_betaugmembers"][".showSimpleSearchOptions"] = true;
			tdataArray["spectrum_betaugmembers"][".allowShowHideFields"] = true;
			tdataArray["spectrum_betaugmembers"][".allowFieldsReordering"] = true;
			tdataArray["spectrum_betaugmembers"][".isUseAjaxSuggest"] = true;


			tdataArray["spectrum_betaugmembers"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["spectrum_betaugmembers"][".buttonsAdded"] = false;
			tdataArray["spectrum_betaugmembers"][".addPageEvents"] = false;
			tdataArray["spectrum_betaugmembers"][".isUseTimeForSearch"] = false;
			tdataArray["spectrum_betaugmembers"][".badgeColor"] = "4169E1";
			tdataArray["spectrum_betaugmembers"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".googleLikeFields"].Add("UserName");
			tdataArray["spectrum_betaugmembers"][".googleLikeFields"].Add("GroupID");
			tdataArray["spectrum_betaugmembers"][".googleLikeFields"].Add("Provider");
			tdataArray["spectrum_betaugmembers"][".tableType"] = "list";
			tdataArray["spectrum_betaugmembers"][".printerPageOrientation"] = 0;
			tdataArray["spectrum_betaugmembers"][".nPrinterPageScale"] = 100;
			tdataArray["spectrum_betaugmembers"][".nPrinterSplitRecords"] = 40;
			tdataArray["spectrum_betaugmembers"][".geocodingEnabled"] = false;
			tdataArray["spectrum_betaugmembers"][".pageSize"] = 20;
			tdataArray["spectrum_betaugmembers"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["spectrum_betaugmembers"][".strOrderBy"] = tstrOrderBy;
			tdataArray["spectrum_betaugmembers"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["spectrum_betaugmembers"][".sqlHead"] = "SELECT UserName,  	GroupID,  	Provider";
			tdataArray["spectrum_betaugmembers"][".sqlFrom"] = "FROM dbo.spectrum_betaugmembers";
			tdataArray["spectrum_betaugmembers"][".sqlWhereExpr"] = "";
			tdataArray["spectrum_betaugmembers"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["spectrum_betaugmembers"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["spectrum_betaugmembers"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["spectrum_betaugmembers"][".highlightSearchResults"] = true;
			tableKeysArray["spectrum_betaugmembers"] = SettingsMap.GetArray();
			tableKeysArray["spectrum_betaugmembers"].Add("UserName");
			tableKeysArray["spectrum_betaugmembers"].Add("GroupID");
			tableKeysArray["spectrum_betaugmembers"].Add("Provider");
			tdataArray["spectrum_betaugmembers"][".Keys"] = tableKeysArray["spectrum_betaugmembers"];
			tdataArray["spectrum_betaugmembers"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "UserName";
			fdata["GoodName"] = "UserName";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugmembers","UserName");
			fdata["FieldType"] = 200;
			fdata["strField"] = "UserName";
			fdata["sourceSingle"] = "UserName";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "UserName";
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
			tdataArray["spectrum_betaugmembers"]["UserName"] = fdata;
			tdataArray["spectrum_betaugmembers"][".searchableFields"].Add("UserName");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "GroupID";
			fdata["GoodName"] = "GroupID";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugmembers","GroupID");
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
			tdataArray["spectrum_betaugmembers"]["GroupID"] = fdata;
			tdataArray["spectrum_betaugmembers"][".searchableFields"].Add("GroupID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "Provider";
			fdata["GoodName"] = "Provider";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betaugmembers","Provider");
			fdata["FieldType"] = 200;
			fdata["strField"] = "Provider";
			fdata["sourceSingle"] = "Provider";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "Provider";
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
			tdataArray["spectrum_betaugmembers"]["Provider"] = fdata;
			tdataArray["spectrum_betaugmembers"][".searchableFields"].Add("Provider");
			GlobalVars.tables_data["dbo.spectrum_betaugmembers"] = tdataArray["spectrum_betaugmembers"];
			GlobalVars.field_labels["dbo_spectrum_betaugmembers"] = fieldLabelsArray["spectrum_betaugmembers"];
			GlobalVars.fieldToolTips["dbo_spectrum_betaugmembers"] = fieldToolTipsArray["spectrum_betaugmembers"];
			GlobalVars.placeHolders["dbo_spectrum_betaugmembers"] = placeHoldersArray["spectrum_betaugmembers"];
			GlobalVars.page_titles["dbo_spectrum_betaugmembers"] = pageTitlesArray["spectrum_betaugmembers"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.spectrum_betaugmembers"));
			GlobalVars.detailsTablesData["dbo.spectrum_betaugmembers"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.spectrum_betaugmembers"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "UserName,  	GroupID,  	Provider";
protoArray["0"]["m_strFrom"] = "FROM dbo.spectrum_betaugmembers";
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
obj = new SQLField(new XVar("m_strName", "UserName", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "dbo.spectrum_betaugmembers"));

protoArray["6"]["m_sql"] = "UserName";
protoArray["6"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "GroupID", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "dbo.spectrum_betaugmembers"));

protoArray["8"]["m_sql"] = "GroupID";
protoArray["8"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Provider", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "dbo.spectrum_betaugmembers"));

protoArray["10"]["m_sql"] = "Provider";
protoArray["10"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.spectrum_betaugmembers";
protoArray["13"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("UserName");
protoArray["13"]["m_columns"].Add("GroupID");
protoArray["13"]["m_columns"].Add("Provider");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.spectrum_betaugmembers";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
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
protoArray["0"]["m_srcTableName"] = "dbo.spectrum_betaugmembers";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["spectrum_betaugmembers"] = obj;

				
		
			tdataArray["spectrum_betaugmembers"][".sqlquery"] = queryData_Array["spectrum_betaugmembers"];
			tdataArray["spectrum_betaugmembers"][".hasEvents"] = false;
		}
	}

}
