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
	public static partial class Settings_sysdiagrams
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["sysdiagrams"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".ShortName"] = "sysdiagrams";
			tdataArray["sysdiagrams"][".OwnerID"] = "";
			tdataArray["sysdiagrams"][".OriginalTable"] = "dbo.sysdiagrams";
			tdataArray["sysdiagrams"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}"));
			tdataArray["sysdiagrams"][".originalPagesByType"] = tdataArray["sysdiagrams"][".pagesByType"];
			tdataArray["sysdiagrams"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"add\":[\"add\"],\"edit\":[\"edit\"],\"export\":[\"export\"],\"import\":[\"import\"],\"list\":[\"list\"],\"print\":[\"print\"],\"search\":[\"search\"],\"view\":[\"view\"]}")));
			tdataArray["sysdiagrams"][".originalPages"] = tdataArray["sysdiagrams"][".pages"];
			tdataArray["sysdiagrams"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"add\":\"add\",\"edit\":\"edit\",\"export\":\"export\",\"import\":\"import\",\"list\":\"list\",\"print\":\"print\",\"search\":\"search\",\"view\":\"view\"}"));
			tdataArray["sysdiagrams"][".originalDefaultPages"] = tdataArray["sysdiagrams"][".defaultPages"];
			fieldLabelsArray["sysdiagrams"] = SettingsMap.GetArray();
			fieldToolTipsArray["sysdiagrams"] = SettingsMap.GetArray();
			pageTitlesArray["sysdiagrams"] = SettingsMap.GetArray();
			placeHoldersArray["sysdiagrams"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["sysdiagrams"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["sysdiagrams"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["sysdiagrams"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["sysdiagrams"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["sysdiagrams"]["English"]["name"] = "Name";
				fieldToolTipsArray["sysdiagrams"]["English"]["name"] = "";
				placeHoldersArray["sysdiagrams"]["English"]["name"] = "";
				fieldLabelsArray["sysdiagrams"]["English"]["principal_id"] = "Principal Id";
				fieldToolTipsArray["sysdiagrams"]["English"]["principal_id"] = "";
				placeHoldersArray["sysdiagrams"]["English"]["principal_id"] = "";
				fieldLabelsArray["sysdiagrams"]["English"]["diagram_id"] = "Diagram Id";
				fieldToolTipsArray["sysdiagrams"]["English"]["diagram_id"] = "";
				placeHoldersArray["sysdiagrams"]["English"]["diagram_id"] = "";
				fieldLabelsArray["sysdiagrams"]["English"]["version"] = "Version";
				fieldToolTipsArray["sysdiagrams"]["English"]["version"] = "";
				placeHoldersArray["sysdiagrams"]["English"]["version"] = "";
				fieldLabelsArray["sysdiagrams"]["English"]["definition"] = "Definition";
				fieldToolTipsArray["sysdiagrams"]["English"]["definition"] = "";
				placeHoldersArray["sysdiagrams"]["English"]["definition"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["sysdiagrams"]["English"])))
				{
					tdataArray["sysdiagrams"][".isUseToolTips"] = true;
				}
			}
			tdataArray["sysdiagrams"][".NCSearch"] = true;
			tdataArray["sysdiagrams"][".shortTableName"] = "sysdiagrams";
			tdataArray["sysdiagrams"][".nSecOptions"] = 0;
			tdataArray["sysdiagrams"][".mainTableOwnerID"] = "";
			tdataArray["sysdiagrams"][".entityType"] = 0;
			tdataArray["sysdiagrams"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["sysdiagrams"][".strOriginalTableName"] = "dbo.sysdiagrams";
			tdataArray["sysdiagrams"][".showAddInPopup"] = false;
			tdataArray["sysdiagrams"][".showEditInPopup"] = false;
			tdataArray["sysdiagrams"][".showViewInPopup"] = false;
			tdataArray["sysdiagrams"][".listAjax"] = false;
			tdataArray["sysdiagrams"][".audit"] = true;
			tdataArray["sysdiagrams"][".locking"] = false;
			GlobalVars.pages = tdataArray["sysdiagrams"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["sysdiagrams"][".edit"] = true;
				tdataArray["sysdiagrams"][".afterEditAction"] = 1;
				tdataArray["sysdiagrams"][".closePopupAfterEdit"] = 1;
				tdataArray["sysdiagrams"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["sysdiagrams"][".add"] = true;
				tdataArray["sysdiagrams"][".afterAddAction"] = 1;
				tdataArray["sysdiagrams"][".closePopupAfterAdd"] = 1;
				tdataArray["sysdiagrams"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["sysdiagrams"][".list"] = true;
			}
			tdataArray["sysdiagrams"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["sysdiagrams"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["sysdiagrams"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["sysdiagrams"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["sysdiagrams"][".printFriendly"] = true;
			}
			tdataArray["sysdiagrams"][".showSimpleSearchOptions"] = true;
			tdataArray["sysdiagrams"][".allowShowHideFields"] = true;
			tdataArray["sysdiagrams"][".allowFieldsReordering"] = true;
			tdataArray["sysdiagrams"][".isUseAjaxSuggest"] = true;


			tdataArray["sysdiagrams"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["sysdiagrams"][".buttonsAdded"] = false;
			tdataArray["sysdiagrams"][".addPageEvents"] = false;
			tdataArray["sysdiagrams"][".isUseTimeForSearch"] = false;
			tdataArray["sysdiagrams"][".badgeColor"] = "3CB371";
			tdataArray["sysdiagrams"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".googleLikeFields"].Add("name");
			tdataArray["sysdiagrams"][".googleLikeFields"].Add("principal_id");
			tdataArray["sysdiagrams"][".googleLikeFields"].Add("diagram_id");
			tdataArray["sysdiagrams"][".googleLikeFields"].Add("version");
			tdataArray["sysdiagrams"][".tableType"] = "list";
			tdataArray["sysdiagrams"][".printerPageOrientation"] = 0;
			tdataArray["sysdiagrams"][".nPrinterPageScale"] = 100;
			tdataArray["sysdiagrams"][".nPrinterSplitRecords"] = 40;
			tdataArray["sysdiagrams"][".geocodingEnabled"] = false;
			tdataArray["sysdiagrams"][".pageSize"] = 20;
			tdataArray["sysdiagrams"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["sysdiagrams"][".strOrderBy"] = tstrOrderBy;
			tdataArray["sysdiagrams"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["sysdiagrams"][".sqlHead"] = "SELECT name,  	principal_id,  	diagram_id,  	version,  	definition";
			tdataArray["sysdiagrams"][".sqlFrom"] = "FROM dbo.sysdiagrams";
			tdataArray["sysdiagrams"][".sqlWhereExpr"] = "";
			tdataArray["sysdiagrams"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["sysdiagrams"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["sysdiagrams"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["sysdiagrams"][".highlightSearchResults"] = true;
			tableKeysArray["sysdiagrams"] = SettingsMap.GetArray();
			tableKeysArray["sysdiagrams"].Add("diagram_id");
			tdataArray["sysdiagrams"][".Keys"] = tableKeysArray["sysdiagrams"];
			tdataArray["sysdiagrams"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "name";
			fdata["GoodName"] = "name";
			fdata["ownerTable"] = "dbo.sysdiagrams";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_sysdiagrams","name");
			fdata["FieldType"] = 202;
			fdata["strField"] = "name";
			fdata["sourceSingle"] = "name";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "name";
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
			edata["EditParams"] = MVCFunctions.Concat(edata["EditParams"], " maxlength=128");
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
			tdataArray["sysdiagrams"]["name"] = fdata;
			tdataArray["sysdiagrams"][".searchableFields"].Add("name");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "principal_id";
			fdata["GoodName"] = "principal_id";
			fdata["ownerTable"] = "dbo.sysdiagrams";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_sysdiagrams","principal_id");
			fdata["FieldType"] = 3;
			fdata["strField"] = "principal_id";
			fdata["sourceSingle"] = "principal_id";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "principal_id";
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
			tdataArray["sysdiagrams"]["principal_id"] = fdata;
			tdataArray["sysdiagrams"][".searchableFields"].Add("principal_id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "diagram_id";
			fdata["GoodName"] = "diagram_id";
			fdata["ownerTable"] = "dbo.sysdiagrams";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_sysdiagrams","diagram_id");
			fdata["FieldType"] = 3;
			fdata["AutoInc"] = true;
			fdata["strField"] = "diagram_id";
			fdata["sourceSingle"] = "diagram_id";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "diagram_id";
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
			tdataArray["sysdiagrams"]["diagram_id"] = fdata;
			tdataArray["sysdiagrams"][".searchableFields"].Add("diagram_id");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "version";
			fdata["GoodName"] = "version";
			fdata["ownerTable"] = "dbo.sysdiagrams";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_sysdiagrams","version");
			fdata["FieldType"] = 3;
			fdata["strField"] = "version";
			fdata["sourceSingle"] = "version";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "version";
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
			tdataArray["sysdiagrams"]["version"] = fdata;
			tdataArray["sysdiagrams"][".searchableFields"].Add("version");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 5;
			fdata["strName"] = "definition";
			fdata["GoodName"] = "definition";
			fdata["ownerTable"] = "dbo.sysdiagrams";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_sysdiagrams","definition");
			fdata["FieldType"] = 205;
			fdata["strField"] = "definition";
			fdata["sourceSingle"] = "definition";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "definition";
			fdata["UploadFolder"] = "files";
			fdata["ViewFormats"] = SettingsMap.GetArray();
			vdata = new XVar("ViewFormat", "Database Image");
			vdata["ImageWidth"] = 600;
			vdata["ImageHeight"] = 400;
			vdata["showGallery"] = true;
			vdata["galleryMode"] = 2;
			vdata["captionMode"] = 1;
			vdata["captionField"] = "";
			vdata["imageBorder"] = 1;
			vdata["imageFullWidth"] = 1;
			vdata["NeedEncode"] = true;
			vdata["truncateText"] = true;
			vdata["NumberOfChars"] = 80;
			fdata["ViewFormats"]["view"] = vdata;
			fdata["EditFormats"] = SettingsMap.GetArray();
			edata = new XVar("EditFormat", "Database image");
			edata["weekdayMessage"] = new XVar("message", "", "messageType", "Text");
			edata["weekdays"] = "[]";
			edata["acceptFileTypesHtml"] = "";
			edata["maxNumberOfFiles"] = 1;
			edata["controlWidth"] = 200;
			edata["validateAs"] = SettingsMap.GetArray();
			edata["validateAs"]["basicValidate"] = SettingsMap.GetArray();
			edata["validateAs"]["customMessages"] = SettingsMap.GetArray();
			fdata["EditFormats"]["edit"] = edata;
			fdata["isSeparate"] = false;
			fdata["defaultSearchOption"] = "NOT Empty";
			fdata["searchOptionsList"] = new XVar(0, "Contains", 1, "Equals", 2, "Starts with", 3, "More than", 4, "Less than", 5, "Between", 6, "Empty", 7, Constants.NOT_EMPTY);
			fdata["filterTotals"] = 0;
			fdata["filterMultiSelect"] = 0;
			fdata["filterFormat"] = "Values list";
			fdata["showCollapsed"] = false;
			fdata["sortValueType"] = 0;
			fdata["numberOfVisibleItems"] = 10;
			fdata["filterBy"] = 0;
			tdataArray["sysdiagrams"]["definition"] = fdata;
			GlobalVars.tables_data["dbo.sysdiagrams"] = tdataArray["sysdiagrams"];
			GlobalVars.field_labels["dbo_sysdiagrams"] = fieldLabelsArray["sysdiagrams"];
			GlobalVars.fieldToolTips["dbo_sysdiagrams"] = fieldToolTipsArray["sysdiagrams"];
			GlobalVars.placeHolders["dbo_sysdiagrams"] = placeHoldersArray["sysdiagrams"];
			GlobalVars.page_titles["dbo_sysdiagrams"] = pageTitlesArray["sysdiagrams"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.sysdiagrams"));
			GlobalVars.detailsTablesData["dbo.sysdiagrams"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.sysdiagrams"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "name,  	principal_id,  	diagram_id,  	version,  	definition";
protoArray["0"]["m_strFrom"] = "FROM dbo.sysdiagrams";
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
obj = new SQLField(new XVar("m_strName", "name", "m_strTable", "dbo.sysdiagrams", "m_srcTableName", "dbo.sysdiagrams"));

protoArray["6"]["m_sql"] = "name";
protoArray["6"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "principal_id", "m_strTable", "dbo.sysdiagrams", "m_srcTableName", "dbo.sysdiagrams"));

protoArray["8"]["m_sql"] = "principal_id";
protoArray["8"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "diagram_id", "m_strTable", "dbo.sysdiagrams", "m_srcTableName", "dbo.sysdiagrams"));

protoArray["10"]["m_sql"] = "diagram_id";
protoArray["10"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "version", "m_strTable", "dbo.sysdiagrams", "m_srcTableName", "dbo.sysdiagrams"));

protoArray["12"]["m_sql"] = "version";
protoArray["12"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["14"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "definition", "m_strTable", "dbo.sysdiagrams", "m_srcTableName", "dbo.sysdiagrams"));

protoArray["14"]["m_sql"] = "definition";
protoArray["14"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["14"]["m_expr"] = obj;
protoArray["14"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["14"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["16"] = SettingsMap.GetArray();
protoArray["16"]["m_link"] = "SQLL_MAIN";
protoArray["17"] = SettingsMap.GetArray();
protoArray["17"]["m_strName"] = "dbo.sysdiagrams";
protoArray["17"]["m_srcTableName"] = "dbo.sysdiagrams";
protoArray["17"]["m_columns"] = SettingsMap.GetArray();
protoArray["17"]["m_columns"].Add("name");
protoArray["17"]["m_columns"].Add("principal_id");
protoArray["17"]["m_columns"].Add("diagram_id");
protoArray["17"]["m_columns"].Add("version");
protoArray["17"]["m_columns"].Add("definition");
obj = new SQLTable(protoArray["17"]);

protoArray["16"]["m_table"] = obj;
protoArray["16"]["m_sql"] = "dbo.sysdiagrams";
protoArray["16"]["m_alias"] = "";
protoArray["16"]["m_srcTableName"] = "dbo.sysdiagrams";
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
protoArray["0"]["m_srcTableName"] = "dbo.sysdiagrams";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["sysdiagrams"] = obj;

				
		
			tdataArray["sysdiagrams"][".sqlquery"] = queryData_Array["sysdiagrams"];
			tdataArray["sysdiagrams"][".hasEvents"] = false;
		}
	}

}
