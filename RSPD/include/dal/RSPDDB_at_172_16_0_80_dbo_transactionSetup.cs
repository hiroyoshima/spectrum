using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_transactionSetup : tDALTable
    {
        public XVar id;
        public XVar defaulttransaction;
        public XVar defaultStatus;
        public XVar autonumber;
        public XVar prefix;
        public XVar leadingZeros;
        public XVar seriesStart;
        public static void Init()
        {
            XVar dalTabletransactionSetup = XVar.Array();
            dalTabletransactionSetup["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTabletransactionSetup["defaulttransaction"] = new XVar("type", 200, "varname", "defaulttransaction", "name", "defaulttransaction", "autoInc", "0");
            dalTabletransactionSetup["defaultStatus"] = new XVar("type", 200, "varname", "defaultStatus", "name", "defaultStatus", "autoInc", "0");
            dalTabletransactionSetup["autonumber"] = new XVar("type", 200, "varname", "autonumber", "name", "autonumber", "autoInc", "0");
            dalTabletransactionSetup["prefix"] = new XVar("type", 200, "varname", "prefix", "name", "prefix", "autoInc", "0");
            dalTabletransactionSetup["leadingZeros"] = new XVar("type", 200, "varname", "leadingZeros", "name", "leadingZeros", "autoInc", "0");
            dalTabletransactionSetup["seriesStart"] = new XVar("type", 200, "varname", "seriesStart", "name", "seriesStart", "autoInc", "0");
	        dalTabletransactionSetup.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_transactionSetup"] = dalTabletransactionSetup;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_transactionSetup()
        {
            			this.m_TableName = "dbo.transactionSetup";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_transactionSetup";
        }
    }
}