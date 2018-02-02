namespace CParts.Domain.Core.Model
{
    public partial class TextModule
    {
        /// <summary>
        /// TMO_ID
        /// </summary>
        public int TmoId { get; set; }

        /// <summary>
        /// TMO_LNG_ID
        /// </summary>
        public short LanguageId { get; set; }

        public Language Language { get; set; }
        /// <summary>
        /// TMO_FIXED
        /// </summary>
        public short Fixed { get; set; }

        /// <summary>
        /// TMO_TMT_ID
        /// </summary>
        public int TextId { get; set; }
        
        public TextModuleText Text { get; set; }
    }
}