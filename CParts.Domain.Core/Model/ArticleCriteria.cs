namespace CParts.Domain.Core.Model
{
    public partial class ArticleCriteria
    {
        /// <summary>
        /// ACR_ART_ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ACR_GA_ID
        /// </summary>
        public int AcrGaId { get; set; }
        /// <summary>
        /// ACR_SORT
        /// </summary>
        public short AcrSort { get; set; }
        /// <summary>
        /// ACR_CRI_ID
        /// </summary>
        public short AcrCriId { get; set; }
        /// <summary>
        /// ACR_VALUE
        /// </summary>
        public string AcrValue { get; set; }
        /// <summary>
        /// ACR_KV_DES_ID
        /// </summary>
        public int? AcrKvDesId { get; set; }
        /// <summary>
        /// ACR_DISPLAY
        /// </summary>
        public short? AcrDisplay { get; set; }
    }
}
