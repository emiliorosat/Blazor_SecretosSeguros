
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using secretsVaul.Models;

namespace secretsVaul.Services
{
    public interface IFetch
    {
        Task<Person> GetDataByDocument(User user);
    }

    public class Fetch : IFetch
    {
        private string Url = "https://api.adamix.net/apec/cedula/";
        private readonly HttpClient client = new HttpClient();
        public async Task<Person> GetDataByDocument(User user)
        {
            string document = user.Document.Trim();
            Person human = new Person(){
                Document = document,
                UserId = user.Id
            };
            try	
                {
                    HttpResponseMessage response = await client.GetAsync(Url + document);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    PersonFetch obj = JsonSerializer.Deserialize<PersonFetch>(responseBody);

                    human.Name = obj.Nombres;
                    human.LastName = obj.Apellidos();
                    human.Image = obj.foto;
                    return human;
                    
                }
            catch(HttpRequestException e)
                {
                    Console.WriteLine("Message :{0} ",e.Message);
                   return human;
                    
                }

        }
    }

    public class PersonFetch
    {
        public string Nombres {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string foto {get; set;}

        public string Apellidos(){
            return Apellido1 + " " + Apellido2;
        }
    }
}