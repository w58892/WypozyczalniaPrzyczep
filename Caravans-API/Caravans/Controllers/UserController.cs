using Caravans.Interfaces;
using Caravans.Models;
using Caravans.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Caravans.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        //private readonly DatabaseContext _context;
        private readonly IJwtAutenticationManager _jwtAutenticationManager;

        
        public UserController(IUserRepository userRepository, IJwtAutenticationManager jwtAutenticationManager)
        {
            _userRepository = userRepository;
            _jwtAutenticationManager = jwtAutenticationManager;
        }

        // GET: User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userRepository.GetAll());
            }
            return BadRequest();
        }

        // GET: User/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userRepository.Get(id));
            }
            return BadRequest();
        }

        // GET: User/Email/{email}
        [HttpGet("Email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userRepository.GetByEmail(email));
            }
            return BadRequest();
        }

        // POST: User/Add
        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(User user)
        {
            if (ModelState.IsValid)
            {
                User us = await _userRepository.GetByEmail(user.Email);
                if (us != null)
                    return BadRequest(JsonSerializer.Serialize(new { errors = new { Email = "Taki email już istnieje" } }));

                return Ok(await _userRepository.Add(user));
            }
            return BadRequest();
        }

        // POST: User/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update(User user)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userRepository.Update(user));
            }
            return BadRequest();
        }

        // GET: User/Delete/id
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                var user = await _userRepository.Delete(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        // POST: User/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            User user = await _userRepository.GetByEmail(login.Email);
            if (user == null)
                return BadRequest(JsonSerializer.Serialize(new { errors = new { Email = "Taki użytkownik nie istnieje" } }));
            bool verified = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);

            if (!verified)
                return BadRequest(JsonSerializer.Serialize(new { errors = new { Password = "Błędne hasło" } }));

            var token = _jwtAutenticationManager.Authenticate(user);

            if (token == null)
                return BadRequest(JsonSerializer.Serialize(new { errors = new { Token = "brak tokenu" } }));

            return Ok(token);
        }

    }
}
