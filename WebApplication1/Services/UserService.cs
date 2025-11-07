using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography;
using Microsoft.AspNetCore;
using System.Text;

namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly APIContext _apiContext;
        public UserService(APIContext apiContext) 
        {
            _apiContext = apiContext;
        }
        public async Task<User> RegistrarUserAsync(RegistrarUserDTOs dto)
        {
            throw new NotImplementedException();
            if (await _apiContext.Users.AnyAsync(u => u.Email == dto.Email))
            {
                throw new Exception("Email ya registrado");
            }
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = HashPassword(dto.Password) // En un entorno real, la contraseña debe ser hasheada
            };
            _apiContext.Users.Add(user);
            await _apiContext.SaveChangesAsync();
            return user;
        }
        public string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);

        }
    }
}
