namespace CParts.Domain.Core.Model
{
    public partial class Graphic
    {
        /// <summary>
        /// GRA_SUP_ID
        /// </summary>
        public short? GraSupId { get; set; }

        /// <summary>
        /// GRA_ID
        /// </summary>
        public string GraId { get; set; }

        /// <summary>
        /// GRA_DOC_TYPE
        /// </summary>
        public sbyte? GraDocType { get; set; }

        /// <summary>
        /// GRA_LNG_ID
        /// </summary>
        public short GraLngId { get; set; }

        /// <summary>
        /// GRA_GRD_ID
        /// </summary>
        public string GraGrdId { get; set; }

        /// <summary>
        /// GRA_TYPE
        /// </summary>
        public short? GraType { get; set; }

        /// <summary>
        /// GRA_NORM
        /// </summary>
        public string GraNorm { get; set; }

        /// <summary>
        /// GRA_SUPPLIER_NR
        /// </summary>
        public short? GraSupplierNr { get; set; }

        /// <summary>
        /// GRA_TAB_NR
        /// </summary>
        public short? GraTabNr { get; set; }

        /// <summary>
        /// GRA_DES_ID
        /// </summary>
        public int? GraDesId { get; set; }
    }
}