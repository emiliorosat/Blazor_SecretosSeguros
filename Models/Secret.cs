
using System;
using System.ComponentModel.DataAnnotations;

namespace secretsVaul.Models
{
    public class Secret{
        [Key]
        public Guid Id {get; set;}
        public Guid UserId {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public float Value {get; set;}
        public DateTime Date {get; set;}
        public string Place {get; set;}
        public Coord Coordinate {get; set;}
    }

    public class Coord {
        [Key]
        public Guid Id {get; set;}
        public Guid SecretId {get; set;}
        public float Latitude {get; set;}
        public float Longitude {get; set;}
    }
}