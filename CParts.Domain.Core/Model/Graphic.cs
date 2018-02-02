namespace CParts.Domain.Core.Model
{
    public partial class Graphic
    {
        /// <summary>
        /// GRA_SUP_ID
        /// </summary>
        public short? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        /// <summary>
        /// GRA_ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// GRA_DOC_TYPE
        /// </summary>
        public sbyte? GraDocType { get; set; }

        /// <summary>
        /// GRA_LNG_ID
        /// </summary>
        public short LanguageId { get; set; }

        public Language Language { get; set; }

        //TODO: Investigate GRA_GRD_ID
        /// <summary>
        /// GRA_GRD_ID
        /// </summary>
        public string GraGrdId { get; set; }

        /// <summary>
        /// GRA_TYPE
        /// </summary>
        public short? Type { get; set; }

        /// <summary>
        /// GRA_NORM
        /// </summary>
        public string Norm { get; set; }

        /// <summary>
        /// GRA_SUPPLIER_NR
        /// </summary>
        public short? SupplierNumber { get; set; }

        /// <summary>
        /// GRA_TAB_NR
        /// </summary>
        public short? TabNr { get; set; }

        /// <summary>
        /// GRA_DES_ID
        /// </summary>
        public int? DesignationId { get; set; }

        public Designation Designation { get; set; }
    }
}