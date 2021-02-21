using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Proinx.Helpers;
using Proinx.Models;
using Proinx.Services;

namespace Proinx
{
    public class ProjectStarter
    {
        private readonly IProductsMerger _projectMerger;

        public ProjectStarter(IProductsMerger projectMerger)
        {
            _projectMerger = projectMerger;
        }

        public void Start()
        {
            string excelFilePath = @"InputFiles\input 1.xlsx";
            string csvFilePath = @"InputFiles\input 2.csv";
            try
            {
                bool foundExcelFile = FileHelper.TryReadFile(excelFilePath, out FileInfo fileExcel);

                if (foundExcelFile)
                {
                    List<ProductInfoExcel> prodInfoExcel = ExcelProductReader.GetProducts(fileExcel);
                    List<ProductInfoCsv> prodInfoCsv = CsvProductReader.GetProducts(csvFilePath);

                    List<ProductAllCdnUrls> productsAllCdn = _projectMerger.MergeDocsToProductListWithAllCdn(prodInfoExcel, prodInfoCsv);
                    List<Product> productsLatestCdn = _projectMerger.MergeDocsToProductListWithLatestCdn(prodInfoExcel, prodInfoCsv);
                    
                    string jsonResultAllCdn = JsonConvert.SerializeObject(productsAllCdn, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Formatting = Formatting.Indented });
                    string jsonResultLatestCdn = JsonConvert.SerializeObject(productsLatestCdn, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Formatting = Formatting.Indented });
                    
                    FileHelper.WriteJsonToFile(jsonResultAllCdn, "productsAllCdn.json");
                    FileHelper.WriteJsonToFile(jsonResultLatestCdn, "productsLatestCdn.json");
                }
                else
                {
                    Console.WriteLine("Unable to find the file(s)");
                }
                Console.WriteLine("The excel and csv documents has been merged. Please find the output file in the \"Debug\" folder.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
