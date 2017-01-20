using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
