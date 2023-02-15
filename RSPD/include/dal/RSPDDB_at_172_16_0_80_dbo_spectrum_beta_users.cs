using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace runnerDotNet
{
    public class dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_users : tDALTable
    {
        public XVar ID;
        public XVar username;
        public XVar password;
        public XVar email;
        public XVar fullname;
        public XVar groupid;
        public XVar active;
        public XVar ext_security_id;
        public XVar company;
        public XVar position;
        public XVar branch;
        public XVar groupPermission;
        public static void Init()
        {
            XVar dalTablespectrum_beta_users = XVar.Array();
            dalTablespectrum_beta_users["ID"] = new XVar("type", 3, "varname", "ID", "name", "ID", "autoInc", "1");
            dalTablespectrum_beta_users["username"] = new XVar("type", 200, "varname", "username", "name", "username", "autoInc", "0");
            dalTablespectrum_beta_users["password"] = new XVar("type", 200, "varname", "password", "name", "password", "autoInc", "0");
            dalTablespectrum_beta_users["email"] = new XVar("type", 200, "varname", "email", "name", "email", "autoInc", "0");
            dalTablespectrum_beta_users["fullname"] = new XVar("type", 200, "varname", "fullname", "name", "fullname", "autoInc", "0");
            dalTablespectrum_beta_users["groupid"] = new XVar("type", 200, "varname", "groupid", "name", "groupid", "autoInc", "0");
            dalTablespectrum_beta_users["active"] = new XVar("type", 3, "varname", "active", "name", "active", "autoInc", "0");
            dalTablespectrum_beta_users["ext_security_id"] = new XVar("type", 200, "varname", "ext_security_id", "name", "ext_security_id", "autoInc", "0");
            dalTablespectrum_beta_users["company"] = new XVar("type", 200, "varname", "company", "name", "company", "autoInc", "0");
            dalTablespectrum_beta_users["position"] = new XVar("type", 200, "varname", "position", "name", "position", "autoInc", "0");
            dalTablespectrum_beta_users["branch"] = new XVar("type", 200, "varname", "branch", "name", "branch", "autoInc", "0");
            dalTablespectrum_beta_users["groupPermission"] = new XVar("type", 200, "varname", "groupPermission", "name", "groupPermission", "autoInc", "0");
	        dalTablespectrum_beta_users.InitAndSetArrayItem(true, "ID", "key");
            GlobalVars.dal_info["RSPDDB_at_172_16_0_80_dbo_spectrum_beta_users"] = dalTablespectrum_beta_users;
        }

        public  dalTable_RSPDDB_at_172_16_0_80_dbo_spectrum_beta_users()
        {
            			this.m_TableName = "dbo.spectrum_beta_users";
            this.m_infoKey = "RSPDDB_at_172_16_0_80_dbo_spectrum_beta_users";
        }
    }
}