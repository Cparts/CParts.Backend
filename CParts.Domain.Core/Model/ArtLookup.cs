namespace CParts.Domain.Core.Model
{
    public partial class ArtLookup
    {
        /// Like searchbar
        /// <summary>
        /// ARL_ART_ID
        /// </summary>
        public int ArlArtId { get; set; }

        /// <summary>
        /// ARL_SEARCH_NUMBER
        /// </summary>
        public string CatalogueCode { get; set; }

        /// <summary>
        /// ARL_KIND
        /// </summary>
        public byte[] Kind { get; set; }

        /// <summary>
        /// ARL_BRA_ID
        /// </summary>
        public short BrandId { get; set; }

        /// <summary>
        /// ARL_DISPLAY_NR
        /// </summary>
        public string ArlDisplayNr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short ArlDisplay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short ArlBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short ArlSort { get; set; }
    }
}