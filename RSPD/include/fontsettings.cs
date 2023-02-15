
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
	public static partial class FontSettings_class
	{
		static public XVar settings()
		{
			return new XVar( 0, new XVar( "name", "Roboto",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "Roboto-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "Roboto-Bold.ttf",
"italic", false ),
2, new XVar( "weight", 400,
"filename", "Roboto-Italic.ttf",
"italic", true ),
3, new XVar( "weight", 700,
"filename", "Roboto-BoldItalic.ttf",
"italic", true ) ) ),
1, new XVar( "name", "Open Sans",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "OpenSans-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "OpenSans-Bold.ttf",
"italic", false ),
2, new XVar( "weight", 400,
"filename", "OpenSans-Italic.ttf",
"italic", true ),
3, new XVar( "weight", 700,
"filename", "OpenSans-BoldItalic.ttf",
"italic", true ) ) ),
2, new XVar( "name", "Roboto Mono",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "RobotoMono-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "RobotoMono-Bold.ttf",
"italic", false ),
2, new XVar( "weight", 400,
"filename", "RobotoMono-Italic.ttf",
"italic", true ),
3, new XVar( "weight", 700,
"filename", "RobotoMono-BoldItalic.ttf",
"italic", true ) ) ),
3, new XVar( "name", "Roboto Slab",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "RobotoSlab-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "RobotoSlab-Bold.ttf",
"italic", false ) ) ),
4, new XVar( "name", "Inconsolata",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "Inconsolata-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "Inconsolata-Bold.ttf",
"italic", false ) ) ),
5, new XVar( "name", "Merriweather",
"type", 0,
"pdf", true,
"standard", true,
"files", new XVar( 0, new XVar( "weight", 400,
"filename", "Merriweather-Regular.ttf",
"italic", false ),
1, new XVar( "weight", 700,
"filename", "Merriweather-Bold.ttf",
"italic", false ),
2, new XVar( "weight", 400,
"filename", "Merriweather-Italic.ttf",
"italic", true ),
3, new XVar( "weight", 700,
"filename", "Merriweather-BoldItalic.ttf",
"italic", true ) ) ) );
		}
	}
}
			