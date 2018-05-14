using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms_BAC.Data;
using Xamarin.Forms_BAC.Model;
using Xamarin.Forms_BAC.Models;

namespace Xamarin.Forms_BAC.ViewModels
{
    public class StarshipViewModel: INotifyPropertyChanged
    {
        public DataModel Data { get; set; }

        private List<StarshipModel> _starshipModels;

        public List<StarshipModel> Starships
        {
            get => _starshipModels;
            set
            {
                if (_starshipModels != value)
                {
                    _starshipModels = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Starships"));
                }
            }
        }

        public async Task UpdateData()
        {
            Data = await StarshipService.GetStarshipData();
            _starshipModels = Data.results;
            //Debug.WriteLine(Starships.Count);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}