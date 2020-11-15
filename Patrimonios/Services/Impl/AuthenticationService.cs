using Microsoft.IdentityModel.Tokens;
using Patrimonios.Entidade;
using Patrimonios.Models;
using Patrimonios.Repositorio.Interfaces;
using Patrimonios.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patrimonios.Services.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        IUsuarioRepositorio usuarioRepositorio;
        public AuthenticationService(IUsuarioRepositorio repositorio)
        {
            usuarioRepositorio = repositorio;
        }
        public AuthViewModel Autenticar(AuthViewModel auth) 
        {
            var usuario = usuarioRepositorio.Get(x => x.Email.ToLowerInvariant().Equals(auth.Email.ToLowerInvariant()));
            if (usuario == null)
            {
                auth.Erro = "Usuário não encontado";
                return auth;
            }
            if (!usuario.Senha.Equals(auth.Senha))
            {
                auth.Erro = "Senha inválida";
                return auth;
            }
            auth.Token = GenerateToken(usuario);
            return auth;
        }
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "gPvwLhqx3zqFng74JdrtgPvwLhqx3z";
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }

}
