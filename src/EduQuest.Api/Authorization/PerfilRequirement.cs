using Microsoft.AspNetCore.Authorization;

namespace EduQuest.Api.Authorization
{
    public class PerfilRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> AllowedPerfis { get; }

        public PerfilRequirement(IEnumerable<string> allowedRoles)
        {
            AllowedPerfis = allowedRoles.Select(p => p.ToLower());
        }
    }
}
