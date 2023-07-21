using System.ComponentModel;
using System;

namespace HoiDongYVN.Models.ViewModel
{
    public class PostModel
    {
        public int PkIPostId { get; set; }
        [DisplayName("Tiêu đề")]
        public string STitle { get; set; }
        [DisplayName("Mô tả")]
        public string SDescription { get; set; }
        [DisplayName("Nội dung")]
        public string SContent { get; set; }

        [DisplayName("Nguồn")]
        public string SSource { get; set; }
        [DisplayName("Ảnh nổi bật")]
        public string SImage { get; set; }
        [DisplayName("Danh mục")]
        public int ITagid { get; set; }
        public string STagname { get; set; }

        public string SDate { get; set; }




    }
}
