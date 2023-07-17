using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using System.Collections.Generic;
using System.Linq;
namespace HoiDongYVN.Repository
{
    public class TagRepo : iTag
    {
        private readonly db_HoiDongYVNContext _dbContext;
        public TagRepo(db_HoiDongYVNContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Tag Create(Tag tag)
        {
            _dbContext.Add(tag);
            _dbContext.SaveChanges();
            return tag;
        }

        public List<Tag> GetTags()
        {
            throw new System.NotImplementedException();
        }

        public Tag Update(Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}
