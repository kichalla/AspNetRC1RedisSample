﻿using Microsoft.AspNet.Mvc;

namespace AspNetRC1RedisSample.Controllers
{
    [Route("")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}