using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Conquistas.GetById
{
    internal class GetConquistaByIdUseCase : IGetConquistaByIdUseCase
    {
        private readonly IConquistaRepository _conquistaRepository;
        private readonly IUnitOfWork _uniUnitOfWork;
        private readonly IMapper _mapper;

        public GetConquistaByIdUseCase(IConquistaRepository conquistaRepository, IUnitOfWork uniUnitOfWork, IMapper mapper)
        {
            _conquistaRepository = conquistaRepository;
            _uniUnitOfWork = uniUnitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseConquistaJson> Execute(int conquistaId)
        {
            var conquista = await _conquistaRepository.GetByIdAsync(conquistaId);
            if (conquista is null)
                throw new NotFoundException("Conquista não encontrada");

            return _mapper.Map<ResponseConquistaJson>(conquista);
        }
    }
}
