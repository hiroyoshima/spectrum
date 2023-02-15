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
	public partial class RightsPage_AD : RightsPage
	{
		protected static bool skipRightsPage_ADCtor = false;
		public RightsPage_AD(dynamic var_params)
			:base((XVar)var_params)
		{
			if(skipRightsPage_ADCtor)
			{
				skipRightsPage_ADCtor = false;
				return;
			}
		}
		public override XVar fillGroupsArr()
		{
			dynamic grConnection = null, qResult = null, sql = null, tdata = XVar.Array();
			grConnection = XVar.Clone(GlobalVars.cman.getForUserGroups());
			this.groups.InitAndSetArrayItem(MVCFunctions.Concat("<", "Default", ">"), -2);
			this.groups.InitAndSetArrayItem(MVCFunctions.Concat("<", "Guest", ">"), -3);
			sql = XVar.Clone(MVCFunctions.Concat("select ", grConnection.addFieldWrappers(new XVar("GroupID")), ", ", grConnection.addFieldWrappers(new XVar("Label")), " from ", grConnection.addTableWrappers(new XVar("dbo.spectrum_betauggroups")), " order by ", grConnection.addFieldWrappers(new XVar("Label"))));
			qResult = XVar.Clone(grConnection.query((XVar)(sql)));
			while(XVar.Pack(tdata = XVar.Clone(qResult.fetchNumeric())))
			{
				this.groups.InitAndSetArrayItem(tdata[1], tdata[0]);
			}
			return null;
		}
		public override XVar commonAssign()
		{
			base.commonAssign();
			this.xt.assign(new XVar("menu_block"), new XVar(false));
			this.hideItem(new XVar("rights_rename_group"));
			return null;
		}
	}
}
