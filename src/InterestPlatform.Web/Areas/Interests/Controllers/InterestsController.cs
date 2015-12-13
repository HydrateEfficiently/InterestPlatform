using InterestPlatform.Services.Interests;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Controllers
{
    [Route("interests")]
    [Area("Interests")]
    public class InterestsController : Controller
    {

        private readonly IInterestService _interestService;

        public InterestsController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
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

                return RedirectToAction(nameof(Details), new { path = result.Path });
            }
            return View(model);
        }

        [Route("details/{path}")]
        [HttpGet]
        public IActionResult Details(string path)
        {
            return View(_interestService.Get(path));
        }
    }
}
