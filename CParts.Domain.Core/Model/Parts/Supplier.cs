namespace CParts.Domain.Core.Model.Parts
{
    public partial class Supplier
    {
        /// <summary>
        /// SUP_ID
        /// </summary>
        public short Id { get; set; }
        
        /// <summary>
        /// SUP_BRAND
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// SUP_SUPPLIER_NR
        /// </summary>
        public short? Number { get; set; }
        
        /// <summary>
        /// SUP_COU_ID
        /// </summary>
        public short? CountryId { get; set; }
        
        public Country Country { get; set; }
        
        /// <summary>
        /// SUP_IS_HESS
        /// </summary>
        public short? IsHess { get; set; }
    }
}
