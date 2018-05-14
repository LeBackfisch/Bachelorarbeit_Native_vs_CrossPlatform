using System;
using System.Diagnostics;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_BAC.ViewModels;
using ImageSource = Xamarin.Forms.ImageSource;


namespace Xamarin.Forms_BAC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPicturePage : ContentPage
	{
	    private EditPictureViewModel vm;
	    private bool clicked = false;

        public EditPicturePage ()
		{
			InitializeComponent ();
		    vm = new EditPictureViewModel();
		    EditPictureButton.IsEnabled = false;
		    SavePictureButton.IsEnabled = false;



		}

	    async void EditPicture(object sender, EventArgs e)
        {
            var stop = new Stopwatch();
            stop.Start();
            await vm.UpdateImage(clicked);
	        TakenPicture.Source = vm.Picture;
            if (clicked)
            {
                clicked = false;
            }
            else
            {
                clicked = true;
            }
            stop.Stop();
            Console.WriteLine("Elapsed Time: " + stop.Elapsed);

        }

	    async void SavePicture(object sender, EventArgs e)
	    {
	        var stop = new Stopwatch();
	        stop.Start();
            await vm.SaveImage();
	        stop.Stop();
	        Console.WriteLine("Elapsed Time: " + stop.Elapsed);
        }


        async void TakePicture(object sender, EventArgs e)
	    {
	        await CrossMedia.Current.Initialize();

	        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
	        {
	            await DisplayAlert("No Camera", "No Persmission to use Camera", "OK");
	            return;
	        }

	        var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = false,
                    PhotoSize = PhotoSize.Small
                });
	        var img = ImageSource.FromStream(() =>
	        {
	            using (var memoryStream = new MemoryStream())
	            {
	                file.GetStream().CopyTo(memoryStream);
	                vm.Bytes = memoryStream.ToArray();
	            }
	            var stream = file.GetStream();
	            file.Dispose();
	            return stream;
	        });
	        vm.UsedBytes = null;
	        TakenPicture.Source = img;
	        vm.Picture = img;
	        EditPictureButton.IsEnabled = true;
	        SavePictureButton.IsEnabled = true;


            if (file == null)
	            return;
	    }
    }
}