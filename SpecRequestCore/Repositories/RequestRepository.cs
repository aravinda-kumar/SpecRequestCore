using SpecRequestCore.Data;
using SpecRequestCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SpecRequestCore.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private ApplicationDbContext context;

        public RequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Request> Requests =>
            context.Requests
                .Include(r => r.User)
                .Include(r => r.Reviewer)
                .Include(r => r.RequestStatus);
                

        public IQueryable<Request> RequestsForUser(string userId) =>
            context.Requests
                .Include(r => r.User)
                .Include(r => r.Reviewer)
                .Include(r => r.RequestStatus)
                .Where(r => r.UserId == userId);

        public void SaveRequest(Request request)
        {
            if (request.Id == 0)
            {
                context.Requests.Add(request);
            }

            context.SaveChanges();
        }
    }
}
