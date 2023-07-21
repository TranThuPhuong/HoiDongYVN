using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HoiDongYVN.Controllers.CustomAttributes;

namespace HoiDongYVN.Controllers
{
    [CustomAuthorization]
    public class CreatorsController : Controller
    {
        private readonly iCreator creatorRepo;

        public CreatorsController(iCreator creatorRepo)
        {
            this.creatorRepo = creatorRepo;
        }

        // GET: Creators
       
        public IActionResult Index()

        {
            //if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            //{
                // Người dùng đã đăng nhập và có quyền truy cập vào trang hoặc tài nguyên cụ thể
                // Thực hiện các thao tác mong muốn tại đây
                return View(creatorRepo.GetCreators());
            //}
            //else
            //{
            //    // Người dùng không đủ quyền truy cập vào trang hoặc tài nguyên này
            //    // Chuyển hướng đến trang đăng nhập hoặc hiển thị thông báo lỗi
            //    return RedirectToAction("Login", "Login");
            //}
           
        }


        // GET: Creators/Details/5
        //public async task<iactionresult> details(int? id)
        //{
        //    if (id == null || _context.tblcreators == null)
        //    {
        //        return notfound();
        //    }

        //    var creator = await _context.tblcreators
        //        .firstordefaultasync(m => m.pkicreatorid == id);
        //    if (creator == null)
        //    {
        //        return notfound();
        //    }

        //    return view(creator);
        //}
       
        public IActionResult Detail(int id)
        {
            var creator = creatorRepo.GetCreatorById(id);
            return View(creator);
        }


        // GET: Creators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Creators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Creator creator)
        {
            if (ModelState.IsValid)
            {
                creatorRepo.Create(creator);
                return RedirectToAction(nameof(Index));
            }

            return View(creator);
        }
        // GET: Creators/Lock
        public IActionResult Lock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Lock(int id)
        {
            creatorRepo.Lock(id);
            return Ok();
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            creatorRepo.Delete(id);
            return Ok();

        }
        public IActionResult Edit(int id)
        {
            var creator = creatorRepo.GetCreatorById(id);
            return View(creator);
        }
        [HttpPost]
        public IActionResult Edit(Creator creator) 
        {
            creatorRepo.Update(creator);
            return View();

        }

        // GET: Creators/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TblCreators == null)
        //    {
        //        return NotFound();
        //    }

        //    var creator = await _context.TblCreators.FindAsync(id);
        //    if (creator == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(creator);
        //}

        // POST: Creators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PkICreatorId,SUsername,SPassword,SFullname,SEmail,SPhone,IStatus,IRole")] Creator creator)
        //{
        //    if (id != creator.PkICreatorId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(creator);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CreatorExists(creator.PkICreatorId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(creator);
        //}

        //// GET: Creators/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TblCreators == null)
        //    {
        //        return NotFound();
        //    }

        //    var creator = await _context.TblCreators
        //        .FirstOrDefaultAsync(m => m.PkICreatorId == id);
        //    if (creator == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(creator);
        //}

        //// POST: Creators/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TblCreators == null)
        //    {
        //        return Problem("Entity set 'db_HoiDongYVNContext.TblCreators'  is null.");
        //    }
        //    var creator = await _context.TblCreators.FindAsync(id);
        //    if (creator != null)
        //    {
        //        _context.TblCreators.Remove(creator);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CreatorExists(int id)
        //{
        //  return _context.TblCreators.Any(e => e.PkICreatorId == id);
        //}
    }
}