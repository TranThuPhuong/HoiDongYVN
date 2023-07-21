using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using HoiDongYVN.Models;
using System.Security.Claims;
using HoiDongYVN.Models.ViewModel;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Routing;

namespace HoiDongYVN.Controllers
{
    public class PostController : Controller
    {
        private readonly iPost postRepo;
        private readonly iTag tagRepo;
        private readonly string id;
        private readonly string name;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(iPost postRepo, IWebHostEnvironment webHostEnvironment, iTag tagRepo, IHttpContextAccessor contextAccessor)
        {
            this.postRepo = postRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.tagRepo = tagRepo;
            id = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid); 
            name = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        // GET: HomeController1
        public IActionResult Index()
        {
            return View(postRepo.GetPosts());
        }

        [HttpGet]
        [Route("Post/{id}")]
        public IActionResult GetPostByOnlyId(int id)
        {
            try
            {
                return Ok(postRepo.GetPostByOnlyId(id));
            }
            catch
            {
                return NotFound();
            }
        }
        
        // GET: HomeController1/Details/5
        [Route("Post/Details")]
        public IActionResult Details(int id)
        {
            var post = postRepo.GetPostById(id);
            var postModel = new PostModel
            {
                PkIPostId = post.PkIPostId,
                STitle = post.STitle,
                SDescription = post.SDescription,
                SContent = post.SContent,
                SSource = post.SSource,
                SImage = post.SImage,
                ITagid = post.FkITagId,
                STagname = post.FkITag.STagname,
                SDate = post.DUpDatedDate.ToString()
            };
            
            return View(postModel);
        }

        // GET: HomeController1/Create
        [Route("Post/Create")]
        public IActionResult Create()
        {
            ViewBag.Tag = tagRepo.GetTags();
            ViewBag.CreatorName = name;
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [Route("Post/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModel postModel, IFormFile imageFile)
        {
            var post = new Post
            {
                STitle = postModel.STitle,
                SDescription = postModel.SDescription,
                SContent = postModel.SContent,
                DCreatedDate = DateTime.UtcNow,
                DUpDatedDate = DateTime.UtcNow,
                SSource = postModel.SSource,
                SImage = UploadFile(imageFile),
                IStatus = 1,
                FkITagId = postModel.ITagid,
                FkICreatorId = int.Parse(id),
            };
            postRepo.Create(post);
            return RedirectToAction("Index", "Post");

        }
        public string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Lấy đường dẫn nơi bạn muốn lưu trữ ảnh trên server
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "image/image_post");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                // Tạo tên file duy nhất cho ảnh
                var uniqueFileName = DateTime.UtcNow.Ticks.ToString() + Path.GetExtension(file.FileName);

                // Tạo đường dẫn đầy đủ của file ảnh trên server
                var filePath = Path.Combine(imagePath, uniqueFileName);

                // Lưu ảnh lên server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return uniqueFileName;
            }
            return "";
        }
        
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var post = postRepo.GetPostByOnlyId(id);
                if (post == null)
                {
                    return NotFound();
                }

                postRepo.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var post = postRepo.GetPostById(id);
            ViewBag.Tag = tagRepo.GetTags();
            if (post == null)
            {
                return NotFound();
            }

            var postModel = new PostModel
            {
                PkIPostId = post.PkIPostId,
                STitle = post.STitle,
                SDescription = post.SDescription,
                SContent = post.SContent,
                SSource = post.SSource,
                SImage = post.SImage,
                ITagid = post.FkITag.PkITagId,
                STagname = post.FkITag.STagname,
                SDate = post.DUpDatedDate.ToString()
            };
            return View("Edit",postModel);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostModel postModel, IFormFile imageFile)
        {
            var post_pass = postRepo.GetPostById(postModel.PkIPostId);

            post_pass.STitle = postModel.STitle;
            post_pass.SDescription = postModel.SDescription;
            post_pass.SContent = postModel.SContent;
            post_pass.DCreatedDate = post_pass.DCreatedDate;
            post_pass.DUpDatedDate = DateTime.UtcNow;
            post_pass.SSource = postModel.SSource;
            if(imageFile != null)
            {
                post_pass.SImage = UploadFile(imageFile);
            }
            else
            {
                post_pass.SImage = postModel.SImage;
            }
           
            post_pass.IStatus = 1;
            post_pass.FkITagId = postModel.ITagid;
            post_pass.FkICreatorId = post_pass.FkICreatorId;
 
            postRepo.UpdatePost(post_pass);
            return RedirectToAction("Index", "Post"); ;
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
