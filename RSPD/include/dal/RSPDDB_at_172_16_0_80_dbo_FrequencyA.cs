using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_FrequencyA : tDALTable
    {
        public XVar ID;
        public XVar RspdID;
        public XVar SerialNoA;
        public XVar TxA;
        public XVar RxB;
        public static void Init()
        {
            XVar dalTableFrequencyA = XVar.Array();
            dalTableFrequencyA["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTableFrequencyA["RspdID"] = new XVar("type", 3, "varname", "RspdID", "name", "RspdID", "autoInc", "0");
            dalTableFrequencyA["SerialNoA"] = new XVar("type", 200, "varname", "SerialNoA", "name", "SerialNoA", "autoInc", "0");
            dalTableFrequencyA["TxA"] = new XVar("type", 14, "varname", "TxA", "name", "TxA", "autoInc", "0");
            dalTableFrequencyA["RxB"] = new XVar("type", 14, "varname", "RxB", "name", "RxB", "autoInc", "0");
	        dalTableFrequencyA.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_FrequencyA"] = dalTableFrequencyA;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_FrequencyA()
        {
            			this.m_TableName = "dbo.FrequencyA";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_FrequencyA";
        }
    }
}