using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpecRequestCore.Models;

namespace SpecRequestCore.Repositories
{
    public interface IRequestStatusRepository
    {
        IQueryable<RequestStatus> RequestStatuses { get; }

        void SaveRequestStatus(RequestStatus requestStatus);
    }
}
