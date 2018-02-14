namespace CParts.Domain.Core.Model.Parts
{
    public partial class Manufacturer
    {
        /// <summary>
        /// MFA_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// MFA_PC_MFC
        /// </summary>
        public short? PcMfc { get; set; }

        /// <summary>
        /// MFA_CV_MFC
        /// </summary>
        public short? CvMfc { get; set; }

        /// <summary>
        /// MFA_AXL_MFC
        /// </summary>
        public short? AxlMfc { get; set; }

        /// <summary>
        /// MFA_ENG_MFC
        /// </summary>
        public short? EngineMfc { get; set; }

        /// <summary>
        /// MFA_ENG_TYP
        /// </summary>
        public short? EngineType { get; set; }

        /// <summary>
        /// MFA_MFC_CODE
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// MFA_BRAND
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// MFA_MF_NR
        /// </summary>
        public int? MfNumber { get; set; }
    }
}