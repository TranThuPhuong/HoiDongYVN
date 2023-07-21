using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoiDongYVN.Repository
{
    public class TagRepo : iTag
    {
        private readonly db_HoiDongYVNContext _dbContext;
        public TagRepo(db_HoiDongYVNContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Tag Create(string tagName, int tagStatus)
        {
            var tag = new Tag { STagname = tagName,IStatus = tagStatus };
            _dbContext.Add(tag);
            _dbContext.SaveChanges();
            return tag;
        }

        public List<Tag> GetTags()
        {
            return _dbContext.TblTags.ToList();
        }
        public Tag GetTagById(int id)
        {
            var tag = _dbContext.TblTags.Find(id);
            return tag;
        }
        public Tag Update(Tag tag)
        {
            _dbContext.TblTags.Update(tag);
            _dbContext.SaveChanges();
            return tag;
        }
        public Tag Edit(int id, string new_TagName)
        {
            var tag = _dbContext.TblTags.Find(id);
            tag.STagname = new_TagName;
            _dbContext.SaveChanges();
            return tag;
        }

    

        public bool TagExists(int id)
        {
            return _dbContext.TblTags.Any(e => e.PkITagId == id);
        }
        public Tag CreateTag(Tag tag)
        {
            _dbContext.Add(tag);
            _dbContext.SaveChanges();
            return tag;
        }

        public void Delete(int id)
        {
            var tag = _dbContext.TblTags.Find(id);
            _dbContext.TblTags.Remove(tag);
            _dbContext.SaveChanges();
        } 
    }
}
