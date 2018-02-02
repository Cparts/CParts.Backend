using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CParts.Domain.Core.Model
{
    public partial class Type
    {
        /// <summary>
        /// TYP_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TYP_CDS_ID
        /// </summary>
        public int? CountryDesignationId { get; set; }

        [NotMapped]
        public ICollection<CountryDesignation> CountryDesignation { get; set; }

        /// <summary>
        /// TYP_MMT_CDS_ID
        /// </summary>
        public int? MmtCountryDesignationId { get; set; }

        [NotMapped]
        public ICollection<CountryDesignation> MmtCountryDesignations { get; set; }

        /// <summary>
        /// TYP_MOD_ID
        /// </summary>
        public int ModelId { get; set; }

        public Model Model { get; set; }

        /// <summary>
        /// TYP_SORT
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// TYP_PCON_START
        /// </summary>
        public int? PconStart { get; set; }

        /// <summary>
        /// TYP_PCON_END
        /// </summary>
        public int? PconEnd { get; set; }

        /// <summary>
        /// TYP_KW_FROM
        /// </summary>
        public int? KwFrom { get; set; }

        /// <summary>
        /// TYP_KW_UPTO
        /// </summary>
        public int? KwUpto { get; set; }

        /// <summary>
        /// TYP_HP_FROM
        /// </summary>
        public int? HpFrom { get; set; }

        /// <summary>
        /// TYP_HP_UPTO
        /// </summary>
        public int? HpUpto { get; set; }

        /// <summary>
        /// TYP_CCM
        /// </summary>
        public int? Ccm { get; set; }

        /// <summary>
        /// TYP_CYLINDERS
        /// </summary>
        public short? Cylinders { get; set; }

        /// <summary>
        /// TYP_DOORS
        /// </summary>
        public short? Doors { get; set; }

        /// <summary>
        /// TYP_TANK
        /// </summary>
        public short? Tank { get; set; }

        /// <summary>
        /// TYP_KV_VOLTAGE_DES_ID
        /// </summary>
        public int? KvVoltageDesignationId { get; set; }

        public Designation KvVoltageDesignation { get; set; }

        /// <summary>
        /// TYP_KV_ABS_DES_ID
        /// </summary>
        public int? KvAbsDesignationId { get; set; }

        public Designation KvAbsDesignation { get; set; }

        /// <summary>
        /// TYP_KV_ASR_DES_ID
        /// </summary>
        public int? KvAsrDesignationId { get; set; }

        public Designation KvAsrDesignation { get; set; }

        /// <summary>
        /// TYP_KV_ENGINE_DES_ID
        /// </summary>
        public int? KvEngineDesignationId { get; set; }

        public Designation KvEngineDesignation { get; set; }

        /// <summary>
        /// TYP_KV_BRAKE_TYPE_DES_ID
        /// </summary>
        public int? KvBrakeTypeDesignationId { get; set; }

        public Designation KvBrakeTypeDisignation { get; set; }

        /// <summary>
        /// TYP_KV_BRAKE_SYST_DES_ID
        /// </summary>
        public int? KvBrakeSystemDesignationId { get; set; }

        public Designation KvBrakeSystemDesignation { get; set; }

        /// <summary>
        /// TYP_KV_FUEL_DES_ID
        /// </summary>
        public int? KvFuelDesignationId { get; set; }

        public Designation KvFuelDesignation { get; set; }

        /// <summary>
        /// TYP_KV_CATALYST_DES_ID
        /// </summary>
        public int? KvCatalystDesignationId { get; set; }

        public Designation KvCatalystDesignation { get; set; }

        /// <summary>
        /// TYP_KV_BODY_DES_ID
        /// </summary>
        public int? KvBodyDesignationId { get; set; }

        public Designation KvBodyDesignation { get; set; }

        /// <summary>
        /// TYP_KV_STEERING_DES_ID
        /// </summary>
        public int? KvSteeringDesignationId { get; set; }

        public Designation KvSteeringDesignation { get; set; }

        /// <summary>
        /// TYP_KV_STEERING_SIDE_DES_ID
        /// </summary>
        public int? KvSteeringSideDesignationId { get; set; }

        public Designation KvSteeringSideDesignation { get; set; }

        public double? TypMaxWeight { get; set; }

        /// <summary>
        /// TYP_KV_MODEL_DES_ID
        /// </summary>
        public int? KvModelDesignationId { get; set; }

        public Designation KvModelDesignation { get; set; }

        /// <summary>
        /// TYP_KV_AXLE_DES_ID
        /// </summary>
        public int? KvAxleDesignationId { get; set; }

        public Designation KvAxleDesignation { get; set; }

        /// <summary>
        /// TYP_CCM_TAX
        /// </summary>
        public int? CcmTax { get; set; }

        /// <summary>
        /// TYP_LITRES
        /// </summary>
        public double? Litres { get; set; }

        /// <summary>
        /// TYP_KV_DRIVE_DES_ID
        /// </summary>
        public int? KvDriveDesignationId { get; set; }

        public Designation KvDriveDesignation { get; set; }

        /// <summary>
        /// TYP_KV_TRANS_DES_ID
        /// </summary>
        public int? KvTransDesignationId { get; set; }

        public Designation KvTransDesignation { get; set; }

        /// <summary>
        /// TYP_KV_FUEL_SUPPLY_DES_ID
        /// </summary>
        public int? KvFuelSupplyDesignationId { get; set; }

        public Designation KvFuelSupplyDesignation { get; set; }

        /// <summary>
        /// TYP_VALVES
        /// </summary>
        public short? Valves { get; set; }

        /// <summary>
        /// TYP_RT_EXISTS
        /// </summary>
        public short? RtExists { get; set; }
    }
}