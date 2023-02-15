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
	public partial class SecurityPluginGoogle : SecurityPlugin
	{
		protected dynamic domain = XVar.Pack("");
		protected static bool skipSecurityPluginGoogleCtor = false;
		public SecurityPluginGoogle(dynamic _param_params)
			:base((XVar)_param_params)
		{
			if(skipSecurityPluginGoogleCtor)
			{
				skipSecurityPluginGoogleCtor = false;
				return;
			}
			#region pass-by-value parameters
			dynamic var_params = XVar.Clone(_param_params);
			#endregion

			this.appId = XVar.Clone(var_params["clientId"]);
			this.domain = XVar.Clone(var_params["domain"]);
		}
		public override XVar getUserInfo(dynamic _param_id_token)
		{
			#region pass-by-value parameters
			dynamic id_token = XVar.Clone(_param_id_token);
			#endregion

			dynamic payload = XVar.Array(), ret = XVar.Array();
			payload = XVar.Clone(this.verifyIdToken((XVar)(id_token)));
			if(XVar.Pack(payload["error"]))
			{
				this.var_error = XVar.Clone(MVCFunctions.Concat("Google security plugin: ", payload["error"], " ", payload["error_description"]));
			}
			if((XVar)(!(XVar)(payload))  || (XVar)(payload["error"]))
			{
				return XVar.Array();
			}
			CommonFunctions.setProjectCookie(new XVar("google_token"), (XVar)(id_token), (XVar)(MVCFunctions.time() + (30 * 1440) * 60), new XVar(true));
			ret = XVar.Clone(new XVar("id", MVCFunctions.Concat("go", payload["sub"]), "name", MVCFunctions.runner_convert_encoding((XVar)(payload["name"]), (XVar)(GlobalVars.cCharset), new XVar("UTF-8")), "email", payload["email"], "raw", payload));
			if(XVar.Pack(payload["picture"]))
			{
				dynamic picResult = XVar.Array();
				picResult = XVar.Clone(MVCFunctions.runner_http_request((XVar)(payload["picture"]), new XVar(""), new XVar("GET"), (XVar)(XVar.Array()), new XVar(false)));
				if(XVar.Pack(picResult["content"]))
				{
					ret.InitAndSetArrayItem(picResult["content"], "picture");
				}
			}
			return ret;
		}
		private XVar getDomainList()
		{
			dynamic domainList = XVar.Array(), rawDomain = null, result = XVar.Array();
			rawDomain = XVar.Clone(this.domain);
			domainList = XVar.Clone(MVCFunctions.explode(new XVar(","), (XVar)(rawDomain)));
			result = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> domain in domainList.GetEnumerator())
			{
				dynamic trimDomain = null;
				trimDomain = XVar.Clone(MVCFunctions.trim((XVar)(domain.Value)));
				if(XVar.Pack(trimDomain))
				{
					result.InitAndSetArrayItem(trimDomain, null);
				}
			}
			return result;
		}
		public virtual XVar verifyIdToken(dynamic _param_token)
		{
			#region pass-by-value parameters
			dynamic token = XVar.Clone(_param_token);
			#endregion

			dynamic certPath = null, domainList = null, headers = XVar.Array(), jwk = null, payload = XVar.Array(), url = null, var_params = null, var_response = XVar.Array(), verifiedTokenData = XVar.Array(), wellKnown = null;
			wellKnown = XVar.Clone(Security.getOpenIdConfiguration(new XVar("https://accounts.google.com/.well-known/openid-configuration")));
			jwk = XVar.Clone(Security.getOpenIdJWK((XVar)(token), (XVar)(wellKnown)));
			verifiedTokenData = XVar.Clone(Security.openIdVerifyToken((XVar)(token), (XVar)(jwk)));
			if(XVar.Pack(!(XVar)(verifiedTokenData)))
			{
				return false;
			}
			payload = XVar.Clone(verifiedTokenData["payload"]);
			domainList = XVar.Clone(this.getDomainList());
			if(XVar.Pack(domainList))
			{
				if(XVar.Pack(!(XVar)(MVCFunctions.in_array((XVar)(payload["hd"]), (XVar)(domainList)))))
				{
					dynamic domains = null;
					domains = XVar.Clone(MVCFunctions.implode(new XVar(", "), (XVar)(domainList)));
					this.var_error = XVar.Clone(MVCFunctions.str_replace(new XVar("%s"), (XVar)(domains), (XVar)(CommonFunctions.mlang_message(new XVar("GOOGLE_DOMAIN")))));
					return false;
				}
			}
			return payload;
		}
		public override XVar getJSSettings()
		{
			return new XVar("isGoogleSignIn", true, "GoogleClientId", this.appId);
		}
		public override XVar onLogout()
		{
			CommonFunctions.setProjectCookie(new XVar("google_token"), new XVar(""), (XVar)(MVCFunctions.time() - 1), new XVar(true));
			return null;
		}
		public override XVar savedToken()
		{
			return MVCFunctions.GetCookie("google_token");
		}
	}
}
