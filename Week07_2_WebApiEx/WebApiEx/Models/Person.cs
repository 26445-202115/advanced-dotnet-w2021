using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEx.Models
{
    public class Person
    {
        [Key]
        public Guid Id  { get; set; }
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)] 
        public string LastName { get; set; }
        [Required]
        public DateTimeOffset CreationTime { get; set; }
    }
}
