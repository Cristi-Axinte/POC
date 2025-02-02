using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace SwaggerPOC.Models
{
    public class Model
    {
        /// <summary>
        /// This is a random string value
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// This is a random string value that should be required
        /// </summary>
        [Required]
        public string ModelStringRequired { get; set; }


        /// <summary>
        /// This is a random integer value
        /// </summary>
        public int ModelValue { get; set; }
    }
}
