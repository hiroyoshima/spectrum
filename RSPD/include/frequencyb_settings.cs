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
	public static partial class Settings_frequencyb
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["frequencyb"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".ShortName"] = "frequencyb";
			tdataArray["frequencyb"][".OwnerID"] = "";
			tdataArray["frequencyb"][".OriginalTable"] = "dbo.FrequencyB";
			tdataArray["frequencyb"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["frequencyb"][".originalPagesByType"] = tdataArray["frequencyb"][".pagesByType"];
			tdataArray["frequencyb"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["frequencyb"][".originalPages"] = tdataArray["frequencyb"][".pages"];
			tdataArray["frequencyb"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["frequencyb"][".originalDefaultPages"] = tdataArray["frequencyb"][".defaultPages"];
			fieldLabelsArray["frequencyb"] = SettingsMap.GetArray();
			fieldToolTipsArray["frequencyb"] = SettingsMap.GetArray();
			pageTitlesArray["frequencyb"] = SettingsMap.GetArray();
			placeHoldersArray["frequencyb"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["frequencyb"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["frequencyb"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["frequencyb"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["frequencyb"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["frequencyb"]["English"]["ID"] = "ID";
				fieldToolTipsArray["frequencyb"]["English"]["ID"] = "";
				placeHoldersArray["frequencyb"]["English"]["ID"] = "";
				fieldLabelsArray["frequencyb"]["English"]["HdrID"] = "Hdr ID";
				fieldToolTipsArray["frequencyb"]["English"]["HdrID"] = "";
				placeHoldersArray["frequencyb"]["English"]["HdrID"] = "";
				fieldLabelsArray["frequencyb"]["English"]["SerialNoB"] = "Serial No B";
				fieldToolTipsArray["frequencyb"]["English"]["SerialNoB"] = "";
				placeHoldersArray["frequencyb"]["English"]["SerialNoB"] = "";
				fieldLabelsArray["frequencyb"]["English"]["TxB"] = "Tx B";
				fieldToolTipsArray["frequencyb"]["English"]["TxB"] = "";
				placeHoldersArray["frequencyb"]["English"]["TxB"] = "";
				fieldLabelsArray["frequencyb"]["English"]["RxA"] = "Rx A";
				fieldToolTipsArray["frequencyb"]["English"]["RxA"] = "";
				placeHoldersArray["frequencyb"]["English"]["RxA"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["frequencyb"]["English"])))
				{
					tdataArray["frequencyb"][".isUseToolTips"] = true;
				}
			}
			tdataArray["frequencyb"][".NCSearch"] = true;
			tdataArray["frequencyb"][".shortTableName"] = "frequencyb";
			tdataArray["frequencyb"][".nSecOptions"] = 0;
			tdataArray["frequencyb"][".mainTableOwnerID"] = "";
			tdataArray["frequencyb"][".entityType"] = 0;
			tdataArray["frequencyb"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["frequencyb"][".strOriginalTableName"] = "dbo.FrequencyB";
			tdataArray["frequencyb"][".showAddInPopup"] = false;
			tdataArray["frequencyb"][".showEditInPopup"] = false;
			tdataArray["frequencyb"][".showViewInPopup"] = false;
			tdataArray["frequencyb"][".listAjax"] = false;
			tdataArray["frequencyb"][".audit"] = false;
			tdataArray["frequencyb"][".locking"] = false;
			GlobalVars.pages = tdataArray["frequencyb"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["frequencyb"][".edit"] = true;
				tdataArray["frequencyb"][".afterEditAction"] = 1;
				tdataArray["frequencyb"][".closePopupAfterEdit"] = 1;
				tdataArray["frequencyb"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["frequencyb"][".add"] = true;
				tdataArray["frequencyb"][".afterAddAction"] = 1;
				tdataArray["frequencyb"][".closePopupAfterAdd"] = 1;
				tdataArray["frequencyb"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["frequencyb"][".list"] = true;
			}
			tdataArray["frequencyb"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["frequencyb"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["frequencyb"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["frequencyb"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["frequencyb"][".printFriendly"] = true;
			}
			tdataArray["frequencyb"][".showSimpleSearchOptions"] = true;
			tdataArray["frequencyb"][".allowShowHideFields"] = true;
			tdataArray["frequencyb"][".allowFieldsReordering"] = true;
			tdataArray["frequencyb"][".isUseAjaxSuggest"] = true;


			tdataArray["frequencyb"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["frequencyb"][".buttonsAdded"] = false;
			tdataArray["frequencyb"][".addPageEvents"] = false;
			tdataArray["frequencyb"][".isUseTimeForSearch"] = false;
			tdataArray["frequencyb"][".badgeColor"] = "6DA5C8";
			tdataArray["frequencyb"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".googleLikeFields"].Add("ID");
			tdataArray["frequencyb"][".googleLikeFields"].Add("HdrID");
			tdataArray["frequencyb"][".googleLikeFields"].Add("SerialNoB");
			tdataArray["frequencyb"][".googleLikeFields"].Add("TxB");
			tdataArray["frequencyb"][".googleLikeFields"].Add("RxA");
			tdataArray["frequencyb"][".tableType"] = "list";
			tdataArray["frequencyb"][".printerPageOrientation"] = 0;
			tdataArray["frequencyb"][".nPrinterPageScale"] = 100;
			tdataArray["frequencyb"][".nPrinterSplitRecords"] = 40;
			tdataArray["frequencyb"][".geocodingEnabled"] = false;
			tdataArray["frequencyb"][".pageSize"] = 20;
			tdataArray["frequencyb"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["frequencyb"][".strOrderBy"] = tstrOrderBy;
			tdataArray["frequencyb"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["frequencyb"][".sqlHead"] = "SELECT ID,  	HdrID,  	SerialNoB,  	TxB,  	RxA";
			tdataArray["frequencyb"][".sqlFrom"] = "FROM dbo.FrequencyB";
			tdataArray["frequencyb"][".sqlWhereExpr"] = "";
			tdataArray["frequencyb"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["frequencyb"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["frequencyb"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["frequencyb"][".highlightSearchResults"] = true;
			tableKeysArray["frequencyb"] = SettingsMap.GetArray();
			tableKeysArray["frequencyb"].Add("ID");
			tdataArray["frequencyb"][".Keys"] = tableKeysArray["frequencyb"];
			tdataArray["frequencyb"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "ID";
			fdata["GoodName"] = "ID";
			fdata["ownerTable"] = "dbo.FrequencyB";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyB","ID");
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
			tdataArray["frequencyb"]["ID"] = fdata;
			tdataArray["frequencyb"][".searchableFields"].Add("ID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "HdrID";
			fdata["GoodName"] = "HdrID";
			fdata["ownerTable"] = "dbo.FrequencyB";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyB","HdrID");
			fdata["FieldType"] = 3;
			fdata["strField"] = "HdrID";
			fdata["sourceSingle"] = "HdrID";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "HdrID";
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
			tdataArray["frequencyb"]["HdrID"] = fdata;
			tdataArray["frequencyb"][".searchableFields"].Add("HdrID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "SerialNoB";
			fdata["GoodName"] = "SerialNoB";
			fdata["ownerTable"] = "dbo.FrequencyB";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyB","SerialNoB");
			fdata["FieldType"] = 200;
			fdata["strField"] = "SerialNoB";
			fdata["sourceSingle"] = "SerialNoB";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "SerialNoB";
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
			tdataArray["frequencyb"]["SerialNoB"] = fdata;
			tdataArray["frequencyb"][".searchableFields"].Add("SerialNoB");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "TxB";
			fdata["GoodName"] = "TxB";
			fdata["ownerTable"] = "dbo.FrequencyB";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyB","TxB");
			fdata["FieldType"] = 14;
			fdata["strField"] = "TxB";
			fdata["sourceSingle"] = "TxB";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "TxB";
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
			tdataArray["frequencyb"]["TxB"] = fdata;
			tdataArray["frequencyb"][".searchableFields"].Add("TxB");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "RxA";
			fdata["GoodName"] = "RxA";
			fdata["ownerTable"] = "dbo.FrequencyB";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_FrequencyB","RxA");
			fdata["FieldType"] = 14;
			fdata["strField"] = "RxA";
			fdata["sourceSingle"] = "RxA";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "RxA";
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
			tdataArray["frequencyb"]["RxA"] = fdata;
			tdataArray["frequencyb"][".searchableFields"].Add("RxA");
			GlobalVars.tables_data["dbo.FrequencyB"] = tdataArray["frequencyb"];
			GlobalVars.field_labels["dbo_FrequencyB"] = fieldLabelsArray["frequencyb"];
			GlobalVars.fieldToolTips["dbo_FrequencyB"] = fieldToolTipsArray["frequencyb"];
			GlobalVars.placeHolders["dbo_FrequencyB"] = placeHoldersArray["frequencyb"];
			GlobalVars.page_titles["dbo_FrequencyB"] = pageTitlesArray["frequencyb"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.FrequencyB"));
			GlobalVars.detailsTablesData["dbo.FrequencyB"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.FrequencyB"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "ID,  	HdrID,  	SerialNoB,  	TxB,  	RxA";
protoArray["0"]["m_strFrom"] = "FROM dbo.FrequencyB";
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
obj = new SQLField(new XVar("m_strName", "ID", "m_strTable", "dbo.FrequencyB", "m_srcTableName", "dbo.FrequencyB"));

protoArray["6"]["m_sql"] = "ID";
protoArray["6"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "HdrID", "m_strTable", "dbo.FrequencyB", "m_srcTableName", "dbo.FrequencyB"));

protoArray["8"]["m_sql"] = "HdrID";
protoArray["8"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "SerialNoB", "m_strTable", "dbo.FrequencyB", "m_srcTableName", "dbo.FrequencyB"));

protoArray["10"]["m_sql"] = "SerialNoB";
protoArray["10"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "TxB", "m_strTable", "dbo.FrequencyB", "m_srcTableName", "dbo.FrequencyB"));

protoArray["12"]["m_sql"] = "TxB";
protoArray["12"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "RxA", "m_strTable", "dbo.FrequencyB", "m_srcTableName", "dbo.FrequencyB"));

protoArray["14"]["m_sql"] = "RxA";
protoArray["14"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["16"] = SettingsMap.GetArray();
protoArray["16"]["m_link"] = "SQLL_MAIN";
protoArray["17"] = SettingsMap.GetArray();
protoArray["17"]["m_strName"] = "dbo.FrequencyB";
protoArray["17"]["m_srcTableName"] = "dbo.FrequencyB";
protoArray["17"]["m_columns"] = SettingsMap.GetArray();
protoArray["17"]["m_columns"].Add("ID");
protoArray["17"]["m_columns"].Add("HdrID");
protoArray["17"]["m_columns"].Add("SerialNoB");
protoArray["17"]["m_columns"].Add("TxB");
protoArray["17"]["m_columns"].Add("RxA");
obj = new SQLTable(protoArray["17"]);

protoArray["16"]["m_table"] = obj;
protoArray["16"]["m_sql"] = "dbo.FrequencyB";
protoArray["16"]["m_alias"] = "";
protoArray["16"]["m_srcTableName"] = "dbo.FrequencyB";
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
protoArray["0"]["m_srcTableName"] = "dbo.FrequencyB";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["frequencyb"] = obj;

				
		
			tdataArray["frequencyb"][".sqlquery"] = queryData_Array["frequencyb"];
			tdataArray["frequencyb"][".hasEvents"] = false;
		}
	}

}
