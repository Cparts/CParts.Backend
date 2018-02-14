using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace CParts.Domain.Core.Model.Parts
{
    public partial class Criteria
    {
        /// <summary>
        /// CRI_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// CRI_DES_ID
        /// </summary>
        public int DesignationId { get; set; }
        
        [NotMapped]
        public GeneralDesignation Designation { get; set; }

        /// <summary>
        /// CRI_SHORT_DES_ID
        /// </summary>
        public int? ShortDesignationId { get; set; }
        
        [NotMapped]
        public GeneralDesignation ShortDesignation { get; set; }

        /// <summary>
        /// CRI_UNIT_DES_ID
        /// </summary>
        public int? UnitDesignationId { get; set; }
        
        [NotMapped]
        public GeneralDesignation UnitDesignation { get; set; }

        /// <summary>
        /// CRI_TYPE
        /// </summary>
        [JsonIgnore]
        public byte[] Type { get; set; }
        
        public string TypeConverted => Encoding.UTF8.GetString(Type);

        //TODO: Investigate CRI_KT_ID
        /// <summary>
        /// CRI_KT_ID
        /// </summary>
        public short? KtId { get; set; }

        /// <summary>
        /// CRI_IS_INTERVAL
        /// </summary>
        public short? IsInterval { get; set; }

        //TODO: Investigate CRI_KT_ID
        /// <summary>
        /// CRI_SUCCESSOR
        /// </summary>
        public short? Successor { get; set; }
    }
}