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
		public XVar save_style()
		{
			try
			{
				dynamic _connection = null, arr = XVar.Array(), arrayer = null, repname = null, strSQL = null, xml = null;
				GlobalVars.init_dbcommon();
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				_connection = XVar.Clone(GlobalVars.cman.getForWebReports());
				xml = XVar.Clone(new xml());
				if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("str_xml")))))
				{
					MVCFunctions.Echo("Error: Script didn't get data. Try once again.");
					MVCFunctions.Echo(new XVar(0));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				arr = XVar.Clone(xml.xml_to_array((XVar)(MVCFunctions.postvalue(new XVar("str_xml")))));
				repname = XVar.Clone(MVCFunctions.postvalue(new XVar("repname")));
				if(MVCFunctions.postvalue("str_xml") == "del_all")
				{
					strSQL = XVar.Clone(MVCFunctions.Concat("DELETE FROM ", _connection.addTableWrappers(new XVar("webreport_style")), " WHERE ", _connection.addFieldWrappers(new XVar("repname")), "=", _connection.prepareString((XVar)(repname))));
					_connection.exec((XVar)(strSQL));
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				arrayer = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> style_record in arr.GetEnumerator())
				{
					if(style_record.Value["type"] == "table")
					{
						strSQL = XVar.Clone(MVCFunctions.Concat("DELETE FROM ", _connection.addTableWrappers(new XVar("webreport_style")), " WHERE (", _connection.addFieldWrappers(new XVar("repname")), "=", _connection.prepareString((XVar)(repname)), " AND ", _connection.addFieldWrappers(new XVar("styletype")), "='", style_record.Value["params"]["styleType"], "')"));
						_connection.exec((XVar)(strSQL));
					}
					if(style_record.Value["type"] == "group")
					{
						if(style_record.Value["params"]["groupName"] != 0)
						{
							strSQL = XVar.Clone(MVCFunctions.Concat("DELETE FROM ", _connection.addTableWrappers(new XVar("webreport_style")), " WHERE (", _connection.addFieldWrappers(new XVar("group")), " = ", 0 + style_record.Value["params"]["groupName"], " AND ", _connection.addFieldWrappers(new XVar("repname")), "=", _connection.prepareString((XVar)(repname)), " AND ", _connection.addFieldWrappers(new XVar("styletype")), "='", style_record.Value["params"]["styleType"], "' AND (", _connection.addFieldWrappers(new XVar("type")), "='cell' OR ", _connection.addFieldWrappers(new XVar("type")), "='group'))"));
							_connection.exec((XVar)(strSQL));
						}
					}
					if(style_record.Value["type"] == "field")
					{
						strSQL = XVar.Clone(MVCFunctions.Concat("DELETE FROM ", _connection.addTableWrappers(new XVar("webreport_style")), " WHERE (", _connection.addFieldWrappers(new XVar("field")), " = ", style_record.Value["params"]["fieldName"] + 0, " AND ", _connection.addFieldWrappers(new XVar("repname")), "=", _connection.prepareString((XVar)(repname)), " AND ", _connection.addFieldWrappers(new XVar("styletype")), "='", style_record.Value["params"]["styleType"], "' and ", _connection.addFieldWrappers(new XVar("type")), "='field')"));
						_connection.exec((XVar)(strSQL));
					}
					if(style_record.Value["type"] == "cell")
					{
						style_record.Value.InitAndSetArrayItem((int)style_record.Value["params"]["uniq"], "params", "uniq");
						strSQL = XVar.Clone(MVCFunctions.Concat("DELETE FROM ", _connection.addTableWrappers(new XVar("webreport_style")), " WHERE (", _connection.addFieldWrappers(new XVar("type")), " = '", style_record.Value["type"], "' AND ", _connection.addFieldWrappers(new XVar("field")), " = ", style_record.Value["params"]["fieldName"] + 0, " AND ", _connection.addFieldWrappers(new XVar("group")), " = ", 0 + style_record.Value["params"]["groupName"], " AND ", _connection.addFieldWrappers(new XVar("uniq")), "=", (int)style_record.Value["params"]["uniq"], " AND ", _connection.addFieldWrappers(new XVar("repname")), "=", _connection.prepareString((XVar)(repname)), " AND ", _connection.addFieldWrappers(new XVar("styletype")), "='", style_record.Value["params"]["styleType"], "')"));
						_connection.exec((XVar)(strSQL));
					}
					strSQL = XVar.Clone(MVCFunctions.Concat("INSERT INTO ", _connection.addTableWrappers(new XVar("webreport_style")), " (", _connection.addFieldWrappers(new XVar("type")), ",", _connection.addFieldWrappers(new XVar("field")), ",", _connection.addFieldWrappers(new XVar("group")), ",", _connection.addFieldWrappers(new XVar("style_str")), ",", _connection.addFieldWrappers(new XVar("uniq")), ",", _connection.addFieldWrappers(new XVar("repname")), ",", _connection.addFieldWrappers(new XVar("styletype")), ") VALUES ('", style_record.Value["type"], "',", _connection.prepareString((XVar)(style_record.Value["params"]["fieldName"])), ",", style_record.Value["params"]["groupName"], ",", _connection.prepareString((XVar)(style_record.Value["params"]["styleStr"])), ",", style_record.Value["params"]["uniq"], ",", _connection.prepareString((XVar)(repname)), ",'", style_record.Value["params"]["styleType"], "')"));
					_connection.exec((XVar)(strSQL));
				}
				MVCFunctions.Echo("OK");
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
