namespace CParts.Domain.Core.Model
{
    public partial class SupplierLogo
    {
        /// <summary>
        /// SLO_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// SLO_SUP_ID
        /// </summary>
        public short SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        /// <summary>
        /// SLO_LNG_ID
        /// </summary>
        public short LanguageId { get; set; }

        public Language Language { get; set; }
    }
}