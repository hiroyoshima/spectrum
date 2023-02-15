using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_FrequencyB : tDALTable
    {
        public XVar ID;
        public XVar HdrID;
        public XVar SerialNoB;
        public XVar TxB;
        public XVar RxA;
        public static void Init()
        {
            XVar dalTableFrequencyB = XVar.Array();
            dalTableFrequencyB["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTableFrequencyB["HdrID"] = new XVar("type", 3, "varname", "HdrID", "name", "HdrID", "autoInc", "0");
            dalTableFrequencyB["SerialNoB"] = new XVar("type", 200, "varname", "SerialNoB", "name", "SerialNoB", "autoInc", "0");
            dalTableFrequencyB["TxB"] = new XVar("type", 14, "varname", "TxB", "name", "TxB", "autoInc", "0");
            dalTableFrequencyB["RxA"] = new XVar("type", 14, "varname", "RxA", "name", "RxA", "autoInc", "0");
	        dalTableFrequencyB.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_FrequencyB"] = dalTableFrequencyB;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_FrequencyB()
        {
            			this.m_TableName = "dbo.FrequencyB";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_FrequencyB";
        }
    }
}