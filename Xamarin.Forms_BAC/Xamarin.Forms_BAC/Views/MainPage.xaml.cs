using System;
using Xamarin.Forms;
using Xamarin.Forms_BAC.Views;

namespace Xamarin.Forms_BAC
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void navigateToStarships(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StarshipPage());
        }

        async void navigateToEditPicture(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPicturePage());
        }

	    async void navigateToBackgroundThread(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new BackgroundThreadPage());
	    }

    }
}
