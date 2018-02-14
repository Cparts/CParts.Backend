namespace CParts.Domain.Core.Model.Parts
{
    public partial class ArticleInfo
    {
        /// <summary>
        /// AIN_ART_ID
        /// </summary>
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        //TODO: Investigate AIN_GA_ID
        /// <summary>
        /// AIN_GA_ID
        /// </summary>
        public int GaId { get; set; }

        /// <summary>
        /// AIN_SORT
        /// </summary>
        public short Sort { get; set; }

        /// <summary>
        /// AIN_KV_TYPE
        /// </summary>
        public string KvType { get; set; }

        /// <summary>
        /// AIN_DISPLAY
        /// </summary>
        public short AinDisplay { get; set; }

        //TODO: Investigate AIN_TMO_ID
        /// <summary>
        /// AIN_TMO_ID
        /// </summary>
        public int TextModuleId { get; set; }
        
        public TextModule TextModule { get; set; }
    }
}