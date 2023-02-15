using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_sysdiagrams : tDALTable
    {
        public XVar name;
        public XVar principal_id;
        public XVar diagram_id;
        public XVar version;
        public XVar definition;
        public static void Init()
        {
            XVar dalTablesysdiagrams = XVar.Array();
            dalTablesysdiagrams["name"] = new XVar("type", 202, "varname", "name", "name", "name", "autoInc", "0");
            dalTablesysdiagrams["principal_id"] = new XVar("type", 3, "varname", "principal_id", "name", "principal_id", "autoInc", "0");
            dalTablesysdiagrams["diagram_id"] = new XVar("type", 3, "varname", "diagram_id", "name", "diagram_id", "autoInc", "1");
            dalTablesysdiagrams["version"] = new XVar("type", 3, "varname", "version", "name", "version", "autoInc", "0");
            dalTablesysdiagrams["definition"] = new XVar("type", 205, "varname", "definition", "name", "definition", "autoInc", "0");
	        dalTablesysdiagrams.InitAndSetArrayItem(true, "diagram_id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_sysdiagrams"] = dalTablesysdiagrams;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_sysdiagrams()
        {
            			this.m_TableName = "dbo.sysdiagrams";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_sysdiagrams";
        }
    }
}