using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecRequestCore.Repositories;

namespace SpecRequestCore.Controllers
{
    public class RequestController : Controller
    {
        private IRequestRepository repository;

        public RequestController(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Requests);
    }
}