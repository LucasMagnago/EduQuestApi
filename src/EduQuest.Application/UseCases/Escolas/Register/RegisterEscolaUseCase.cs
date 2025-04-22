using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Escolas.Register
{
    internal class RegisterEscolaUseCase : IRegisterEscolaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEscolaRepository _escolaRepository;
        private readonly ITipoUnidadeRepository _tipoUnidadeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterEscolaUseCase(IMapper mapper,
            IEscolaRepository escolaRepository,
            ITipoUnidadeRepository tipoUnidadeRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _escolaRepository = escolaRepository;
            _tipoUnidadeRepository = tipoUnidadeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredEscolaJson> Execute(RequestRegisterEscolaJson request)
        {
            await Validate(request);

            var escola = _mapper.Map<Escola>(request);
            escola.ativo = true;

            await _escolaRepository.SaveAsync(escola);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredEscolaJson>(escola);
        }

        private async Task Validate(RequestRegisterEscolaJson request)
        {
            var result = new RegisterEscolaValidator().Validate(request);

            bool existsTipoEscola = await _tipoUnidadeRepository.ExistsWithIdAsync(request.TipoUnidadeId);
            if (!existsTipoEscola)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O tipo de escola informado não existe"));
            }

            bool existsEscolaWithNome = await _escolaRepository.ExistsWithNomeAsync(request.Nome);
            if (existsEscolaWithNome)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O nome da escola já existe"));
            }

            bool existsEscolaWithSigla = await _escolaRepository.ExistsWithSiglaAsync(request.Sigla);
            if (existsEscolaWithSigla)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A sigla informada está em uso"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
