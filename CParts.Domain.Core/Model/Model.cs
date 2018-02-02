using System.ComponentModel.DataAnnotations.Schema;

namespace CParts.Domain.Core.Model
{
    public partial class Model
    {
        /// <summary>
        /// MOD_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// MOD_MFA_ID
        /// </summary>
        public short? ManufacturerId { get; set; }
        
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// MOD_CDS_ID
        /// </summary>
        public int? CountryDesignationId { get; set; }
        
        [NotMapped]
        public CountryDesignation CountryDesignation { get; set; }

        /// <summary>
        /// MOD_PCON_START
        /// </summary>
        public int? PconStart { get; set; }

        /// <summary>
        /// MOD_PCON_END
        /// </summary>
        public int? PconEnd { get; set; }

        /// <summary>
        /// MOD_PC
        /// </summary>
        public short? Pc { get; set; }

        /// <summary>
        /// MOD_CV
        /// </summary>
        public short? Cv { get; set; }

        /// <summary>
        /// MOD_AXL
        /// </summary>
        public short? Axl { get; set; }
    }
}