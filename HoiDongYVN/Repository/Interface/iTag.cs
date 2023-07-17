using HoiDongYVN.Models;
using System.Collections.Generic;

namespace HoiDongYVN.Repository
{
    public interface iTag
    {
        public List<Tag> GetTags();
        public Tag Create(Tag tag);
        public Tag Update(Tag tag);
    }
}



