namespace CParts.Web
{
    public class JsonResponseMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}