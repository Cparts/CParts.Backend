using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.QueryModels
{
    public class AnalogueQueryArtLookup
    {
        public int ArticleId { get; set; }
        public int Kind { get; set; }
        public string DisplayNumber { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}