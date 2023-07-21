using System.Collections.Generic;
using System.Threading.Tasks;
using HoiDongYVN.Models;

namespace HoiDongYVN.Repository
{
    public interface iPost
    {
        Task<List<Post>> getListPost(int? Fk_iTagID, int? FK_iTagIDSub);
     
        public List<Post> GetPosts();
        public Post Create(Post post);
        public Post GetPostById(int id);
        public Post GetPostByOnlyId(int id);
        public Post GetPostByTagId(int id);
        public Post GetPostByCreatorId(int id);
        public List<Post> GetAllByTagId(int TagID);
        public List<Post> GetAllByCreatorId(int CreatorID);
        public void Delete(int id);

        public void UpdatePost(Post post);
        public void Update(int id);

    }

}