using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Features.Brand.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Brand> result = await _brandRepository.GetListAsync(Brand => Brand.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }

        public async Task BrandShouldExistWhenRequested(Domain.Entities.Brand brand)
        {
            if (brand==null) throw new BusinessException("Requested brand does not exist.");
        }
    }
}
