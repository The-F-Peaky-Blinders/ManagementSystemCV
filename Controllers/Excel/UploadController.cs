using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ManagementSystemCV.Models;
using ManagementSystemCV.Infraestructures.Context;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

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
                            var firstName = worksheet.Cells[row, 2].Value?.ToString().Trim();
                            var lastName = worksheet.Cells[row, 3].Value?.ToString().Trim();
                            var email = worksheet.Cells[row, 4].Value?.ToString().Trim();
                            var password = worksheet.Cells[row, 5].Value?.ToString().Trim();
                            var birthdateValue = worksheet.Cells[row, 6].Value?.ToString().Trim();
                            var telephonePrefixes = worksheet.Cells[row, 7].Value?.ToString().Trim();
                            var phoneNumber = worksheet.Cells[row, 8].Value?.ToString().Trim();
                            var pictureUrl = worksheet.Cells[row, 9].Value?.ToString().Trim();
                            var city = worksheet.Cells[row, 10].Value?.ToString().Trim();

                            DateTime? birthdate = null;
                            if (!string.IsNullOrWhiteSpace(birthdateValue))
                            {
                                DateTime parsedDate;
                                if (DateTime.TryParseExact(birthdateValue, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                                {
                                    birthdate = parsedDate;
                                }
                                else
                                {
                                    return BadRequest(new { error = $"Invalid date format in row {row}: {birthdateValue}. Expected formats are: {string.Join(", ", formats)}." });
                                }
                            }

                            // Verificar si el correo ya existe en la base de datos
                            if (await _context.Users.AnyAsync(u => u.Email == email))
                            {
                                return BadRequest(new { error = $"Duplicate email found in row {row}: {email}" });
                            }

                            var user = new User
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                Password = password,
                                Birthdate = birthdate,
                                TelephonePrefixes = telephonePrefixes,
                                PhoneNumber = phoneNumber,
                                PictureUrl = pictureUrl,
                                City = city
                            };
                            users.Add(user);
                        }

                        _context.Users.AddRange(users);
                        await _context.SaveChangesAsync();
                    }
                }

                return Ok(new { message = "File uploaded and data imported successfully." });
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, new { error = $"An error occurred while saving the entity changes: {dbEx.InnerException?.Message ?? dbEx.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
