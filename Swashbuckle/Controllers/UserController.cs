using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.Models;
using System.IO;

namespace Swashbuckle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Create, read, update and delete Users")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Gets users with pagination
        /// </summary>
        /// <remarks>Additional info</remarks>
        /// <param name="filter" example="John">User name filter</param>
        /// <response code="200">User retrieved</response>
        /// <response code="500">Oops! Can't lookup your user right now</response>
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetUsers([FromQuery, BindRequired] string filter, [FromQuery] PageParams pagingParams)
        {
            return Ok(new List<User>());
        }

        [SwaggerOperation("Gets user by ID")]
        [SwaggerResponse(StatusCodes.Status200OK,"Successful request",typeof(User))]
        [SwaggerResponse(StatusCodes.Status404NotFound,"User not found")]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(new Models.User());
        }


        [HttpPost]
        [SwaggerOperation("Saves new user in app")]
        [SwaggerResponse(StatusCodes.Status200OK, "User saved successfully", typeof(User))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User is invalid")]
        public IActionResult CreateUser([FromBody] User user)
        {
            return Ok();
        }

        [SwaggerOperation(Summary = "Updates an user", Description = "Updates an user with provided id")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "User updated successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User is invalid")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            return NoContent();
        }

        [SwaggerOperation(Summary = "Deletes an user", Description = "Deletes an user with provided id")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "User deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
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
