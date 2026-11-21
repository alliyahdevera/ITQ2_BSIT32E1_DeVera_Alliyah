using ITQ2_BSIT32E1_DeVera_Alliyah.Data;
using ITQ2_BSIT32E1_DeVera_Alliyah.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_DeVera_Alliyah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var response = new GetUsersResponse
            {
                Users = _repository.GetAllUsers().Select(u => new GetUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                }).ToList()
            };

            return Ok(response);
        }

        // GET: api/User/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(new GetUserByIdResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserRequest request)
        {
            var user = _repository.CreateUser(request.Name, request.Email);

            var response = new GetUserByIdResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, response);
        }

        // PUT: api/User/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserRequest request)
        {
            if (id != request.Id)
                return BadRequest("Route id and body id do not match.");

            if (!_repository.UpdateUser(id, request.Name, request.Email))
                return NotFound();

            return NoContent();
        }

        // DELETE: api/User/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.DeleteUser(id))
                return NotFound();

            return NoContent();
        }
    }
}