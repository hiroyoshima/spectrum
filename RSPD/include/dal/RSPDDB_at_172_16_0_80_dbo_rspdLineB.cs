using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_rspdLineB : tDALTable
    {
        public XVar ID;
        public XVar HdrID;
        public XVar LOC_UNIT_STA_B;
        public XVar LOC_STREET_STA_B;
        public XVar LOC_BRGY_STA_B;
        public XVar CITY_MUNICIPALITY_STA_B;
        public XVar PROVINCE_STA_B;
        public XVar ZIPCODE_STA_B;
        public XVar eDegB;
        public XVar eMinB;
        public XVar eSecB;
        public XVar nDegB;
        public XVar nMinB;
        public XVar nSecB;
        public XVar elevationB;
        public XVar aMakeTypeModelB;
        public XVar gainB;
        public XVar diameterB;
        public XVar beamwidthB;
        public XVar polarizationB;
        public XVar azimuthB;
        public XVar elevAngleB;
        public XVar heightAGLB;
        public XVar feederLengthB;
        public XVar callSignB;
        public static void Init()
        {
            XVar dalTablerspdLineB = XVar.Array();
            dalTablerspdLineB["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablerspdLineB["HdrID"] = new XVar("type", 3, "varname", "HdrID", "name", "HdrID", "autoInc", "0");
            dalTablerspdLineB["LOC_UNIT_STA_B"] = new XVar("type", 200, "varname", "LOC_UNIT_STA_B", "name", "LOC_UNIT_STA_B", "autoInc", "0");
            dalTablerspdLineB["LOC_STREET_STA_B"] = new XVar("type", 200, "varname", "LOC_STREET_STA_B", "name", "LOC_STREET_STA_B", "autoInc", "0");
            dalTablerspdLineB["LOC_BRGY_STA_B"] = new XVar("type", 200, "varname", "LOC_BRGY_STA_B", "name", "LOC_BRGY_STA_B", "autoInc", "0");
            dalTablerspdLineB["CITY/MUNICIPALITY_STA_B"] = new XVar("type", 200, "varname", "CITY_MUNICIPALITY_STA_B", "name", "CITY/MUNICIPALITY_STA_B", "autoInc", "0");
            dalTablerspdLineB["PROVINCE_STA_B"] = new XVar("type", 200, "varname", "PROVINCE_STA_B", "name", "PROVINCE_STA_B", "autoInc", "0");
            dalTablerspdLineB["ZIPCODE_STA_B"] = new XVar("type", 200, "varname", "ZIPCODE_STA_B", "name", "ZIPCODE_STA_B", "autoInc", "0");
            dalTablerspdLineB["eDegB"] = new XVar("type", 131, "varname", "eDegB", "name", "eDegB", "autoInc", "0");
            dalTablerspdLineB["eMinB"] = new XVar("type", 131, "varname", "eMinB", "name", "eMinB", "autoInc", "0");
            dalTablerspdLineB["eSecB"] = new XVar("type", 131, "varname", "eSecB", "name", "eSecB", "autoInc", "0");
            dalTablerspdLineB["nDegB"] = new XVar("type", 131, "varname", "nDegB", "name", "nDegB", "autoInc", "0");
            dalTablerspdLineB["nMinB"] = new XVar("type", 131, "varname", "nMinB", "name", "nMinB", "autoInc", "0");
            dalTablerspdLineB["nSecB"] = new XVar("type", 131, "varname", "nSecB", "name", "nSecB", "autoInc", "0");
            dalTablerspdLineB["elevationB"] = new XVar("type", 131, "varname", "elevationB", "name", "elevationB", "autoInc", "0");
            dalTablerspdLineB["aMakeTypeModelB"] = new XVar("type", 200, "varname", "aMakeTypeModelB", "name", "aMakeTypeModelB", "autoInc", "0");
            dalTablerspdLineB["gainB"] = new XVar("type", 131, "varname", "gainB", "name", "gainB", "autoInc", "0");
            dalTablerspdLineB["diameterB"] = new XVar("type", 131, "varname", "diameterB", "name", "diameterB", "autoInc", "0");
            dalTablerspdLineB["beamwidthB"] = new XVar("type", 131, "varname", "beamwidthB", "name", "beamwidthB", "autoInc", "0");
            dalTablerspdLineB["polarizationB"] = new XVar("type", 200, "varname", "polarizationB", "name", "polarizationB", "autoInc", "0");
            dalTablerspdLineB["azimuthB"] = new XVar("type", 131, "varname", "azimuthB", "name", "azimuthB", "autoInc", "0");
            dalTablerspdLineB["elevAngleB"] = new XVar("type", 131, "varname", "elevAngleB", "name", "elevAngleB", "autoInc", "0");
            dalTablerspdLineB["heightAGLB"] = new XVar("type", 131, "varname", "heightAGLB", "name", "heightAGLB", "autoInc", "0");
            dalTablerspdLineB["feederLengthB"] = new XVar("type", 131, "varname", "feederLengthB", "name", "feederLengthB", "autoInc", "0");
            dalTablerspdLineB["callSignB"] = new XVar("type", 200, "varname", "callSignB", "name", "callSignB", "autoInc", "0");
	        dalTablerspdLineB.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_rspdLineB"] = dalTablerspdLineB;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_rspdLineB()
        {
            			this.m_TableName = "dbo.rspdLineB";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_rspdLineB";
        }
    }
}