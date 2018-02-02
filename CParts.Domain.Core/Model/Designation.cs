using System.Collections.Generic;

namespace CParts.Domain.Core.Model
{
    public partial class Designation
    {
        /// <summary>
        /// DES_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DES_LNG_ID
        /// </summary>
        public short LanguageId { get; set; }
        
        public Language Language { get; set; }

        /// <summary>
        /// DES_TEX_ID
        /// </summary>
        public int TextId { get; set; }
        
        public DesignationText Text { get; set; }
    }
}