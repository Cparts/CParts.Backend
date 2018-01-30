namespace CParts.Domain.Core.Model
{
    public partial class Language
    {
        /// <summary>
        /// LNG_ID
        /// </summary>
        public short LngId { get; set; }

        /// <summary>
        /// LNG_DES_ID
        /// </summary>
        public int? LngDesId { get; set; }

        /// <summary>
        /// LNG_ISO_2
        /// </summary>
        public string LngIso2 { get; set; }

        /// <summary>
        /// LNG_CODEPAGE
        /// </summary>
        public string LngCodepage { get; set; }
    }
}