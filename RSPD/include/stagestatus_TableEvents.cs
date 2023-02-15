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
	[Export(typeof(IEventProviderCS_stagestatus))]
	public class eventclassCS_stagestatus : IEventProviderCS_stagestatus
	{


		//	handlers
// Before record deleted
		public XVar BeforeDelete(dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject)
		{
dynamic tblModels = GlobalVars.dal.Table("dbo.rspdHeader");
XVar rs = tblModels.Query("stageStatus='" + deleted_values["stageStatus"].ToString() + "'","");
XVar data = CommonFunctions.db_fetch_array(rs);
if(data)
{
message = "Record Still Existed In RSPD Form";
return false;
}
else
{
return true;
}


// Place event code here.
// Use "Add Action" button to add code snippets.

return true;
return null;

		} // BeforeDelete




	}

}