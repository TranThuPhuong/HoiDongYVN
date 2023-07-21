
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

        public List<Post> GetPosts()
        {
            return _context.TblPosts.Include(p => p.FkITag).ToList();
        }

        public Post Create(Post post)
        {
            _context.TblPosts.Add(post);
            _context.SaveChangesAsync();
            return post;
        }
        public List<Post> GetAllByTagId(int TagID)
        {
            return _context.TblPosts.Include(p => p.FkITag).Where(p => p.FkITagId == TagID).ToList();
        }

        public List<Post> GetAllByCreatorId(int CreatorID)
        {
            return _context.TblPosts.Include(p => p.FkITag).Where(p => p.FkICreatorId == CreatorID).ToList();
        }

        public Post GetPostById(int id)
        {
            var post = _context.TblPosts.Include(post => post.FkITag).SingleOrDefault(P => P.PkIPostId == id);
            return post;
        }
        public Post GetPostByOnlyId(int id)
        {
            var post = _context.TblPosts.Find(id);
            return post;
        }
        public Post GetPostByTagId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Post GetPostByCreatorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var post = _context.TblPosts.Find(id);
            _context.TblPosts.Remove(post);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            //_context.TblPosts.Update(post);
            //_context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.TblPosts.Update(post);
            _context.SaveChanges();
        }
    }
}
