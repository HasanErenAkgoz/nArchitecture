using Application.Features.Brand.Dtos;
using Application.Features.Brand.Models;
using Application.Features.Brand.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brand.Querys.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
                _brandBusinessRules = brandBusinessRules;
            }
            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Brand? brand = await _brandRepository.GetAsync(brand => brand.Id == request.Id);
                await _brandBusinessRules.BrandShouldExistWhenRequested(brand);
                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);
                return brandGetByIdDto;
            }
        }
    }
}
