
Runner.pages.PageSettings.addPageEvent('dbo.applicationsRecieved',Runner.pages.constants.PAGE_ADD,"afterPageReady",function(pageObj,proxy,pageid,inlineRow,inlineObject,row){setTimeout(function(){document.getElementById('revertall_edited2').click();},2000);var siteNameB=Runner.getControl(pageid,"siteNameB");var siteIDB=Runner.getControl(pageid,"siteIDB");var provinceB=Runner.getControl(pageid,"province_b");var CityB=Runner.getControl(pageid,"city_b");var barangayB=Runner.getControl(pageid,"barangay_b");var streetB=Runner.getControl(pageid,"street_b");var unitB=Runner.getControl(pageid,"unit_b");var longtitudeB=Runner.getControl(pageid,"longtitudeB");var latitudeB=Runner.getControl(pageid,"latitudeB");var elevationB=Runner.getControl(pageid,"elevationB");var makeTypeModelB=Runner.getControl(pageid,"makeTypeModelB");var gainB=Runner.getControl(pageid,"gainB");var diameterB=Runner.getControl(pageid,"diameterB");var beamwidthB=Runner.getControl(pageid,"beamwidthB");var polarizationB=Runner.getControl(pageid,"polarizationB");var azimuthB=Runner.getControl(pageid,"azimuthB");var elevAngleB=Runner.getControl(pageid,"elevAngleB");var heightB=Runner.getControl(pageid,"heightAGLB");var feederLengthB=Runner.getControl(pageid,"feederLengthB");var callsignB=Runner.getControl(pageid,"callSignB");var app_cat=Runner.getControl(pageid,"applicationCategory");app_cat.on('change',function(e){document.getElementById('revertall_edited2').click();if(this.getValue()=='NarrowBand'){siteNameB.clear();siteIDB.clear();provinceB.clear();CityB.clear();streetB.clear();unitB.clear();longtitudeB.clear();latitudeB.clear();elevationB.clear();makeTypeModelB.clear();gainB.clear();diameterB.clear();beamwidthB.clear();polarizationB.clear();azimuthB.clear();elevAngleB.clear();heightB.clear();feederLengthB.clear();callsignB.clear();barangayB.clear();siteNameB.setDisabled();siteIDB.setDisabled();provinceB.setDisabled();CityB.setDisabled();streetB.setDisabled();unitB.setDisabled();longtitudeB.setDisabled();latitudeB.setDisabled();elevationB.setDisabled();makeTypeModelB.setDisabled();gainB.setDisabled();diameterB.setDisabled();beamwidthB.setDisabled();polarizationB.setDisabled();azimuthB.setDisabled();elevAngleB.setDisabled();heightB.setDisabled();feederLengthB.setDisabled();callsignB.setDisabled();barangayB.setDisabled();}else{siteNameB.setEnabled();siteIDB.setEnabled();provinceB.setEnabled();CityB.setEnabled();streetB.setEnabled();unitB.setEnabled();longtitudeB.setEnabled();latitudeB.setEnabled();elevationB.setEnabled();makeTypeModelB.setEnabled();gainB.setEnabled();diameterB.setEnabled();beamwidthB.setEnabled();polarizationB.setEnabled();azimuthB.setEnabled();elevAngleB.setEnabled();heightB.setEnabled();feederLengthB.setEnabled();callsignB.setEnabled();barangayB.setEnabled();}});;});