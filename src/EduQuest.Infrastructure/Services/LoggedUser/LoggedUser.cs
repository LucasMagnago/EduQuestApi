using EduQuest.Domain.Entities;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Domain.Services.LoggedUser;
using EduQuest.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EduQuest.Infrastructure.Services.LoggedUser
{
    internal class LoggedUser : ILoggedUser
    {
        private readonly EduQuestDbContext _context;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(EduQuestDbContext context, ITokenProvider tokenProvider)
        {
            _context = context;
            _tokenProvider = tokenProvider;
        }

        public async Task<Usuario> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _context
                .Usuarios
                .AsNoTracking()
                .FirstAsync(usuario => usuario.UsuarioIdentifier == Guid.Parse(identifier));
        }
    }
}
