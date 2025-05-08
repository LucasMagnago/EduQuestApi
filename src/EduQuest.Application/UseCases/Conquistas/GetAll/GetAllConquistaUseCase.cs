using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Conquistas.GetAll
{
    internal class GetAllConquistaUseCase : IGetAllConquistaUseCase
    {
        private readonly IConquistaRepository _conquistaRepository;
        private readonly IMapper _mapper;

        public GetAllConquistaUseCase(IConquistaRepository conquistaRepository, IUnitOfWork uniUnitOfWork, IMapper mapper)
        {
            _conquistaRepository = conquistaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseConquistaJson>> Execute()
        {
            var conquistas = await _conquistaRepository.GetAllAsync();
            if (conquistas is null || !conquistas.Any())
                throw new NotFoundException("Conquistas não encontradas");

            return conquistas.Select(c => _mapper.Map<ResponseConquistaJson>(c)).ToList();
        }
    }
}
