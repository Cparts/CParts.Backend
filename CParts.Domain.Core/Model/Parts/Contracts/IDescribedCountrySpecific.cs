using System.Collections;
using System.Collections.Generic;

namespace CParts.Domain.Core.Model.Parts.Contracts
{
    public interface IDescribedCountrySpecific
    {
        ICollection<int> GetCountryDesignationsId();
        void SetCountryDesignations(ICollection<CountryDesignation> designations);
    }
}