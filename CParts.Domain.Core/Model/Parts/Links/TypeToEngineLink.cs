namespace CParts.Domain.Core.Model.Parts.Links
{
    public partial class TypeToEngineLink
    {
        /// <summary>
        /// LTE_TYP_ID
        /// </summary>
        public int TypeId { get; set; }
        
        public Type Type { get; set; }

        /// <summary>
        /// LTE_NR
        /// </summary>
        public short Number { get; set; }

        /// <summary>
        /// LTE_ENG_ID
        /// </summary>
        public int EngineId { get; set; }
        
        public Engine Engine { get; set; }

        /// <summary>
        /// LTE_PCON_START
        /// </summary>
        public int? PconStart { get; set; }

        /// <summary>
        /// LTE_PCON_END
        /// </summary>
        public int? PconEnd { get; set; }
    }
}