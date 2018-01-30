namespace CParts.Domain.Core.Model
{
    public partial class SupplierAddress
    {
        public short SadSupId { get; set; }
        public string SadTypeOfAddress { get; set; }
        public short SadCouId { get; set; }
        public string SadName1 { get; set; }
        public string SadName2 { get; set; }
        public string SadStreet1 { get; set; }
        public string SadStreet2 { get; set; }
        public string SadPob { get; set; }
        public short? SadCouIdPostal { get; set; }
        public string SadPostalCodePlace { get; set; }
        public string SadPostalCodePob { get; set; }
        public string SadPostalCodeCust { get; set; }
        public string SadCity1 { get; set; }
        public string SadCity2 { get; set; }
        public string SadTel { get; set; }
        public string SadFax { get; set; }
        public string SadEmail { get; set; }
        public string SadWeb { get; set; }
    }
}
