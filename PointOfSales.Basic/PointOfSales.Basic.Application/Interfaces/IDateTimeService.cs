using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
