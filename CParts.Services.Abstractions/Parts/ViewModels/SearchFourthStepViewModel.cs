using System.Collections.Generic;

namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class SearchFourthStepViewModel
    {
        public ICollection<CarType> Types { get; set; }
    }

    public class CarType
    {
        public string BodyType { get; set; }
        public int KwPower { get; set; }
        public int HpPower { get; set; }
        public double EngineVolume { get; set; }
        public string FuelType { get; set; }
        public string FullEngineDescription { get; set; }
        public string EngineCode { get; set; }
    }
}