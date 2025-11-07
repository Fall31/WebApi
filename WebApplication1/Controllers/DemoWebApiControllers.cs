using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoWebApiControllers:ControllerBase
    {
        private readonly UserService _userService;
        public DemoWebApiControllers(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrarUserDTOs dto)
        {
            try
            {
                var user = await _userService.RegistrarUserAsync(dto);
                return Ok(new {message = "Usuario creado"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
