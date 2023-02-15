using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_stage : tDALTable
    {
        public XVar ID;
        public XVar StageDescription;
        public static void Init()
        {
            XVar dalTablestage = XVar.Array();
            dalTablestage["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablestage["StageDescription"] = new XVar("type", 200, "varname", "StageDescription", "name", "StageDescription", "autoInc", "0");
	        dalTablestage.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_stage"] = dalTablestage;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_stage()
        {
            			this.m_TableName = "dbo.stage";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_stage";
        }
    }
}