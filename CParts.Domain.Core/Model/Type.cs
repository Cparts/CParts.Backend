namespace CParts.Domain.Core.Model
{
    public partial class Type
    {
        public int TypId { get; set; }
        public int? TypCdsId { get; set; }
        public int? TypMmtCdsId { get; set; }
        public int TypModId { get; set; }
        public int TypSort { get; set; }
        public int? TypPconStart { get; set; }
        public int? TypPconEnd { get; set; }
        public int? TypKwFrom { get; set; }
        public int? TypKwUpto { get; set; }
        public int? TypHpFrom { get; set; }
        public int? TypHpUpto { get; set; }
        public int? TypCcm { get; set; }
        public short? TypCylinders { get; set; }
        public short? TypDoors { get; set; }
        public short? TypTank { get; set; }
        public int? TypKvVoltageDesId { get; set; }
        public int? TypKvAbsDesId { get; set; }
        public int? TypKvAsrDesId { get; set; }
        public int? TypKvEngineDesId { get; set; }
        public int? TypKvBrakeTypeDesId { get; set; }
        public int? TypKvBrakeSystDesId { get; set; }
        public int? TypKvFuelDesId { get; set; }
        public int? TypKvCatalystDesId { get; set; }
        public int? TypKvBodyDesId { get; set; }
        public int? TypKvSteeringDesId { get; set; }
        public int? TypKvSteeringSideDesId { get; set; }
        public double? TypMaxWeight { get; set; }
        public int? TypKvModelDesId { get; set; }
        public int? TypKvAxleDesId { get; set; }
        public int? TypCcmTax { get; set; }
        public double? TypLitres { get; set; }
        public int? TypKvDriveDesId { get; set; }
        public int? TypKvTransDesId { get; set; }
        public int? TypKvFuelSupplyDesId { get; set; }
        public short? TypValves { get; set; }
        public short? TypRtExists { get; set; }
    }
}
