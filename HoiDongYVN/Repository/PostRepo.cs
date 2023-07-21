
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.EntityFrameworkCore;

namespace HoiDongYVN.Repository
{
    public class PostRepo : iPost
    {
        private readonly db_HoiDongYVNContext _context;

        public PostRepo(db_HoiDongYVNContext context)
        {
            _context = context;
        }


        public async Task<List<Post>> getListPost(int? FK_iTagID, int? FK_iTagIDSub)
        {
            if (FK_iTagID != null)
            {
                if (FK_iTagIDSub != null)
                {
                    return await _context.TblPosts.Where(x => (x.FkITagId == FK_iTagID || x.FkITagId == FK_iTagIDSub)).ToListAsync();

                }
                else
                {
                    return await _context.TblPosts.Where(x => x.FkITagId == FK_iTagID).ToListAsync();
                }
            }
            else
            {
                return await _context.TblPosts.ToListAsync();
            }

        }
        public async Task<Post> createPost(Post Post)
        {
            _context.TblPosts.Add(Post);
            await _context.SaveChangesAsync();
            return Post;
        }

        public async Task<Post> getPost(int postId)
        {
        var succeeded = await _context.TblPosts.FirstOrDefaultAsync(p => p.PkIPostId == postId);
            return succeeded;
        }
    }
}
