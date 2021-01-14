using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
