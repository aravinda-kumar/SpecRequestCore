using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpecRequestCore.Data;
using SpecRequestCore.Models;

namespace SpecRequestCore.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private ApplicationDbContext context;

        public RequestStatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<RequestStatus> RequestStatuses => context.RequestStatuses;

        public void SaveRequestStatus(RequestStatus requestStatus)
        {
            if (requestStatus.Id == 0)
            {
                context.RequestStatuses.Add(requestStatus);
            }

            context.SaveChanges();
        }
    }
}
