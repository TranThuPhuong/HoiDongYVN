
using System.Collections.Generic;
using System.Threading.Tasks;
using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.EntityFrameworkCore;

namespace HoiDongYVN.Repository
{
    public class PostRepo : IPost
    {
        private readonly DbThuchanhContext _context;

        public PostRepo(DbThuchanhContext context)
        {
            _context = context;
        }


        public async Task<List<Post>> getListPost()
        {
            return await _context.tblPost.ToListAsync();
        }
        public async Task<Post> createPost(Post Post)
        {
            _context.tblPost.Add(Post);
            await _context.SaveChangesAsync();
            return Post;
        }

    }
}