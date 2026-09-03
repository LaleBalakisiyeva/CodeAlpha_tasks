using CodeAlpha_SimpleUrlShortener.Business.DTOs.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.Business.Services.Interfaces
{
    public interface IUrlService
    {
        Task<string> ShortenUrlAsync(UrlCreateDto dto);
        Task<string> GetOriginalUrlAsync(string shortCode);
    }
}
