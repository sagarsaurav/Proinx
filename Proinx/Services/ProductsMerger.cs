using System.Collections.Generic;
using System.Linq;
using Proinx.Models;

namespace Proinx.Services
{
    public class ProductsMerger : IProductsMerger
    {
        public List<ProductAllCdnUrls> MergeDocsToProductListWithAllCdn(List<ProductInfoExcel> excelProdList, List<ProductInfoCsv> csvProdList)
        {
            var groupedProducts = from p in csvProdList
                                  group p by p.UniqueIdentifier
                into grouped
                                  select new
                                  {
                                      UniqueId = grouped.Key,
                                      CdnUrls = grouped.Select(x => x.CdnUrl).ToList()
                                  };
            return (from prod in excelProdList
                    join prodCsv in groupedProducts on prod.EAN equals prodCsv.UniqueId
                    select new ProductAllCdnUrls { EAN = prod.EAN, Name = prod.Name, CdnUrls = prodCsv.CdnUrls }).ToList();
        }

        public List<Product> MergeDocsToProductListWithLatestCdn(List<ProductInfoExcel> excelProdList, List<ProductInfoCsv> csvProdList)
        {
            var groupedProducts = from p in csvProdList
                                  group p by p.UniqueIdentifier
                into grouped
                                  select new
                                  {
                                      UniqueId = grouped.Key,
                                      LatestCdnUrl = grouped.OrderByDescending(x => x.LastUpdated).FirstOrDefault()?.CdnUrl
                                  };
            return (from prod in excelProdList
                    join prodCsv in groupedProducts on prod.EAN equals prodCsv.UniqueId
                    select new Product { EAN = prod.EAN, Name = prod.Name, CdnUrl = prodCsv.LatestCdnUrl }).ToList();

        }
    }
}
