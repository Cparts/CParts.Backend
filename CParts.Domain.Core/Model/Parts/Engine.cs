namespace CParts.Domain.Core.Model.Parts
{
    public partial class Engine
    {
        /// <summary>
        /// ENG_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ENG_MFA_ID
        /// </summary>
        public short? ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// ENG_CODE
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ENG_PCON_START
        /// </summary>
        public int? PconStart { get; set; }

        /// <summary>
        /// ENG_PCON_END
        /// </summary>
        public int? PconEnd { get; set; }

        /// <summary>
        /// ENG_KW_FROM
        /// </summary>
        public int? KwFrom { get; set; }

        /// <summary>
        /// ENG_KW_UPTO
        /// </summary>
        public int? KwUpto { get; set; }

        /// <summary>
        /// ENG_HP_FROM
        /// </summary>
        public int? HpFrom { get; set; }

        /// <summary>
        /// ENG_HP_UPTO
        /// </summary>
        public int? HpUpto { get; set; }

        /// <summary>
        /// ENG_VALVES
        /// </summary>
        public short? Valves { get; set; }

        /// <summary>
        /// ENG_CYLINDERS
        /// </summary>
        public short? Cylinders { get; set; }

        /// <summary>
        /// ENG_CCM_FROM
        /// </summary>
        public int? CcmFrom { get; set; }

        /// <summary>
        /// ENG_CCM_UPTO
        /// </summary>
        public int? CcmUpto { get; set; }

        /// <summary>
        /// ENG_KV_DESIGN_DES_ID
        /// </summary>
        public int? KvDesignDesignationId { get; set; }
        
        public GeneralDesignation KvDesignDesignation { get; set; }

        /// <summary>
        /// ENG_KV_FUEL_TYPE_DES_ID
        /// </summary>
        public int? KvFuelTypeDesignationId { get; set; }
        
        public GeneralDesignation KvFuelTypeDesignation { get; set; }

        /// <summary>
        /// ENG_KV_FUEL_SUPPLY_DES_ID
        /// </summary>
        public int? KvFuelSupplyDesignationId { get; set; }

        public GeneralDesignation KvFuelSupplyDesignation { get; set; }

        /// <summary>
        /// ENG_DESCRIPTION
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ENG_KV_ENGINE_DES_ID
        /// </summary>
        public int? KvEngineDesignationId { get; set; }

        public GeneralDesignation KvEngineDesignation { get; set; }

        /// <summary>
        /// ENG_KW_RPM_FROM
        /// </summary>
        public int? KwRPMFrom { get; set; }

        /// <summary>
        /// ENG_KW_RPM_UPTO
        /// </summary>
        public int? KwRPMUpto { get; set; }

        /// <summary>
        /// ENG_TORQUE_FROM
        /// </summary>
        public int? TorqueFrom { get; set; }

        /// <summary>
        /// ENG_TORQUE_UPTO
        /// </summary>
        public int? TorqueUpto { get; set; }

        /// <summary>
        /// ENG_TORQUE_RPM_FROM
        /// </summary>
        public int? TorqueRpmFrom { get; set; }

        /// <summary>
        /// ENG_TORQUE_RPM_UPTO
        /// </summary>
        public int? TorqueRpmUpto { get; set; }

        /// <summary>
        /// ENG_COMPRESSION_FROM
        /// </summary>
        public double? CompressionFrom { get; set; }

        /// <summary>
        /// ENG_COMPRESSION_UPTO
        /// </summary>
        public double? CompressionUpto { get; set; }

        /// <summary>
        /// ENG_DRILLING
        /// </summary>
        public double? Drilling { get; set; }

        /// <summary>
        /// ENG_EXTENSION
        /// </summary>
        public double? Extension { get; set; }

        /// <summary>
        /// ENG_CRANKSHAFT
        /// </summary>
        public short? Crankshaft { get; set; }

        /// <summary>
        /// ENG_KV_CHARGE_DES_ID
        /// </summary>
        public int? KvChargeDesignationId { get; set; }

        public GeneralDesignation KvChargeDesignation { get; set; }

        /// <summary>
        /// ENG_KV_GAS_NORM_DES_ID
        /// </summary>
        public int? KvGasNormDesignationId { get; set; }

        public GeneralDesignation KvGasNormDesignation { get; set; }

        /// <summary>
        /// ENG_KV_CYLINDERS_DES_ID
        /// </summary>
        public int? KvCylindersDesignationId { get; set; }

        public GeneralDesignation KvCylindersDesignation { get; set; }

        /// <summary>
        /// ENG_KV_CONTROL_DES_ID
        /// </summary>
        public int? KvControlDesignationId { get; set; }

        public GeneralDesignation KvControlDesignation { get; set; }

        /// <summary>
        /// ENG_KV_VALVE_CONTROL_DES_ID
        /// </summary>
        public int? KvValveControlDesignationId { get; set; }

        public GeneralDesignation KvValveControlDesignation { get; set; }

        /// <summary>
        /// ENG_KV_COOLING_DES_ID
        /// </summary>
        public int? KvCoolingDesignationId { get; set; }

        public GeneralDesignation KvCoolingDesignation { get; set; }

        /// <summary>
        /// ENG_CCM_TAX_FROM
        /// </summary>
        public int? CcmTaxFrom { get; set; }

        /// <summary>
        /// ENG_CCM_TAX_UPTO
        /// </summary>
        public int? CcmTaxUpto { get; set; }

        /// <summary>
        /// ENG_LITRES_TAX_FROM
        /// </summary>
        public double? LitresTaxFrom { get; set; }

        /// <summary>
        /// ENG_LITRES_TAX_UPTO
        /// </summary>
        public double? LitresTaxUpto { get; set; }

        /// <summary>
        /// ENG_LITRES_FROM
        /// </summary>
        public double? LitresFrom { get; set; }

        /// <summary>
        /// ENG_LITRES_UPTO
        /// </summary>
        public double? LitresUpto { get; set; }

        /// <summary>
        /// ENG_KV_USE_DES_ID
        /// </summary>
        public int? KvUseDesignationId { get; set; }

        public GeneralDesignation KvUseDesignation { get; set; }
    }
}