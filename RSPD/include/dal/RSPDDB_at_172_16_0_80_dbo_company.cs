using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_company : tDALTable
    {
        public XVar id;
        public XVar companyName;
        public static void Init()
        {
            XVar dalTablecompany = XVar.Array();
            dalTablecompany["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablecompany["companyName"] = new XVar("type", 200, "varname", "companyName", "name", "companyName", "autoInc", "0");
	        dalTablecompany.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_company"] = dalTablecompany;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_company()
        {
            			this.m_TableName = "dbo.company";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_company";
        }
    }
}