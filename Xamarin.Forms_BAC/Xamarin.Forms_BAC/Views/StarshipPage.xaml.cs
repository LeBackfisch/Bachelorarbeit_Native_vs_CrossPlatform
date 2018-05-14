using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_BAC.ViewModels;

namespace Xamarin.Forms_BAC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StarshipPage : ContentPage
	{
	    private StarshipViewModel vm;
		public StarshipPage ()
		{

            InitializeComponent ();
            vm = new StarshipViewModel();
		    StarshipList.ItemsSource = vm.Starships;
		}

	    async void GetStarships(object sender, EventArgs e)
	    {
	        var stop = new Stopwatch();
	        stop.Start();
            await vm.UpdateData();
	        StarshipList.ItemsSource = vm.Starships;
	        stop.Stop();
	        Console.WriteLine("Elapsed Time: " + stop.Elapsed);

        }
	}
}