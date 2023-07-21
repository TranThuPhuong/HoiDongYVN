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
        private readonly iPost _iPost;

        public HomeController(ILogger<HomeController> logger, iPost iPost)
        {
            _logger = logger;
            _iPost = iPost;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Post(int? FK_iTagID, int? FK_iTagIDSub)
        {

            List<Post> issuccess = await _iPost.getListPost(FK_iTagID, FK_iTagIDSub);
            if (FK_iTagID != null
                 && FK_iTagIDSub != null)
            {
                if ((FK_iTagID == 2 && FK_iTagIDSub == 3) || (FK_iTagID == 3 && FK_iTagIDSub == 2)) ViewData["tag"] = "Tin tức và sự kiện";

            }
            else
            if (FK_iTagID != null)
            {
                switch (FK_iTagID)
                {
                    case 1: ViewData["tag"] = "Kiến thức đông y"; break;
                    case 2: ViewData["tag"] = "Tin tức trong nước"; break;
                    case 3: ViewData["tag"] = "Tin tức quốc tế"; break;
                }
            }


            return View(issuccess);

        }
        public async Task<IActionResult> Detail(int postId)
        {
            Post post = await _iPost.getPost(postId);
            return View(post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
