using InterestPlatform.Services.Filters;
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
        private readonly IFilterService _filterService;

        public InterestsController(
            IInterestService interestService,
            IFilterService filterService)
        {
            _interestService = interestService;
            _filterService = filterService;
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

                return RedirectToAction(nameof(Edit), new { path = result.Path });
            }
            return View(model);
        }

        [Route("edit/{path?}")]
        [HttpGet]
        public IActionResult Edit(string path)
        {
            return View(_interestService.Get(path));
        }

        [Route("add-filter/{path?}")]
        [HttpGet]
        public IActionResult AddFilter(string path)
        {
            ViewData["InterestId"] = _interestService.Get(path).Id;
            return View();
        }

        [Route("add-filter/{path?}")]
        [HttpPost]
        public async Task<IActionResult> AddFilter(string path, CreateFilterRequest request)
        {
            if (ModelState.IsValid)
            {
                var interest = _interestService.Get(path);
                await _filterService.CreateAsync(interest.Id, request);
                return RedirectToAction(nameof(Edit), new { path = path });
            }
            return View(request);
        }

        [Route("details/{path}")]
        [HttpGet]
        public IActionResult Details(string path)
        {
            return View(_interestService.Get(path));
        }
    }
}
