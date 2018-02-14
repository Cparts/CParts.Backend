using CParts.Domain.Core.Model.Parts.Links;

namespace CParts.Domain.Core.Model.Parts
{
    public partial class LaCriteria
    {
        /// <summary>
        /// LAC_LA_ID
        /// </summary>
        public int LinkArtId { get; set; }
        
        public LinkArt LinkArt { get; set; }

        /// <summary>
        /// LAC_SORT
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// LAC_CRI_ID
        /// </summary>
        public short CriteriaId { get; set; }
        
        public Criteria Criteria { get; set; }

        /// <summary>
        /// LAC_VALUE
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// LAC_KV_DES_ID
        /// </summary>
        public int? KvDesignationId { get; set; }
        
        public GeneralDesignation Designation { get; set; }

        /// <summary>
        /// LAC_DISPLAY
        /// </summary>
        public short? Display { get; set; }
    }
}