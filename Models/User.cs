
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secretsVaul.Models
{
    public class User
    {
        [Key]
        public Guid Id {get; set;}
        public string Document {get; set;}
        public string Password {get; set;}
    }
}