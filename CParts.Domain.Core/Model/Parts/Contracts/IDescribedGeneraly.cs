using System.Collections.Generic;

namespace CParts.Domain.Core.Model.Parts.Contracts
{
    public interface IDescribedGeneraly
    {
        ICollection<int> GetGeneralDesignationsId();
        void SetGeneralDesignations(ICollection<GeneralDesignation> designations);
    }
}