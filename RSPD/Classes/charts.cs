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
	public partial class Chart : XClass
	{
		protected dynamic header;
		protected dynamic footer;
		protected dynamic y_axis_label;
		protected dynamic strLabel;
		protected dynamic arrDataLabels = XVar.Array();
		protected dynamic arrDataSeries = XVar.Array();
		protected dynamic chrt_array = XVar.Array();
		public dynamic webchart;
		protected dynamic cname;
		protected dynamic table_type;
		protected dynamic cipherer = XVar.Pack(null);
		protected ProjectSettings pSet = null;
		protected dynamic searchClauseObj = XVar.Pack(null);
		protected dynamic sessionPrefix = XVar.Pack("");
		protected dynamic detailTablesData = XVar.Array();
		protected dynamic pageId;
		protected dynamic showDetails = XVar.Pack(true);
		protected dynamic chartPreview = XVar.Pack(false);
		protected dynamic dashChart = XVar.Pack(false);
		protected dynamic dashChartFirstPointSelected = XVar.Pack(false);
		protected dynamic detailMasterKeys = XVar.Pack("");
		protected dynamic dashTName = XVar.Pack("");
		protected dynamic dashElementName = XVar.Pack("");
		protected dynamic connection;
		protected dynamic _2d;
		protected dynamic noRecordsFound = XVar.Pack(false);
		protected dynamic singleSeries = XVar.Pack(false);
		protected dynamic masterKeysReq;
		protected dynamic masterTable;
		protected dynamic dataSource = XVar.Pack(null);
		protected dynamic tName = XVar.Pack("");
		public Chart(dynamic ch_array, dynamic _param_param)
		{
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.webchart = XVar.Clone(param["webchart"]);
			if(XVar.Pack(this.webchart))
			{
				this.chrt_array = XVar.Clone(CommonFunctions.Convert_Old_Chart((XVar)(ch_array)));
			}
			else
			{
				this.chrt_array = XVar.Clone(ch_array);
			}
			this.tName = XVar.Clone(this.chrt_array["tables"][0]);
			this.setConnection();
			this.pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(this.tName), new XVar(Constants.PAGE_CHART)));
			this.showDetails = XVar.Clone(param["showDetails"]);
			if(XVar.Pack(this.showDetails))
			{
				dynamic i = null, strPerm = null;
				this.detailTablesData = XVar.Clone(this.pSet.getDetailTablesArr());
				i = new XVar(0);
				for(;i < MVCFunctions.count(this.detailTablesData); i++)
				{
					strPerm = XVar.Clone(CommonFunctions.GetUserPermissions((XVar)(this.detailTablesData[i]["dDataSourceTable"])));
					if(XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(strPerm), new XVar("S"))), XVar.Pack(false)))
					{
						this.detailTablesData.Remove(i);
					}
				}
			}
			this.table_type = XVar.Clone(this.chrt_array["table_type"]);
			if(XVar.Pack(!(XVar)(this.table_type)))
			{
				this.table_type = new XVar("project");
			}
			if(this.table_type == "project")
			{
				this.dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(this.tName), (XVar)(this.pSet), (XVar)(this.connection)));
			}
			else
			{
				this.dataSource = XVar.Clone(CommonFunctions.getWebDataSource((XVar)(this.chrt_array)));
			}
			this.pageId = XVar.Clone(param["pageId"]);
			this.chrt_array.InitAndSetArrayItem(false, "appearance", "autoupdate");
			this.cname = XVar.Clone(param["cname"]);
			this.sessionPrefix = XVar.Clone(this.chrt_array["tables"][0]);
			this.masterTable = XVar.Clone(param["masterTable"]);
			this.masterKeysReq = XVar.Clone(param["masterKeysReq"]);
			this.chartPreview = XVar.Clone(param["chartPreview"]);
			this.dashChart = XVar.Clone(param["dashChart"]);
			if(XVar.Pack(this.dashChart))
			{
				this.dashTName = XVar.Clone(param["dashTName"]);
				this.dashElementName = XVar.Clone(param["dashElementName"]);
				this.sessionPrefix = XVar.Clone(MVCFunctions.Concat(this.dashTName, "_", this.sessionPrefix));
			}
			if((XVar)((XVar)(!(XVar)(this.webchart))  && (XVar)(!(XVar)(this.chartPreview)))  && (XVar)(XSession.Session.KeyExists(MVCFunctions.Concat(this.sessionPrefix, "_advsearch"))))
			{
				this.searchClauseObj = XVar.Clone(SearchClause.UnserializeObject((XVar)(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_advsearch")])));
			}
			if(XVar.Pack(this.searchClauseObj))
			{
				RunnerContext.pushSearchContext((XVar)(this.searchClauseObj));
			}
			if(XVar.Pack(this.isProjectDB()))
			{
				this.cipherer = XVar.Clone(new RunnerCipherer((XVar)(this.tName)));
			}
			this.setBasicChartProp();
			if(XVar.Pack(CommonFunctions.tableEventExists(new XVar("UpdateChartSettings"), (XVar)(GlobalVars.strTableName))))
			{
				dynamic eventObj = null;
				eventObj = XVar.Clone(CommonFunctions.getEventObject((XVar)(GlobalVars.strTableName)));
				eventObj.UpdateChartSettings(this);
			}
		}
		protected virtual XVar setSpecParams(dynamic _param_params)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			if(var_params["name"] == "")
			{
				return null;
			}
			if(this.table_type != "db")
			{
				this.arrDataSeries.InitAndSetArrayItem((XVar.Pack(var_params["agr_func"]) ? XVar.Pack(var_params["label"]) : XVar.Pack(var_params["name"])), null);
			}
			else
			{
				this.arrDataSeries.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["name"]), null);
			}
			return null;
		}
		protected virtual XVar setDataLabels(dynamic _param_params, dynamic _param_gTableName)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			dynamic gTableName = XVar.Clone(_param_gTableName);
			#endregion

			dynamic chartType = null;
			chartType = XVar.Clone(this.chrt_array["chart_type"]["type"]);
			if((XVar)(this.table_type == "project")  && (XVar)(!(XVar)(this.webchart)))
			{
				if((XVar)(chartType != "candlestick")  && (XVar)(chartType != "ohlc"))
				{
					this.arrDataLabels.InitAndSetArrayItem(CommonFunctions.GetFieldLabel((XVar)(gTableName), (XVar)(MVCFunctions.GoodFieldName((XVar)(var_params["name"])))), null);
				}
				else
				{
					this.arrDataLabels.InitAndSetArrayItem(CommonFunctions.GetFieldLabel((XVar)(gTableName), (XVar)(MVCFunctions.GoodFieldName((XVar)(var_params["ohlcOpen"])))), null);
				}
			}
			else
			{
				if(XVar.Pack(!(XVar)(var_params["label"])))
				{
					if((XVar)(chartType != "candlestick")  && (XVar)(chartType != "ohlc"))
					{
						this.arrDataLabels.InitAndSetArrayItem(var_params["name"], null);
					}
					else
					{
						this.arrDataLabels.InitAndSetArrayItem(var_params["ohlcOpen"], null);
					}
				}
				else
				{
					this.arrDataLabels.InitAndSetArrayItem(var_params["label"], null);
				}
			}
			return null;
		}
		protected virtual XVar setBasicChartProp()
		{
			dynamic i = null;
			this.header = XVar.Clone(this.chrt_array["appearance"]["head"]);
			this.header = XVar.Clone((XVar.Pack(this.header) ? XVar.Pack(this.header) : XVar.Pack("")));
			this.footer = XVar.Clone(this.chrt_array["appearance"]["foot"]);
			this.footer = XVar.Clone((XVar.Pack(this.footer) ? XVar.Pack(this.footer) : XVar.Pack("")));
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.chrt_array["parameters"]) - 1; i++)
			{
				this.setSpecParams((XVar)(this.chrt_array["parameters"][i]));
				this.setDataLabels((XVar)(this.chrt_array["parameters"][i]), (XVar)(MVCFunctions.GoodFieldName((XVar)(this.chrt_array["tables"][0]))));
			}
			if(this.chrt_array["chart_type"]["type"] != "gauge")
			{
				dynamic chartParams = XVar.Array(), var_params = XVar.Array();
				chartParams = XVar.Clone(this.chrt_array["parameters"]);
				var_params = XVar.Clone(chartParams[MVCFunctions.count(chartParams) - 1]);
				if(this.table_type != "db")
				{
					this.strLabel = XVar.Clone(var_params["name"]);
				}
				else
				{
					this.strLabel = XVar.Clone((XVar.Pack(var_params["agr_func"]) ? XVar.Pack(MVCFunctions.Concat(var_params["agr_func"], "_", var_params["table"], "_", var_params["name"])) : XVar.Pack(MVCFunctions.Concat(var_params["table"], "_", var_params["name"]))));
				}
			}
			if(MVCFunctions.count(this.arrDataLabels) == 1)
			{
				this.y_axis_label = XVar.Clone(this.arrDataLabels[0]);
			}
			else
			{
				this.y_axis_label = XVar.Clone(this.chrt_array["appearance"]["y_axis_label"]);
			}
			return null;
		}
		protected virtual XVar getMasterCondition()
		{
			dynamic conditions = XVar.Array(), detailKeysByM = XVar.Array(), i = null;
			if(XVar.Pack(this.dashChart))
			{
				return null;
			}
			detailKeysByM = XVar.Clone(this.pSet.getDetailKeysByMasterTable((XVar)(this.masterTable)));
			if(XVar.Pack(!(XVar)(detailKeysByM)))
			{
				return null;
			}
			conditions = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(detailKeysByM); ++(i))
			{
				conditions.InitAndSetArrayItem(DataCondition.FieldEquals((XVar)(detailKeysByM[i]), (XVar)(this.masterKeysReq[i + 1])), null);
			}
			return DataCondition._And((XVar)(conditions));
		}
		public virtual XVar getSubsetDataCommand(dynamic _param_ignoreFilterField = null)
		{
			#region default values
			if(_param_ignoreFilterField as Object == null) _param_ignoreFilterField = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic ignoreFilterField = XVar.Clone(_param_ignoreFilterField);
			#endregion

			dynamic dc = null, orderObject = null;
			dc = XVar.Clone(new DsCommand());
			dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, Security.SelectCondition(new XVar("S"), (XVar)(this.pSet)), 1, this.getMasterCondition()))));
			if((XVar)(!(XVar)(this.chartPreview))  && (XVar)(this.searchClauseObj))
			{
				dynamic filter = null, search = null;
				search = XVar.Clone(this.searchClauseObj.getSearchDataCondition());
				filter = XVar.Clone(this.searchClauseObj.getFilterCondition((XVar)(this.pSet)));
				dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, dc.filter, 1, search, 2, filter))));
			}
			if(XVar.Pack(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_chartTabWhere")]))
			{
				dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, dc.filter, 1, DataCondition.SQLCondition((XVar)(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_chartTabWhere")]))))));
			}
			orderObject = XVar.Clone(new OrderClause((XVar)(this.pSet), (XVar)(this.cipherer), (XVar)(this.sessionPrefix), (XVar)(this.connection)));
			dc.order = XVar.Clone(orderObject.getOrderFields());
			if(XVar.Pack(this.pSet.getRecordsLimit()))
			{
				dc.reccount = XVar.Clone(this.pSet.getRecordsLimit());
			}
			if(XVar.Pack(this.pSet.groupChart()))
			{
				dc.totals = XVar.Clone(this.getGroupChartCommandTotals());
			}
			return dc;
		}
		protected virtual XVar getGroupChartCommandTotals()
		{
			dynamic _totals = XVar.Array(), fields = XVar.Array(), orderInfo = XVar.Array(), series = XVar.Array(), totals = XVar.Array();
			totals = XVar.Clone(XVar.Array());
			totals.InitAndSetArrayItem(new XVar("alias", this.pSet.chartLabelField(), "field", this.pSet.chartLabelField(), "modifier", this.pSet.chartLabelInterval()), null);
			series = XVar.Clone(this.pSet.chartSeries());
			foreach (KeyValuePair<XVar, dynamic> s in series.GetEnumerator())
			{
				totals.InitAndSetArrayItem(new XVar("alias", s.Value["field"], "field", s.Value["field"], "total", MVCFunctions.strtolower((XVar)(s.Value["total"]))), null);
			}
			orderInfo = XVar.Clone(this.pSet.getOrderIndexes());
			if(XVar.Pack(!(XVar)(orderInfo)))
			{
				return totals;
			}
			fields = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> o in orderInfo.GetEnumerator())
			{
				fields.InitAndSetArrayItem(this.pSet.GetFieldByIndex((XVar)(o.Value[0])), null);
			}
			foreach (KeyValuePair<XVar, dynamic> t in totals.GetEnumerator())
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.in_array((XVar)(t.Value["field"]), (XVar)(fields)))))
				{
					fields.InitAndSetArrayItem(t.Value["field"], null);
				}
				foreach (KeyValuePair<XVar, dynamic> o in orderInfo.GetEnumerator())
				{
					dynamic fieldIdx = null;
					fieldIdx = XVar.Clone(this.pSet.getFieldIndex((XVar)(t.Value["field"])));
					if(fieldIdx == o.Value[0])
					{
						totals.InitAndSetArrayItem(o.Value[1], t.Key, "direction");
						break;
					}
				}
			}
			_totals = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> field in fields.GetEnumerator())
			{
				foreach (KeyValuePair<XVar, dynamic> t in totals.GetEnumerator())
				{
					if(t.Value["field"] == field.Value)
					{
						_totals.InitAndSetArrayItem(t.Value, null);
					}
				}
			}
			return _totals;
		}
		protected virtual XVar isProjectDB()
		{
			if(XVar.Pack(!(XVar)(this.webchart)))
			{
				return true;
			}
			if("dbo.sysdiagrams" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.company" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.radioEquipment" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.baranggay" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.city" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.province" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_beta_users" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_betaugrights" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_betaugmembers" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_beta_users" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.stage" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.stageStatus" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_betauggroups" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_beta_audit" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_beta_settings" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_betaugmembers" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_betaugrights" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.transactionSetup" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.branch" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.spectrum_beta_users" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.classStation" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.rspdHeader" == this.chrt_array["tables"][0])
			{
				return true;
			}
			if("dbo.region" == this.chrt_array["tables"][0])
			{
				return true;
			}
			return false;
		}
		protected virtual XVar setConnection()
		{
			if(XVar.Pack(this.isProjectDB()))
			{
				this.connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(this.tName)));
			}
			else
			{
				this.connection = XVar.Clone(GlobalVars.cman.getDefault());
			}
			return null;
		}
		public virtual XVar setFooter(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			this.footer = XVar.Clone(name);
			return null;
		}
		public virtual XVar getFooter()
		{
			return this.footer;
		}
		public virtual XVar setHeader(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			this.header = XVar.Clone(name);
			return null;
		}
		public virtual XVar getHeader()
		{
			return this.header;
		}
		public virtual XVar setLabelField(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			this.strLabel = XVar.Clone(name);
			return null;
		}
		public virtual XVar getLabelField()
		{
			return this.strLabel;
		}
		protected virtual XVar getDetailedTooltipMessage()
		{
			dynamic showClickHere = null;
			if((XVar)(!(XVar)(this.showDetails))  || (XVar)(!(XVar)(this.detailTablesData)))
			{
				return "";
			}
			showClickHere = new XVar(true);
			if(XVar.Pack(this.dashChart))
			{
				dynamic arrDElem = XVar.Array(), pDSet = null;
				showClickHere = new XVar(false);
				pDSet = XVar.Clone(new ProjectSettings((XVar)(this.dashTName)));
				arrDElem = XVar.Clone(pDSet.getDashboardElements());
				foreach (KeyValuePair<XVar, dynamic> elem in arrDElem.GetEnumerator())
				{
					if((XVar)(elem.Value["table"] == this.chrt_array["tables"][0])  && (XVar)(!(XVar)(!(XVar)(elem.Value["details"]))))
					{
						showClickHere = new XVar(true);
					}
				}
			}
			if(XVar.Pack(showClickHere))
			{
				dynamic tableCaption = null;
				tableCaption = XVar.Clone(CommonFunctions.GetTableCaption((XVar)(this.detailTablesData[0]["dDataSourceTable"])));
				tableCaption = XVar.Clone((XVar.Pack(tableCaption) ? XVar.Pack(tableCaption) : XVar.Pack(this.detailTablesData[0]["dDataSourceTable"])));
				return MVCFunctions.Concat("\nClick here to see ", tableCaption, " details");
			}
			return "";
		}
		protected virtual XVar getNoDataMessage()
		{
			if(XVar.Pack(!(XVar)(this.noRecordsFound)))
			{
				return "";
			}
			if(XVar.Pack(!(XVar)(this.searchClauseObj)))
			{
				return "No data yet.";
			}
			if(XVar.Pack(this.searchClauseObj.isSearchFunctionalityActivated()))
			{
				return "No results found.";
			}
			return "No data yet.";
		}
		public virtual XVar write()
		{
			dynamic chart = XVar.Array(), data = XVar.Array();
			data = XVar.Clone(XVar.Array());
			chart = XVar.Clone(XVar.Array());
			this.setTypeSpecChartSettings((XVar)(chart));
			if((XVar)(this.chrt_array["appearance"]["color71"] != "")  || (XVar)(this.chrt_array["appearance"]["color91"] != ""))
			{
				chart.InitAndSetArrayItem(XVar.Array(), "background");
			}
			if(this.chrt_array["appearance"]["color71"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color71"]), "background", "fill");
			}
			if(this.chrt_array["appearance"]["color91"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color91"]), "background", "stroke");
			}
			if(XVar.Pack(this.noRecordsFound))
			{
				data.InitAndSetArrayItem(this.getNoDataMessage(), "noDataMessage");
				MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(data)));
				return null;
			}
			if((XVar)(this.chrt_array["appearance"]["sanim"] == "true")  && (XVar)(this.chrt_array["appearance"]["autoupdate"] != "true"))
			{
				chart.InitAndSetArrayItem(new XVar("enabled", "true", "duration", 1000), "animation");
			}
			if((XVar)(this.chrt_array["appearance"]["slegend"] == "true")  && (XVar)(!(XVar)(this.chartPreview)))
			{
				chart.InitAndSetArrayItem(new XVar("enabled", "true"), "legend");
			}
			else
			{
				chart.InitAndSetArrayItem(new XVar("enabled", false), "legend");
			}
			chart.InitAndSetArrayItem(false, "credits");
			chart.InitAndSetArrayItem(new XVar("enabled", "true", "text", this.header), "title");
			if(this.chrt_array["appearance"]["color101"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color101"]), "title", "fontColor");
			}
			data.InitAndSetArrayItem(chart, "chart");
			MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(data)));
			return null;
		}
		protected virtual XVar setTypeSpecChartSettings(dynamic chart)
		{
			return null;
		}
		protected virtual XVar getGrids()
		{
			dynamic grids = XVar.Array();
			grids = XVar.Clone(XVar.Array());
			if(this.chrt_array["appearance"]["sgrid"] == "true")
			{
				dynamic grid0 = XVar.Array(), stroke = null;
				stroke = XVar.Clone((XVar.Pack(this.chrt_array["appearance"]["color121"] != "") ? XVar.Pack(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color121"])) : XVar.Pack("#ddd")));
				grid0 = XVar.Clone(new XVar("enabled", true, "drawLastLine", false, "stroke", stroke, "scale", 0, "axis", 0));
				if(this.chrt_array["appearance"]["color81"] != "")
				{
					dynamic dataPlotBackgroundColor = null;
					dataPlotBackgroundColor = XVar.Clone(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color81"]));
					grid0.InitAndSetArrayItem(dataPlotBackgroundColor, "oddFill");
					grid0.InitAndSetArrayItem(dataPlotBackgroundColor, "evenFill");
				}
				grids.InitAndSetArrayItem(grid0, null);
				grids.InitAndSetArrayItem(new XVar("enabled", true, "drawLastLine", false, "stroke", stroke, "axis", 1), null);
			}
			return grids;
		}
		protected virtual XVar labelFormat(dynamic _param_fieldName, dynamic _param_data, dynamic _param_truncated = null)
		{
			#region default values
			if(_param_truncated as Object == null) _param_truncated = new XVar(true);
			#endregion

			#region pass-by-value parameters
			dynamic fieldName = XVar.Clone(_param_fieldName);
			dynamic data = XVar.Clone(_param_data);
			dynamic truncated = XVar.Clone(_param_truncated);
			#endregion

			dynamic value = null, viewControls = null;
			if(XVar.Pack(!(XVar)(fieldName)))
			{
				return "";
			}
			if((XVar)(this.table_type == "db")  && (XVar)(!(XVar)(!(XVar)(this.chrt_array["customLabels"]))))
			{
				fieldName = XVar.Clone(this.chrt_array["customLabels"][fieldName]);
			}
			viewControls = XVar.Clone(new ViewControlsContainer((XVar)(this.pSet), new XVar(Constants.PAGE_CHART)));
			if(XVar.Pack(this.pSet.groupChart()))
			{
				dynamic interval = null;
				interval = XVar.Clone(this.pSet.chartLabelInterval());
				if(XVar.Pack(interval))
				{
					dynamic fType = null;
					fType = XVar.Clone(this.pSet.getFieldType((XVar)(fieldName)));
					return RunnerPage.formatGroupValueStatic((XVar)(fieldName), (XVar)(interval), (XVar)(data[fieldName]), (XVar)(this.pSet), (XVar)(viewControls), new XVar(false));
				}
			}
			value = XVar.Clone(viewControls.showDBValue((XVar)(fieldName), (XVar)(data), new XVar(""), new XVar(""), new XVar(false)));
			if((XVar)(truncated)  && (XVar)(50 < MVCFunctions.strlen((XVar)(value))))
			{
				value = XVar.Clone(MVCFunctions.Concat(MVCFunctions.runner_substr((XVar)(value), new XVar(0), new XVar(47)), "..."));
			}
			return value;
		}
		protected virtual XVar beforeQueryEvent(dynamic dc)
		{
			dynamic eventsObject = null, order = null, prep = XVar.Array(), sql = null, where = null;
			eventsObject = XVar.Clone(CommonFunctions.getEventObject((XVar)(this.pSet.getTableName())));
			if(XVar.Pack(!(XVar)(eventsObject)))
			{
				return null;
			}
			if(XVar.Pack(!(XVar)(eventsObject.exists(new XVar("BeforeQueryChart")))))
			{
				return null;
			}
			prep = XVar.Clone(this.dataSource.prepareSQL((XVar)(dc)));
			where = XVar.Clone(prep["where"]);
			sql = XVar.Clone(prep["sql"]);
			order = XVar.Clone(prep["order"]);
			eventsObject.BeforeQueryChart((XVar)(sql), ref where, ref order);
			if(sql != prep["sql"])
			{
				this.dataSource.overrideSQL((XVar)(dc), (XVar)(sql));
			}
			else
			{
				if(where != prep["where"])
				{
					this.dataSource.overrideWhere((XVar)(dc), (XVar)(where));
				}
				if(order != prep["order"])
				{
					this.dataSource.overrideOrder((XVar)(dc), (XVar)(order));
				}
			}
			return null;
		}
		public virtual XVar get_data()
		{
			dynamic clickdata = XVar.Array(), data = XVar.Array(), dc = null, i = null, row = null, rs = null, series = XVar.Array(), strLabelFormat = null;
			data = XVar.Clone(XVar.Array());
			clickdata = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrDataSeries); i++)
			{
				data.InitAndSetArrayItem(XVar.Array(), i);
				clickdata.InitAndSetArrayItem(XVar.Array(), i);
			}
			dc = XVar.Clone(this.getSubsetDataCommand());
			this.beforeQueryEvent((XVar)(dc));
			if(XVar.Pack(this.pSet.groupChart()))
			{
				rs = XVar.Clone(this.dataSource.getTotals((XVar)(dc)));
			}
			else
			{
				rs = XVar.Clone(this.dataSource.getList((XVar)(dc)));
			}
			if(XVar.Pack(!(XVar)(rs)))
			{
				MVCFunctions.showError((XVar)(this.dataSource.lastError()));
			}
			row = XVar.Clone(rs.fetchAssoc());
			if(XVar.Pack(this.cipherer))
			{
				row = XVar.Clone(this.cipherer.DecryptFetchedArray((XVar)(row)));
			}
			if(XVar.Pack(!(XVar)(row)))
			{
				this.noRecordsFound = new XVar(true);
			}
			while(XVar.Pack(row))
			{
				i = new XVar(0);
				for(;i < MVCFunctions.count(this.arrDataSeries); i++)
				{
					data.InitAndSetArrayItem(this.getPoint((XVar)(i), (XVar)(row)), i, null);
					strLabelFormat = XVar.Clone(this.labelFormat((XVar)(this.strLabel), (XVar)(row)));
					clickdata.InitAndSetArrayItem(this.getActions((XVar)(row), (XVar)(this.arrDataSeries[i]), (XVar)(strLabelFormat)), i, null);
				}
				row = XVar.Clone(rs.fetchAssoc());
				if(XVar.Pack(this.cipherer))
				{
					row = XVar.Clone(this.cipherer.DecryptFetchedArray((XVar)(row)));
				}
			}
			series = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrDataSeries); i++)
			{
				series.InitAndSetArrayItem(this.getSeriesData((XVar)(this.arrDataLabels[i]), (XVar)(data[i]), (XVar)(clickdata[i]), (XVar)(i), (XVar)(1 < MVCFunctions.count(this.arrDataSeries))), null);
			}
			return series;
		}
		protected virtual XVar getPoint(dynamic _param_seriesNumber, dynamic _param_row)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic row = XVar.Clone(_param_row);
			#endregion

			dynamic fieldName = null, formattedValue = null, strDataSeries = null, strLabelFormat = null, viewControls = null;
			strLabelFormat = XVar.Clone(this.labelFormat((XVar)(this.strLabel), (XVar)(row)));
			viewControls = XVar.Clone(new ViewControlsContainer((XVar)(this.pSet), new XVar(Constants.PAGE_CHART)));
			if((XVar)(this.table_type != "db")  || (XVar)(!(XVar)(this.chrt_array["customLabels"])))
			{
				strDataSeries = XVar.Clone(row[this.arrDataSeries[seriesNumber]]);
				fieldName = XVar.Clone(this.arrDataSeries[seriesNumber]);
				formattedValue = XVar.Clone(viewControls.showDBValue((XVar)(fieldName), (XVar)(row), new XVar(""), new XVar(""), new XVar(false)));
			}
			else
			{
				strDataSeries = XVar.Clone(row[this.chrt_array["customLabels"][this.arrDataSeries[seriesNumber]]]);
				fieldName = XVar.Clone(this.chrt_array["customLabels"][this.arrDataSeries[seriesNumber]]);
				formattedValue = XVar.Clone(viewControls.showDBValue((XVar)(fieldName), (XVar)(row), new XVar(""), new XVar(""), new XVar(false)));
			}
			return new XVar("x", strLabelFormat, "value", (double)MVCFunctions.str_replace(new XVar(","), new XVar("."), (XVar)(strDataSeries)), "viewAsValue", formattedValue);
		}
		protected virtual XVar getSeriesData(dynamic _param_name, dynamic _param_pointsData, dynamic _param_clickData, dynamic _param_seriesNumber, dynamic _param_multiSeries = null)
		{
			#region default values
			if(_param_multiSeries as Object == null) _param_multiSeries = new XVar(true);
			#endregion

			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic pointsData = XVar.Clone(_param_pointsData);
			dynamic clickData = XVar.Clone(_param_clickData);
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic multiSeries = XVar.Clone(_param_multiSeries);
			#endregion

			dynamic data = XVar.Array();
			data = XVar.Clone(new XVar("name", name, "data", pointsData, "xScale", "0", "yScale", "1", "seriesType", this.getSeriesType((XVar)(seriesNumber))));
			data.InitAndSetArrayItem(new XVar("enabled", this.chrt_array["appearance"]["sval"] == "true", "format", "{%viewAsValue}"), "labels");
			if(this.chrt_array["appearance"]["color61"] != "")
			{
				data.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color61"]), "labels", "fontColor");
			}
			if((XVar)(clickData)  && (XVar)(this.detailTablesData))
			{
				data.InitAndSetArrayItem(clickData, "clickData");
			}
			data.InitAndSetArrayItem(this.getSeriesTooltip((XVar)(multiSeries)), "tooltip");
			return data;
		}
		protected virtual XVar getSeriesTooltip(dynamic _param_multiSeries)
		{
			#region pass-by-value parameters
			dynamic multiSeries = XVar.Clone(_param_multiSeries);
			#endregion

			return new XVar("enabled", true, "format", MVCFunctions.Concat("{%seriesName}: {%viewAsValue}", this.getDetailedTooltipMessage()));
			return null;
		}
		protected virtual XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			return "column";
		}
		protected virtual XVar chart_xmlencode(dynamic _param_str)
		{
			#region pass-by-value parameters
			dynamic str = XVar.Clone(_param_str);
			#endregion

			return MVCFunctions.str_replace((XVar)(new XVar(0, "&", 1, "<", 2, ">", 3, "\"")), (XVar)(new XVar(0, "&amp;", 1, "&lt;", 2, "&gt;", 3, "&quot;")), (XVar)(str));
		}
		protected virtual XVar getActions(dynamic _param_data, dynamic _param_seriesId, dynamic _param_pointId)
		{
			#region pass-by-value parameters
			dynamic data = XVar.Clone(_param_data);
			dynamic seriesId = XVar.Clone(_param_seriesId);
			dynamic pointId = XVar.Clone(_param_pointId);
			#endregion

			dynamic detailTableData = XVar.Array(), masterquery = null;
			if(XVar.Pack(!(XVar)(this.detailTablesData)))
			{
				return null;
			}
			if(XVar.Pack(this.dashChart))
			{
				dynamic masterKeysArr = XVar.Array();
				masterKeysArr = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> detail in this.detailTablesData.GetEnumerator())
				{
					foreach (KeyValuePair<XVar, dynamic> mk in detail.Value["masterKeys"].GetEnumerator())
					{
						masterKeysArr.InitAndSetArrayItem(new XVar(MVCFunctions.Concat("masterkey", mk.Key + 1), data[mk.Value]), detail.Value["dDataSourceTable"]);
					}
				}
				if(XVar.Pack(!(XVar)(this.dashChartFirstPointSelected)))
				{
					this.dashChartFirstPointSelected = new XVar(true);
					this.detailMasterKeys = XVar.Clone(MVCFunctions.my_json_encode((XVar)(masterKeysArr)));
				}
				return new XVar("masterKeys", masterKeysArr, "seriesId", seriesId, "pointId", pointId);
			}
			detailTableData = XVar.Clone(this.detailTablesData[0]);
			masterquery = XVar.Clone(MVCFunctions.Concat("mastertable=", MVCFunctions.RawUrlEncode((XVar)(GlobalVars.strTableName))));
			foreach (KeyValuePair<XVar, dynamic> mk in detailTableData["masterKeys"].GetEnumerator())
			{
				masterquery = MVCFunctions.Concat(masterquery, "&masterkey", mk.Key + 1, "=", MVCFunctions.RawUrlEncode((XVar)(data[mk.Value])));
			}
			return new XVar("url", MVCFunctions.GetTableLink((XVar)(detailTableData["dShortTable"]), (XVar)(detailTableData["dType"]), (XVar)(masterquery)));
		}
		protected virtual XVar getLogarithm()
		{
			if(this.chrt_array["appearance"]["slog"] == "true")
			{
				return true;
			}
			return false;
		}
	}
	public partial class Chart_Bar : Chart
	{
		protected dynamic stacked;
		protected dynamic bar;
		protected static bool skipChart_BarCtor = false;
		public Chart_Bar(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_BarCtor)
			{
				skipChart_BarCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.stacked = XVar.Clone(param["stacked"]);
			this._2d = XVar.Clone(param["2d"]);
			this.bar = XVar.Clone(param["bar"]);
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			if(XVar.Pack(this.bar))
			{
				return "bar";
			}
			else
			{
				return "column";
			}
			return null;
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			chart.InitAndSetArrayItem(this.getScales(), "scales");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			if(XVar.Pack(this.bar))
			{
				chart.InitAndSetArrayItem("bar", "type");
			}
			else
			{
				chart.InitAndSetArrayItem("column", "type");
			}
			if(XVar.Pack(!(XVar)(this._2d)))
			{
				chart["type"] = MVCFunctions.Concat(chart["type"], "-3d");
			}
			chart.InitAndSetArrayItem(0, "xScale");
			chart.InitAndSetArrayItem(1, "yScale");
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", this.y_axis_label)), "yAxes");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			return null;
		}
		protected virtual XVar getScales()
		{
			if((XVar)(this.stacked)  || (XVar)(this.chrt_array["appearance"]["slog"] == "true"))
			{
				dynamic arr = XVar.Array();
				arr = XVar.Clone(XVar.Array());
				if(XVar.Pack(this.stacked))
				{
					arr.InitAndSetArrayItem("value", "stackMode");
				}
				if(this.chrt_array["appearance"]["slog"] == "true")
				{
					arr.InitAndSetArrayItem(10, "logBase");
					arr.InitAndSetArrayItem("log", "type");
				}
				return new XVar(0, new XVar("names", XVar.Array()), 1, arr);
			}
			return XVar.Array();
		}
	}
	public partial class Chart_Line : Chart
	{
		protected dynamic type_line;
		protected static bool skipChart_LineCtor = false;
		public Chart_Line(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_LineCtor)
			{
				skipChart_LineCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.type_line = XVar.Clone(param["type_line"]);
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			chart.InitAndSetArrayItem("line", "type");
			chart.InitAndSetArrayItem(0, "xScale");
			chart.InitAndSetArrayItem(1, "yScale");
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			chart.InitAndSetArrayItem(new XVar("displayMode", "single"), "tooltip");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", this.y_axis_label)), "yAxes");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			return null;
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			switch(((XVar)this.type_line).ToString())
			{
				case "line":
					return "line";
				case "spline":
					return "spline";
				case "step_line":
					return "stepLine";
				default:
					return "line";
			}
			return null;
		}
	}
	public partial class Chart_Area : Chart
	{
		protected dynamic stacked;
		protected static bool skipChart_AreaCtor = false;
		public Chart_Area(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_AreaCtor)
			{
				skipChart_AreaCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.stacked = XVar.Clone(param["stacked"]);
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			if(XVar.Pack(this.stacked))
			{
				chart.InitAndSetArrayItem(this.getScales(), "scales");
			}
			chart.InitAndSetArrayItem("area", "type");
			chart.InitAndSetArrayItem(0, "xScale");
			chart.InitAndSetArrayItem(1, "yScale");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(new XVar("displayMode", "single"), "tooltip");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", this.y_axis_label)), "yAxes");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			return null;
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			return "area";
		}
		protected virtual XVar getScales()
		{
			if(XVar.Pack(this.stacked))
			{
				dynamic arr = XVar.Array();
				arr = XVar.Clone(XVar.Array());
				arr.InitAndSetArrayItem("value", "stackMode");
				if(this.chrt_array["appearance"]["sstacked"] == "true")
				{
					arr.InitAndSetArrayItem("percent", "stackMode");
					arr.InitAndSetArrayItem("10", "maximumGap");
					arr.InitAndSetArrayItem("100", "maximum");
				}
				return new XVar(0, new XVar("names", XVar.Array()), 1, arr);
			}
			return XVar.Array();
		}
	}
	public partial class Chart_Pie : Chart
	{
		protected dynamic pie;
		protected static bool skipChart_PieCtor = false;
		public Chart_Pie(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_PieCtor)
			{
				skipChart_PieCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.pie = XVar.Clone(param["pie"]);
			this._2d = XVar.Clone(param["2d"]);
			this.singleSeries = new XVar(true);
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			dynamic series = XVar.Array();
			series = XVar.Clone(this.get_data());
			chart.InitAndSetArrayItem(series[0]["data"], "data");
			chart.InitAndSetArrayItem(series[0]["clickData"], "clickData");
			chart.InitAndSetArrayItem(true, "singleSeries");
			chart.InitAndSetArrayItem(series[0]["tooltip"], "tooltip");
			chart.InitAndSetArrayItem(false, "logarithm");
			if(XVar.Pack(this._2d))
			{
				chart.InitAndSetArrayItem("pie", "type");
			}
			else
			{
				chart.InitAndSetArrayItem("pie-3d", "type");
			}
			if(XVar.Pack(!(XVar)(this.pie)))
			{
				chart.InitAndSetArrayItem("30%", "innerRadius");
			}
			if((XVar)(this.chrt_array["appearance"]["slegend"] == "true")  && (XVar)(!(XVar)(this.chartPreview)))
			{
				chart.InitAndSetArrayItem(new XVar("enabled", "true"), "legend");
			}
			chart.InitAndSetArrayItem(new XVar("enabled", (XVar)(this.chrt_array["appearance"]["sval"] == "true")  || (XVar)(this.chrt_array["appearance"]["sname"] == "true")), "labels");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				if(XVar.Pack(this.chrt_array["appearance"]["sval"]))
				{
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color61"]), "labels", "fontColor");
				}
				else
				{
					if(XVar.Pack(this.chrt_array["appearance"]["sname"]))
					{
						chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "labels", "fontColor");
					}
				}
			}
			return null;
		}
	}
	public partial class Chart_Combined : Chart
	{
		protected static bool skipChart_CombinedCtor = false;
		public Chart_Combined(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_CombinedCtor)
			{
				skipChart_CombinedCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			chart.InitAndSetArrayItem("column", "type");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			chart.InitAndSetArrayItem(0, "xScale");
			chart.InitAndSetArrayItem(1, "yScale");
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", this.y_axis_label)), "yAxes");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			return null;
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			switch(((XVar)seriesNumber).ToInt())
			{
				case 0:
					return "spline";
					break;
				case 1:
					return "splineArea";
					break;
				default:
					return "column";
			}
			return null;
		}
		protected override XVar getLogarithm()
		{
			if(this.chrt_array["appearance"]["slog"] == "true")
			{
				return true;
			}
			return false;
		}
	}
	public partial class Chart_Funnel : Chart
	{
		protected dynamic inver;
		protected static bool skipChart_FunnelCtor = false;
		public Chart_Funnel(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_FunnelCtor)
			{
				skipChart_FunnelCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.inver = XVar.Clone(param["funnel_inv"]);
			this.singleSeries = new XVar(true);
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			dynamic series = XVar.Array();
			series = XVar.Clone(this.get_data());
			chart.InitAndSetArrayItem("pyramid", "type");
			chart.InitAndSetArrayItem(series[0]["data"], "data");
			chart.InitAndSetArrayItem(series[0]["clickData"], "clickData");
			chart.InitAndSetArrayItem(true, "singleSeries");
			chart.InitAndSetArrayItem(series[0]["tooltip"], "tooltip");
			chart.InitAndSetArrayItem(false, "logarithm");
			if(XVar.Pack(this.inver))
			{
				chart.InitAndSetArrayItem(true, "reversed");
			}
			chart.InitAndSetArrayItem(new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"), "labels");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "labels", "fontColor");
			}
			return null;
		}
	}
	public partial class Chart_Bubble : Chart
	{
		protected dynamic arrDataSize = XVar.Array();
		protected static bool skipChart_BubbleCtor = false;
		public Chart_Bubble(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_BubbleCtor)
			{
				skipChart_BubbleCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this._2d = XVar.Clone(param["2d"]);
		}
		protected override XVar setSpecParams(dynamic _param_params)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			base.setSpecParams((XVar)(var_params));
			if(var_params["name"] != "")
			{
				if(this.table_type != "db")
				{
					this.arrDataSize.InitAndSetArrayItem(var_params["size"], null);
				}
				else
				{
					this.arrDataSize.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["size"]), null);
				}
			}
			return null;
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			chart.InitAndSetArrayItem("cartesian", "type");
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", true, "title", this.y_axis_label, "labels", new XVar("enabled", this.chrt_array["appearance"]["sval"] == "true"))), "yAxes");
			if(this.chrt_array["appearance"]["color61"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color61"]), "yAxes", 0, "labels", "fontColor");
			}
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			return null;
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			return "bubble";
		}
		protected override XVar getPoint(dynamic _param_seriesNumber, dynamic _param_row)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic row = XVar.Clone(_param_row);
			#endregion

			dynamic pointData = XVar.Array();
			pointData = XVar.Clone(base.getPoint((XVar)(seriesNumber), (XVar)(row)));
			pointData.InitAndSetArrayItem((double)MVCFunctions.str_replace(new XVar(","), new XVar("."), (XVar)(row[this.arrDataSize[seriesNumber]])), "size");
			return pointData;
		}
	}
	public partial class Chart_Gauge : Chart
	{
		protected dynamic arrGaugeColor = XVar.Array();
		protected dynamic gaugeType = XVar.Pack("");
		protected dynamic layout = XVar.Pack("");
		protected static bool skipChart_GaugeCtor = false;
		public Chart_Gauge(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_GaugeCtor)
			{
				skipChart_GaugeCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.gaugeType = XVar.Clone(param["gaugeType"]);
			this.layout = XVar.Clone(param["layout"]);
		}
		protected override XVar setSpecParams(dynamic _param_params)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			base.setSpecParams((XVar)(var_params));
			if(var_params["name"] != "")
			{
				dynamic beginColor = null, endColor = null, gColor = null, k = null;
				k = new XVar(0);
				for(;(XVar)(MVCFunctions.is_array((XVar)(var_params["gaugeColorZone"])))  && (XVar)(k < MVCFunctions.count(var_params["gaugeColorZone"])); k++)
				{
					beginColor = XVar.Clone((double)var_params["gaugeColorZone"][k]["gaugeBeginColor"]);
					endColor = XVar.Clone((double)var_params["gaugeColorZone"][k]["gaugeEndColor"]);
					gColor = XVar.Clone(MVCFunctions.Concat("#", var_params["gaugeColorZone"][k]["gaugeColor"]));
					this.arrGaugeColor.InitAndSetArrayItem(new XVar(0, beginColor, 1, endColor, 2, gColor), MVCFunctions.count(this.arrDataSeries) - 1, null);
				}
			}
			return null;
		}
		public override XVar write()
		{
			dynamic chart = XVar.Array(), data = XVar.Array(), i = null;
			data = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrDataSeries); i++)
			{
				chart = XVar.Clone(XVar.Array());
				if(this.chrt_array["appearance"]["sanim"] == "true")
				{
					chart.InitAndSetArrayItem(new XVar("enabled", "true", "duration", 1000), "animation");
				}
				this.setGaugeSpecChartSettings((XVar)(chart), (XVar)(i));
				if((XVar)(this.chrt_array["appearance"]["color71"] != "")  || (XVar)(this.chrt_array["appearance"]["color91"] != ""))
				{
					chart.InitAndSetArrayItem(XVar.Array(), "background");
				}
				if(this.chrt_array["appearance"]["color71"] != "")
				{
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color71"]), "background", "fill");
				}
				if(this.chrt_array["appearance"]["color91"] != "")
				{
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color91"]), "background", "stroke");
				}
				if(XVar.Pack(this.noRecordsFound))
				{
					data.InitAndSetArrayItem(this.getNoDataMessage(), "noDataMessage");
					MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(data)));
					return null;
				}
				data.InitAndSetArrayItem(new XVar("gauge", chart), null);
			}
			MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(new XVar("gauge", data, "header", this.header, "footer", this.footer))));
			return null;
		}
		protected virtual XVar setGaugeSpecChartSettings(dynamic chart, dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			dynamic series = XVar.Array();
			series = XVar.Clone(this.get_data());
			chart.InitAndSetArrayItem(series[seriesNumber]["data"], "data");
			chart.InitAndSetArrayItem(this.gaugeType, "type");
			chart.InitAndSetArrayItem(this.layout, "layout");
			chart.InitAndSetArrayItem(new XVar(0, this.getAxesSettings((XVar)(seriesNumber))), "axes");
			chart.InitAndSetArrayItem(false, "credits");
			chart.InitAndSetArrayItem(this.getCircularGaugeLabel((XVar)(seriesNumber), (XVar)(chart["data"][0])), "chartLabels");
			if(this.gaugeType == "circular-gauge")
			{
				chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", true)), "needles");
				chart.InitAndSetArrayItem(this.getColorRanges((XVar)(seriesNumber)), "ranges");
			}
			else
			{
				dynamic hasColorZones = null, scalesData = XVar.Array();
				hasColorZones = XVar.Clone((XVar)(0 < MVCFunctions.count(this.arrGaugeColor))  && (XVar)(this.arrGaugeColor.KeyExists(seriesNumber)));
				chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", true, "pointerType", "marker", "type", (XVar.Pack(this.layout == "horizontal") ? XVar.Pack("triangleUp") : XVar.Pack("triangleLeft")), "name", "", "offset", (XVar.Pack(hasColorZones) ? XVar.Pack("20%") : XVar.Pack("10%")), "dataIndex", 0)), "pointers");
				if(XVar.Pack(hasColorZones))
				{
					foreach (KeyValuePair<XVar, dynamic> val in this.arrGaugeColor[seriesNumber].GetEnumerator())
					{
						chart.InitAndSetArrayItem(new XVar("enabled", true, "pointerType", "rangeBar", "name", "", "offset", "10%", "dataIndex", val.Key + 1, "color", val.Value[2]), "pointers", null);
					}
				}
				scalesData = XVar.Clone(this.getGaugeScales((XVar)(seriesNumber)));
				chart.InitAndSetArrayItem(0, "scale");
				chart.InitAndSetArrayItem(new XVar(0, new XVar("maximum", scalesData["max"], "minimum", scalesData["min"], "ticks", new XVar("interval", scalesData["interval"]), "minorTicks", new XVar("interval", scalesData["interval"] / 2))), "scales");
			}
			return null;
		}
		protected virtual XVar getCircularGaugeLabel(dynamic _param_seriesNumber, dynamic _param_pointData)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic pointData = XVar.Clone(_param_pointData);
			#endregion

			dynamic label = XVar.Array();
			label = XVar.Clone(new XVar("enabled", true, "vAlign", "center", "hAlign", "center", "text", this.getChartLabelText((XVar)(seriesNumber), (XVar)(pointData["value"]))));
			if(this.gaugeType == "circular-gauge")
			{
				label.InitAndSetArrayItem(-150, "offsetY");
				label.InitAndSetArrayItem("center", "anchor");
				label.InitAndSetArrayItem(new XVar("enabled", true, "fill", "#fff", "cornerType", "round", "corner", 0), "background");
				label.InitAndSetArrayItem(new XVar("top", 15, "right", 20, "bottom", 15, "left", 20), "padding");
			}
			return new XVar(0, label);
		}
		protected virtual XVar getColorRanges(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			dynamic ranges = XVar.Array();
			ranges = XVar.Clone(XVar.Array());
			if((XVar)(0 < MVCFunctions.count(this.arrGaugeColor))  && (XVar)(this.arrGaugeColor.KeyExists(seriesNumber)))
			{
				foreach (KeyValuePair<XVar, dynamic> val in this.arrGaugeColor[seriesNumber].GetEnumerator())
				{
					ranges.InitAndSetArrayItem(new XVar("radius", 70, "from", val.Value[0], "to", val.Value[1], "fill", val.Value[2], "endSize", "10%", "startSize", "10%"), null);
				}
			}
			return ranges;
		}
		protected virtual XVar getAxesSettings(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			dynamic axes = XVar.Array();
			axes = XVar.Clone(XVar.Array());
			if(this.gaugeType == "circular-gauge")
			{
				dynamic scalesData = XVar.Array();
				axes.InitAndSetArrayItem(-150, "startAngle");
				axes.InitAndSetArrayItem(300, "sweepAngle");
				scalesData = XVar.Clone(this.getGaugeScales((XVar)(seriesNumber)));
				axes.InitAndSetArrayItem(new XVar("maximum", scalesData["max"], "minimum", scalesData["min"], "ticks", new XVar("interval", scalesData["interval"]), "minorTicks", new XVar("interval", scalesData["interval"] / 2)), "scale");
				axes.InitAndSetArrayItem(new XVar("type", "trapezoid", "interval", scalesData["interval"]), "ticks");
				axes.InitAndSetArrayItem(new XVar("enabled", true, "length", 2), "minorTicks");
				if(this.chrt_array["appearance"]["color131"] != "")
				{
					axes.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "fill");
				}
			}
			axes.InitAndSetArrayItem(true, "enabled");
			axes.InitAndSetArrayItem(new XVar("enabled", this.chrt_array["appearance"]["sval"] == "true"), "labels");
			if(this.chrt_array["appearance"]["color61"] != "")
			{
				axes.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color61"]), "labels", "fontColor");
			}
			return axes;
		}
		protected virtual XVar getGaugeScales(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			dynamic diff = null, interval = null, max = null, min = null, muls = XVar.Array(), slog = null;
			min = XVar.Clone(this.chrt_array["parameters"][seriesNumber]["gaugeMinValue"]);
			max = XVar.Clone(this.chrt_array["parameters"][seriesNumber]["gaugeMaxValue"]);
			if(XVar.Pack(!(XVar)(MVCFunctions.IsNumeric(min))))
			{
				min = new XVar(0);
			}
			if(XVar.Pack(!(XVar)(MVCFunctions.IsNumeric(max))))
			{
				max = new XVar(100);
			}
			diff = XVar.Clone(max - min);
			slog = XVar.Clone((XVar)Math.Floor((double)((XVar)Math.Log10(diff))));
			interval = XVar.Clone((XVar)Math.Pow(10, slog - 2));
			muls = XVar.Clone(new XVar(0, 1, 1, 2, 2, 3, 3, 5, 4, 10));
			while(XVar.Pack(true))
			{
				foreach (KeyValuePair<XVar, dynamic> m in muls.GetEnumerator())
				{
					if(diff / (interval * m.Value) <= 10)
					{
						interval *= m.Value;
						break;
					}
				}
				if(diff / interval <= 10)
				{
					break;
				}
				interval *= 10;
			}
			return new XVar("min", min, "max", max, "interval", interval);
		}
		public override XVar getSubsetDataCommand(dynamic _param_ignoreFilterField = null)
		{
			#region default values
			if(_param_ignoreFilterField as Object == null) _param_ignoreFilterField = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic ignoreFilterField = XVar.Clone(_param_ignoreFilterField);
			#endregion

			dynamic dc = null;
			dc = XVar.Clone(base.getSubsetDataCommand());
			if(this.table_type == "project")
			{
				dynamic order = XVar.Array(), orderObject = null, revertedOrder = XVar.Array();
				orderObject = XVar.Clone(new OrderClause((XVar)(this.pSet), (XVar)(this.cipherer), (XVar)(this.sessionPrefix), (XVar)(this.connection)));
				order = XVar.Clone(orderObject.getOrderFields());
				revertedOrder = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> o in order.GetEnumerator())
				{
					dynamic ro = XVar.Array();
					ro = XVar.Clone(o.Value);
					ro.InitAndSetArrayItem((XVar.Pack(ro["dir"] == "ASC") ? XVar.Pack("DESC") : XVar.Pack("ASC")), "dir");
					revertedOrder.InitAndSetArrayItem(ro, null);
				}
				dc.order = XVar.Clone(revertedOrder);
			}
			return dc;
		}
		public override XVar get_data()
		{
			dynamic clickdata = XVar.Array(), data = XVar.Array(), dc = null, i = null, row = null, rs = null, series = XVar.Array();
			data = XVar.Clone(XVar.Array());
			dc = XVar.Clone(this.getSubsetDataCommand());
			this.beforeQueryEvent((XVar)(dc));
			rs = XVar.Clone(this.dataSource.getList((XVar)(dc)));
			if(XVar.Pack(!(XVar)(rs)))
			{
				MVCFunctions.showError((XVar)(this.dataSource.lastError()));
			}
			row = XVar.Clone(rs.fetchAssoc());
			if(XVar.Pack(this.cipherer))
			{
				row = XVar.Clone(this.cipherer.DecryptFetchedArray((XVar)(row)));
			}
			if(XVar.Pack(!(XVar)(row)))
			{
				this.noRecordsFound = new XVar(true);
			}
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrDataSeries); i++)
			{
				if(XVar.Pack(row))
				{
					data.InitAndSetArrayItem(XVar.Array(), i);
					data.InitAndSetArrayItem(this.getPoint((XVar)(i), (XVar)(row)), i, null);
				}
			}
			series = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrDataSeries); i++)
			{
				series.InitAndSetArrayItem(this.getSeriesData((XVar)(this.arrDataLabels[i]), (XVar)(data[i]), (XVar)(clickdata[i]), (XVar)(i), (XVar)(1 < MVCFunctions.count(this.arrDataSeries))), null);
			}
			return series;
		}
		protected override XVar getSeriesData(dynamic _param_name, dynamic _param_pointsData, dynamic _param_clickData, dynamic _param_seriesNumber, dynamic _param_multiSeries = null)
		{
			#region default values
			if(_param_multiSeries as Object == null) _param_multiSeries = new XVar(true);
			#endregion

			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			dynamic pointsData = XVar.Clone(_param_pointsData);
			dynamic clickData = XVar.Clone(_param_clickData);
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic multiSeries = XVar.Clone(_param_multiSeries);
			#endregion

			if((XVar)((XVar)(this.gaugeType == "linearGauge")  && (XVar)(0 < MVCFunctions.count(this.arrGaugeColor)))  && (XVar)(this.arrGaugeColor.KeyExists(seriesNumber)))
			{
				foreach (KeyValuePair<XVar, dynamic> val in this.arrGaugeColor[seriesNumber].GetEnumerator())
				{
					pointsData.InitAndSetArrayItem(new XVar("low", val.Value[0], "high", val.Value[1]), null);
				}
			}
			return new XVar("data", pointsData, "labelText", this.getChartLabelText((XVar)(seriesNumber), (XVar)(pointsData[0]["value"])));
		}
		protected virtual XVar getChartLabelText(dynamic _param_seriesNumber, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			if((XVar)(this.table_type == "project")  && (XVar)(!(XVar)(this.webchart)))
			{
				dynamic data = null, fieldName = null, viewControls = null, viewValue = null;
				fieldName = XVar.Clone(this.arrDataSeries[seriesNumber]);
				viewControls = XVar.Clone(new ViewControlsContainer((XVar)(this.pSet), new XVar(Constants.PAGE_CHART)));
				data = XVar.Clone(new XVar(fieldName, value));
				viewValue = XVar.Clone(viewControls.showDBValue((XVar)(fieldName), (XVar)(data), new XVar(""), new XVar(""), new XVar(false)));
				return MVCFunctions.Concat(this.arrDataLabels[seriesNumber], ": ", viewValue);
			}
			return MVCFunctions.Concat(this.arrDataLabels[seriesNumber], ": ", value);
		}
	}
	public partial class Chart_Ohlc : Chart
	{
		protected dynamic ohcl_type;
		protected dynamic arrOHLC_high = XVar.Array();
		protected dynamic arrOHLC_low = XVar.Array();
		protected dynamic arrOHLC_open = XVar.Array();
		protected dynamic arrOHLC_close = XVar.Array();
		protected static bool skipChart_OhlcCtor = false;
		public Chart_Ohlc(dynamic ch_array, dynamic _param_param)
			:base((XVar)ch_array, (XVar)_param_param)
		{
			if(skipChart_OhlcCtor)
			{
				skipChart_OhlcCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic param = XVar.Clone(_param_param);
			#endregion

			this.ohcl_type = XVar.Clone(param["ohcl_type"]);
		}
		protected override XVar setSpecParams(dynamic _param_params)
		{
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			if(this.table_type != "db")
			{
				this.arrOHLC_open.InitAndSetArrayItem(var_params["ohlcOpen"], null);
				this.arrOHLC_high.InitAndSetArrayItem(var_params["ohlcHigh"], null);
				this.arrOHLC_low.InitAndSetArrayItem(var_params["ohlcLow"], null);
				this.arrOHLC_close.InitAndSetArrayItem(var_params["ohlcClose"], null);
				return null;
			}
			if(XVar.Pack(var_params["agr_func"]))
			{
				this.arrOHLC_open.InitAndSetArrayItem(MVCFunctions.Concat(var_params["agr_func"], "_", var_params["table"], "_", var_params["ohlcOpen"]), null);
				this.arrOHLC_high.InitAndSetArrayItem(MVCFunctions.Concat(var_params["agr_func"], "_", var_params["table"], "_", var_params["ohlcHigh"]), null);
				this.arrOHLC_low.InitAndSetArrayItem(MVCFunctions.Concat(var_params["agr_func"], "_", var_params["table"], "_", var_params["ohlcLow"]), null);
				this.arrOHLC_close.InitAndSetArrayItem(MVCFunctions.Concat(var_params["agr_func"], "_", var_params["table"], "_", var_params["ohlcClose"]), null);
			}
			else
			{
				this.arrOHLC_open.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["ohlcOpen"]), null);
				this.arrOHLC_high.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["ohlcHigh"]), null);
				this.arrOHLC_low.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["ohlcLow"]), null);
				this.arrOHLC_close.InitAndSetArrayItem(MVCFunctions.Concat(var_params["table"], "_", var_params["ohlcClose"]), null);
			}
			return null;
		}
		public override XVar write()
		{
			dynamic chart = XVar.Array(), data = XVar.Array();
			data = XVar.Clone(XVar.Array());
			chart = XVar.Clone(XVar.Array());
			this.setTypeSpecChartSettings((XVar)(chart));
			if((XVar)(this.chrt_array["appearance"]["color71"] != "")  || (XVar)(this.chrt_array["appearance"]["color91"] != ""))
			{
				chart.InitAndSetArrayItem(XVar.Array(), "background");
			}
			if(this.chrt_array["appearance"]["color71"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color71"]), "background", "fill");
			}
			if(this.chrt_array["appearance"]["color91"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color91"]), "background", "stroke");
			}
			chart.InitAndSetArrayItem(false, "credits");
			chart.InitAndSetArrayItem(new XVar("enabled", "true", "text", this.header), "title");
			if(this.chrt_array["appearance"]["color101"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color101"]), "title", "fontColor");
			}
			if((XVar)(this.chrt_array["appearance"]["slegend"] == "true")  && (XVar)(!(XVar)(this.chartPreview)))
			{
				chart.InitAndSetArrayItem(new XVar("enabled", "true"), "legend");
			}
			data.InitAndSetArrayItem(chart, "chart");
			MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(data)));
			return null;
		}
		protected override XVar setTypeSpecChartSettings(dynamic chart)
		{
			chart.InitAndSetArrayItem(this.get_data(), "series");
			foreach (KeyValuePair<XVar, dynamic> var_params in this.chrt_array["parameters"].GetEnumerator())
			{
				if(var_params.Value["ohlcColor"] != "")
				{
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcColor"]), "series", var_params.Key, "fallingStroke");
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcColor"]), "series", var_params.Key, "fallingFill");
					if(this.ohcl_type == "ohcl")
					{
						chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcColor"]), "series", var_params.Key, "risingStroke");
						chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcColor"]), "series", var_params.Key, "risingFill");
					}
				}
				if((XVar)(var_params.Value["ohlcCandleColor"] != "")  && (XVar)(this.ohcl_type != "ohcl"))
				{
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcCandleColor"]), "series", var_params.Key, "risingStroke");
					chart.InitAndSetArrayItem(MVCFunctions.Concat("#", var_params.Value["ohlcCandleColor"]), "series", var_params.Key, "risingFill");
				}
			}
			chart.InitAndSetArrayItem(this.getGrids(), "grids");
			chart.InitAndSetArrayItem(base.getLogarithm(), "logarithm");
			chart.InitAndSetArrayItem("financial", "type");
			chart.InitAndSetArrayItem(0, "xScale");
			chart.InitAndSetArrayItem(1, "yScale");
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", this.y_axis_label, "labels", new XVar("enabled", this.chrt_array["appearance"]["sval"] == "true"))), "yAxes");
			if(this.chrt_array["appearance"]["color61"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color61"]), "yAxes", 0, "labels", "fontColor");
			}
			chart.InitAndSetArrayItem(new XVar(0, new XVar("enabled", "true", "title", new XVar("text", this.footer), "labels", new XVar("enabled", this.chrt_array["appearance"]["sname"] == "true"))), "xAxes");
			if(this.chrt_array["appearance"]["color51"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color51"]), "xAxes", 0, "labels", "fontColor");
			}
			if(this.chrt_array["appearance"]["color111"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color111"]), "xAxes", 0, "title", "fontColor");
			}
			if(this.chrt_array["appearance"]["color131"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color131"]), "xAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["color141"] != "")
			{
				chart.InitAndSetArrayItem(MVCFunctions.Concat("#", this.chrt_array["appearance"]["color141"]), "yAxes", 0, "stroke");
			}
			if(this.chrt_array["appearance"]["slog"] == "true")
			{
				chart.InitAndSetArrayItem(new XVar(0, new XVar("names", XVar.Array()), 1, new XVar("logBase", 10, "type", "log")), "scales");
			}
			return null;
		}
		public override XVar get_data()
		{
			dynamic clickdata = XVar.Array(), data = XVar.Array(), dc = null, i = null, row = null, rs = null, series = XVar.Array(), strLabelFormat = null;
			data = XVar.Clone(XVar.Array());
			clickdata = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrOHLC_open); i++)
			{
				data.InitAndSetArrayItem(XVar.Array(), i);
				clickdata.InitAndSetArrayItem(XVar.Array(), i);
			}
			dc = XVar.Clone(this.getSubsetDataCommand());
			this.beforeQueryEvent((XVar)(dc));
			rs = XVar.Clone(this.dataSource.getList((XVar)(dc)));
			if(XVar.Pack(!(XVar)(rs)))
			{
				MVCFunctions.showError((XVar)(this.dataSource.lastError()));
			}
			row = XVar.Clone(rs.fetchAssoc());
			if(XVar.Pack(this.cipherer))
			{
				row = XVar.Clone(this.cipherer.DecryptFetchedArray((XVar)(row)));
			}
			if(XVar.Pack(!(XVar)(row)))
			{
				this.noRecordsFound = new XVar(true);
			}
			while(XVar.Pack(row))
			{
				i = new XVar(0);
				for(;i < MVCFunctions.count(this.arrOHLC_open); i++)
				{
					data.InitAndSetArrayItem(this.getPoint((XVar)(i), (XVar)(row)), i, null);
					strLabelFormat = XVar.Clone(this.labelFormat((XVar)(this.strLabel), (XVar)(row)));
					clickdata.InitAndSetArrayItem(this.getActions((XVar)(row), (XVar)(this.arrDataSeries[i]), (XVar)(strLabelFormat)), i, null);
				}
				row = XVar.Clone(rs.fetchAssoc());
				if(XVar.Pack(this.cipherer))
				{
					row = XVar.Clone(this.cipherer.DecryptFetchedArray((XVar)(row)));
				}
			}
			series = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < MVCFunctions.count(this.arrOHLC_open); i++)
			{
				series.InitAndSetArrayItem(this.getSeriesData((XVar)(this.arrDataLabels[i]), (XVar)(data[i]), (XVar)(clickdata[i]), (XVar)(i)), null);
			}
			return series;
		}
		protected override XVar getSeriesType(dynamic _param_seriesNumber)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			#endregion

			if(this.ohcl_type == "ohcl")
			{
				return "ohlc";
			}
			return "candlestick";
		}
		protected override XVar getSeriesTooltip(dynamic _param_multiSeries)
		{
			#region pass-by-value parameters
			dynamic multiSeries = XVar.Clone(_param_multiSeries);
			#endregion

			dynamic tooltipSettings = null;
			tooltipSettings = XVar.Clone(new XVar("enabled", true));
			return tooltipSettings;
		}
		protected override XVar getPoint(dynamic _param_seriesNumber, dynamic _param_row)
		{
			#region pass-by-value parameters
			dynamic seriesNumber = XVar.Clone(_param_seriesNumber);
			dynamic row = XVar.Clone(_param_row);
			#endregion

			dynamic close = null, high = null, low = null, open = null;
			if((XVar)(this.table_type != "db")  || (XVar)(!(XVar)(this.chrt_array["customLabels"])))
			{
				high = XVar.Clone(row[this.arrOHLC_high[seriesNumber]]);
				low = XVar.Clone(row[this.arrOHLC_low[seriesNumber]]);
				open = XVar.Clone(row[this.arrOHLC_open[seriesNumber]]);
				close = XVar.Clone(row[this.arrOHLC_close[seriesNumber]]);
			}
			else
			{
				high = XVar.Clone(row[this.chrt_array["customLabels"][this.arrOHLC_high[seriesNumber]]]);
				low = XVar.Clone(row[this.chrt_array["customLabels"][this.arrOHLC_low[seriesNumber]]]);
				open = XVar.Clone(row[this.chrt_array["customLabels"][this.arrOHLC_open[seriesNumber]]]);
				close = XVar.Clone(row[this.chrt_array["customLabels"][this.arrOHLC_close[seriesNumber]]]);
			}
			return new XVar("x", this.labelFormat((XVar)(this.strLabel), (XVar)(row)), "open", (double)open, "high", (double)high, "low", (double)low, "close", (double)MVCFunctions.str_replace(new XVar(","), new XVar("."), (XVar)(close)));
		}
	}
}
