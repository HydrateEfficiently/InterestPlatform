using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Controllers
{
    [Route("{path?}/post")]
    public class PostController : Controller
    {

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("submit")]
        [HttpGet]
        public IActionResult Submit(string path)
        {
            ViewData["path"] = path;
            return View();
        }
    }
}
