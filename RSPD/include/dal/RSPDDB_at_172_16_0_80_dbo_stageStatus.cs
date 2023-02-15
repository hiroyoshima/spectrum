using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_stageStatus : tDALTable
    {
        public XVar ID;
        public XVar stage;
        public XVar status;
        public static void Init()
        {
            XVar dalTablestageStatus = XVar.Array();
            dalTablestageStatus["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablestageStatus["stage"] = new XVar("type", 3, "varname", "stage", "name", "stage", "autoInc", "0");
            dalTablestageStatus["status"] = new XVar("type", 200, "varname", "status", "name", "status", "autoInc", "0");
	        dalTablestageStatus.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_stageStatus"] = dalTablestageStatus;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_stageStatus()
        {
            			this.m_TableName = "dbo.stageStatus";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_stageStatus";
        }
    }
}