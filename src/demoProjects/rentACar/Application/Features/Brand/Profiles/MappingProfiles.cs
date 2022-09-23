using Application.Features.Brand.Commands.CreateBrand;
using Application.Features.Brand.Dtos;
using Application.Features.Brand.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brand.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Brand, CreatedBrandDto>().ReverseMap();
            CreateMap<Domain.Entities.Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Brand>, BrandListModel>().ReverseMap();
            CreateMap<Domain.Entities.Brand, BrandListDto>().ReverseMap();
            CreateMap<Domain.Entities.Brand, BrandGetByIdDto>().ReverseMap();
        }
    }
}
