using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Disciplinas.GetById
{
    public class GetDisciplinaByIdUseCase : IGetDisciplinaByIdUseCase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;

        public GetDisciplinaByIdUseCase(IDisciplinaRepository disciplinaRepository,
            IMapper mapper)
        {
            _disciplinaRepository = disciplinaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDisciplinaJson> Execute(int id)
        {
            var result = await _disciplinaRepository.GetByIdAsync(id);

            if (result is null)
                throw new NotFoundException("Disciplina não encontrada");

            return _mapper.Map<ResponseDisciplinaJson>(result);
        }
    }
}
