
namespace secretsVaul.Models
{
     public class Token
    {
        public string UserId {get; set;}
        public int exp {get; set;}
        public bool status {get; set;}
        public string message {get; set;}
    }
}