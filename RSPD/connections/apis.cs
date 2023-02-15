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
	public partial class RestManager : XClass
	{
		protected dynamic _tablesConnectionIds;
		protected dynamic _connectionsData;
		protected dynamic _connectionsIdByName = XVar.Array();
		public RestManager()
		{
			this._setConnectionsData();
		}
		protected virtual XVar _setTablesConnectionIds()
		{
			dynamic connectionsIds = XVar.Array();
			connectionsIds = XVar.Clone(XVar.Array());
			this._tablesConnectionIds = connectionsIds;
			return null;
		}
		protected virtual XVar _setConnectionsData()
		{
			dynamic connectionsData = XVar.Array(), data = XVar.Array();
			connectionsData = XVar.Clone(XVar.Array());
			this._connectionsData = connectionsData;
			return null;
		}
		public virtual XVar getConnection(dynamic _param_id)
		{
			#region pass-by-value parameters
			dynamic id = XVar.Clone(_param_id);
			#endregion

			if(id == Constants.spidGOOGLEDRIVE)
			{
				return CommonFunctions.getGoogleDriveConnection();
			}
			if(id == Constants.spidONEDRIVE)
			{
				return CommonFunctions.getOneDriveConnection();
			}
			if(id == Constants.spidDROPBOX)
			{
				return CommonFunctions.getDropboxConnection();
			}
			if(XVar.Pack(!(XVar)(this._connectionsData[id])))
			{
				return null;
			}
			return new RestConnection((XVar)(this._connectionsData[id]));
		}
		public virtual XVar idByName(dynamic _param_name)
		{
			#region pass-by-value parameters
			dynamic name = XVar.Clone(_param_name);
			#endregion

			foreach (KeyValuePair<XVar, dynamic> data in this._connectionsData.GetEnumerator())
			{
				if(data.Value["connName"] == name)
				{
					return data.Key;
				}
			}
			foreach (KeyValuePair<XVar, dynamic> data in this._connectionsData.GetEnumerator())
			{
				return data.Key;
			}
			return null;
		}
	}
}
