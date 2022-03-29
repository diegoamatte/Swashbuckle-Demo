using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Swashbuckle.Models
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// The user name.
        /// </summary>
        /// <example>John Doe</example>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Email address
        /// </summary>
        /// <example>johndoe@mail.com</example>
        public string Email { get; set; }

        [SwaggerSchema("The URL where the image is hosted")]
        [SwaggerSchemaExample("htps://blog.makingsense.com/wp-content/authors/Making%20Sense-170.jpg")]
        public string ProfilePictureUrl { get; set; }
    }
}
