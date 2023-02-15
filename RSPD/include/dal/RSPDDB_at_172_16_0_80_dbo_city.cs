using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_city : tDALTable
    {
        public XVar id;
        public XVar city;
        public XVar province;
        public XVar zipcode;
        public static void Init()
        {
            XVar dalTablecity = XVar.Array();
            dalTablecity["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablecity["city"] = new XVar("type", 200, "varname", "city", "name", "city", "autoInc", "0");
            dalTablecity["province"] = new XVar("type", 200, "varname", "province", "name", "province", "autoInc", "0");
            dalTablecity["zipcode"] = new XVar("type", 3, "varname", "zipcode", "name", "zipcode", "autoInc", "0");
	        dalTablecity.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_city"] = dalTablecity;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_city()
        {
            			this.m_TableName = "dbo.city";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_city";
        }
    }
}