using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoiDongYVN.Controllers
{
    public class HomeController : Controller
    {
        private readonly iPost postRepo;
        private readonly iTag tagRepo;

        public HomeController(iPost postRepo, iTag tagRepo)
        {
            this.postRepo = postRepo;
            this.tagRepo = tagRepo;
        }
        public IActionResult Index()
        {

            return View(postRepo.GetPosts());
        }
        public IActionResult Introduction()
        {
            return View();
        }

        public IActionResult Post(int FK_iTagID, int page)
        {
            var post = postRepo.GetAllByTagId(FK_iTagID).Count();
            var tag = tagRepo.GetTagById(FK_iTagID);
            ViewBag.Tagname = tag.STagname;
            ViewBag.Tagid = tag.PkITagId;

            int PAGE_SIZE = 5;
            var posts = postRepo.GetAllByTagId(FK_iTagID);
            int pageNumber;
            int totalPages = (int)Math.Ceiling((double)posts.Count() / PAGE_SIZE);

            if (page > 0)
                pageNumber = page > totalPages ? totalPages : page;
            else
                pageNumber = 1;


            var pagedList = new PagedList<Post>(posts, pageNumber, PAGE_SIZE);

            return View("Post", pagedList);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
