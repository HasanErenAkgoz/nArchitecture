using Application.Features.Brand.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brand.Rules;

namespace Application.Features.Brand.Commands.CreateBrand
{

    public class CreateBrandCommand:IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            public CreateBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper,
                    BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }
            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Domain.Entities.Brand mappedBrand = _mapper.Map<Domain.Entities.Brand>(request);
                Domain.Entities.Brand createdBrand = await _brandRepository.AddAsync(mappedBrand); //veritabanından gelen brand
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand); // veritabanından gelen brand verisini dto'ya çevirdik
                return createdBrandDto;
            }
        }
    }
}
