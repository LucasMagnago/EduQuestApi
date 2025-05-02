using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Escolas.GetById
{
    public class GetEscolaByIdUseCase : IGetEscolaByIdUseCase
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IMapper _mapper;

        public GetEscolaByIdUseCase(IEscolaRepository escolaRepository,
            IMapper mapper)
        {
            _escolaRepository = escolaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseEscolaJson> Execute(int id)
        {
            var result = await _escolaRepository.GetEscolaWithRelationsByIdAsync(id);

            if (result is null)
                throw new NotFoundException("Escola não encontrada");

            return _mapper.Map<ResponseEscolaJson>(result);
        }
    }
}
