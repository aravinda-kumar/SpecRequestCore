using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecRequestCore.Repositories;

namespace SpecRequestCore.Controllers
{
    public class RequestAdminController : Controller
    {
        private IRequestRepository repository;

        public RequestAdminController(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index() => View(repository.Requests);
    }
}