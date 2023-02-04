using Auth.API.Data.Repository;
using Auth.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserController(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        // GET: api/SystemUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetSystemUsers()
        {
            return Ok(await _systemUserRepository.GetAll());
        }

        // GET: api/SystemUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> GetSystemUser(int id)
        {
            var validGuid = Guid.TryParse(id.ToString(), out var userGuid);
            if (!validGuid)
            {
                return BadRequest();
            }
            var systemUser = await _systemUserRepository.GetByGuid(userGuid);
            if (systemUser == null)
            {
                return NotFound();
            }
            return Ok(systemUser);
        }

        // PUT: api/SystemUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemUser(int id, SystemUser systemUserRequest)
        {
            var validGuid = Guid.TryParse(id.ToString(), out var userGuid);
            if (!validGuid)
            {
                return BadRequest();
            }
            var systemUser = await _systemUserRepository.GetByGuid(userGuid);
            if (systemUser == null)
            {
                return BadRequest();
            }
            await _systemUserRepository.Update(systemUserRequest);
            return NoContent();
        }

        // POST: api/SystemUser
        [HttpPost]
        public async Task<ActionResult<SystemUser>> PostSystemUser(SystemUser systemUser)
        {
            await _systemUserRepository.Add(systemUser);
            return CreatedAtAction("GetSystemUser", new { id = systemUser.Id }, systemUser);
        }

        // DELETE: api/SystemUser/5
        [HttpDelete("{username}")]
        public async Task<ActionResult<SystemUser>> DeleteSystemUser(string username)
        {
            var systemUser = await _systemUserRepository.GetByUsername(username);
            if (systemUser == null)
            {
                return NotFound();
            }
            await _systemUserRepository.Delete(systemUser.Id);

            return NoContent();
        }
    }
}