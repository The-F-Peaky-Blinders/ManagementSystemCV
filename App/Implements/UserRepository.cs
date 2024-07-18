using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Infraestructures.Context;
using ManagementSystemCV.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class UserRepository : IUser
{
    private readonly ManagementContext _context;
    private readonly IMapper _mapper;
    private readonly EmailService _emailService;

    public UserRepository(ManagementContext context, IMapper mapper, EmailService emailService)
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

   public async Task RegisterUserAsync(User userModel)
        {
            try
            {
                var existingUser = await GetUserByEmailAsync(userModel.Email);
                if (existingUser != null)
                {
                    throw new Exception("User already exists");
                }

                var user = _mapper.Map<User>(userModel);
                await AddUserAsync(user);
                await SendWelcomeEmail(user);
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción de alguna manera, por ejemplo, registrándola o lanzándola nuevamente
                // También podrías querer lograr el error para un seguimiento detallado
                throw new Exception("Error al registrar usuario", ex);
            }
        }


    private async Task<User> AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    private async Task SendWelcomeEmail(User user)
    {
        var subject = "Registro con éxito - Detalles del Registro";
        var htmlContent = $"<p>Hola <strong>{user.FirstName}</strong>,</p>" +
            $"<p>Nos complace informarte que te has registrado exitosamente en nuestro servicio.</p>" +
            $"<p><strong>Detalles del registro:</strong></p>" +
            $"<ul>" +
            $"<li><strong>Nombre:</strong> {user.FirstName}</li>" +
            $"<li><strong>Correo Electrónico:</strong> {user.Email}</li>" +
            $"<li><strong>Fecha:</strong> {DateTime.UtcNow}</li>" +
            $"</ul>" +
            $"<p>Gracias por utilizar nuestro servicio.</p>" +
            $"<p>Saludos cordiales,</p>" +
            $"<p>The-F-Peaky-Blinders<br>" +
            $"<a href='mailto:The-F-Peaky-Blinders.soporte@riwicould.com'>The-F-Peaky-Blinders.soporte@peaky.com</a><br>" +
            $"Teléfono de Soporte: 8654324</p>";

        await _emailService.SendEmailAsync(user.Email, subject, htmlContent);
    }
}
