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
	public partial class GlobalController : BaseController
	{
		public XVar dimager()
		{
			try
			{
				dynamic data = XVar.Array(), defConnection = null, field = null, itype = null, keys = XVar.Array(), rs = null, show = null, strSQL = null, strkeywhere = null, table = null, value = null;
				GlobalVars.init_dbcommon();
				if((XVar)(!(XVar)(CommonFunctions.isLogged()))  || (XVar)(!(XVar)(MVCFunctions.postvalue(new XVar("rname")))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("rname")))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.rpt_array = XVar.Clone(CommonFunctions.wrGetEntityArray((XVar)(MVCFunctions.postvalue(new XVar("rname"))), new XVar(Constants.WR_REPORT)));
				if(XVar.Pack(CommonFunctions.is_wr_project()))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if((XVar)(GlobalVars.rpt_array["settings"]["status"] == "private")  && (XVar)(GlobalVars.rpt_array["owner"] != Security.getUserName()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(1 < CommonFunctions.pre8count((XVar)(CommonFunctions.GetUserGroups())))
				{
					dynamic arr_reports = XVar.Array();
					arr_reports = XVar.Clone(XVar.Array());
					arr_reports = XVar.Clone(CommonFunctions.wrGetEntityList(new XVar(Constants.WR_REPORT)));
					foreach (KeyValuePair<XVar, dynamic> rpt in arr_reports.GetEnumerator())
					{
						if((XVar)((XVar)((XVar)(rpt.Value["owner"] != Security.getUserName())  || (XVar)(rpt.Value["owner"] == ""))  && (XVar)(rpt.Value["view"] == 0))  && (XVar)(GlobalVars.rpt_array["settings"]["name"] == rpt.Value["name"]))
						{
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
					}
				}
				defConnection = XVar.Clone(GlobalVars.cman.getForWebReports());
				field = new XVar("");
				table = new XVar("");
				CommonFunctions.WRSplitFieldName((XVar)(MVCFunctions.postvalue(new XVar("field"))), ref table, ref field);
				show = new XVar(false);
				foreach (KeyValuePair<XVar, dynamic> fld in GlobalVars.rpt_array["totals"].GetEnumerator())
				{
					if((XVar)(fld.Value["table"] == table)  && (XVar)(fld.Value["name"] == field))
					{
						if(XVar.Pack(fld.Value["show"]))
						{
							show = new XVar(true);
						}
						break;
					}
				}
				if(XVar.Pack(!(XVar)(show)))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				keys = XVar.Clone(CommonFunctions.DBGetTableKeys((XVar)(table)));
				if(XVar.Pack(!(XVar)(CommonFunctions.pre8count((XVar)(keys)))))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				strkeywhere = new XVar("");
				foreach (KeyValuePair<XVar, dynamic> k in keys.GetEnumerator())
				{
					dynamic var_type = null;
					if(XVar.Pack(MVCFunctions.strlen((XVar)(strkeywhere))))
					{
						strkeywhere = MVCFunctions.Concat(strkeywhere, " and ");
					}
					strkeywhere = MVCFunctions.Concat(strkeywhere, defConnection.addTableWrappers((XVar)(table)), ".", defConnection.addFieldWrappers((XVar)(k.Value)), "=");
					var_type = XVar.Clone(CommonFunctions.WRGetFieldType((XVar)(MVCFunctions.Concat(table, ".", k.Value))));
					if(XVar.Pack(CommonFunctions.NeedQuotes((XVar)(var_type))))
					{
						strkeywhere = MVCFunctions.Concat(strkeywhere, CommonFunctions.db_prepare_string((XVar)(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("key", k.Key + 1))))));
					}
					else
					{
						dynamic strvalue = null;
						value = XVar.Clone(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("key", k.Key + 1))));
						strvalue = XVar.Clone(XVar.Pack(value).ToString());
						strvalue = XVar.Clone(MVCFunctions.str_replace(new XVar(","), new XVar("."), (XVar)(strvalue)));
						if(XVar.Pack(MVCFunctions.IsNumeric(strvalue)))
						{
							value = XVar.Clone(strvalue);
						}
						else
						{
							value = new XVar(0);
						}
						strkeywhere = MVCFunctions.Concat(strkeywhere, value);
					}
				}
				strSQL = XVar.Clone(MVCFunctions.Concat(GlobalVars.rpt_array["sql"], " WHERE ", strkeywhere));
				rs = XVar.Clone(defConnection.query((XVar)(strSQL)));
				if((XVar)(!(XVar)(rs))  || (XVar)(!(XVar)(data = XVar.Clone(rs.fetchAssoc()))))
				{
					return CommonFunctions.DisplayNoImage();
				}
				value = XVar.Clone(MVCFunctions.db_stripslashesbinaryAccess((XVar)(data[MVCFunctions.postvalue(new XVar("alias"))])));
				if(XVar.Pack(!(XVar)(value)))
				{
					return CommonFunctions.DisplayNoImage();
				}
				itype = XVar.Clone(MVCFunctions.SupposeImageType((XVar)(value)));
				if(XVar.Pack(itype))
				{
					MVCFunctions.Header((XVar)(MVCFunctions.Concat("Content-Type: ", itype)));
				}
				else
				{
					return CommonFunctions.DisplayFile();
				}
				MVCFunctions.echoBinary((XVar)(value));
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
