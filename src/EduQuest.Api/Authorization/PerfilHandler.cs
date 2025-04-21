using EduQuest.Api.Authorization;
using EduQuest.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class PerfilHandler : AuthorizationHandler<PerfilRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;

    public PerfilHandler(IHttpContextAccessor httpContextAccessor,
        IAlunoRepository alunoRepository,
        IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _alunoRepository = alunoRepository;
        _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PerfilRequirement requirement)
    {
        // 1. Pega o ID do usuário logado (vem do token JWT)
        var usuarioIdClaim = context.User.FindFirst(ClaimTypes.Sid);
        if (usuarioIdClaim == null)
            return;

        var userId = Guid.Parse(usuarioIdClaim.Value);

        var routeData = _httpContextAccessor.HttpContext?.GetRouteData();

        //if (routeData == null || !routeData.Values.TryGetValue("escolaId", out var escolaIdObj))
        //    return;

        //if (!Guid.TryParse(escolaIdObj.ToString(), out var escolaId))
        //    return;

        List<string> perfis = new List<string>();

        // 2. Busca os perfis do usuário
        var usuarioEscolaPerfis = await _usuarioEscolaPerfilRepository.GetAllByUsuarioGuidAsync(userId);

        foreach (var usuarioEscolaPerfil in usuarioEscolaPerfis)
            perfis.Add(usuarioEscolaPerfil.Perfil.Nome.ToLower());

        // 3. Verifica se é aluno
        bool isAluno = await _alunoRepository.ExistAlunoWithUsuarioGuid(userId);
        if (isAluno)
        {
            perfis.Add("aluno");
        }

        /// 4. Verifica se algum perfil do usuário está na lista permitida
        if (perfis.Intersect(requirement.AllowedPerfis).Any())
        {
            context.Succeed(requirement);
        }
    }
}
