using System;

namespace CParts.Domain.Core.Model.Internal.Contracts
{
    public interface ITrackedEntity
    {
        DateTime CreateTimeStamp { get; set; }
        DateTime UpdateTimeStamp { get; set; }
    }
}