namespace CParts.Domain.Core.Model.Parts
{
    public partial class SupplierAddress
    {
        /// <summary>
        /// SAD_SUP_ID
        /// </summary>
        public short SupplierId { get; set; }
        
        public Supplier Supplier { get; set; }

        /// <summary>
        /// SAD_TYPE_OF_ADDRESS
        /// </summary>
        public string TypeOfAddress { get; set; }

        /// <summary>
        /// SAD_COU_ID
        /// </summary>
        public short CountryId { get; set; }
        
        public Country Country { get; set; }

        /// <summary>
        /// SAD_NAME_1
        /// </summary>
        public string Name1 { get; set; }

        /// <summary>
        /// SAD_NAME_2
        /// </summary>
        public string Name2 { get; set; }

        /// <summary>
        /// SAD_STREET_1
        /// </summary>
        public string Street1 { get; set; }

        /// <summary>
        /// SAD_STREET_2
        /// </summary>
        public string Street2 { get; set; }

        /// <summary>
        /// SAD_POB
        /// </summary>
        public string Pob { get; set; }

        /// <summary>
        /// SAD_COU_ID_POSTAL
        /// </summary>
        public short? CountryIdPostal { get; set; }
        
        public Country CountryPostal { get; set; }

        /// <summary>
        /// SAD_POSTAL_CODE_PLACE
        /// </summary>
        public string PostalCodePlace { get; set; }

        /// <summary>
        /// SAD_POSTAL_CODE_POB
        /// </summary>
        public string PostalCodePob { get; set; }

        /// <summary>
        /// SAD_POSTAL_CODE_CUST
        /// </summary>
        public string PostalCodeCust { get; set; }

        /// <summary>
        /// SAD_CITY_1
        /// </summary>
        public string City1 { get; set; }

        /// <summary>
        /// SAD_CITY_2
        /// </summary>
        public string City2 { get; set; }

        /// <summary>
        /// SAD_TEL
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// SAD_FAX
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// SAD_EMAIL
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// SAD_WEB
        /// </summary>
        public string Web { get; set; }
    }
}