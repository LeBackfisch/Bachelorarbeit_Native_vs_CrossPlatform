using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using ImageSource = Xamarin.Forms.ImageSource;
using Plugin.ImageEdit;
using Xamarin.Forms;
using Xamarin.Forms_BAC.Models;

namespace Xamarin.Forms_BAC.ViewModels
{
    public class EditPictureViewModel : INotifyPropertyChanged
    {
        private ImageSource _imageSource;

        public ImageSource Picture
        {
            get => _imageSource;
            set
            {

                _imageSource = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));

            }
        }

        public Byte[] Bytes { get; set; }
        public Byte[] UsedBytes { get; set; }

        public ImageSource OriginalSource { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task UpdateImage(bool clicked)
        {
            if (clicked)
            {
                Picture = OriginalSource;
            }
            else
            {
                OriginalSource = ImageSource.FromStream(() => { return new MemoryStream(Bytes); });
                var image = await CrossImageEdit.Current.CreateImageAsync(Bytes);
                var data = image.ToMonochrome().ToJpeg(100);
                UsedBytes = data;
                Picture = ImageSource.FromStream(() => new MemoryStream(data));
            }

        }

      
        public async Task SaveImage()
        {

            if (UsedBytes != null)
            {
                DependencyService.Get<IPicture>().SavePictureToDisk("Image", UsedBytes);
            }
            else
            {
                DependencyService.Get<IPicture>().SavePictureToDisk("Image", Bytes);
            }
          
        }
    }
}
