using InterestPlatform.Services.Filters;
using InterestPlatform.Services.Interests;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Controllers
{
    [Route("f")]
    public class InterestsController : Controller
    {
        private readonly IInterestService _interestService;
        private readonly IFilterService _filterService;

        public InterestsController(
            IInterestService interestService,
            IFilterService filterService)
        {
            _interestService = interestService;
            _filterService = filterService;
        }

        [Route("submit")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("submit")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateInterestRequest model)
        {
            if (ModelState.IsValid)
            {
                InterestResult result = null;
                try
                {
                    result = await _interestService.CreateAsync(model);
                }
                catch (DuplicateUrlException)
                {
                    ModelState.AddModelError(string.Empty, "Requested URL already exists.");
                }

                return RedirectToAction(nameof(Edit), new { path = result.Path });
            }
            return View(model);
        }

        [Route("{path?}/edit")]
        [HttpGet]
        public IActionResult Edit(string path)
        {
            return View(_interestService.Get(path));
        }

        [Route("{path}")]
        [HttpGet]
        public IActionResult Details(string path)
        {
            return View(_interestService.Get(path));
        }
    }
}
