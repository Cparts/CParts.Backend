namespace CParts.Domain.Core.Model.Parts.Contracts
{
    public interface IDesignation
    {
        int Id { get; set; }
        short LanguageId { get; set; }
        Language Language { get; set; }
        int TextId { get; set; }
        DesignationText Text { get; set; }
    }
}