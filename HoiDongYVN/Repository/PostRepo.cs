
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


        public async Task<List<Post>> getListPost(int? FK_iTagID, int? FK_iTagIDSub)
        {
            if (FK_iTagID != null)
            {
                if (FK_iTagIDSub != null)
                {
                    return await _context.tblPost.Where(x => (x.FK_iTagID == FK_iTagID || x.FK_iTagID == FK_iTagIDSub)).ToListAsync();
                }
                else
                {
                    return await _context.tblPost.Where(x => x.FK_iTagID == FK_iTagID).ToListAsync();
                }
            }
            else
            {
                return await _context.tblPost.ToListAsync();
            }

        }
        public async Task<Post> createPost(Post Post)
        {
            _context.tblPost.Add(Post);
            await _context.SaveChangesAsync();
            return Post;
        }

    }
}