using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;
using System.ComponentModel.Composition;
using System.Web;
using runnerDotNet;

namespace runnerDotNet
{
	[Export(typeof(IEventProviderCS_admin_users))]
	public class eventclassCS_admin_users : IEventProviderCS_admin_users
	{


		//	handlers
// Before record deleted
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{
/*
//RSPD FORM
dynamic tblModels = GlobalVars.dal.Table("dbo.rspdHeader");
XVar rs = tblModels.Query("id='" + deleted_values["userCreate"].ToString() + "'","");
XVar data = CommonFunctions.db_fetch_array(rs);
if(data)
{
message = "Record Still Existed In RSPD Form";
return false;
}
//Delivery Unit
dynamic tblModels = GlobalVars.dal.Table("dbo.rspdHeader");
XVar rs = tblModels.Query("id='" + deleted_values["createdBy"].ToString() + "'","");
XVar data = CommonFunctions.db_fetch_array(rs);
if(data)
{
message = "Record Still Existed in Delivery Unit";
return false;
}
*/


// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeDelete

// Before record added
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
values["password"] = MVCFunctions.getPasswordHash(values["password"]);
values["active"] = '1';

if(values["groupPermission"] == "Admin"){
values["groupid"] = "-1";
}else if(values["groupPermission"] == "Delivery Unit"){
values["groupid"] = "3";
}


// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeAdd

// After record added
		public XVar AfterAdd(dynamic values, dynamic keys, dynamic inline, dynamic pageObject)
		{
//INSERT PERMISSION
dynamic data = XVar.Array();
data["UserName"] = values["username"];
data["GroupID"] = values["groupid"];
DB.Insert("spectrum_betaugmembers", data);


return null;

		} // AfterAdd

// Before Insert Record
		public XVar BeforeInsert(dynamic rawvalues, dynamic values, dynamic pageObject, ref dynamic message)
		{
values["password"] = MVCFunctions.getPasswordHash(rawvalues["password"]);
values["active"] = '1';
// Place event code here.
// Use "Add Action" button to add code snippets.

dynamic data;
dynamic rs = DB.Query("select dbo.spectrum_betauggroups.GroupID,dbo.spectrum_betauggroups.Label from dbo.spectrum_betauggroups WHERE Label =" +"'"+ rawvalues["groupid"].ToString()+"'");
data = rs.fetchAssoc();
if(data)
{
 values["groupid"] = data["GroupID"]; 
}



return true;
return null;

		} // BeforeInsert




	}

}