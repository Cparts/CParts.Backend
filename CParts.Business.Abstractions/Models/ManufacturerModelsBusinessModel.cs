using System.Collections.Generic;
using CParts.Domain.Core.Model.Parts;

namespace CParts.Infrastructure.Business.Parts
{
    public class ManufacturerModelsBusinessModel
    {
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}