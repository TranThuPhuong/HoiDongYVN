
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoiDongYVN.Models;

[Table("tblPost")]
public class Post
{
    [Key]
    public int? PK_iPostID { get; set; }
    public string? sTitle { get; set; }
    public string? sDescription { get; set; }
    public string? sContent { get; set; }
    public DateTime? dCreatedDate { get; set; }
    public DateTime? dUpDatedDate { get; set; }
    public string? sSource { get; set; }
    public string? sImage { get; set; }
    public int? iStatus { get; set; }
    public int? FK_iTagID { get; set; }
    public int? FK_iCreatorID { get; set; }
}
