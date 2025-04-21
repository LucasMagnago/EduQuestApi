using EduQuest.Domain.Entities;
using EduQuest.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduQuest.Infrastructure.Security.Tokens
{
    public class JwtTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _expirationTimeInMinutes;
        private readonly string _signingKey;

        public JwtTokenGenerator(uint expirationTimeInMinutes, string signingKey)
        {
            _expirationTimeInMinutes = expirationTimeInMinutes;
            _signingKey = signingKey;
        }

        public string Generate(Usuario usuario,
            Matricula matricula,
            List<UsuarioEscolaPerfil> perfis
            )
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Sid, usuario.UsuarioIdentifier.ToString()),
            };

            if (matricula != null)
            {
                claims.Add(new Claim("matricula", matricula.Id.ToString()));
            }

            foreach (var perfil in perfis)
            {
                claims.Add(new Claim(ClaimTypes.Role, $"{perfil.EscolaId}:{perfil.PerfilId}"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
        }
    }
}
