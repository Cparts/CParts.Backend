namespace CParts.Framework.Options
{
    public class CorsSettings
    {
        public bool Enabled { get; set; }
        public string[] Headers { get; set; }
        public string[] Methods { get; set; }
        public string[] Origins { get; set; }
    }
}