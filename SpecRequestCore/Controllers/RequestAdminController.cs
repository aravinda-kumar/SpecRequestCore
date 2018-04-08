using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpecRequestCore.Models;
using SpecRequestCore.Models.RequestAdminViewModels;
using SpecRequestCore.Repositories;

namespace SpecRequestCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RequestAdminController : Controller
    {
        private IRequestRepository repository;
        private IRequestStatusRepository statusRepository;
        private UserManager<ApplicationUser> userManager;

        public RequestAdminController(IRequestRepository repository, IRequestStatusRepository statusRepository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.statusRepository = statusRepository;
            this.userManager = userManager;
        }

        public IActionResult Index() => View(repository.Requests);

        public async Task<IActionResult> Edit(int id)
        {
            var request = repository.Requests.FirstOrDefault(r => r.Id == id);
            
            if (request != null)
            {
                var reviewers = new List<ApplicationUser>();
                foreach (var user in userManager.Users)
                {
                    if(await userManager.IsInRoleAsync(user, "Reviewer"))
                        reviewers.Add(user);
                }

                EditRequestViewModel editModel = new EditRequestViewModel();
                editModel.Id = request.Id;
                editModel.Name = request.Name;
                editModel.Description = request.Description;
                editModel.RequestStatusId = request.RequestStatusId;
                editModel.ReviewerId = request.ReviewerId;
                editModel.Statuses = statusRepository.RequestStatuses;
                editModel.Reviewers = reviewers;

                return View(editModel);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRequestViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = repository.Requests.FirstOrDefault(r => r.Id == editViewModel.Id);
                if (model != null)
                {
                    model.Name = editViewModel.Name;
                    model.Description = editViewModel.Description;
                    model.ReviewerId = editViewModel.ReviewerId;
                    model.RequestStatusId = editViewModel.RequestStatusId;
                    repository.SaveRequest(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editViewModel);
        }
    }
}