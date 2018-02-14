namespace CParts.Domain.Core.Model.Parts
{
    public partial class Brand
    {
        /// <summary>
        /// BRA_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// BRA_MFC_CODE
        /// </summary>
        public string MfcCode { get; set; }

        /// <summary>
        /// BRA_BRAND
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// BRA_MF_NR
        /// </summary>
        public int? MfNr { get; set; }
    }
}