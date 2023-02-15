
			using System;
			using System.IO;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.Web;
			using System.Web.Mvc;
			using System.Reflection;
			using runnerDotNet;
			namespace runnerDotNet
			{
				public static partial class SecuritySettings_class
				{
					static public XVar settings()
					{
						return new XVar( "providers", new XVar( 0, new XVar( "type", "%db",
"activationField", "active",
"active", true,
"code", "00",
"emailField", "email",
"extUserIdField", "ext_security_id",
"fullnameField", "fullname",
"label", new XVar( "text", "Database",
"type", 0 ),
"name", "db",
"passwordField", "password",
"resetDateField", "˂Create new˃",
"resetTokenField", "˂Create new˃",
"table", new XVar( "connId", "RSPDDB_at_172_16_0_80",
"table", "dbo.spectrum_beta_users" ),
"userGroupField", "username",
"usernameField", "username",
"userpicField", "" ) ),
"sessionControl", new XVar( "lifeTime", 15,
"sessionName", "5PxER7dkKbj1pwTRogw4",
"JWTSecret", "eycpYZZbM25NXMncrS6F",
"forceExpire", false,
"keepAlive", true ),
"registration", new XVar( "passwordValidation", new XVar( "strong", false,
"minimumLength", 8,
"uniqueCharacters", 4,
"digitsAndSymbols", 2,
"upperAndLowerCase", false ),
"remindMethod", 1,
"hashAlgorithm", 0,
"changePwdPage", false,
"hashPassword", true,
"registerPage", false,
"remindPage", false ),
"captchaSettings", new XVar( "captchaType", 0,
"siteKey", "",
"secretKey", "",
"passesCount", 5 ),
"emailSettings", new XVar( "fromEmail", "",
"usePHPDefinedSMTP", false,
"useBuiltInMailer", false,
"SMTPServer", "localhost",
"SMTPPort", 25,
"SMTPUser", "",
"SMTPPassword", "",
"securityProtocol", 0 ),
"advancedSecurity", new XVar( "allowGuestLogin", false ),
"auditAndLocking", new XVar( "loggingTable", new XVar( "connId", "RSPDDB_at_172_16_0_80",
"table", "dbo.spectrum_beta_audit" ),
"lockingTable", new XVar( "connId", "RSPDDB_at_172_16_0_80",
"table", "˂Create new˃" ),
"tables", new XVar( "admin_members", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"admin_rights", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"admin_users", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.FrequencyA", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.FrequencyB", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.baranggay", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.city", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.company", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.delivery_Unit", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.province", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.radioEquipment", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.rspdHeader", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.spectrum_beta_users", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.spectrum_betauggroups", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.stage", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.stageStatus", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ),
"dbo.sysdiagrams", new XVar( "logFieldValues", true,
"logModifications", true,
"recordLocking", false ) ),
"loggingMode", 1,
"loggingFile", "audit.log",
"logSecurityActions", true,
"lockAfterUnsuccessfulLogin", false,
"enableLocking", false ),
"twoFactorSettings", new XVar( "available", false,
"required", false,
"enable", true,
"remember", true,
"types", new XVar(  ),
"twoFactorField", "",
"emailField", "",
"phoneField", "",
"codeField", "",
"projectName", "" ),
"projectName", "Spectrum",
"loginDataSource", "dbo.spectrum_beta_users",
"loginForm", 0,
"dynamicPermissions", true,
"dpTablePrefix", "dbo.spectrum_beta",
"dpTableConnId", "RSPDDB_at_172_16_0_80",
"hardcodedLogin", false,
"enabled", true,
"advancedSecurityAvailable", true,
"userGroupsAvailable", true,
"defaultProviderCode", "00",
"adOnlyLogin", false,
"dbProvider", new XVar( "type", "%db",
"activationField", "active",
"active", true,
"code", "00",
"emailField", "email",
"extUserIdField", "ext_security_id",
"fullnameField", "fullname",
"label", new XVar( "text", "Database",
"type", 0 ),
"name", "db",
"passwordField", "password",
"resetDateField", "˂Create new˃",
"resetTokenField", "˂Create new˃",
"table", new XVar( "connId", "RSPDDB_at_172_16_0_80",
"table", "dbo.spectrum_beta_users" ),
"userGroupField", "username",
"usernameField", "username",
"userpicField", "" ),
"adAdminGroups", XVar.Array(),
"showUserSource", false,
"dbProviderCodes", new XVar( 0, "00" ),
"notifications", new XVar(  ) );
					}
				}
			}