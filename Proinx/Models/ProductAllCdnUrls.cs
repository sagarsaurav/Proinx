using System.Collections.Generic;

namespace Proinx.Models
{
    public class ProductAllCdnUrls
    {
        public string Name { get; set; }
        public string EAN { get; set; }
        public List<string> CdnUrls { get; set; }
    }
}
