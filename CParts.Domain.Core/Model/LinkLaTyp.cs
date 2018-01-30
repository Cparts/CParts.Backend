namespace CParts.Domain.Core.Model
{
    public partial class LinkLaTyp
    {
        /// <summary>
        /// LAT_TYP_ID
        /// </summary>
        public int LatTypId { get; set; }

        /// <summary>
        /// LAT_LA_ID
        /// </summary>
        public int LatLaId { get; set; }

        /// <summary>
        /// LAT_GA_ID
        /// </summary>
        public int LatGaId { get; set; }

        /// <summary>
        /// LAT_SUP_ID
        /// </summary>
        public short? LatSupId { get; set; }

        /// <summary>
        /// LAT_SORT
        /// </summary>
        public int LatSort { get; set; }
    }
}