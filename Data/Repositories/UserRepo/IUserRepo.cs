using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Models.UserModel;
using Data.Repositories.GenericRepository;

namespace Data.Repositories.UserRepo
{
    public interface IUserRepo : IRepository<TblUser>
    {
        Task<TblUser> getUserByUsername(string username);

        Task<Guid> GetRoleId(string RoleName);

        Task<TblUser> GetUserByEmail(string Email);
        
        Task<UserModel> GetUserById(Guid id);
    }
}
