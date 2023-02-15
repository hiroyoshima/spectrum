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
	public partial class ViewUserControl : ViewControl
	{
		protected static bool skipViewUserControlCtor = false;
		public ViewUserControl(dynamic _param_field, dynamic _param_container, dynamic _param_pageObject) // proxy constructor
			:base((XVar)_param_field, (XVar)_param_container, (XVar)_param_pageObject) {}

		public virtual XVar initUserControl()
		{
			return null;
		}
		public virtual XVar addViewPluginJSControl(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			if(this.viewFormat == name)
			{
				this.AddJSFile((XVar)(MVCFunctions.Concat("include/runnerJS/controls/", name, ".js")), new XVar("include/runnerJS/viewControls/ViewControl.js"));
				this.getJSControl();
				foreach (KeyValuePair<XVar, dynamic> settingValue in this.settings.GetEnumerator())
				{
					this.addJSControlSetting((XVar)(settingValue.Key), (XVar)(settingValue.Value));
				}
			}
			return null;
		}
		public virtual XVar init()
		{
			this.userControl = new XVar(true);
			return null;
		}
		public override XVar getExportValue(dynamic data, dynamic _param_keylink = null, dynamic _param_html = null)
		{
			#region default values
			if(_param_keylink as Object == null) _param_keylink = new XVar("");
			if(_param_html as Object == null) _param_html = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic keylink = XVar.Clone(_param_keylink);
			dynamic html = XVar.Clone(_param_html);
			#endregion

			return data[this.field];
		}
		public override XVar neededLoadJSFiles()
		{
			return true;
		}
		public override XVar getPdfValue(dynamic data, dynamic _param_keylink = null)
		{
			#region default values
			if(_param_keylink as Object == null) _param_keylink = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic keylink = XVar.Clone(_param_keylink);
			#endregion

			return "''";
		}
	}
}
