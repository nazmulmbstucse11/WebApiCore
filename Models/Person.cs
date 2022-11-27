using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiFirst.Models
{
    public class Person
    {
        [Key]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
