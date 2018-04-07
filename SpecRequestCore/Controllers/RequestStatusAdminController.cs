using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecRequestCore.Data;
using SpecRequestCore.Models;
using SpecRequestCore.Models.RequestStatusViewModels;
using SpecRequestCore.Repositories;

namespace SpecRequestCore.Controllers
{
    public class RequestStatusAdminController : Controller
    {
        private IRequestStatusRepository repository;

        public RequestStatusAdminController(IRequestStatusRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.RequestStatuses);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new RequestStatus
                {
                    Status = model.Status
                };
                repository.SaveRequestStatus(result);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}