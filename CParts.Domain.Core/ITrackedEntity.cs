using System;

namespace CParts.Domain.Core
{
    public interface ITrackedEntity
    {
        DateTime CreateTimeStamp { get; set; }
        DateTime UpdateTimeStamp { get; set; }
    }
}