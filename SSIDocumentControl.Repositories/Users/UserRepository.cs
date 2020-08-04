using Microsoft.EntityFrameworkCore;
using SSIDocumentControl.Core;
using SSIDocumentControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories.Users
{
  public  class UserRepository : IUserRepository
    {
        private readonly DocumentContext _context;
        public UserRepository(DocumentContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateCredentials(string userName, string password)
        {
            var user = await GetByUserName(userName);
            if (user == null)
                return false;
            return user.Password.ToLower() == password.ToLower();
        }
        public async Task<RentUser> GetByUserName(string userName)
        {
            try
            {
                var user = await _context.Users
              .Select(u => new RentUser
              {
                  UserId = u.UserId,
                  User = u.User,
                  FirstName = u.FirstName,
                  LastName = u.LastName,
                  OfficeId = u.OfficeId,
                  Password = u.Password
              })
              .FirstOrDefaultAsync(u => u.User == userName);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<RentUser> GetByUserId(int? userId)
        {
            try
            {
                var user = await _context.Users
              .Select(u => new RentUser
              {
                  UserId = u.UserId,
                  User = u.User,
                  FirstName = u.FirstName,
                  LastName = u.LastName,
                  OfficeId = u.OfficeId,
                  Password = u.Password
              })
              .FirstOrDefaultAsync(u => u.UserId == userId);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<IEnumerable<RentUser>> GetAllActiveUsers()
        {
            return await _context.Users
                 .Where(user=> user.Active == true)
                .Select(u => new RentUser
                {
                    UserId = u.UserId,
                    User = u.User,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    OfficeId = u.OfficeId,
                    Password = u.Password
                })
                .OrderBy(u=> u.FirstName)
                .ToListAsync();
        }
        public async Task<IEnumerable<RentUser>> GetActiveUsersNotAssignedToRole(int roleId)
        {
            return await _context.Users
                 .Where(user => !_context.UserRole
                                            .Any(ur=> user.UserId == ur.UserId && ur.Role.RoleId == roleId) 
                                && user.Active == true)
                .Select(u => new RentUser
                {
                    UserId = u.UserId,
                    User = u.User,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    OfficeId = u.OfficeId,
                    Password = u.Password
                })
                .OrderBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<bool> IsAdministrator(RentUser user)
        {
            return await _context.UserRole.AnyAsync(u => u.UserId == user.UserId && u.Role.Name == "Administrator");
        }
    }
}
