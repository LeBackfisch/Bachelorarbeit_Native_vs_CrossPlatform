using Foundation;
using System;
using System.Globalization;
using UIKit;
using Xamarin.iOS_BAC_.Models;

namespace Xamarin.iOS_BAC_
{
    public partial class StarshipCell : UITableViewCell
    {
        public StarshipCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(StarshipModel starship)
        {
            NameLabel.Text = "Name: "+starship.Name;
            LengthLabel.Text = "Length: "+starship.Length.ToString(CultureInfo.InvariantCulture);
        }
    }
}