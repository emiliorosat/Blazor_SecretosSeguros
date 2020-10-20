
using System;
using System.Text.Json;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using secretsVaul.Models;

namespace secretsVaul.Services
{
    public class TokenService : ITokenService
    {
        private string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public string CreateToken(Guid user)
        {
            string token = new JwtBuilder()
            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
            .WithSecret(secret)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
            .AddClaim("UserId", user.ToString())
            .Encode();
            
            return token;
        }

        public string UpdateToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public Token ValidateToken(string token)
        {
            try{
                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                
                string json = decoder.Decode(token, secret, verify: true);
                Token data = JsonSerializer.Deserialize<Token>(json);
                data.status = true;
                data.message = "ok";
                return data;
            }
            catch(TokenExpiredException)
            {
                
                return new Token(){
                    status = false,
                    message = "Token Expirado"
                };
            }
            catch(SignatureVerificationException)
            {
                 return new Token(){
                    status = false,
                    message = "Error Al Leer Token"
                };
            }
        }

    }

   
}