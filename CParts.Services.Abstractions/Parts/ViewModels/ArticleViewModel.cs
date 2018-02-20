using System.Collections.Generic;
using Newtonsoft.Json;

namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string DisplayNumber { get; set; }
        public string Brand { get; set; }
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string Description { get; set; }
        public string CompleteDescription { get; set; }
        public ICollection<SpecificationViewModel> Specs { get; set; }
        public ICollection<OriginalArticleViewModel> Originals { get; set; }
        
    }
}