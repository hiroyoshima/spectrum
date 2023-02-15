using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_rspdLineA : tDALTable
    {
        public XVar ID;
        public XVar HdrID;
        public XVar LOC_UNIT_STA_A;
        public XVar LOC_STREET_STA_A;
        public XVar LOC_BRGY_STA_A;
        public XVar CITY_MUNICIPALITY_STA_A;
        public XVar PROVINCE_STA_A;
        public XVar ZIPCODE_STA_A;
        public XVar eDegA;
        public XVar eMinA;
        public XVar eSecA;
        public XVar nDegA;
        public XVar nMinA;
        public XVar nSecA;
        public XVar elevationA;
        public XVar aMakeTypeModelA;
        public XVar gainA;
        public XVar diameterA;
        public XVar beamwidthA;
        public XVar polarizationA;
        public XVar azimuthA;
        public XVar elevAngleA;
        public XVar heightAGLA;
        public XVar feederLengthA;
        public XVar callSignA;
        public static void Init()
        {
            XVar dalTablerspdLineA = XVar.Array();
            dalTablerspdLineA["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablerspdLineA["HdrID"] = new XVar("type", 3, "varname", "HdrID", "name", "HdrID", "autoInc", "0");
            dalTablerspdLineA["LOC_UNIT_STA_A"] = new XVar("type", 200, "varname", "LOC_UNIT_STA_A", "name", "LOC_UNIT_STA_A", "autoInc", "0");
            dalTablerspdLineA["LOC_STREET_STA_A"] = new XVar("type", 200, "varname", "LOC_STREET_STA_A", "name", "LOC_STREET_STA_A", "autoInc", "0");
            dalTablerspdLineA["LOC_BRGY_STA_A"] = new XVar("type", 200, "varname", "LOC_BRGY_STA_A", "name", "LOC_BRGY_STA_A", "autoInc", "0");
            dalTablerspdLineA["CITY/MUNICIPALITY_STA_A"] = new XVar("type", 200, "varname", "CITY_MUNICIPALITY_STA_A", "name", "CITY/MUNICIPALITY_STA_A", "autoInc", "0");
            dalTablerspdLineA["PROVINCE_STA_A"] = new XVar("type", 200, "varname", "PROVINCE_STA_A", "name", "PROVINCE_STA_A", "autoInc", "0");
            dalTablerspdLineA["ZIPCODE_STA_A"] = new XVar("type", 200, "varname", "ZIPCODE_STA_A", "name", "ZIPCODE_STA_A", "autoInc", "0");
            dalTablerspdLineA["eDegA"] = new XVar("type", 131, "varname", "eDegA", "name", "eDegA", "autoInc", "0");
            dalTablerspdLineA["eMinA"] = new XVar("type", 131, "varname", "eMinA", "name", "eMinA", "autoInc", "0");
            dalTablerspdLineA["eSecA"] = new XVar("type", 131, "varname", "eSecA", "name", "eSecA", "autoInc", "0");
            dalTablerspdLineA["nDegA"] = new XVar("type", 131, "varname", "nDegA", "name", "nDegA", "autoInc", "0");
            dalTablerspdLineA["nMinA"] = new XVar("type", 131, "varname", "nMinA", "name", "nMinA", "autoInc", "0");
            dalTablerspdLineA["nSecA"] = new XVar("type", 131, "varname", "nSecA", "name", "nSecA", "autoInc", "0");
            dalTablerspdLineA["elevationA"] = new XVar("type", 131, "varname", "elevationA", "name", "elevationA", "autoInc", "0");
            dalTablerspdLineA["aMakeTypeModelA"] = new XVar("type", 200, "varname", "aMakeTypeModelA", "name", "aMakeTypeModelA", "autoInc", "0");
            dalTablerspdLineA["gainA"] = new XVar("type", 131, "varname", "gainA", "name", "gainA", "autoInc", "0");
            dalTablerspdLineA["diameterA"] = new XVar("type", 131, "varname", "diameterA", "name", "diameterA", "autoInc", "0");
            dalTablerspdLineA["beamwidthA"] = new XVar("type", 131, "varname", "beamwidthA", "name", "beamwidthA", "autoInc", "0");
            dalTablerspdLineA["polarizationA"] = new XVar("type", 200, "varname", "polarizationA", "name", "polarizationA", "autoInc", "0");
            dalTablerspdLineA["azimuthA"] = new XVar("type", 131, "varname", "azimuthA", "name", "azimuthA", "autoInc", "0");
            dalTablerspdLineA["elevAngleA"] = new XVar("type", 131, "varname", "elevAngleA", "name", "elevAngleA", "autoInc", "0");
            dalTablerspdLineA["heightAGLA"] = new XVar("type", 131, "varname", "heightAGLA", "name", "heightAGLA", "autoInc", "0");
            dalTablerspdLineA["feederLengthA"] = new XVar("type", 131, "varname", "feederLengthA", "name", "feederLengthA", "autoInc", "0");
            dalTablerspdLineA["callSignA"] = new XVar("type", 200, "varname", "callSignA", "name", "callSignA", "autoInc", "0");
	        dalTablerspdLineA.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_rspdLineA"] = dalTablerspdLineA;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_rspdLineA()
        {
            			this.m_TableName = "dbo.rspdLineA";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_rspdLineA";
        }
    }
}