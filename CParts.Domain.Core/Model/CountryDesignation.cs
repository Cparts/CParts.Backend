namespace CParts.Domain.Core.Model
{
    public class CountryDesignation
    {
        /// <summary>
        /// CDS_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// CDS_LNG_ID
        /// </summary>
        public short LanguageId { get; set; }

        public Language Language { get; set; }

        /// <summary>
        /// CDS_TEX_ID
        /// </summary>
        public int DesignationTextId { get; set; }

        public DesignationText DesignationText { get; set; }
    }
}