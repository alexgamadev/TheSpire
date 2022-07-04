using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSpire.Models;
using TheSpire.Repositories;

namespace TheSpire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempUsersController : ControllerBase
    {
        private readonly ITemporaryUsersRepo _tempUsersRepo;

        public TempUsersController(ITemporaryUsersRepo temporaryUsersRepo)
        {
            _tempUsersRepo = temporaryUsersRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemporaryUser>> GetAsync(string id)
        {
            var tempUser = await _tempUsersRepo.GetAsync(id);
            if( tempUser is null )
            {
                return NotFound("User doesn't exist");
            }

            return Ok(tempUser);
        }

        [HttpPost]
        public async Task<ActionResult<TemporaryUser>> CreateAsync([FromBody] TemporaryUser tempUser)
        {
            var result = await _tempUsersRepo.CreateAsync(tempUser);
            if( result is null )
            {
                // Temp user for the device already exists
                return Ok(result);
            }

            return CreatedAtAction("Get", new { id = tempUser.Id }, tempUser);
        }
    }
}
