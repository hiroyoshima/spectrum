using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_classStation : tDALTable
    {
        public XVar id;
        public XVar classStationService;
        public XVar application_type;
        public static void Init()
        {
            XVar dalTableclassStation = XVar.Array();
            dalTableclassStation["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTableclassStation["classStationService"] = new XVar("type", 200, "varname", "classStationService", "name", "classStationService", "autoInc", "0");
            dalTableclassStation["application_type"] = new XVar("type", 200, "varname", "application_type", "name", "application_type", "autoInc", "0");
	        dalTableclassStation.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_classStation"] = dalTableclassStation;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_classStation()
        {
            			this.m_TableName = "dbo.classStation";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_classStation";
        }
    }
}