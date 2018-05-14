using Android.Content;
using Java.IO;
using Xamarin.Forms_BAC.Droid;
using Xamarin.Forms_BAC.Models;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_Droid))]

namespace Xamarin.Forms_BAC.Droid
{
    class Picture_Droid: IPicture
    {
        internal static MainActivity Instance { get; private set; }
        public void SavePictureToDisk(string filename, byte[] imageData)
        {
            var dir = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;

            string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
                
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}