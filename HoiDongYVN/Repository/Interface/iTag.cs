using HoiDongYVN.Models;
using System.Collections.Generic;

namespace HoiDongYVN.Repository
{
    public interface iTag
    {
        public List<Tag> GetTags();
        public Tag GetTagById(int id);
        public Tag Create(string tagnName, int tagStatus);
        public Tag CreateTag(Tag tag);
        public Tag Update(Tag tag);
        public void Delete(int id);
        public Tag Edit(int id, string new_TagName);
        public bool TagExists(int id);


    }
}



