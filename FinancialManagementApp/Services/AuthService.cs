using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Services
{
    public class AuthService
    {
        private readonly WalletRepository _walletRepository;
        private readonly UserRepository _userRepository;

        public AuthService() 
        {
            _walletRepository = new WalletRepository();
            _userRepository = new UserRepository();
        }

        /// <summary>
        ///  Регистрация пользователя в системе
        /// </summary>
        /// <param name="registrationUserDto"></param>
        /// <returns>Id нового пользователя</returns>
        async public Task<int> RegistartionUser(RegistrationUserDto registrationUserDto)
        {
            try
            {
                int userId = await _userRepository.RegistartionUser(registrationUserDto);

                return userId;
            }
            catch (Exception) {}
            

            return -1;
        }

        async public Task<UserDto> LoginUser(string email, string password)
        {
            UserDto user = await _userRepository.LoginUser(email, password);

            return user;
        }
    }
}
