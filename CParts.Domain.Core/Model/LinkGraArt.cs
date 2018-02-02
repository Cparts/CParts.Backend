namespace CParts.Domain.Core.Model
{
    public partial class LinkGraArt
    {
        /// <summary>
        /// LGA_ART_ID
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// LGA_SORT
        /// </summary>
        public short Sort { get; set; }

        /// <summary>
        /// LGA_GRA_ID
        /// </summary>
        public string GraphicId { get; set; }
        
        public Graphic Graphic { get; set; }
    }
}