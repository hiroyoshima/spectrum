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
	public partial class ViewDatabaseImageField : ViewImageDownloadField
	{
		protected static bool skipViewDatabaseImageFieldCtor = false;
		public ViewDatabaseImageField(dynamic _param_field, dynamic _param_container, dynamic _param_pageobject) // proxy constructor
			:base((XVar)_param_field, (XVar)_param_container, (XVar)_param_pageobject) {}

		public override XVar getPdfValue(dynamic data, dynamic _param_keylink = null)
		{
			#region default values
			if(_param_keylink as Object == null) _param_keylink = new XVar("");
			#endregion

			#region pass-by-value parameters
			dynamic keylink = XVar.Clone(_param_keylink);
			#endregion

			dynamic imageType = null;
			if(XVar.Pack(!(XVar)(data[this.field])))
			{
				return "\"\"";
			}
			imageType = XVar.Clone(MVCFunctions.SupposeImageType((XVar)(data[this.field])));
			if((XVar)(imageType == "image/jpeg")  || (XVar)(imageType == "image/png"))
			{
				return MVCFunctions.Concat("{\r\n\t\t\t\timage: \"", CommonFunctions.jsreplace((XVar)(MVCFunctions.Concat("data:", imageType, ";base64,", MVCFunctions.base64_bin2str((XVar)(data[this.field]))))), "\",\r\n\t\t\t\twidth: ", this.container.pSet.getImageWidth((XVar)(this.field)), ",\r\n\t\t\t\theight: ", this.container.pSet.getImageHeight((XVar)(this.field)), "\r\n\t\t\t}");
			}
			else
			{
				dynamic urls = XVar.Array();
				urls = XVar.Clone(this.getFileURLs((XVar)(data), (XVar)(keylink)));
				if(XVar.Pack(urls))
				{
					return MVCFunctions.Concat("{\r\n\t\t\t\t\timage: \"", CommonFunctions.jsreplace((XVar)(urls[0]["image"])), "\",\r\n\t\t\t\t\twidth: ", this.container.pSet.getImageWidth((XVar)(this.field)), ",\r\n\t\t\t\t\theight: ", this.container.pSet.getImageHeight((XVar)(this.field)), "\r\n\t\t\t\t}");
				}
			}
			return "\"\"";
		}
		protected override XVar getFileURLs(dynamic data, dynamic _param_keylink)
		{
			#region pass-by-value parameters
			dynamic keylink = XVar.Clone(_param_keylink);
			#endregion

			dynamic fileName = null, fileNameF = null, fileURLs = XVar.Array(), thumbField = null, url = XVar.Array(), var_params = XVar.Array();
			ProjectSettings pSet;
			fileURLs = XVar.Clone(XVar.Array());
			if(XVar.Pack(!(XVar)(data[this.field])))
			{
				return XVar.Array();
			}
			pSet = XVar.UnPackProjectSettings(this.pSettings());
			fileName = new XVar("file.jpg");
			fileNameF = XVar.Clone(pSet.getFilenameField((XVar)(this.field)));
			if((XVar)(fileNameF)  && (XVar)(data[fileNameF]))
			{
				fileName = XVar.Clone(data[fileNameF]);
			}
			var_params = XVar.Clone(XVar.Array());
			var_params.InitAndSetArrayItem(fileName, "filename");
			var_params.InitAndSetArrayItem(pSet.table(), "table");
			var_params.InitAndSetArrayItem(this.field, "field");
			var_params.InitAndSetArrayItem(CommonFunctions.fileAttrHash((XVar)(keylink), (XVar)(MVCFunctions.strlen_bin((XVar)(data[this.field])))), "hash");
			url = XVar.Clone(new XVar("image", MVCFunctions.GetTableLink(new XVar("file"), new XVar(""), (XVar)(MVCFunctions.Concat(CommonFunctions.prepareUrlQuery((XVar)(var_params)), keylink))), "filename", fileName));
			thumbField = XVar.Clone(pSet.getStrThumbnail((XVar)(this.field)));
			if((XVar)(thumbField)  && (XVar)(this.showThumbnails))
			{
				var_params.InitAndSetArrayItem(1, "thumbnail");
				var_params.InitAndSetArrayItem(CommonFunctions.fileAttrHash((XVar)(keylink), (XVar)(MVCFunctions.strlen_bin((XVar)(data[thumbField])))), "hash");
				url.InitAndSetArrayItem(MVCFunctions.GetTableLink(new XVar("file"), new XVar(""), (XVar)(MVCFunctions.Concat(CommonFunctions.prepareUrlQuery((XVar)(var_params)), keylink))), "thumbnail");
			}
			fileURLs.InitAndSetArrayItem(url, null);
			return fileURLs;
		}
		public override XVar getTextValue(dynamic data)
		{
			dynamic fileNameField = null;
			if(XVar.Pack(!(XVar)(MVCFunctions.strlen((XVar)(data[this.field])))))
			{
				return "";
			}
			fileNameField = XVar.Clone(this.container.pSet.getFilenameField((XVar)(this.field)));
			if((XVar)(fileNameField)  && (XVar)(data[fileNameField]))
			{
				return data[fileNameField];
			}
			return "<<Image>>";
		}
		public override XVar getExportValue(dynamic data, dynamic _param_keylink = null, dynamic _param_html = null)
		{
			#region default values
			if(_param_keylink as Object == null) _param_keylink = new XVar("");
			if(_param_html as Object == null) _param_html = new XVar(false);
			#endregion

			#region pass-by-value parameters
			dynamic keylink = XVar.Clone(_param_keylink);
			dynamic html = XVar.Clone(_param_html);
			#endregion

			return "LONG BINARY DATA - CANNOT BE DISPLAYED";
		}
		protected override XVar getSmallThumbnailStyle(dynamic _param_imageSrc = null, dynamic _param_hasThumbnail = null)
		{
			#region default values
			if(_param_imageSrc as Object == null) _param_imageSrc = new XVar(false);
			if(_param_hasThumbnail as Object == null) _param_hasThumbnail = new XVar(true);
			#endregion

			#region pass-by-value parameters
			dynamic imageSrc = XVar.Clone(_param_imageSrc);
			dynamic hasThumbnail = XVar.Clone(_param_hasThumbnail);
			#endregion

			dynamic styles = XVar.Array();
			styles = XVar.Clone(XVar.Array());
			if(XVar.Pack(imageSrc))
			{
				imageSrc = XVar.Clone(MVCFunctions.str_replace(new XVar("="), new XVar("&#61;"), (XVar)(imageSrc)));
				styles.InitAndSetArrayItem(MVCFunctions.Concat(" background-image: url(", imageSrc, ");"), null);
				if(XVar.Pack(!(XVar)(hasThumbnail)))
				{
					styles.InitAndSetArrayItem(MVCFunctions.Concat(" background-size: ", this.thumbWidth, "px ", this.thumbHeight, "px ;"), null);
				}
			}
			if(XVar.Pack(this.thumbWidth))
			{
				styles.InitAndSetArrayItem(MVCFunctions.Concat(" width: ", this.thumbWidth, "px;"), null);
			}
			if(XVar.Pack(this.thumbHeight))
			{
				styles.InitAndSetArrayItem(MVCFunctions.Concat(" height: ", this.thumbHeight, "px"), null);
			}
			return MVCFunctions.Concat(" style=\"", MVCFunctions.implode(new XVar(""), (XVar)(styles)), "\"");
		}
	}
}
