using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Turmas.GetById
{
    public class GetTurmaByIdUseCase : IGetTurmaByIdUseCase
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public GetTurmaByIdUseCase(ITurmaRepository turmaRepository,
            IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTurmaJson> Execute(int id)
        {
            var result = await _turmaRepository.GetByIdAsync(id);

            if (result is null)
                throw new NotFoundException("Turma não encontrado");

            return _mapper.Map<ResponseTurmaJson>(result);
        }
    }
}
