using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoiDongYVN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly IPost _iPost;

        public HomeController(ILogger<HomeController> logger, IPost iPost)
        {
            _logger = logger;
            _iPost = iPost;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Post()
        {
             List<Post> issuccess = await _iPost.getListPost();
            return View(issuccess);
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
