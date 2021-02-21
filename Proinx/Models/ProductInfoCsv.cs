using System;
using CsvHelper.Configuration.Attributes;

namespace Proinx.Models
{
    public class ProductInfoCsv
    {
        [Name("UniqueIdentifier")]
        public string UniqueIdentifier { get; set; }
        [Name("CdnUrl")]
        public string CdnUrl { get; set; }
        [Name("LastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
