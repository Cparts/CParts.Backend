namespace CParts.Domain.Core.Model.Parts
{
    public partial class Country
    {
        /// <summary>
        /// COU_ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// COU_CC
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// COU_DES_ID
        /// </summary>
        public int? DesignationId { get; set; }
        
        public GeneralDesignation Designation { get; set; }

        /// <summary>
        /// COU_CURRENCY_CODE
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// COU_ISO_2
        /// </summary>
        public string Iso2 { get; set; }

        /// <summary>
        /// COU_IS_GROUP
        /// </summary>
        public short IsGroup { get; set; }
    }
}