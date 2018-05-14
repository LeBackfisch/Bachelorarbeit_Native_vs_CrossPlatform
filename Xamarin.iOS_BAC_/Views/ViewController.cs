using System;
using System.Diagnostics;
using UIKit;

namespace Xamarin.iOS_BAC_.Views
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		public override void ViewDidAppear(bool animated)
		{
            Console.WriteLine("Startup: "+Application.StartUpTimer.ElapsedMilliseconds.ToString());
			base.ViewDidAppear(animated);
		}

	}
}