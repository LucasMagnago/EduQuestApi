using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AlunoConquistas.GetAllByAlunoId
{
    internal class GetAllConquistaByAlunoIdUseCase : IGetAllConquistaByAlunoIdUseCase
    {
        private readonly IAlunoConquistaRepository _alunoConquistaRepository;
        private readonly IMapper _mapper;

        public GetAllConquistaByAlunoIdUseCase(IAlunoConquistaRepository alunoConquistaRepository,
            IMapper mapper)
        {
            _alunoConquistaRepository = alunoConquistaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAlunoConquistaJson>> Execute(int conquistaId)
        {
            var conquistas = await _alunoConquistaRepository.GetAllByAlunoId(conquistaId);
            if (conquistas is null)
                throw new NotFoundException("Conquistas não encontradas");

            return conquistas.Select(c => _mapper.Map<ResponseAlunoConquistaJson>(c)).ToList();
        }
    }
}
