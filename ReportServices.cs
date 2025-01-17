namespace MAgistrFront
{ 
    using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class ReportService
    {
        //public async Task<byte[]> GenerateExcelReportAsync(List<ReportModel> reports)
        //{
        //    using var package = new ExcelPackage();
        //    var worksheet = package.Workbook.Worksheets.Add("Reports");

        //    worksheet.Cells[1, 1].Value = "Id";
        //    worksheet.Cells[1, 2].Value = "Name";
        //    worksheet.Cells[1, 3].Value = "Value";

        //    for (int i = 0; i < reports.Count; i++)
        //    {
        //        worksheet.Cells[i + 2, 1].Value = reports[i].Id;
        //        worksheet.Cells[i + 2, 2].Value = reports[i].Name;
        //        worksheet.Cells[i + 2, 3].Value = reports[i].Value;
        //    }

        //    return await package.GetAsByteArrayAsync();
        //}
    }
}
