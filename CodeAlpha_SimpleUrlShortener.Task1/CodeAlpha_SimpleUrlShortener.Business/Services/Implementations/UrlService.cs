using AutoMapper;
using CodeAlpha_SimpleUrlShortener.Business.DTOs.Url;
using CodeAlpha_SimpleUrlShortener.Business.Helpers.Exceptions;
using CodeAlpha_SimpleUrlShortener.Business.Services.Interfaces;
using CodeAlpha_SimpleUrlShortener.Core.Entities;
using CodeAlpha_SimpleUrlShortener.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.Business.Services.Implementations
{
    public class UrlService : IUrlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UrlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> ShortenUrlAsync(UrlCreateDto dto)
        {
            var urlRepository = _unitOfWork.Repository<UrlMapping>();

            string shortCode;
            do
            {
                shortCode = GenerateShortCode();
            }
            while (await urlRepository.GetAsync(x => x.ShortCode == shortCode) != null);

            var urlMapping = _mapper.Map<UrlMapping>(dto);
            urlMapping.ShortCode = shortCode;

            await urlRepository.AddAsync(urlMapping);
            await _unitOfWork.SaveChangesAsync();

            return shortCode;
        }

        public async Task<string> GetOriginalUrlAsync(string shortCode)
        {
            var urlRepository = _unitOfWork.Repository<UrlMapping>();
            var urlMapping = await urlRepository.GetAsync(x => x.ShortCode == shortCode);

            if (urlMapping == null)
                throw new NotFoundException("This short URL does not exist.");

            urlMapping.ClickCount++;
            urlRepository.Update(urlMapping);
            await _unitOfWork.SaveChangesAsync();

            return urlMapping.OriginalUrl;
        }

        private string GenerateShortCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
