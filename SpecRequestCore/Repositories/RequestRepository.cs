using SpecRequestCore.Data;
using SpecRequestCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                .Include(r => r.User);

        public IQueryable<Request> RequestsForUser(string userId) =>
            context.Requests
                .Include(r => r.User)
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
