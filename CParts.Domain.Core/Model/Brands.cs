namespace CParts.Domain.Core.Model
{
    public partial class Brands
    {
        /// <summary>
        /// BRA_ID
        /// </summary>
        public short BraId { get; set; }

        /// <summary>
        /// BRA_MFC_CODE
        /// </summary>
        public string BraMfcCode { get; set; }

        /// <summary>
        /// BRA_BRAND
        /// </summary>
        public string BraBrand { get; set; }

        /// <summary>
        /// BRA_MF_NR
        /// </summary>
        public int? BraMfNr { get; set; }
    }
}