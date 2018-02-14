using Newtonsoft.Json;

namespace CParts.Services.Abstractions.ViewModels
{
    public class SpecificationViewModel
    {
        public string Description { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string UnitDescription { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string KvDescription { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Value { get; set; }
        
    }
}