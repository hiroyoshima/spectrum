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
	public static partial class Settings_dashboard
	{
		static public void Apply()
		{
			SettingsMap fieldLabelsArray = new XVar(), pageTitlesArray = new XVar(), query = null, queryData_Array = new XVar(), table = null, tdataArray = new XVar();
			tdataArray["dashboard"] = SettingsMap.GetArray();
			tdataArray["dashboard"][".ShortName"] = "dashboard";
			tdataArray["dashboard"][".pagesByType"] = MVCFunctions.my_json_decode(new XVar("{\"dashboard\":[\"dashboard\"]}"));
			tdataArray["dashboard"][".originalPagesByType"] = tdataArray["dashboard"][".pagesByType"];
			tdataArray["dashboard"][".pages"] = CommonFunctions.types2pages(MVCFunctions.my_json_decode(new XVar("{\"dashboard\":[\"dashboard\"]}")));
			tdataArray["dashboard"][".originalPages"] = tdataArray["dashboard"][".pages"];
			tdataArray["dashboard"][".defaultPages"] = MVCFunctions.my_json_decode(new XVar("{\"dashboard\":\"dashboard\"}"));
			tdataArray["dashboard"][".originalDefaultPages"] = tdataArray["dashboard"][".defaultPages"];
			fieldLabelsArray["dashboard"] = SettingsMap.GetArray();
			pageTitlesArray["dashboard"] = SettingsMap.GetArray();
			if(CommonFunctions.mlang_getcurrentlang() == "English")
			{
				fieldLabelsArray["dashboard"]["English"] = SettingsMap.GetArray();
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_ID"] = "ID";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_referenceID"] = "Reference ID";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_applicationNo"] = "Application No";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_companyNameA"] = "Company Name ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_userCreate"] = "User Create";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_userUpdate"] = "User Update";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_dateCreated"] = "Date Created";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_dateUpdated"] = "Date Updated";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_companyNameB"] = "Company Name B";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_siteNameA"] = "Site Name:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_siteNameB"] = "Site Name";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_siteIDA"] = "Site ID:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_siteIDB"] = "Site ID:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_coordinateA"] = "Coordinate:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_coordinateB"] = "Coordinate:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_elevationA"] = "Elevation:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_elevationB"] = "Elevation ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_makeTypeModelA"] = "Make/Model:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_gainA"] = "Gain(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_diameterA"] = "Diameter(M):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_beamwidthA"] = "Beamwidth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_polarizationA"] = "Polarization:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_azimuthA"] = "Azimuth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_elevAngleA"] = "Elevation Angle:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_heightAGLA"] = "Height(AGL):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_feederLengthA"] = "Feeder Length(M)/AH(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_makeTypeModelB"] = "Make Type Model ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_gainB"] = "Gain(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_diameterB"] = "Diameter(M):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_beamwidthB"] = "Beamwidth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_polarizationB"] = "Polarization:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_azimuthB"] = "Azimuth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_elevAngleB"] = "Elevation Angle:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_heightAGLB"] = "Height (AGL):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_feederLengthB"] = "Feeder Length (M)/AH (dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_longtitudeA"] = "Longtitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_longtitudeB"] = "Longtitude ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_latitudeA"] = "Latitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_latitudeB"] = "Latitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_callSignA"] = "Call Sign:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_callSignB"] = "Call Sign:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_applicationType"] = "Application Type:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_unit_a"] = "Unit:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_street_a"] = "Street:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_barangay_a"] = "Barangay:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_city_a"] = "City:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_province_a"] = "Province:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_zipcode_a"] = "Zipcode:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_unit_b"] = "Unit:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_street_b"] = "Street:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_barangay_b"] = "Barangay:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_city_b"] = "City:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_province_b"] = "Province:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_zipcode_b"] = "Zipcode:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspdHeader_map"] = "Map";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_ID"] = "ID";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_referenceID"] = "Reference ID";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_applicationNo"] = "Application No";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_companyNameA"] = "Company Name ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_userCreate"] = "User Created:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_userUpdate"] = "User Modified:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_dateCreated"] = "Date Created";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_dateUpdated"] = "Date Modified:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_companyNameB"] = "Company Name B";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_siteNameA"] = "Site Name:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_siteNameB"] = "Site Name";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_siteIDA"] = "Site ID:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_siteIDB"] = "Site ID:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_coordinateA"] = "Coordinate:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_coordinateB"] = "Coordinate:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_elevationA"] = "Elevation:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_elevationB"] = "Elevation ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_makeTypeModelA"] = "Make/Model:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_gainA"] = "Gain(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_diameterA"] = "Diameter(M):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_beamwidthA"] = "Beamwidth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_polarizationA"] = "Polarization:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_azimuthA"] = "Azimuth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_elevAngleA"] = "Elevation Angle:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_heightAGLA"] = "Height(AGL):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_feederLengthA"] = "Feeder Length(M)/AH(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_makeTypeModelB"] = "Make Type Model ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_gainB"] = "Gain(dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_diameterB"] = "Diameter(M):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_beamwidthB"] = "Beamwidth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_polarizationB"] = "Polarization:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_azimuthB"] = "Azimuth:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_elevAngleB"] = "Elevation Angle:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_heightAGLB"] = "Height (AGL):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_feederLengthB"] = "Feeder Length (M)/AH (dB):";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_longtitudeA"] = "Longtitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_longtitudeB"] = "Longtitude ";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_latitudeA"] = "Latitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_latitudeB"] = "Latitude:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_callSignA"] = "Call Sign:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_callSignB"] = "Call Sign:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_applicationType"] = "Application Type:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_unit_a"] = "Unit:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_street_a"] = "Street:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_barangay_a"] = "Barangay:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_city_a"] = "City:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_province_a"] = "Province:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_zipcode_a"] = "Zipcode:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_unit_b"] = "Unit:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_street_b"] = "Street:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_barangay_b"] = "Barangay:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_city_b"] = "City:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_province_b"] = "Province:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_zipcode_b"] = "Zipcode:";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_map"] = "Map";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_stage"] = "Stage";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_stageStatus"] = "Stage Status";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_externalReferenceNo"] = "External Reference No";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_classStationService"] = "Class Station Service";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_modeOfOperation"] = "Mode Of Operation";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_Remarks"] = "Remarks";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_dateOfApprovedBrief"] = "Date Of Approved Brief";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_recommendations"] = "Recommendations";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_applicationCategory"] = "Application Category";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_address"] = "Address";
				fieldLabelsArray["dashboard"]["English"]["dbo_rspd_application_received_view_data"] = "View Data";
			}
			tdataArray["dashboard"][".shortTableName"] = "dashboard";
			tdataArray["dashboard"][".entityType"] = 4;

			tdataArray["dashboard"][".hasEvents"] = false;
			tdataArray["dashboard"][".tableType"] = "dashboard";

			tdataArray["dashboard"][".addPageEvents"] = false;
			tdataArray["dashboard"][".isUseAjaxSuggest"] = true;
			GlobalVars.tables_data["Dashboard"] = tdataArray["dashboard"];
			GlobalVars.field_labels["Dashboard"] = fieldLabelsArray["dashboard"];
			GlobalVars.page_titles["Dashboard"] = pageTitlesArray["dashboard"];
		}
	}

}
