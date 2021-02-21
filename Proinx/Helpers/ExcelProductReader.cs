using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Proinx.Models;

namespace Proinx.Helpers
{
    public static class ExcelProductReader
    {
        public static List<ProductInfoExcel> GetProducts(FileInfo documentFile)
        {
            List<ProductInfoExcel> productList = new List<ProductInfoExcel>();
            // Excel file
            using (ExcelPackage package = new ExcelPackage(documentFile))
            {

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet firstSheet = package.Workbook.Worksheets[0];
                int rowCount = firstSheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)
                {
                    ProductInfoExcel productInfoExcel = new ProductInfoExcel
                    {
                        EAN = firstSheet.Cells[row, 1].Value?.ToString()?.Trim(),
                        Name = firstSheet.Cells[row, 2].Value?.ToString()?.Trim(),
                        Description = firstSheet.Cells[row, 3].Value?.ToString()?.Trim()
                    };
                    productList.Add(productInfoExcel);
                }
            }

            return productList;
        }
    }
}
