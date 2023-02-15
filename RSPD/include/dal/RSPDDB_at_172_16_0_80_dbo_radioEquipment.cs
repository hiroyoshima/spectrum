using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_radioEquipment : tDALTable
    {
        public XVar id;
        public XVar makeModelA;
        public XVar capacityA;
        public XVar powerA;
        public XVar modA;
        public XVar BWEA;
        public XVar serialNoA;
        public XVar makeModelB;
        public XVar capacityB;
        public XVar powerB;
        public XVar modB;
        public XVar BWEB;
        public XVar serialNoB;
        public XVar rspdID;
        public XVar txA;
        public XVar txB;
        public XVar rxA;
        public XVar rxB;
        public XVar frequencyRange;
        public XVar frequencyRangeB;
        public static void Init()
        {
            XVar dalTableradioEquipment = XVar.Array();
            dalTableradioEquipment["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTableradioEquipment["makeModelA"] = new XVar("type", 200, "varname", "makeModelA", "name", "makeModelA", "autoInc", "0");
            dalTableradioEquipment["capacityA"] = new XVar("type", 200, "varname", "capacityA", "name", "capacityA", "autoInc", "0");
            dalTableradioEquipment["powerA"] = new XVar("type", 200, "varname", "powerA", "name", "powerA", "autoInc", "0");
            dalTableradioEquipment["modA"] = new XVar("type", 200, "varname", "modA", "name", "modA", "autoInc", "0");
            dalTableradioEquipment["BWEA"] = new XVar("type", 200, "varname", "BWEA", "name", "BWEA", "autoInc", "0");
            dalTableradioEquipment["serialNoA"] = new XVar("type", 200, "varname", "serialNoA", "name", "serialNoA", "autoInc", "0");
            dalTableradioEquipment["makeModelB"] = new XVar("type", 200, "varname", "makeModelB", "name", "makeModelB", "autoInc", "0");
            dalTableradioEquipment["capacityB"] = new XVar("type", 200, "varname", "capacityB", "name", "capacityB", "autoInc", "0");
            dalTableradioEquipment["powerB"] = new XVar("type", 200, "varname", "powerB", "name", "powerB", "autoInc", "0");
            dalTableradioEquipment["modB"] = new XVar("type", 200, "varname", "modB", "name", "modB", "autoInc", "0");
            dalTableradioEquipment["BWEB"] = new XVar("type", 200, "varname", "BWEB", "name", "BWEB", "autoInc", "0");
            dalTableradioEquipment["serialNoB"] = new XVar("type", 200, "varname", "serialNoB", "name", "serialNoB", "autoInc", "0");
            dalTableradioEquipment["rspdID"] = new XVar("type", 3, "varname", "rspdID", "name", "rspdID", "autoInc", "0");
            dalTableradioEquipment["txA"] = new XVar("type", 14, "varname", "txA", "name", "txA", "autoInc", "0");
            dalTableradioEquipment["txB"] = new XVar("type", 14, "varname", "txB", "name", "txB", "autoInc", "0");
            dalTableradioEquipment["rxA"] = new XVar("type", 14, "varname", "rxA", "name", "rxA", "autoInc", "0");
            dalTableradioEquipment["rxB"] = new XVar("type", 14, "varname", "rxB", "name", "rxB", "autoInc", "0");
            dalTableradioEquipment["frequencyRange"] = new XVar("type", 200, "varname", "frequencyRange", "name", "frequencyRange", "autoInc", "0");
            dalTableradioEquipment["frequencyRangeB"] = new XVar("type", 200, "varname", "frequencyRangeB", "name", "frequencyRangeB", "autoInc", "0");
	        dalTableradioEquipment.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_radioEquipment"] = dalTableradioEquipment;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_radioEquipment()
        {
            			this.m_TableName = "dbo.radioEquipment";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_radioEquipment";
        }
    }
}