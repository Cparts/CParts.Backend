namespace CParts.Domain.Core.Model
{
    public partial class LaCriteria
    {
        /// <summary>
        /// LAC_LA_ID
        /// </summary>
        public int LacLaId { get; set; }

        /// <summary>
        /// LAC_SORT
        /// </summary>
        public int LacSort { get; set; }

        /// <summary>
        /// LAC_CRI_ID
        /// </summary>
        public short LacCriId { get; set; }

        /// <summary>
        /// LAC_VALUE
        /// </summary>
        public string LacValue { get; set; }

        /// <summary>
        /// LAC_KV_DES_ID
        /// </summary>
        public int? LacKvDesId { get; set; }

        /// <summary>
        /// LAC_DISPLAY
        /// </summary>
        public short? LacDisplay { get; set; }
    }
}