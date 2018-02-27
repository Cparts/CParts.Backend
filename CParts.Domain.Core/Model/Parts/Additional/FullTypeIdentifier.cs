namespace CParts.Domain.Core.Model.Parts.Additional
{
    public class FullTypeIdentifier
    {
        /// <summary>
        /// FTP_ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// FTP_FULL_IDENTIFIER
        /// </summary>
        public string FullIdentifier { get; set; }
        
        /// <summary>
        /// FTP_MFA_ID
        /// </summary>
        public short ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        
        /// <summary>
        /// FTP_MOD_ID
        /// </summary>
        public int ModelId { get; set; }
        public Model Model { get; set; }
        
        /// <summary>
        /// FTP_TYP_ID
        /// </summary>
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}