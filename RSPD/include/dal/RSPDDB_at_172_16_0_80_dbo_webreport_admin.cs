using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_webreport_admin : tDALTable
    {
        public XVar id;
        public XVar fldtablename;
        public XVar db_type;
        public XVar group_name;
        public static void Init()
        {
            XVar dalTablewebreport_admin = XVar.Array();
            dalTablewebreport_admin["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablewebreport_admin["tablename"] = new XVar("type", 200, "varname", "fldtablename", "name", "tablename", "autoInc", "0");
            dalTablewebreport_admin["db_type"] = new XVar("type", 200, "varname", "db_type", "name", "db_type", "autoInc", "0");
            dalTablewebreport_admin["group_name"] = new XVar("type", 200, "varname", "group_name", "name", "group_name", "autoInc", "0");
	        dalTablewebreport_admin.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_webreport_admin"] = dalTablewebreport_admin;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_webreport_admin()
        {
            			this.m_TableName = "dbo.webreport_admin";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_webreport_admin";
        }
    }
}