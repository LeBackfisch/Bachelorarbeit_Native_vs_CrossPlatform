using Newtonsoft.Json;

namespace Xamarin.Forms_BAC.Model
{
    public class StarshipModel
    {
        public StarshipModel(string name, string model, string manufacturer, double length)
        {
            Name = name;
            Model = model;
            Manufacturer = manufacturer;
            Length = length;
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonProperty("length")]
        public double Length { get; set; }
    }
}
