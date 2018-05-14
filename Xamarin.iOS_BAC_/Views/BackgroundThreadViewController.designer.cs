// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Xamarin.iOS_BAC_.Views
{
    [Register ("BackgroundThreadViewController")]
    partial class BackgroundThreadViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        [Action ("UIButton6078_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton6078_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }
        }
    }
}