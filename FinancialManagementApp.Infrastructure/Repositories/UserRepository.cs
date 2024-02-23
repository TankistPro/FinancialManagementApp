using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using FinancialManagementApp.Infrastructure.ModelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        async public Task<UserDto> LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) 
            {
                return null;
            }

            var candidate = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (candidate != null) 
            {
                var candidatePassword = candidate.Password;

                if (candidatePassword == password) 
                {
                    return new UserDto()
                    {
                        Id = candidate.Id,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        MiddleName = candidate.MiddleName,
                        Email = candidate.Email,
                        AvatarHash = candidate.AvatarHash,
                        EmailConfirmed = candidate.EmailConfirmed.ToString(),
                        RegistrationDate = candidate.RegistrationDate,
                    };
                }
            }

            return null;
        }

        async public Task<int> RegistartionUser(RegistrationUserDto user)
        {
            bool exsistUser = _context.Users.Any(x => x.Email == user.Email);

            if (exsistUser)
            {
                return -1;
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName ?? String.Empty,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                Password = user.Password,
                AvatarHash = user.AvatarHash ?? String.Empty,
                RegistrationDate = DateTime.Now
            };

            bool status = await this.AddAsync(newUser);

            if (status)
            {
                return newUser.Id;
            }

            return -1;
        }
    }
}
