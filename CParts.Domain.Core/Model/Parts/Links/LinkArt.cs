using System.Collections.Generic;

namespace CParts.Domain.Core.Model.Parts.Links
{
    public partial class LinkArt
    {
        /// <summary>
        /// LA_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// LA_ART_ID
        /// </summary>
        public int ArticleId { get; set; }
        
        public Article Article { get; set; }

        //TODO: Investigate LA_GA_ID
        /// <summary>
        /// LA_GA_ID
        /// </summary>
        public int GaId { get; set; }
        
        /// <summary>
        /// LA_SORT
        /// </summary>
        public int Sort { get; set; }
    }
}