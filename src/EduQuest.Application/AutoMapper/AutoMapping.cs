using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;

namespace EduQuest.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterUsuarioJson, Usuario>()
                .ForMember(entityUsuario => entityUsuario.Senha, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<Usuario, ResponseRegisteredUsuarioJson>();
        }
    }
}

