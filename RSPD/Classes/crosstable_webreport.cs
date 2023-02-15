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
	public partial class CrossTableWebReport : XClass
	{
		public dynamic tableName;
		public dynamic shortTableName;
		public dynamic col_summary = XVar.Array();
		public dynamic group_header = XVar.Array();
		public dynamic rowinfo = XVar.Array();
		public dynamic total_summary;
		public dynamic xml_array;
		public dynamic is_value_empty;
		public dynamic pageType;
		public dynamic arrDBFieldsList = XVar.Array();
		public dynamic wrdb = XVar.Pack(false);
		public dynamic index_field_x;
		public dynamic index_field_y;
		protected dynamic table_type = XVar.Pack("project");
		protected ProjectSettings pSet = null;
		protected dynamic dataFieldSettings = XVar.Pack(null);
		protected dynamic dataField = XVar.Pack("");
		protected dynamic dataGroupFunction = XVar.Pack("");
		protected dynamic tableKeys = XVar.Pack(null);
		protected dynamic connection;
		protected dynamic sessionPrefix;
		protected dynamic dashBased = XVar.Pack(false);
		protected dynamic dashTName = XVar.Pack("");
		protected dynamic groupFieldsData;
		protected dynamic sortFields;
		public CrossTableWebReport(dynamic _param_rpt_array, dynamic _param_strSQL)
		{
			#region pass-by-value parameters
			dynamic rpt_array = XVar.Clone(_param_rpt_array);
			dynamic strSQL = XVar.Clone(_param_strSQL);
			#endregion

			dynamic arravgcount = XVar.Array(), arravgsum = XVar.Array(), arrdata = XVar.Array(), avgcountx = XVar.Array(), avgsumx = XVar.Array(), data = XVar.Array(), fName = null, ftype = null, group_x = XVar.Array(), group_y = XVar.Array(), key_x = null, key_y = null, qResult = null, sort_y = XVar.Array(), sum_total = null, sum_x = null, sum_y = null;
			this.xml_array = XVar.Clone(rpt_array);
			if(XVar.Pack(rpt_array["table_type"]))
			{
				this.table_type = XVar.Clone(rpt_array["table_type"]);
			}
			this.wrdb = XVar.Clone(rpt_array["wrdb"]);
			this.arrDBFieldsList = XVar.Clone(rpt_array["arrDBFieldsList"]);
			this.pageType = XVar.Clone(rpt_array["pageType"]);
			this.tableName = XVar.Clone(this.xml_array["tables"][0]);
			this.setDbConnection();
			this.shortTableName = XVar.Clone(CommonFunctions.GetTableURL((XVar)(this.tableName)));
			if(MVCFunctions.strlen((XVar)(this.shortTableName)) == 0)
			{
				this.shortTableName = XVar.Clone(this.tableName);
			}
			this.pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(this.tableName), new XVar(Constants.PAGE_REPORT)));
			this.setSessionPrefix((XVar)(rpt_array["sessionPrefix"]));
			this.fillSessionVariables();
			this.dataField = XVar.Clone(this.getDataField((XVar)(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_field")])));
			if(XVar.Pack(!(XVar)(MVCFunctions.strlen((XVar)(this.dataField)))))
			{
				this.dataField = XVar.Clone(XSession.Session["webreports"]["group_fields"][0]["name"]);
			}
			this.initDataFieldSettings();
			this.initDataGroupFunction((XVar)(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_group_func")]));
			this.setAxisFieldsIndices();
			fName = XVar.Clone(this.getDBFieldName((XVar)(this.CrossGoodFieldName((XVar)(this.dataField)))));
			if(fName != " ")
			{
				ftype = XVar.Clone(this.getFieldType((XVar)(fName)));
			}
			group_y = XVar.Clone(XVar.Array());
			group_x = XVar.Clone(XVar.Array());
			sort_y = XVar.Clone(XVar.Array());
			arrdata = XVar.Clone(XVar.Array());
			arravgsum = XVar.Clone(XVar.Array());
			arravgcount = XVar.Clone(XVar.Array());
			avgsumx = XVar.Clone(XVar.Array());
			avgcountx = XVar.Clone(XVar.Array());
			this.groupFieldsData = XVar.Clone(rpt_array["group_fields"]);
			this.sortFields = XVar.Clone(rpt_array["sort_fields"]);
			if(XVar.Pack(CommonFunctions.is_wr_project()))
			{
				dynamic dataSource = null;
				dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(this.tableName)));
				qResult = XVar.Clone(dataSource.getTotals((XVar)(this.getProjectWRCommand())));
			}
			else
			{
				dynamic crtableSQL = null;
				crtableSQL = XVar.Clone(this.getstrSQL((XVar)(strSQL)));
				qResult = XVar.Clone(this.connection.query((XVar)(crtableSQL)));
			}
			while(XVar.Pack(data = XVar.Clone(qResult.fetchNumeric())))
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.in_array((XVar)(data[1]), (XVar)(group_y)))))
				{
					group_y.InitAndSetArrayItem(data[1], null);
					sort_y.InitAndSetArrayItem(CommonFunctions.pre8count((XVar)(sort_y)), null);
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.in_array((XVar)(data[2]), (XVar)(group_x)))))
				{
					group_x.InitAndSetArrayItem(data[2], null);
					this.col_summary.InitAndSetArrayItem("&nbsp;", "data", CommonFunctions.pre8count((XVar)(group_x)) - 1, "col_summary");
					this.col_summary.InitAndSetArrayItem(MVCFunctions.Concat("total_x_", CommonFunctions.pre8count((XVar)(group_x)) - 1), "data", CommonFunctions.pre8count((XVar)(group_x)) - 1, "id_col_summary");
				}
				key_y = XVar.Clone(MVCFunctions.array_search((XVar)(data[1]), (XVar)(group_y)));
				key_x = XVar.Clone(MVCFunctions.array_search((XVar)(data[2]), (XVar)(group_x)));
				avgsumx.InitAndSetArrayItem(0, key_x);
				avgcountx.InitAndSetArrayItem(0, key_x);
				if(XVar.Pack(!(XVar)(this.is_value_empty)))
				{
					arrdata.InitAndSetArrayItem(data[0], key_y, key_x);
					arravgsum.InitAndSetArrayItem(data[3], key_y, key_x);
					arravgcount.InitAndSetArrayItem(data[4], key_y, key_x);
				}
				else
				{
					arrdata.InitAndSetArrayItem("&nbsp;", key_y, key_x);
				}
			}
			GlobalVars.group_sort_y = XVar.Clone(group_y);
			MVCFunctions.SortForCrossTable((XVar)(sort_y));
			foreach (KeyValuePair<XVar, dynamic> _key_y in sort_y.GetEnumerator())
			{
				dynamic value_y = null;
				value_y = XVar.Clone(group_y[_key_y.Value]);
				this.rowinfo.InitAndSetArrayItem("&nbsp;", _key_y.Value, "row_summary");
				this.rowinfo.InitAndSetArrayItem(this.getAxisDisplayValue((XVar)(this.index_field_y), (XVar)(value_y)), _key_y.Value, "group_y");
				foreach (KeyValuePair<XVar, dynamic> value_x in group_x.GetEnumerator())
				{
					if(XVar.Pack(arrdata.KeyExists(_key_y.Value)))
					{
						dynamic rowValue = null;
						rowValue = new XVar("&nbsp;");
						if((XVar)((XVar)(arrdata[_key_y.Value].KeyExists(value_x.Key))  && (XVar)(!(XVar)(this.is_value_empty)))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(arrdata[_key_y.Value][value_x.Key]), XVar.Pack(null)))))
						{
							rowValue = XVar.Clone(arrdata[_key_y.Value][value_x.Key]);
							if((XVar)(this.dataGroupFunction == "avg")  && (XVar)(!(XVar)(CommonFunctions.IsTimeType((XVar)(ftype)))))
							{
								rowValue = XVar.Clone((XVar)Math.Round((double)(rowValue), 2));
							}
						}
						this.rowinfo.InitAndSetArrayItem(rowValue, _key_y.Value, "row_record", "data", value_x.Key, "row_value");
						this.rowinfo.InitAndSetArrayItem(MVCFunctions.Concat(_key_y.Value, "_", value_x.Key), _key_y.Value, "row_record", "data", value_x.Key, "id_data");
					}
				}
				this.rowinfo.InitAndSetArrayItem(MVCFunctions.Concat("total_y_", _key_y.Value), _key_y.Value, "id_row_summary");
			}
			foreach (KeyValuePair<XVar, dynamic> value_x in group_x.GetEnumerator())
			{
				if(value_x.Value != XVar.Pack(""))
				{
					this.group_header.InitAndSetArrayItem(this.getAxisDisplayValue((XVar)(this.index_field_x), (XVar)(value_x.Value)), "data", value_x.Key, "gr_value");
				}
				else
				{
					this.group_header.InitAndSetArrayItem("&nbsp;", "data", value_x.Key, "gr_value");
				}
			}
			sum_x = XVar.Clone(this.xml_array["group_fields"][CommonFunctions.pre8count((XVar)(this.xml_array["group_fields"])) - 1]["sum_x"]);
			sum_y = XVar.Clone(this.xml_array["group_fields"][CommonFunctions.pre8count((XVar)(this.xml_array["group_fields"])) - 1]["sum_y"]);
			sum_total = XVar.Clone(this.xml_array["group_fields"][CommonFunctions.pre8count((XVar)(this.xml_array["group_fields"])) - 1]["sum_total"]);
			this.total_summary = new XVar("&nbsp;");
			foreach (KeyValuePair<XVar, dynamic> obj_y in this.rowinfo.GetEnumerator())
			{
				dynamic obj_x = XVar.Array();
				obj_x = XVar.Clone(obj_y.Value["row_record"]["data"]);
				foreach (KeyValuePair<XVar, dynamic> value in obj_x.GetEnumerator())
				{
					if(!XVar.Equals(XVar.Pack(value.Value["row_value"]), XVar.Pack("&nbsp;")))
					{
						switch(((XVar)this.dataGroupFunction).ToString())
						{
							case "sum":
								if(XVar.Pack(!(XVar)(XVar.Equals(XVar.Pack(value.Value["row_value"]), XVar.Pack(null)))))
								{
									this.rowinfo[obj_y.Key]["row_summary"] += value.Value["row_value"];
									this.col_summary["data"][value.Key]["col_summary"] += value.Value["row_value"];
									this.total_summary += value.Value["row_value"];
								}
								break;
							case "min":
								if((XVar)((XVar)(XVar.Equals(XVar.Pack(this.rowinfo[obj_y.Key]["row_summary"]), XVar.Pack("&nbsp;")))  || (XVar)(value.Value["row_value"] < this.rowinfo[obj_y.Key]["row_summary"]))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(value.Value["row_value"]), XVar.Pack(null)))))
								{
									this.rowinfo.InitAndSetArrayItem(value.Value["row_value"], obj_y.Key, "row_summary");
								}
								if((XVar)((XVar)(XVar.Equals(XVar.Pack(this.col_summary["data"][value.Key]["col_summary"]), XVar.Pack("&nbsp;")))  || (XVar)(value.Value["row_value"] < this.col_summary["data"][value.Key]["col_summary"]))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(value.Value["row_value"]), XVar.Pack(null)))))
								{
									this.col_summary.InitAndSetArrayItem(value.Value["row_value"], "data", value.Key, "col_summary");
								}
								if((XVar)((XVar)(XVar.Equals(XVar.Pack(this.total_summary), XVar.Pack("&nbsp;")))  || (XVar)(value.Value["row_value"] < this.total_summary))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(value.Value["row_value"]), XVar.Pack(null)))))
								{
									this.total_summary = XVar.Clone(value.Value["row_value"]);
								}
								break;
							case "max":
								if((XVar)(XVar.Equals(XVar.Pack(this.rowinfo[obj_y.Key]["row_summary"]), XVar.Pack("&nbsp;")))  || (XVar)(this.rowinfo[obj_y.Key]["row_summary"] < value.Value["row_value"]))
								{
									this.rowinfo.InitAndSetArrayItem(value.Value["row_value"], obj_y.Key, "row_summary");
								}
								if((XVar)(XVar.Equals(XVar.Pack(this.col_summary["data"][value.Key]["col_summary"]), XVar.Pack("&nbsp;")))  || (XVar)(this.col_summary["data"][value.Key]["col_summary"] < value.Value["row_value"]))
								{
									this.col_summary.InitAndSetArrayItem(value.Value["row_value"], "data", value.Key, "col_summary");
								}
								if((XVar)(XVar.Equals(XVar.Pack(this.total_summary), XVar.Pack("&nbsp;")))  || (XVar)(this.total_summary < value.Value["row_value"]))
								{
									this.total_summary = XVar.Clone(value.Value["row_value"]);
								}
								break;
							case "avg":
								this.rowinfo[obj_y.Key]["avgsumy"] += arravgsum[obj_y.Key][value.Key];
								this.rowinfo[obj_y.Key]["avgcounty"] += arravgcount[obj_y.Key][value.Key];
								this.rowinfo[obj_y.Key]["row_record"]["data"][value.Key]["avgsumx"] += arravgsum[obj_y.Key][value.Key];
								this.rowinfo[obj_y.Key]["row_record"]["data"][value.Key]["avgcountx"] += arravgcount[obj_y.Key][value.Key];
								break;
						}
						if((XVar)((XVar)(sum_x == true)  && (XVar)(!(XVar)(this.is_value_empty)))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(this.col_summary["data"][value.Key]["col_summary"]), XVar.Pack(null)))))
						{
							if(XVar.Pack(MVCFunctions.IsNumeric(this.col_summary["data"][value.Key]["col_summary"])))
							{
								this.col_summary.InitAndSetArrayItem((XVar)Math.Round((double)(this.col_summary["data"][value.Key]["col_summary"]), 2), "data", value.Key, "col_summary");
							}
						}
						else
						{
							this.col_summary.InitAndSetArrayItem("&nbsp;", "data", value.Key, "col_summary");
						}
					}
				}
				if((XVar)((XVar)(sum_y == true)  && (XVar)(!(XVar)(this.is_value_empty)))  && (XVar)(!(XVar)(XVar.Equals(XVar.Pack(this.rowinfo[obj_y.Key]["row_summary"]), XVar.Pack(null)))))
				{
					if(XVar.Pack(MVCFunctions.IsNumeric(this.rowinfo[obj_y.Key]["row_summary"])))
					{
						this.rowinfo.InitAndSetArrayItem((XVar)Math.Round((double)(this.rowinfo[obj_y.Key]["row_summary"]), 2), obj_y.Key, "row_summary");
					}
				}
				else
				{
					this.rowinfo.InitAndSetArrayItem("&nbsp;", obj_y.Key, "row_summary");
				}
			}
			if(this.dataGroupFunction == "avg")
			{
				dynamic total_count = null, total_sum = null;
				total_sum = new XVar(0);
				total_count = new XVar(0);
				foreach (KeyValuePair<XVar, dynamic> valuey in this.rowinfo.GetEnumerator())
				{
					if(XVar.Pack(valuey.Value["avgcounty"]))
					{
						this.rowinfo.InitAndSetArrayItem((XVar)Math.Round((double)(valuey.Value["avgsumy"] / valuey.Value["avgcounty"]), 2), valuey.Key, "row_summary");
						total_sum += valuey.Value["avgsumy"];
						total_count += valuey.Value["avgcounty"];
					}
					foreach (KeyValuePair<XVar, dynamic> valuex in valuey.Value["row_record"]["data"].GetEnumerator())
					{
						if(XVar.Pack(valuex.Value["avgcountx"]))
						{
							avgsumx[valuex.Key] += valuex.Value["avgsumx"];
							avgcountx[valuex.Key] += valuex.Value["avgcountx"];
							total_sum += valuex.Value["avgsumx"];
							total_count += valuex.Value["avgcountx"];
						}
					}
				}
				foreach (KeyValuePair<XVar, dynamic> value in avgsumx.GetEnumerator())
				{
					if(XVar.Pack(avgcountx[value.Key]))
					{
						this.col_summary.InitAndSetArrayItem((XVar)Math.Round((double)(value.Value / avgcountx[value.Key]), 2), "data", value.Key, "col_summary");
					}
				}
				if(XVar.Pack(total_count))
				{
					this.total_summary = XVar.Clone(total_sum / total_count);
				}
			}
			if((XVar)(sum_total != true)  || (XVar)(this.is_value_empty))
			{
				this.total_summary = new XVar("&nbsp;");
			}
			else
			{
				if(XVar.Pack(MVCFunctions.IsNumeric(this.total_summary)))
				{
					this.total_summary = XVar.Clone((XVar)Math.Round((double)(this.total_summary), 2));
				}
			}
			this.updateRecordsDisplayedFields();
		}
		protected virtual XVar getProjectWRCommand()
		{
			dynamic BeforeQueryReport = null, BeforeQueryReportPrint = null, arr = XVar.Array(), axis_x = null, axis_y = null, dc = null, ftype = null, i = null, xFName = null, xIntervalType = null, xType = null, yFName = null, yIntervalType = null, yType = null;
			dc = XVar.Clone(CommonFunctions.getProjectWRSubsetDataCommand((XVar)(this.tableName), (XVar)(this.sortFields), (XVar)(this.pSet)));
			ftype = XVar.Clone(this.pSet.getFieldType((XVar)(this.dataField)));
			axis_x = XVar.Clone(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_x")]);
			axis_y = XVar.Clone(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_y")]);
			xFName = XVar.Clone(this.getGroupFieldByParam(new XVar("x"), (XVar)(axis_x)));
			yFName = XVar.Clone(this.getGroupFieldByParam(new XVar("y"), (XVar)(axis_y), (XVar)(xFName)));
			arr = XVar.Clone(this.xml_array["group_fields"]);
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(arr)) - 1; i++)
			{
				if((XVar)(xFName == arr[i]["name"])  && (XVar)(this.index_field_x == i))
				{
					xType = XVar.Clone(arr[i]["int_type"]);
					break;
				}
			}
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(arr)) - 1; i++)
			{
				if((XVar)(yFName == arr[i]["name"])  && (XVar)(this.index_field_y == i))
				{
					yType = XVar.Clone(arr[i]["int_type"]);
					break;
				}
			}
			xIntervalType = XVar.Clone(this.getIntervalTypeByParam(new XVar("x"), (XVar)(xFName), (XVar)(xType)));
			yIntervalType = XVar.Clone(this.getIntervalTypeByParam(new XVar("y"), (XVar)(yFName), (XVar)(yType)));
			dc.totals.InitAndSetArrayItem(new XVar("field", this.dataField, "total", this.dataGroupFunction, "timeToSec", (XVar)(this.pSet.getViewFormat((XVar)(this.dataField)) == Constants.FORMAT_TIME)  || (XVar)(CommonFunctions.IsTimeType((XVar)(ftype)))), null);
			dc.totals.InitAndSetArrayItem(new XVar("field", yFName, "modifier", yIntervalType, "direction", this.getGroupOrderDirection((XVar)(yFName))), null);
			dc.totals.InitAndSetArrayItem(new XVar("field", xFName, "modifier", xIntervalType), null);
			if((XVar)(this.dataGroupFunction == "avg")  && (XVar)(!(XVar)(CommonFunctions.IsDateFieldType((XVar)(ftype)))))
			{
				dc.totals.InitAndSetArrayItem(new XVar("field", this.dataField, "alias", "avg_sum", "total", "sum"), null);
				dc.totals.InitAndSetArrayItem(new XVar("field", this.dataField, "alias", "avg_count", "total", "count"), null);
			}
			else
			{
				dc.totals.InitAndSetArrayItem(new XVar("alias", "avg_sum", "total", "count"), null);
				dc.totals.InitAndSetArrayItem(new XVar("alias", "avg_count", "total", "count"), null);
			}
			BeforeQueryReport = XVar.Clone((XVar)(this.pageType == Constants.PAGE_REPORT)  && (XVar)(CommonFunctions.tableEventExists(new XVar("BeforeQueryReport"), (XVar)(this.tableName))));
			BeforeQueryReportPrint = XVar.Clone((XVar)(this.pageType == Constants.PAGE_RPRINT)  && (XVar)(CommonFunctions.tableEventExists(new XVar("BeforeQueryReportPrint"), (XVar)(this.tableName))));
			if((XVar)(BeforeQueryReport)  || (XVar)(BeforeQueryReportPrint))
			{
				dynamic dataSource = null, eventObj = null, prep = XVar.Array(), where = null;
				dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(this.tableName)));
				prep = XVar.Clone(dataSource.prepareSQL((XVar)(dc)));
				where = XVar.Clone(prep["where"]);
				eventObj = XVar.Clone(CommonFunctions.getEventObject((XVar)(this.tableName)));
				if(XVar.Pack(BeforeQueryReport))
				{
					eventObj.BeforeQueryReport((XVar)(where));
				}
				else
				{
					eventObj.BeforeQueryReportPrint((XVar)(where));
				}
				if(where != prep["where"])
				{
					dataSource.overrideWhere((XVar)(dc), (XVar)(where));
				}
			}
			return dc;
		}
		protected virtual XVar getGroupOrderDirection(dynamic _param_fName)
		{
			#region pass-by-value parameters
			dynamic fName = XVar.Clone(_param_fName);
			#endregion

			dynamic fieldIdx = null, orderIndices = XVar.Array();
			orderIndices = this.pSet.getOrderIndexes();
			fieldIdx = XVar.Clone(this.pSet.getFieldIndex((XVar)(fName)));
			foreach (KeyValuePair<XVar, dynamic> o in orderIndices.GetEnumerator())
			{
				if(o.Value[0] == fieldIdx)
				{
					return o.Value[1];
				}
			}
			return "ASC";
		}
		protected virtual XVar getGroupFieldByParam(dynamic _param_axis, dynamic _param_paramField, dynamic _param_otherField = null)
		{
			#region default values
			if(_param_otherField as Object == null) _param_otherField = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic axis = XVar.Clone(_param_axis);
			dynamic paramField = XVar.Clone(_param_paramField);
			dynamic otherField = XVar.Clone(_param_otherField);
			#endregion

			dynamic firstField = null;
			firstField = new XVar("");
			foreach (KeyValuePair<XVar, dynamic> fData in this.groupFieldsData.GetEnumerator())
			{
				if((XVar)(fData.Value["group_type"] == "all")  || (XVar)(fData.Value["group_type"] == axis))
				{
					if(fData.Value["name"] == paramField)
					{
						return paramField;
					}
					if((XVar)(XVar.Equals(XVar.Pack(firstField), XVar.Pack("")))  && (XVar)((XVar)(!(XVar)(otherField))  || (XVar)(!XVar.Equals(XVar.Pack(otherField), XVar.Pack(firstField)))))
					{
						firstField = XVar.Clone(fData.Value["name"]);
					}
				}
			}
			return firstField;
		}
		protected virtual XVar getIntervalTypeByParam(dynamic _param_axis, dynamic _param_crossName, dynamic _param_userIntType)
		{
			#region pass-by-value parameters
			dynamic axis = XVar.Clone(_param_axis);
			dynamic crossName = XVar.Clone(_param_crossName);
			dynamic userIntType = XVar.Clone(_param_userIntType);
			#endregion

			dynamic iType = null, intTypes = XVar.Array(), int_type = null;
			iType = XVar.Clone(this.getRefineIntervalType((XVar)(userIntType), (XVar)(crossName)));
			int_type = XVar.Clone(-1);
			intTypes = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> fData in this.groupFieldsData.GetEnumerator())
			{
				if((XVar)(fData.Value["name"] == crossName)  && (XVar)((XVar)(fData.Value["group_type"] == "all")  || (XVar)(fData.Value["group_type"] == axis)))
				{
					if((XVar)(!(XVar)(MVCFunctions.strlen((XVar)(userIntType))))  || (XVar)(iType == fData.Value["int_type"]))
					{
						int_type = XVar.Clone(fData.Value["int_type"]);
						break;
					}
					intTypes.InitAndSetArrayItem(fData.Value["int_type"], null);
				}
			}
			if(int_type != -1)
			{
				return int_type;
			}
			if(0 < CommonFunctions.pre8count((XVar)(intTypes)))
			{
				return intTypes[0];
			}
			return 0;
		}
		protected virtual XVar getRefineIntervalType(dynamic _param_intType, dynamic _param_fName)
		{
			#region pass-by-value parameters
			dynamic intType = XVar.Clone(_param_intType);
			dynamic fName = XVar.Clone(_param_fName);
			#endregion

			dynamic ftype = null;
			if(XVar.Equals(XVar.Pack(intType), XVar.Pack(0)))
			{
				return "normal";
			}
			ftype = XVar.Clone(this.pSet.getFieldType((XVar)(fName)));
			if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
			{
				return MVCFunctions.substr((XVar)(intType), new XVar(1));
			}
			if(XVar.Pack(CommonFunctions.IsCharType((XVar)(ftype))))
			{
				return MVCFunctions.substr((XVar)(intType), (XVar)(MVCFunctions.strlen(new XVar("first"))));
			}
			if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
			{
				switch(((XVar)intType).ToString())
				{
					case "year":
						return 1;
					case "quarter":
						return 2;
					case "month":
						return 3;
					case "week":
						return 4;
					case "day":
						return 5;
					case "hour":
						return 6;
					case "minute":
						return 7;
				}
			}
			return -1;
		}
		protected virtual XVar updateRecordsDisplayedFields()
		{
			if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(this.rowinfo)))))
			{
				return null;
			}
			this.updateWebReportRecordsDisplayedFields();
			return null;
		}
		protected virtual XVar updateWebReportRecordsDisplayedFields()
		{
			if(this.dataFieldSettings["curr"] != true)
			{
				return null;
			}
			foreach (KeyValuePair<XVar, dynamic> arrfield in this.rowinfo.GetEnumerator())
			{
				foreach (KeyValuePair<XVar, dynamic> fieldvalue in arrfield.Value["row_record"]["data"].GetEnumerator())
				{
					if(XVar.Pack(MVCFunctions.IsNumeric(fieldvalue.Value["row_value"])))
					{
						this.rowinfo.InitAndSetArrayItem(CommonFunctions.str_format_currency((XVar)(fieldvalue.Value["row_value"])), arrfield.Key, "row_record", "data", fieldvalue.Key, "row_value");
					}
				}
				if(XVar.Pack(MVCFunctions.IsNumeric(arrfield.Value["row_summary"])))
				{
					this.rowinfo.InitAndSetArrayItem(CommonFunctions.str_format_currency((XVar)(arrfield.Value["row_summary"])), arrfield.Key, "row_summary");
				}
			}
			if(XVar.Pack(MVCFunctions.IsNumeric(this.total_summary)))
			{
				this.total_summary = XVar.Clone(CommonFunctions.str_format_currency((XVar)(this.total_summary)));
			}
			foreach (KeyValuePair<XVar, dynamic> arrvalue in this.col_summary["data"].GetEnumerator())
			{
				if(XVar.Pack(MVCFunctions.IsNumeric(arrvalue.Value["col_summary"])))
				{
					this.col_summary.InitAndSetArrayItem(CommonFunctions.str_format_currency((XVar)(arrvalue.Value["col_summary"])), "data", arrvalue.Key, "col_summary");
				}
			}
			return null;
		}
		protected virtual XVar setSessionPrefix(dynamic _param_sessionPrefix = null)
		{
			#region default values
			if(_param_sessionPrefix as Object == null) _param_sessionPrefix = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic sessionPrefix = XVar.Clone(_param_sessionPrefix);
			#endregion

			if(XVar.Pack(sessionPrefix))
			{
				this.sessionPrefix = XVar.Clone(sessionPrefix);
			}
			else
			{
				this.sessionPrefix = XVar.Clone(this.shortTableName);
			}
			return null;
		}
		protected virtual XVar fillSessionVariables()
		{
			if(MVCFunctions.postvalue(new XVar("operation")) != "")
			{
				XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_group_func")] = MVCFunctions.postvalue(new XVar("operation"));
			}
			if(MVCFunctions.postvalue(new XVar("field")) != "")
			{
				XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_field")] = MVCFunctions.postvalue(new XVar("field"));
			}
			if(MVCFunctions.postvalue(new XVar("axis_x")) != "")
			{
				XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_x")] = MVCFunctions.postvalue(new XVar("axis_x"));
			}
			if(MVCFunctions.postvalue(new XVar("axis_y")) != "")
			{
				XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_y")] = MVCFunctions.postvalue(new XVar("axis_y"));
			}
			if(MVCFunctions.postvalue(new XVar("rname")) != "")
			{
				XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_rname")] = MVCFunctions.postvalue(new XVar("rname"));
			}
			return null;
		}
		public virtual XVar getCrossTableData()
		{
			return this.rowinfo;
		}
		public virtual XVar getCrossTableHeader()
		{
			return this.group_header;
		}
		public virtual XVar getCrossTableSummary()
		{
			return this.col_summary;
		}
		public virtual XVar getTotalSummary()
		{
			return this.total_summary;
		}
		protected virtual XVar setAxisFieldsIndices()
		{
			dynamic gr_x = null, gr_y = null;
			gr_x = XVar.Clone(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_x")]);
			gr_y = XVar.Clone(XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_gr_y")]);
			if(gr_x == XVar.Pack(""))
			{
				this.index_field_x = XVar.Clone(this.getFirstGroupField(new XVar("x")));
			}
			else
			{
				this.index_field_x = XVar.Clone(gr_x);
			}
			if(gr_y == XVar.Pack(""))
			{
				this.index_field_y = XVar.Clone(this.getFirstGroupField(new XVar("y")));
			}
			else
			{
				this.index_field_y = XVar.Clone(gr_y);
			}
			return null;
		}
		protected virtual XVar setDbConnection()
		{
			if(XVar.Pack(this.isProjectDB()))
			{
				this.connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(this.tableName)));
			}
			else
			{
				this.connection = XVar.Clone(GlobalVars.cman.getDefault());
			}
			return null;
		}
		protected virtual XVar getstrSQL(dynamic _param_strSQL)
		{
			#region pass-by-value parameters
			dynamic strSQL = XVar.Clone(_param_strSQL);
			#endregion

			dynamic avg_func = null, eventObj = null, fName = null, groupByClause = null, group_x = XVar.Array(), group_y = XVar.Array(), gx0 = null, gx1 = null, gy0 = null, gy1 = null, orderByClause = null, selectClause = null, select_field = null, whereClause = null;
			group_x = XVar.Clone(this.getIntervalType((XVar)(this.index_field_x)));
			group_y = XVar.Clone(this.getIntervalType((XVar)(this.index_field_y)));
			fName = XVar.Clone(this.getDBFieldName((XVar)(this.CrossGoodFieldName((XVar)(this.dataField)))));
			select_field = new XVar("' ', ");
			avg_func = new XVar("");
			if(fName != " ")
			{
				dynamic ftype = null, isTime = null, strViewFormat = null;
				strViewFormat = XVar.Clone(this.pSet.getViewFormat((XVar)(this.dataField)));
				ftype = XVar.Clone(this.getFieldType((XVar)(fName)));
				isTime = XVar.Clone((XVar)(strViewFormat == Constants.FORMAT_TIME)  || (XVar)(CommonFunctions.IsTimeType((XVar)(ftype))));
				if(XVar.Pack(isTime))
				{
					select_field = XVar.Clone(MVCFunctions.Concat(this.dataGroupFunction, "(", this.connection.timeToSecWrapper((XVar)(fName)), "), "));
				}
				else
				{
					select_field = XVar.Clone(MVCFunctions.Concat(this.dataGroupFunction, "(", this.connection.addFieldWrappers((XVar)(fName)), "), "));
				}
				this.is_value_empty = new XVar(false);
				if((XVar)(this.dataGroupFunction == "avg")  && (XVar)(!(XVar)(CommonFunctions.IsDateFieldType((XVar)(ftype)))))
				{
					dynamic sum_for_avg = null;
					sum_for_avg = XVar.Clone((XVar.Pack(!(XVar)(isTime)) ? XVar.Pack(MVCFunctions.Concat("sum(", this.connection.addFieldWrappers((XVar)(fName)), ")")) : XVar.Pack(MVCFunctions.Concat("sum(", this.connection.timeToSecWrapper((XVar)(fName)), ")"))));
					avg_func = XVar.Clone(MVCFunctions.Concat(", ", sum_for_avg, " as ", this.connection.addFieldWrappers(new XVar("avg_sum")), ", pre8count(", this.connection.addFieldWrappers((XVar)(fName)), ") as ", this.connection.addFieldWrappers(new XVar("avg_count"))));
				}
				else
				{
					avg_func = XVar.Clone(MVCFunctions.Concat(", 1 as ", this.connection.addFieldWrappers(new XVar("avg_sum")), ", 1 as ", this.connection.addFieldWrappers(new XVar("avg_count"))));
				}
			}
			whereClause = new XVar("");
			if(this.pageType == Constants.PAGE_REPORT)
			{
				if(XVar.Pack(CommonFunctions.tableEventExists(new XVar("BeforeQueryReport"), (XVar)(GlobalVars.strTableName))))
				{
					eventObj = XVar.Clone(CommonFunctions.getEventObject((XVar)(GlobalVars.strTableName)));
					eventObj.BeforeQueryReport((XVar)(whereClause));
					if(XVar.Pack(whereClause))
					{
						whereClause = XVar.Clone(MVCFunctions.Concat(" where ", whereClause));
					}
				}
			}
			else
			{
				if(XVar.Pack(CommonFunctions.tableEventExists(new XVar("BeforeQueryReportPrint"), (XVar)(GlobalVars.strTableName))))
				{
					eventObj = XVar.Clone(CommonFunctions.getEventObject((XVar)(GlobalVars.strTableName)));
					eventObj.BeforeQueryReportPrint((XVar)(whereClause));
					if(XVar.Pack(whereClause))
					{
						whereClause = XVar.Clone(MVCFunctions.Concat(" where ", whereClause));
					}
				}
			}
			gx0 = XVar.Clone(this.getDBFieldName((XVar)(group_x[0])));
			gx1 = XVar.Clone(this.getDBFieldName((XVar)(group_x[1])));
			gy0 = XVar.Clone(this.getDBFieldName((XVar)(group_y[0])));
			gy1 = XVar.Clone(this.getDBFieldName((XVar)(group_y[1])));
			selectClause = XVar.Clone(MVCFunctions.Concat("select ", select_field, gy0, ", ", gx0, avg_func));
			groupByClause = XVar.Clone(MVCFunctions.Concat("group by ", gx1, ", ", gy1));
			orderByClause = XVar.Clone(MVCFunctions.Concat("order by ", gx1, ",", gy1));
			if(this.connection.dbType != Constants.nDATABASE_Oracle)
			{
				if(this.connection.dbType == Constants.nDATABASE_MSSQLServer)
				{
					dynamic pos = null;
					pos = XVar.Clone(MVCFunctions.strrpos((XVar)(MVCFunctions.strtoupper((XVar)(strSQL))), new XVar("ORDER BY")));
					if(XVar.Pack(pos))
					{
						strSQL = XVar.Clone(MVCFunctions.substr((XVar)(strSQL), new XVar(0), (XVar)(pos)));
					}
				}
				return MVCFunctions.Concat(selectClause, " from (", strSQL, ") as cross_table", whereClause, " ", groupByClause, " ", orderByClause);
			}
			return MVCFunctions.Concat(selectClause, " from (", strSQL, ")", whereClause, " ", groupByClause, " ", orderByClause);
		}
		protected virtual XVar getIntervalType(dynamic _param_index)
		{
			#region pass-by-value parameters
			dynamic index = XVar.Clone(_param_index);
			#endregion

			dynamic arr = XVar.Array(), field = null, ftype = null, i = null, int_type = null;
			field = XVar.Clone(this.xml_array["group_fields"][index]["name"]);
			ftype = XVar.Clone(this.getFieldType((XVar)(field)));
			arr = XVar.Clone(this.xml_array["group_fields"]);
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(arr)) - 1; i++)
			{
				if((XVar)(field == arr[i]["name"])  && (XVar)(index == i))
				{
					int_type = XVar.Clone(arr[i]["int_type"]);
					break;
				}
			}
			if(int_type == XVar.Pack(0))
			{
				dynamic wrappedGoodFieldName = null;
				wrappedGoodFieldName = XVar.Clone(this.connection.addFieldWrappers((XVar)(this.CrossGoodFieldName((XVar)(field)))));
				return new XVar(0, wrappedGoodFieldName, 1, wrappedGoodFieldName);
			}
			if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
			{
				return this.getNumberTypeInterval((XVar)(field), (XVar)(int_type));
			}
			if(XVar.Pack(CommonFunctions.IsCharType((XVar)(ftype))))
			{
				return this.getCharTypeInterval((XVar)(field), (XVar)(int_type));
			}
			if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
			{
				return this.getDateTypeInterval((XVar)(field), (XVar)(int_type));
			}
			return null;
		}
		protected virtual XVar getDateTypeInterval(dynamic _param_field, dynamic _param_int_type)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic int_type = XVar.Clone(_param_int_type);
			#endregion

			field = XVar.Clone(this.connection.addFieldWrappers((XVar)(this.CrossGoodFieldName((XVar)(field)))));
			switch(((XVar)this.connection.dbType).ToInt())
			{
				case Constants.nDATABASE_MySQL:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+0101"), 1, MVCFunctions.Concat("YEAR(", field, ")"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+QUARTER(", field, ")*100+1"), 1, MVCFunctions.Concat("year(", field, "),QUARTER(", field, ")"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+month(", field, ")*100+1"), 1, MVCFunctions.Concat("year(", field, "),month(", field, ")"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+week(", field, ")*100+01"), 1, MVCFunctions.Concat("year(", field, "),WEEK(", field, ")"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+month(", field, ")*100+day(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, ")"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("year(", field, ")*1000000+month(", field, ")*10000+day(", field, ")*100+HOUR(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, "),hour(", field, ")"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("year(", field, ")*1000000+month(", field, ")*1000000+day(", field, ")*10000+HOUR(", field, ")*100+minute(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, "),hour(", field, "),minute(", field, ")"));
											}
										}
									}
								}
							}
						}
					}
					break;
				case Constants.nDATABASE_Oracle:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*10000+0101"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*10000+TO_CHAR(", field, ",'Q')*100+1"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ",'Q')"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*10000+TO_CHAR(", field, ".'MM')*100+1"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ".'MM')"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*10000+TO_CHAR(", field, ",'W')*100+01"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ",'W')"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*10000+TO_CHAR(", field, ",'MM')*100+TO_CHAR(", field, ",'DD')"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ",'MM'),TO_CHAR(", field, ",'DD')"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*1000000+TO_CHAR(", field, ",'MM')*10000+TO_CHAR(", field, ",'DD')*100+TO_CHAR(", field, ",'HH')"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ",'MM'),TO_CHAR(", field, ",'DD'),TO_CHAR(", field, ",'HH')"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY')*1000000+TO_CHAR(", field, ",'MM')*1000000+TO_CHAR(", field, ",'DD')*10000+TO_CHAR(", field, ",'HH')*100+TO_CHAR(", field, ",'MI')"), 1, MVCFunctions.Concat("TO_CHAR(", field, ", 'YYYY'),TO_CHAR(", field, ",'MM'),TO_CHAR(", field, ",'DD'),TO_CHAR(", field, ",'HH'),TO_CHAR(", field, ",'MI')"));
											}
										}
									}
								}
							}
						}
					}
					break;
				case Constants.nDATABASE_MSSQLServer:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*10000+0101"), 1, MVCFunctions.Concat("datepart(yyyy,", field, ")"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*10000+datepart(qq,", field, ")*100+1"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(qq,", field, ")"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*10000+datepart(mm,", field, ")*100+1"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(mm,", field, ")"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*10000+(datepart(ww,", field, ")-1)*100+01"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(ww,", field, ")"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*10000+datepart(mm,", field, ")*100+datepart(dd,", field, ")"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(mm,", field, "),datepart(dd,", field, ")"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*1000000+datepart(mm,", field, ")*10000+datepart(dd,", field, ")*100+datepart(hh,", field, ")"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(mm,", field, "),datepart(dd,", field, "),datepart(hh,", field, ")"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("datepart(yyyy,", field, ")*1000000+datepart(mm,", field, ")*1000000+datepart(dd,", field, ")*10000+datepart(hh,", field, ")*100+datepart(mi,", field, ")"), 1, MVCFunctions.Concat("datepart(yyyy,", field, "),datepart(mm,", field, "),datepart(dd,", field, "),datepart(hh,", field, "),datepart(mi,", field, ")"));
											}
										}
									}
								}
							}
						}
					}
					break;
				case Constants.nDATABASE_Access:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*10000+0101"), 1, MVCFunctions.Concat("datepart('yyyy',", field, ")"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*10000+datepart('q',", field, ")*100+1"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('q',", field, ")"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*10000+datepart('m',", field, ")*100+1"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('m',", field, ")"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*10000+(datepart('ww',", field, ")-1)*100+01"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('ww',", field, ")"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*10000+datepart('m',", field, ")*100+datepart('d',", field, ")"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('m',", field, "),datepart('d',", field, ")"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*1000000+datepart('m',", field, ")*10000+datepart('d',", field, ")*100+datepart('h',", field, ")"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('m',", field, "),datepart('d',", field, "),datepart('h',", field, ")"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("datepart('yyyy',", field, ")*1000000+datepart('m',", field, ")*1000000+datepart('d',", field, ")*10000+datepart('h',", field, ")*100+datepart('n',", field, ")"), 1, MVCFunctions.Concat("datepart('yyyy',", field, "),datepart('m',", field, "),datepart('d',", field, "),datepart('h',", field, "),datepart('n',", field, ")"));
											}
										}
									}
								}
							}
						}
					}
					break;
				case Constants.nDATABASE_PostgreSQL:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*10000+0101"), 1, MVCFunctions.Concat("date_part('year',", field, ")"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*10000+date_part('quarter',", field, ")*100+1"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('quarter',", field, ")"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*10000+date_part('month',", field, ")*100+1"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('month',", field, ")"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*10000+(date_part('week',", field, ")-1)*100+01"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('week',", field, ")"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*10000+date_part('month',", field, ")*100+date_part('days',", field, ")"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('month',", field, "),date_part('days',", field, ")"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*1000000+date_part('month',", field, ")*10000+date_part('days',", field, ")*100+date_part('hour',", field, ")"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('month',", field, "),date_part('days',", field, "),date_part('hour',", field, ")"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("date_part('year',", field, ")*1000000+date_part('month',", field, ")*1000000+date_part('days',", field, ")*10000+date_part('hour',", field, ")*100+date_part('minute',", field, ")"), 1, MVCFunctions.Concat("date_part('year',", field, "),date_part('month',", field, "),date_part('days',", field, "),date_part('hour',", field, "),date_part('minute',", field, ")"));
											}
										}
									}
								}
							}
						}
					}
					break;
				case Constants.nDATABASE_Informix:
					return MVCFunctions.Concat("substring(", field, " from 1 for ", int_type, ")");
				case Constants.nDATABASE_SQLite3:
					return new XVar(0, field, 1, field);
				case Constants.nDATABASE_DB2:
					if(int_type == 1)
					{
						return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+0101"), 1, MVCFunctions.Concat("YEAR(", field, ")"));
					}
					else
					{
						if(int_type == 2)
						{
							return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+QUARTER(", field, ")*100+1"), 1, MVCFunctions.Concat("year(", field, "),QUARTER(", field, ")"));
						}
						else
						{
							if(int_type == 3)
							{
								return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+month(", field, ")*100+1"), 1, MVCFunctions.Concat("year(", field, "),month(", field, ")"));
							}
							else
							{
								if(int_type == 4)
								{
									return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+week(", field, ")*100+01"), 1, MVCFunctions.Concat("year(", field, "),WEEK(", field, ")"));
								}
								else
								{
									if(int_type == 5)
									{
										return new XVar(0, MVCFunctions.Concat("year(", field, ")*10000+month(", field, ")*100+day(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, ")"));
									}
									else
									{
										if(int_type == 6)
										{
											return new XVar(0, MVCFunctions.Concat("year(", field, ")*1000000+month(", field, ")*10000+day(", field, ")*100+HOUR(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, "),hour(", field, ")"));
										}
										else
										{
											if(int_type == 7)
											{
												return new XVar(0, MVCFunctions.Concat("year(", field, ")*1000000+month(", field, ")*1000000+day(", field, ")*10000+HOUR(", field, ")*100+minute(", field, ")"), 1, MVCFunctions.Concat("year(", field, "),month(", field, "),day(", field, "),hour(", field, "),minute(", field, ")"));
											}
										}
									}
								}
							}
						}
					}
					break;
			}
			return null;
		}
		protected virtual XVar getNumberTypeInterval(dynamic _param_field, dynamic _param_int_type)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic int_type = XVar.Clone(_param_int_type);
			#endregion

			return new XVar(0, MVCFunctions.Concat("floor(", this.connection.addFieldWrappers((XVar)(this.CrossGoodFieldName((XVar)(field)))), "/", int_type, ")*", int_type), 1, MVCFunctions.Concat("floor(", this.connection.addFieldWrappers((XVar)(this.CrossGoodFieldName((XVar)(field)))), "/", int_type, ")*", int_type));
		}
		protected virtual XVar getCharTypeInterval(dynamic _param_field, dynamic _param_int_type)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic int_type = XVar.Clone(_param_int_type);
			#endregion

			field = XVar.Clone(this.connection.addFieldWrappers((XVar)(this.CrossGoodFieldName((XVar)(field)))));
			switch(((XVar)this.connection.dbType).ToInt())
			{
				case Constants.nDATABASE_MySQL:
				case Constants.nDATABASE_MSSQLServer:
				case Constants.nDATABASE_Access:
					return new XVar(0, MVCFunctions.Concat("left(", field, ",", int_type, ")"), 1, MVCFunctions.Concat("left(", field, ",", int_type, ")"));
				case Constants.nDATABASE_PostgreSQL:
				case Constants.nDATABASE_Informix:
					return new XVar(0, MVCFunctions.Concat("substring(", field, " from 1 for ", int_type, ")"), 1, MVCFunctions.Concat("substring(", field, " from 1 for ", int_type, ")"));
				case Constants.nDATABASE_Oracle:
				case Constants.nDATABASE_SQLite3:
				case Constants.nDATABASE_DB2:
					return new XVar(0, MVCFunctions.Concat("substr(", field, ",1,", int_type, ")"), 1, MVCFunctions.Concat("substr(", field, ",1,", int_type, ")"));
			}
			return null;
		}
		public virtual XVar getSelectedValue()
		{
			dynamic arr = XVar.Array(), firstarr = XVar.Array();
			arr = XVar.Clone(XVar.Array());
			firstarr = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> value in this.xml_array["totals"].GetEnumerator())
			{
				if(CommonFunctions.pre8count((XVar)(firstarr)) == 0)
				{
					firstarr.InitAndSetArrayItem(this.FullFieldName((XVar)(value.Value["name"]), (XVar)(value.Value["table"])), null);
				}
				if((XVar)((XVar)((XVar)(value.Value["min"] == true)  || (XVar)(value.Value["max"] == true))  || (XVar)(value.Value["sum"] == true))  || (XVar)(value.Value["avg"] == true))
				{
					arr.InitAndSetArrayItem(this.FullFieldName((XVar)(value.Value["name"]), (XVar)(value.Value["table"])), null);
				}
			}
			if(CommonFunctions.pre8count((XVar)(arr)) == 0)
			{
				arr = XVar.Clone(firstarr);
			}
			return arr;
		}
		public virtual XVar getRadioGroupFunctions(dynamic _param_hostPageLocation = null, dynamic _param_hostPageId = null)
		{
			#region default values
			if(_param_hostPageLocation as Object == null) _param_hostPageLocation = new XVar("");
			if(_param_hostPageId as Object == null) _param_hostPageId = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic hostPageLocation = XVar.Clone(_param_hostPageLocation);
			dynamic hostPageId = XVar.Clone(_param_hostPageId);
			#endregion

			dynamic arr = XVar.Array(), arrDisplay = XVar.Array(), j = null, onclick = null, res = null, s = null;
			arr = XVar.Clone(XVar.Array());
			arrDisplay = XVar.Clone(XVar.Array());
			res = new XVar("");
			if(this.dataFieldSettings["sum"] == true)
			{
				arrDisplay.InitAndSetArrayItem("Sum", null);
				arr.InitAndSetArrayItem("sum", null);
			}
			if(this.dataFieldSettings["max"] == true)
			{
				arrDisplay.InitAndSetArrayItem("Max", null);
				arr.InitAndSetArrayItem("max", null);
			}
			if(this.dataFieldSettings["min"] == true)
			{
				arrDisplay.InitAndSetArrayItem("Min", null);
				arr.InitAndSetArrayItem("min", null);
			}
			if(this.dataFieldSettings["avg"] == true)
			{
				arrDisplay.InitAndSetArrayItem("Average", null);
				arr.InitAndSetArrayItem("avg", null);
			}
			if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(arr)))))
			{
				arr.InitAndSetArrayItem("sum", null);
				arrDisplay.InitAndSetArrayItem("Sum", null);
			}
			res = new XVar("");
			onclick = XVar.Clone(MVCFunctions.Concat("onclick='refresh_crosstable(\"", hostPageLocation, "\", \"", hostPageId, "\", \"", this.dashBased, "\", \"", this.dashTName, "\");'"));
			j = new XVar(0);
			for(;j < CommonFunctions.pre8count((XVar)(arr)); j++)
			{
				s = new XVar("");
				if((XVar)(res == XVar.Pack(""))  || (XVar)(this.dataGroupFunction == arr[j]))
				{
					s = new XVar("checked");
				}
				res = MVCFunctions.Concat(res, "<input type=radio value='", arr[j], "' name=\"group_func", hostPageId, "\" ", s, " ", onclick, "> ", arrDisplay[j], "&nbsp;&nbsp;");
			}
			return res;
		}
		public virtual XVar ajax_refresh_crosstable(dynamic _param_hostPageLocation = null, dynamic _param_hostPageId = null)
		{
			#region default values
			if(_param_hostPageLocation as Object == null) _param_hostPageLocation = new XVar("");
			if(_param_hostPageId as Object == null) _param_hostPageId = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic hostPageLocation = XVar.Clone(_param_hostPageLocation);
			dynamic hostPageId = XVar.Clone(_param_hostPageId);
			#endregion

			dynamic reportData = null;
			reportData = XVar.Clone(new XVar(0, this.rowinfo, 1, this.col_summary, 2, this.total_summary, 3, this.getTotalsName((XVar)(this.dataGroupFunction)), 4, this.getRadioGroupFunctions((XVar)(hostPageLocation), (XVar)(hostPageId))));
			MVCFunctions.Echo(MVCFunctions.my_json_encode((XVar)(reportData)));
			return null;
		}
		public virtual XVar getGroupFields(dynamic _param_axis)
		{
			#region pass-by-value parameters
			dynamic axis = XVar.Clone(_param_axis);
			#endregion

			dynamic arr = XVar.Array(), i = null, label = XVar.Array(), res = null, s = null;
			res = new XVar("");
			label = XVar.Clone(this.xml_array["totals"]);
			arr = XVar.Clone(this.xml_array["group_fields"]);
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(arr)) - 1; i++)
			{
				s = new XVar("");
				if((XVar)((XVar)((XVar)(axis == "x")  && (XVar)(arr[i]["group_type"] == "x"))  || (XVar)((XVar)(axis == "y")  && (XVar)(arr[i]["group_type"] == "y")))  || (XVar)(arr[i]["group_type"] == "all"))
				{
					if((XVar)((XVar)(axis == "x")  && (XVar)(this.index_field_y != i))  || (XVar)((XVar)(axis == "y")  && (XVar)(this.index_field_x != i)))
					{
						dynamic strlabel = null;
						if((XVar)((XVar)(this.index_field_x == i)  && (XVar)(axis == "x"))  || (XVar)((XVar)(this.index_field_y == i)  && (XVar)(axis == "y")))
						{
							s = new XVar("selected");
						}
						strlabel = new XVar("");
						foreach (KeyValuePair<XVar, dynamic> val in label.GetEnumerator())
						{
							if(arr[i]["name"] == this.FullFieldName((XVar)(val.Value["name"]), (XVar)(val.Value["table"])))
							{
								strlabel = XVar.Clone(val.Value["label"]);
								break;
							}
						}
						res = MVCFunctions.Concat(res, "<option value='", i, "' ", s, ">", strlabel, "</option>");
					}
				}
			}
			return res;
		}
		protected virtual XVar getFirstGroupField(dynamic _param_axis)
		{
			#region pass-by-value parameters
			dynamic axis = XVar.Clone(_param_axis);
			#endregion

			dynamic arr = XVar.Array(), arrAll = XVar.Array(), arrX = XVar.Array(), arrY = XVar.Array(), i = null;
			arr = XVar.Clone(this.xml_array["group_fields"]);
			arrX = XVar.Clone(XVar.Array());
			arrY = XVar.Clone(XVar.Array());
			arrAll = XVar.Clone(XVar.Array());
			i = new XVar(0);
			for(;i < CommonFunctions.pre8count((XVar)(arr)) - 1; i++)
			{
				if(arr[i]["group_type"] == "x")
				{
					arrX.InitAndSetArrayItem(i, null);
				}
				if(arr[i]["group_type"] == "y")
				{
					arrY.InitAndSetArrayItem(i, null);
				}
				if(arr[i]["group_type"] == "all")
				{
					arrAll.InitAndSetArrayItem(i, null);
				}
			}
			if((XVar)(0 < CommonFunctions.pre8count((XVar)(arrX)))  && (XVar)(axis == "x"))
			{
				return arrX[0];
			}
			if((XVar)(0 < CommonFunctions.pre8count((XVar)(arrY)))  && (XVar)(axis == "y"))
			{
				return arrY[0];
			}
			if((XVar)(CommonFunctions.pre8count((XVar)(arrX)) == 0)  && (XVar)(axis == "x"))
			{
				return arrAll[0];
			}
			if((XVar)(CommonFunctions.pre8count((XVar)(arrY)) == 0)  && (XVar)(axis == "y"))
			{
				if(CommonFunctions.pre8count((XVar)(arrX)) == 0)
				{
					return arrAll[1];
				}
				else
				{
					return arrAll[0];
				}
			}
			return null;
		}
		protected virtual XVar getAxisDisplayValue(dynamic _param_index, dynamic _param_value)
		{
			#region pass-by-value parameters
			dynamic index = XVar.Clone(_param_index);
			dynamic value = XVar.Clone(_param_value);
			#endregion

			dynamic field = null, fieldIdentifier = null, ftype = null, groupFieldsData = XVar.Array(), int_type = null;
			if((XVar)(value == XVar.Pack(""))  || (XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack(null))))
			{
				return "";
			}
			groupFieldsData = XVar.Clone(this.xml_array["group_fields"]);
			field = XVar.Clone(groupFieldsData[index]["name"]);
			int_type = XVar.Clone(groupFieldsData[index]["int_type"]);
			ftype = XVar.Clone(this.getFieldType((XVar)(field)));
			if(int_type == XVar.Pack(0))
			{
				if(this.table_type != "db")
				{
					fieldIdentifier = XVar.Clone(MVCFunctions.Concat(this.xml_array["tables"][0], "_", field));
				}
				else
				{
					fieldIdentifier = XVar.Clone(this.CrossGoodFieldName((XVar)(field)));
				}
				if(this.xml_array["totals"][fieldIdentifier]["curr"] == true)
				{
					return CommonFunctions.str_format_currency((XVar)(value));
				}
				if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
				{
					return CommonFunctions.format_shortdate((XVar)(CommonFunctions.db2time((XVar)(value))));
				}
				return CommonFunctions.xmlencode((XVar)(value));
			}
			if(XVar.Pack(CommonFunctions.IsNumberType((XVar)(ftype))))
			{
				dynamic start = null, var_end = null;
				start = XVar.Clone(value - value  %  int_type);
				var_end = XVar.Clone(start + int_type);
				if(this.table_type != "db")
				{
					fieldIdentifier = XVar.Clone(MVCFunctions.Concat(this.xml_array["tables"][0], "_", field));
				}
				else
				{
					fieldIdentifier = XVar.Clone(this.CrossGoodFieldName((XVar)(field)));
				}
				if(this.xml_array["totals"][fieldIdentifier]["curr"] == true)
				{
					return MVCFunctions.Concat(CommonFunctions.str_format_currency((XVar)(start)), " - ", CommonFunctions.str_format_currency((XVar)(var_end)));
				}
				return MVCFunctions.Concat(start, " - ", var_end);
			}
			if(XVar.Pack(CommonFunctions.IsCharType((XVar)(ftype))))
			{
				return CommonFunctions.xmlencode((XVar)(MVCFunctions.substr((XVar)(value), new XVar(0), (XVar)(int_type))));
			}
			if(XVar.Pack(CommonFunctions.IsDateFieldType((XVar)(ftype))))
			{
				dynamic dates = XVar.Array(), dvalue = null, tm = XVar.Array();
				dvalue = XVar.Clone(MVCFunctions.Concat(MVCFunctions.substr((XVar)(value), new XVar(0), new XVar(4)), "-", MVCFunctions.substr((XVar)(value), new XVar(4), new XVar(2)), "-", MVCFunctions.substr((XVar)(value), new XVar(6), new XVar(2))));
				if(MVCFunctions.strlen((XVar)(value)) == 10)
				{
					dvalue = MVCFunctions.Concat(dvalue, " ", MVCFunctions.substr((XVar)(value), new XVar(8), new XVar(2)), "00:00");
				}
				else
				{
					if(MVCFunctions.strlen((XVar)(value)) == 12)
					{
						dvalue = MVCFunctions.Concat(dvalue, " ", MVCFunctions.substr((XVar)(value), new XVar(8), new XVar(2)), ":", MVCFunctions.substr((XVar)(value), new XVar(10), new XVar(2)), ":00");
					}
				}
				tm = XVar.Clone(CommonFunctions.db2time((XVar)(dvalue)));
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(tm)))))
				{
					return "";
				}
				switch(((XVar)int_type).ToInt())
				{
					case 1:
						return tm[0];
					case 2:
						return MVCFunctions.Concat(tm[0], "/Q", tm[1]);
					case 3:
						return MVCFunctions.Concat(GlobalVars.locale_info[MVCFunctions.Concat("LOCALE_SABBREVMONTHNAME", tm[1])], " ", tm[0]);
					case 4:
						dates = XVar.Clone(this.getDatesByWeek((XVar)(tm[1] + 1), (XVar)(tm[0])));
						return MVCFunctions.Concat(CommonFunctions.format_shortdate((XVar)(CommonFunctions.db2time((XVar)(dates[0])))), " - ", CommonFunctions.format_shortdate((XVar)(CommonFunctions.db2time((XVar)(dates[1])))));
					case 5:
						return CommonFunctions.format_shortdate((XVar)(tm));
					case 6:
						tm.InitAndSetArrayItem(0, 4);
						tm.InitAndSetArrayItem(0, 5);
						return CommonFunctions.str_format_datetime((XVar)(tm));
					case 7:
						tm.InitAndSetArrayItem(0, 5);
						return CommonFunctions.str_format_datetime((XVar)(tm));
					default:
						return CommonFunctions.str_format_datetime((XVar)(tm));
				}
			}
			return "";
		}
		protected virtual XVar getDatesByWeek(dynamic _param_week, dynamic _param_year)
		{
			#region pass-by-value parameters
			dynamic week = XVar.Clone(_param_week);
			dynamic year = XVar.Clone(_param_year);
			#endregion

			dynamic L = null, dates = XVar.Array(), day = null, day_of_week = null, i = null, month = null, months = XVar.Array(), startweekday = null, sum = null, total_days = null;
			startweekday = new XVar(0);
			if(0 < GlobalVars.locale_info["LOCALE_IFIRSTDAYOFWEEK"])
			{
				startweekday = XVar.Clone(7 - GlobalVars.locale_info["LOCALE_IFIRSTDAYOFWEEK"]);
			}
			L = XVar.Clone((XVar.Pack(CommonFunctions.isleapyear((XVar)(year))) ? XVar.Pack(1) : XVar.Pack(0)));
			months = XVar.Clone(new XVar(0, 31, 1, 28 + L, 2, 31, 3, 30, 4, 31, 5, 30, 6, 31, 7, 31, 8, 30, 9, 31, 10, 30, 11, 31));
			total_days = XVar.Clone((week - 1) * 7);
			i = new XVar(0);
			sum = new XVar(0);
			while(sum <= total_days)
			{
				sum += months[i++];
			}
			sum -= months[i - 1];
			month = XVar.Clone(i);
			day = XVar.Clone(total_days - sum);
			day_of_week = XVar.Clone(CommonFunctions.getdayofweek((XVar)(new XVar(0, year, 1, month, 2, day))));
			if(day_of_week == XVar.Pack(0))
			{
				day_of_week = new XVar(7);
			}
			day = XVar.Clone((day - (day_of_week - 1)) - startweekday);
			dates = XVar.Clone(XVar.Array());
			dates.InitAndSetArrayItem(MVCFunctions.getYMDdate((XVar)(MVCFunctions.mktime(new XVar(0), new XVar(0), new XVar(0), (XVar)(month), (XVar)(day), (XVar)(year)))), 0);
			dates.InitAndSetArrayItem(MVCFunctions.getYMDdate((XVar)(MVCFunctions.mktime(new XVar(1), new XVar(1), new XVar(1), (XVar)(month), (XVar)(day + 6), (XVar)(year)))), 1);
			return dates;
		}
		public virtual XVar getValuesControl()
		{
			dynamic arr_label = XVar.Array(), arr_list = XVar.Array(), first_field = null, i = null, res = null;
			arr_list = XVar.Clone(this.getSelectedValue());
			arr_label = XVar.Clone(this.xml_array["totals"]);
			res = new XVar("");
			first_field = new XVar(0);
			i = new XVar(0);
			if(CommonFunctions.pre8count((XVar)(arr_list)) != 0)
			{
				foreach (KeyValuePair<XVar, dynamic> value in arr_list.GetEnumerator())
				{
					dynamic s = null, strlabel = null;
					s = new XVar("");
					if((XVar)(i == XVar.Pack(0))  || (XVar)(i == XSession.Session[MVCFunctions.Concat(this.sessionPrefix, "_field")]))
					{
						first_field = XVar.Clone(i);
						s = new XVar("selected");
					}
					strlabel = new XVar("");
					foreach (KeyValuePair<XVar, dynamic> val in arr_label.GetEnumerator())
					{
						if(value.Value == this.FullFieldName((XVar)(val.Value["name"]), (XVar)(val.Value["table"])))
						{
							strlabel = XVar.Clone(val.Value["label"]);
							break;
						}
					}
					res = MVCFunctions.Concat(res, "<option value=", i, " ", s, ">", MVCFunctions.runner_htmlspecialchars((XVar)(strlabel)), "</option>");
					i++;
				}
			}
			return new XVar(0, res, 1, first_field);
		}
		protected virtual XVar FullFieldName(dynamic _param_field, dynamic _param_table = null)
		{
			#region default values
			if(_param_table as Object == null) _param_table = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			dynamic table = XVar.Clone(_param_table);
			#endregion

			dynamic res = null;
			if(XVar.Pack(!(XVar)(table)))
			{
				table = XVar.Clone(this.tableName);
			}
			if(this.table_type == "db")
			{
				if(XVar.Equals(XVar.Pack(MVCFunctions.strpos((XVar)(field), new XVar("."))), XVar.Pack(false)))
				{
					res = XVar.Clone(MVCFunctions.Concat(table, ".", field));
				}
				else
				{
					res = XVar.Clone(field);
				}
			}
			else
			{
				res = XVar.Clone(field);
			}
			return res;
		}
		protected virtual XVar CrossGoodFieldName(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			if(this.table_type == "db")
			{
				return MVCFunctions.GoodFieldName((XVar)(field));
			}
			else
			{
				return field;
			}
			return null;
		}
		public virtual XVar getPrintCrossHeader()
		{
			dynamic fieldName = null, fieldNameX = null, fieldNameY = null, prefix = null;
			fieldNameX = XVar.Clone(this.xml_array["group_fields"][this.index_field_x]["name"]);
			fieldNameY = XVar.Clone(this.xml_array["group_fields"][this.index_field_y]["name"]);
			fieldName = XVar.Clone(this.dataField);
			prefix = new XVar("");
			if(this.table_type != "db")
			{
				prefix = XVar.Clone(MVCFunctions.Concat(this.xml_array["tables"][0], "_"));
			}
			fieldNameX = XVar.Clone(MVCFunctions.Concat(prefix, MVCFunctions.GoodFieldName((XVar)(fieldNameX))));
			fieldNameY = XVar.Clone(MVCFunctions.Concat(prefix, MVCFunctions.GoodFieldName((XVar)(fieldNameY))));
			fieldName = XVar.Clone(MVCFunctions.Concat(prefix, MVCFunctions.GoodFieldName((XVar)(fieldName))));
			return MVCFunctions.Concat("Group X", ":<b>", this.xml_array["totals"][fieldNameX]["label"], "</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", "Group Y", ":<b>", this.xml_array["totals"][fieldNameY]["label"], "</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", "Field", ":<b>", this.xml_array["totals"][fieldName]["label"], "</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", "Group function", ":<b>", this.dataGroupFunction, "</b>");
		}
		public virtual XVar getTotalsName(dynamic _param_grfunc)
		{
			#region pass-by-value parameters
			dynamic grfunc = XVar.Clone(_param_grfunc);
			#endregion

			switch(((XVar)grfunc).ToString())
			{
				case "sum":
					return "Sum";
					break;
				case "min":
					return "Min";
					break;
				case "max":
					return "Max";
					break;
				case "avg":
					return "Average";
					break;
			}
			return null;
		}
		protected virtual XVar getFieldType(dynamic _param_field)
		{
			#region pass-by-value parameters
			dynamic field = XVar.Clone(_param_field);
			#endregion

			dynamic ftype = null;
			if(this.table_type == "db")
			{
				ftype = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(this.FullFieldName((XVar)(field)))));
			}
			else
			{
				if(this.table_type == "project")
				{
					ftype = XVar.Clone(this.pSet.getFieldType((XVar)(field)));
				}
				else
				{
					dynamic fields_type = XVar.Array();
					fields_type = XVar.Clone(CommonFunctions.WRGetAllCustomFieldType());
					ftype = XVar.Clone(fields_type[field]);
				}
			}
			return ftype;
		}
		protected virtual XVar getDataField(dynamic _param_idx)
		{
			#region pass-by-value parameters
			dynamic idx = XVar.Clone(_param_idx);
			#endregion

			dynamic arr_value = XVar.Array();
			idx = XVar.Clone(0 + idx);
			arr_value = XVar.Clone(this.getSelectedValue());
			if(CommonFunctions.pre8count((XVar)(arr_value)) <= idx)
			{
				return "";
			}
			return arr_value[idx];
		}
		protected virtual XVar initDataFieldSettings()
		{
			foreach (KeyValuePair<XVar, dynamic> value in this.xml_array["totals"].GetEnumerator())
			{
				if(this.FullFieldName((XVar)(value.Value["name"]), (XVar)(value.Value["table"])) == this.dataField)
				{
					this.dataFieldSettings = XVar.Clone(this.xml_array["totals"][value.Key]);
					break;
				}
			}
			return null;
		}
		protected virtual XVar initDataGroupFunction(dynamic _param_func)
		{
			#region pass-by-value parameters
			dynamic func = XVar.Clone(_param_func);
			#endregion

			dynamic gfuncs = XVar.Array();
			if(this.dataFieldSettings[func] == true)
			{
				this.dataGroupFunction = XVar.Clone(func);
				return null;
			}
			gfuncs = XVar.Clone(new XVar(0, "sum", 1, "max", 2, "min", 3, "avg"));
			foreach (KeyValuePair<XVar, dynamic> gf in gfuncs.GetEnumerator())
			{
				if(this.dataFieldSettings[gf.Value] == true)
				{
					this.dataGroupFunction = XVar.Clone(gf.Value);
					return null;
				}
			}
			this.dataGroupFunction = new XVar("sum");
			return null;
		}
		public virtual XVar getCurrentGroupFunction()
		{
			return this.dataGroupFunction;
		}
		public virtual XVar isProjectDB()
		{
			dynamic isDB = null;
			isDB = new XVar(false);
			if("dbo.sysdiagrams" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.company" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.radioEquipment" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.baranggay" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.city" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.province" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_beta_users" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_betaugrights" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_betaugmembers" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_beta_users" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.stage" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.stageStatus" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_betauggroups" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_beta_audit" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_beta_settings" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_betaugmembers" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_betaugrights" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.transactionSetup" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.branch" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.spectrum_beta_users" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.classStation" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.rspdHeader" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			if("dbo.region" == this.xml_array["tables"][0])
			{
				isDB = new XVar(true);
			}
			return isDB;
		}
		protected virtual XVar getDBFieldName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			if(XVar.Pack(!(XVar)(this.wrdb)))
			{
				return name;
			}
			else
			{
				dynamic gname = null;
				gname = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(name)));
				if((XVar)(MVCFunctions.substr((XVar)(gname), new XVar(0), new XVar(1)) == "_")  && (XVar)(MVCFunctions.substr((XVar)(gname), new XVar(-1)) == "_"))
				{
					gname = XVar.Clone(MVCFunctions.substr((XVar)(gname), new XVar(1), new XVar(-1)));
				}
				return this.arrDBFieldsList[gname];
			}
			return null;
		}
	}
}
