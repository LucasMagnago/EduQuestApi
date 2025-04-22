using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Alunos.GetTurmaByAlunoId
{
    internal class GetTurmaByAlunoId : IGetTurmaByAlunoId
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetTurmaByAlunoId(IAlunoRepository alunoRepository,
            IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTurmaJson> Execute(int alunoId)
        {
            var turma = await _alunoRepository.GetTurmaByAlunoId(alunoId);

            if (turma is null)
                throw new NotFoundException("Aluno não está matrículado");

            return _mapper.Map<ResponseTurmaJson>(turma);

        }
    }
}
