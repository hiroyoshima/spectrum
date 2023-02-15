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
	[Export(typeof(IEventProviderCS_delivery_unit))]
	public class eventclassCS_delivery_unit : IEventProviderCS_delivery_unit
	{


		//	handlers
// Before record added
		public XVar BeforeAdd(dynamic values, ref dynamic message, dynamic inline, dynamic pageObject)
		{
values["password"] = MVCFunctions.getPasswordHash(values["password"]);
// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeAdd




	}

}