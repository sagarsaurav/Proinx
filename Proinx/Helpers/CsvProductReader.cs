using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Proinx.Models;

namespace Proinx.Helpers
{
    public static class CsvProductReader
    {

        public static List<ProductInfoCsv> GetProducts(string documentFileFullPath)
        {
            using (var reader = new StreamReader(documentFileFullPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ProductInfoCsv>();
                return records.ToList();
            }

        }
    }
}
