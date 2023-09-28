using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.UserRepo
{
    public class UserRepo : Repository<TblUser>, IUserRepo
    {
        private readonly PetLoversDbContext _context;
        public UserRepo(/*IMapper mapper,*/ PetLoversDbContext context) : base(context)
        {
            //_mapper = mapper;
            _context = context;
        }

        public async Task<TblUser> getUserByUsername(string username)
        {
            return await _context.TblUsers.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
        }

        public async Task<Guid> GetRoleId(string RoleName)
        {
            var role = await _context.TblRoles.Where(x => x.Name.ToLower().Equals(RoleName.ToLower())).FirstOrDefaultAsync();
            return role.Id;
        }

        public async Task<TblUser> GetUserByEmail(string Email)
        {
            return await _context.TblUsers.Where(x => x.Email.Equals(Email)).FirstOrDefaultAsync();
        }

        public async Task<TblUser> GetUserById(Guid id)
        {
            TblUser user = await _context.TblUsers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return user;
        }
    }
}
