namespace CParts.Domain.Core.Model
{
    public partial class SearchTree
    {
        /// <summary>
        /// STR_ID
        /// </summary>
        public int StrId { get; set; }

        /// <summary>
        /// STR_ID_PARENT
        /// </summary>
        public int? StrIdParent { get; set; }

        /// <summary>
        /// STR_TYPE
        /// </summary>
        public short? StrType { get; set; }

        /// <summary>
        /// STR_LEVEL
        /// </summary>
        public short? StrLevel { get; set; }

        /// <summary>
        /// STR_DES_ID
        /// </summary>
        public int? StrDesId { get; set; }

        /// <summary>
        /// STR_SORT
        /// </summary>
        public short? StrSort { get; set; }

        /// <summary>
        /// STR_NODE_NR
        /// </summary>
        public int? StrNodeNr { get; set; }
    }
}