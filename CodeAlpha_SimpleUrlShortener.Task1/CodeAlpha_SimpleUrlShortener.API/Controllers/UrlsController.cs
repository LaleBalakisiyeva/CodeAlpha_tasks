using CodeAlpha_SimpleUrlShortener.Business.DTOs.Url;
using CodeAlpha_SimpleUrlShortener.Business.Helpers.Exceptions;
using CodeAlpha_SimpleUrlShortener.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_SimpleUrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten([FromBody] UrlCreateDto dto)
        {
            var shortCode = await _urlService.ShortenUrlAsync(dto);

            var fullShortUrl = $"{Request.Scheme}://{Request.Host}/{shortCode}";

            return Ok(new
            {
                ShortCode = shortCode,
                ShortUrl = fullShortUrl
            });
        }

        [HttpGet("/{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal([FromRoute] string shortCode)
        {
            try
            {
                var originalUrl = await _urlService.GetOriginalUrlAsync(shortCode);
                return Redirect(originalUrl);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
