﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SenaiNotas.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };
            string tokencode = Environment.GetEnvironmentVariable("tokencode");

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokencode)); //colcoar no key vault

            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: "senainotes",
                audience: "senainotes",
                claims: claims,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
