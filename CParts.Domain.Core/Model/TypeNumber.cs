namespace CParts.Domain.Core.Model
{
    public partial class TypeNumber
    {
        /// <summary>
        /// TYN_TYP_ID
        /// </summary>
        public int TypeId { get; set; }
        
        public Type Type { get; set; }

        /// <summary>
        /// TYN_SEARCH_TEXT
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// TYN_KIND
        /// </summary>
        public short Kind { get; set; }

        /// <summary>
        /// TYN_DISPLAY_NR
        /// </summary>
        public string DisplayNumber { get; set; }

        /// <summary>
        /// TYN_GOP_NR
        /// </summary>
        public string GopNumber { get; set; }

        /// <summary>
        /// TYN_GOP_START
        /// </summary>
        public int GopStart { get; set; }
    }
}