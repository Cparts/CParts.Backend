namespace CParts.Domain.Core.Model
{
    public partial class Supplier
    {
        public short SupId { get; set; }
        public string SupBrand { get; set; }
        public short? SupSupplierNr { get; set; }
        public short? SupCouId { get; set; }
        public short? SupIsHess { get; set; }
    }
}
