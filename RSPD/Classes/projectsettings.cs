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
	public partial class ProjectSettings : XClass
	{
		public dynamic _table;
		public dynamic _pageMode;
		public dynamic _pageType;
		public dynamic _page;
		public dynamic _viewPage = XVar.Pack(Constants.PAGE_VIEW);
		public dynamic _defaultViewPage = XVar.Pack(Constants.PAGE_VIEW);
		public dynamic _editPage = XVar.Pack(Constants.PAGE_EDIT);
		public dynamic _defaultEditPage = XVar.Pack(Constants.PAGE_EDIT);
		public dynamic _tableData = XVar.Array();
		public dynamic _optionsFile = XVar.Array();
		public dynamic _auxTable = XVar.Pack("");
		public dynamic _auxTableData = XVar.Array();
		public dynamic _pageOptions = XVar.Array();
		public dynamic _mastersTableData = XVar.Array();
		public dynamic _detailsTableData = XVar.Array();
		public dynamic _dashboardElemPSet = XVar.Array();
		public ProjectSettings(dynamic _param_table = null, dynamic _param_pageType = null, dynamic _param_page = null, dynamic _param_pageTable = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			if(_param_pageType as Object == null) _param_pageType = new XVar("");
			if(_param_page as Object == null) _param_page = new XVar("");
			if(_param_pageTable as Object == null) _param_pageTable = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic pageType = XVar.Clone(_param_pageType);
			dynamic page = XVar.Clone(_param_page);
			dynamic pageTable = XVar.Clone(_param_pageTable);
			#endregion

			dynamic mobileSub = null;
			if(XVar.Pack(!(XVar)(table)))
			{
				table = new XVar(Constants.GLOBAL_PAGES);
			}
			if(XVar.Pack(!(XVar)(pageTable)))
			{
				pageTable = XVar.Clone(table);
			}
			this.setTable((XVar)(table));
			if(table == pageTable)
			{
				this._auxTableData = this._tableData;
				this._auxTable = XVar.Clone(this._table);
			}
			else
			{
				this.loadAuxTable((XVar)(pageTable));
			}
			if(XVar.Pack(page))
			{
				this._pageType = XVar.Clone(this.getOriginalPageType((XVar)(page)));
			}
			if((XVar)(page)  && (XVar)(this.getPageIds().KeyExists(page)))
			{
				this.setPage((XVar)(page));
				this.setPageType((XVar)(this.getPageType()));
			}
			else
			{
				if(XVar.Pack(!(XVar)(pageType)))
				{
					pageType = XVar.Clone(this.getDefaultPageType());
				}
				if(XVar.Pack(pageType))
				{
					this._pageType = XVar.Clone(pageType);
					page = XVar.Clone(this.getDefaultPage((XVar)(pageType)));
					if(XVar.Pack(page))
					{
						this.setPage((XVar)(page));
					}
				}
			}
			if((XVar)(page)  && (XVar)(!(XVar)(pageType)))
			{
				pageType = XVar.Clone(this.getPageType());
			}
			if(XVar.Pack(pageType))
			{
				this.setPageType((XVar)(pageType));
			}
			mobileSub = XVar.Clone(this.getMobileSub());
			if((XVar)(GlobalVars.mediaType)  && (XVar)(mobileSub))
			{
				if(XVar.Pack(this.getPageIds().KeyExists(mobileSub)))
				{
					this.setPage((XVar)(mobileSub));
				}
			}
		}
		public virtual XVar getDefaultPageType()
		{
			dynamic pageTypes = XVar.Array();
			pageTypes = XVar.Clone(XVar.Array());
			pageTypes.InitAndSetArrayItem("list", Constants.titTABLE);
			pageTypes.InitAndSetArrayItem("list", Constants.titVIEW);
			pageTypes.InitAndSetArrayItem("report", Constants.titREPORT);
			pageTypes.InitAndSetArrayItem("chart", Constants.titCHART);
			pageTypes.InitAndSetArrayItem("dashboard", Constants.titDASHBOARD);
			pageTypes.InitAndSetArrayItem("list", Constants.titSQL);
			pageTypes.InitAndSetArrayItem("list", Constants.titREST);
			pageTypes.InitAndSetArrayItem("report", Constants.titSQL_REPORT);
			pageTypes.InitAndSetArrayItem("chart", Constants.titSQL_CHART);
			pageTypes.InitAndSetArrayItem("report", Constants.titREST_REPORT);
			pageTypes.InitAndSetArrayItem("chart", Constants.titREST_CHART);
			return pageTypes[this.getEntityType()];
		}
		public virtual XVar table()
		{
			return this._table;
		}
		public virtual XVar loadPageOptions(dynamic _param_option = null)
		{
			#region default values
			if(_param_option as Object == null) _param_option = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic var_option = XVar.Clone(_param_option);
			#endregion

			if(XVar.Pack(this._pageOptions))
			{
				return null;
			}
			MVCFunctions.importPageOptions((XVar)(this._auxTable), (XVar)(this._page));
			this._pageOptions = GlobalVars.page_options[this._auxTable][this._page];
			return null;
		}
		public virtual XVar setPage(dynamic _param_page)
		{
			#region pass-by-value parameters
			dynamic page = XVar.Clone(_param_page);
			#endregion

			if(page != this._page)
			{
				dynamic dummy = null;
				dummy = new XVar(null);
				this._pageOptions = dummy;
			}
			this._page = XVar.Clone(page);
			if(XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(page), (XVar)(this.getPageIds()))), XVar.Pack(false)))
			{
				return null;
			}
			this._optionsFile = XVar.Clone(MVCFunctions.getabspath((XVar)(MVCFunctions.Concat("include/pages/", CommonFunctions.GetTableURL((XVar)(this._auxTable)), "_", page, ".json"))));
			return null;
		}
		public virtual XVar setTable(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic tableType = null;
			this._table = XVar.Clone(table);
			if(CommonFunctions.GetTableURL((XVar)(table)) != "")
			{
				MVCFunctions.importTableSettings((XVar)(table));
			}
			if(XVar.Pack(GlobalVars.tables_data.KeyExists(this._table)))
			{
				this._tableData = GlobalVars.tables_data[this._table];
			}
			this._mastersTableData = GlobalVars.masterTablesData[this._table];
			this._detailsTableData = GlobalVars.detailsTablesData[this._table];
			tableType = XVar.Clone(this.getTableType());
			this._editPage = XVar.Clone(this.getDefaultEditPageType((XVar)(tableType)));
			this._viewPage = XVar.Clone(this.getDefaultViewPageType((XVar)(tableType)));
			this._defaultEditPage = XVar.Clone(this._editPage);
			this._defaultViewPage = XVar.Clone(this._viewPage);
			return null;
		}
		public virtual XVar loadAuxTable(dynamic _param_auxTable)
		{
			#region pass-by-value parameters
			dynamic auxTable = XVar.Clone(_param_auxTable);
			#endregion

			this._auxTable = XVar.Clone(auxTable);
			if(CommonFunctions.GetTableURL((XVar)(auxTable)) != "")
			{
				MVCFunctions.importTableSettings((XVar)(auxTable));
			}
			if(XVar.Pack(GlobalVars.tables_data.KeyExists(this._auxTable)))
			{
				this._auxTableData = GlobalVars.tables_data[this._auxTable];
			}
			return null;
		}
		public virtual XVar pageName()
		{
			return this._page;
		}
		public virtual XVar pageType()
		{
			return this._pageType;
		}
		public virtual XVar pageTable()
		{
			return this._auxTable;
		}
		public virtual XVar getDefaultViewPageType(dynamic _param_tableType)
		{
			#region pass-by-value parameters
			dynamic tableType = XVar.Clone(_param_tableType);
			#endregion

			if((XVar)(tableType == Constants.PAGE_CHART)  || (XVar)(tableType == Constants.PAGE_REPORT))
			{
				return tableType;
			}
			return Constants.PAGE_VIEW;
		}
		public virtual XVar getDefaultEditPageType(dynamic _param_tableType)
		{
			#region pass-by-value parameters
			dynamic tableType = XVar.Clone(_param_tableType);
			#endregion

			if((XVar)(tableType == Constants.PAGE_CHART)  || (XVar)(tableType == Constants.PAGE_REPORT))
			{
				return Constants.PAGE_SEARCH;
			}
			return Constants.PAGE_EDIT;
		}
		public virtual XVar setPageType(dynamic _param_page)
		{
			#region pass-by-value parameters
			dynamic page = XVar.Clone(_param_page);
			#endregion

			if(XVar.Pack(this.isPageTypeForView((XVar)(page))))
			{
				dynamic tableType = null;
				tableType = XVar.Clone(this.getTableType());
				if((XVar)((XVar)(tableType != "report")  && (XVar)(tableType != "chart"))  && (XVar)((XVar)(page == Constants.PAGE_CHART)  || (XVar)(page == Constants.PAGE_REPORT)))
				{
					this._viewPage = new XVar(Constants.PAGE_LIST);
				}
				else
				{
					this._viewPage = XVar.Clone(page);
				}
				this._defaultViewPage = XVar.Clone(this.getDefaultViewPageType((XVar)(tableType)));
			}
			if(XVar.Pack(this.isPageTypeForEdit((XVar)(page))))
			{
				this._editPage = XVar.Clone(page);
				this._defaultEditPage = XVar.Clone(this.getDefaultEditPageType((XVar)(this.getTableType())));
			}
			return null;
		}
		public virtual XVar getDefaultPages()
		{
			this.updatePages();
			return this.getAuxTableData(new XVar(".defaultPages"));
		}
		public virtual XVar getDefaultPage(dynamic _param_type, dynamic _param_pageTable = null)
		{
			#region default values
			if(_param_pageTable as Object == null) _param_pageTable = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic var_type = XVar.Clone(_param_type);
			dynamic pageTable = XVar.Clone(_param_pageTable);
			#endregion

			dynamic defPage = null, defPages = XVar.Array();
			this.updatePages();
			if(XVar.Pack(CommonFunctions.isAdminPage((XVar)(this._auxTable))))
			{
				return this._pageType;
			}
			defPages = this.getAuxTableData(new XVar(".defaultPages"));
			defPage = XVar.Clone(defPages[var_type]);
			if(XVar.Pack(defPage))
			{
				return defPage;
			}
			return null;
		}
		public virtual XVar getPageIds()
		{
			dynamic ret = null;
			this.updatePages();
			ret = XVar.Clone(this.getAuxTableData(new XVar(".pages")));
			if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(ret)))))
			{
				return XVar.Array();
			}
			return ret;
		}
		public virtual XVar getEditPageType()
		{
			return this._editPage;
		}
		public virtual XVar isPageTypeForView(dynamic _param_ptype)
		{
			#region pass-by-value parameters
			dynamic ptype = XVar.Clone(_param_ptype);
			#endregion

			return MVCFunctions.in_array((XVar)(MVCFunctions.strtolower((XVar)(ptype))), (XVar)(GlobalVars.pageTypesForView));
		}
		public virtual XVar isPageTypeForEdit(dynamic _param_ptype)
		{
			#region pass-by-value parameters
			dynamic ptype = XVar.Clone(_param_ptype);
			#endregion

			return MVCFunctions.in_array((XVar)(MVCFunctions.strtolower((XVar)(ptype))), (XVar)(GlobalVars.pageTypesForEdit));
		}
		public virtual XVar getTable(dynamic _param_table, dynamic _param_page = null)
		{
			#region default values
			if(_param_page as Object == null) _param_page = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			dynamic page = XVar.Clone(_param_page);
			#endregion

			return new ProjectSettings((XVar)(table), (XVar)(page));
		}
		public virtual XVar getPageTypeByFieldEditFormat(dynamic _param_field, dynamic _param_editFormat)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic editFormat = XVar.Clone(_param_editFormat);
			#endregion

			if((XVar)(this._tableData.KeyExists(field))  && (XVar)(this._tableData[field].KeyExists(Constants.FORMAT_EDIT)))
			{
				foreach (KeyValuePair<XVar, dynamic> editSettings in this._tableData[field][Constants.FORMAT_EDIT].GetEnumerator())
				{
					if((XVar)(editSettings.Value.KeyExists("EditFormat"))  && (XVar)(editSettings.Value["EditFormat"] == editFormat))
					{
						return editSettings.Key;
					}
				}
			}
			return "";
		}
		public virtual XVar getTableData(dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(!(XVar)(this.isExistsTableKey((XVar)(key)))))
			{
				return this.getDefaultValueByKey((XVar)(MVCFunctions.substr((XVar)(key), new XVar(1))));
			}
			return this._tableData[key];
		}
		public virtual XVar getAuxTableData(dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(!(XVar)(this.isExistsAuxTableKey((XVar)(key)))))
			{
				return this.getDefaultValueByKey((XVar)(MVCFunctions.substr((XVar)(key), new XVar(1))));
			}
			return this._auxTableData[key];
		}
		public virtual XVar getPageOption(dynamic _param_key1, dynamic _param_key2 = null, dynamic _param_key3 = null, dynamic _param_key4 = null, dynamic _param_key5 = null)
		{
			#region default values
			if(_param_key2 as Object == null) _param_key2 = new XVar(false);
			if(_param_key3 as Object == null) _param_key3 = new XVar(false);
			if(_param_key4 as Object == null) _param_key4 = new XVar(false);
			if(_param_key5 as Object == null) _param_key5 = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic key1 = XVar.Clone(_param_key1);
			dynamic key2 = XVar.Clone(_param_key2);
			dynamic key3 = XVar.Clone(_param_key3);
			dynamic key4 = XVar.Clone(_param_key4);
			dynamic key5 = XVar.Clone(_param_key5);
			#endregion

			dynamic keys = XVar.Array(), opt = XVar.Array();
			this.loadPageOptions((XVar)(MVCFunctions.Concat(key1, key2)));
			if(XVar.Pack(!(XVar)(this._pageOptions.KeyExists(key1))))
			{
				return false;
			}
			keys = XVar.Clone(new XVar(0, key1));
			if(!XVar.Equals(XVar.Pack(key2), XVar.Pack(false)))
			{
				keys.InitAndSetArrayItem(key2, null);
			}
			if(!XVar.Equals(XVar.Pack(key3), XVar.Pack(false)))
			{
				keys.InitAndSetArrayItem(key3, null);
			}
			if(!XVar.Equals(XVar.Pack(key4), XVar.Pack(false)))
			{
				keys.InitAndSetArrayItem(key4, null);
			}
			if(!XVar.Equals(XVar.Pack(key5), XVar.Pack(false)))
			{
				keys.InitAndSetArrayItem(key5, null);
			}
			opt = this._pageOptions;
			foreach (KeyValuePair<XVar, dynamic> k in keys.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(opt)))))
				{
					return false;
				}
				if(XVar.Pack(!(XVar)(opt.KeyExists(k.Value))))
				{
					return false;
				}
				opt = opt[k.Value];
			}
			return opt;
		}
		public virtual XVar getPageOptionAsArray(dynamic _param_key1, dynamic _param_key2 = null, dynamic _param_key3 = null, dynamic _param_key4 = null, dynamic _param_key5 = null)
		{
			#region default values
			if(_param_key2 as Object == null) _param_key2 = new XVar(false);
			if(_param_key3 as Object == null) _param_key3 = new XVar(false);
			if(_param_key4 as Object == null) _param_key4 = new XVar(false);
			if(_param_key5 as Object == null) _param_key5 = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic key1 = XVar.Clone(_param_key1);
			dynamic key2 = XVar.Clone(_param_key2);
			dynamic key3 = XVar.Clone(_param_key3);
			dynamic key4 = XVar.Clone(_param_key4);
			dynamic key5 = XVar.Clone(_param_key5);
			#endregion

			dynamic ret = null;
			ret = this.getPageOption((XVar)(key1), (XVar)(key2), (XVar)(key3), (XVar)(key4), (XVar)(key5));
			if((XVar)(!(XVar)(ret))  || (XVar)(!(XVar)(MVCFunctions.is_array((XVar)(ret)))))
			{
				return XVar.Array();
			}
			return ret;
		}
		public virtual XVar getPageOptionArray(dynamic _param_keys)
		{
			#region pass-by-value parameters
			dynamic keys = XVar.Clone(_param_keys);
			#endregion

			dynamic opt = XVar.Array();
			this.loadPageOptions();
			opt = this._pageOptions;
			foreach (KeyValuePair<XVar, dynamic> k in keys.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(opt)))))
				{
					return false;
				}
				if(XVar.Pack(!(XVar)(opt.KeyExists(k.Value))))
				{
					return false;
				}
				opt = opt[k.Value];
			}
			return opt;
		}
		private XVar getEffectiveEditPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(this.isSeparate((XVar)(field))))
			{
				return this._editPage;
			}
			return this._defaultEditPage;
		}
		private XVar getEffectiveViewPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(this.isSeparate((XVar)(field))))
			{
				if((XVar)(this._pageMode == Constants.EDIT_INLINE)  && (XVar)(this._viewPage != Constants.PAGE_VIEW))
				{
					return Constants.PAGE_LIST;
				}
				else
				{
					if((XVar)(this._pageMode == Constants.LIST_MASTER)  && (XVar)(this._viewPage == Constants.PAGE_LIST))
					{
						return Constants.PAGE_MASTER_INFO_LIST;
					}
					else
					{
						if((XVar)(this._pageMode == Constants.LIST_MASTER)  && (XVar)(this._viewPage == Constants.PAGE_REPORT))
						{
							return Constants.PAGE_MASTER_INFO_REPORT;
						}
						else
						{
							if((XVar)(this._pageMode == Constants.PRINT_MASTER)  && (XVar)(this._viewPage == Constants.PAGE_RPRINT))
							{
								return Constants.PAGE_MASTER_INFO_RPRINT;
							}
							else
							{
								if(this._pageMode == Constants.PRINT_MASTER)
								{
									return Constants.PAGE_MASTER_INFO_PRINT;
								}
							}
						}
					}
				}
				return this._viewPage;
			}
			return this._defaultViewPage;
		}
		public virtual XVar getFieldData(dynamic _param_field, dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic key = XVar.Clone(_param_key);
			#endregion

			dynamic editPage = null, settingType = null, viewPage = null;
			if(this.getEntityType() == Constants.titDASHBOARD)
			{
				return this.getDashFieldData((XVar)(field), (XVar)(key));
			}
			if(XVar.Pack(!(XVar)(this._tableData.KeyExists(field))))
			{
				return this.getDefaultValueByKey((XVar)(key));
			}
			settingType = XVar.Clone(GlobalVars.g_settingsType[key]);
			if(settingType == null)
			{
				settingType = new XVar("");
			}
			switch(((XVar)settingType).ToString())
			{
				case Constants.SETTING_TYPE_VIEW:
					viewPage = XVar.Clone(this.getEffectiveViewPage((XVar)(field)));
					if(XVar.Pack(this._tableData[field][Constants.FORMAT_VIEW][viewPage].KeyExists(key)))
					{
						return this._tableData[field][Constants.FORMAT_VIEW][viewPage][key];
					}
					break;
				case Constants.SETTING_TYPE_EDIT:
					editPage = XVar.Clone(this.getEffectiveEditPage((XVar)(field)));
					if(XVar.Pack(this._tableData[field][Constants.FORMAT_EDIT][editPage].KeyExists(key)))
					{
						return this._tableData[field][Constants.FORMAT_EDIT][editPage][key];
					}
					break;
				default:
					if(XVar.Pack(this._tableData[field].KeyExists(key)))
					{
						return this._tableData[field][key];
					}
					break;
			}
			return this.getDefaultValueByKey((XVar)(key));
		}
		public virtual XVar setFieldData(dynamic _param_field, dynamic _param_key, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic key = XVar.Clone(_param_key);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			dynamic editPage = null, oldValue = null, settingType = null, viewPage = null;
			oldValue = XVar.Clone(this.getFieldData((XVar)(field), (XVar)(key)));
			settingType = XVar.Clone(GlobalVars.g_settingsType[key]);
			if(settingType == null)
			{
				settingType = new XVar("");
			}
			switch(((XVar)settingType).ToString())
			{
				case Constants.SETTING_TYPE_VIEW:
					viewPage = XVar.Clone(this.getEffectiveViewPage((XVar)(field)));
					this._tableData.InitAndSetArrayItem(value, field, Constants.FORMAT_VIEW, viewPage, key);
					break;
				case Constants.SETTING_TYPE_EDIT:
					editPage = XVar.Clone(this.getEffectiveEditPage((XVar)(field)));
					this._tableData.InitAndSetArrayItem(value, field, Constants.FORMAT_EDIT, editPage, key);
					break;
				default:
					this._tableData.InitAndSetArrayItem(value, field, key);
					break;
			}
			return oldValue;
		}
		public virtual XVar getTableName()
		{
			return this._table;
		}
		public virtual XVar findField(dynamic _param_f)
		{
			#region pass-by-value parameters
			dynamic f = XVar.Clone(_param_f);
			#endregion

			dynamic fields = XVar.Array(), gTable = null;
			fields = XVar.Clone(this.getFieldsList());
			if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(f), (XVar)(fields))), XVar.Pack(false)))
			{
				return f;
			}
			gTable = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(this._table)));
			if(XVar.Pack(GlobalVars.field_labels[GlobalVars.mlang_defaultlang].KeyExists(f)))
			{
				return this.getFieldByGoodFieldName((XVar)(f));
			}
			f = XVar.Clone(MVCFunctions.strtoupper((XVar)(f)));
			foreach (KeyValuePair<XVar, dynamic> ff in fields.GetEnumerator())
			{
				if(MVCFunctions.strtoupper((XVar)(ff.Value)) == f)
				{
					return ff.Value;
				}
				if(MVCFunctions.strtoupper((XVar)(MVCFunctions.GoodFieldName((XVar)(ff.Value)))) == f)
				{
					return ff.Value;
				}
			}
			return "";
		}
		public virtual XVar addCustomExpressionIndex(dynamic _param_mainTable, dynamic _param_mainField, dynamic _param_index)
		{
			#region pass-by-value parameters
			dynamic mainTable = XVar.Clone(_param_mainTable);
			dynamic mainField = XVar.Clone(_param_mainField);
			dynamic index = XVar.Clone(_param_index);
			#endregion

			if(XVar.Pack(!(XVar)(this.isExistsTableKey(new XVar(".customExpressionIndexes")))))
			{
				this._tableData.InitAndSetArrayItem(XVar.Array(), ".customExpressionIndexes");
			}
			if(XVar.Pack(!(XVar)(this._tableData[".customExpressionIndexes"].KeyExists(mainTable))))
			{
				this._tableData.InitAndSetArrayItem(XVar.Array(), ".customExpressionIndexes", mainTable);
			}
			this._tableData.InitAndSetArrayItem(index, ".customExpressionIndexes", mainTable, mainField);
			return null;
		}
		public virtual XVar getCustomExpressionIndex(dynamic _param_mainTable, dynamic _param_mainField)
		{
			#region pass-by-value parameters
			dynamic mainTable = XVar.Clone(_param_mainTable);
			dynamic mainField = XVar.Clone(_param_mainField);
			#endregion

			if(XVar.Pack(!(XVar)(this.isExistsTableKey(new XVar(".customExpressionIndexes")))))
			{
				this._tableData.InitAndSetArrayItem(XVar.Array(), ".customExpressionIndexes");
			}
			if((XVar)(this._tableData[".customExpressionIndexes"].KeyExists(mainTable))  && (XVar)(this._tableData[".customExpressionIndexes"][mainTable].KeyExists(mainField)))
			{
				return this._tableData[".customExpressionIndexes"][mainTable][mainField];
			}
			return false;
		}
		public virtual XVar isExistsTableKey(dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(!(XVar)(this._tableData.KeyExists(key))))
			{
				return false;
			}
			return true;
		}
		public virtual XVar isExistsAuxTableKey(dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(!(XVar)(this._auxTableData.KeyExists(key))))
			{
				return false;
			}
			return true;
		}
		public virtual XVar isExistsFieldKey(dynamic _param_field, dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(!(XVar)(this.isExistsTableKey((XVar)(field)))))
			{
				return false;
			}
			if(XVar.Pack(!(XVar)(this._tableData[field].KeyExists(key))))
			{
				return false;
			}
			return true;
		}
		public virtual XVar getDefaultValueByKey(dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic key = XVar.Clone(_param_key);
			#endregion

			if(XVar.Pack(GlobalVars.g_defaultOptionValues.KeyExists(key)))
			{
				return GlobalVars.g_defaultOptionValues[key];
			}
			return false;
		}
		public virtual XVar getMasterTablesArr()
		{
			return this._mastersTableData;
		}
		public virtual XVar getMasterKeysByDetailTable(dynamic _param_dTableName, dynamic _param_default = null)
		{
			#region default values
			if(_param_default as Object == null) _param_default = new XVar(XVar.Array());
			#endregion

			#region pass-by-value parameters
			dynamic dTableName = XVar.Clone(_param_dTableName);
			dynamic var_default = XVar.Clone(_param_default);
			#endregion

			if(XVar.Pack(!(XVar)(dTableName)))
			{
				return var_default;
			}
			foreach (KeyValuePair<XVar, dynamic> dTableDataArr in this._detailsTableData.GetEnumerator())
			{
				if(dTableDataArr.Value["dDataSourceTable"] == dTableName)
				{
					return dTableDataArr.Value["masterKeys"];
				}
			}
			return var_default;
		}
		public virtual XVar getDetailTablesArr()
		{
			if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(this._detailsTableData)))))
			{
				return XVar.Array();
			}
			return this._detailsTableData;
		}
		public virtual XVar getDetailKeysByMasterTable(dynamic _param_mTableName = null, dynamic _param_default = null)
		{
			#region default values
			if(_param_mTableName as Object == null) _param_mTableName = new XVar("");
			if(_param_default as Object == null) _param_default = new XVar(XVar.Array());
			#endregion

			#region pass-by-value parameters
			dynamic mTableName = XVar.Clone(_param_mTableName);
			dynamic var_default = XVar.Clone(_param_default);
			#endregion

			if(XVar.Pack(!(XVar)(mTableName)))
			{
				return var_default;
			}
			foreach (KeyValuePair<XVar, dynamic> mTableDataArr in this._mastersTableData.GetEnumerator())
			{
				if(mTableDataArr.Value["mDataSourceTable"] == mTableName)
				{
					return mTableDataArr.Value["detailKeys"];
				}
			}
			return var_default;
		}
		public virtual XVar getDetailKeysByDetailTable(dynamic _param_dTableName, dynamic _param_default = null)
		{
			#region default values
			if(_param_default as Object == null) _param_default = new XVar(XVar.Array());
			#endregion

			#region pass-by-value parameters
			dynamic dTableName = XVar.Clone(_param_dTableName);
			dynamic var_default = XVar.Clone(_param_default);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> dTableDataArr in this._detailsTableData.GetEnumerator())
			{
				if(dTableDataArr.Value["dDataSourceTable"] == dTableName)
				{
					return dTableDataArr.Value["detailKeys"];
				}
			}
			return var_default;
		}
		public virtual XVar getDPType(dynamic _param_dTableName)
		{
			#region pass-by-value parameters
			dynamic dTableName = XVar.Clone(_param_dTableName);
			#endregion

			if(XVar.Pack(!(XVar)(dTableName)))
			{
				return false;
			}
			foreach (KeyValuePair<XVar, dynamic> dTableDataArr in this._detailsTableData.GetEnumerator())
			{
				if(dTableDataArr.Value["dDataSourceTable"] == dTableName)
				{
					return dTableDataArr.Value["previewOnList"];
				}
			}
			return false;
		}
		public virtual XVar GetFieldByIndex(dynamic _param_index)
		{
			#region pass-by-value parameters
			dynamic index = XVar.Clone(_param_index);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> value in this._tableData.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(value.Value)))))
				{
					continue;
				}
				else
				{
					if(XVar.Pack(!(XVar)(value.Value.KeyExists("Index"))))
					{
						continue;
					}
				}
				if((XVar)(value.Value["Index"] == index)  && (XVar)(this.getFieldIndex((XVar)(value.Key))))
				{
					return value.Key;
				}
			}
			return null;
		}
		public virtual XVar isSeparate(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return !(XVar)(!(XVar)(this._tableData[field]["isSeparate"]));
		}
		public virtual XVar label(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic result = null;
			result = XVar.Clone(CommonFunctions.GetFieldLabel((XVar)(MVCFunctions.GoodFieldName((XVar)(this._table))), (XVar)(MVCFunctions.GoodFieldName((XVar)(field)))));
			return (XVar.Pack(result != XVar.Pack("")) ? XVar.Pack(result) : XVar.Pack(field));
		}
		public virtual XVar getFilenameField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("Filename"));
		}
		public virtual XVar getLinkPrefix(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LinkPrefix"));
		}
		public virtual XVar getLinkType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("hlType"));
		}
		public virtual XVar getLinkDisplayField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("hlTitleField"));
		}
		public virtual XVar openLinkInNewWindow(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("hlNewWindow"));
		}
		public virtual XVar getLinkWordNameType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("hlLinkWordNameType"));
		}
		public virtual XVar getLinkWordText(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("hlLinkWordText"));
		}
		public virtual XVar getFieldType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("FieldType"));
		}
		public virtual XVar isAutoincField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("AutoInc"));
		}
		public virtual XVar getDefaultValue(dynamic _param_field, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic editPage = null, tableName = null;
			tableName = XVar.Clone((XVar.Pack(table) ? XVar.Pack(table) : XVar.Pack(this._table)));
			editPage = XVar.Clone(this._editPage);
			if(XVar.Pack(!(XVar)(this.isSeparate((XVar)(field)))))
			{
				return null;
			}
			return MVCFunctions.GetDefaultValue((XVar)(field), (XVar)(editPage), (XVar)(tableName));
		}
		public virtual XVar isAutoUpdatable(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("autoUpdatable"));
		}
		public virtual XVar getAutoUpdateValue(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic editPage = null;
			editPage = XVar.Clone(this._editPage);
			if(XVar.Pack(!(XVar)(this.isSeparate((XVar)(field)))))
			{
				editPage = XVar.Clone(this.getDefaultEditPageType((XVar)(this.getTableType())));
			}
			return MVCFunctions.GetAutoUpdateValue((XVar)(field), (XVar)(editPage), (XVar)(this._table));
		}
		public virtual XVar getEditFormat(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("EditFormat"));
		}
		public virtual XVar getViewFormat(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ViewFormat"));
		}
		public virtual XVar dateEditShowTime(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowTime"));
		}
		public virtual XVar lookupControlType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LCType"));
		}
		public virtual XVar lookupListPageId(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("listPageId"));
		}
		public virtual XVar lookupAddPageId(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("addPageId"));
		}
		public virtual XVar isDeleteAssociatedFile(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("DeleteAssociatedFile"));
		}
		public virtual XVar useCategory(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("UseCategory"));
		}
		public virtual XVar multiSelect(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("Multiselect"));
		}
		public virtual XVar getOAuthCloudFields()
		{
			dynamic fields = XVar.Array();
			if((XVar)((XVar)(!(XVar)(CommonFunctions.GetGlobalData(new XVar("GoogleDriveClientID"))))  && (XVar)(!(XVar)(CommonFunctions.GetGlobalData(new XVar("OneDriveClientID")))))  && (XVar)(!(XVar)(CommonFunctions.GetGlobalData(new XVar("DropboxClientID")))))
			{
				return XVar.Array();
			}
			fields = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> field in this.getFieldsList().GetEnumerator())
			{
				dynamic stp = null;
				stp = XVar.Clone(this.fileStorageProvider((XVar)(field.Value)));
				if((XVar)((XVar)(XVar.Equals(XVar.Pack(stp), XVar.Pack(Constants.stpGOOGLEDRIVE)))  || (XVar)(XVar.Equals(XVar.Pack(stp), XVar.Pack(Constants.stpDROPBOX))))  || (XVar)(XVar.Equals(XVar.Pack(stp), XVar.Pack(Constants.stpONEDRIVE))))
				{
					fields.InitAndSetArrayItem(field.Value, null);
				}
			}
			return fields;
		}
		public virtual XVar singleSelectLookupEdit(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic hasLookup = null;
			hasLookup = new XVar(false);
			foreach (KeyValuePair<XVar, dynamic> editFormat in this._tableData[field][Constants.FORMAT_EDIT].GetEnumerator())
			{
				if((XVar)(editFormat.Key != "edit")  && (XVar)(editFormat.Key != "add"))
				{
					continue;
				}
				if(editFormat.Value["EditFormat"] != Constants.EDIT_FORMAT_LOOKUP_WIZARD)
				{
					continue;
				}
				hasLookup = new XVar(true);
				if(XVar.Pack(editFormat.Value["Multiselect"]))
				{
					return false;
				}
			}
			return hasLookup;
		}
		public virtual XVar multiSelectLookupEdit(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> editFormat in this._tableData[field][Constants.FORMAT_EDIT].GetEnumerator())
			{
				if((XVar)(editFormat.Key != "edit")  && (XVar)(editFormat.Key != "add"))
				{
					continue;
				}
				if(editFormat.Value["EditFormat"] != Constants.EDIT_FORMAT_LOOKUP_WIZARD)
				{
					continue;
				}
				if(XVar.Pack(editFormat.Value["Multiselect"]))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar lookupField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> editFormat in this._tableData[field][Constants.FORMAT_EDIT].GetEnumerator())
			{
				if(editFormat.Value["EditFormat"] != Constants.EDIT_FORMAT_LOOKUP_WIZARD)
				{
					continue;
				}
				if(editFormat.Value["LinkField"] != editFormat.Value["DisplayField"])
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar selectSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("SelectSize"));
		}
		public virtual XVar showThumbnail(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowThumbnail"));
		}
		public virtual XVar isImageURL(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("fieldIsImageUrl"));
		}
		public virtual XVar showCustomExpr(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowCustomExpr"));
		}
		public virtual XVar showFileSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowFileSize"));
		}
		public virtual XVar displayPDF(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("DisplayPDF"));
		}
		public virtual XVar showIcon(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowIcon"));
		}
		public virtual XVar getImageWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ImageWidth"));
		}
		public virtual XVar getImageHeight(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ImageHeight"));
		}
		public virtual XVar getThumbnailWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ThumbWidth"));
		}
		public virtual XVar getThumbnailHeight(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ThumbHeight"));
		}
		public virtual XVar getLookupType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupType"));
		}
		public virtual XVar getLookupTable(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupTable"));
		}
		public virtual XVar isLookupWhereCode(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupWhereCode"));
		}
		public virtual XVar isLookupWhereSet(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(this.isLookupWhereCode((XVar)(field))))
			{
				return true;
			}
			return 0 != MVCFunctions.strlen((XVar)(this.getFieldData((XVar)(field), new XVar("LookupWhere"))));
		}
		public virtual XVar getLookupWhere(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(this.isLookupWhereCode((XVar)(field))))
			{
				dynamic tName = null;
				tName = XVar.Clone(this._table);
				if(this.getEntityType() == Constants.titDASHBOARD)
				{
					dynamic dashSearchFields = XVar.Array();
					dashSearchFields = XVar.Clone(this.getDashboardSearchFields());
					if(XVar.Pack(dashSearchFields.KeyExists(field)))
					{
						tName = XVar.Clone(dashSearchFields[field][0]["table"]);
						field = XVar.Clone(dashSearchFields[field][0]["field"]);
					}
				}
				return MVCFunctions.GetLWWhere((XVar)(field), (XVar)(this.getEffectiveEditPage((XVar)(field))), (XVar)(tName));
			}
			return this.getFieldData((XVar)(field), new XVar("LookupWhere"));
		}
		public virtual XVar getNotProjectLookupTableConnId(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupConnId"));
		}
		public virtual XVar getConnId()
		{
			dynamic connId = null;
			connId = XVar.Clone(this.getTableData(new XVar(".connId")));
			if(connId == XVar.Pack(""))
			{
				return "RSPDDB_at_172_16_0_80";
			}
			return connId;
		}
		public virtual XVar getLinkField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LinkField"));
		}
		public virtual XVar getLWLinkFieldType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LinkFieldType"));
		}
		public virtual XVar getDisplayField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("DisplayField"));
		}
		public virtual XVar getCustomDisplay(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("CustomDisplay"));
		}
		public virtual XVar NeedEncode(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("NeedEncode"));
		}
		public virtual XVar getValidation(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("validateAs"));
		}
		public virtual XVar getFieldItems(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getPageOption(new XVar("fields"), new XVar("fieldItems"), (XVar)(field));
		}
		public virtual XVar getGroupFields()
		{
			return this.getPageOption(new XVar("dataGrid"), new XVar("groupFields"));
		}
		public virtual XVar appearOnListPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(this.getPageOption(new XVar("fields"), new XVar("gridFields"))))), XVar.Pack(false)))
			{
				return true;
			}
			if(XVar.Pack(CommonFunctions.isReport((XVar)(this.getEntityType()))))
			{
				return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(this.getReportGroupFields()))), XVar.Pack(false));
			}
			return false;
		}
		public virtual XVar appearOnAddPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnPage((XVar)(field));
		}
		public virtual XVar appearOnInlineAdd(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic fields = null;
			fields = this.getInlineAddFields();
			if(XVar.Pack(!(XVar)(fields)))
			{
				return false;
			}
			return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(fields))), XVar.Pack(false));
		}
		public virtual XVar appearOnEditPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnPage((XVar)(field));
		}
		public virtual XVar appearOnInlineEdit(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic inlineFields = null;
			inlineFields = this.getInlineEditFields();
			if(XVar.Pack(!(XVar)(inlineFields)))
			{
				return false;
			}
			return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(inlineFields))), XVar.Pack(false));
		}
		public virtual XVar appearOnUpdateSelected(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic updateOnEditFields = null;
			updateOnEditFields = XVar.Clone(this.getPageOption(new XVar("fields"), new XVar("updateOnEditFields")));
			if(XVar.Pack(!(XVar)(updateOnEditFields)))
			{
				return false;
			}
			return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(this.getPageOption(new XVar("fields"), new XVar("updateOnEditFields"))))), XVar.Pack(false));
		}
		public virtual XVar appearOnPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic gridFields = null, ret = null;
			gridFields = this.getPageOption(new XVar("fields"), new XVar("gridFields"));
			if(XVar.Pack(!(XVar)(gridFields)))
			{
				ret = new XVar(false);
			}
			else
			{
				ret = XVar.Clone(!XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(gridFields))), XVar.Pack(false)));
			}
			if(XVar.Pack(!(XVar)(ret)))
			{
				if((XVar)(XVar.Equals(XVar.Pack(this.getPageType()), XVar.Pack("report")))  || (XVar)(XVar.Equals(XVar.Pack(this.getPageType()), XVar.Pack("rprint"))))
				{
					return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(this.getReportGroupFields()))), XVar.Pack(false));
				}
			}
			return ret;
		}
		public virtual XVar appearOnSearchPanel(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic fields = null;
			fields = this.getPageOption(new XVar("fields"), new XVar("searchPanelFields"));
			if(XVar.Pack(!(XVar)(fields)))
			{
				return false;
			}
			return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(fields))), XVar.Pack(false));
		}
		public virtual XVar appearAlwaysOnSearchPanel(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic fields = null;
			fields = this.getPageOption(new XVar("listSearch"), new XVar("alwaysOnPanelFields"));
			if(XVar.Pack(!(XVar)(fields)))
			{
				return false;
			}
			return !XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(field), (XVar)(fields))), XVar.Pack(false));
		}
		public virtual XVar getPageFields()
		{
			dynamic fields = null;
			fields = XVar.Clone(this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields")));
			if(XVar.Pack(CommonFunctions.isReport((XVar)(this.getEntityType()))))
			{
				return MVCFunctions.array_merge((XVar)(fields), (XVar)(this.getReportGroupFields()));
			}
			return fields;
		}
		public virtual XVar appearOnViewPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnPage((XVar)(field));
		}
		public virtual XVar appearOnPrinterPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnListPage((XVar)(field));
		}
		public virtual XVar isVideoUrlField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("fieldIsVideoUrl"));
		}
		public virtual XVar isAbsolute(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("Absolute"));
		}
		public virtual XVar getAudioTitleField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("audioTitleField"));
		}
		public virtual XVar getVideoWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("videoWidth"));
		}
		public virtual XVar getVideoHeight(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("videoHeight"));
		}
		public virtual XVar isRewindEnabled(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("RewindEnabled"));
		}
		public virtual XVar getParentFieldsData(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("categoryFields"));
		}
		public virtual XVar getLookupParentFNames(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic fNames = XVar.Array();
			fNames = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> data in this.getParentFieldsData((XVar)(field)).GetEnumerator())
			{
				fNames.InitAndSetArrayItem(data.Value["main"], null);
			}
			return fNames;
		}
		public virtual XVar isLookupUnique(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupUnique"));
		}
		public virtual XVar getLookupOrderBy(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupOrderBy"));
		}
		public virtual XVar isLookupDesc(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupDesc"));
		}
		public virtual XVar getOwnerTable(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ownerTable"));
		}
		public virtual XVar isFieldEncrypted(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("bIsEncrypted"));
		}
		public virtual XVar isAllowToAdd(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("AllowToAdd"));
		}
		public virtual XVar isSimpleAdd(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("SimpleAdd"));
		}
		public virtual XVar getAutoCompleteFields(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic editPageType = null;
			editPageType = XVar.Clone(this.getEditPageType());
			if((XVar)((XVar)(editPageType == Constants.PAGE_REGISTER)  || (XVar)(editPageType == Constants.PAGE_ADD))  || (XVar)((XVar)(editPageType == Constants.PAGE_EDIT)  && (XVar)((XVar)(this.isSeparate((XVar)(field)))  || (XVar)(this.isAutoCompleteFieldsOnEdit((XVar)(field))))))
			{
				return this.getFieldData((XVar)(field), new XVar("autoCompleteFields"));
			}
			return this.getDefaultValueByKey(new XVar("autoCompleteFields"));
		}
		public virtual XVar isAutoCompleteFieldsOnEdit(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("autoCompleteFieldsOnEdit"));
		}
		public virtual XVar isFreeInput(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("freeInput"));
		}
		public virtual XVar getMapData(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("mapData"));
		}
		public virtual XVar getFormatTimeAttrs(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("FormatTimeAttrs"));
		}
		public virtual XVar getViewAsTimeFormatData(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("timeFormatData"));
		}
		public virtual XVar showDaysInTimeTotals(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic formatData = XVar.Array();
			formatData = XVar.Clone(this.getViewAsTimeFormatData((XVar)(field)));
			return (XVar.Pack(formatData) ? XVar.Pack(formatData["showDaysInTotals"]) : XVar.Pack(false));
		}
		public virtual XVar appearOnExportPage(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnPage((XVar)(field));
		}
		public virtual XVar getStrOriginalTableName()
		{
			return this.getTableData(new XVar(".strOriginalTableName"));
		}
		public virtual XVar getSearchableFields()
		{
			if(this.getEntityType() == Constants.titDASHBOARD)
			{
				return this.getPageOption(new XVar("dashSearch"), new XVar("allSearchFields"));
			}
			return this.getTableData(new XVar(".searchableFields"));
		}
		public virtual XVar getAllSearchFields()
		{
			return (XVar.Pack(this.getEntityType() == Constants.titDASHBOARD) ? XVar.Pack(this.getPageOptionAsArray(new XVar("dashSearch"), new XVar("allSearchFields"))) : XVar.Pack(this.getPageOptionAsArray(new XVar("fields"), new XVar("searchPanelFields"))));
		}
		public virtual XVar getAdvSearchFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar isUseTimeForSearch()
		{
			return this.getTableData(new XVar(".isUseTimeForSearch"));
		}
		public virtual XVar isUseToolTips()
		{
			return this.getTableData(new XVar(".isUseToolTips"));
		}
		public virtual XVar isUseVideo()
		{
			return this.getTableData(new XVar(".isUseVideo"));
		}
		public virtual XVar isUseAudio()
		{
			return this.getTableData(new XVar(".isUseAudio"));
		}
		public virtual XVar isUseAudioOnDetails()
		{
			dynamic i = null;
			i = new XVar(0);
			for(;i < MVCFunctions.count(this._detailsTableData); i++)
			{
				if(XVar.Pack(this._detailsTableData[i]["isUseAudio"]))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar getTableType()
		{
			return this.getTableData(new XVar(".tableType"));
		}
		public virtual XVar getShortTableName()
		{
			return CommonFunctions.GetTableURL((XVar)(this._table));
		}
		public virtual XVar isShowAddInPopup()
		{
			return this.getPageOption(new XVar("list"), new XVar("addInPopup"));
		}
		public virtual XVar isShowEditInPopup()
		{
			return this.getPageOption(new XVar("list"), new XVar("editInPopup"));
		}
		public virtual XVar isShowViewInPopup()
		{
			return this.getPageOption(new XVar("list"), new XVar("viewInPopup"));
		}
		public virtual XVar isResizeColumns()
		{
			return this.getTableData(new XVar(".isResizeColumns"));
		}
		public virtual XVar isUseAjaxSuggest()
		{
			return this.getTableData(new XVar(".isUseAjaxSuggest"));
		}
		public virtual XVar getAllPageFields()
		{
			return MVCFunctions.array_merge((XVar)(this.getPageFields()), (XVar)(this.getAllSearchFields()));
		}
		public virtual XVar getPanelSearchFields()
		{
			return this.getPageOptionAsArray(new XVar("listSearch"), new XVar("alwaysOnPanelFields"));
		}
		public virtual XVar getSearchPanelOptions()
		{
			return this.getTableData(new XVar(".searchPanelOptions"));
		}
		public virtual XVar getGoogleLikeFields()
		{
			if(this.getEntityType() == Constants.titDASHBOARD)
			{
				return this.getPageOptionAsArray(new XVar("dashSearch"), new XVar("googleLikeFields"));
			}
			return this.getTableData(new XVar(".googleLikeFields"));
		}
		public virtual XVar getInlineEditFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("inlineEditFields"));
		}
		public virtual XVar getUpdateSelectedFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("updateOnEditFields"));
		}
		public virtual XVar getExportFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("exportFields"));
		}
		public virtual XVar getImportFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar getEditFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar getInlineAddFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("inlineAddFields"));
		}
		public virtual XVar getAddFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar getMasterListFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar getViewFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields"));
		}
		public virtual XVar getFieldFilterFields()
		{
			dynamic ret = XVar.Array();
			ret = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in this.getPageOptionAsArray(new XVar("fields"), new XVar("fieldFilterFields")).GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(this.getFieldType((XVar)(f.Value)))))))
				{
					ret.InitAndSetArrayItem(f.Value, null);
				}
			}
			return ret;
		}
		public virtual XVar getPrinterFields()
		{
			return this.getPageFields();
		}
		public virtual XVar getListFields()
		{
			dynamic fields = null;
			fields = XVar.Clone(this.getPageOptionAsArray(new XVar("fields"), new XVar("gridFields")));
			if(XVar.Pack(CommonFunctions.isReport((XVar)(this.getEntityType()))))
			{
				return MVCFunctions.array_merge((XVar)(fields), (XVar)(this.getReportGroupFields()));
			}
			return fields;
		}
		public virtual XVar isAddPageEvents()
		{
			return this.getAuxTableData(new XVar(".addPageEvents"));
		}
		public virtual XVar hasAjaxSnippet()
		{
			return this.getTableData(new XVar(".ajaxCodeSnippetAdded"));
		}
		public virtual XVar hasButtonsAdded()
		{
			return this.getPageOption(new XVar("page"), new XVar("hasCustomButtons"));
		}
		public virtual XVar customButtons()
		{
			return this.getPageOptionAsArray(new XVar("page"), new XVar("customButtons"));
		}
		public virtual XVar isUseFieldsMaps()
		{
			return this.getTableData(new XVar(".isUseFieldsMaps"));
		}
		public virtual XVar getOrderIndexes()
		{
			return this.getTableData(new XVar(".orderindexes"));
		}
		public virtual XVar getStrOrderBy()
		{
			return this.getTableData(new XVar(".strOrderBy"));
		}
		public virtual SQLQuery getSQLQuery()
		{
			dynamic query = null;
			query = XVar.Clone(this.getTableData(new XVar(".sqlquery")));
			if(query != null)
			{
				return query;
			}
			return null;
		}
		public virtual XVar getSQLQueryByField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic query = null;
			if(this.getTableType() == Constants.PAGE_DASHBOARD)
			{
				query = XVar.Clone(this.getDashTableData((XVar)(field), new XVar(".sqlquery")));
				if(query != null)
				{
					return query;
				}
				return null;
			}
			else
			{
				query = XVar.Clone(this.getTableData(new XVar(".sqlquery")));
				if(query != null)
				{
					return query;
				}
				return null;
			}
			return null;
		}
		public virtual XVar getCreateThumbnail(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("CreateThumbnail"));
		}
		public virtual XVar getStrThumbnail(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("StrThumbnail"));
		}
		public virtual XVar getThumbnailSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ThumbnailSize"));
		}
		public virtual XVar getResizeOnUpload(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ResizeImage"));
		}
		public virtual XVar isBasicUploadUsed(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("CompatibilityMode"));
		}
		public virtual XVar isAutoUpload(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("autoUpload"));
		}
		public virtual XVar getNewImageSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("NewSize"));
		}
		public virtual XVar getAcceptFileTypes(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("acceptFileTypes"));
		}
		public virtual XVar getAcceptFileTypesHtml(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("acceptFileTypesHtml"));
		}
		public virtual XVar getMaxFileSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxFileSize"));
		}
		public virtual XVar getMaxTotalFilesSize(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxTotalFilesSize"));
		}
		public virtual XVar getMaxNumberOfFiles(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxNumberOfFiles"));
		}
		public virtual XVar getMaxImageWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxImageWidth"));
		}
		public virtual XVar getMaxImageHeight(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxImageHeight"));
		}
		public virtual XVar getStrFilename(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("strFilename"));
		}
		public virtual XVar getNRows(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("nRows"));
		}
		public virtual XVar getNCols(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("nCols"));
		}
		public virtual XVar getOriginalTableName()
		{
			dynamic result = null;
			result = XVar.Clone(this.getTableData(new XVar(".OriginalTable")));
			return (XVar.Pack(result != XVar.Pack("")) ? XVar.Pack(result) : XVar.Pack(this._table));
		}
		public virtual XVar getTableKeys()
		{
			return this.getTableData(new XVar(".Keys"));
		}
		public virtual XVar isLargeTextTruncationSet(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("truncateText"));
		}
		public virtual XVar getNumberOfChars(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("NumberOfChars"));
		}
		public virtual XVar isSQLExpression(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("isSQLExpression"));
		}
		public virtual XVar getFullFieldName(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("FullName"));
		}
		public virtual XVar setFullFieldName(dynamic _param_field, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			return this.setFieldData((XVar)(field), new XVar("FullName"), (XVar)(value));
		}
		public virtual XVar getTableOwnerID()
		{
			return this.getTableData(new XVar(".OwnerID"));
		}
		public virtual XVar isRequired(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("IsRequired"));
		}
		public virtual XVar insertNull(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("insertNull"));
		}
		public virtual XVar isUseRTE(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("UseRTE"));
		}
		public virtual XVar isUseRTEBasic(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return (XVar)(this.isUseRTE((XVar)(field)))  && (XVar)(GlobalVars.isUseRTEBasic);
		}
		public virtual XVar isUseRTEFCK(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return (XVar)(this.isUseRTE((XVar)(field)))  && (XVar)(GlobalVars.isUseRTECK);
		}
		public virtual XVar isUseRTECKNew(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return (XVar)(this.isUseRTE((XVar)(field)))  && (XVar)(GlobalVars.isUseRTECKNew);
		}
		public virtual XVar isUseRTEInnova(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return (XVar)(this.isUseRTE((XVar)(field)))  && (XVar)(GlobalVars.isUseRTEInnova);
		}
		public virtual XVar isUseTimestamp(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("UseTimestamp"));
		}
		public virtual XVar getFieldIndex(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("Index"));
		}
		public virtual XVar getEntityType()
		{
			return this.getTableData(new XVar(".entityType"));
		}
		public virtual XVar getDateEditType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("DateEditType"));
		}
		public virtual XVar getHTML5InputType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("HTML5InuptType"));
		}
		public virtual XVar getEditParams(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("EditParams"));
		}
		public virtual XVar getControlWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("controlWidth"));
		}
		public virtual XVar checkFieldPermissions(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.appearOnPage((XVar)(field));
		}
		public virtual XVar getTableOwnerIdField()
		{
			return this.getTableData(new XVar(".mainTableOwnerID"));
		}
		public virtual XVar isHorizontalLookup(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("HorizontalLookup"));
		}
		public virtual XVar isDecimalDigits(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("DecimalDigits"));
		}
		public virtual XVar getLookupValues(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("LookupValues"));
		}
		public virtual XVar hasEditPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("edit"))));
		}
		public virtual XVar hasAddPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("add"))));
		}
		public virtual XVar hasListPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("list"))));
		}
		public virtual XVar hasImportPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("import"))));
		}
		public virtual XVar hasInlineEdit()
		{
			return this.getPageOption(new XVar("list"), new XVar("inlineEdit"));
		}
		public virtual XVar hasUpdateSelected()
		{
			return this.getPageOption(new XVar("list"), new XVar("updateSelected"));
		}
		public virtual XVar updateSelectedButtons()
		{
			dynamic data = XVar.Array();
			data = XVar.Clone(this.labeledButtons());
			return data["update_records"];
		}
		public virtual XVar activatonMessages()
		{
			dynamic data = XVar.Array();
			data = XVar.Clone(this.labeledButtons());
			if(XVar.Pack(!(XVar)(MVCFunctions.is_array((XVar)(data["register_activate_message"])))))
			{
				return XVar.Array();
			}
			return data["register_activate_message"];
		}
		public virtual XVar labeledButtons()
		{
			return this.getPageOptionAsArray(new XVar("page"), new XVar("labeledButtons"));
		}
		public virtual XVar printPagesLabelsData()
		{
			dynamic data = XVar.Array();
			data = XVar.Clone(this.labeledButtons());
			return data["print_pages"];
		}
		public virtual XVar detailsFoundLabelsData()
		{
			dynamic data = XVar.Array();
			data = XVar.Clone(this.labeledButtons());
			return data["details_found"];
		}
		public virtual XVar hasSortByDropdown()
		{
			return this.getPageOption(new XVar("list"), new XVar("sortDropdown"));
		}
		public virtual XVar getSortControlSettingsJSONString()
		{
			return this.getTableData(new XVar(".strSortControlSettingsJSON"));
		}
		public virtual XVar getClickActionJSONString()
		{
			return this.getTableData(new XVar(".strClickActionJSON"));
		}
		public virtual XVar hasCopyPage()
		{
			return true;
		}
		public virtual XVar hasViewPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("view"))));
		}
		public virtual XVar hasExportPage()
		{
			return !(XVar)(!(XVar)(this.getDefaultPage(new XVar("export"))));
		}
		public virtual XVar hasPrintPage()
		{
			return (XVar)(!(XVar)(!(XVar)(this.getDefaultPage(new XVar("print")))))  || (XVar)(!(XVar)(!(XVar)(this.getDefaultPage(new XVar("rprint")))));
		}
		public virtual XVar hasDelete()
		{
			return this.getPageOption(new XVar("list"), new XVar("delete"));
		}
		public virtual XVar getTotalsFields()
		{
			dynamic ret = XVar.Array();
			ret = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> totals in this.getPageOptionAsArray(new XVar("totals")).GetEnumerator())
			{
				if((XVar)(totals.Value)  && (XVar)(totals.Value["totalsType"]))
				{
					ret.InitAndSetArrayItem(new XVar("fName", totals.Key, "numRows", 0, "totalsType", totals.Value["totalsType"], "viewFormat", this.getViewFormat((XVar)(totals.Key))), null);
				}
			}
			return ret;
		}
		public virtual XVar calcTotalsFor()
		{
			return this.getPageOption(new XVar("page"), new XVar("calcTotalsFor"));
		}
		public virtual XVar getExportTxtFormattingType()
		{
			return this.getPageOption(new XVar("export"), new XVar("format"));
		}
		public virtual XVar getExportDelimiter()
		{
			return this.getPageOption(new XVar("export"), new XVar("delimiter"));
		}
		public virtual XVar chekcExportDelimiterSelection()
		{
			return this.getPageOption(new XVar("export"), new XVar("selectDelimiter"));
		}
		public virtual XVar checkExportFieldsSelection()
		{
			return this.getPageOption(new XVar("export"), new XVar("selectFields"));
		}
		public virtual XVar exportFileTypes()
		{
			return this.getPageOption(new XVar("export"), new XVar("exportFileTypes"));
		}
		public virtual XVar getLoginFormType()
		{
			return this.getPageOption(new XVar("loginForm"), new XVar("loginForm"));
		}
		public virtual XVar getAdvancedSecurityType()
		{
			if(XVar.Pack(!(XVar)(Security.advancedSecurityAvailable())))
			{
				return Constants.ADVSECURITY_ALL;
			}
			return this.getTableData(new XVar(".nSecOptions"));
		}
		public virtual XVar displayLoading()
		{
			return this.getTableData(new XVar(".isDisplayLoading"));
		}
		public virtual XVar getRecordsPerPageArray()
		{
			return this.getTableData(new XVar(".arrRecsPerPage"));
		}
		public virtual XVar getGroupsPerPageArray()
		{
			return this.getTableData(new XVar(".arrGroupsPerPage"));
		}
		public virtual XVar isReportWithGroups()
		{
			return !(XVar)(!(XVar)(this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("groupFields"))));
		}
		public virtual XVar isCrossTabReport()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("crosstab"));
		}
		public virtual XVar getReportGroupFields()
		{
			dynamic ret = XVar.Array();
			ret = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> g in this.getPageOptionAsArray(new XVar("newreport"), new XVar("reportInfo"), new XVar("groupFields")).GetEnumerator())
			{
				ret.InitAndSetArrayItem(g.Value["field"], null);
			}
			return ret;
		}
		public virtual XVar getReportGroupFieldsData()
		{
			dynamic ret = XVar.Array();
			ret = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> g in this.getPageOptionAsArray(new XVar("newreport"), new XVar("reportInfo"), new XVar("groupFields")).GetEnumerator())
			{
				dynamic gdata = XVar.Array();
				gdata = XVar.Clone(XVar.Array());
				gdata.InitAndSetArrayItem(g.Value["field"], "strGroupField");
				gdata.InitAndSetArrayItem(g.Value["interval"], "groupInterval");
				gdata.InitAndSetArrayItem(g.Key + 1, "groupOrder");
				gdata.InitAndSetArrayItem(g.Value["summary"], "showGroupSummary");
				gdata.InitAndSetArrayItem(g.Value["axis"], "crossTabAxis");
				ret.InitAndSetArrayItem(gdata, null);
			}
			return ret;
		}
		public virtual XVar reportHasHorizontalSummary()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("horizSummary"));
		}
		public virtual XVar reportHasVerticalSummary()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("vertSummary"));
		}
		public virtual XVar reportHasPageSummary()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("pageSummary"));
		}
		public virtual XVar reportHasGlobalSummary()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("globalSummary"));
		}
		public virtual XVar getReportLayout()
		{
			dynamic rLayout = null;
			rLayout = XVar.Clone(this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("layout")));
			if(XVar.Equals(XVar.Pack(rLayout), XVar.Pack("stepped")))
			{
				return Constants.REPORT_STEPPED;
			}
			else
			{
				if(XVar.Equals(XVar.Pack(rLayout), XVar.Pack("align")))
				{
					return Constants.REPORT_ALIGN;
				}
				else
				{
					if(XVar.Equals(XVar.Pack(rLayout), XVar.Pack("outline")))
					{
						return Constants.REPORT_OUTLINE;
					}
					else
					{
						if(XVar.Equals(XVar.Pack(rLayout), XVar.Pack("block")))
						{
							return Constants.REPORT_BLOCK;
						}
						else
						{
							return Constants.REPORT_TABULAR;
						}
					}
				}
			}
			return null;
		}
		public virtual XVar isGroupSummaryCountShown()
		{
			foreach (KeyValuePair<XVar, dynamic> g in this.getPageOptionAsArray(new XVar("newreport"), new XVar("reportInfo"), new XVar("groupFields")).GetEnumerator())
			{
				if(XVar.Pack(g.Value["summary"]))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar reportDetailsShown()
		{
			return this.getPageOption(new XVar("newreport"), new XVar("reportInfo"), new XVar("showData"));
		}
		public virtual XVar reportTotalFieldsExist()
		{
			foreach (KeyValuePair<XVar, dynamic> f in this.getPageOptionAsArray(new XVar("newreport"), new XVar("reportInfo"), new XVar("fields")).GetEnumerator())
			{
				if((XVar)((XVar)((XVar)(f.Value["sum"])  || (XVar)(f.Value["min"]))  || (XVar)(f.Value["max"]))  || (XVar)(f.Value["avg"]))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar reportFieldInfo(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> f in this.getPageOptionAsArray(new XVar("newreport"), new XVar("reportInfo"), new XVar("fields")).GetEnumerator())
			{
				if(XVar.Equals(XVar.Pack(f.Value["field"]), XVar.Pack(field)))
				{
					return f.Value;
				}
			}
			return null;
		}
		public virtual XVar noRecordsOnFirstPage()
		{
			return this.getTableData(new XVar(".noRecordsFirstPage"));
		}
		public virtual XVar isViewPagePDF()
		{
			return this.getTableData(new XVar(".isViewPagePDF"));
		}
		public virtual XVar isLandscapeViewPDFOrientation()
		{
			return this.getTableData(new XVar(".isLandscapeViewPDFOrientation"));
		}
		public virtual XVar isViewPagePDFFitToPage()
		{
			return this.getTableData(new XVar(".isViewPagePDFFitToPage"));
		}
		public virtual XVar getViewPagePDFScale()
		{
			return this.getTableData(new XVar(".nViewPagePDFScale"));
		}
		public virtual XVar isLandscapePrinterPagePDFOrientation()
		{
			return this.getTableData(new XVar(".isLandscapePrinterPagePDFOrientation"));
		}
		public virtual XVar isPrinterPagePDFFitToPage()
		{
			return this.getTableData(new XVar(".isPrinterPagePDFFitToPage"));
		}
		public virtual XVar getPrinterPagePDFScale()
		{
			return this.getTableData(new XVar(".nPrinterPagePDFScale"));
		}
		public virtual XVar isPrinterPageFitToPage()
		{
			return this.getTableData(new XVar(".isPrinterPageFitToPage"));
		}
		public virtual XVar getPrinterPageScale()
		{
			return this.getTableData(new XVar(".nPrinterPageScale"));
		}
		public virtual XVar getPrinterSplitRecords()
		{
			return this.getTableData(new XVar(".nPrinterSplitRecords"));
		}
		public virtual XVar getPrinterPDFSplitRecords()
		{
			return this.getTableData(new XVar(".nPrinterPDFSplitRecords"));
		}
		public virtual XVar isPrinterPagePDF()
		{
			return this.getPageOption(new XVar("pdf"), new XVar("pdfView"));
		}
		public virtual XVar hasCaptcha()
		{
			return this.getPageOption(new XVar("captcha"), new XVar("captcha"));
		}
		public virtual XVar hasBreadcrumb()
		{
			return this.getPageOption(new XVar("misc"), new XVar("breadcrumb"));
		}
		public virtual XVar isSearchRequiredForFiltering()
		{
			return this.getTableData(new XVar(".searchIsRequiredForFilters"));
		}
		public virtual XVar warnLeavingPages()
		{
			return this.getTableData(new XVar(".warnLeavingPages"));
		}
		public virtual XVar hideEmptyViewFields()
		{
			return this.getTableData(new XVar(".hideEmptyFieldsOnView"));
		}
		public virtual XVar getInitialPageSize()
		{
			if(XVar.Pack(CommonFunctions.isReport((XVar)(this.getEntityType()))))
			{
				if(XVar.Pack(this.isReportWithGroups()))
				{
					return this.getTableData(new XVar(".pageSizeGroups"));
				}
				else
				{
					return this.getTableData(new XVar(".pageSizeRecords"));
				}
			}
			return this.getTableData(new XVar(".pageSize"));
		}
		public virtual XVar getRecordsPerRowList()
		{
			return this.getPageOption(new XVar("page"), new XVar("recsPerRow"));
		}
		public virtual XVar getRecordsPerRowPrint()
		{
			return this.getPageOption(new XVar("page"), new XVar("recsPerRow"));
		}
		public virtual XVar getRecordsLimit()
		{
			return this.getTableData(new XVar(".recsLimit"));
		}
		public virtual XVar useMoveNext()
		{
			return this.getPageOption(new XVar("misc"), new XVar("nextPrev"));
		}
		public virtual XVar hasInlineAdd()
		{
			return this.getPageOption(new XVar("list"), new XVar("inlineAdd"));
		}
		public virtual XVar getListGridLayout()
		{
			return this.getPageOption(new XVar("page"), new XVar("gridType"));
		}
		public virtual XVar getPrintGridLayout()
		{
			return this.getPageOption(new XVar("page"), new XVar("gridType"));
		}
		public virtual XVar getPrinterPageOrientation()
		{
			return this.getTableData(new XVar(".printerPageOrientation"));
		}
		public virtual XVar getReportPrintGroupsPerPage()
		{
			if(XVar.Pack(this.isReportWithGroups()))
			{
				return this.getTableData(new XVar(".reportPrintGroupsPerPage"));
			}
			else
			{
				return this.getTableData(new XVar(".reportPrintRecordsPerPage"));
			}
			return null;
		}
		public virtual XVar getReportPrintPDFGroupsPerPage()
		{
			return this.getTableData(new XVar(".reportPrintPDFGroupsPerPage"));
		}
		public virtual XVar ajaxBasedListPage()
		{
			return this.getTableData(new XVar(".listAjax"));
		}
		public virtual XVar isMultistepped()
		{
			return this.getPageOption(new XVar("page"), new XVar("multiStep"));
		}
		public virtual XVar hasVerticalBar()
		{
			return this.getPageOption(new XVar("page"), new XVar("verticalBar"));
		}
		public virtual XVar getGridTabs()
		{
			return this.getTableData(new XVar(".arrGridTabs"));
		}
		public virtual XVar highlightSearchResults()
		{
			return this.getTableData(new XVar(".highlightSearchResults"));
		}
		public virtual XVar getFieldsList()
		{
			dynamic arr = XVar.Array(), t = XVar.Array();
			if(XVar.Pack(XVar.Equals(XVar.Pack(this._tableData), XVar.Pack(null))))
			{
				return XVar.Array();
			}
			t = XVar.Clone(MVCFunctions.array_keys((XVar)(this._tableData)));
			arr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in t.GetEnumerator())
			{
				if(MVCFunctions.substr((XVar)(f.Value), new XVar(0), new XVar(1)) != ".")
				{
					arr.InitAndSetArrayItem(f.Value, null);
				}
			}
			return arr;
		}
		public virtual XVar getFieldCount()
		{
			return MVCFunctions.count(this.getFieldsList());
		}
		public virtual XVar getBinaryFieldsIndices()
		{
			dynamic fields = XVar.Array(), var_out = XVar.Array();
			fields = XVar.Clone(this.getFieldsList());
			var_out = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in fields.GetEnumerator())
			{
				if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(this.getFieldType((XVar)(f.Value))))))
				{
					var_out.InitAndSetArrayItem(f.Key + 1, null);
				}
			}
			return var_out;
		}
		public virtual XVar getNBFieldsList()
		{
			dynamic arr = XVar.Array(), t = XVar.Array();
			t = XVar.Clone(this.getFieldsList());
			arr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in t.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(CommonFunctions.IsBinaryType((XVar)(this.getFieldType((XVar)(f.Value)))))))
				{
					arr.InitAndSetArrayItem(f.Value, null);
				}
			}
			return arr;
		}
		public virtual XVar getFieldByGoodFieldName(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> value in this._tableData.GetEnumerator())
			{
				if((XVar)(MVCFunctions.is_array((XVar)(value.Value)))  && (XVar)(1 < MVCFunctions.count(value.Value)))
				{
					if(value.Value["GoodName"] == field)
					{
						return value.Key;
					}
				}
			}
			return "";
		}
		public virtual XVar getUploadFolder(dynamic _param_field, dynamic _param_fileData = null)
		{
			#region default values
			if(_param_fileData as Object == null) _param_fileData = new XVar(XVar.Array());
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic fileData = XVar.Clone(_param_fileData);
			#endregion

			dynamic path = null;
			if(XVar.Pack(this.isUploadCodeExpression((XVar)(field))))
			{
				path = XVar.Clone(MVCFunctions.GetUploadFolderExpression((XVar)(field), (XVar)(fileData), (XVar)(this._table)));
			}
			else
			{
				path = XVar.Clone(this.getFieldData((XVar)(field), new XVar("UploadFolder")));
			}
			if((XVar)(MVCFunctions.strlen((XVar)(path)))  && (XVar)(MVCFunctions.substr((XVar)(path), (XVar)(MVCFunctions.strlen((XVar)(path)) - 1)) != "/"))
			{
				path = MVCFunctions.Concat(path, "/");
			}
			return path;
		}
		public virtual XVar isMakeDirectoryNeeded(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return (XVar)(this.isUploadCodeExpression((XVar)(field)))  || (XVar)(!(XVar)(this.isAbsolute((XVar)(field))));
		}
		public virtual XVar getFinalUploadFolder(dynamic _param_field, dynamic _param_fileData = null)
		{
			#region default values
			if(_param_fileData as Object == null) _param_fileData = new XVar(XVar.Array());
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic fileData = XVar.Clone(_param_fileData);
			#endregion

			dynamic path = null;
			if(XVar.Pack(this.isAbsolute((XVar)(field))))
			{
				path = XVar.Clone(this.getUploadFolder((XVar)(field), (XVar)(fileData)));
			}
			else
			{
				path = XVar.Clone(MVCFunctions.getabspath((XVar)(this.getUploadFolder((XVar)(field), (XVar)(fileData)))));
			}
			if((XVar)(MVCFunctions.strlen((XVar)(path)))  && (XVar)(MVCFunctions.substr((XVar)(path), (XVar)(MVCFunctions.strlen((XVar)(path)) - 1)) != "\\"))
			{
				path = MVCFunctions.Concat(path, "\\");
			}
			return path;
		}
		public virtual XVar isUploadCodeExpression(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("UploadCodeExpression"));
		}
		public virtual XVar getQueryObject()
		{
			dynamic queryObj = null;
			queryObj = XVar.Clone(this.getSQLQuery());
			return queryObj;
		}
		public virtual XVar getListOfFieldsByExprType(dynamic _param_needaggregate)
		{
			#region pass-by-value parameters
			dynamic needaggregate = XVar.Clone(_param_needaggregate);
			#endregion

			dynamic fields = XVar.Array(), query = null, var_out = XVar.Array();
			query = this.getSQLQuery();
			if(XVar.Pack(!(XVar)(query)))
			{
				return XVar.Array();
			}
			fields = XVar.Clone(this.getFieldsList());
			var_out = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in fields.GetEnumerator())
			{
				dynamic aggr = null;
				aggr = XVar.Clone(query.IsAggrFuncField((XVar)(f.Key)));
				if((XVar)((XVar)(needaggregate)  && (XVar)(aggr))  || (XVar)((XVar)(!(XVar)(needaggregate))  && (XVar)(!(XVar)(aggr))))
				{
					var_out.InitAndSetArrayItem(f.Value, null);
				}
			}
			return var_out;
		}
		public virtual XVar isAggregateField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic idx = null, query = null;
			query = this.getSQLQuery();
			idx = XVar.Clone(this.getFieldIndex((XVar)(field)) - 1);
			return query.IsAggrFuncField((XVar)(idx));
		}
		public virtual XVar getNCSearch()
		{
			return this.getTableData(new XVar(".NCSearch"));
		}
		public virtual XVar getChartType()
		{
			return this.getTableData(new XVar(".chartType"));
		}
		public virtual XVar getChartRefreshTime()
		{
			return this.getTableData(new XVar(".ChartRefreshTime"));
		}
		public virtual XVar getChartXml()
		{
			return this.getTableData(new XVar(".chartXml"));
		}
		public virtual XVar auditEnabled()
		{
			return this.getTableData(new XVar(".audit"));
		}
		public virtual XVar isSearchSavingEnabled()
		{
			return this.getPageOption(new XVar("listSearch"), new XVar("searchSaving"));
		}
		public virtual XVar isAllowShowHideFields()
		{
			if(XVar.Pack(this.getScrollGridBody()))
			{
				return false;
			}
			return this.getPageOption(new XVar("list"), new XVar("showHideFields"));
		}
		public virtual XVar isAllowFieldsReordering()
		{
			if((XVar)(this.getScrollGridBody())  || (XVar)(1 < this.getRecordsPerRowList()))
			{
				return false;
			}
			return this.getPageOption(new XVar("list"), new XVar("reorderFields"));
		}
		public virtual XVar lockingEnabled()
		{
			return this.getTableData(new XVar(".locking"));
		}
		public virtual XVar hasEncryptedFields()
		{
			return this.getTableData(new XVar(".hasEncryptedFields"));
		}
		public virtual XVar showSearchPanel()
		{
			return this.getPageOption(new XVar("listSearch"), new XVar("searchPanel"));
		}
		public virtual XVar isFlexibleSearch()
		{
			return !(XVar)(this.getPageOption(new XVar("listSearch"), new XVar("fixedSearchPanel")));
		}
		public virtual XVar getSearchRequiredFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("searchRequiredFields"));
		}
		public virtual XVar showSimpleSearchOptions()
		{
			return this.getPageOption(new XVar("listSearch"), new XVar("simpleSearchOptions"));
		}
		public virtual XVar getFieldsToHideIfEmpty()
		{
			return this.getPageOption(new XVar("fields"), new XVar("hideEmptyFields"));
		}
		public virtual XVar getFilterFields()
		{
			return this.getPageOptionAsArray(new XVar("fields"), new XVar("filterFields"));
		}
		public virtual XVar getFilterFieldFormat(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterFormat"));
		}
		public virtual XVar getFilterFieldTotal(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterTotals"));
		}
		public virtual XVar showWithNoRecords(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("showWithNoRecords"));
		}
		public virtual XVar getFilterSortValueType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("sortValueType"));
		}
		public virtual XVar isFilterSortOrderDescending(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("descendingOrder"));
		}
		public virtual XVar getNumberOfVisibleFilterItems(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("numberOfVisibleItems"));
		}
		public virtual XVar getFilterByInterval(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterBy"));
		}
		public virtual XVar getParentFilterName(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("parentFilterField"));
		}
		public virtual XVar getFilterIntervals(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterIntervals"));
		}
		public virtual XVar showCollapsed(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("showCollapsed"));
		}
		public virtual XVar getFilterIntervalDatabyIndex(dynamic _param_field, dynamic _param_idx)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic idx = XVar.Clone(_param_idx);
			#endregion

			dynamic filterIntervalsData = XVar.Array(), intervalData = null;
			intervalData = XVar.Clone(XVar.Array());
			filterIntervalsData = XVar.Clone(this.getFilterIntervals((XVar)(field)));
			foreach (KeyValuePair<XVar, dynamic> interval in filterIntervalsData.GetEnumerator())
			{
				if(interval.Value["index"] == idx)
				{
					intervalData = XVar.Clone(interval.Value);
					break;
				}
			}
			return intervalData;
		}
		public virtual XVar getFilterTotalsField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterTotalFields"));
		}
		public virtual XVar getFilterFiledMultiSelect(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterMultiSelect"));
		}
		public virtual XVar getBooleanFilterMessageData(dynamic _param_field, dynamic _param_checked)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic var_checked = XVar.Clone(_param_checked);
			#endregion

			if(XVar.Pack(var_checked))
			{
				return new XVar("text", this.getFieldData((XVar)(field), new XVar("filterCheckedMessageText")), "type", this.getFieldData((XVar)(field), new XVar("filterCheckedMessageType")));
			}
			return new XVar("text", this.getFieldData((XVar)(field), new XVar("filterUncheckedMessageText")), "type", this.getFieldData((XVar)(field), new XVar("filterUncheckedMessageType")));
		}
		public virtual XVar getFilterStepType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterSliderStepType"));
		}
		public virtual XVar getFilterStepValue(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterSliderStepValue"));
		}
		public virtual XVar getFilterKnobsType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterKnobsType"));
		}
		public virtual XVar isFilterApplyBtnSet(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("filterApplyBtn"));
		}
		public virtual XVar getStrField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("strField"));
		}
		public virtual XVar getSourceSingle(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("sourceSingle"));
		}
		public virtual XVar getFieldSource(dynamic _param_field, dynamic _param_listRequest)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic listRequest = XVar.Clone(_param_listRequest);
			#endregion

			return (XVar.Pack(listRequest) ? XVar.Pack(this.getFieldData((XVar)(field), new XVar("strField"))) : XVar.Pack(this.getFieldData((XVar)(field), new XVar("sourceSingle"))));
		}
		public virtual XVar getScrollGridBody()
		{
			return this.getTableData(new XVar(".scrollGridBody"));
		}
		public virtual XVar isUpdateLatLng()
		{
			return this.getTableData(new XVar(".geocodingEnabled"));
		}
		public virtual XVar getGeocodingData()
		{
			return this.getTableData(new XVar(".geocodingData"));
		}
		public virtual XVar allowDuplicateValues(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return !(XVar)(this.getFieldData((XVar)(field), new XVar("denyDuplicates")));
		}
		public virtual XVar getDashFieldData(dynamic _param_field, dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic key = XVar.Clone(_param_key);
			#endregion

			dynamic dashSearchFields = XVar.Array(), dfield = XVar.Array(), table = null;
			dashSearchFields = XVar.Clone(this.getDashboardSearchFields());
			dfield = XVar.Clone(dashSearchFields[field]);
			if(XVar.Pack(dfield))
			{
				table = XVar.Clone(dfield[0]["table"]);
			}
			if((XVar)(!(XVar)(dfield))  || (XVar)(!(XVar)(table)))
			{
				return this.getDefaultValueByKey((XVar)(key));
			}
			if(XVar.Pack(!(XVar)(this._dashboardElemPSet[table])))
			{
				this._dashboardElemPSet.InitAndSetArrayItem(new ProjectSettings((XVar)(table), (XVar)(this._editPage)), table);
			}
			return this._dashboardElemPSet[table].getFieldData((XVar)(dfield[0]["field"]), (XVar)(key));
		}
		public virtual XVar getDashTableData(dynamic _param_field, dynamic _param_key)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic key = XVar.Clone(_param_key);
			#endregion

			dynamic dashSearchFields = XVar.Array(), tableSettings = null;
			dashSearchFields = XVar.Clone(this.getDashboardSearchFields());
			tableSettings = XVar.Clone(new ProjectSettings((XVar)(dashSearchFields[field][0]["table"]), (XVar)(this._editPage)));
			return tableSettings.getTableData((XVar)(key));
		}
		public virtual XVar getSearchOptionsList(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("searchOptionsList"));
		}
		public virtual XVar getDefaultSearchOption(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic defaultOpt = null;
			defaultOpt = XVar.Clone(this.getFieldData((XVar)(field), new XVar("defaultSearchOption")));
			if(XVar.Pack(!(XVar)(defaultOpt)))
			{
				dynamic searchOptionsList = XVar.Array();
				searchOptionsList = XVar.Clone(this.getSearchOptionsList((XVar)(field)));
				if(XVar.Pack(MVCFunctions.count(searchOptionsList)))
				{
					defaultOpt = XVar.Clone(searchOptionsList[0]);
				}
			}
			return defaultOpt;
		}
		public virtual XVar showListOfThumbnails(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("ShowListOfThumbnails"));
		}
		public static XVar isMenuTreelike(dynamic _param_menuName)
		{
			#region pass-by-value parameters
			dynamic menuName = XVar.Clone(_param_menuName);
			#endregion

			return GlobalVars.menuTreelikeFlags[menuName];
		}
		public virtual XVar setPageMode(dynamic _param_pageMode)
		{
			#region pass-by-value parameters
			dynamic pageMode = XVar.Clone(_param_pageMode);
			#endregion

			this._pageMode = XVar.Clone(pageMode);
			return null;
		}
		public virtual XVar editPageHasDenyDuplicatesFields()
		{
			foreach (KeyValuePair<XVar, dynamic> fieldName in this.getEditFields().GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(this.allowDuplicateValues((XVar)(fieldName.Value)))))
				{
					return true;
				}
			}
			return false;
		}
		public virtual XVar getRTEType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(XVar.Pack(this.isUseRTEBasic((XVar)(field))))
			{
				return "RTE";
			}
			if(XVar.Pack(this.isUseRTECKNew((XVar)(field))))
			{
				return "RTECK_NEW";
			}
			if(XVar.Pack(this.isUseRTEFCK((XVar)(field))))
			{
				return "RTECK";
			}
			if(XVar.Pack(this.isUseRTEInnova((XVar)(field))))
			{
				return "RTEINNOVA";
			}
			return "";
		}
		public virtual XVar getHiddenFields(dynamic _param_device)
		{
			#region pass-by-value parameters
			dynamic device = XVar.Clone(_param_device);
			#endregion

			dynamic list = XVar.Array();
			list = XVar.Clone(this.getTableData(new XVar(".hideMobileList")));
			if(XVar.Pack(list.KeyExists(device)))
			{
				return list[device];
			}
			return XVar.Array();
		}
		public virtual XVar getHiddenGoodNameFields(dynamic _param_device)
		{
			#region pass-by-value parameters
			dynamic device = XVar.Clone(_param_device);
			#endregion

			dynamic hFields = XVar.Array(), hGoodFields = XVar.Array();
			hGoodFields = XVar.Clone(XVar.Array());
			hFields = XVar.Clone(this.getHiddenFields((XVar)(device)));
			foreach (KeyValuePair<XVar, dynamic> isShow in hFields.GetEnumerator())
			{
				hGoodFields.InitAndSetArrayItem(isShow.Value, MVCFunctions.GoodFieldName((XVar)(isShow.Key)));
			}
			return hGoodFields;
		}
		public virtual XVar columnsByDeviceEnabled()
		{
			dynamic list = XVar.Array();
			list = XVar.Clone(this.getTableData(new XVar(".hideMobileList")));
			foreach (KeyValuePair<XVar, dynamic> v in list.GetEnumerator())
			{
				if(XVar.Pack(v.Value))
				{
					return true;
				}
			}
			return false;
		}
		public static XVar getDeviceMediaClause(dynamic _param_device)
		{
			#region pass-by-value parameters
			dynamic device = XVar.Clone(_param_device);
			#endregion

			if(device == Constants.DESKTOP)
			{
				return "@media (min-device-width: 1281px)";
			}
			else
			{
				if(device == Constants.TABLET_10_IN)
				{
					return MVCFunctions.Concat("@media (device-width: 768px) and (device-height: 1024px)", " , (min-device-width: 1025px) and (max-device-width: 1280px) and (max-device-height: 1023px) , (min-device-height: 1025px) and (max-device-height: 1280px) and (max-device-width: 1023px)");
				}
				else
				{
					if(device == Constants.TABLET_7_IN)
					{
						return "@media (min-device-height: 401px) and (max-device-height: 800px) and (min-device-width: 401px) and (max-device-width: 1024px) , (min-device-height: 401px) and (min-device-width: 401px) and (max-device-height: 1024px) and (max-device-width: 800px)";
					}
					else
					{
						if(device == Constants.SMARTPHONE_LANDSCAPE)
						{
							return "@media (orientation: landscape) and (max-device-height: 400px), (orientation: landscape) and (max-device-width: 400px)";
						}
						else
						{
							if(device == Constants.SMARTPHONE_PORTRAIT)
							{
								return "@media (orientation: portrait) and (max-device-height: 400px), (orientation: portrait) and (max-device-width: 400px)";
							}
						}
					}
				}
			}
			return null;
		}
		public static XVar getForLogin()
		{
			return (XVar.Pack(!(XVar)(!(XVar)(Security.dbProvider()))) ? XVar.Pack(new ProjectSettings(new XVar("dbo.spectrum_beta_users"), new XVar(Constants.PAGE_LIST))) : XVar.Pack(null));
		}
		public virtual XVar getDashboardSearchFields()
		{
			return this.getPageOptionAsArray(new XVar("dashSearch"), new XVar("searchFields"));
		}
		public virtual XVar getDashboardElementData(dynamic _param_dashElementName)
		{
			#region pass-by-value parameters
			dynamic dashElementName = XVar.Clone(_param_dashElementName);
			#endregion

			dynamic dElements = XVar.Array();
			dElements = XVar.Clone(this.getDashboardElements());
			foreach (KeyValuePair<XVar, dynamic> dElemData in dElements.GetEnumerator())
			{
				if(dElemData.Value["elementName"] == dashElementName)
				{
					return dElemData.Value;
				}
			}
			return XVar.Array();
		}
		public virtual XVar getAfterAddAction()
		{
			return this.getTableData(new XVar(".afterAddAction"));
		}
		public virtual XVar getAADetailTable()
		{
			return this.getTableData(new XVar(".afterAddActionDetTable"));
		}
		public virtual XVar checkClosePopupAfterAdd()
		{
			return this.getTableData(new XVar(".closePopupAfterAdd"));
		}
		public virtual XVar getAfterEditAction()
		{
			return this.getTableData(new XVar(".afterEditAction"));
		}
		public virtual XVar getAEDetailTable()
		{
			return this.getTableData(new XVar(".afterEditActionDetTable"));
		}
		public virtual XVar checkClosePopupAfterEdit()
		{
			return this.getTableData(new XVar(".closePopupAfterEdit"));
		}
		public virtual XVar getMapIcon(dynamic _param_field, dynamic _param_data)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic data = XVar.Clone(_param_data);
			#endregion

			if(XVar.Pack(!(XVar)(this.isMapIconCustom((XVar)(field)))))
			{
				dynamic mapData = XVar.Array();
				mapData = XVar.Clone(this.getMapData((XVar)(field)));
				if(mapData["mapIcon"] != "")
				{
					return MVCFunctions.Concat("images/menuicons/", mapData["mapIcon"]);
				}
				return "";
			}
			else
			{
				return MVCFunctions.getCustomMapIcon((XVar)(field), new XVar(""), (XVar)(data));
			}
			return null;
		}
		public virtual XVar getDashMapIcon(dynamic _param_dashElementName, dynamic _param_data)
		{
			#region pass-by-value parameters
			dynamic dashElementName = XVar.Clone(_param_dashElementName);
			dynamic data = XVar.Clone(_param_data);
			#endregion

			dynamic dashElementData = XVar.Array();
			dashElementData = XVar.Clone(this.getDashboardElementData((XVar)(dashElementName)));
			if(XVar.Pack(dashElementData["isMarkerIconCustom"]))
			{
				return MVCFunctions.getDashMapCustomIcon((XVar)(this._table), (XVar)(dashElementName), (XVar)(data));
			}
			if(XVar.Pack(dashElementData["iconF"]))
			{
				return dashElementData["iconF"];
			}
			return "";
		}
		public virtual XVar getDashMapLocationIcon(dynamic _param_dashElementName, dynamic _param_data)
		{
			#region pass-by-value parameters
			dynamic dashElementName = XVar.Clone(_param_dashElementName);
			dynamic data = XVar.Clone(_param_data);
			#endregion

			dynamic dashElementData = XVar.Array();
			dashElementData = XVar.Clone(this.getDashboardElementData((XVar)(dashElementName)));
			if(XVar.Pack(dashElementData["isLocationMarkerIconCustom"]))
			{
				return MVCFunctions.getDashMapCustomLocationIcon((XVar)(this._table), (XVar)(dashElementName), (XVar)(data));
			}
			if(XVar.Pack(dashElementData["currentLocationIcon"]))
			{
				return dashElementData["currentLocationIcon"];
			}
			return "";
		}
		public virtual XVar isMapIconCustom(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic mapData = XVar.Array();
			mapData = XVar.Clone(this.getMapData((XVar)(field)));
			return mapData["isMapIconCustom"];
		}
		public virtual XVar getDetailsBadgeColor(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("badgeColor"));
		}
		public virtual XVar getPageMenus()
		{
			return this.getPageOptionAsArray(new XVar("page"), new XVar("menus"));
		}
		public virtual XVar getDefaultBadgeColor()
		{
			return this.getTableData(new XVar(".badgeColor"));
		}
		public virtual XVar helperFormItems()
		{
			return this.getPageOption(new XVar("layoutHelper"), new XVar("formItems"));
		}
		public virtual XVar helperItemsByType()
		{
			return this.getPageOption(new XVar("layoutHelper"), new XVar("itemsByType"));
		}
		public virtual XVar allFieldItems()
		{
			return this.getPageOption(new XVar("fields"), new XVar("fieldItems"));
		}
		public virtual XVar helperItemVisibility()
		{
			return this.getPageOption(new XVar("layoutHelper"), new XVar("itemVisibility"));
		}
		public virtual XVar helperCellMaps()
		{
			return this.getPageOption(new XVar("layoutHelper"), new XVar("cellMaps"));
		}
		public virtual XVar detailsShowCount(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("showCount"));
		}
		public virtual XVar detailsHideEmpty(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("hideEmptyChild"));
		}
		public virtual XVar detailsHideEmptyPreview(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("hideEmptyPreview"));
		}
		public virtual XVar detailsPreview(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("displayPreview"));
		}
		public virtual XVar detailsProceedLink(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("showProceedLink"));
		}
		public virtual XVar detailsPrint(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("printDetails"));
		}
		public virtual XVar detailsLinks()
		{
			return this.getPageOption(new XVar("allDetails"), new XVar("linkType"));
		}
		public virtual XVar detailsPageId(dynamic _param_dTable)
		{
			#region pass-by-value parameters
			dynamic dTable = XVar.Clone(_param_dTable);
			#endregion

			return this.getPageOption(new XVar("details"), (XVar)(dTable), new XVar("previewPageId"));
		}
		public virtual XVar masterPreview(dynamic _param_mTable)
		{
			#region pass-by-value parameters
			dynamic mTable = XVar.Clone(_param_mTable);
			#endregion

			return this.getPageOption(new XVar("master"), (XVar)(mTable), new XVar("preview"));
		}
		public virtual XVar hasMap()
		{
			return !(XVar)(!(XVar)(this.getPageOption(new XVar("events"), new XVar("maps"))));
		}
		public virtual XVar maps()
		{
			return this.getPageOption(new XVar("events"), new XVar("maps"));
		}
		public virtual XVar mapsData()
		{
			return this.getPageOption(new XVar("events"), new XVar("mapsData"));
		}
		public virtual XVar buttons()
		{
			return this.getPageOption(new XVar("events"), new XVar("buttons"));
		}
		public virtual XVar getPageType(dynamic _param_page = null)
		{
			#region default values
			if(_param_page as Object == null) _param_page = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic page = XVar.Clone(_param_page);
			#endregion

			if(XVar.Pack(!(XVar)(page)))
			{
				page = XVar.Clone(this._page);
			}
			return this._auxTableData[".pages"][page];
		}
		public virtual XVar getOriginalPageType(dynamic _param_page = null)
		{
			#region default values
			if(_param_page as Object == null) _param_page = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic page = XVar.Clone(_param_page);
			#endregion

			if(XVar.Pack(!(XVar)(page)))
			{
				page = XVar.Clone(this._page);
			}
			return this._auxTableData[".originalPages"][page];
		}
		public virtual XVar getOriginalPages()
		{
			return this._auxTableData[".originalPages"];
		}
		public virtual XVar welcomeItems()
		{
			return this.getPageOption(new XVar("welcome"), new XVar("welcomeItems"));
		}
		public virtual XVar welcomePageSkip()
		{
			return this.getPageOption(new XVar("welcome"), new XVar("welcomePageSkip"));
		}
		public virtual XVar getMultipleImgMode(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("multipleImgMode"));
		}
		public virtual XVar getMaxImages(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("maxImages"));
		}
		public virtual XVar isGalleryEnabled(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("showGallery"));
		}
		public virtual XVar getGalleryMode(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("galleryMode"));
		}
		public virtual XVar getCaptionMode(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("captionMode"));
		}
		public virtual XVar getCaptionField(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("captionField"));
		}
		public virtual XVar getImageBorder(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("imageBorder"));
		}
		public virtual XVar getImageFullWidth(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("imageFullWidth"));
		}
		public virtual XVar pageTypeAvailable(dynamic _param_pageType)
		{
			#region pass-by-value parameters
			dynamic pageType = XVar.Clone(_param_pageType);
			#endregion

			dynamic pagesByType = XVar.Array();
			pagesByType = this._auxTableData[".pagesByType"];
			return !(XVar)(!(XVar)(pagesByType[pageType]));
		}
		public virtual XVar updatePages()
		{
			dynamic defaultPages = XVar.Array(), newPages = XVar.Array(), pages = XVar.Array(), pagesByType = XVar.Array(), restrictedPages = XVar.Array();
			if(XVar.Pack(this._auxTableData[".pagesUpdated"]))
			{
				return null;
			}
			if((XVar)((XVar)((XVar)(this._pageType == Constants.PAGE_LOGIN)  || (XVar)(this._pageType == Constants.PAGE_REGISTER))  || (XVar)(this._pageType == Constants.PAGE_REMIND))  || (XVar)(this._pageType == Constants.PAGE_REMIND_SUCCESS))
			{
				return null;
			}
			this._auxTableData.InitAndSetArrayItem(true, ".pagesUpdated");
			restrictedPages = XVar.Clone(Security.getRestrictedPages((XVar)(this._auxTable), this));
			if(XVar.Pack(!(XVar)(restrictedPages)))
			{
				return null;
			}
			pages = this._auxTableData[".pages"];
			pagesByType = this._auxTableData[".pagesByType"];
			newPages = XVar.Clone(XVar.Array());
			defaultPages = this._auxTableData[".defaultPages"];
			foreach (KeyValuePair<XVar, dynamic> var_type in pages.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(restrictedPages[var_type.Key])))
				{
					newPages.InitAndSetArrayItem(var_type.Value, var_type.Key);
				}
				else
				{
					dynamic idx = null;
					idx = XVar.Clone(MVCFunctions.array_search((XVar)(var_type.Key), (XVar)(pagesByType[var_type.Value])));
					pagesByType[var_type.Value].Remove(idx);
					if(defaultPages[var_type.Value] == var_type.Key)
					{
						defaultPages.InitAndSetArrayItem("", var_type.Value);
						foreach (KeyValuePair<XVar, dynamic> d in pagesByType[var_type.Value].GetEnumerator())
						{
							defaultPages.InitAndSetArrayItem(d.Value, var_type.Value);
							break;
						}
					}
				}
			}
			this._auxTableData.InitAndSetArrayItem(newPages, ".pages");
			return null;
		}
		public virtual XVar resetPages()
		{
			this._auxTableData.Remove(".pagesUpdated");
			this._auxTableData.InitAndSetArrayItem(this._auxTableData[".originalDefaultPages"], ".defaultPages");
			this._auxTableData.InitAndSetArrayItem(this._auxTableData[".originalPages"], ".pages");
			return null;
		}
		public virtual XVar getOriginalPagesByType(dynamic _param_pageType)
		{
			#region pass-by-value parameters
			dynamic pageType = XVar.Clone(_param_pageType);
			#endregion

			return this._auxTableData[".originalPagesByType"][pageType];
		}
		public virtual XVar getDataSourceOps()
		{
			return this._tableData[".operations"];
		}
		public virtual XVar groupChart()
		{
			return this.getTableData(new XVar(".groupChart"));
		}
		public virtual XVar chartLabelInterval()
		{
			return this.getTableData(new XVar(".chartLabelInterval"));
		}
		public virtual XVar chartSeries()
		{
			return this.getTableData(new XVar(".chartSeries"));
		}
		public virtual XVar chartLabelField()
		{
			return this.getTableData(new XVar(".chartLabelField"));
		}
		public virtual XVar getViewPageType()
		{
			return this._viewPage;
		}
		public virtual XVar spreadsheetGrid()
		{
			return this.getPageOption(new XVar("list"), new XVar("spreadsheetMode"));
		}
		public static XVar uploadEditType(dynamic _param_editFormat)
		{
			#region pass-by-value parameters
			dynamic editFormat = XVar.Clone(_param_editFormat);
			#endregion

			return (XVar)((XVar)(editFormat == Constants.EDIT_FORMAT_DATABASE_FILE)  || (XVar)(editFormat == Constants.EDIT_FORMAT_DATABASE_IMAGE))  || (XVar)(editFormat == Constants.EDIT_FORMAT_FILE);
		}
		public virtual XVar addNewRecordAutomatically()
		{
			return this.getPageOption(new XVar("list"), new XVar("addNewRecordAutomatically"));
		}
		public virtual XVar reorderRows()
		{
			return (XVar)(this.getPageOption(new XVar("list"), new XVar("reorderRows")))  && (XVar)(this.reorderRowsField() != "");
		}
		public virtual XVar reorderRowsField()
		{
			return this.getPageOption(new XVar("list"), new XVar("reorderRowsField"));
		}
		public virtual XVar inlineAddBottom()
		{
			return !(XVar)(!(XVar)((XVar)(this.getPageOption(new XVar("list"), new XVar("addToBottom")))  || (XVar)((XVar)(this.spreadsheetGrid())  && (XVar)(this.addNewRecordAutomatically()))));
		}
		public virtual XVar listColumnsOrderOnPrint()
		{
			return this.getPageOption(new XVar("misc"), new XVar("listColumnsOrderOnPrint"));
		}
		public virtual XVar fileStorageProvider(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("fileStorageProvider"));
		}
		public virtual XVar googleDriveFolder(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("googleDriveFolder"));
		}
		public virtual XVar hideAdGroupsUntilSearch()
		{
			return this.getPageOption(new XVar("adGroups"), new XVar("hideUntilSearch"));
		}
		public virtual XVar hasNotifications()
		{
			return this.getPageOption(new XVar("page"), new XVar("hasNotifications"));
		}
		public virtual XVar amazonSecretKey(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("S3SecretKey"));
		}
		public virtual XVar amazonAccessKey(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("S3AccessKey"));
		}
		public virtual XVar amazonPath(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("S3Path"));
		}
		public virtual XVar amazonBucket(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("S3Bucket"));
		}
		public virtual XVar amazonRegion(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("S3Region"));
		}
		public virtual XVar wasabiSecretKey(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("WasabiSecretKey"));
		}
		public virtual XVar wasabiAccessKey(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("WasabiAccessKey"));
		}
		public virtual XVar wasabiPath(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("wasabiPath"));
		}
		public virtual XVar wasabiBucket(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("WasabiBucket"));
		}
		public virtual XVar wasabiRegion(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("WasabiRegion"));
		}
		public virtual XVar oneDrivePath(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("oneDrivePath"));
		}
		public virtual XVar oneDriveDrive(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return CommonFunctions.GetGlobalData(new XVar("OneDriveDrive"));
		}
		public virtual XVar dropboxPath(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			return this.getFieldData((XVar)(field), new XVar("dropBoxPath"));
		}
		public virtual XVar hasOldPassField()
		{
			return this.getPageOption(new XVar("changepwd"), new XVar("oldPassFieldOnPage"));
		}
		public virtual XVar getDashboardElements()
		{
			return this.getPageOption(new XVar("dashboard"), new XVar("elements"));
		}
		public virtual XVar getMobileSub()
		{
			return this.getPageOption(new XVar("page"), new XVar("mobileSub"));
		}
		public virtual XVar getChartCount()
		{
			return this.getPageOption(new XVar("chart"), new XVar("chartCount"));
		}
	}
	// Included file globals
	public partial class CommonFunctions
	{
		public static XVar fillProjectEntites()
		{
			if(XVar.Pack(MVCFunctions.count(GlobalVars.projectEntities)))
			{
				return null;
			}
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "sysdiagrams", "type", 0), "dbo.sysdiagrams");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.sysdiagrams", "sysdiagrams");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "dbo_rspdheader", "type", 0), "dbo.rspdHeader");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.rspdHeader", "dbo_rspdheader");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "dbo_company", "type", 0), "dbo.company");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.company", "dbo_company");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "radioequipment", "type", 0), "dbo.radioEquipment");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.radioEquipment", "radioequipment");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "dashboard", "type", 4), "Dashboard");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("Dashboard", "dashboard");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "baranggay", "type", 0), "dbo.baranggay");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.baranggay", "baranggay");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "city", "type", 0), "dbo.city");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.city", "city");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "province", "type", 0), "dbo.province");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.province", "province");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "fas_report", "type", 2), "FAS Report");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("FAS Report", "fas_report");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_beta_users", "type", 0), "dbo.spectrum_beta_users");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_beta_users", "spectrum_beta_users");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "admin_rights", "type", 1), "admin_rights");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("admin_rights", "admin_rights");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "admin_members", "type", 1), "admin_members");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("admin_members", "admin_members");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "admin_users", "type", 1), "admin_users");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("admin_users", "admin_users");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "stage", "type", 0), "dbo.stage");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.stage", "stage");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "stagestatus", "type", 0), "dbo.stageStatus");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.stageStatus", "stagestatus");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_betauggroups", "type", 0), "dbo.spectrum_betauggroups");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_betauggroups", "spectrum_betauggroups");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_beta_audit", "type", 0), "dbo.spectrum_beta_audit");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_beta_audit", "spectrum_beta_audit");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_beta_settings", "type", 0), "dbo.spectrum_beta_settings");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_beta_settings", "spectrum_beta_settings");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_betaugmembers", "type", 0), "dbo.spectrum_betaugmembers");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_betaugmembers", "spectrum_betaugmembers");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "spectrum_betaugrights", "type", 0), "dbo.spectrum_betaugrights");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.spectrum_betaugrights", "spectrum_betaugrights");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "transactionsetup", "type", 0), "dbo.transactionSetup");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.transactionSetup", "transactionsetup");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "rspd_application_received", "type", 1), "dbo.rspd_application_received");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.rspd_application_received", "rspd_application_received");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "applicationsrecieved", "type", 1), "dbo.applicationsRecieved");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.applicationsRecieved", "applicationsrecieved");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "branch", "type", 0), "dbo.branch");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.branch", "branch");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "users", "type", 1), "users");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("users", "users");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "classstation", "type", 0), "dbo.classStation");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.classStation", "classstation");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "applicationendorsed", "type", 1), "applicationEndorsed");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("applicationEndorsed", "applicationendorsed");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "applicationunderassessment", "type", 1), "applicationUnderAssessment");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("applicationUnderAssessment", "applicationunderassessment");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "applicationundertechnicalevaluation", "type", 1), "applicationUnderTechnicalEvaluation");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("applicationUnderTechnicalEvaluation", "applicationundertechnicalevaluation");
			GlobalVars.projectEntities.InitAndSetArrayItem(new XVar("url", "region", "type", 0), "dbo.region");
			GlobalVars.projectEntitiesReverse.InitAndSetArrayItem("dbo.region", "region");
			return null;
		}
		public static XVar findTable(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic uTable = null;
			CommonFunctions.fillProjectEntites();
			if(XVar.Pack(GlobalVars.projectEntities.KeyExists(table)))
			{
				return table;
			}
			uTable = XVar.Clone(MVCFunctions.strtoupper((XVar)(table)));
			foreach (KeyValuePair<XVar, dynamic> d in GlobalVars.projectEntities.GetEnumerator())
			{
				dynamic gt = null;
				if(uTable == MVCFunctions.strtoupper((XVar)(d.Key)))
				{
					return d.Key;
				}
				gt = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(d.Key)));
				if((XVar)(table == gt)  || (XVar)(uTable == MVCFunctions.strtoupper((XVar)(gt))))
				{
					return d.Key;
				}
			}
			if(XVar.Pack(GlobalVars.projectEntitiesReverse.KeyExists(table)))
			{
				return GlobalVars.projectEntitiesReverse[table];
			}
			foreach (KeyValuePair<XVar, dynamic> v in GlobalVars.projectEntitiesReverse.GetEnumerator())
			{
				if(uTable == MVCFunctions.strtoupper((XVar)(v.Key)))
				{
					return v.Value;
				}
			}
			return "";
		}
		public static XVar GetTableURL(dynamic _param_table)
		{
			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(table == "<global>")
			{
				return Constants.GLOBAL_PAGES_SHORT;
			}
			if(XVar.Pack(!(XVar)(table)))
			{
				return "";
			}
			CommonFunctions.fillProjectEntites();
			if(XVar.Pack(GlobalVars.projectEntities.KeyExists(table)))
			{
				return GlobalVars.projectEntities[table]["url"];
			}
			return "";
		}
		public static XVar GetEntityType(dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic table = XVar.Clone(_param_table);
			#endregion

			if(XVar.Pack(!(XVar)(table)))
			{
				table = XVar.Clone(GlobalVars.strTableName);
			}
			CommonFunctions.fillProjectEntites();
			if(XVar.Pack(GlobalVars.projectEntities.KeyExists(table)))
			{
				return GlobalVars.projectEntities[table]["type"];
			}
			return "";
		}
		public static XVar GetTableByShort(dynamic _param_shortTName)
		{
			#region pass-by-value parameters
			dynamic shortTName = XVar.Clone(_param_shortTName);
			#endregion

			CommonFunctions.fillProjectEntites();
			if(XVar.Pack(!(XVar)(shortTName)))
			{
				return false;
			}
			return GlobalVars.projectEntitiesReverse[shortTName];
		}
	}
}
