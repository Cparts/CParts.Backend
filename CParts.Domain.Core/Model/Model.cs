namespace CParts.Domain.Core.Model
{
    public partial class Model
    {
        /// <summary>
        /// MOD_ID
        /// </summary>
        public int ModId { get; set; }

        /// <summary>
        /// MOD_MFA_ID
        /// </summary>
        public short? ModMfaId { get; set; }

        /// <summary>
        /// MOD_CDS_ID
        /// </summary>
        public int? ModCdsId { get; set; }

        /// <summary>
        /// MOD_PCON_START
        /// </summary>
        public int? ModPconStart { get; set; }

        /// <summary>
        /// MOD_PCON_END
        /// </summary>
        public int? ModPconEnd { get; set; }

        /// <summary>
        /// MOD_PC
        /// </summary>
        public short? ModPc { get; set; }

        /// <summary>
        /// MOD_CV
        /// </summary>
        public short? ModCv { get; set; }

        /// <summary>
        /// MOD_AXL
        /// </summary>
        public short? ModAxl { get; set; }
    }
}