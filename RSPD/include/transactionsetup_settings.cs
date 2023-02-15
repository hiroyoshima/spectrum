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
	public static partial class Settings_transactionsetup
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["transactionsetup"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".ShortName"] = "transactionsetup";
			tdataArray["transactionsetup"][".OwnerID"] = "";
			tdataArray["transactionsetup"][".OriginalTable"] = "dbo.transactionSetup";
			tdataArray["transactionsetup"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["transactionsetup"][".originalPagesByType"] = tdataArray["transactionsetup"][".pagesByType"];
			tdataArray["transactionsetup"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["transactionsetup"][".originalPages"] = tdataArray["transactionsetup"][".pages"];
			tdataArray["transactionsetup"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["transactionsetup"][".originalDefaultPages"] = tdataArray["transactionsetup"][".defaultPages"];
			fieldLabelsArray["transactionsetup"] = SettingsMap.GetArray();
			fieldToolTipsArray["transactionsetup"] = SettingsMap.GetArray();
			pageTitlesArray["transactionsetup"] = SettingsMap.GetArray();
			placeHoldersArray["transactionsetup"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["transactionsetup"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["transactionsetup"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["transactionsetup"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["transactionsetup"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["transactionsetup"]["English"]["id"] = "Id";
				fieldToolTipsArray["transactionsetup"]["English"]["id"] = "";
				placeHoldersArray["transactionsetup"]["English"]["id"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["defaulttransaction"] = "Defaulttransaction";
				fieldToolTipsArray["transactionsetup"]["English"]["defaulttransaction"] = "";
				placeHoldersArray["transactionsetup"]["English"]["defaulttransaction"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["defaultStatus"] = "Default Status";
				fieldToolTipsArray["transactionsetup"]["English"]["defaultStatus"] = "";
				placeHoldersArray["transactionsetup"]["English"]["defaultStatus"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["autonumber"] = "Autonumber";
				fieldToolTipsArray["transactionsetup"]["English"]["autonumber"] = "";
				placeHoldersArray["transactionsetup"]["English"]["autonumber"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["prefix"] = "Prefix";
				fieldToolTipsArray["transactionsetup"]["English"]["prefix"] = "";
				placeHoldersArray["transactionsetup"]["English"]["prefix"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["leadingZeros"] = "Leading Zeros";
				fieldToolTipsArray["transactionsetup"]["English"]["leadingZeros"] = "";
				placeHoldersArray["transactionsetup"]["English"]["leadingZeros"] = "";
				fieldLabelsArray["transactionsetup"]["English"]["seriesStart"] = "Series Start";
				fieldToolTipsArray["transactionsetup"]["English"]["seriesStart"] = "";
				placeHoldersArray["transactionsetup"]["English"]["seriesStart"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["transactionsetup"]["English"])))
				{
					tdataArray["transactionsetup"][".isUseToolTips"] = true;
				}
			}
			tdataArray["transactionsetup"][".NCSearch"] = true;
			tdataArray["transactionsetup"][".shortTableName"] = "transactionsetup";
			tdataArray["transactionsetup"][".nSecOptions"] = 0;
			tdataArray["transactionsetup"][".mainTableOwnerID"] = "";
			tdataArray["transactionsetup"][".entityType"] = 0;
			tdataArray["transactionsetup"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["transactionsetup"][".strOriginalTableName"] = "dbo.transactionSetup";
			tdataArray["transactionsetup"][".showAddInPopup"] = false;
			tdataArray["transactionsetup"][".showEditInPopup"] = false;
			tdataArray["transactionsetup"][".showViewInPopup"] = false;
			tdataArray["transactionsetup"][".listAjax"] = false;
			tdataArray["transactionsetup"][".audit"] = false;
			tdataArray["transactionsetup"][".locking"] = false;
			GlobalVars.pages = tdataArray["transactionsetup"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["transactionsetup"][".edit"] = true;
				tdataArray["transactionsetup"][".afterEditAction"] = 1;
				tdataArray["transactionsetup"][".closePopupAfterEdit"] = 1;
				tdataArray["transactionsetup"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["transactionsetup"][".add"] = true;
				tdataArray["transactionsetup"][".afterAddAction"] = 1;
				tdataArray["transactionsetup"][".closePopupAfterAdd"] = 1;
				tdataArray["transactionsetup"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["transactionsetup"][".list"] = true;
			}
			tdataArray["transactionsetup"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["transactionsetup"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["transactionsetup"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["transactionsetup"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["transactionsetup"][".printFriendly"] = true;
			}
			tdataArray["transactionsetup"][".showSimpleSearchOptions"] = true;
			tdataArray["transactionsetup"][".allowShowHideFields"] = true;
			tdataArray["transactionsetup"][".allowFieldsReordering"] = true;
			tdataArray["transactionsetup"][".isUseAjaxSuggest"] = true;


			tdataArray["transactionsetup"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["transactionsetup"][".buttonsAdded"] = false;
			tdataArray["transactionsetup"][".addPageEvents"] = false;
			tdataArray["transactionsetup"][".isUseTimeForSearch"] = false;
			tdataArray["transactionsetup"][".badgeColor"] = "DB7093";
			tdataArray["transactionsetup"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".googleLikeFields"].Add("id");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("defaulttransaction");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("defaultStatus");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("autonumber");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("prefix");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("leadingZeros");
			tdataArray["transactionsetup"][".googleLikeFields"].Add("seriesStart");
			tdataArray["transactionsetup"][".tableType"] = "list";
			tdataArray["transactionsetup"][".printerPageOrientation"] = 0;
			tdataArray["transactionsetup"][".nPrinterPageScale"] = 100;
			tdataArray["transactionsetup"][".nPrinterSplitRecords"] = 40;
			tdataArray["transactionsetup"][".geocodingEnabled"] = false;
			tdataArray["transactionsetup"][".pageSize"] = 20;
			tdataArray["transactionsetup"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["transactionsetup"][".strOrderBy"] = tstrOrderBy;
			tdataArray["transactionsetup"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["transactionsetup"][".sqlHead"] = "SELECT id,  	defaulttransaction,  	defaultStatus,  	autonumber,  	[prefix],  	leadingZeros,  	seriesStart";
			tdataArray["transactionsetup"][".sqlFrom"] = "FROM dbo.transactionSetup";
			tdataArray["transactionsetup"][".sqlWhereExpr"] = "";
			tdataArray["transactionsetup"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["transactionsetup"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["transactionsetup"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["transactionsetup"][".highlightSearchResults"] = true;
			tableKeysArray["transactionsetup"] = SettingsMap.GetArray();
			tableKeysArray["transactionsetup"].Add("id");
			tdataArray["transactionsetup"][".Keys"] = tableKeysArray["transactionsetup"];
			tdataArray["transactionsetup"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","id");
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
			tdataArray["transactionsetup"]["id"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "defaulttransaction";
			fdata["GoodName"] = "defaulttransaction";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","defaulttransaction");
			fdata["FieldType"] = 200;
			fdata["strField"] = "defaulttransaction";
			fdata["sourceSingle"] = "defaulttransaction";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "defaulttransaction";
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
			tdataArray["transactionsetup"]["defaulttransaction"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("defaulttransaction");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "defaultStatus";
			fdata["GoodName"] = "defaultStatus";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","defaultStatus");
			fdata["FieldType"] = 200;
			fdata["strField"] = "defaultStatus";
			fdata["sourceSingle"] = "defaultStatus";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "defaultStatus";
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
			tdataArray["transactionsetup"]["defaultStatus"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("defaultStatus");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "autonumber";
			fdata["GoodName"] = "autonumber";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","autonumber");
			fdata["FieldType"] = 200;
			fdata["strField"] = "autonumber";
			fdata["sourceSingle"] = "autonumber";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "autonumber";
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
			tdataArray["transactionsetup"]["autonumber"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("autonumber");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "prefix";
			fdata["GoodName"] = "prefix";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","prefix");
			fdata["FieldType"] = 200;
			fdata["strField"] = "prefix";
			fdata["sourceSingle"] = "prefix";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[prefix]";
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
			tdataArray["transactionsetup"]["prefix"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("prefix");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 6;
			fdata["strName"] = "leadingZeros";
			fdata["GoodName"] = "leadingZeros";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","leadingZeros");
			fdata["FieldType"] = 200;
			fdata["strField"] = "leadingZeros";
			fdata["sourceSingle"] = "leadingZeros";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "leadingZeros";
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
			tdataArray["transactionsetup"]["leadingZeros"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("leadingZeros");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 7;
			fdata["strName"] = "seriesStart";
			fdata["GoodName"] = "seriesStart";
			fdata["ownerTable"] = "dbo.transactionSetup";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_transactionSetup","seriesStart");
			fdata["FieldType"] = 200;
			fdata["strField"] = "seriesStart";
			fdata["sourceSingle"] = "seriesStart";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "seriesStart";
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
			tdataArray["transactionsetup"]["seriesStart"] = fdata;
			tdataArray["transactionsetup"][".searchableFields"].Add("seriesStart");
			GlobalVars.tables_data["dbo.transactionSetup"] = tdataArray["transactionsetup"];
			GlobalVars.field_labels["dbo_transactionSetup"] = fieldLabelsArray["transactionsetup"];
			GlobalVars.fieldToolTips["dbo_transactionSetup"] = fieldToolTipsArray["transactionsetup"];
			GlobalVars.placeHolders["dbo_transactionSetup"] = placeHoldersArray["transactionsetup"];
			GlobalVars.page_titles["dbo_transactionSetup"] = pageTitlesArray["transactionsetup"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.transactionSetup"));
			GlobalVars.detailsTablesData["dbo.transactionSetup"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.transactionSetup"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	defaulttransaction,  	defaultStatus,  	autonumber,  	[prefix],  	leadingZeros,  	seriesStart";
protoArray["0"]["m_strFrom"] = "FROM dbo.transactionSetup";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "defaulttransaction", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["8"]["m_sql"] = "defaulttransaction";
protoArray["8"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "defaultStatus", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["10"]["m_sql"] = "defaultStatus";
protoArray["10"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "autonumber", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["12"]["m_sql"] = "autonumber";
protoArray["12"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "prefix", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["14"]["m_sql"] = "[prefix]";
protoArray["14"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["16"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "leadingZeros", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["16"]["m_sql"] = "leadingZeros";
protoArray["16"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["16"]["m_expr"] = obj;
protoArray["16"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["16"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["18"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "seriesStart", "m_strTable", "dbo.transactionSetup", "m_srcTableName", "dbo.transactionSetup"));

protoArray["18"]["m_sql"] = "seriesStart";
protoArray["18"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["18"]["m_expr"] = obj;
protoArray["18"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["18"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["20"] = SettingsMap.GetArray();
protoArray["20"]["m_link"] = "SQLL_MAIN";
protoArray["21"] = SettingsMap.GetArray();
protoArray["21"]["m_strName"] = "dbo.transactionSetup";
protoArray["21"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["21"]["m_columns"] = SettingsMap.GetArray();
protoArray["21"]["m_columns"].Add("id");
protoArray["21"]["m_columns"].Add("defaulttransaction");
protoArray["21"]["m_columns"].Add("defaultStatus");
protoArray["21"]["m_columns"].Add("autonumber");
protoArray["21"]["m_columns"].Add("prefix");
protoArray["21"]["m_columns"].Add("leadingZeros");
protoArray["21"]["m_columns"].Add("seriesStart");
obj = new SQLTable(protoArray["21"]);

protoArray["20"]["m_table"] = obj;
protoArray["20"]["m_sql"] = "dbo.transactionSetup";
protoArray["20"]["m_alias"] = "";
protoArray["20"]["m_srcTableName"] = "dbo.transactionSetup";
protoArray["22"] = SettingsMap.GetArray();
protoArray["22"]["m_sql"] = "";
protoArray["22"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["22"]["m_column"] = obj;
protoArray["22"]["m_contained"] = SettingsMap.GetArray();
protoArray["22"]["m_strCase"] = "";
protoArray["22"]["m_havingmode"] = false;
protoArray["22"]["m_inBrackets"] = false;
protoArray["22"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["22"]);

protoArray["20"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["20"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.transactionSetup";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["transactionsetup"] = obj;

				
		
			tdataArray["transactionsetup"][".sqlquery"] = queryData_Array["transactionsetup"];
			tdataArray["transactionsetup"][".hasEvents"] = false;
		}
	}

}
