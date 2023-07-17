using HoiDongYVN.Models;
using System.Collections.Generic;

namespace HoiDongYVN.Repository
{
    public interface iCreator
    {
        public List<Creator> GetCreators();
        public Creator Create(Creator creator);
        public Creator GetCreatorByUsernameAndPassword(string username, string password);
        public Creator Update(Creator creator);
        public void Delete(int id);
        public void Lock(int id);
        public Creator GetCreatorById(int id);
    }
}


  
