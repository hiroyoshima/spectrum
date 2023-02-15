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
	[Export(typeof(IEventProviderCS_dbo_rspdheader))]
	public class eventclassCS_dbo_rspdheader : IEventProviderCS_dbo_rspdheader
	{


		//	handlers
// Before record added
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
//AFTER RECORD CODE
values["userCreate"] = XSession.Session["user"];
values["dateCreated"] = new XVar(DateTime.Now);


//Saving STATUS
values["stage"] = 1;
values["stageStatus"] = 1;


//PROCESS RECORD VALUE
dynamic date = DateTime.Now.ToString("MM/dd/yyyy");
dynamic data;
dynamic rs = DB.Query("select * from dbo.transactionSetup WHERE defaulttransaction = 'RSPD' AND autoNumber = 1");
data = rs.fetchAssoc();
if(data)
{
	dynamic dataCount;
	dynamic rsCount = DB.Query("select count(ID) as maxID from dbo.rspdHeader WHERE FORMAT(dateCreated, 'MM/dd/yyyy') = FORMAT(getDate(), 'MM/dd/yyyy')");
	dataCount = rsCount.fetchAssoc();
	if(dataCount)
	{
	values["referenceID"] = dataCount["maxID"] + 1;
	dynamic leadz = 4 - dataCount["maxID"].Length();
	dynamic repeatingZeroes = new string('0', leadz);
	dynamic cnt = dataCount["maxID"] + 1;
	values["referenceID"] = date.ToString() + "-" + repeatingZeroes.ToString() + cnt.ToString();
	}
}

// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeAdd

// Before record updated
		public XVar BeforeEdit(dynamic values, dynamic where, dynamic oldvalues, dynamic keys, ref dynamic message, dynamic inline, dynamic pageObject)
		{
values["userUpdate"] = XSession.Session["user"];
values["dateUpdated"] = new XVar(DateTime.Now);

// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeEdit

// Before record deleted
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{


//**********  Check if specific record exists  ************


//**********  Check if specific record exists  ************



// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeDelete


// Process record values
		public XVar ProcessValuesAdd(dynamic values, dynamic pageObject)
		{
values["serviceArea"] = XSession.Session["user"];

// Place event code here.
// Use "Add Action" button to add code snippets.
return null;

		} // ProcessValuesAdd




	}

}