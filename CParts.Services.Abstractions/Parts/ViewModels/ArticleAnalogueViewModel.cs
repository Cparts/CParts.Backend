using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class ArticleAnalogueViewModel
    {
        public int ArticleId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Kind Kind { get; set; } 
        public bool IsBrand { get; set; }
        public int BrandOrSupplierId { get; set; }
        public string BrandOrSupplier { get; set; }
        public string DisplayNumber { get; set; }
    }

    public enum Kind
    {
        Market = 2,
        Original = 3,
        NonOriginal = 4
    }
}