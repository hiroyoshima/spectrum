using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_baranggay : tDALTable
    {
        public XVar id;
        public XVar barangay;
        public XVar city;
        public static void Init()
        {
            XVar dalTablebaranggay = XVar.Array();
            dalTablebaranggay["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablebaranggay["barangay"] = new XVar("type", 200, "varname", "barangay", "name", "barangay", "autoInc", "0");
            dalTablebaranggay["city"] = new XVar("type", 3, "varname", "city", "name", "city", "autoInc", "0");
	        dalTablebaranggay.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_baranggay"] = dalTablebaranggay;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_baranggay()
        {
            			this.m_TableName = "dbo.baranggay";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_baranggay";
        }
    }
}