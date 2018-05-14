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
    [Register ("StarshipsViewController")]
    partial class StarshipsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GetStarshipsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView StarshipTableView { get; set; }

        [Action ("GetStarshipsButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GetStarshipsButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (GetStarshipsButton != null) {
                GetStarshipsButton.Dispose ();
                GetStarshipsButton = null;
            }

            if (StarshipTableView != null) {
                StarshipTableView.Dispose ();
                StarshipTableView = null;
            }
        }
    }
}