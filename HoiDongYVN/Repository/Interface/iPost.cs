using System.Collections.Generic;
using System.Threading.Tasks;
using HoiDongYVN.Models;

namespace HoiDongYVN.Repository
{
    public interface IPost
    {
        Task<List<Post>> getListPost(int? Fk_iTagID, int? FK_iTagIDSub);
        Task<Post> createPost(Post Post);
    }
}