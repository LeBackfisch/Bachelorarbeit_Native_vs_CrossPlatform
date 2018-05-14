using System;
using System.Threading;
using System.Diagnostics;
using UIKit;
using Xamarin.iOS_BAC_.Services;

namespace Xamarin.iOS_BAC_.Views
{
    public partial class BackgroundThreadViewController : UIViewController
    {
        private readonly PrimeService _primeService;
		private Stopwatch stopwatch = new Stopwatch();
        public BackgroundThreadViewController (IntPtr handle) : base (handle)
        {
            _primeService = new PrimeService();
        }

        partial void UIButton6078_TouchUpInside(UIButton sender)
        {
            stopwatch.Start();
            StartThread();
            
        }

        private void StartThread()
        {
            new Thread(() =>
            {
                var res = _primeService.GetPrime();

                this.InvokeOnMainThread(() =>
                {
                    this.ResultLabel.Text = res.ToString();
					Console.WriteLine("BackgroundThread: " + stopwatch.Elapsed);
                });
            }).Start();
        }
    }
}