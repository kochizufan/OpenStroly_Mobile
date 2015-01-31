// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace NLuaSample
{
	[Register ("NLuaSampleViewController")]
	partial class NLuaSampleViewController
	{
		[Outlet]
		public UIKit.UITextView codeView { get; set; }

		[Outlet]
		public UIKit.UITextView outputView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (codeView != null) {
				codeView.Dispose ();
				codeView = null;
			}

			if (outputView != null) {
				outputView.Dispose ();
				outputView = null;
			}
		}
	}
}
