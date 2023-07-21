using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoiDongYVN.Models;
using HoiDongYVN.Repository;

namespace HoiDongYVN.Controllers
{
    public class TagsController : Controller
    {
        private readonly iTag tagRepo;


        public TagsController(iTag tagRepo)
        {
            this.tagRepo = tagRepo;
        }

        // GET: Creators

        public IActionResult Index()

        {
            return View(tagRepo.GetTags());
        }
        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Tagname, int Tagstatus)

        {
                tagRepo.Create(Tagname,1);
                return RedirectToAction(nameof(Index));
            
           
        }
        public IActionResult Detail(int id)
        {
            var tag = tagRepo.GetTagById(id);
            return View(tag);
        }

        [HttpGet]
        [Route("Tags/{id}")]
        public IActionResult GetTagById(int id)
        {
            try
            {
                return Ok(tagRepo.GetTagById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(string id, string Tagname)
        {
            //int idTag = int.Parse(id);
            tagRepo.Edit(int.Parse(id), Tagname);
            return View();

        }

        [HttpPost]
        public IActionResult CreateTag([FromBody] Tag tag)
        {
            try
            {
                if (TagExists(tag.PkITagId))
                {
                    return Ok(new
                    {
                        message = "Tên nhóm danh mục đã tồn tại"
                    });
                }

                tagRepo.CreateTag(tag);
                return Ok(tag);
            }
            catch
            {
                return BadRequest();
            }
        }
        public bool TagExists(int id)
        {
            return tagRepo.TagExists(id);
        }

        [HttpPost]
        public IActionResult UpdateTag(int id, [FromBody] Tag tag)

        {
            try
            {
                var tagExists = tagRepo.GetTagById(id);

                if (tagExists == null)
                {
                    return NotFound();
                }

                if (tag.STagname != tagExists.STagname && TagExists(tag.PkITagId))
                {
                    return Ok(new
                    {
                        message = "Tên nhóm danh mục đã tồn tại"
                    });
                }

                tagExists.STagname = tag.STagname;
                tagRepo.Update(tagExists);
                return Ok(tagExists);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult DeleteTag(int id)
        {
            try
            {
                var tag = tagRepo.GetTagById(id);
                if (tag == null)
                {
                    return NotFound();
                }

                tagRepo.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Tags/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.TblTags == null)
        //    {
        //        return NotFound();
        //    }

        //    var tag = await _context.TblTags
        //        .FirstOrDefaultAsync(m => m.PkITagId == id);
        //    if (tag == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tag);
        //}

        //// GET: Tags/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Tags/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PkITagId,STagname,IStatus")] Tag tag)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tag);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tag);
        //}

        //// GET: Tags/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TblTags == null)
        //    {
        //        return NotFound();
        //    }

        //    var tag = await _context.TblTags.FindAsync(id);
        //    if (tag == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tag);
        //}

        //// POST: Tags/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PkITagId,STagname,IStatus")] Tag tag)
        //{
        //    if (id != tag.PkITagId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tag);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TagExists(tag.PkITagId))
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
        //    return View(tag);
        //}

        //// GET: Tags/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TblTags == null)
        //    {
        //        return NotFound();
        //    }

        //    var tag = await _context.TblTags
        //        .FirstOrDefaultAsync(m => m.PkITagId == id);
        //    if (tag == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tag);
        //}

        //// POST: Tags/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TblTags == null)
        //    {
        //        return Problem("Entity set 'db_HoiDongYVNContext.TblTags'  is null.");
        //    }
        //    var tag = await _context.TblTags.FindAsync(id);
        //    if (tag != null)
        //    {
        //        _context.TblTags.Remove(tag);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TagExists(int id)
        //{
        //  return _context.TblTags.Any(e => e.PkITagId == id);
        //}
    }
}
