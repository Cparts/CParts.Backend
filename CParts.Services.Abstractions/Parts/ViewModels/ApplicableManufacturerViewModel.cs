namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class ApplicableManufacturerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicableModelViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class ApplicableTypeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}