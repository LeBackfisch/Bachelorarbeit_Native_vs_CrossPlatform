using System;
using System.Diagnostics;
using CoreImage;
using Foundation;
using Photos;
using UIKit;

namespace Xamarin.iOS_BAC_.Views
{
    public partial class EditPictureViewController : UIViewController
    {
        private UIImagePickerController imagePickerForCamera;
        private UIImage originalImage;
        private bool clicked = false;
        public EditPictureViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EditPictureButton.Enabled = false;
            SavePictureButton.Enabled = false;
        }

        private void GetPicture()
        {
            imagePickerForCamera = new UIImagePickerController();
            imagePickerForCamera.PrefersStatusBarHidden();
            imagePickerForCamera.SourceType = UIImagePickerControllerSourceType.Camera;
           

            imagePickerForCamera.FinishedPickingMedia += Handle_FinishedPickingMedia;
            imagePickerForCamera.Canceled += Handle_Canceled;
            PresentViewController(imagePickerForCamera, animated: true, completionHandler: null);
        }

        public void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e){
            bool isImage = false;
            switch (e.Info[UIImagePickerController.MediaType].ToString()){
                case "public.image":  
                    isImage = true;  
                    break;  
                case "public.video":  
                    break;  
            }
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
            if (referenceURL != null)
                Console.WriteLine("Url:" + referenceURL.ToString());

            // if it was an image, get the other image info
            if (isImage)
            {
                // get the original image
                UIImage originalImg = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImg != null)
                {
                    PictureView.Image = originalImg;
                    originalImage = originalImg;
                }
            }
            else
            { 
                NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
                if (mediaURL != null)
                {
                    Console.WriteLine(mediaURL.ToString());
                }
            }
            imagePickerForCamera.DismissModalViewController(true);
            EditPictureButton.Enabled = true;
            SavePictureButton.Enabled = true;
            clicked = false;
        }

        public void Handle_Canceled(object sender, EventArgs e){
            imagePickerForCamera.DismissModalViewController(true);
        }

        private void EditPicture()
        {
            if (clicked)
            {
                PictureView.Image = originalImage;
                clicked = false;
            }
            else
            {
                var uiimage = PictureView.Image;
                originalImage = uiimage;
                var image = new CIImage(uiimage.CGImage);
                var originialOrientation = PictureView.Image.Orientation;

                var filter = new CIMinimumComponent()
                {
                    Image = image
                };

                var output = filter.OutputImage;

                var context = CIContext.FromOptions(null);
                var cgimage = context.CreateCGImage(output, output.Extent);

                PictureView.Image = UIImage.FromImage(cgimage, 1.0f, originialOrientation);
                clicked = true;
            }

        }

        private void SavePicture()
        {
            
            var image = PictureView.Image;

            PHPhotoLibrary.RequestAuthorization(status =>
            {
                switch (status)
                {
                    case PHAuthorizationStatus.Denied:
                    case PHAuthorizationStatus.Restricted:

                        return;
                    case PHAuthorizationStatus.Authorized:
                        break;
                }
            });

            image.SaveToPhotosAlbum((UIimage, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("error:" + error);
                }
                else
                {
                    var o = UIimage as UIImage;
                }
            });
        }

        partial void TakePictureButton_TouchUpInside(UIButton sender)
        {
            GetPicture();
        }

        partial void EditPictureButton_TouchUpInside(UIButton sender)
        {
            var stop = new Stopwatch();
            stop.Start();
            EditPicture();
            Debug.WriteLine("Edit Picture: " + stop.Elapsed);
        }

        partial void SavePictureButton_TouchUpInside(UIButton sender)
        {
            var stop = new Stopwatch();
            stop.Start();
            SavePicture();
            Debug.WriteLine("Save Picture: " + stop.Elapsed);

        }
    }
}