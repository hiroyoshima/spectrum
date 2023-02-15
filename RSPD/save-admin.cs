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
		public XVar save_admin()
		{
			try
			{
				dynamic _connection = null, arr = XVar.Array(), customSQL = null;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(MVCFunctions.postvalue(new XVar("name")) == "password")
				{
					if(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("password")))) == GlobalVars.WRAdminPagePassword)
					{
						XSession.Session["WRAdmin"] = true;
						MVCFunctions.Echo("OK");
					}
					else
					{
						XSession.Session.Remove("WRAdmin");
						MVCFunctions.Echo("ERROR");
					}
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(!(XVar)(CommonFunctions.isWRAdmin())))
				{
					XSession.Session["MyURL"] = MVCFunctions.Concat(MVCFunctions.GetScriptName(), "?", MVCFunctions.GetQueryString());
					MVCFunctions.HeaderRedirect((XVar)(MVCFunctions.Concat("", MVCFunctions.GetTableLink(new XVar("webreport"), new XVar(""), new XVar("message=expired")))));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
				if(MVCFunctions.postvalue(new XVar("name")) == "deletesql")
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("idsql"))))
					{
						_connection.exec((XVar)(MVCFunctions.Concat("delete from ", _connection.addTableWrappers(new XVar("webreport_sql")), "  where ", _connection.addFieldWrappers(new XVar("id")), "=", MVCFunctions.postvalue(new XVar("idsql")))));
					}
					MVCFunctions.Echo("OK");
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(MVCFunctions.postvalue(new XVar("name")) == "sqledit")
				{
					dynamic errstr = null, qResult = null, rs = null, sqlcontent = null;
					errstr = new XVar("");
					sqlcontent = XVar.Clone(MVCFunctions.postvalue(new XVar("sqlcontent")));
					XSession.Session["object_sql"] = sqlcontent;
					qResult = XVar.Clone(_connection.query((XVar)(sqlcontent)));
					rs = XVar.Clone(qResult.fetchAssoc());
					if(XVar.Pack(!(XVar)(rs)))
					{
						MVCFunctions.Echo(errstr);
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					if(XVar.Pack(XSession.Session["idSQL"]))
					{
						_connection.exec((XVar)(MVCFunctions.Concat("update ", _connection.addTableWrappers(new XVar("webreport_sql")), " set ", _connection.addFieldWrappers(new XVar("sqlname")), "=", _connection.prepareString((XVar)(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("namesql")))))), ",", _connection.addFieldWrappers(new XVar("sqlcontent")), "=", _connection.prepareString((XVar)(sqlcontent)), " where ", _connection.addFieldWrappers(new XVar("id")), "=", XSession.Session["idSQL"])));
						_connection.exec((XVar)(MVCFunctions.Concat("update ", _connection.addTableWrappers(new XVar("webreport_admin")), " set ", _connection.addFieldWrappers(new XVar("tablename")), "=", _connection.prepareString((XVar)(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("namesql")))))), " where ", _connection.addFieldWrappers(new XVar("tablename")), "=", _connection.prepareString((XVar)(XSession.Session["nameSQL"])))));
						XSession.Session["nameSQL"] = MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("namesql"))));
					}
					else
					{
						dynamic data = XVar.Array(), prefix = null, sname = null, sql = null;
						sname = XVar.Clone(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("namesql")))));
						prefix = new XVar(0);
						while(XVar.Pack(true))
						{
							if(XVar.Pack(0) < prefix)
							{
								sname = XVar.Clone(MVCFunctions.Concat(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("namesql")))), "_", prefix));
							}
							sql = XVar.Clone(MVCFunctions.Concat("select count(*) from ", _connection.addTableWrappers(new XVar("webreport_sql")), " where ", _connection.addFieldWrappers(new XVar("sqlname")), "=", _connection.prepareString((XVar)(sname))));
							data = XVar.Clone(_connection.query((XVar)(sql)).fetchNumeric());
							if(0 < data[0])
							{
								prefix++;
							}
							else
							{
								break;
							}
						}
						_connection.exec((XVar)(MVCFunctions.Concat("insert into ", _connection.addTableWrappers(new XVar("webreport_sql")), " (", _connection.addFieldWrappers(new XVar("sqlname")), ",", _connection.addFieldWrappers(new XVar("sqlcontent")), ") values (", _connection.prepareString((XVar)(sname)), ",", _connection.prepareString((XVar)(sqlcontent)), ")")));
						_connection.exec((XVar)(MVCFunctions.Concat("insert into ", _connection.addTableWrappers(new XVar("webreport_admin")), " (", _connection.addFieldWrappers(new XVar("tablename")), ",", _connection.addFieldWrappers(new XVar("db_type")), ",", _connection.addFieldWrappers(new XVar("group_name")), ")", " values (", _connection.prepareString((XVar)(sname)), ",'custom',", _connection.prepareString((XVar)(Security.getUserName())), ")")));
						sql = XVar.Clone(MVCFunctions.Concat("select ", _connection.addFieldWrappers(new XVar("id")), " from ", _connection.addTableWrappers(new XVar("webreport_sql")), " where ", _connection.addFieldWrappers(new XVar("sqlname")), "=", _connection.prepareString((XVar)(sname))));
						data = XVar.Clone(_connection.query((XVar)(sql)).fetchNumeric());
						XSession.Session["idSQL"] = data[0];
					}
					MVCFunctions.Echo("OK");
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(MVCFunctions.postvalue(new XVar("name")) == "viewsql")
				{
					arr = XVar.Clone(XVar.Array());
					arr = XVar.Clone(new XVar(0, 0, 1, "", 2, MVCFunctions.postvalue(new XVar("output"))));
					customSQL = XVar.Clone(arr[2]);
					XSession.Session["customSQL"] = customSQL;
					XSession.Session["idSQL"] = arr[0];
					XSession.Session["nameSQL"] = arr[1];
					XSession.Session["object_sql"] = customSQL;
					MVCFunctions.Echo(customSQL);
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(MVCFunctions.postvalue(new XVar("name")) == "getcustomsql")
				{
					arr = XVar.Clone(XVar.Array());
					arr = XVar.Clone(CommonFunctions.WRgetCurrentCustomSQL((XVar)(MVCFunctions.postvalue(new XVar("output")))));
					customSQL = XVar.Clone(arr[2]);
					XSession.Session["customSQL"] = customSQL;
					XSession.Session["idSQL"] = arr[0];
					XSession.Session["nameSQL"] = arr[1];
					XSession.Session["object_sql"] = customSQL;
					MVCFunctions.Echo(customSQL);
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				arr = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.DecodeUTF8((XVar)(MVCFunctions.postvalue(new XVar("output")))))));
				_connection.exec((XVar)(MVCFunctions.Concat("delete from ", _connection.addTableWrappers(new XVar("webreport_admin")))));
				foreach (KeyValuePair<XVar, dynamic> val in arr.GetEnumerator())
				{
					_connection.exec((XVar)(MVCFunctions.Concat("insert into ", _connection.addTableWrappers(new XVar("webreport_admin")), " (", _connection.addFieldWrappers(new XVar("tablename")), ",", _connection.addFieldWrappers(new XVar("db_type")), ",", _connection.addFieldWrappers(new XVar("group_name")), ")", " values (", _connection.prepareString((XVar)(val.Value["table"])), ",'", val.Value["db_type"], "',", _connection.prepareString((XVar)(val.Value["group"])), ")")));
				}
				MVCFunctions.Echo("OK");
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
