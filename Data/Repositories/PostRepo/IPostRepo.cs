using Data.Entities;
using Data.Models.PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.PostRepo
{
    public interface IPostRepo
    {
        public Task<TblPost> GetPostById(Guid id);
        public Task<List<PostResModel>> GetNewFeed(Guid id);
    }
}
