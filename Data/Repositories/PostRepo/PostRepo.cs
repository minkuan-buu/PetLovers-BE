using Data.Entities;
using Data.Repositories.GenericRepository;
using Data.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.PostRepo
{
    public class PostRepo : Repository<TblUser>, IPostRepo
    {
        private readonly PetLoversDbContext _context;
        public PostRepo(/*IMapper mapper,*/ PetLoversDbContext context) : base(context)
        {
            //_mapper = mapper;
            _context = context;
        }
        public async Task<TblPost> GetPostById(Guid id)
        {
            return await _context.TblPosts.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
