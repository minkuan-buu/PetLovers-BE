using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Models.UserModel;
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

        public async Task<UserModel> GetUserById(Guid id)
        {
            TblUser user = await _context.TblUsers.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            UserModel reponseUser = new UserModel()
            {
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Status = user.Status,
                CreateAt = user.CreateAt,
            };
            return reponseUser;
        }
    }
}
