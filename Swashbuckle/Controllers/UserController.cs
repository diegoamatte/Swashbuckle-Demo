using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Swashbuckle.Models;


namespace Swashbuckle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetUsers([FromQuery, BindRequired] string filter, [FromQuery] PageParams pagingParams)
        {
            return Ok(new List<User>());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(new Models.User());
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return NoContent();
        }

        [Obsolete("Deprecated")]
        [HttpPost("photo")]
        public IActionResult UploadPhoto(IFormFile file)
        {
            return Ok("photoUrl");
        }

    }
}