namespace CParts.Domain.Core.Model.Parts
{
    public partial class ArticleCriteria
    {
        /// <summary>
        /// ACR_ART_ID
        /// </summary>
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        //TODO: Investigate ACR_GA_ID
        /// <summary>
        /// ACR_GA_ID
        /// </summary>
        public int AcrGaId { get; set; }

        /// <summary>
        /// ACR_SORT
        /// </summary>
        public short Sort { get; set; }

        /// <summary>
        /// ACR_CRI_ID
        /// </summary>
        public short CriteriaId { get; set; }

        public Criteria Criteria { get; set; }

        /// <summary>
        /// ACR_VALUE
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ACR_KV_DES_ID
        /// </summary>
        public int? KvDesignationId { get; set; }

        public GeneralDesignation KvDesignation { get; set; }

        /// <summary>
        /// ACR_DISPLAY
        /// </summary>
        public short? Display { get; set; }
        
    }
}