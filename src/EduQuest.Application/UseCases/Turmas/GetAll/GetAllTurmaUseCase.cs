using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Turmas.GetAll
{
    public class GetAllTurmaUseCase : IGetAllTurmaUseCase
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public GetAllTurmaUseCase(ITurmaRepository turmaRepository,
        IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseTurmaJson>> Execute()
        {
            var result = await _turmaRepository.GetAllAsync();

            if (result is null)
                throw new NotFoundException("Turmas não encontradas");

            return _mapper.Map<List<ResponseTurmaJson>>(result);
        }
    }
}
