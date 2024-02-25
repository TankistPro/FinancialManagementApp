using AutoMapper;
using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Layouts;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly WalletRepository _walletRepository;
        private readonly UserRepository _userRepository;

        private readonly IMapper _mapper;

        public AuthService(IMapper mapper) 
        {
            _mapper = mapper;

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

        async public Task<UserVM> LoginUser(string email, string password)
        {
            User user = await _userRepository.LoginUser(email, password);

            return _mapper.Map<UserVM>(user);
        }
    }
}
