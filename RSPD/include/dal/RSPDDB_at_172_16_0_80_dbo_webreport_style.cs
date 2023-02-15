using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_webreport_style : tDALTable
    {
        public XVar report_style_id;
        public XVar type;
        public XVar field;
        public XVar group;
        public XVar style_str;
        public XVar uniq;
        public XVar repname;
        public XVar styletype;
        public static void Init()
        {
            XVar dalTablewebreport_style = XVar.Array();
            dalTablewebreport_style["report_style_id"] = new XVar("type", 3, "varname", "report_style_id", "name", "report_style_id", "autoInc", "1");
            dalTablewebreport_style["type"] = new XVar("type", 200, "varname", "type", "name", "type", "autoInc", "0");
            dalTablewebreport_style["field"] = new XVar("type", 3, "varname", "field", "name", "field", "autoInc", "0");
            dalTablewebreport_style["group"] = new XVar("type", 3, "varname", "group", "name", "group", "autoInc", "0");
            dalTablewebreport_style["style_str"] = new XVar("type", 201, "varname", "style_str", "name", "style_str", "autoInc", "0");
            dalTablewebreport_style["uniq"] = new XVar("type", 3, "varname", "uniq", "name", "uniq", "autoInc", "0");
            dalTablewebreport_style["repname"] = new XVar("type", 200, "varname", "repname", "name", "repname", "autoInc", "0");
            dalTablewebreport_style["styletype"] = new XVar("type", 200, "varname", "styletype", "name", "styletype", "autoInc", "0");
	        dalTablewebreport_style.InitAndSetArrayItem(true, "report_style_id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_webreport_style"] = dalTablewebreport_style;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_webreport_style()
        {
            			this.m_TableName = "dbo.webreport_style";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_webreport_style";
        }
    }
}