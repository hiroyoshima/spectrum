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
	public static partial class Settings_spectrum_beta_settings
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".ShortName"] = "spectrum_beta_settings";
			tdataArray["spectrum_beta_settings"][".OwnerID"] = "";
			tdataArray["spectrum_beta_settings"][".OriginalTable"] = "dbo.spectrum_beta_settings";
			tdataArray["spectrum_beta_settings"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["spectrum_beta_settings"][".originalPagesByType"] = tdataArray["spectrum_beta_settings"][".pagesByType"];
			tdataArray["spectrum_beta_settings"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["spectrum_beta_settings"][".originalPages"] = tdataArray["spectrum_beta_settings"][".pages"];
			tdataArray["spectrum_beta_settings"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["spectrum_beta_settings"][".originalDefaultPages"] = tdataArray["spectrum_beta_settings"][".defaultPages"];
			fieldLabelsArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			fieldToolTipsArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			pageTitlesArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			placeHoldersArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["spectrum_beta_settings"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["spectrum_beta_settings"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["spectrum_beta_settings"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["spectrum_beta_settings"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["spectrum_beta_settings"]["English"]["ID"] = "ID";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["ID"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["ID"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["TYPE"] = "TYPE";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["TYPE"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["TYPE"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["NAME"] = "NAME";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["NAME"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["NAME"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["USERNAME"] = "USERNAME";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["USERNAME"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["USERNAME"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["COOKIE"] = "COOKIE";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["COOKIE"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["COOKIE"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["SEARCH"] = "SEARCH";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["SEARCH"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["SEARCH"] = "";
				fieldLabelsArray["spectrum_beta_settings"]["English"]["TABLENAME"] = "TABLENAME";
				fieldToolTipsArray["spectrum_beta_settings"]["English"]["TABLENAME"] = "";
				placeHoldersArray["spectrum_beta_settings"]["English"]["TABLENAME"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["spectrum_beta_settings"]["English"])))
				{
					tdataArray["spectrum_beta_settings"][".isUseToolTips"] = true;
				}
			}
			tdataArray["spectrum_beta_settings"][".NCSearch"] = true;
			tdataArray["spectrum_beta_settings"][".shortTableName"] = "spectrum_beta_settings";
			tdataArray["spectrum_beta_settings"][".nSecOptions"] = 0;
			tdataArray["spectrum_beta_settings"][".mainTableOwnerID"] = "";
			tdataArray["spectrum_beta_settings"][".entityType"] = 0;
			tdataArray["spectrum_beta_settings"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["spectrum_beta_settings"][".strOriginalTableName"] = "dbo.spectrum_beta_settings";
			tdataArray["spectrum_beta_settings"][".showAddInPopup"] = false;
			tdataArray["spectrum_beta_settings"][".showEditInPopup"] = false;
			tdataArray["spectrum_beta_settings"][".showViewInPopup"] = false;
			tdataArray["spectrum_beta_settings"][".listAjax"] = false;
			tdataArray["spectrum_beta_settings"][".audit"] = false;
			tdataArray["spectrum_beta_settings"][".locking"] = false;
			GlobalVars.pages = tdataArray["spectrum_beta_settings"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["spectrum_beta_settings"][".edit"] = true;
				tdataArray["spectrum_beta_settings"][".afterEditAction"] = 1;
				tdataArray["spectrum_beta_settings"][".closePopupAfterEdit"] = 1;
				tdataArray["spectrum_beta_settings"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["spectrum_beta_settings"][".add"] = true;
				tdataArray["spectrum_beta_settings"][".afterAddAction"] = 1;
				tdataArray["spectrum_beta_settings"][".closePopupAfterAdd"] = 1;
				tdataArray["spectrum_beta_settings"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["spectrum_beta_settings"][".list"] = true;
			}
			tdataArray["spectrum_beta_settings"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["spectrum_beta_settings"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["spectrum_beta_settings"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["spectrum_beta_settings"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["spectrum_beta_settings"][".printFriendly"] = true;
			}
			tdataArray["spectrum_beta_settings"][".showSimpleSearchOptions"] = true;
			tdataArray["spectrum_beta_settings"][".allowShowHideFields"] = true;
			tdataArray["spectrum_beta_settings"][".allowFieldsReordering"] = true;
			tdataArray["spectrum_beta_settings"][".isUseAjaxSuggest"] = true;


			tdataArray["spectrum_beta_settings"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["spectrum_beta_settings"][".buttonsAdded"] = false;
			tdataArray["spectrum_beta_settings"][".addPageEvents"] = false;
			tdataArray["spectrum_beta_settings"][".isUseTimeForSearch"] = false;
			tdataArray["spectrum_beta_settings"][".badgeColor"] = "1E90FF";
			tdataArray["spectrum_beta_settings"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("ID");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("TYPE");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("NAME");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("USERNAME");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("COOKIE");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("SEARCH");
			tdataArray["spectrum_beta_settings"][".googleLikeFields"].Add("TABLENAME");
			tdataArray["spectrum_beta_settings"][".tableType"] = "list";
			tdataArray["spectrum_beta_settings"][".printerPageOrientation"] = 0;
			tdataArray["spectrum_beta_settings"][".nPrinterPageScale"] = 100;
			tdataArray["spectrum_beta_settings"][".nPrinterSplitRecords"] = 40;
			tdataArray["spectrum_beta_settings"][".geocodingEnabled"] = false;
			tdataArray["spectrum_beta_settings"][".pageSize"] = 20;
			tdataArray["spectrum_beta_settings"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["spectrum_beta_settings"][".strOrderBy"] = tstrOrderBy;
			tdataArray["spectrum_beta_settings"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_settings"][".sqlHead"] = "SELECT ID,  	[TYPE],  	NAME,  	USERNAME,  	COOKIE,  	[SEARCH],  	TABLENAME";
			tdataArray["spectrum_beta_settings"][".sqlFrom"] = "FROM dbo.spectrum_beta_settings";
			tdataArray["spectrum_beta_settings"][".sqlWhereExpr"] = "";
			tdataArray["spectrum_beta_settings"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["spectrum_beta_settings"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["spectrum_beta_settings"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["spectrum_beta_settings"][".highlightSearchResults"] = true;
			tableKeysArray["spectrum_beta_settings"] = SettingsMap.GetArray();
			tableKeysArray["spectrum_beta_settings"].Add("ID");
			tdataArray["spectrum_beta_settings"][".Keys"] = tableKeysArray["spectrum_beta_settings"];
			tdataArray["spectrum_beta_settings"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "ID";
			fdata["GoodName"] = "ID";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","ID");
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
			tdataArray["spectrum_beta_settings"]["ID"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("ID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "TYPE";
			fdata["GoodName"] = "TYPE";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","TYPE");
			fdata["FieldType"] = 3;
			fdata["strField"] = "TYPE";
			fdata["sourceSingle"] = "TYPE";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[TYPE]";
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
			tdataArray["spectrum_beta_settings"]["TYPE"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("TYPE");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "NAME";
			fdata["GoodName"] = "NAME";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","NAME");
			fdata["FieldType"] = 202;
			fdata["strField"] = "NAME";
			fdata["sourceSingle"] = "NAME";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "NAME";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=300");
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
			tdataArray["spectrum_beta_settings"]["NAME"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("NAME");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "USERNAME";
			fdata["GoodName"] = "USERNAME";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","USERNAME");
			fdata["FieldType"] = 202;
			fdata["strField"] = "USERNAME";
			fdata["sourceSingle"] = "USERNAME";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "USERNAME";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=300");
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
			tdataArray["spectrum_beta_settings"]["USERNAME"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("USERNAME");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "COOKIE";
			fdata["GoodName"] = "COOKIE";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","COOKIE");
			fdata["FieldType"] = 200;
			fdata["strField"] = "COOKIE";
			fdata["sourceSingle"] = "COOKIE";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "COOKIE";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=500");
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
			tdataArray["spectrum_beta_settings"]["COOKIE"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("COOKIE");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 6;
			fdata["strName"] = "SEARCH";
			fdata["GoodName"] = "SEARCH";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","SEARCH");
			fdata["FieldType"] = 203;
			fdata["strField"] = "SEARCH";
			fdata["sourceSingle"] = "SEARCH";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[SEARCH]";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Text area");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 0;
			edata["nRows"] = 100;
			edata["nCols"] = 200;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["CreateThumbnail"] = true;
			edata["StrThumbnail"] = "th";
			edata["ThumbnailSize"] = 600;
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
			tdataArray["spectrum_beta_settings"]["SEARCH"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("SEARCH");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 7;
			fdata["strName"] = "TABLENAME";
			fdata["GoodName"] = "TABLENAME";
			fdata["ownerTable"] = "dbo.spectrum_beta_settings";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_settings","TABLENAME");
			fdata["FieldType"] = 200;
			fdata["strField"] = "TABLENAME";
			fdata["sourceSingle"] = "TABLENAME";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "TABLENAME";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=300");
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
			tdataArray["spectrum_beta_settings"]["TABLENAME"] = fdata;
			tdataArray["spectrum_beta_settings"][".searchableFields"].Add("TABLENAME");
			GlobalVars.tables_data["dbo.spectrum_beta_settings"] = tdataArray["spectrum_beta_settings"];
			GlobalVars.field_labels["dbo_spectrum_beta_settings"] = fieldLabelsArray["spectrum_beta_settings"];
			GlobalVars.fieldToolTips["dbo_spectrum_beta_settings"] = fieldToolTipsArray["spectrum_beta_settings"];
			GlobalVars.placeHolders["dbo_spectrum_beta_settings"] = placeHoldersArray["spectrum_beta_settings"];
			GlobalVars.page_titles["dbo_spectrum_beta_settings"] = pageTitlesArray["spectrum_beta_settings"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.spectrum_beta_settings"));
			GlobalVars.detailsTablesData["dbo.spectrum_beta_settings"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.spectrum_beta_settings"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "ID,  	[TYPE],  	NAME,  	USERNAME,  	COOKIE,  	[SEARCH],  	TABLENAME";
protoArray["0"]["m_strFrom"] = "FROM dbo.spectrum_beta_settings";
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
obj = new SQLField(new XVar("m_strName", "ID", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["6"]["m_sql"] = "ID";
protoArray["6"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "TYPE", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["8"]["m_sql"] = "[TYPE]";
protoArray["8"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "NAME", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["10"]["m_sql"] = "NAME";
protoArray["10"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "USERNAME", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["12"]["m_sql"] = "USERNAME";
protoArray["12"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "COOKIE", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["14"]["m_sql"] = "COOKIE";
protoArray["14"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["16"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "SEARCH", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["16"]["m_sql"] = "[SEARCH]";
protoArray["16"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["16"]["m_expr"] = obj;
protoArray["16"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["16"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["18"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "TABLENAME", "m_strTable", "dbo.spectrum_beta_settings", "m_srcTableName", "dbo.spectrum_beta_settings"));

protoArray["18"]["m_sql"] = "TABLENAME";
protoArray["18"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["18"]["m_expr"] = obj;
protoArray["18"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["18"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["20"] = SettingsMap.GetArray();
protoArray["20"]["m_link"] = "SQLL_MAIN";
protoArray["21"] = SettingsMap.GetArray();
protoArray["21"]["m_strName"] = "dbo.spectrum_beta_settings";
protoArray["21"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
protoArray["21"]["m_columns"] = SettingsMap.GetArray();
protoArray["21"]["m_columns"].Add("ID");
protoArray["21"]["m_columns"].Add("TYPE");
protoArray["21"]["m_columns"].Add("NAME");
protoArray["21"]["m_columns"].Add("USERNAME");
protoArray["21"]["m_columns"].Add("COOKIE");
protoArray["21"]["m_columns"].Add("SEARCH");
protoArray["21"]["m_columns"].Add("TABLENAME");
obj = new SQLTable(protoArray["21"]);

protoArray["20"]["m_table"] = obj;
protoArray["20"]["m_sql"] = "dbo.spectrum_beta_settings";
protoArray["20"]["m_alias"] = "";
protoArray["20"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
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
protoArray["0"]["m_srcTableName"] = "dbo.spectrum_beta_settings";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["spectrum_beta_settings"] = obj;

				
		
			tdataArray["spectrum_beta_settings"][".sqlquery"] = queryData_Array["spectrum_beta_settings"];
			tdataArray["spectrum_beta_settings"][".hasEvents"] = false;
		}
	}

}
