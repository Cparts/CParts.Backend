using CParts.Domain.Core.Model.Parts;

namespace CParts.Domain.Abstractions.QueryModels
{
    public class TypeEngineQueryModel
    {
        public Engine Engine { get; set; }
        public int TypeId { get; set; }
    }
}