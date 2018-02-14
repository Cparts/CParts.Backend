using CParts.Domain.Core.Model.Parts.Contracts;

namespace CParts.Domain.Core.Model.Parts
{
    public class CountryDesignation : IDesignation
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
        public int TextId { get; set; }

        public DesignationText Text { get; set; }
    }
}