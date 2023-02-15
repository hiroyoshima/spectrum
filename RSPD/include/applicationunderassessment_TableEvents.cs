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
	[Export(typeof(IEventProviderCS_applicationunderassessment))]
	public class eventclassCS_applicationunderassessment : IEventProviderCS_applicationunderassessment
	{


		//	handlers
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





	}

}