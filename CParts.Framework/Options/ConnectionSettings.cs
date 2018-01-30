namespace CParts.Framework.Options
{
    public class ConnectionSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public StagedConnectionStrings InternalData { get; set; }
        public StagedConnectionStrings PartsData { get; set; }
    }

    public class StagedConnectionStrings
    {
        public string Production { get; set; }
        public string Test { get; set; }
    }
}