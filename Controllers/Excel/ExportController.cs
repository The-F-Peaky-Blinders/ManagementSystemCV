using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagementSystemCV.Models;
using ManagementSystemCV.Infraestructures.Context;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemCV.Controllers
{
    public class ExportController : Controller
    {
        private readonly ManagementContext _context;

        public ExportController(ManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ExportUsersToExcel()
        {
            var users = await _context.Users.ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // Agregar encabezados
                worksheet.Cells[1, 1].Value = "UserId";
                worksheet.Cells[1, 2].Value = "FirstName";
                worksheet.Cells[1, 3].Value = "LastName";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Password";
                worksheet.Cells[1, 6].Value = "Birthdate";
                worksheet.Cells[1, 7].Value = "TelephonePrefixes";
                worksheet.Cells[1, 8].Value = "PhoneNumber";
                worksheet.Cells[1, 9].Value = "PictureUrl";
                worksheet.Cells[1, 10].Value = "City";

                // Agregar datos
                for (int i = 0; i < users.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = users[i].UserId;
                    worksheet.Cells[i + 2, 2].Value = users[i].FirstName;
                    worksheet.Cells[i + 2, 3].Value = users[i].LastName;
                    worksheet.Cells[i + 2, 4].Value = users[i].Email;
                    worksheet.Cells[i + 2, 5].Value = users[i].Password;
                    worksheet.Cells[i + 2, 6].Value = users[i].Birthdate.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 7].Value = users[i].TelephonePrefixes;
                    worksheet.Cells[i + 2, 8].Value = users[i].PhoneNumber;
                    worksheet.Cells[i + 2, 9].Value = users[i].PictureUrl;
                    worksheet.Cells[i + 2, 10].Value = users[i].City;
                }

                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"Users-{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }
    }
}
