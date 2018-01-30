namespace CParts.Domain.Core.Model
{
    public partial class Criteria
    {
        /// <summary>
        /// CRI_ID
        /// </summary>
        public short CriId { get; set; }

        /// <summary>
        /// CRI_DES_ID
        /// </summary>
        public int CriDesId { get; set; }

        /// <summary>
        /// CRI_SHORT_DES_ID
        /// </summary>
        public int? CriShortDesId { get; set; }

        /// <summary>
        /// CRI_UNIT_DES_ID
        /// </summary>
        public int? CriUnitDesId { get; set; }

        /// <summary>
        /// CRI_TYPE
        /// </summary>
        public byte[] CriType { get; set; }

        /// <summary>
        /// CRI_KT_ID
        /// </summary>
        public short? CriKtId { get; set; }

        /// <summary>
        /// CRI_IS_INTERVAL
        /// </summary>
        public short? CriIsInterval { get; set; }

        /// <summary>
        /// CRI_SUCCESSOR
        /// </summary>
        public short? CriSuccessor { get; set; }
    }
}