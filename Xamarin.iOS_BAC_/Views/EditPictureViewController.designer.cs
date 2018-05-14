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
    [Register ("EditPictureViewController")]
    partial class EditPictureViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EditPictureButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PictureView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SavePictureButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TakePictureButton { get; set; }

        [Action ("EditPictureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EditPictureButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SavePictureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SavePictureButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("TakePictureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TakePictureButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (EditPictureButton != null) {
                EditPictureButton.Dispose ();
                EditPictureButton = null;
            }

            if (PictureView != null) {
                PictureView.Dispose ();
                PictureView = null;
            }

            if (SavePictureButton != null) {
                SavePictureButton.Dispose ();
                SavePictureButton = null;
            }

            if (TakePictureButton != null) {
                TakePictureButton.Dispose ();
                TakePictureButton = null;
            }
        }
    }
}