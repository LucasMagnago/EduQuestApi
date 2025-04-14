using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Services.LoggedUser;

namespace EduQuest.Application.UseCases.Usuarios.Profile
{
    public class GetUsuarioProfileUseCase : IGetUsuarioProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public GetUsuarioProfileUseCase(ILoggedUser loggedUser, IMapper mapper)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
        }

        public async Task<ResponseUsuarioProfileJson> Execute()
        {
            var user = await _loggedUser.Get();

            return _mapper.Map<ResponseUsuarioProfileJson>(user);
        }
    }
}
