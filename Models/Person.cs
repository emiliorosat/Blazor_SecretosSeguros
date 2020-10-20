
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secretsVaul.Models
{
    public class Person{
        [Key]
        public Guid UserId {get; set;}
        public string Document {get; set;}
        public string Name {get; set;}
        public string LastName {get; set;}
        public string Image {get; set;}
        public virtual ICollection<Secret> Secrets {get; set;}
    }
}