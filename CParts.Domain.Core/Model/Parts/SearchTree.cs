using System.Collections.Generic;

namespace CParts.Domain.Core.Model.Parts
{
    public partial class SearchTree
    {
        /// <summary>
        /// STR_ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// STR_ID_PARENT
        /// </summary>
        public int? ParentId { get; set; }
        
        public SearchTree Parent { get; set; }

        public ICollection<SearchTree> Childs { get; set; }
        
        /// <summary>
        /// STR_TYPE
        /// </summary>
        public short? Type { get; set; }

        /// <summary>
        /// STR_LEVEL
        /// </summary>
        public short? Level { get; set; }

        /// <summary>
        /// STR_DES_ID
        /// </summary>
        public int? DesignationId { get; set; }
        
        public GeneralDesignation Designation { get; set; }

        /// <summary>
        /// STR_SORT
        /// </summary>
        public short? Sort { get; set; }

        /// <summary>
        /// STR_NODE_NR
        /// </summary>
        public int? NodeNr { get; set; }
    }
}