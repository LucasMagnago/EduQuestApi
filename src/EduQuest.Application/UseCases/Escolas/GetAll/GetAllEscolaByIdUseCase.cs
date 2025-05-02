using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Escolas.GetAll
{
    public class GetAllEscolaUseCase : IGetAllEscolaUseCase
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IMapper _mapper;

        public GetAllEscolaUseCase(IEscolaRepository escolaRepository,
            IMapper mapper)
        {
            _escolaRepository = escolaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseEscolaJson>> Execute()
        {
            var result = await _escolaRepository.GetAllEscolasWithRelationsByIdAsync();

            if (result is null)
                throw new NotFoundException("Escolas não encontradas");

            return _mapper.Map<List<ResponseEscolaJson>>(result);
        }
    }
}
