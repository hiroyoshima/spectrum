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
		public XVar buttonhandler()
		{
			try
			{
				dynamic buttId = null, eventId = null, i = null, page = null, table = null, var_params = XVar.Array();
				ProjectSettings pSet;
				GlobalVars.init_dbcommon();
				if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				var_params = XVar.Clone(MVCFunctions.my_json_decode((XVar)(MVCFunctions.postvalue(new XVar("params")))));
				if(XVar.Pack(var_params["_base64fields"]))
				{
					foreach (KeyValuePair<XVar, dynamic> f in var_params["_base64fields"].GetEnumerator())
					{
						var_params.InitAndSetArrayItem(MVCFunctions.base64_str2bin((XVar)(var_params[f.Value])), f.Value);
					}
				}
				buttId = XVar.Clone(var_params["buttId"]);
				eventId = XVar.Clone(MVCFunctions.postvalue(new XVar("event")));
				table = XVar.Clone(var_params["table"]);
				if(XVar.Pack(!(XVar)(CommonFunctions.GetTableURL((XVar)(table)))))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				page = XVar.Clone(var_params["page"]);
				if(XVar.Pack(!(XVar)(Security.userCanSeePage((XVar)(table), (XVar)(page)))))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(table), new XVar(""), (XVar)(page)));
				if(XVar.Pack(buttId))
				{
					dynamic pageButtons = null;
					pageButtons = XVar.Clone(pSet.customButtons());
					if(XVar.Equals(XVar.Pack(MVCFunctions.array_search((XVar)(buttId), (XVar)(pageButtons))), XVar.Pack(false)))
					{
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterTable")), "masterTable");
				var_params.InitAndSetArrayItem(XVar.Array(), "masterKeys");
				i = new XVar(1);
				while(XVar.Pack(MVCFunctions.REQUESTKeyExists(MVCFunctions.Concat("masterkey", i))))
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(MVCFunctions.Concat("masterkey", i)), "masterKeys", i);
					i++;
				}
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
