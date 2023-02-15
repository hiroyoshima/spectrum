using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betauggroups : tDALTable
    {
        public XVar GroupID;
        public XVar Label;
        public XVar Provider;
        public XVar Comment;
        public static void Init()
        {
            XVar dalTablespectrum_betauggroups = XVar.Array();
            dalTablespectrum_betauggroups["GroupID"] = new XVar("type", 3, "varname", "GroupID", "name", "GroupID", "autoInc", "1");
            dalTablespectrum_betauggroups["Label"] = new XVar("type", 200, "varname", "Label", "name", "Label", "autoInc", "0");
            dalTablespectrum_betauggroups["Provider"] = new XVar("type", 200, "varname", "Provider", "name", "Provider", "autoInc", "0");
            dalTablespectrum_betauggroups["Comment"] = new XVar("type", 201, "varname", "Comment", "name", "Comment", "autoInc", "0");
	        dalTablespectrum_betauggroups.InitAndSetArrayItem(true, "GroupID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_betauggroups"] = dalTablespectrum_betauggroups;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_betauggroups()
        {
            			this.m_TableName = "dbo.spectrum_betauggroups";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_betauggroups";
        }
    }
}