// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ZXingObjC.iOS.Binding.Test
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel decodedLabel { get; set; }

		[Outlet]
		UIKit.UIView scanRectView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (scanRectView != null) {
				scanRectView.Dispose ();
				scanRectView = null;
			}

			if (decodedLabel != null) {
				decodedLabel.Dispose ();
				decodedLabel = null;
			}
		}
	}
}