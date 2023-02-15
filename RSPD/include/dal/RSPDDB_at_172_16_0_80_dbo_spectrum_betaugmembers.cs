using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betaugmembers : tDALTable
    {
        public XVar UserName;
        public XVar GroupID;
        public XVar Provider;
        public static void Init()
        {
            XVar dalTablespectrum_betaugmembers = XVar.Array();
            dalTablespectrum_betaugmembers["UserName"] = new XVar("type", 200, "varname", "UserName", "name", "UserName", "autoInc", "0");
            dalTablespectrum_betaugmembers["GroupID"] = new XVar("type", 3, "varname", "GroupID", "name", "GroupID", "autoInc", "0");
            dalTablespectrum_betaugmembers["Provider"] = new XVar("type", 200, "varname", "Provider", "name", "Provider", "autoInc", "0");
	        dalTablespectrum_betaugmembers.InitAndSetArrayItem(true, "UserName", "key");
	        dalTablespectrum_betaugmembers.InitAndSetArrayItem(true, "GroupID", "key");
	        dalTablespectrum_betaugmembers.InitAndSetArrayItem(true, "Provider", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_betaugmembers"] = dalTablespectrum_betaugmembers;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betaugmembers()
        {
            			this.m_TableName = "dbo.spectrum_betaugmembers";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_betaugmembers";
        }
    }
}