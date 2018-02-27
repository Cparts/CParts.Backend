namespace CParts.Domain.Core.Model.Parts.Additional
{
    public class SearchTreeName
    {
        /// <summary>
        /// STR_ID
        /// </summary>
        public int SearchTreeId { get; set; }
        public SearchTree SearchTree { get; set; }
        
        /// <summary>
        /// TEX_TEXT
        /// </summary>
        public string Name { get; set; }
    }
}