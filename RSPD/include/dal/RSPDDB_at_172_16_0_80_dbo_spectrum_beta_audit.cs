using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_audit : tDALTable
    {
        public XVar id;
        public XVar datetime;
        public XVar ip;
        public XVar user;
        public XVar table;
        public XVar action;
        public XVar description;
        public static void Init()
        {
            XVar dalTablespectrum_beta_audit = XVar.Array();
            dalTablespectrum_beta_audit["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablespectrum_beta_audit["datetime"] = new XVar("type", 135, "varname", "datetime", "name", "datetime", "autoInc", "0");
            dalTablespectrum_beta_audit["ip"] = new XVar("type", 200, "varname", "ip", "name", "ip", "autoInc", "0");
            dalTablespectrum_beta_audit["user"] = new XVar("type", 200, "varname", "user", "name", "user", "autoInc", "0");
            dalTablespectrum_beta_audit["table"] = new XVar("type", 200, "varname", "table", "name", "table", "autoInc", "0");
            dalTablespectrum_beta_audit["action"] = new XVar("type", 200, "varname", "action", "name", "action", "autoInc", "0");
            dalTablespectrum_beta_audit["description"] = new XVar("type", 201, "varname", "description", "name", "description", "autoInc", "0");
	        dalTablespectrum_beta_audit.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_beta_audit"] = dalTablespectrum_beta_audit;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_audit()
        {
            			this.m_TableName = "dbo.spectrum_beta_audit";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_beta_audit";
        }
    }
}