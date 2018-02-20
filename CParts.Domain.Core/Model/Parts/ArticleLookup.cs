using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CParts.Domain.Core.Model.Parts
{
    public partial class ArticleLookup
    {
        /// Like searchbar
        /// <summary>
        /// ARL_ART_ID
        /// </summary>
        public int ArticleId { get; set; }

        public Article Article { get; set; }
        
        /// <summary>
        /// ARL_SEARCH_NUMBER
        /// </summary>
        public string CatalogueCode { get; set; }

        /// <summary>
        /// ARL_KIND
        /// </summary>
        [JsonIgnore]
        public byte[] Kind { get; set; }

        public int KindConverted => Convert.ToInt32(Encoding.UTF8.GetString(Kind));

        /// <summary>
        /// ARL_BRA_ID
        /// </summary>
        public short BrandId { get; set; }
        
        public Brand Brand { get; set; }

        /// <summary>
        /// ARL_DISPLAY_NR
        /// </summary>
        public string DisplayNumber { get; set; }

        /// <summary>
        /// ARL_DISPLAY
        /// </summary>
        public short Display { get; set; }

        /// <summary>
        /// ARL_BLOCK
        /// </summary>
        public short Block { get; set; }

        /// <summary>
        /// ARL_SORT
        /// </summary>
        public short Sort { get; set; }
    }

}