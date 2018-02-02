using System.Collections.Generic;

namespace CParts.Domain.Core.Model
{
    public partial class Language
    {
        /// <summary>
        /// LNG_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// LNG_DES_ID
        /// </summary>
        public int? DesignationId { get; set; }

        public Designation Designation { get; set; }

        /// <summary>
        /// LNG_ISO_2
        /// </summary>
        public string Iso2 { get; set; }

        /// <summary>
        /// LNG_CODEPAGE
        /// </summary>
        public string Codepage { get; set; }
    }
}