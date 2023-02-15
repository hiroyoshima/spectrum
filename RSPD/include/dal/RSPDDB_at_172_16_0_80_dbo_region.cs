using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_region : tDALTable
    {
        public XVar id;
        public XVar region;
        public static void Init()
        {
            XVar dalTableregion = XVar.Array();
            dalTableregion["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTableregion["region"] = new XVar("type", 200, "varname", "region", "name", "region", "autoInc", "0");
	        dalTableregion.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_region"] = dalTableregion;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_region()
        {
            			this.m_TableName = "dbo.region";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_region";
        }
    }
}