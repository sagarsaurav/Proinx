using Proinx.Models;
using System.Collections.Generic;

namespace Proinx.Services
{
    public interface IProductsMerger
    {
        List<ProductAllCdnUrls> MergeDocsToProductListWithAllCdn(List<ProductInfoExcel> excelProdList,
            List<ProductInfoCsv> csvProdList);

        List<Product> MergeDocsToProductListWithLatestCdn(List<ProductInfoExcel> excelProdList,
            List<ProductInfoCsv> csvProdList);
    }
}
