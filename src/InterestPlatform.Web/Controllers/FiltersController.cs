using InterestPlatform.Services.Filters;
using InterestPlatform.Services.Interests;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Controllers
{
    [Route("f/{path?}/filter")]
    public class FiltersController : Controller
    {
        private readonly IInterestService _interestService;
        private readonly IFilterService _filterService;

        public FiltersController(
            IInterestService interestService,
            IFilterService filterService)
        {
            _interestService = interestService;
            _filterService = filterService;
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add(string path)
        {
            ViewData["Path"] = path;
            return View();
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Add(string path, CreateFilterRequest request)
        {
            if (ModelState.IsValid)
            {
                var interest = _interestService.Get(path);
                await _filterService.CreateAsync(interest.Id, request);
                return RedirectToAction("Edit", "Interests", new { path = path });
            }
            return View(request);
        }
    }
}
