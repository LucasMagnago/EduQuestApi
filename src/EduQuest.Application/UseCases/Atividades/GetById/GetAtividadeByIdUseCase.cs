using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Atividades.GetById
{
    internal class GetAtividadeByIdUseCase : IGetAtividadeByIdUseCase
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public GetAtividadeByIdUseCase(IAtividadeRepository atividadeRepository,
            IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }

        public async Task<ResponseAtividadeJson> Execute(int id)
        {
            var result = await _atividadeRepository.GetByIdAsync(id);

            if (result is null)
                throw new NotFoundException("Atividade não encontrada");

            return _mapper.Map<ResponseAtividadeJson>(result);
        }
    }
}
