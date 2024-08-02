namespace No1_Online.Services
{
    using System.Collections.Generic;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using No1_Online.Models;

    public class ExcelExportService
    {
        public byte[] ExportLoadingSchedulesToExcel(List<LoadingSchedule> schedules)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("LoadingSchedules");

                // Add headers
                worksheet.Cells[1, 1].Value = "Load Id";
                worksheet.Cells[1, 2].Value = "Loading Date";
                worksheet.Cells[1, 3].Value = "Transporter";
                worksheet.Cells[1, 4].Value = "Client References Number";
                worksheet.Cells[1, 5].Value = "Sub Reg Number";
                worksheet.Cells[1, 6].Value = "Load Value";
                worksheet.Cells[1, 7].Value = "Load Instructions";
                worksheet.Cells[1, 8].Value = "Marketer";
                worksheet.Cells[1, 9].Value = "POD Number";
                worksheet.Cells[1, 10].Value = "Depo";
                worksheet.Cells[1, 11].Value = "Payment Terms";
                worksheet.Cells[1, 12].Value = "Self Load";
                worksheet.Cells[1, 13].Value = "Revision";
                worksheet.Cells[1, 14].Value = "Company";
                worksheet.Cells[1, 15].Value = "Loading Point Load";
                worksheet.Cells[1, 16].Value = "Loading Point Off";
                worksheet.Cells[1, 17].Value = "Note";
                worksheet.Cells[1, 18].Value = "Vehicle";

                // Add data
                for (int i = 0; i < schedules.Count; i++)
                {
                    var schedule = schedules[i];
                    worksheet.Cells[i + 2, 1].Value = schedule.Id;
                    worksheet.Cells[i + 2, 2].Value = schedule.Date;
                    worksheet.Cells[i + 2, 3].Value = schedule.CompanyTrans?.Name;
                    worksheet.Cells[i + 2, 4].Value = schedule.PurchaseOrder;
                    worksheet.Cells[i + 2, 5].Value = schedule.SubReg;
                    worksheet.Cells[i + 2, 6].Value = schedule.Value;
                    worksheet.Cells[i + 2, 7].Value = schedule.LoadInstruction;
                    worksheet.Cells[i + 2, 8].Value = schedule.ProfileId;
                    worksheet.Cells[i + 2, 9].Value = schedule.Podnum;
                    worksheet.Cells[i + 2, 10].Value = schedule.Depo;
                    worksheet.Cells[i + 2, 11].Value = schedule.PayTerms;
                    worksheet.Cells[i + 2, 12].Value = schedule.SelfLoad;
                    worksheet.Cells[i + 2, 13].Value = schedule.Revision;
                    worksheet.Cells[i + 2, 14].Value = schedule.Company?.Name;
                    worksheet.Cells[i + 2, 15].Value = schedule.LoadingPointLoad?.City;
                    worksheet.Cells[i + 2, 16].Value = schedule.LoadingPointOff?.City;
                    worksheet.Cells[i + 2, 17].Value = schedule.Note?.Description;
                    worksheet.Cells[i + 2, 18].Value = schedule.Vehicle?.Registration;
                }

                // Format header
                using (var range = worksheet.Cells[1, 1, 1, 18])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                return package.GetAsByteArray();
            }
        }
    }
}

