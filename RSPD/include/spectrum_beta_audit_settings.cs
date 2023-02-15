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
	public static partial class Settings_spectrum_beta_audit
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".ShortName"] = "spectrum_beta_audit";
			tdataArray["spectrum_beta_audit"][".OwnerID"] = "";
			tdataArray["spectrum_beta_audit"][".OriginalTable"] = "dbo.spectrum_beta_audit";
			tdataArray["spectrum_beta_audit"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["spectrum_beta_audit"][".originalPagesByType"] = tdataArray["spectrum_beta_audit"][".pagesByType"];
			tdataArray["spectrum_beta_audit"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["spectrum_beta_audit"][".originalPages"] = tdataArray["spectrum_beta_audit"][".pages"];
			tdataArray["spectrum_beta_audit"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["spectrum_beta_audit"][".originalDefaultPages"] = tdataArray["spectrum_beta_audit"][".defaultPages"];
			fieldLabelsArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			fieldToolTipsArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			pageTitlesArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			placeHoldersArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["spectrum_beta_audit"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["spectrum_beta_audit"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["spectrum_beta_audit"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["spectrum_beta_audit"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["spectrum_beta_audit"]["English"]["id"] = "Id";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["id"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["id"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["datetime"] = "Datetime";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["datetime"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["datetime"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["ip"] = "Ip";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["ip"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["ip"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["user"] = "User";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["user"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["user"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["table"] = "Table";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["table"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["table"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["action"] = "Action";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["action"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["action"] = "";
				fieldLabelsArray["spectrum_beta_audit"]["English"]["description"] = "Description";
				fieldToolTipsArray["spectrum_beta_audit"]["English"]["description"] = "";
				placeHoldersArray["spectrum_beta_audit"]["English"]["description"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["spectrum_beta_audit"]["English"])))
				{
					tdataArray["spectrum_beta_audit"][".isUseToolTips"] = true;
				}
			}
			tdataArray["spectrum_beta_audit"][".NCSearch"] = true;
			tdataArray["spectrum_beta_audit"][".shortTableName"] = "spectrum_beta_audit";
			tdataArray["spectrum_beta_audit"][".nSecOptions"] = 0;
			tdataArray["spectrum_beta_audit"][".mainTableOwnerID"] = "";
			tdataArray["spectrum_beta_audit"][".entityType"] = 0;
			tdataArray["spectrum_beta_audit"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["spectrum_beta_audit"][".strOriginalTableName"] = "dbo.spectrum_beta_audit";
			tdataArray["spectrum_beta_audit"][".showAddInPopup"] = false;
			tdataArray["spectrum_beta_audit"][".showEditInPopup"] = false;
			tdataArray["spectrum_beta_audit"][".showViewInPopup"] = false;
			tdataArray["spectrum_beta_audit"][".listAjax"] = false;
			tdataArray["spectrum_beta_audit"][".audit"] = false;
			tdataArray["spectrum_beta_audit"][".locking"] = false;
			GlobalVars.pages = tdataArray["spectrum_beta_audit"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["spectrum_beta_audit"][".edit"] = true;
				tdataArray["spectrum_beta_audit"][".afterEditAction"] = 1;
				tdataArray["spectrum_beta_audit"][".closePopupAfterEdit"] = 1;
				tdataArray["spectrum_beta_audit"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["spectrum_beta_audit"][".add"] = true;
				tdataArray["spectrum_beta_audit"][".afterAddAction"] = 1;
				tdataArray["spectrum_beta_audit"][".closePopupAfterAdd"] = 1;
				tdataArray["spectrum_beta_audit"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["spectrum_beta_audit"][".list"] = true;
			}
			tdataArray["spectrum_beta_audit"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["spectrum_beta_audit"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["spectrum_beta_audit"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["spectrum_beta_audit"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["spectrum_beta_audit"][".printFriendly"] = true;
			}
			tdataArray["spectrum_beta_audit"][".showSimpleSearchOptions"] = true;
			tdataArray["spectrum_beta_audit"][".allowShowHideFields"] = true;
			tdataArray["spectrum_beta_audit"][".allowFieldsReordering"] = true;
			tdataArray["spectrum_beta_audit"][".isUseAjaxSuggest"] = true;


			tdataArray["spectrum_beta_audit"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["spectrum_beta_audit"][".buttonsAdded"] = false;
			tdataArray["spectrum_beta_audit"][".addPageEvents"] = false;
			tdataArray["spectrum_beta_audit"][".isUseTimeForSearch"] = false;
			tdataArray["spectrum_beta_audit"][".badgeColor"] = "5F9EA0";
			tdataArray["spectrum_beta_audit"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("id");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("datetime");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("ip");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("user");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("table");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("action");
			tdataArray["spectrum_beta_audit"][".googleLikeFields"].Add("description");
			tdataArray["spectrum_beta_audit"][".tableType"] = "list";
			tdataArray["spectrum_beta_audit"][".printerPageOrientation"] = 0;
			tdataArray["spectrum_beta_audit"][".nPrinterPageScale"] = 100;
			tdataArray["spectrum_beta_audit"][".nPrinterSplitRecords"] = 40;
			tdataArray["spectrum_beta_audit"][".geocodingEnabled"] = false;
			tdataArray["spectrum_beta_audit"][".pageSize"] = 20;
			tdataArray["spectrum_beta_audit"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["spectrum_beta_audit"][".strOrderBy"] = tstrOrderBy;
			tdataArray["spectrum_beta_audit"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["spectrum_beta_audit"][".sqlHead"] = "SELECT id,  	[datetime],  	ip,  	[user],  	[table],  	[action],  	description";
			tdataArray["spectrum_beta_audit"][".sqlFrom"] = "FROM dbo.spectrum_beta_audit";
			tdataArray["spectrum_beta_audit"][".sqlWhereExpr"] = "";
			tdataArray["spectrum_beta_audit"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["spectrum_beta_audit"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["spectrum_beta_audit"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["spectrum_beta_audit"][".highlightSearchResults"] = true;
			tableKeysArray["spectrum_beta_audit"] = SettingsMap.GetArray();
			tableKeysArray["spectrum_beta_audit"].Add("id");
			tdataArray["spectrum_beta_audit"][".Keys"] = tableKeysArray["spectrum_beta_audit"];
			tdataArray["spectrum_beta_audit"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "id";
			fdata["GoodName"] = "id";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","id");
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
			tdataArray["spectrum_beta_audit"]["id"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "datetime";
			fdata["GoodName"] = "datetime";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","datetime");
			fdata["FieldType"] = 135;
			fdata["strField"] = "datetime";
			fdata["sourceSingle"] = "datetime";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[datetime]";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "Short Date");
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Date");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["IsRequired"] = true;
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["DateEditType"] = 13;
			edata["InitialYearFactor"] = 100;
			edata["LastYearFactor"] = 10;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"].Add("IsRequired");
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "Equals";
			fdata["searchOptionsList"] = new XVar(0, "Equals", 1, "More than", 2, "Less than", 3, "Between", 4, Constants.EMPTY_SEARCH, 5, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["spectrum_beta_audit"]["datetime"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("datetime");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "ip";
			fdata["GoodName"] = "ip";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","ip");
			fdata["FieldType"] = 200;
			fdata["strField"] = "ip";
			fdata["sourceSingle"] = "ip";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "ip";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=40");
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
			tdataArray["spectrum_beta_audit"]["ip"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("ip");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "user";
			fdata["GoodName"] = "user";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","user");
			fdata["FieldType"] = 200;
			fdata["strField"] = "user";
			fdata["sourceSingle"] = "user";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[user]";
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
			tdataArray["spectrum_beta_audit"]["user"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("user");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "table";
			fdata["GoodName"] = "table";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","table");
			fdata["FieldType"] = 200;
			fdata["strField"] = "table";
			fdata["sourceSingle"] = "table";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[table]";
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
			tdataArray["spectrum_beta_audit"]["table"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("table");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 6;
			fdata["strName"] = "action";
			fdata["GoodName"] = "action";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","action");
			fdata["FieldType"] = 200;
			fdata["strField"] = "action";
			fdata["sourceSingle"] = "action";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[action]";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=250");
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
			tdataArray["spectrum_beta_audit"]["action"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("action");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 7;
			fdata["strName"] = "description";
			fdata["GoodName"] = "description";
			fdata["ownerTable"] = "dbo.spectrum_beta_audit";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_beta_audit","description");
			fdata["FieldType"] = 201;
			fdata["strField"] = "description";
			fdata["sourceSingle"] = "description";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "description";
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
			tdataArray["spectrum_beta_audit"]["description"] = fdata;
			tdataArray["spectrum_beta_audit"][".searchableFields"].Add("description");
			GlobalVars.tables_data["dbo.spectrum_beta_audit"] = tdataArray["spectrum_beta_audit"];
			GlobalVars.field_labels["dbo_spectrum_beta_audit"] = fieldLabelsArray["spectrum_beta_audit"];
			GlobalVars.fieldToolTips["dbo_spectrum_beta_audit"] = fieldToolTipsArray["spectrum_beta_audit"];
			GlobalVars.placeHolders["dbo_spectrum_beta_audit"] = placeHoldersArray["spectrum_beta_audit"];
			GlobalVars.page_titles["dbo_spectrum_beta_audit"] = pageTitlesArray["spectrum_beta_audit"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.spectrum_beta_audit"));
			GlobalVars.detailsTablesData["dbo.spectrum_beta_audit"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.spectrum_beta_audit"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "id,  	[datetime],  	ip,  	[user],  	[table],  	[action],  	description";
protoArray["0"]["m_strFrom"] = "FROM dbo.spectrum_beta_audit";
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
obj = new SQLField(new XVar("m_strName", "id", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["6"]["m_sql"] = "id";
protoArray["6"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "datetime", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["8"]["m_sql"] = "[datetime]";
protoArray["8"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "ip", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["10"]["m_sql"] = "ip";
protoArray["10"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "user", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["12"]["m_sql"] = "[user]";
protoArray["12"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "table", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["14"]["m_sql"] = "[table]";
protoArray["14"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["16"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "action", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["16"]["m_sql"] = "[action]";
protoArray["16"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["16"]["m_expr"] = obj;
protoArray["16"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["16"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["18"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "description", "m_strTable", "dbo.spectrum_beta_audit", "m_srcTableName", "dbo.spectrum_beta_audit"));

protoArray["18"]["m_sql"] = "description";
protoArray["18"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["18"]["m_expr"] = obj;
protoArray["18"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["18"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["20"] = SettingsMap.GetArray();
protoArray["20"]["m_link"] = "SQLL_MAIN";
protoArray["21"] = SettingsMap.GetArray();
protoArray["21"]["m_strName"] = "dbo.spectrum_beta_audit";
protoArray["21"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
protoArray["21"]["m_columns"] = SettingsMap.GetArray();
protoArray["21"]["m_columns"].Add("id");
protoArray["21"]["m_columns"].Add("datetime");
protoArray["21"]["m_columns"].Add("ip");
protoArray["21"]["m_columns"].Add("user");
protoArray["21"]["m_columns"].Add("table");
protoArray["21"]["m_columns"].Add("action");
protoArray["21"]["m_columns"].Add("description");
obj = new SQLTable(protoArray["21"]);

protoArray["20"]["m_table"] = obj;
protoArray["20"]["m_sql"] = "dbo.spectrum_beta_audit";
protoArray["20"]["m_alias"] = "";
protoArray["20"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
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
protoArray["0"]["m_srcTableName"] = "dbo.spectrum_beta_audit";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["spectrum_beta_audit"] = obj;

				
		
			tdataArray["spectrum_beta_audit"][".sqlquery"] = queryData_Array["spectrum_beta_audit"];
			tdataArray["spectrum_beta_audit"][".hasEvents"] = false;
		}
	}

}
