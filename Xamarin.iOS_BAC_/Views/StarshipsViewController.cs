using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Diagnostics;
using UIKit;
using Xamarin.iOS_BAC_.Models;
using Xamarin.iOS_BAC_.Services;

namespace Xamarin.iOS_BAC_.Views
{
    public partial class StarshipsViewController : UIViewController
    {
        List<StarshipModel> _starships = new List<StarshipModel>();
        private readonly StarshipService _starshipService;
		Stopwatch stop = new Stopwatch();
        public StarshipsViewController (IntPtr handle) : base (handle)
        {
           
            _starshipService = new StarshipService();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            StarshipTableView.Source = new StarshipTableView(_starships);

        }

        partial void GetStarshipsButton_TouchUpInside(UIButton sender)
        {
            
            stop.Start();
            bool check = NetworkInterface.GetIsNetworkAvailable();

            if (check)
            {
                Task.Run(async () =>
                {
                    await UpdateData();
                });
            }
            else
            {
                return;
            }
            
        }

        private async Task UpdateData()
        {
            DataModel data = await _starshipService.GetStarshipModels();
            _starships = data.results;           
            this.InvokeOnMainThread(() =>
            {
                StarshipTableView.Source = new StarshipTableView(_starships);
                StarshipTableView.RowHeight = UITableView.AutomaticDimension;
                StarshipTableView.EstimatedRowHeight = 40f;
                StarshipTableView.ReloadData();
				Debug.WriteLine("StarshipList: " + stop.Elapsed);
            });
            
        }
    }
}