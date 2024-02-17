using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using FinancialManagementApp.Infrastructure.ModelDto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public Task<bool> LoginUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        async public Task<bool> RegistartionUser(RegistrationUserDto user)
        {
            bool exsistUser = _context.Users.Any(x => x.Email == user.Email);

            if (exsistUser)
            {
                return false;
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName ?? String.Empty,
                Email = user.Email,
                Password = user.Password,
                AvatarHash = user.AvatarHash ?? String.Empty,
                WalletId = user.WalletId
            };

            bool status = await this.AddAsync(newUser);

            return status;
        }
    }
}
