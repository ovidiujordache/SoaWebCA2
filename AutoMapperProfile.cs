using AutoMapper;

using WebApiCA2.Repository.Models;

namespace WebApiCA2
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {


            //Mappint Entity to Data Transfer Object. What user is supposed to SEE.
            CreateMap<User, UserDto>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<HospitalityServiceProvider, HospitalityServiceProviderDto>();
            CreateMap<HspandRestaurant, HspandRestaurantDto>();
            CreateMap<FinancialTransaction, FinancialTransactionDto>(); 

        }

    }
}
