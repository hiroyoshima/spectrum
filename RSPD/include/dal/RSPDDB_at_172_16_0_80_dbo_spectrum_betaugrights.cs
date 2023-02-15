using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betaugrights : tDALTable
    {
        public XVar fldTableName;
        public XVar GroupID;
        public XVar AccessMask;
        public XVar Page;
        public static void Init()
        {
            XVar dalTablespectrum_betaugrights = XVar.Array();
            dalTablespectrum_betaugrights["TableName"] = new XVar("type", 200, "varname", "fldTableName", "name", "TableName", "autoInc", "0");
            dalTablespectrum_betaugrights["GroupID"] = new XVar("type", 3, "varname", "GroupID", "name", "GroupID", "autoInc", "0");
            dalTablespectrum_betaugrights["AccessMask"] = new XVar("type", 200, "varname", "AccessMask", "name", "AccessMask", "autoInc", "0");
            dalTablespectrum_betaugrights["Page"] = new XVar("type", 201, "varname", "Page", "name", "Page", "autoInc", "0");
	        dalTablespectrum_betaugrights.InitAndSetArrayItem(true, "TableName", "key");
	        dalTablespectrum_betaugrights.InitAndSetArrayItem(true, "GroupID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_betaugrights"] = dalTablespectrum_betaugrights;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betaugrights()
        {
            			this.m_TableName = "dbo.spectrum_betaugrights";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_betaugrights";
        }
    }
}