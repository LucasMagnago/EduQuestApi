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
            Turma? turma = null,
            List<UsuarioEscolaPerfil>? perfis = null
            )
        {
            if (usuario is null)
                throw new ArgumentNullException(nameof(usuario), "Erro ao gerar token");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Sid, usuario.UsuarioIdentifier.ToString()),
            };

            // Verifica se é aluno ou servidor e adiciona a claim 'tipo'
            if (usuario is Aluno)
            {
                claims.Add(new Claim("tipoUsuario", "aluno"));

                if (turma is not null)
                    claims.Add(new Claim("turma", turma.Id.ToString()));
            }
            else
            {
                claims.Add(new Claim("tipoUsuario", "servidor"));

                //var perfisValidos = perfis?.Where(p => p is not null) ?? Enumerable.Empty<UsuarioEscolaPerfil>();
                //claims.AddRange(perfisValidos.Select(p =>
                //    new Claim(ClaimTypes.Role, $"{p.EscolaId}:{p.PerfilId}")));
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
