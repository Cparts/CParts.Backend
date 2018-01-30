namespace CParts.Domain.Core.Model
{
    public partial class Country
    {
        /// <summary>
        /// COU_ID
        /// </summary>
        public short CouId { get; set; }

        /// <summary>
        /// COU_CC
        /// </summary>
        public string CouCc { get; set; }

        /// <summary>
        /// COU_DES_ID
        /// </summary>
        public int? CouDesId { get; set; }

        /// <summary>
        /// COU_CURRENCY_CODE
        /// </summary>
        public string CouCurrencyCode { get; set; }

        /// <summary>
        /// COU_ISO_2
        /// </summary>
        public string CouIso2 { get; set; }

        /// <summary>
        /// COU_IS_GROUP
        /// </summary>
        public short CouIsGroup { get; set; }
    }
}