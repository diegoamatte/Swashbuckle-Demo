using System.ComponentModel;

namespace Swashbuckle.Models
{
    public class PageParams
    {
        /// <summary>
        /// The page number
        /// </summary>
        /// <example>1</example>
        public int PageNumber { get; set; }
        /// <summary>
        /// Results quantity
        /// </summary>
        /// <example>10</example>
        public int PageSize { get; set; }
    }
}
