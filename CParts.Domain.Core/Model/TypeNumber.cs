namespace CParts.Domain.Core.Model
{
    public partial class TypeNumber
    {
        /// <summary>
        /// TYN_TYP_ID
        /// </summary>
        public int TynTypId { get; set; }

        /// <summary>
        /// TYN_SEARCH_TEXT
        /// </summary>
        public string TynSearchText { get; set; }

        /// <summary>
        /// TYN_KIND
        /// </summary>
        public short TynKind { get; set; }

        /// <summary>
        /// TYN_DISPLAY_NR
        /// </summary>
        public string TynDisplayNr { get; set; }

        /// <summary>
        /// TYN_GOP_NR
        /// </summary>
        public string TynGopNr { get; set; }

        /// <summary>
        /// TYN_GOP_START
        /// </summary>
        public int TynGopStart { get; set; }
    }
}