using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Alunos.GetById
{
    internal class GetAlunoById : IGetAlunoById
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAlunoById(IAlunoRepository alunoRepository,
            IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseAlunoJson> Execute(int id)
        {
            var result = await _alunoRepository.GetByIdAsync(id);

            if (result is null)
                throw new NotFoundException("aluno não encontrado");

            return _mapper.Map<ResponseAlunoJson>(result);
        }
    }
}
