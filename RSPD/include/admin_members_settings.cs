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
	public static partial class Settings_admin_members
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["admin_members"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".ShortName"] = "admin_members";
			tdataArray["admin_members"][".OwnerID"] = "";
			tdataArray["admin_members"][".OriginalTable"] = "dbo.spectrum_betaugmembers";
			tdataArray["admin_members"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"search\":[\"search\"]}"));
			tdataArray["admin_members"][".originalPagesByType"] = tdataArray["admin_members"][".pagesByType"];
			tdataArray["admin_members"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"search\":[\"search\"]}")));
			tdataArray["admin_members"][".originalPages"] = tdataArray["admin_members"][".pages"];
			tdataArray["admin_members"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"search\":\"search\"}"));
			tdataArray["admin_members"][".originalDefaultPages"] = tdataArray["admin_members"][".defaultPages"];
			fieldLabelsArray["admin_members"] = SettingsMap.GetArray();
			fieldToolTipsArray["admin_members"] = SettingsMap.GetArray();
			pageTitlesArray["admin_members"] = SettingsMap.GetArray();
			placeHoldersArray["admin_members"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["admin_members"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["admin_members"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["admin_members"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["admin_members"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["admin_members"]["English"]["UserName"] = "User Name";
				fieldToolTipsArray["admin_members"]["English"]["UserName"] = "";
				placeHoldersArray["admin_members"]["English"]["UserName"] = "";
				fieldLabelsArray["admin_members"]["English"]["GroupID"] = "Group ID";
				fieldToolTipsArray["admin_members"]["English"]["GroupID"] = "";
				placeHoldersArray["admin_members"]["English"]["GroupID"] = "";
				fieldLabelsArray["admin_members"]["English"]["Provider"] = "Provider";
				fieldToolTipsArray["admin_members"]["English"]["Provider"] = "";
				placeHoldersArray["admin_members"]["English"]["Provider"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["admin_members"]["English"])))
				{
					tdataArray["admin_members"][".isUseToolTips"] = true;
				}
			}
			tdataArray["admin_members"][".NCSearch"] = true;
			tdataArray["admin_members"][".shortTableName"] = "admin_members";
			tdataArray["admin_members"][".nSecOptions"] = 0;
			tdataArray["admin_members"][".mainTableOwnerID"] = "";
			tdataArray["admin_members"][".entityType"] = 1;
			tdataArray["admin_members"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["admin_members"][".strOriginalTableName"] = "dbo.spectrum_betaugmembers";
			tdataArray["admin_members"][".showAddInPopup"] = false;
			tdataArray["admin_members"][".showEditInPopup"] = false;
			tdataArray["admin_members"][".showViewInPopup"] = false;
			tdataArray["admin_members"][".listAjax"] = false;
			tdataArray["admin_members"][".audit"] = true;
			tdataArray["admin_members"][".locking"] = false;
			GlobalVars.pages = tdataArray["admin_members"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["admin_members"][".edit"] = true;
				tdataArray["admin_members"][".afterEditAction"] = 1;
				tdataArray["admin_members"][".closePopupAfterEdit"] = 1;
				tdataArray["admin_members"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["admin_members"][".add"] = true;
				tdataArray["admin_members"][".afterAddAction"] = 1;
				tdataArray["admin_members"][".closePopupAfterAdd"] = 1;
				tdataArray["admin_members"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["admin_members"][".list"] = true;
			}
			tdataArray["admin_members"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["admin_members"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["admin_members"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["admin_members"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["admin_members"][".printFriendly"] = true;
			}
			tdataArray["admin_members"][".showSimpleSearchOptions"] = true;
			tdataArray["admin_members"][".allowShowHideFields"] = true;
			tdataArray["admin_members"][".allowFieldsReordering"] = true;
			tdataArray["admin_members"][".isUseAjaxSuggest"] = true;


			tdataArray["admin_members"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["admin_members"][".buttonsAdded"] = false;
			tdataArray["admin_members"][".addPageEvents"] = false;
			tdataArray["admin_members"][".isUseTimeForSearch"] = false;
			tdataArray["admin_members"][".badgeColor"] = "4682B4";
			tdataArray["admin_members"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".googleLikeFields"].Add("UserName");
			tdataArray["admin_members"][".googleLikeFields"].Add("GroupID");
			tdataArray["admin_members"][".googleLikeFields"].Add("Provider");
			tdataArray["admin_members"][".tableType"] = "list";
			tdataArray["admin_members"][".printerPageOrientation"] = 0;
			tdataArray["admin_members"][".nPrinterPageScale"] = 100;
			tdataArray["admin_members"][".nPrinterSplitRecords"] = 40;
			tdataArray["admin_members"][".geocodingEnabled"] = false;
			tdataArray["admin_members"][".pageSize"] = 20;
			tdataArray["admin_members"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["admin_members"][".strOrderBy"] = tstrOrderBy;
			tdataArray["admin_members"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["admin_members"][".sqlHead"] = "SELECT UserName,  	GroupID,  	Provider";
			tdataArray["admin_members"][".sqlFrom"] = "FROM dbo.spectrum_betaugmembers";
			tdataArray["admin_members"][".sqlWhereExpr"] = "";
			tdataArray["admin_members"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["admin_members"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["admin_members"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["admin_members"][".highlightSearchResults"] = true;
			tableKeysArray["admin_members"] = SettingsMap.GetArray();
			tableKeysArray["admin_members"].Add("UserName");
			tableKeysArray["admin_members"].Add("GroupID");
			tableKeysArray["admin_members"].Add("Provider");
			tdataArray["admin_members"][".Keys"] = tableKeysArray["admin_members"];
			tdataArray["admin_members"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "UserName";
			fdata["GoodName"] = "UserName";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("admin_members","UserName");
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
			tdataArray["admin_members"]["UserName"] = fdata;
			tdataArray["admin_members"][".searchableFields"].Add("UserName");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "GroupID";
			fdata["GoodName"] = "GroupID";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("admin_members","GroupID");
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
			tdataArray["admin_members"]["GroupID"] = fdata;
			tdataArray["admin_members"][".searchableFields"].Add("GroupID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "Provider";
			fdata["GoodName"] = "Provider";
			fdata["ownerTable"] = "dbo.spectrum_betaugmembers";
			fdata["Label"] = CommonFunctions.GetFieldLabel("admin_members","Provider");
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
			tdataArray["admin_members"]["Provider"] = fdata;
			tdataArray["admin_members"][".searchableFields"].Add("Provider");
			GlobalVars.tables_data["admin_members"] = tdataArray["admin_members"];
			GlobalVars.field_labels["admin_members"] = fieldLabelsArray["admin_members"];
			GlobalVars.fieldToolTips["admin_members"] = fieldToolTipsArray["admin_members"];
			GlobalVars.placeHolders["admin_members"] = placeHoldersArray["admin_members"];
			GlobalVars.page_titles["admin_members"] = pageTitlesArray["admin_members"];
			CommonFunctions.changeTextControlsToDate(new XVar("admin_members"));
			GlobalVars.detailsTablesData["admin_members"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["admin_members"] = SettingsMap.GetArray();

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
obj = new SQLField(new XVar("m_strName", "UserName", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "admin_members"));

protoArray["6"]["m_sql"] = "UserName";
protoArray["6"]["m_srcTableName"] = "admin_members";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "GroupID", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "admin_members"));

protoArray["8"]["m_sql"] = "GroupID";
protoArray["8"]["m_srcTableName"] = "admin_members";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Provider", "m_strTable", "dbo.spectrum_betaugmembers", "m_srcTableName", "admin_members"));

protoArray["10"]["m_sql"] = "Provider";
protoArray["10"]["m_srcTableName"] = "admin_members";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["12"] = SettingsMap.GetArray();
protoArray["12"]["m_link"] = "SQLL_MAIN";
protoArray["13"] = SettingsMap.GetArray();
protoArray["13"]["m_strName"] = "dbo.spectrum_betaugmembers";
protoArray["13"]["m_srcTableName"] = "admin_members";
protoArray["13"]["m_columns"] = SettingsMap.GetArray();
protoArray["13"]["m_columns"].Add("UserName");
protoArray["13"]["m_columns"].Add("GroupID");
protoArray["13"]["m_columns"].Add("Provider");
obj = new SQLTable(protoArray["13"]);

protoArray["12"]["m_table"] = obj;
protoArray["12"]["m_sql"] = "dbo.spectrum_betaugmembers";
protoArray["12"]["m_alias"] = "";
protoArray["12"]["m_srcTableName"] = "admin_members";
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
protoArray["0"]["m_srcTableName"] = "admin_members";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["admin_members"] = obj;

				
		
			tdataArray["admin_members"][".sqlquery"] = queryData_Array["admin_members"];
			tdataArray["admin_members"][".hasEvents"] = false;
		}
	}

}
