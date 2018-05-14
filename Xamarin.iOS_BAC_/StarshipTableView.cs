using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.iOS_BAC_.Models;

namespace Xamarin.iOS_BAC_
{
    public class StarshipTableView : UITableViewSource
    {
        private List<StarshipModel> starshipModels;
        public StarshipTableView(List<StarshipModel> starships)
        {
            starshipModels = starships;
            Console.WriteLine(starshipModels.Count);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (StarshipCell)tableView.DequeueReusableCell("cell_id", indexPath);

            cell.UpdateCell(starshipModels[indexPath.Row]);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return starshipModels.Count;
        }
    }
}
