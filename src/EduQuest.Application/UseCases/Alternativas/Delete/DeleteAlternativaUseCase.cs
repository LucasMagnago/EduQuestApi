
using AutoMapper;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Alternativas.Delete
{
    internal class DeleteAlternativaUseCase : IDeleteAlternativaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAlternativaRepository _alternativaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAlternativaUseCase(IMapper mapper,
            IAlternativaRepository alternativaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _alternativaRepository = alternativaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int alternativaId)
        {
            var alternativa = await _alternativaRepository.GetByIdAsync(alternativaId);
            if (alternativa == null)
            {
                throw new NotFoundException("Alternativa não encontrada");
            }

            await _alternativaRepository.DeleteAsync(alternativa);
            await _unitOfWork.Commit();
        }
    }
}
