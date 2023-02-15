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
	public static partial class Settings_spectrum_betauggroups
	{
		static public void Apply()
		{
			SettingsMap arrGPP = SettingsMap.GetArray(), arrGridTabs = SettingsMap.GetArray(), arrRPP = SettingsMap.GetArray(), dIndex = null, detailsParam = SettingsMap.GetArray(), edata = SettingsMap.GetArray(), eventsData = SettingsMap.GetArray(), fdata = SettingsMap.GetArray(), fieldLabelsArray = new XVar(), fieldToolTipsArray = new XVar(), hours = null, intervalData = SettingsMap.GetArray(), masterParams = SettingsMap.GetArray(), pageTitlesArray = new XVar(), placeHoldersArray = new XVar(), query = null, queryData_Array = new XVar(), strOriginalDetailsTable = null, table = null, tableKeysArray = new XVar(), tdataArray = new XVar(), tstrOrderBy = null, vdata = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".searchableFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".ShortName"] = "spectrum_betauggroups";
			tdataArray["spectrum_betauggroups"][".OwnerID"] = "";
			tdataArray["spectrum_betauggroups"][".OriginalTable"] = "dbo.spectrum_betauggroups";
			tdataArray["spectrum_betauggroups"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{}"));
			tdataArray["spectrum_betauggroups"][".originalPagesByType"] = tdataArray["spectrum_betauggroups"][".pagesByType"];
			tdataArray["spectrum_betauggroups"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{}")));
			tdataArray["spectrum_betauggroups"][".originalPages"] = tdataArray["spectrum_betauggroups"][".pages"];
			tdataArray["spectrum_betauggroups"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{}"));
			tdataArray["spectrum_betauggroups"][".originalDefaultPages"] = tdataArray["spectrum_betauggroups"][".defaultPages"];
			fieldLabelsArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			fieldToolTipsArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			pageTitlesArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			placeHoldersArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["spectrum_betauggroups"]["English"] = SettingsMap.GetArray();
				fieldToolTipsArray["spectrum_betauggroups"]["English"] = SettingsMap.GetArray();
				placeHoldersArray["spectrum_betauggroups"]["English"] = SettingsMap.GetArray();
				pageTitlesArray["spectrum_betauggroups"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["spectrum_betauggroups"]["English"]["GroupID"] = "Group ID";
				fieldToolTipsArray["spectrum_betauggroups"]["English"]["GroupID"] = "";
				placeHoldersArray["spectrum_betauggroups"]["English"]["GroupID"] = "";
				fieldLabelsArray["spectrum_betauggroups"]["English"]["Label"] = "Label";
				fieldToolTipsArray["spectrum_betauggroups"]["English"]["Label"] = "";
				placeHoldersArray["spectrum_betauggroups"]["English"]["Label"] = "";
				fieldLabelsArray["spectrum_betauggroups"]["English"]["Provider"] = "Provider";
				fieldToolTipsArray["spectrum_betauggroups"]["English"]["Provider"] = "";
				placeHoldersArray["spectrum_betauggroups"]["English"]["Provider"] = "";
				fieldLabelsArray["spectrum_betauggroups"]["English"]["Comment"] = "Comment";
				fieldToolTipsArray["spectrum_betauggroups"]["English"]["Comment"] = "";
				placeHoldersArray["spectrum_betauggroups"]["English"]["Comment"] = "";
				if(XVar.Pack(MVCFunctions.count(fieldToolTipsArray["spectrum_betauggroups"]["English"])))
				{
					tdataArray["spectrum_betauggroups"][".isUseToolTips"] = true;
				}
			}
			tdataArray["spectrum_betauggroups"][".NCSearch"] = true;
			tdataArray["spectrum_betauggroups"][".shortTableName"] = "spectrum_betauggroups";
			tdataArray["spectrum_betauggroups"][".nSecOptions"] = 0;
			tdataArray["spectrum_betauggroups"][".mainTableOwnerID"] = "";
			tdataArray["spectrum_betauggroups"][".entityType"] = 0;
			tdataArray["spectrum_betauggroups"][".connId"] = "RSPDDB_at_172_16_0_80";
			tdataArray["spectrum_betauggroups"][".strOriginalTableName"] = "dbo.spectrum_betauggroups";
			tdataArray["spectrum_betauggroups"][".showAddInPopup"] = false;
			tdataArray["spectrum_betauggroups"][".showEditInPopup"] = false;
			tdataArray["spectrum_betauggroups"][".showViewInPopup"] = false;
			tdataArray["spectrum_betauggroups"][".listAjax"] = false;
			tdataArray["spectrum_betauggroups"][".audit"] = true;
			tdataArray["spectrum_betauggroups"][".locking"] = false;
			GlobalVars.pages = tdataArray["spectrum_betauggroups"][".defaultPages"];
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EDIT]))
			{
				tdataArray["spectrum_betauggroups"][".edit"] = true;
				tdataArray["spectrum_betauggroups"][".afterEditAction"] = 1;
				tdataArray["spectrum_betauggroups"][".closePopupAfterEdit"] = 1;
				tdataArray["spectrum_betauggroups"][".afterEditActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_ADD]))
			{
				tdataArray["spectrum_betauggroups"][".add"] = true;
				tdataArray["spectrum_betauggroups"][".afterAddAction"] = 1;
				tdataArray["spectrum_betauggroups"][".closePopupAfterAdd"] = 1;
				tdataArray["spectrum_betauggroups"][".afterAddActionDetTable"] = "";
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_LIST]))
			{
				tdataArray["spectrum_betauggroups"][".list"] = true;
			}
			tdataArray["spectrum_betauggroups"][".strSortControlSettingsJSON"] = "";
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_VIEW]))
			{
				tdataArray["spectrum_betauggroups"][".view"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_IMPORT]))
			{
				tdataArray["spectrum_betauggroups"][".import"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_EXPORT]))
			{
				tdataArray["spectrum_betauggroups"][".exportTo"] = true;
			}
			if(XVar.Pack(GlobalVars.pages[Constants.PAGE_PRINT]))
			{
				tdataArray["spectrum_betauggroups"][".printFriendly"] = true;
			}
			tdataArray["spectrum_betauggroups"][".showSimpleSearchOptions"] = true;
			tdataArray["spectrum_betauggroups"][".allowShowHideFields"] = true;
			tdataArray["spectrum_betauggroups"][".allowFieldsReordering"] = true;
			tdataArray["spectrum_betauggroups"][".isUseAjaxSuggest"] = true;


			tdataArray["spectrum_betauggroups"][".ajaxCodeSnippetAdded"] = false;
			tdataArray["spectrum_betauggroups"][".buttonsAdded"] = false;
			tdataArray["spectrum_betauggroups"][".addPageEvents"] = false;
			tdataArray["spectrum_betauggroups"][".isUseTimeForSearch"] = false;
			tdataArray["spectrum_betauggroups"][".badgeColor"] = "CD5C5C";
			tdataArray["spectrum_betauggroups"][".allSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".filterFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".requiredSearchFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".googleLikeFields"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".googleLikeFields"].Add("GroupID");
			tdataArray["spectrum_betauggroups"][".googleLikeFields"].Add("Label");
			tdataArray["spectrum_betauggroups"][".googleLikeFields"].Add("Provider");
			tdataArray["spectrum_betauggroups"][".googleLikeFields"].Add("Comment");
			tdataArray["spectrum_betauggroups"][".tableType"] = "list";
			tdataArray["spectrum_betauggroups"][".printerPageOrientation"] = 0;
			tdataArray["spectrum_betauggroups"][".nPrinterPageScale"] = 100;
			tdataArray["spectrum_betauggroups"][".nPrinterSplitRecords"] = 40;
			tdataArray["spectrum_betauggroups"][".geocodingEnabled"] = false;
			tdataArray["spectrum_betauggroups"][".pageSize"] = 20;
			tdataArray["spectrum_betauggroups"][".warnLeavingPages"] = true;
			tstrOrderBy = "";
			tdataArray["spectrum_betauggroups"][".strOrderBy"] = tstrOrderBy;
			tdataArray["spectrum_betauggroups"][".orderindexes"] = SettingsMap.GetArray();
			tdataArray["spectrum_betauggroups"][".sqlHead"] = "SELECT GroupID,  	[Label],  	Provider,  	[Comment]";
			tdataArray["spectrum_betauggroups"][".sqlFrom"] = "FROM dbo.spectrum_betauggroups";
			tdataArray["spectrum_betauggroups"][".sqlWhereExpr"] = "";
			tdataArray["spectrum_betauggroups"][".sqlTail"] = "";
			arrRPP = SettingsMap.GetArray();
			arrRPP.Add(10);
			arrRPP.Add(20);
			arrRPP.Add(30);
			arrRPP.Add(50);
			arrRPP.Add(100);
			arrRPP.Add(500);
			arrRPP.Add(-1);
			tdataArray["spectrum_betauggroups"][".arrRecsPerPage"] = arrRPP;
			arrGPP = SettingsMap.GetArray();
			arrGPP.Add(1);
			arrGPP.Add(3);
			arrGPP.Add(5);
			arrGPP.Add(10);
			arrGPP.Add(50);
			arrGPP.Add(100);
			arrGPP.Add(-1);
			tdataArray["spectrum_betauggroups"][".arrGroupsPerPage"] = arrGPP;
			tdataArray["spectrum_betauggroups"][".highlightSearchResults"] = true;
			tableKeysArray["spectrum_betauggroups"] = SettingsMap.GetArray();
			tableKeysArray["spectrum_betauggroups"].Add("GroupID");
			tdataArray["spectrum_betauggroups"][".Keys"] = tableKeysArray["spectrum_betauggroups"];
			tdataArray["spectrum_betauggroups"][".hideMobileList"] = SettingsMap.GetArray();
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 1;
			fdata["strName"] = "GroupID";
			fdata["GoodName"] = "GroupID";
			fdata["ownerTable"] = "dbo.spectrum_betauggroups";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betauggroups","GroupID");
			fdata["FieldType"] = 3;
			fdata["AutoInc"] = true;
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
			tdataArray["spectrum_betauggroups"]["GroupID"] = fdata;
			tdataArray["spectrum_betauggroups"][".searchableFields"].Add("GroupID");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 2;
			fdata["strName"] = "Label";
			fdata["GoodName"] = "Label";
			fdata["ownerTable"] = "dbo.spectrum_betauggroups";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betauggroups","Label");
			fdata["FieldType"] = 200;
			fdata["strField"] = "Label";
			fdata["sourceSingle"] = "Label";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[Label]";
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
			tdataArray["spectrum_betauggroups"]["Label"] = fdata;
			tdataArray["spectrum_betauggroups"][".searchableFields"].Add("Label");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 3;
			fdata["strName"] = "Provider";
			fdata["GoodName"] = "Provider";
			fdata["ownerTable"] = "dbo.spectrum_betauggroups";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betauggroups","Provider");
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
			tdataArray["spectrum_betauggroups"]["Provider"] = fdata;
			tdataArray["spectrum_betauggroups"][".searchableFields"].Add("Provider");
			fdata = SettingsMap.GetArray();
			fdata["Index"] = 4;
			fdata["strName"] = "Comment";
			fdata["GoodName"] = "Comment";
			fdata["ownerTable"] = "dbo.spectrum_betauggroups";
			fdata["Label"] = CommonFunctions.GetFieldLabel("dbo_spectrum_betauggroups","Comment");
			fdata["FieldType"] = 201;
			fdata["strField"] = "Comment";
			fdata["sourceSingle"] = "Comment";
			fdata["isSQLExpression"] = true;
			fdata["FullName"] = "[Comment]";
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
			tdataArray["spectrum_betauggroups"]["Comment"] = fdata;
			tdataArray["spectrum_betauggroups"][".searchableFields"].Add("Comment");
			GlobalVars.tables_data["dbo.spectrum_betauggroups"] = tdataArray["spectrum_betauggroups"];
			GlobalVars.field_labels["dbo_spectrum_betauggroups"] = fieldLabelsArray["spectrum_betauggroups"];
			GlobalVars.fieldToolTips["dbo_spectrum_betauggroups"] = fieldToolTipsArray["spectrum_betauggroups"];
			GlobalVars.placeHolders["dbo_spectrum_betauggroups"] = placeHoldersArray["spectrum_betauggroups"];
			GlobalVars.page_titles["dbo_spectrum_betauggroups"] = pageTitlesArray["spectrum_betauggroups"];
			CommonFunctions.changeTextControlsToDate(new XVar("dbo.spectrum_betauggroups"));
			GlobalVars.detailsTablesData["dbo.spectrum_betauggroups"] = SettingsMap.GetArray();
			GlobalVars.masterTablesData["dbo.spectrum_betauggroups"] = SettingsMap.GetArray();

SQLEntity obj = null;
var protoArray = SettingsMap.GetArray();
protoArray["0"] = SettingsMap.GetArray();
protoArray["0"]["m_strHead"] = "SELECT";
protoArray["0"]["m_strFieldList"] = "GroupID,  	[Label],  	Provider,  	[Comment]";
protoArray["0"]["m_strFrom"] = "FROM dbo.spectrum_betauggroups";
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
obj = new SQLField(new XVar("m_strName", "GroupID", "m_strTable", "dbo.spectrum_betauggroups", "m_srcTableName", "dbo.spectrum_betauggroups"));

protoArray["6"]["m_sql"] = "GroupID";
protoArray["6"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["6"]["m_expr"] = obj;
protoArray["6"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["6"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["8"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Label", "m_strTable", "dbo.spectrum_betauggroups", "m_srcTableName", "dbo.spectrum_betauggroups"));

protoArray["8"]["m_sql"] = "[Label]";
protoArray["8"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["8"]["m_expr"] = obj;
protoArray["8"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["8"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["10"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Provider", "m_strTable", "dbo.spectrum_betauggroups", "m_srcTableName", "dbo.spectrum_betauggroups"));

protoArray["10"]["m_sql"] = "Provider";
protoArray["10"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["10"]["m_expr"] = obj;
protoArray["10"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["10"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["12"] = SettingsMap.GetArray();
obj = new SQLField(new XVar("m_strName", "Comment", "m_strTable", "dbo.spectrum_betauggroups", "m_srcTableName", "dbo.spectrum_betauggroups"));

protoArray["12"]["m_sql"] = "[Comment]";
protoArray["12"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["12"]["m_expr"] = obj;
protoArray["12"]["m_alias"] = "";
obj = new SQLFieldListItem(protoArray["12"]);

protoArray["0"]["m_fieldlist"].Add(obj);
protoArray["0"]["m_fromlist"] = SettingsMap.GetArray();
protoArray["14"] = SettingsMap.GetArray();
protoArray["14"]["m_link"] = "SQLL_MAIN";
protoArray["15"] = SettingsMap.GetArray();
protoArray["15"]["m_strName"] = "dbo.spectrum_betauggroups";
protoArray["15"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["15"]["m_columns"] = SettingsMap.GetArray();
protoArray["15"]["m_columns"].Add("GroupID");
protoArray["15"]["m_columns"].Add("Label");
protoArray["15"]["m_columns"].Add("Provider");
protoArray["15"]["m_columns"].Add("Comment");
obj = new SQLTable(protoArray["15"]);

protoArray["14"]["m_table"] = obj;
protoArray["14"]["m_sql"] = "dbo.spectrum_betauggroups";
protoArray["14"]["m_alias"] = "";
protoArray["14"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
protoArray["16"] = SettingsMap.GetArray();
protoArray["16"]["m_sql"] = "";
protoArray["16"]["m_uniontype"] = "SQLL_UNKNOWN";
obj = new SQLNonParsed(new XVar("m_sql", ""));

protoArray["16"]["m_column"] = obj;
protoArray["16"]["m_contained"] = SettingsMap.GetArray();
protoArray["16"]["m_strCase"] = "";
protoArray["16"]["m_havingmode"] = false;
protoArray["16"]["m_inBrackets"] = false;
protoArray["16"]["m_useAlias"] = false;
obj = new SQLLogicalExpr(protoArray["16"]);

protoArray["14"]["m_joinon"] = obj;
obj = new SQLFromListItem(protoArray["14"]);

protoArray["0"]["m_fromlist"].Add(obj);
protoArray["0"]["m_groupby"] = SettingsMap.GetArray();
protoArray["0"]["m_orderby"] = SettingsMap.GetArray();
protoArray["0"]["m_srcTableName"] = "dbo.spectrum_betauggroups";
obj = new SQLQuery(protoArray["0"]);

queryData_Array["spectrum_betauggroups"] = obj;

				
		
			tdataArray["spectrum_betauggroups"][".sqlquery"] = queryData_Array["spectrum_betauggroups"];
			tdataArray["spectrum_betauggroups"][".hasEvents"] = false;
		}
	}

}
