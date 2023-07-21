using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HoiDongYVN.Models
{
    public partial class Post
    {
        public int PkIPostId { get; set; }
        [DisplayName("Tiêu đề")]
        public string STitle { get; set; }
        [DisplayName("Danh mục")]
        public string SDescription { get; set; }
        [DisplayName("Nội dung")]
        public string SContent { get; set; }
        public DateTime? DCreatedDate { get; set; }
        public DateTime? DUpDatedDate { get; set; }

        public string SSource { get; set; }
        [DisplayName("Ảnh nổi bật")]
        public string SImage { get; set; }
        public int? IStatus { get; set; }
        public int FkITagId { get; set; }
        public int FkICreatorId { get; set; }

        public virtual Creator FkICreator { get; set; }
        public virtual Tag FkITag { get; set; }
    }
}
