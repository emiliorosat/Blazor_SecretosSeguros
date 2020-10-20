
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using secretsVaul.Models;
using System.Linq;

namespace secretsVaul.Services
{
    public interface ISecretService
    {
        Task<bool> AddSecret(Secret secre);
        Task<List<Secret>> GetAllMySecret(Guid uid);
        Task<Secret> GetASecret(Guid sid);
        Task<Coord> GetCoord(Guid cid);
    }

    public class SecretService : ISecretService
    {
        DataContext db = new DataContext();
        public Task<bool> AddSecret(Secret secre)
        {
            bool status = false;
            try{
                db.Secrets.Add(secre);
                db.SaveChanges();
                status = true;
            }catch(Exception){
                status = false;
            }

            return Task.FromResult(status);
            
        }

        public Task<List<Secret>> GetAllMySecret(Guid uid)
        {
            List<Secret> secrets = db.Secrets.Where(ui => ui.UserId.Equals(uid)).ToList<Secret>();
            return Task.FromResult(secrets);
        }

        public Task<Secret> GetASecret(Guid sid)
        {
            Secret secret = db.Secrets.Where(s => s.Id.Equals(sid)).FirstOrDefault();
            return Task.FromResult(secret);
        }

        public Task<Coord> GetCoord(Guid cid)
        {
            Coord coord = db.Coords.Where(c => c.SecretId.Equals(cid)).FirstOrDefault();
            return Task.FromResult(coord);
        }
    }
}