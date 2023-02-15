using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_webreports : tDALTable
    {
        public XVar rpt_id;
        public XVar rpt_name;
        public XVar rpt_title;
        public XVar rpt_cdate;
        public XVar rpt_mdate;
        public XVar rpt_content;
        public XVar rpt_owner;
        public XVar rpt_status;
        public XVar rpt_type;
        public static void Init()
        {
            XVar dalTablewebreports = XVar.Array();
            dalTablewebreports["rpt_id"] = new XVar("type", 3, "varname", "rpt_id", "name", "rpt_id", "autoInc", "1");
            dalTablewebreports["rpt_name"] = new XVar("type", 200, "varname", "rpt_name", "name", "rpt_name", "autoInc", "0");
            dalTablewebreports["rpt_title"] = new XVar("type", 200, "varname", "rpt_title", "name", "rpt_title", "autoInc", "0");
            dalTablewebreports["rpt_cdate"] = new XVar("type", 135, "varname", "rpt_cdate", "name", "rpt_cdate", "autoInc", "0");
            dalTablewebreports["rpt_mdate"] = new XVar("type", 135, "varname", "rpt_mdate", "name", "rpt_mdate", "autoInc", "0");
            dalTablewebreports["rpt_content"] = new XVar("type", 201, "varname", "rpt_content", "name", "rpt_content", "autoInc", "0");
            dalTablewebreports["rpt_owner"] = new XVar("type", 200, "varname", "rpt_owner", "name", "rpt_owner", "autoInc", "0");
            dalTablewebreports["rpt_status"] = new XVar("type", 200, "varname", "rpt_status", "name", "rpt_status", "autoInc", "0");
            dalTablewebreports["rpt_type"] = new XVar("type", 200, "varname", "rpt_type", "name", "rpt_type", "autoInc", "0");
	        dalTablewebreports.InitAndSetArrayItem(true, "rpt_id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_webreports"] = dalTablewebreports;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_webreports()
        {
            			this.m_TableName = "dbo.webreports";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_webreports";
        }
    }
}