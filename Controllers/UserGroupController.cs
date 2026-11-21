using ITQ2_BSIT32E1_DeVera_Alliyah.Data;
using ITQ2_BSIT32E1_DeVera_Alliyah.Models.UserGroups;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_DeVera_Alliyah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserGroupController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/UserGroup
        [HttpGet]
        public IActionResult Get()
        {
            var response = _repository.GetAllGroups().Select(g => new GetUserGroupResponse
            {
                Id = g.Id,
                Name = g.Name,
                Users = g.Users.Select(u => new UserGroupMemberDTO { Id = u.Id, Name = u.Name }).ToList()
            }).ToList();

            return Ok(response);
        }

        // GET: api/UserGroup/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var group = _repository.GetGroupById(id);
            if (group == null)
                return NotFound();

            return Ok(new GetUserGroupByIdResponse
            {
                Id = group.Id,
                Name = group.Name,
                Users = group.Users.Select(u => new UserGroupMemberDTO { Id = u.Id, Name = u.Name }).ToList()
            });
        }

        // POST: api/UserGroup
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserGroupRequest request)
        {
            var missing = _repository.FindMissingUserIds(request.UserIDs);
            if (missing.Count > 0)
                return BadRequest($"User id(s) not found: {string.Join(", ", missing)}");

            var group = _repository.CreateGroup(request.Name, request.UserIDs);

            var response = new GetUserGroupByIdResponse
            {
                Id = group.Id,
                Name = group.Name,
                Users = group.Users.Select(u => new UserGroupMemberDTO { Id = u.Id, Name = u.Name }).ToList()
            };

            // 201 Created + Location header pointing to GET api/UserGroup/{id}
            return CreatedAtAction(nameof(GetById), new { id = group.Id }, response);
        }

        // PUT: api/UserGroup/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest("Route id and body id do not match.");

            var missing = _repository.FindMissingUserIds(request.UserIDs);
            if (missing.Count > 0)
                return BadRequest($"User id(s) not found: {string.Join(", ", missing)}");

            if (!_repository.UpdateGroup(id, request.Name, request.UserIDs))
                return NotFound();

            return NoContent();
        }

        // DELETE: api/UserGroup/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.DeleteGroup(id))
                return NotFound();

            return NoContent();
        }
    }
}