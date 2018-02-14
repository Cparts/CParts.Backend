namespace CParts.Domain.Core.Model.Parts
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
        public string Number { get; set; }

        /// <summary>
        /// ART_SUP_ID
        /// </summary>
        public short? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        /// <summary>
        /// ART_DES_ID
        /// </summary>
        public int? DesignationId { get; set; }

        public GeneralDesignation Designation { get; set; }

        /// <summary>
        /// ART_COMPLETE_DES_ID
        /// </summary>
        public int? CompleteDesignationId { get; set; }
        
        public GeneralDesignation CompleteDesignation { get; set; }

        /// <summary>
        /// ART_PACK_SELFSERVICE
        /// </summary>
        public short? PackSelfservice { get; set; }

        /// <summary>
        /// ART_MATERIAL_MARK
        /// </summary>
        public short? MaterialMark { get; set; }

        /// <summary>
        /// ART_REPLACEMENT
        /// </summary>
        public short? Replacement { get; set; }

        /// <summary>
        /// ART_ACCESSORY
        /// </summary>
        public short? Accessory { get; set; }

        /// <summary>
        /// ART_BATCH_SIZE_1
        /// </summary>
        public int? BatchSize1 { get; set; }

        /// <summary>
        /// ART_BATCH_SIZE_2
        /// </summary>
        public int? BatchSize2 { get; set; }

        //public IEnumerable<ArticleLookup> Lookups { get; set; }
        //public ICollection<ArticleCriteria> Criterias { get; set; }
//        public override int GetHashCode()
//        {
//            return 47 * 23 + base.GetHashCode() + Id.GetHashCode() + Number.GetHashCode();
//        }
    }
}