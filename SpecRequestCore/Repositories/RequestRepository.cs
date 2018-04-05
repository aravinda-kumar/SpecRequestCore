using SpecRequestCore.Data;
using SpecRequestCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private ApplicationDbContext context;

        public RequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Request> Requests => context.Requests; 
    }
}
