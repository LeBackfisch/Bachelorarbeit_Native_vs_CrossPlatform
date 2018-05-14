using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.Forms_BAC.Droid;
using Xamarin.Forms_BAC.Models;


[assembly: Xamarin.Forms.Dependency(typeof(PictureiOS))]

namespace Xamarin.Forms_BAC.Droid
{
    class PictureiOS: IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var image = new UIImage(NSData.FromArray(imageData));
            image.SaveToPhotosAlbum((imagefile, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine(error);
                }
            });
        }
    }
}