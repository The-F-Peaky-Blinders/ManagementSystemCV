using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ManagementSystemCV.Models;
using ManagementSystemCV.Infraestructures.Context;
using System.Globalization;

namespace ManagementSystemCV.Controllers
{
    public class UploadController : Controller
    {
        private readonly ManagementContext _context;

        public UploadController(ManagementContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "Please upload a valid Excel file." });
            }

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        var users = new List<User>();

                        string[] formats = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "dd-MM-yyyy" };

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var birthdateValue = worksheet.Cells[row, 5].Value.ToString().Trim();
                            DateTime birthdate;

                            if (!DateTime.TryParseExact(birthdateValue, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate))
                            {
                                return BadRequest(new { error = $"Invalid date format in row {row}: {birthdateValue}" });
                            }

                            var user = new User
                            {
                                FirstName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                LastName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                Password = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                Birthdate = birthdate,
                                TelephonePrefixes = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                PhoneNumber = worksheet.Cells[row, 7].Value.ToString().Trim(),
                                PictureUrl = worksheet.Cells[row, 8].Value.ToString().Trim(),
                                City = worksheet.Cells[row, 9].Value.ToString().Trim()
                            };
                            users.Add(user);
                        }

                        _context.Users.AddRange(users);
                        await _context.SaveChangesAsync();
                    }
                }

                return Ok(new { message = "File uploaded and data imported successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
