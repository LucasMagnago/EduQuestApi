using AutoMapper;
using EduQuest.Application.UseCases.Cursos.GetAll;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Disciplinas.GetAll
{
    public class GetAllDisciplinaUseCase : IGetAllDisciplinaUseCase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;

        public GetAllDisciplinaUseCase(IDisciplinaRepository disciplinaRepository,
            IMapper mapper)
        {
            _disciplinaRepository = disciplinaRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseDisciplinaJson>> Execute()
        {
            var result = await _disciplinaRepository.GetAllAsync();

            if (result is null)
                throw new NotFoundException("Disciplinas não encontradas");

            return _mapper.Map<List<ResponseDisciplinaJson>>(result);
        }
    }
}
