using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpecRequestCore.Models;

namespace SpecRequestCore.Repositories
{
    public interface IRequestRepository
    {
        IQueryable<Request> Requests { get; }
        void SaveRequest(Request request);
    }
}
