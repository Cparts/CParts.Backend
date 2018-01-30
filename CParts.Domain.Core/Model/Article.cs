namespace CParts.Domain.Core.Model
{
    public partial class Article
    {
        /// <summary>
        /// ART_ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ART_ARTICLE_NR
        /// </summary>
        public string ArtArticleNr { get; set; }
        /// <summary>
        /// ART_SUP_ID
        /// </summary>
        public short? ArtSupId { get; set; }
        /// <summary>
        /// ART_DES_ID
        /// </summary>
        public int? ArtDesId { get; set; }
        /// <summary>
        /// ART_COMPLETE_DES_ID
        /// </summary>
        public int? ArtCompleteDesId { get; set; }
        /// <summary>
        /// ART_PACK_SELFSERVICE
        /// </summary>
        public short? ArtPackSelfservice { get; set; }
        /// <summary>
        /// ART_MATERIAL_MARK
        /// </summary>
        public short? ArtMaterialMark { get; set; }
        /// <summary>
        /// ART_REPLACEMENT
        /// </summary>
        public short? ArtReplacement { get; set; }
        /// <summary>
        /// ART_ACCESSORY
        /// </summary>
        public short? ArtAccessory { get; set; }
        /// <summary>
        /// ART_BATCH_SIZE_1
        /// </summary>
        public int? ArtBatchSize1 { get; set; }
        /// <summary>
        /// ART_BATCH_SIZE_2
        /// </summary>
        public int? ArtBatchSize2 { get; set; }
    }
}
