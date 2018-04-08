using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecRequestCore.Models;
using SpecRequestCore.Models.RequestViewModels;
using SpecRequestCore.Repositories;

namespace SpecRequestCore.Controllers
{
    [Authorize(Roles = "User")]
    public class RequestController : Controller
    {
        private IRequestRepository repository;
        private UserManager<ApplicationUser> userManager;

        public RequestController(IRequestRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            return View(repository.RequestsForUser(user.Id));
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Request
                {
                    Id = 0,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    RequestCreated = DateTime.Now,
                    UserId = userManager.GetUserId(HttpContext.User),
                    RequestStatusId = 1 // Want to set the status to received, assume its ID is 1.
                };

                repository.SaveRequest(model);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}