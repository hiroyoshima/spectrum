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
	public partial class GlobalController : BaseController
	{
		public XVar geocoding()
		{
			try
			{
				if(MVCFunctions.GetServerVariable("PHP_SELF") == MVCFunctions.Concat("/", MVCFunctions.GetTableLink(new XVar("geocoding"))))
				{
					MVCFunctions.Echo(MVCFunctions.Concat("<!DOCTYPE html>\r\n\t\t  <html>\r\n\t\t\t<head>\r\n\t\t\t\t<style type='text/css'>\r\n\t\t\t\t\tdiv#message {\r\n\t\t\t\t\t\twidth: 300px;\r\n\t\t\t\t\t\theight: 50px auto;\r\n\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\tmargin: 100px auto 10px;\r\n\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\ttext-align: left;\r\n\t\t\t\t\t\tpadding: 10px 20px 10px 20px;\r\n\t\t\t\t\t\tfont: 14px Arial, sans-serif;\r\n\t\t\t\t\t}\t\t\t\t\t\t\t\t\r\n\t\t\t\t</style>\r\n\t\t\t</head>\r\n\t\t\t<body style='background: #bbb'>\t\t\t\t         \r\n\t\t\t\t<div id='message'> \r\n\t\t\t\t\t<h3> How-to </h3>\t\r\n\t\t\t\t\t<p> Add the following line to the 'Before process' event of your list page with a 'View as a Map' field: </p> \r\n\t\t\t\t\t<hr />\r\n\t\t\t\t\t<p> &nbsp;&nbsp;include_once(\"geocoding.php\");</p>\r\n\t\t\t\t\t<hr />\r\n\t\t\t\t\t<p> Set for your 'View as a Map' field 'Address', 'Latitude', 'Longitude' field names. \r\n\t\t\t\t\t (You can also define them manually in the event's code.)</p>\r\n\t\t\t\t\t<p> Run you list page contains one 'View as a Map' field with the 'geocoding=1' parameter,  eg:</p>\r\n\t\t\t\t\t<hr />\r\n\t\t\t\t\t<p> &nbsp;&nbsp;", MVCFunctions.GetTableLink(new XVar("map_list"), new XVar(""), new XVar("geocoding=1")), "</p>\r\n\t\t\t\t\t<hr />\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t</div>\r\n\t\t\t</body>    \r\n\t\t  </html>\r\n\t"));
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("geocoding"))))
				{
					dynamic _connection = null, addressField = null, addressFields = XVar.Array(), gData = XVar.Array(), goodTableName = null, latField = null, lngField = null, origTableName = null;
					GlobalVars.gSettings = XVar.Clone(new ProjectSettings((XVar)(GlobalVars.strTableName)));
					_connection = XVar.Clone(GlobalVars.cman.byTable((XVar)(GlobalVars.strTableName)));
					origTableName = XVar.Clone(GlobalVars.strOriginalTableName);
					goodTableName = XVar.Clone(MVCFunctions.GoodFieldName((XVar)(GlobalVars.strTableName)));
					gData = XVar.Clone(GlobalVars.gSettings.getGeocodingData());
					addressFields = XVar.Clone(XVar.Array());
					if(XVar.Pack(!(XVar)(addressField as object != null)))
					{
						addressFields = XVar.Clone(gData["addressFields"]);
					}
					else
					{
						addressFields.InitAndSetArrayItem(addressField, null);
					}
					if(XVar.Pack(!(XVar)(latField as object != null)))
					{
						latField = XVar.Clone(gData["latField"]);
					}
					if(XVar.Pack(!(XVar)(lngField as object != null)))
					{
						lngField = XVar.Clone(gData["lngField"]);
					}
					if((XVar)((XVar)(!(XVar)(addressField as object != null))  && (XVar)(!(XVar)(addressFields)))  || (XVar)((XVar)(latField == XVar.Pack(""))  && (XVar)(lngField == XVar.Pack(""))))
					{
						dynamic fieldsMapData = XVar.Array();
						foreach (KeyValuePair<XVar, dynamic> field in GlobalVars.gSettings.getFieldsList().GetEnumerator())
						{
							if(GlobalVars.gSettings.getViewFormat((XVar)(field.Value)) == "Map")
							{
								fieldsMapData.InitAndSetArrayItem(GlobalVars.gSettings.getMapData((XVar)(field.Value)), null);
							}
						}
						if(0 < MVCFunctions.count(fieldsMapData))
						{
							if(XVar.Pack(!(XVar)(addressFields)))
							{
								addressFields.InitAndSetArrayItem(fieldsMapData[0]["address"], null);
							}
							if(latField == XVar.Pack(""))
							{
								latField = XVar.Clone(fieldsMapData[0]["lat"]);
							}
							if(lngField == XVar.Pack(""))
							{
								lngField = XVar.Clone(fieldsMapData[0]["lng"]);
							}
						}
					}
					if(XVar.Pack(!(XVar)(MVCFunctions.postvalue(new XVar("ajax")))))
					{
						dynamic address = null, addresses = XVar.Array(), data = XVar.Array(), fieldType = null, items = XVar.Array(), keyFields = XVar.Array(), qResult = null, query = null, tmpWhere = null;
						if((XVar)((XVar)(!(XVar)(addressFields))  || (XVar)(latField == XVar.Pack("")))  || (XVar)(lngField == XVar.Pack("")))
						{
							MVCFunctions.Echo(MVCFunctions.Concat("<!DOCTYPE html>\r\n\t\t\t\t  <html>\r\n\t\t\t\t\t<head>\r\n\t\t\t\t\t\t<style type='text/css'>\r\n\t\t\t\t\t\t\tdiv#message {\r\n\t\t\t\t\t\t\t\twidth: 300px;\r\n\t\t\t\t\t\t\t\theight: 50px;\r\n\t\t\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\t\t\tmargin: 0px auto 10px;\r\n\t\t\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\t\t\ttext-align:center;\r\n\t\t\t\t\t\t\t\tpadding: 30px;\r\n\t\t\t\t\t\t\t\tfont: 16px Arial, sans-serif;\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\tdiv#inf  {\r\n\t\t\t\t\t\t\t\twidth: 300px;\r\n\t\t\t\t\t\t\t\theight: 60px;\r\n\t\t\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\t\t\tmargin: 100px auto 30px auto;\r\n\t\t\t\t\t\t\t\tpadding: 10px 10px 10px 50px;\r\n\t\t\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\t\t\ttext-align: left;\r\n\t\t\t\t\t\t\t\tfont: 16px Arial, sans-serif;\t\t\t\t\r\n\t\t\t\t\t\t\t}\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t</style>\r\n\t\t\t\t\t</head>\r\n\t\t\t\t\t<body style='background: #bbb'>\r\n\t\t\t\t\t\t<div id='inf'> The 'Address' fields names: &nbsp;&nbsp;&nbsp;", (XVar.Pack(MVCFunctions.count(addressFields)) ? XVar.Pack(MVCFunctions.implode(new XVar(" "), (XVar)(addressFields))) : XVar.Pack("&mdash;")), "<br> The 'Latitude' field name:&nbsp;&nbsp;&nbsp; ", (XVar.Pack(latField) ? XVar.Pack(latField) : XVar.Pack("&mdash;")), "<br> the 'Longtitude' field name: ", (XVar.Pack(lngField) ? XVar.Pack(lngField) : XVar.Pack("&mdash;")), "<br></div>            \r\n\t\t\t\t\t\t<div id='message'> <p> Some field names were not defined </p> </div>\r\n\t\t\t\t\t</body>    \r\n\t\t\t\t  </html>\r\n\t\t\t"));
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
						keyFields = XVar.Clone(XVar.Array());
						addresses = XVar.Clone(XVar.Array());
						query = XVar.Clone(GlobalVars.gSettings.getSQLQuery());
						tmpWhere = XVar.Clone(MVCFunctions.Concat(_connection.addFieldWrappers((XVar)(latField)), " is NULL or ", _connection.addFieldWrappers((XVar)(lngField)), " is NULL"));
						fieldType = XVar.Clone(GlobalVars.gSettings.getFieldType((XVar)(latField)));
						if(XVar.Pack(CommonFunctions.IsCharType((XVar)(fieldType))))
						{
							tmpWhere = MVCFunctions.Concat(tmpWhere, " or ", _connection.addFieldWrappers((XVar)(latField)), "=\"\"");
						}
						fieldType = XVar.Clone(GlobalVars.gSettings.getFieldType((XVar)(lngField)));
						if(XVar.Pack(CommonFunctions.IsCharType((XVar)(fieldType))))
						{
							tmpWhere = MVCFunctions.Concat(tmpWhere, " or ", _connection.addFieldWrappers((XVar)(lngField)), "=\"\"");
						}
						query.addWhere((XVar)(tmpWhere));
						qResult = XVar.Clone(_connection.query((XVar)(query.toSql())));
						while(XVar.Pack(data = XVar.Clone(qResult.fetchAssoc())))
						{
							address = new XVar("");
							foreach (KeyValuePair<XVar, dynamic> aField in addressFields.GetEnumerator())
							{
								if((XVar)(data.KeyExists(aField.Value))  && (XVar)(MVCFunctions.strlen((XVar)(MVCFunctions.trim((XVar)(data[aField.Value]))))))
								{
									address = MVCFunctions.Concat(address, MVCFunctions.trim((XVar)(data[aField.Value])), " ");
								}
							}
							addresses.InitAndSetArrayItem(address, null);
							items = XVar.Clone(XVar.Array());
							foreach (KeyValuePair<XVar, dynamic> name in GlobalVars.gSettings.getTableKeys().GetEnumerator())
							{
								items.InitAndSetArrayItem(data[name.Value], name.Value);
							}
							keyFields.InitAndSetArrayItem(items, null);
						}
						MVCFunctions.Echo(MVCFunctions.Concat("<!DOCTYPE html>\r\n\t\t  <html>\r\n\t\t\t<head>\r\n\t\t\t\t<title> Geocoding </title>\r\n\t\t\t\t<script src='", MVCFunctions.GetRootPathForResources(new XVar("include/jquery.js")), "'></script>\r\n\t\t\t\t<script type='text/javascript'>\r\n\t\t\t\t\tfunction initialize() {\r\n\t\t\t\t\t\tvar adresses = [],\r\n\t\t\t\t\t\t\tkeyFields = [],\r\n\t\t\t\t\t\t\tpromises = [],\r\n\t\t\t\t\t\t\tupdates =[],\r\n\t\t\t\t\t\t\terrors = [], \r\n\t\t\t\t\t\t\ti;\r\n\t\t\t\t\t   \r\n\t\t\t\t\t\tkeyFields = ", MVCFunctions.my_json_encode((XVar)(keyFields)), ";\r\n\t\t\t\t\t\taddresses = ", MVCFunctions.my_json_encode((XVar)(addresses)), ";\r\n\r\n\t\t\t\t\t\t//traversing\r\n\t\t\t\t\t\tif (addresses.length > 0) {\r\n\t\t\t\t\t\t\t$('#progress p').text(addresses.length + ' address field(s) in progress');                   \r\n\t\t\t\t\t\t\t$('#progress').fadeIn();\r\n\t\t\t\t\t   \r\n\t\t\t\t\t\t\tfor (i = 0; i < addresses.length; i++) {\r\n\t\t\t\t\t\t\t\tsetTimeout( (function(i) {\r\n\t\t\t\t\t\t\t\t\tvar d = $.Deferred();\r\n\t\t\t\t\t\t\t\t\tpromises.push(d);\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\treturn function() {\r\n\t\t\t\t\t\t\t\t\t\tvar update = {\r\n\t\t\t\t\t\t\t\t\t\t\tkeyfields: keyFields[i],\r\n\t\t\t\t\t\t\t\t\t\t\taddr: addresses[i]\r\n\t\t\t\t\t\t\t\t\t\t};    \r\n\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t$('#bar').css('width', Math.round(100 * i/ (addresses.length - 1)) + '%');\r\n\t\t\t\t\t\t\t\t\t\t$('#counts').html((i + 1) + '/' + addresses.length + ' processed');\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t$.post('", MVCFunctions.GetTableLink((XVar)(goodTableName), new XVar("list")), "', {ajax: 1, geocoding: 1, update: update}, function(status) {\r\n\t\t\t\t\t\t\t\t\t\t\tif (status != 'OK') {\r\n\t\t\t\t\t\t\t\t\t\t\t\t//Geocode was not successful\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t    $('#error')\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t.text( status )\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t.fadeIn()\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t.fadeOut();\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t$('#error_report2')\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t.show();\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\terrors.push('<br>&nbsp;&nbsp;' + status + ', ' + update.addr);\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t$('div#error_list')\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t.html( '<br>Geocode was not successful <br> for the&nbsp;' \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t+ errors.length + '&nbsp;address(es) <br> for the following reasons:' + errors.join('') );                                       \r\n\t\t\t\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\t\t\t\td.resolve();\r\n\t\t\t\t\t\t\t\t\t\t});  \r\n\t\t\t\t\t\t\t\t\t};\r\n\t\t\t\t\t\t\t\t})(i), 300 * i);\r\n\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t$.when.apply(null, promises).done( function() {\r\n\t\t\t\t\t\t\t\tsetTimeout( function() {\r\n\t\t\t\t\t\t\t\t\t$('#progress').hide();                       \r\n\t\t\t\t\t\t\t\t\t$('#message')\r\n\t\t\t\t\t\t\t\t\t\t.hide()\r\n\t\t\t\t\t\t\t\t\t\t.fadeIn();\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t$('#message p')\r\n\t\t\t\t\t\t\t\t\t\t.html('All done<br><br><br><button class=\\'runner-btnframe\\' type=\\'button\\' onclick=\"$(\\'#message\\').css(\\'opacity\\', 0);\">Ok</button><button class=\\'runner-btnframe\\' type=\\'button\\' onclick=\"window.location.href=\\'", MVCFunctions.GetTableLink((XVar)(goodTableName), new XVar("list"), new XVar("geocoding=1")), "\\'\">Try again</button>');\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\tif (errors.length > 0) {\r\n\t\t\t\t\t\t\t\t\t\t$('#error_report2 span').hide();\r\n\t\t\t\t\t\t\t\t\t\t$('#error_list').html('<br>Geocode was not successful <br> for the&nbsp;'+ errors.length \r\n\t\t\t\t\t\t\t\t\t\t\t+'&nbsp;address(es) <br> for the following reasons:' + errors.toString());\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\t}, 250);\r\n\t\t\t\t\t\t\t});\t\t  \r\n\t\t\t\t\t\t} else {\r\n\t\t\t\t\t\t\t$('#message p').html('<br>All addresses were resolved before');\r\n\t\t\t\t\t\t\t$('#message').fadeIn();\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}    \r\n\t\t\t\t</script>\r\n\t\t\t\t<style type='text/css'>       \r\n\t\t\t\t\tdiv.progress, div.message {\r\n\t\t\t\t\t\twidth: 300px;\r\n\t\t\t\t\t\theight: 120px;\r\n\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\tmargin: 0px auto 10px;\r\n\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\ttext-align:center;\r\n\t\t\t\t\t\tpadding: 30px;\r\n\t\t\t\t\t\tdisplay: none;\r\n\t\t\t\t\t\tfont: 16px Arial, sans-serif;\r\n\t\t\t\t\t}\t\r\n\t\t\t\t\tdiv.bar-container {\r\n\t\t\t\t\t\theight: 24px;\r\n\t\t\t\t\t\tborder: 1px solid #333;\r\n\t\t\t\t\t\tmargin-bottom: 5px;\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv.bar {               \r\n\t\t\t\t\t\theight: 100%;\r\n\t\t\t\t\t\twidth: 0%;\r\n\t\t\t\t\t\tbackground: green;\r\n\t\t\t\t\t\t-webkit-transition: width 0.5s;\r\n\t\t\t\t\t\t-moz-transition: width 0.5s;\r\n\t\t\t\t\t\t-ms-transition: width 0.5s;\r\n\t\t\t\t\t\t-o-transition: width 0.5s;\r\n\t\t\t\t\t\ttransition: width 0.5s;\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv.error{\r\n\t\t\t\t\t\tdisplay: none;\r\n\t\t\t\t\t\tmargin: 5px;\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv#error_report{\r\n\t\t\t\t\t\ttext-align: left;\r\n\t\t\t\t\t\theight: auto;\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv#error_report2{\r\n\t\t\t\t\t\tmargin: 0 auto 10px;\r\n\t\t\t\t\t\tdisplay: none;\r\n\t\t\t\t\t\theight: 150px auto;\r\n\t\t\t\t\t\twidth: 360px;\r\n\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\ttext-align: left;\r\n\t\t\t\t\t\tfont: 16px Arial, sans-serif;\t\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv#error_list{\r\n\t\t\t\t\t\tpadding-bottom: 10px;\r\n\t\t\t\t\t\tmargin: 30px 30px auto 30px;\r\n\t\t\t\t\t}\r\n\t\t\t\t\t.runner-btnframe {\r\n\t\t\t\t\t\tdisplay: inline-block;\r\n\t\t\t\t\t\tposition: relative;\r\n\t\t\t\t\t\twhite-space: nowrap;\r\n\t\t\t\t\t\twidth: auto;\r\n\t\t\t\t\t\tz-index: 0;\r\n\t\t\t\t\t\tvertical-align: middle;\r\n\t\t\t\t\t\tmargin: 0 4pt;\r\n\t\t\t\t\t\tfont: 14px Arial, sans-serif;\r\n\t\t\t\t\t\theight: 30px;\t\t\r\n\t\t\t\t\t}\r\n\t\t\t\t\tdiv#inf{\r\n\t\t\t\t\t\twidth: 300px;\r\n\t\t\t\t\t\theight: 60px;\r\n\t\t\t\t\t\tbackground: #fff;\r\n\t\t\t\t\t\tborder-radius: 10px;\r\n\t\t\t\t\t\tmargin: 100px auto 30px auto;\r\n\t\t\t\t\t\tpadding: 10px 10px 10px 50px;\r\n\t\t\t\t\t\tbox-shadow: 10px 20px 30px rgba(0,0,0,0.4);\r\n\t\t\t\t\t\ttext-align: left;\r\n\t\t\t\t\t\tfont: 16px Arial, sans-serif;\t\t\t\t\r\n\t\t\t\t\t}\t\t\r\n\t\t\t\t</style>\r\n\t\t\t</head>\r\n\t\t\t<body style='background: #bbb;' onload='initialize()'>\r\n\t\t\t\t<div id='inf'>\r\n\t\t\t\t<p> Updating coordinates (<b>", latField, "</b> and <b>", lngField, "</b> fields) based on the <b>", MVCFunctions.implode(new XVar(" "), (XVar)(addressFields)), "</b> fields values</p>\t\r\n\t\t\t\t</div>\r\n\t\t\t\t<div id='progress' class='progress'>\r\n\t\t\t\t\t<p></p>\r\n\t\t\t\t\t<div id='bar-container' class='bar-container'>\r\n\t\t\t\t\t\t<div id='bar' class='bar'></div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div id='counts'></div>\r\n\t\t\t\t\t<div id='error' class='error'></div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div id='message' class='message'>\r\n\t\t\t\t\t<p></p>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div id='error_report2'>\r\n\t\t\t\t\t<div id='error_list'></div>\r\n\t\t\t\t</div>\r\n\t\t\t</body>\r\n\t\t</html>\r\n\t\t"));
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					else
					{
						dynamic a = XVar.Array(), addr = null, get = null, url = null;
						addr = XVar.Clone(MVCFunctions.urlencode((XVar)(MVCFunctions.postvalue("update")["addr"])));
						url = XVar.Clone(MVCFunctions.Concat("http://maps.googleapis.com/maps/api/geocode/json?address=", addr, "&sensor=false"));
						get = XVar.Clone(MVCFunctions.file_get_contents((XVar)(url)));
						a = XVar.Clone(MVCFunctions.my_json_decode((XVar)(get)));
						MVCFunctions.Echo(a["status"]);
						if(a["status"] == "OK")
						{
							dynamic lat = null, lng = null, sql = null, where = null;
							where = XVar.Clone(CommonFunctions.KeyWhere((XVar)(MVCFunctions.postvalue("update")["keyfields"]), (XVar)(GlobalVars.strTableName)));
							lat = XVar.Clone(a["results"][0]["geometry"]["location"]["lat"]);
							lng = XVar.Clone(a["results"][0]["geometry"]["location"]["lng"]);
							sql = XVar.Clone(MVCFunctions.Concat("update ", _connection.addTableWrappers((XVar)(origTableName)), " set ", _connection.addFieldWrappers((XVar)(latField)), " = ", lat, ", ", _connection.addFieldWrappers((XVar)(lngField)), " = ", lng, " where ", where));
							_connection.exec((XVar)(sql));
						}
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
