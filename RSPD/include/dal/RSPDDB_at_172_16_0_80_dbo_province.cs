using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_province : tDALTable
    {
        public XVar id;
        public XVar province;
        public XVar region;
        public static void Init()
        {
            XVar dalTableprovince = XVar.Array();
            dalTableprovince["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTableprovince["province"] = new XVar("type", 200, "varname", "province", "name", "province", "autoInc", "0");
            dalTableprovince["region"] = new XVar("type", 200, "varname", "region", "name", "region", "autoInc", "0");
	        dalTableprovince.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_province"] = dalTableprovince;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_province()
        {
            			this.m_TableName = "dbo.province";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_province";
        }
    }
}