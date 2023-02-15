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
	public static partial class GlobalVars
	{
		public static dynamic Settings
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["Settings"];
			}
			set
			{
				HttpContext.Current.Items["Settings"] = value;
			}
		}
		public static dynamic Variables
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["Variables"];
			}
			set
			{
				HttpContext.Current.Items["Variables"] = value;
			}
		}
		public static dynamic WRAdminPagePassword
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["WRAdminPagePassword"];
			}
			set
			{
				HttpContext.Current.Items["WRAdminPagePassword"] = value;
			}
		}
		public static dynamic _cachedSeachClauses
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["_cachedSeachClauses"];
			}
			set
			{
				HttpContext.Current.Items["_cachedSeachClauses"] = value;
			}
		}
		public static dynamic _currentLanguage
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["_currentLanguage"];
			}
			set
			{
				HttpContext.Current.Items["_currentLanguage"] = value;
			}
		}
		public static dynamic _gmdays
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["_gmdays"];
			}
			set
			{
				HttpContext.Current.Items["_gmdays"] = value;
			}
		}
		public static dynamic _pagetypeToPermissions_dict
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["_pagetypeToPermissions_dict"];
			}
			set
			{
				HttpContext.Current.Items["_pagetypeToPermissions_dict"] = value;
			}
		}
		public static dynamic adNestedPermissions
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["adNestedPermissions"];
			}
			set
			{
				HttpContext.Current.Items["adNestedPermissions"] = value;
			}
		}
		public static dynamic ajaxSearchStartsWith
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["ajaxSearchStartsWith"];
			}
			set
			{
				HttpContext.Current.Items["ajaxSearchStartsWith"] = value;
			}
		}
		public static dynamic all_page_layouts
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["all_page_layouts"];
			}
			set
			{
				HttpContext.Current.Items["all_page_layouts"] = value;
			}
		}
		public static dynamic all_page_types
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["all_page_types"];
			}
			set
			{
				HttpContext.Current.Items["all_page_types"] = value;
			}
		}
		public static dynamic all_pages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["all_pages"];
			}
			set
			{
				HttpContext.Current.Items["all_pages"] = value;
			}
		}
		public static dynamic all_pd_layouts
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["all_pd_layouts"];
			}
			set
			{
				HttpContext.Current.Items["all_pd_layouts"] = value;
			}
		}
		public static dynamic arrCustomPages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["arrCustomPages"];
			}
			set
			{
				HttpContext.Current.Items["arrCustomPages"] = value;
			}
		}
		public static dynamic arrDBFieldsList
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["arrDBFieldsList"];
			}
			set
			{
				HttpContext.Current.Items["arrDBFieldsList"] = value;
			}
		}
		public static dynamic auditMaxFieldLength
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["auditMaxFieldLength"];
			}
			set
			{
				HttpContext.Current.Items["auditMaxFieldLength"] = value;
			}
		}
		public static dynamic bSubqueriesSupported
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["bSubqueriesSupported"];
			}
			set
			{
				HttpContext.Current.Items["bSubqueriesSupported"] = value;
			}
		}
		public static dynamic breadcrumb_labels
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["breadcrumb_labels"];
			}
			set
			{
				HttpContext.Current.Items["breadcrumb_labels"] = value;
			}
		}
		public static dynamic bsProjectSize
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["bsProjectSize"];
			}
			set
			{
				HttpContext.Current.Items["bsProjectSize"] = value;
			}
		}
		public static dynamic bsProjectTheme
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["bsProjectTheme"];
			}
			set
			{
				HttpContext.Current.Items["bsProjectTheme"] = value;
			}
		}
		public static dynamic cCharset
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cCharset"];
			}
			set
			{
				HttpContext.Current.Items["cCharset"] = value;
			}
		}
		public static dynamic cCodepage
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cCodepage"];
			}
			set
			{
				HttpContext.Current.Items["cCodepage"] = value;
			}
		}
		public static dynamic cDisplayNameField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cDisplayNameField"];
			}
			set
			{
				HttpContext.Current.Items["cDisplayNameField"] = value;
			}
		}
		public static dynamic cEmailField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cEmailField"];
			}
			set
			{
				HttpContext.Current.Items["cEmailField"] = value;
			}
		}
		public static dynamic cKeyFields
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cKeyFields"];
			}
			set
			{
				HttpContext.Current.Items["cKeyFields"] = value;
			}
		}
		public static dynamic cLoginTable
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cLoginTable"];
			}
			set
			{
				HttpContext.Current.Items["cLoginTable"] = value;
			}
		}
		public static dynamic cMySQLNames
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cMySQLNames"];
			}
			set
			{
				HttpContext.Current.Items["cMySQLNames"] = value;
			}
		}
		public static dynamic cPasswordField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cPasswordField"];
			}
			set
			{
				HttpContext.Current.Items["cPasswordField"] = value;
			}
		}
		public static dynamic cUserGroupField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cUserGroupField"];
			}
			set
			{
				HttpContext.Current.Items["cUserGroupField"] = value;
			}
		}
		public static dynamic cUserNameField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cUserNameField"];
			}
			set
			{
				HttpContext.Current.Items["cUserNameField"] = value;
			}
		}
		public static dynamic cUserpicField
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cUserpicField"];
			}
			set
			{
				HttpContext.Current.Items["cUserpicField"] = value;
			}
		}
		public static dynamic cacheImages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cacheImages"];
			}
			set
			{
				HttpContext.Current.Items["cacheImages"] = value;
			}
		}
		public static dynamic cache_db2time
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cache_db2time"];
			}
			set
			{
				HttpContext.Current.Items["cache_db2time"] = value;
			}
		}
		public static dynamic cache_formatweekstart
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cache_formatweekstart"];
			}
			set
			{
				HttpContext.Current.Items["cache_formatweekstart"] = value;
			}
		}
		public static dynamic cache_getdayofweek
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cache_getdayofweek"];
			}
			set
			{
				HttpContext.Current.Items["cache_getdayofweek"] = value;
			}
		}
		public static dynamic cache_getweekstart
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cache_getweekstart"];
			}
			set
			{
				HttpContext.Current.Items["cache_getweekstart"] = value;
			}
		}
		public static dynamic cipherer
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cipherer"];
			}
			set
			{
				HttpContext.Current.Items["cipherer"] = value;
			}
		}
		public static dynamic cman
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cman"];
			}
			set
			{
				HttpContext.Current.Items["cman"] = value;
			}
		}
		public static dynamic conn
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["conn"];
			}
			set
			{
				HttpContext.Current.Items["conn"] = value;
			}
		}
		public static dynamic contextStack
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["contextStack"];
			}
			set
			{
				HttpContext.Current.Items["contextStack"] = value;
			}
		}
		public static dynamic cookieParams
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["cookieParams"];
			}
			set
			{
				HttpContext.Current.Items["cookieParams"] = value;
			}
		}
		public static dynamic csrfProtectionOff
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["csrfProtectionOff"];
			}
			set
			{
				HttpContext.Current.Items["csrfProtectionOff"] = value;
			}
		}
		public static dynamic currentConnection
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["currentConnection"];
			}
			set
			{
				HttpContext.Current.Items["currentConnection"] = value;
			}
		}
		public static dynamic customLDAPSettings
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["customLDAPSettings"];
			}
			set
			{
				HttpContext.Current.Items["customLDAPSettings"] = value;
			}
		}
		public static dynamic custom_labels
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["custom_labels"];
			}
			set
			{
				HttpContext.Current.Items["custom_labels"] = value;
			}
		}
		public static dynamic dDebug
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dDebug"];
			}
			set
			{
				HttpContext.Current.Items["dDebug"] = value;
			}
		}
		public static dynamic dSQL
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dSQL"];
			}
			set
			{
				HttpContext.Current.Items["dSQL"] = value;
			}
		}
		public static dynamic dal
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dal"];
			}
			set
			{
				HttpContext.Current.Items["dal"] = value;
			}
		}
		public static dynamic dalTables
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dalTables"];
			}
			set
			{
				HttpContext.Current.Items["dalTables"] = value;
			}
		}
		public static dynamic dal_info
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dal_info"];
			}
			set
			{
				HttpContext.Current.Items["dal_info"] = value;
			}
		}
		public static dynamic debug2Factor
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["debug2Factor"];
			}
			set
			{
				HttpContext.Current.Items["debug2Factor"] = value;
			}
		}
		public static dynamic defaultPages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["defaultPages"];
			}
			set
			{
				HttpContext.Current.Items["defaultPages"] = value;
			}
		}
		public static dynamic detailsTablesData
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["detailsTablesData"];
			}
			set
			{
				HttpContext.Current.Items["detailsTablesData"] = value;
			}
		}
		public static dynamic dummyEvents
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["dummyEvents"];
			}
			set
			{
				HttpContext.Current.Items["dummyEvents"] = value;
			}
		}
		public static dynamic editTextAsDate
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["editTextAsDate"];
			}
			set
			{
				HttpContext.Current.Items["editTextAsDate"] = value;
			}
		}
		public static dynamic fieldFilterDefaultValue
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldFilterDefaultValue"];
			}
			set
			{
				HttpContext.Current.Items["fieldFilterDefaultValue"] = value;
			}
		}
		public static dynamic fieldFilterMaxDisplayValueLength
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldFilterMaxDisplayValueLength"];
			}
			set
			{
				HttpContext.Current.Items["fieldFilterMaxDisplayValueLength"] = value;
			}
		}
		public static dynamic fieldFilterMaxSearchValueLength
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldFilterMaxSearchValueLength"];
			}
			set
			{
				HttpContext.Current.Items["fieldFilterMaxSearchValueLength"] = value;
			}
		}
		public static dynamic fieldFilterMaxValuesCount
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldFilterMaxValuesCount"];
			}
			set
			{
				HttpContext.Current.Items["fieldFilterMaxValuesCount"] = value;
			}
		}
		public static dynamic fieldFilterValueShrinkPostfix
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldFilterValueShrinkPostfix"];
			}
			set
			{
				HttpContext.Current.Items["fieldFilterValueShrinkPostfix"] = value;
			}
		}
		public static dynamic fieldToolTips
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fieldToolTips"];
			}
			set
			{
				HttpContext.Current.Items["fieldToolTips"] = value;
			}
		}
		public static dynamic field_labels
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["field_labels"];
			}
			set
			{
				HttpContext.Current.Items["field_labels"] = value;
			}
		}
		public static dynamic fields_type
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["fields_type"];
			}
			set
			{
				HttpContext.Current.Items["fields_type"] = value;
			}
		}
		public static dynamic gGuestHasPermissions
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gGuestHasPermissions"];
			}
			set
			{
				HttpContext.Current.Items["gGuestHasPermissions"] = value;
			}
		}
		public static dynamic gLoadSearchControls
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gLoadSearchControls"];
			}
			set
			{
				HttpContext.Current.Items["gLoadSearchControls"] = value;
			}
		}
		public static dynamic gPermissionsRead
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gPermissionsRead"];
			}
			set
			{
				HttpContext.Current.Items["gPermissionsRead"] = value;
			}
		}
		public static dynamic gPermissionsRefreshTime
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gPermissionsRefreshTime"];
			}
			set
			{
				HttpContext.Current.Items["gPermissionsRefreshTime"] = value;
			}
		}
		public static dynamic gReadPermissions
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gReadPermissions"];
			}
			set
			{
				HttpContext.Current.Items["gReadPermissions"] = value;
			}
		}
		public static dynamic gSettings
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gSettings"];
			}
			set
			{
				HttpContext.Current.Items["gSettings"] = value;
			}
		}
		public static dynamic g_defaultOptionValues
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["g_defaultOptionValues"];
			}
			set
			{
				HttpContext.Current.Items["g_defaultOptionValues"] = value;
			}
		}
		public static dynamic g_settingsType
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["g_settingsType"];
			}
			set
			{
				HttpContext.Current.Items["g_settingsType"] = value;
			}
		}
		public static dynamic globalEvents
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["globalEvents"];
			}
			set
			{
				HttpContext.Current.Items["globalEvents"] = value;
			}
		}
		public static dynamic globalSettings
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["globalSettings"];
			}
			set
			{
				HttpContext.Current.Items["globalSettings"] = value;
			}
		}
		public static dynamic group_sort_y
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["group_sort_y"];
			}
			set
			{
				HttpContext.Current.Items["group_sort_y"] = value;
			}
		}
		public static dynamic gstrOrderBy
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["gstrOrderBy"];
			}
			set
			{
				HttpContext.Current.Items["gstrOrderBy"] = value;
			}
		}
		public static dynamic isUseRTEBasic
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["isUseRTEBasic"];
			}
			set
			{
				HttpContext.Current.Items["isUseRTEBasic"] = value;
			}
		}
		public static dynamic isUseRTECK
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["isUseRTECK"];
			}
			set
			{
				HttpContext.Current.Items["isUseRTECK"] = value;
			}
		}
		public static dynamic isUseRTECKNew
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["isUseRTECKNew"];
			}
			set
			{
				HttpContext.Current.Items["isUseRTECKNew"] = value;
			}
		}
		public static dynamic isUseRTEInnova
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["isUseRTEInnova"];
			}
			set
			{
				HttpContext.Current.Items["isUseRTEInnova"] = value;
			}
		}
		public static dynamic locale_info
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["locale_info"];
			}
			set
			{
				HttpContext.Current.Items["locale_info"] = value;
			}
		}
		public static dynamic loginKeyFields
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["loginKeyFields"];
			}
			set
			{
				HttpContext.Current.Items["loginKeyFields"] = value;
			}
		}
		public static dynamic logoutPerformed
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["logoutPerformed"];
			}
			set
			{
				HttpContext.Current.Items["logoutPerformed"] = value;
			}
		}
		public static dynamic lookupTableLinks
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["lookupTableLinks"];
			}
			set
			{
				HttpContext.Current.Items["lookupTableLinks"] = value;
			}
		}
		public static dynamic masterTablesData
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["masterTablesData"];
			}
			set
			{
				HttpContext.Current.Items["masterTablesData"] = value;
			}
		}
		public static dynamic mbEnabled
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mbEnabled"];
			}
			set
			{
				HttpContext.Current.Items["mbEnabled"] = value;
			}
		}
		public static dynamic mediaType
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mediaType"];
			}
			set
			{
				HttpContext.Current.Items["mediaType"] = value;
			}
		}
		public static dynamic menuCache
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["menuCache"];
			}
			set
			{
				HttpContext.Current.Items["menuCache"] = value;
			}
		}
		public static dynamic menuNodesCache
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["menuNodesCache"];
			}
			set
			{
				HttpContext.Current.Items["menuNodesCache"] = value;
			}
		}
		public static dynamic menuNodesIndex
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["menuNodesIndex"];
			}
			set
			{
				HttpContext.Current.Items["menuNodesIndex"] = value;
			}
		}
		public static dynamic menuNodesObject
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["menuNodesObject"];
			}
			set
			{
				HttpContext.Current.Items["menuNodesObject"] = value;
			}
		}
		public static dynamic menuTreelikeFlags
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["menuTreelikeFlags"];
			}
			set
			{
				HttpContext.Current.Items["menuTreelikeFlags"] = value;
			}
		}
		public static dynamic mlang_charsets
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mlang_charsets"];
			}
			set
			{
				HttpContext.Current.Items["mlang_charsets"] = value;
			}
		}
		public static dynamic mlang_defaultlang
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mlang_defaultlang"];
			}
			set
			{
				HttpContext.Current.Items["mlang_defaultlang"] = value;
			}
		}
		public static dynamic mlang_messages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mlang_messages"];
			}
			set
			{
				HttpContext.Current.Items["mlang_messages"] = value;
			}
		}
		public static dynamic mysqlSupportDates0000
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["mysqlSupportDates0000"];
			}
			set
			{
				HttpContext.Current.Items["mysqlSupportDates0000"] = value;
			}
		}
		public static dynamic onDemnadVariables
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["onDemnadVariables"];
			}
			set
			{
				HttpContext.Current.Items["onDemnadVariables"] = value;
			}
		}
		public static dynamic pageInConstruction
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pageInConstruction"];
			}
			set
			{
				HttpContext.Current.Items["pageInConstruction"] = value;
			}
		}
		public static dynamic pageTypesForEdit
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pageTypesForEdit"];
			}
			set
			{
				HttpContext.Current.Items["pageTypesForEdit"] = value;
			}
		}
		public static dynamic pageTypesForView
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pageTypesForView"];
			}
			set
			{
				HttpContext.Current.Items["pageTypesForView"] = value;
			}
		}
		public static dynamic page_layouts
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["page_layouts"];
			}
			set
			{
				HttpContext.Current.Items["page_layouts"] = value;
			}
		}
		public static dynamic page_options
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["page_options"];
			}
			set
			{
				HttpContext.Current.Items["page_options"] = value;
			}
		}
		public static dynamic page_titles
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["page_titles"];
			}
			set
			{
				HttpContext.Current.Items["page_titles"] = value;
			}
		}
		public static dynamic pages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pages"];
			}
			set
			{
				HttpContext.Current.Items["pages"] = value;
			}
		}
		public static dynamic pagesData
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pagesData"];
			}
			set
			{
				HttpContext.Current.Items["pagesData"] = value;
			}
		}
		public static dynamic pd_pages
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pd_pages"];
			}
			set
			{
				HttpContext.Current.Items["pd_pages"] = value;
			}
		}
		public static dynamic placeHolders
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["placeHolders"];
			}
			set
			{
				HttpContext.Current.Items["placeHolders"] = value;
			}
		}
		public static dynamic projectBuildKey
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectBuildKey"];
			}
			set
			{
				HttpContext.Current.Items["projectBuildKey"] = value;
			}
		}
		public static dynamic projectBuildNumber
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectBuildNumber"];
			}
			set
			{
				HttpContext.Current.Items["projectBuildNumber"] = value;
			}
		}
		public static dynamic projectEntities
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectEntities"];
			}
			set
			{
				HttpContext.Current.Items["projectEntities"] = value;
			}
		}
		public static dynamic projectEntitiesReverse
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectEntitiesReverse"];
			}
			set
			{
				HttpContext.Current.Items["projectEntitiesReverse"] = value;
			}
		}
		public static dynamic projectLanguage
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectLanguage"];
			}
			set
			{
				HttpContext.Current.Items["projectLanguage"] = value;
			}
		}
		public static dynamic projectMenus
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectMenus"];
			}
			set
			{
				HttpContext.Current.Items["projectMenus"] = value;
			}
		}
		public static dynamic projectPath
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["projectPath"];
			}
			set
			{
				HttpContext.Current.Items["projectPath"] = value;
			}
		}
		public static dynamic regenerateSessionOnLogin
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["regenerateSessionOnLogin"];
			}
			set
			{
				HttpContext.Current.Items["regenerateSessionOnLogin"] = value;
			}
		}
		public static dynamic reportCaseSensitiveGroupFields
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["reportCaseSensitiveGroupFields"];
			}
			set
			{
				HttpContext.Current.Items["reportCaseSensitiveGroupFields"] = value;
			}
		}
		public static dynamic requestPage
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["requestPage"];
			}
			set
			{
				HttpContext.Current.Items["requestPage"] = value;
			}
		}
		public static dynamic requestTable
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["requestTable"];
			}
			set
			{
				HttpContext.Current.Items["requestTable"] = value;
			}
		}
		public static dynamic resizeImagesOnClient
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["resizeImagesOnClient"];
			}
			set
			{
				HttpContext.Current.Items["resizeImagesOnClient"] = value;
			}
		}
		public static dynamic restApiCall
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["restApiCall"];
			}
			set
			{
				HttpContext.Current.Items["restApiCall"] = value;
			}
		}
		public static dynamic restApis
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["restApis"];
			}
			set
			{
				HttpContext.Current.Items["restApis"] = value;
			}
		}
		public static dynamic restResultCache
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["restResultCache"];
			}
			set
			{
				HttpContext.Current.Items["restResultCache"] = value;
			}
		}
		public static dynamic restStorage
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["restStorage"];
			}
			set
			{
				HttpContext.Current.Items["restStorage"] = value;
			}
		}
		public static dynamic rpt_array
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["rpt_array"];
			}
			set
			{
				HttpContext.Current.Items["rpt_array"] = value;
			}
		}
		public static dynamic secure
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["secure"];
			}
			set
			{
				HttpContext.Current.Items["secure"] = value;
			}
		}
		public static dynamic showCustomMarkerOnPrint
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["showCustomMarkerOnPrint"];
			}
			set
			{
				HttpContext.Current.Items["showCustomMarkerOnPrint"] = value;
			}
		}
		public static dynamic sortgroup
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["sortgroup"];
			}
			set
			{
				HttpContext.Current.Items["sortgroup"] = value;
			}
		}
		public static dynamic sortorder
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["sortorder"];
			}
			set
			{
				HttpContext.Current.Items["sortorder"] = value;
			}
		}
		public static dynamic strLastSQL
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["strLastSQL"];
			}
			set
			{
				HttpContext.Current.Items["strLastSQL"] = value;
			}
		}
		public static dynamic strOriginalTableName
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["strOriginalTableName"];
			}
			set
			{
				HttpContext.Current.Items["strOriginalTableName"] = value;
			}
		}
		public static dynamic strTableName
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["strTableName"];
			}
			set
			{
				HttpContext.Current.Items["strTableName"] = value;
			}
		}
		public static dynamic styleOverrides
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["styleOverrides"];
			}
			set
			{
				HttpContext.Current.Items["styleOverrides"] = value;
			}
		}
		public static dynamic suggestAllContent
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["suggestAllContent"];
			}
			set
			{
				HttpContext.Current.Items["suggestAllContent"] = value;
			}
		}
		public static dynamic t_layout
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["t_layout"];
			}
			set
			{
				HttpContext.Current.Items["t_layout"] = value;
			}
		}
		public static dynamic tableCaptions
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tableCaptions"];
			}
			set
			{
				HttpContext.Current.Items["tableCaptions"] = value;
			}
		}
		public static dynamic tableEvents
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tableEvents"];
			}
			set
			{
				HttpContext.Current.Items["tableEvents"] = value;
			}
		}
		public static dynamic tableinfo_cache
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tableinfo_cache"];
			}
			set
			{
				HttpContext.Current.Items["tableinfo_cache"] = value;
			}
		}
		public static dynamic tablesByGoodName
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tablesByGoodName"];
			}
			set
			{
				HttpContext.Current.Items["tablesByGoodName"] = value;
			}
		}
		public static dynamic tablesByUpperCase
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tablesByUpperCase"];
			}
			set
			{
				HttpContext.Current.Items["tablesByUpperCase"] = value;
			}
		}
		public static dynamic tablesByUpperGoodname
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tablesByUpperGoodname"];
			}
			set
			{
				HttpContext.Current.Items["tablesByUpperGoodname"] = value;
			}
		}
		public static dynamic tables_data
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tables_data"];
			}
			set
			{
				HttpContext.Current.Items["tables_data"] = value;
			}
		}
		public static dynamic tbl
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tbl"];
			}
			set
			{
				HttpContext.Current.Items["tbl"] = value;
			}
		}
		public static dynamic tdataGLOBAL
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tdataGLOBAL"];
			}
			set
			{
				HttpContext.Current.Items["tdataGLOBAL"] = value;
			}
		}
		public static dynamic testingLinks
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["testingLinks"];
			}
			set
			{
				HttpContext.Current.Items["testingLinks"] = value;
			}
		}
		public static dynamic topsArray
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["topsArray"];
			}
			set
			{
				HttpContext.Current.Items["topsArray"] = value;
			}
		}
		public static dynamic tops_php2aspreplace000000
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["tops_php2aspreplace000000"];
			}
			set
			{
				HttpContext.Current.Items["tops_php2aspreplace000000"] = value;
			}
		}
		public static dynamic twilioAuth
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["twilioAuth"];
			}
			set
			{
				HttpContext.Current.Items["twilioAuth"] = value;
			}
		}
		public static dynamic twilioNumber
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["twilioNumber"];
			}
			set
			{
				HttpContext.Current.Items["twilioNumber"] = value;
			}
		}
		public static dynamic twilioSID
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["twilioSID"];
			}
			set
			{
				HttpContext.Current.Items["twilioSID"] = value;
			}
		}
		public static dynamic useAJAX
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["useAJAX"];
			}
			set
			{
				HttpContext.Current.Items["useAJAX"] = value;
			}
		}
		public static dynamic useOldMysqlLib
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["useOldMysqlLib"];
			}
			set
			{
				HttpContext.Current.Items["useOldMysqlLib"] = value;
			}
		}
		public static dynamic useUTF8
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["useUTF8"];
			}
			set
			{
				HttpContext.Current.Items["useUTF8"] = value;
			}
		}
		public static dynamic version
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["version"];
			}
			set
			{
				HttpContext.Current.Items["version"] = value;
			}
		}
		public static dynamic wizardBuildKey
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["wizardBuildKey"];
			}
			set
			{
				HttpContext.Current.Items["wizardBuildKey"] = value;
			}
		}
		public static dynamic wr_is_standalone
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["wr_is_standalone"];
			}
			set
			{
				HttpContext.Current.Items["wr_is_standalone"] = value;
			}
		}
		public static dynamic wr_pagestylepath
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["wr_pagestylepath"];
			}
			set
			{
				HttpContext.Current.Items["wr_pagestylepath"] = value;
			}
		}
		public static Stack<StringBuilder> BufferStack
		{
			get
			{
				return (Stack<StringBuilder>)HttpContext.Current.Items["BufferStack"];
			}
			set
			{
				HttpContext.Current.Items["BufferStack"] = value;
			}
		}
		public static XVar ConnectionStrings
		{
			get
			{
				return (XVar)HttpContext.Current.Items["ConnectionStrings"];
			}
			set
			{
				HttpContext.Current.Items["ConnectionStrings"] = value;
			}
		}
		public static dynamic IsOutputDone
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["IsOutputDone"];
			}
			set
			{
				HttpContext.Current.Items["IsOutputDone"] = value;
			}
		}
		public static XVar LastDBError
		{
			get
			{
				return (XVar)HttpContext.Current.Items["LastDBError"];
			}
			set
			{
				HttpContext.Current.Items["LastDBError"] = value;
			}
		}
		public static dynamic pageObject
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["pageObject"];
			}
			set
			{
				HttpContext.Current.Items["pageObject"] = value;
			}
		}
		public static dynamic strErrorHandler
		{
			get
			{
				return (dynamic)HttpContext.Current.Items["strErrorHandler"];
			}
			set
			{
				HttpContext.Current.Items["strErrorHandler"] = value;
			}
		}
		private static dynamic appliedInitializers
		{
			get
			{
				if(HttpContext.Current.Items["appliedInitializers"] == null)
					HttpContext.Current.Items["appliedInitializers"] = new HashSet<string>();
				return (dynamic)HttpContext.Current.Items["appliedInitializers"];
			}
		}
		public static void init_crosstable_report()
		{
			if(GlobalVars.appliedInitializers.Contains("crosstable_report"))
				return;

			GlobalVars.group_sort_y = XVar.Clone(XVar.Array());

			GlobalVars.appliedInitializers.Add("crosstable_report");
		}
		public static void init_crosstable_webreport()
		{
			if(GlobalVars.appliedInitializers.Contains("crosstable_webreport"))
				return;

			GlobalVars.group_sort_y = XVar.Clone(XVar.Array());

			GlobalVars.appliedInitializers.Add("crosstable_webreport");
		}
		public static void init_dal()
		{
			if(GlobalVars.appliedInitializers.Contains("dal"))
				return;

			GlobalVars.dal = XVar.Clone(new tDAL());
			GlobalVars.dal_info = XVar.Clone(XVar.Array());

			GlobalVars.appliedInitializers.Add("dal");
		}
		public static void init_dbcommon()
		{
			if(GlobalVars.appliedInitializers.Contains("dbcommon"))
				return;

			GlobalVars.init_dal();
			GlobalVars.bSubqueriesSupported = new XVar(true);
			GlobalVars.cCharset = new XVar("utf-8");
			GlobalVars.cCodepage = new XVar(65001);
			GlobalVars.cMySQLNames = new XVar("utf8");
			GlobalVars.cookieParams = XVar.Clone(CommonFunctions.session_get_cookie_params());
			GlobalVars.gLoadSearchControls = new XVar(30);
			GlobalVars.mbEnabled = XVar.Clone(MVCFunctions.extension_loaded(new XVar("mbstring")));
			GlobalVars.projectPath = new XVar("");
			GlobalVars.regenerateSessionOnLogin = new XVar(true);
			GlobalVars.secure = XVar.Clone((XVar)(!(XVar)(MVCFunctions.GetServerVariable("HTTPS").IsEmpty()))  && (XVar)(!XVar.Equals(XVar.Pack(MVCFunctions.GetServerVariable("HTTPS")), XVar.Pack("off"))));
			GlobalVars.useOldMysqlLib = XVar.Clone(0 != 0);
			GlobalVars.useUTF8 = XVar.Clone("utf-8" == "utf-8");
			GlobalVars.version = XVar.Clone(MVCFunctions.explode(new XVar("."), new XVar("0.0")));

			GlobalVars.appliedInitializers.Add("dbcommon");
		}
		public static void init_projectsettings()
		{
			if(GlobalVars.appliedInitializers.Contains("projectsettings"))
				return;


			GlobalVars.g_defaultOptionValues = new XVar();
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "Absolute");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "acceptFileTypes");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "addFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "addPageEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ajaxCodeSnippetAdded");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "advSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "afterAddAction");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "afterAddActionDetTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "afterEditAction");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "afterEditActionDetTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "AllowToAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "allowFieldsReordering");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "allowShowHideFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "allSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrGridTabs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrRecsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "audioTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "audit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFieldsAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFieldsEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoCompleteFieldsOnEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "AutoInc");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoUpload");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoUpdatable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "badgeColor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bInlineAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bInlineEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bUpdateSelected");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bIsEncrypted");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bListPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bPrinterPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "buttonsAdded");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CompatibilityMode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "categoryFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(60, "ChartRefreshTime");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "chartXml");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "chartType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "closePopupAfterAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "closePopupAfterEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(160, "controlWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "copy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CreateThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "crossTabReport");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CustomDisplay");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.DL_SINGLE, "detailsLinksOnList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "dashElements");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "dashCells");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "DateEditType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DecimalDigits");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "defaultSearchOption");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DefaultValue");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "delete");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "DeleteAssociatedFile");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "denyDuplicates");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "DependentLookups");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "descendingOrder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DisplayField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "edit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "editFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "EditFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "EditParams");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "exportTo");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.EXPORT_BOTH, "exportFormatting");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(",", "exportDelimiter");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldIsVideoUrl");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldIsImageUrl");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "FieldType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "FieldPermissions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "Filename");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "filterBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "filterFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FF_VALUE_LIST, "filterFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "filterIntervals");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FT_NONE, "filterTotals");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FM_NONE, "filterMultiSelect");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterCheckedMessageText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterCheckedMessageType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterUncheckedMessageText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterUncheckedMessageType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "filterSliderStepType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "filterSliderStepValue");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "filterKnobsType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "filterApplyBtn");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "flexibleSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "FormatTimeAttrs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "freeInput");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "FullName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldViewEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "googleLikeFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "GoodName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hasEncryptedFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hideEmptyFieldsOnView");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "HorizontalLookup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hlNewWindow");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "hlType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlLinkWordNameType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlLinkWordText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "highlightSearchResults");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("text", "HTML5InuptType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "Index");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "InitialYearFactor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ImageHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ImageWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "inlineAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "inlineAddFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "inlineEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "updateSelected");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "inlineEditFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isDisplayLoading");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "tableType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "IsRequired");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "insertNull");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isResizeColumns");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isSeparate");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UpdateLatLng");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseAjaxSuggest");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseAudio");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseFieldsMaps");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseTimeForSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseToolTips");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseVideo");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "listGridLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isExistTotalFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isViewPagePDFFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isPrinterPagePDFFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "isLandscapeViewPDFOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "isLandscapePrinterPagePDFOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isPrinterPagePDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isViewPagePDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isSQLExpression");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isPrinterPageFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "Keys");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "Label");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupConnId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(10, "LastYearFactor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.LCT_DROPDOWN, "LCType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "listPageId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "addPageId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LinkField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "LinkFieldType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LinkPrefix");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "list");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "listAjax");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "locking");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupDesc");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupOrderBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "LookupType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupUnique");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "LookupValues");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupWhere");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupWhereCode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "mainTableOwnerID");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "mapData");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "masterListFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxFileSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxImageHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxImageWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "maxNumberOfFiles");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxTotalFilesSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "moveNext");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "Multiselect");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "NCSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "NeedEncode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "NewSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "noRecordsFirstPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.ADVSECURITY_NONE, "nSecOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "NumberOfChars");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(10, "numberOfVisibleItems");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nViewPagePDFScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nPrinterPagePDFScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nPrinterPageScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "nPrinterPDFSplitRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "nPrinterSplitRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "OriginalTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "orderindexes");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "OwnerID");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ownerTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "OraSequenceName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "pageSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "panelSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "parentFilterField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "printFriendly");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "printFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printGridLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printReportLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printerPageOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "recsLimit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "recsPerRowList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "recsPerRowPrint");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ResizeImage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "RewindEnabled");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "requiredSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(3, "reportPrintGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "reportPrintPDFGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "searchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "searchPanelOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "SelectSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "selectExportDelimiter");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "selectExportFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "searchIsRequiredForFilters");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "searchOptionsList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ShortName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "shortTableName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showAddInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowCustomExpr");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showEditInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowFileSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "DisplayPDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowIcon");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showSearchPanel");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showSimpleSearchOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowTime");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showViewInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showCollapsed");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showWithNoRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "SimpleAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowListOfThumbnails");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.SORT_BY_DISP_VALUE, "sortValueType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlFrom");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlHead");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlTail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlWhereExpr");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "sqlquery");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strFilename");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strOrderBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "StrThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strSortControlSettingsJSON");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strClickActionJSON");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ThumbnailSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "scrollGridBody");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "fileStorageProvider");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "googleDriveFolder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "totalsFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(72, "ThumbHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(72, "ThumbWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "truncateText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "UploadFolder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UploadCodeExpression");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseCategory");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseRTE");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseTimestamp");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "validateAs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(200, "videoHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(300, "videoWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "videoTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "view");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ViewFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "warnLeavingPages");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "weekdays");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "weekdayMessage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "groupChart");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "chartLabelInterval");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "chartSeries");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "Absolute");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "acceptFileTypes");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "addFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "addPageEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ajaxCodeSnippetAdded");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "advSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "afterAddAction");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "afterAddActionDetTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "afterEditAction");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "afterEditActionDetTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "AllowToAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "allowFieldsReordering");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "allowShowHideFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "allSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrGridTabs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "arrRecsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "audioTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "audit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFieldsAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "autoCompleteFieldsEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoCompleteFieldsOnEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "AutoInc");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoUpload");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "autoUpdatable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "badgeColor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bInlineAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bInlineEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bUpdateSelected");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bIsEncrypted");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bListPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "bPrinterPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "buttonsAdded");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CompatibilityMode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "categoryFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(60, "ChartRefreshTime");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "chartXml");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "chartType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "closePopupAfterAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "closePopupAfterEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(160, "controlWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "copy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CreateThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "crossTabReport");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "CustomDisplay");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.DL_SINGLE, "detailsLinksOnList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "dashElements");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "dashCells");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "DateEditType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DecimalDigits");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "defaultSearchOption");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DefaultValue");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "delete");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "DeleteAssociatedFile");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "denyDuplicates");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "DependentLookups");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "descendingOrder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "DisplayField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "edit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "editFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "EditFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "EditParams");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "exportTo");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.EXPORT_BOTH, "exportFormatting");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(",", "exportDelimiter");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldIsVideoUrl");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldIsImageUrl");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "FieldType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "FieldPermissions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "Filename");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "filterBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "filterFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FF_VALUE_LIST, "filterFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "filterIntervals");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FT_NONE, "filterTotals");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.FM_NONE, "filterMultiSelect");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterCheckedMessageText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterCheckedMessageType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterUncheckedMessageText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "filterUncheckedMessageType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "filterSliderStepType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "filterSliderStepValue");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "filterKnobsType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "filterApplyBtn");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "flexibleSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "FormatTimeAttrs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "freeInput");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "FullName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "fieldViewEvents");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "googleLikeFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "GoodName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hasEncryptedFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hideEmptyFieldsOnView");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "HorizontalLookup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "hlNewWindow");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "hlType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlLinkWordNameType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlLinkWordText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "hlTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "highlightSearchResults");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("text", "HTML5InuptType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "Index");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "InitialYearFactor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ImageHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ImageWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "inlineAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "inlineAddFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "inlineEdit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "updateSelected");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "inlineEditFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isDisplayLoading");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "tableType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "IsRequired");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "insertNull");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isResizeColumns");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isSeparate");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UpdateLatLng");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseAjaxSuggest");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseAudio");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseFieldsMaps");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseTimeForSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseToolTips");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isUseVideo");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "listGridLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isExistTotalFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isViewPagePDFFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isPrinterPagePDFFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "isLandscapeViewPDFOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "isLandscapePrinterPagePDFOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isPrinterPagePDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isViewPagePDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "isSQLExpression");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "isPrinterPageFitToPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "Keys");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "Label");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupConnId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(10, "LastYearFactor");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.LCT_DROPDOWN, "LCType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "listPageId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "addPageId");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LinkField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "LinkFieldType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LinkPrefix");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "list");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "listAjax");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "locking");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupDesc");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupOrderBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "LookupType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupUnique");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "LookupValues");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "LookupWhere");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "LookupWhereCode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "mainTableOwnerID");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "mapData");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "masterListFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxFileSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxImageHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxImageWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "maxNumberOfFiles");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "maxTotalFilesSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "moveNext");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "Multiselect");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "NCSearch");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "NeedEncode");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "NewSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "noRecordsFirstPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.ADVSECURITY_NONE, "nSecOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "NumberOfChars");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(10, "numberOfVisibleItems");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nViewPagePDFScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nPrinterPagePDFScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(100, "nPrinterPageScale");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "nPrinterPDFSplitRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "nPrinterSplitRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "OriginalTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "orderindexes");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "OwnerID");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ownerTable");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "OraSequenceName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "pageSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "panelSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "parentFilterField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "printFriendly");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "printFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printGridLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printReportLayout");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "printerPageOrientation");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "recsLimit");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "recsPerRowList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "recsPerRowPrint");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ResizeImage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "RewindEnabled");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "requiredSearchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(3, "reportPrintGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "reportPrintPDFGroupsPerPage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "searchFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "searchPanelOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(1, "SelectSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "selectExportDelimiter");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "selectExportFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "searchIsRequiredForFilters");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "searchOptionsList");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ShortName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "shortTableName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showAddInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowCustomExpr");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showEditInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowFileSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "DisplayPDF");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowIcon");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showSearchPanel");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showSimpleSearchOptions");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowTime");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showViewInPopup");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showCollapsed");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "showWithNoRecords");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "SimpleAdd");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "ShowListOfThumbnails");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(Constants.SORT_BY_DISP_VALUE, "sortValueType");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlFrom");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlHead");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlTail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "sqlWhereExpr");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(null, "sqlquery");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strFilename");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strName");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strOrderBy");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "StrThumbnail");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strSortControlSettingsJSON");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "strClickActionJSON");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "ThumbnailSize");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "scrollGridBody");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "fileStorageProvider");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "googleDriveFolder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "totalsFields");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(72, "ThumbHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(72, "ThumbWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "truncateText");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "UploadFolder");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UploadCodeExpression");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseCategory");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseRTE");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "UseTimestamp");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "validateAs");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(200, "videoHeight");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(300, "videoWidth");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "videoTitleField");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "view");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "ViewFormat");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "warnLeavingPages");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem("", "weekdays");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "weekdayMessage");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(false, "groupChart");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(0, "chartLabelInterval");
			GlobalVars.g_defaultOptionValues.InitAndSetArrayItem(XVar.Array(), "chartSeries");

			GlobalVars.g_settingsType = new XVar();
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Absolute");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "acceptFileTypes");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "acceptFileTypesHtml");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "AllowToAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoCompleteFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoCompleteFieldsOnEdit");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "AutoInc");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "audioTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoUpload");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoUpdatable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bInlineAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bInlineEdit");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bUpdateSelected");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bIsEncrypted");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bListPage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bPrinterPage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "CompatibilityMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "categoryFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "controlWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "CreateThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "CustomDisplay");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DateEditType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "DecimalDigits");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "DeleteAssociatedFile");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "denyDuplicates");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DependentLookups");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DisplayField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "EditFormat");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "EditParams");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldIsVideoUrl");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldIsImageUrl");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FieldType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FieldPermissions");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "Filename");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "FormatTimeAttrs");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "freeInput");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FullName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "fieldEvents");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldViewEvents");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "GoodName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "HorizontalLookup");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlNewWindow");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlLinkWordNameType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlLinkWordText");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "HTML5InuptType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Index");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "InitialYearFactor");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ImageHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ImageWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "insertNull");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "IsRequired");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "isSeparate");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UpdateLatLng");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Label");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LastYearFactor");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LCType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "listPageId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "addPageId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LinkField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LinkFieldType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "LinkPrefix");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupConnId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupDesc");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupOrderBy");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupTable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupUnique");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupValues");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupWhere");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupWhereCode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "mapData");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxFileSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxImageHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxImageWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxNumberOfFiles");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxTotalFilesSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "Multiselect");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "nCols");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "NeedEncode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "NewSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "nRows");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.ADVSECURITY_NONE, "nSecOptions");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "NumberOfChars");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "ownerTable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "OraSequenceName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ResizeImage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "RewindEnabled");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "SelectSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowCustomExpr");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowFileSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "DisplayPDF");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowIcon");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ShowTime");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "SimpleAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowListOfThumbnails");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "strField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "strFilename");
			GlobalVars.g_settingsType.InitAndSetArrayItem("", "filterTotalFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "strEditMask");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "strName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "StrThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "fileStorageProvider");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "googleDriveFolder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ThumbnailSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ThumbHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ThumbWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "truncateText");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "timeFormatData");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "UploadFolder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "UploadCodeExpression");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseCategory");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseRTE");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseTimestamp");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "validateAs");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ViewFormat");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "multipleImgMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "maxImages");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "showGallery");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "galleryMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "captionMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "captionField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "imageBorder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "imageFullWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "weekdays");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "weekdayMessage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Absolute");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "acceptFileTypes");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "acceptFileTypesHtml");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "AllowToAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoCompleteFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoCompleteFieldsOnEdit");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "AutoInc");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "audioTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoUpload");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "autoUpdatable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bInlineAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bInlineEdit");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bUpdateSelected");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bIsEncrypted");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bListPage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "bPrinterPage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "CompatibilityMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "categoryFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "controlWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "CreateThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "CustomDisplay");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DateEditType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "DecimalDigits");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "DeleteAssociatedFile");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "denyDuplicates");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DependentLookups");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "DisplayField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "EditFormat");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "EditParams");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldIsVideoUrl");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldIsImageUrl");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FieldType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FieldPermissions");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "Filename");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "FormatTimeAttrs");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "freeInput");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "FullName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "fieldEvents");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "fieldViewEvents");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "GoodName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "HorizontalLookup");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlNewWindow");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlLinkWordNameType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlLinkWordText");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "hlTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "HTML5InuptType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Index");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "InitialYearFactor");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ImageHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ImageWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "insertNull");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "IsRequired");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "isSeparate");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UpdateLatLng");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "Label");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LastYearFactor");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LCType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "listPageId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "addPageId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LinkField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LinkFieldType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "LinkPrefix");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupConnId");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupDesc");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupOrderBy");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupTable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupType");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupUnique");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupValues");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupWhere");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "LookupWhereCode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "mapData");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxFileSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxImageHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxImageWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxNumberOfFiles");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "maxTotalFilesSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "Multiselect");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "nCols");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "NeedEncode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "NewSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "nRows");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.ADVSECURITY_NONE, "nSecOptions");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "NumberOfChars");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "ownerTable");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "OraSequenceName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ResizeImage");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "RewindEnabled");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "SelectSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowCustomExpr");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowFileSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "DisplayPDF");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowIcon");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ShowTime");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "SimpleAdd");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ShowListOfThumbnails");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "strField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "strFilename");
			GlobalVars.g_settingsType.InitAndSetArrayItem("", "filterTotalFields");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "strEditMask");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "strName");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "StrThumbnail");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "fileStorageProvider");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "googleDriveFolder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "ThumbnailSize");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ThumbHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ThumbWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "truncateText");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "timeFormatData");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "UploadFolder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_GLOBAL, "UploadCodeExpression");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseCategory");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseRTE");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "UseTimestamp");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "validateAs");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoHeight");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "videoTitleField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "ViewFormat");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "multipleImgMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "maxImages");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "showGallery");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "galleryMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "captionMode");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "captionField");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "imageBorder");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_VIEW, "imageFullWidth");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "weekdays");
			GlobalVars.g_settingsType.InitAndSetArrayItem(Constants.SETTING_TYPE_EDIT, "weekdayMessage");

			GlobalVars.appliedInitializers.Add("projectsettings");
		}
		public static void init_reportlib()
		{
			if(GlobalVars.appliedInitializers.Contains("reportlib"))
				return;

			GlobalVars.cache_db2time = XVar.Clone(XVar.Array());
			GlobalVars.cache_formatweekstart = XVar.Clone(XVar.Array());
			GlobalVars.cache_getdayofweek = XVar.Clone(XVar.Array());
			GlobalVars.cache_getweekstart = XVar.Clone(XVar.Array());

			GlobalVars.appliedInitializers.Add("reportlib");
		}
		public static void init_runnerpage()
		{
			if(GlobalVars.appliedInitializers.Contains("runnerpage"))
				return;

			GlobalVars.menuNodesObject = new XVar(null);
			GlobalVars.menuNodesObject = new XVar(null);

			GlobalVars.appliedInitializers.Add("runnerpage");
		}
	}
}
