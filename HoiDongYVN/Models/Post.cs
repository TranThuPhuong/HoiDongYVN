using System;
using System.Collections.Generic;

namespace HoiDongYVN.Models
{
    public partial class Post
    {
        public int PkIPostId { get; set; }
        public string STitle { get; set; }
        public string SDescription { get; set; }
        public string SContent { get; set; }
        public DateTime? DCreatedDate { get; set; }
        public DateTime? DUpDatedDate { get; set; }
        public string SSource { get; set; }
        public string SImage { get; set; }
        public int? IStatus { get; set; }
        public int FkITagId { get; set; }
        public int FkICreatorId { get; set; }

        public virtual Creator FkICreator { get; set; }
        public virtual Tag FkITag { get; set; }
    }
}
