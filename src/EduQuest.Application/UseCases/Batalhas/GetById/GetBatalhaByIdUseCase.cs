using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Batalhas.GetById
{
    internal class GetBatalhaByIdUseCase : IGetBatalhaByIdUseCase
    {
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IMapper _mapper;

        public GetBatalhaByIdUseCase(IBatalhaRepository batalhaRepository, IMapper mapper)
        {
            _batalhaRepository = batalhaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaJson> Execute(int id)
        {
            var batalha = await _batalhaRepository.GetByIdAsync(id);
            if (batalha == null)
            {
                throw new NotFoundException("Batalha não encontrada");
            }

            // TODO: Verificar se está retornando questões e respostas da batalha

            return _mapper.Map<ResponseBatalhaJson>(batalha);
        }
    }
}
