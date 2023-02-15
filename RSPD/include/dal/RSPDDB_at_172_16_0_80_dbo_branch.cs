using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_branch : tDALTable
    {
        public XVar id;
        public XVar branchName;
        public static void Init()
        {
            XVar dalTablebranch = XVar.Array();
            dalTablebranch["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTablebranch["branchName"] = new XVar("type", 200, "varname", "branchName", "name", "branchName", "autoInc", "0");
	        dalTablebranch.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_branch"] = dalTablebranch;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_branch()
        {
            			this.m_TableName = "dbo.branch";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_branch";
        }
    }
}