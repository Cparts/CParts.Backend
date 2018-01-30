namespace CParts.Domain.Core.Model
{
    public partial class Manufacturer
    {
        /// <summary>
        /// MFA_ID
        /// </summary>
        public short MfaId { get; set; }

        /// <summary>
        /// MFA_PC_MFC
        /// </summary>
        public short? MfaPcMfc { get; set; }

        /// <summary>
        /// MFA_CV_MFC
        /// </summary>
        public short? MfaCvMfc { get; set; }

        /// <summary>
        /// MFA_AXL_MFC
        /// </summary>
        public short? MfaAxlMfc { get; set; }

        /// <summary>
        /// MFA_ENG_MFC
        /// </summary>
        public short? MfaEngMfc { get; set; }

        /// <summary>
        /// MFA_ENG_TYP
        /// </summary>
        public short? MfaEngTyp { get; set; }

        /// <summary>
        /// MFA_MFC_CODE
        /// </summary>
        public string MfaMfcCode { get; set; }

        /// <summary>
        /// MFA_BRAND
        /// </summary>
        public string MfaBrand { get; set; }

        /// <summary>
        /// MFA_MF_NR
        /// </summary>
        public int? MfaMfNr { get; set; }
    }
}