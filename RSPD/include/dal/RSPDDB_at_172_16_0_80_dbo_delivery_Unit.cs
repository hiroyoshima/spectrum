using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_delivery_Unit : tDALTable
    {
        public XVar id;
        public XVar first_name;
        public XVar last_name;
        public XVar email;
        public XVar userName;
        public XVar password;
        public XVar address;
        public XVar dateCreated;
        public XVar createdBy;
        public XVar Name;
        public XVar office;
        public static void Init()
        {
            XVar dalTabledelivery_Unit = XVar.Array();
            dalTabledelivery_Unit["id"] = new XVar("type", 3, "varname", "id", "name", "id", "autoInc", "1");
            dalTabledelivery_Unit["first_name"] = new XVar("type", 200, "varname", "first_name", "name", "first_name", "autoInc", "0");
            dalTabledelivery_Unit["last_name"] = new XVar("type", 200, "varname", "last_name", "name", "last_name", "autoInc", "0");
            dalTabledelivery_Unit["email"] = new XVar("type", 200, "varname", "email", "name", "email", "autoInc", "0");
            dalTabledelivery_Unit["userName"] = new XVar("type", 200, "varname", "userName", "name", "userName", "autoInc", "0");
            dalTabledelivery_Unit["password"] = new XVar("type", 200, "varname", "password", "name", "password", "autoInc", "0");
            dalTabledelivery_Unit["address"] = new XVar("type", 201, "varname", "address", "name", "address", "autoInc", "0");
            dalTabledelivery_Unit["dateCreated"] = new XVar("type", 135, "varname", "dateCreated", "name", "dateCreated", "autoInc", "0");
            dalTabledelivery_Unit["createdBy"] = new XVar("type", 200, "varname", "createdBy", "name", "createdBy", "autoInc", "0");
            dalTabledelivery_Unit["Name"] = new XVar("type", 200, "varname", "Name", "name", "Name", "autoInc", "0");
            dalTabledelivery_Unit["office"] = new XVar("type", 3, "varname", "office", "name", "office", "autoInc", "0");
	        dalTabledelivery_Unit.InitAndSetArrayItem(true, "id", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_delivery_Unit"] = dalTabledelivery_Unit;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_delivery_Unit()
        {
            			this.m_TableName = "dbo.delivery_Unit";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_delivery_Unit";
        }
    }
}