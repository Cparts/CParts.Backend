namespace CParts.Domain.Core.Model
{
    public partial class LinkTypEng
    {
        /// <summary>
        /// LTE_TYP_ID
        /// </summary>
        public int LteTypId { get; set; }

        /// <summary>
        /// LTE_NR
        /// </summary>
        public short LteNr { get; set; }

        /// <summary>
        /// LTE_ENG_ID
        /// </summary>
        public int LteEngId { get; set; }

        /// <summary>
        /// LTE_PCON_START
        /// </summary>
        public int? LtePconStart { get; set; }

        /// <summary>
        /// LTE_PCON_END
        /// </summary>
        public int? LtePconEnd { get; set; }
    }
}