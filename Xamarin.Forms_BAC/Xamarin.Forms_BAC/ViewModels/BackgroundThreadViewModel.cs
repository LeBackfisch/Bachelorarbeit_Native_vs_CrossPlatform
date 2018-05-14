using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms_BAC.Data;

namespace Xamarin.Forms_BAC.ViewModels
{
    public class BackgroundThreadViewModel: INotifyPropertyChanged
    {
        private readonly PrimeService _primeService = new PrimeService();
        private string _value;

        public BackgroundThreadViewModel()
        {
            Value = "Result";
        }

        public Command ValueCommand
        {
            get
            {
                var stop = new Stopwatch();
                stop.Start();
                return new Command(async () =>
                {
                    Value = await GetPrime();
                    stop.Stop();
                    Console.WriteLine("Elapsed Time: " + stop.Elapsed);
                });

            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public async Task<string> GetPrime()
        {
            return await Task.Run(async () => await _primeService.GetPrime());          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
