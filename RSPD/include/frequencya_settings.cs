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
	public static partial class Settings_frequencya
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["frequencya"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".ShortName"] = "frequencya";
			tdataArray["frequencya"][".OwnerID"] = "";
			tdataArray["frequencya"][".OriginalTable"] = "dbo.FrequencyA";
			tdataArray["frequencya"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["frequencya"][".originalPagesByType"] = tdataArray["frequencya"][".pagesByType"];
			tdataArray["frequencya"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["frequencya"][".originalPages"] = tdataArray["frequencya"][".pages"];
			tdataArray["frequencya"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["frequencya"][".originalDefaultPages"] = tdataArray["frequencya"][".defaultPages"];
			fieldLabelsArray["frequencya"] = SettingsMap.GetArray();
			fieldToolTipsArray["frequencya"] = SettingsMap.GetArray();
			pageTitlesArray["frequencya"] = SettingsMap.GetArray();
			placeHoldersArray["frequencya"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["frequencya"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["frequencya"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["frequencya"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["frequencya"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["frequencya"]["English"]["ID"] = "ID";
				fieldToolTipsArray["frequencya"]["English"]["ID"] = "";
				placeHoldersArray["frequencya"]["English"]["ID"] = "";
				fieldLabelsArray["frequencya"]["English"]["RspdID"] = "Rspd ID";
				fieldToolTipsArray["frequencya"]["English"]["RspdID"] = "";
				placeHoldersArray["frequencya"]["English"]["RspdID"] = "";
				fieldLabelsArray["frequencya"]["English"]["SerialNoA"] = "Serial No A";
				fieldToolTipsArray["frequencya"]["English"]["SerialNoA"] = "";
				placeHoldersArray["frequencya"]["English"]["SerialNoA"] = "";
				fieldLabelsArray["frequencya"]["English"]["TxA"] = "Tx A";
				fieldToolTipsArray["frequencya"]["English"]["TxA"] = "";
				placeHoldersArray["frequencya"]["English"]["TxA"] = "";
				fieldLabelsArray["frequencya"]["English"]["RxB"] = "Rx B";
				fieldToolTipsArray["frequencya"]["English"]["RxB"] = "";
				placeHoldersArray["frequencya"]["English"]["RxB"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["frequencya"]["English"])))
				{
					tdataArray["frequencya"][".isUseToolTips"] = true;
				}
			}
			tdataArray["frequencya"][".NCSearch"] = true;
			tdataArray["frequencya"][".shortTableName"] = "frequencya";
			tdataArray["frequencya"][".nSecOptions"] = 0;
			tdataArray["frequencya"][".mainTableOwnerID"] = "";
			tdataArray["frequencya"][".entityType"] = 0;
			tdataArray["frequencya"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["frequencya"][".strOriginalTableName"] = "dbo.FrequencyA";
			tdataArray["frequencya"][".showAddInPopup"] = false;
			tdataArray["frequencya"][".showEditInPopup"] = false;
			tdataArray["frequencya"][".showViewInPopup"] = false;
			tdataArray["frequencya"][".listAjax"] = false;
			tdataArray["frequencya"][".audit"] = false;
			tdataArray["frequencya"][".locking"] = false;
			GlobalVars.pages = tdataArray["frequencya"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["frequencya"][".edit"] = true;
				tdataArray["frequencya"][".afterEditAction"] = 1;
				tdataArray["frequencya"][".closePopupAfterEdit"] = 1;
				tdataArray["frequencya"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["frequencya"][".add"] = true;
				tdataArray["frequencya"][".afterAddAction"] = 1;
				tdataArray["frequencya"][".closePopupAfterAdd"] = 1;
				tdataArray["frequencya"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["frequencya"][".list"] = true;
			}
			tdataArray["frequencya"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["frequencya"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["frequencya"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["frequencya"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["frequencya"][".printFriendly"] = true;
			}
			tdataArray["frequencya"][".showSimpleSearchOptions"] = true;
			tdataArray["frequencya"][".allowShowHideFields"] = true;
			tdataArray["frequencya"][".allowFieldsReordering"] = true;
			tdataArray["frequencya"][".isUseAjaxSuggest"] = true;


			tdataArray["frequencya"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["frequencya"][".buttonsAdded"] = false;
			tdataArray["frequencya"][".addPageEvents"] = false;
			tdataArray["frequencya"][".isUseTimeForSearch"] = false;
			tdataArray["frequencya"][".badgeColor"] = "4169E1";
			tdataArray["frequencya"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".googleLikeFields"].Add("ID");
			tdataArray["frequencya"][".googleLikeFields"].Add("RspdID");
			tdataArray["frequencya"][".googleLikeFields"].Add("SerialNoA");
			tdataArray["frequencya"][".googleLikeFields"].Add("TxA");
			tdataArray["frequencya"][".googleLikeFields"].Add("RxB");
			tdataArray["frequencya"][".tableType"] = "list";
			tdataArray["frequencya"][".printerPageOrientation"] = 0;
			tdataArray["frequencya"][".nPrinterPageScale"] = 100;
			tdataArray["frequencya"][".nPrinterSplitRecords"] = 40;
			tdataArray["frequencya"][".geocodingEnabled"] = false;
			tdataArray["frequencya"][".pageSize"] = 20;
			tdataArray["frequencya"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["frequencya"][".strOrderBy"] = tstrOrderBy;
			tdataArray["frequencya"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["frequencya"][".sqlHead"] = "SELECT ID,  	RspdID,  	SerialNoA,  	TxA,  	RxB";
			tdataArray["frequencya"][".sqlFrom"] = "FROM dbo.FrequencyA";
			tdataArray["frequencya"][".sqlWhereExpr"] = "";
			tdataArray["frequencya"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["frequencya"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["frequencya"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["frequencya"][".highlightSearchResults"] = true;
			tableKeysArray["frequencya"] = SettingsMap.GetArray();
			tableKeysArray["frequencya"].Add("ID");
			tdataArray["frequencya"][".Keys"] = tableKeysArray["frequencya"];
			tdataArray["frequencya"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "ID";
			fdata["GoodName"] = "ID";
			fdata["ownerTable"] = "dbo.FrequencyA";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyA","ID");
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
			tdataArray["frequencya"]["ID"] = fdata;
			tdataArray["frequencya"][".searchableFields"].Add("ID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "RspdID";
			fdata["GoodName"] = "RspdID";
			fdata["ownerTable"] = "dbo.FrequencyA";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyA","RspdID");
			fdata["FieldType"] = 3;
			fdata["strField"] = "RspdID";
			fdata["sourceSingle"] = "RspdID";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "RspdID";
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
			tdataArray["frequencya"]["RspdID"] = fdata;
			tdataArray["frequencya"][".searchableFields"].Add("RspdID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "SerialNoA";
			fdata["GoodName"] = "SerialNoA";
			fdata["ownerTable"] = "dbo.FrequencyA";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyA","SerialNoA");
			fdata["FieldType"] = 200;
			fdata["strField"] = "SerialNoA";
			fdata["sourceSingle"] = "SerialNoA";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "SerialNoA";
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
			tdataArray["frequencya"]["SerialNoA"] = fdata;
			tdataArray["frequencya"][".searchableFields"].Add("SerialNoA");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "TxA";
			fdata["GoodName"] = "TxA";
			fdata["ownerTable"] = "dbo.FrequencyA";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyA","TxA");
			fdata["FieldType"] = 14;
			fdata["strField"] = "TxA";
			fdata["sourceSingle"] = "TxA";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "TxA";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "Number");
			vdata["DecimalDigits"] = 2;
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
			tdataArray["frequencya"]["TxA"] = fdata;
			tdataArray["frequencya"][".searchableFields"].Add("TxA");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "RxB";
			fdata["GoodName"] = "RxB";
			fdata["ownerTable"] = "dbo.FrequencyA";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyA","RxB");
			fdata["FieldType"] = 14;
			fdata["strField"] = "RxB";
			fdata["sourceSingle"] = "RxB";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "RxB";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "Number");
			vdata["DecimalDigits"] = 2;
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
			tdataArray["frequencya"]["RxB"] = fdata;
			tdataArray["frequencya"][".searchableFields"].Add("RxB");
			GlobalVars.tables_data["dbo.FrequencyA"] = tdataArray["frequencya"];
			GlobalVars.field_labels["dbo_FrequencyA"] = fieldLabelsArray["frequencya"];
			GlobalVars.fieldToolTips["dbo_FrequencyA"] = fieldToolTipsArray["frequencya"];
			GlobalVars.placeHolders["dbo_FrequencyA"] = placeHoldersArray["frequencya"];
			GlobalVars.page_titles["dbo_FrequencyA"] = pageTitlesArray["frequencya"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.FrequencyA"));
			GlobalVars.detailsTablesData["dbo.FrequencyA"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.FrequencyA"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "ID,  	RspdID,  	SerialNoA,  	TxA,  	RxB";
protoArray["0"]["m_strFrom"] = "FROM dbo.FrequencyA";
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
obj = new SQLField(new XVar("m_strName", "ID", "m_strTable", "dbo.FrequencyA", "m_srcTableName", "dbo.FrequencyA"));

protoArray["6"]["m_sql"] = "ID";
protoArray["6"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "RspdID", "m_strTable", "dbo.FrequencyA", "m_srcTableName", "dbo.FrequencyA"));

protoArray["8"]["m_sql"] = "RspdID";
protoArray["8"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "SerialNoA", "m_strTable", "dbo.FrequencyA", "m_srcTableName", "dbo.FrequencyA"));

protoArray["10"]["m_sql"] = "SerialNoA";
protoArray["10"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "TxA", "m_strTable", "dbo.FrequencyA", "m_srcTableName", "dbo.FrequencyA"));

protoArray["12"]["m_sql"] = "TxA";
protoArray["12"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "RxB", "m_strTable", "dbo.FrequencyA", "m_srcTableName", "dbo.FrequencyA"));

protoArray["14"]["m_sql"] = "RxB";
protoArray["14"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["16"] = SettingsMap.GetArray();
protoArray["16"]["m_link"] = "SQLL_MAIN";
protoArray["17"] = SettingsMap.GetArray();
protoArray["17"]["m_strName"] = "dbo.FrequencyA";
protoArray["17"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["17"]["m_columns"] = SettingsMap.GetArray();
protoArray["17"]["m_columns"].Add("ID");
protoArray["17"]["m_columns"].Add("RspdID");
protoArray["17"]["m_columns"].Add("SerialNoA");
protoArray["17"]["m_columns"].Add("TxA");
protoArray["17"]["m_columns"].Add("RxB");
obj = new SQLTable(protoArray["17"]);

protoArray["16"]["m_table"] = obj;
protoArray["16"]["m_sql"] = "dbo.FrequencyA";
protoArray["16"]["m_alias"] = "";
protoArray["16"]["m_srcTableName"] = "dbo.FrequencyA";
protoArray["18"] = SettingsMap.GetArray();
protoArray["18"]["m_sql"] = "";
protoArray["18"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["18"]["m_column"] = obj;
protoArray["18"]["m_contained"] = SettingsMap.GetArray();
protoArray["18"]["m_strCase"] = "";
protoArray["18"]["m_havingmode"] = false;
protoArray["18"]["m_inBrackets"] = false;
protoArray["18"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["18"]);

protoArray["16"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["16"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.FrequencyA";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["frequencya"] = obj;

				
		
			tdataArray["frequencya"][".sqlquery"] = queryData_Array["frequencya"];
			tdataArray["frequencya"][".hasEvents"] = false;
		}
	}

}
