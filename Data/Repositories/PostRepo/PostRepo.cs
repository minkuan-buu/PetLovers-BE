using Data.Entities;
using Data.Models.PostModel;
using Data.Repositories.UserRepo;
using Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.UserModel;

namespace Data.Repositories.PostRepo
{
    public class PostRepo : Repository<TblPost>, IPostRepo
    {
        private readonly PetLoversDbContext _context;
        private readonly IUserRepo _userRepo;
        public PostRepo(/*IMapper mapper,*/ PetLoversDbContext context) : base(context)
        {
            //_mapper = mapper;
            _context = context;
        }
        public async Task<TblPost> GetPostById(Guid id)
        {
            return await _context.TblPosts.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<PostResModel>> GetNewFeed(Guid id)
        {
            List<UserModel> following = await _userRepo.GetFollowingUser(id);
            List<PostResModel> posts = new();
            DateTime now = DateTime.Now;
            if (following != null)
            {
                foreach (var postAuthor in following)
                {
                    var postFollowing = await _context.TblPosts.Where(x => x.UserId.Equals(postAuthor.Id) && (now - x.CreateAt).TotalMilliseconds <= 900000).FirstOrDefaultAsync();
                    if (postFollowing != null)
                    {
                        posts.Add(new PostResModel()
                        {
                            id = postFollowing.Id,
                            content = postFollowing.Content,
                            attachment = postFollowing.Attachment,
                            createAt = postFollowing.CreateAt
                        });
                    }
                }

                foreach (var postAuthor in following)
                {
                    var newPost = await _context.TblPosts.Where(x => !x.UserId.Equals(postAuthor.Id) && (now - x.CreateAt).TotalMilliseconds <= 900000).ToListAsync();
                    posts.AddRange(newPost.Select(x => new PostResModel()
                    {
                        id = x.Id,
                        content = x.Content,
                        attachment = x.Attachment,
                        createAt = x.CreateAt
                    }));
                }
            }
            else
            {
                var newPost = await _context.TblPosts.Where(x => (now - x.CreateAt).TotalMilliseconds <= 900000).ToListAsync();
                posts.AddRange(newPost.Select(x => new PostResModel()
                {
                    id = x.Id,
                    content = x.Content,
                    attachment = x.Attachment,
                    createAt = x.CreateAt
                }));
            }
            if (posts.Count <= 0)
            {
                var newPost = await _context.TblPosts.OrderBy(x => x.CreateAt).ToListAsync();
                foreach (var post in newPost)
                {
                    posts.Add(new PostResModel()
                    {
                        id = post.Id,
                        content = post.Content,
                        attachment = post.Attachment,
                        createAt = post.CreateAt
                    });
                }
            }
            return posts;
        }
    }
}
