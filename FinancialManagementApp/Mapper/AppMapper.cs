using AutoMapper;
using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp;
using FinancialManagementApp.ViewModels;
using FinancialManagementApp.Infrastructure.ModelDto;

namespace FinancialManagementApp.Infrastructure.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper() 
        {
            CreateMap<UserVM, User>().ReverseMap();

            CreateMap<WalletVM, Wallet>().ReverseMap();

            CreateMap<WalletHistoryVM, WalletHistory>().ReverseMap()
                .ForMember(dest => dest.WalletValue, opt => opt.MapFrom(src => src.Value));
        }
    }
}
