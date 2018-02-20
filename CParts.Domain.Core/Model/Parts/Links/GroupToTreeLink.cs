namespace CParts.Domain.Core.Model.Parts.Links
{
    public partial class GroupToTreeLink
    {
        /// <summary>
        /// LGS_STR_ID
        /// </summary>
        public int SearchTreeId { get; set; }
        
        public SearchTree SearchTree { get; set; }

        //TODO: Investigate LGS_GA_ID
        /// <summary>
        /// LGS_GA_ID
        /// </summary>
        public int GaId { get; set; }
    }
}