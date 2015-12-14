using InterestPlatform.Data.Posts;
using InterestPlatform.Services.Posts;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Controllers
{
    [Route("f/{path?}/post")]
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

        [Route("submit")]
        [HttpPost]
        public IActionResult Submit(CreatePostRequest model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
