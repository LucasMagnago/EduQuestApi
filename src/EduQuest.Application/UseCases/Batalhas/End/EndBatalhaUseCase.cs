using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Services.AssignRewards;
using EduQuest.Domain.Services.UpdateStatistics;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Batalhas.End
{
    internal class EndBatalhaUseCase : IEndBatalhaUseCase
    {
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IBatalhaRespostaRepository _batalhaRespostaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAssignRewardsService _assignRewardsService;
        private readonly IUpdateStatisticsService _updateStatisticsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EndBatalhaUseCase(IBatalhaRepository batalhaRepository,
            IBatalhaRespostaRepository batalhaRespostaRepository,
            IAlunoRepository alunoRepository,
            IAssignRewardsService assignRewardsService,
            IUpdateStatisticsService updateStatisticsService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _batalhaRepository = batalhaRepository;
            _batalhaRespostaRepository = batalhaRespostaRepository;
            _alunoRepository = alunoRepository;
            _assignRewardsService = assignRewardsService;
            _updateStatisticsService = updateStatisticsService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaJson> Execute(RequestEndBatalhaJson request)
        {
            await Validate(request);

            var batalha = await _batalhaRepository.GetByIdAsync(request.BatalhaId);
            batalha!.Status = StatusBatalha.Finalizada;
            batalha.DataFim = DateTime.Now;

            var alunoA = await _alunoRepository.GetByIdAsync((int)batalha.AlunoAId!);
            var alunoB = await _alunoRepository.GetByIdAsync((int)batalha.AlunoBId!);

            if (alunoA is null || alunoB is null)
            {
                throw new NotFoundException("A batalha não pode ser finalizada, pois um ou mais alunos não foram encontrados");

            }

            var acertosAlunoA = await _batalhaRespostaRepository.CountCorrectRespostasForAlunoInBatalhaAsync((int)batalha.AlunoAId!, batalha.Id);
            var acertosAlunoB = await _batalhaRespostaRepository.CountCorrectRespostasForAlunoInBatalhaAsync((int)batalha.AlunoBId!, batalha.Id);

            if (acertosAlunoA > acertosAlunoB)
            {
                batalha.AlunoVencedorId = batalha.AlunoAId;
                alunoA!.SaldoMoedas += batalha.MoedasConcedidasVencedor;
                alunoA.XpAtual += batalha.XpConcedidoVencedor;
            }
            else if (acertosAlunoA < acertosAlunoB)
            {
                batalha.AlunoVencedorId = batalha.AlunoBId;
                alunoB!.SaldoMoedas += batalha.MoedasConcedidasVencedor;
                alunoB.XpAtual += batalha.XpConcedidoVencedor;
            }

            await _alunoRepository.UpdateAsync(alunoA);
            await _alunoRepository.UpdateAsync(alunoB);
            await _batalhaRepository.UpdateAsync(batalha);
            await _unitOfWork.Commit();

            await _assignRewardsService.AssignByBatalha(batalha.Id);
            await _updateStatisticsService.UpdateAlunoStatisticsInBatalhas(batalha.Id);
            await _updateStatisticsService.UpdateTurmaStatisticsInBatalhas(batalha.Id);
            await _updateStatisticsService.UpdateEscolaStatisticsInBatalhas(batalha.Id);

            return _mapper.Map<ResponseBatalhaJson>(batalha);
        }

        public async Task Validate(RequestEndBatalhaJson request)
        {
            var result = new EndBatalhaValidator().Validate(request);

            var batalha = await _batalhaRepository.GetByIdAsync(request.BatalhaId);
            if (batalha == null)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Batalha não encontrada"));
            }

            if (batalha!.Status != StatusBatalha.EmAndamento)
            {
                throw new ConflictException("A batalha não pode ser finalizada devido ao status atual");

            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
