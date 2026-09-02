using CodeAlpha_SimpleUrlShortener.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.Core.Entities
{
    public class UrlMapping : BaseEntity
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public int ClickCount { get; set; } = 0;
    }
}
