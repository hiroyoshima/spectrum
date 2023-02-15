using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_settings : tDALTable
    {
        public XVar ID;
        public XVar TYPE;
        public XVar NAME;
        public XVar USERNAME;
        public XVar COOKIE;
        public XVar SEARCH;
        public XVar fldTABLENAME;
        public static void Init()
        {
            XVar dalTablespectrum_beta_settings = XVar.Array();
            dalTablespectrum_beta_settings["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablespectrum_beta_settings["TYPE"] = new XVar("type", 3, "varname", "TYPE", "name", "TYPE", "autoInc", "0");
            dalTablespectrum_beta_settings["NAME"] = new XVar("type", 202, "varname", "NAME", "name", "NAME", "autoInc", "0");
            dalTablespectrum_beta_settings["USERNAME"] = new XVar("type", 202, "varname", "USERNAME", "name", "USERNAME", "autoInc", "0");
            dalTablespectrum_beta_settings["COOKIE"] = new XVar("type", 200, "varname", "COOKIE", "name", "COOKIE", "autoInc", "0");
            dalTablespectrum_beta_settings["SEARCH"] = new XVar("type", 203, "varname", "SEARCH", "name", "SEARCH", "autoInc", "0");
            dalTablespectrum_beta_settings["TABLENAME"] = new XVar("type", 200, "varname", "fldTABLENAME", "name", "TABLENAME", "autoInc", "0");
	        dalTablespectrum_beta_settings.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_beta_settings"] = dalTablespectrum_beta_settings;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_settings()
        {
            			this.m_TableName = "dbo.spectrum_beta_settings";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_beta_settings";
        }
    }
}