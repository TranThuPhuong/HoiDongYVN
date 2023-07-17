using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HoiDongYVN.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TblPosts = new HashSet<Post>();
        }

        public int PkITagId { get; set; }
        [DisplayName("Danh mục")]
        public string STagname { get; set; }

        [DisplayName("Trạng thái")]
        public int? IStatus { get; set; }

        public virtual ICollection<Post> TblPosts { get; set; }
    }
}
