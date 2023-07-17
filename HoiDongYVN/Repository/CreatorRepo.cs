using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HoiDongYVN.Repository
{
    public class CreatorRepo : iCreator
    {
        private readonly db_HoiDongYVNContext _dbContext;

        public CreatorRepo(db_HoiDongYVNContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Creator Create(Creator creator)
        {
            _dbContext.Add(creator);
            _dbContext.SaveChanges();
            return creator;
        }

        public List<Creator> GetCreators()
        {
            return _dbContext.TblCreators.ToList();
        }
        public Creator GetCreatorByUsernameAndPassword(string username, string password)
        {
            return _dbContext.TblCreators.FirstOrDefault(m => m.SUsername == username && m.SPassword == password);
        }

        public Creator Update(Creator creator)
        {
            _dbContext.TblCreators.Update(creator);
            _dbContext.SaveChanges();
            return creator;
        }
        public void Delete(int id)
        {
            var creator = _dbContext.TblCreators.Find(id);
            _dbContext.TblCreators.Remove(creator);
            _dbContext.SaveChanges();

        }
        public void Lock(int id)
        {
            var creator = _dbContext.TblCreators.Find(id);
            if (creator.IStatus == 1)
            {
                creator.IStatus = 0;
            }
            else
            {
                creator.IStatus = 1;
            }
            _dbContext.TblCreators.Update(creator);
            _dbContext.SaveChanges();

        }
        public Creator GetCreatorById(int id)
        {
            var creator = _dbContext.TblCreators.Find(id);
            return creator;
        }

    }
}
