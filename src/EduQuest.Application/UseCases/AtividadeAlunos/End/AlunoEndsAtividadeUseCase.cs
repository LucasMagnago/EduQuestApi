using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AtividadeAlunos.End
{
    internal class AlunoEndsAtividadeUseCase : IAlunoEndsAtividadeUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeAlunoRepository _atividadeAlunoRepository;
        readonly IAtividadeRepository _atividadeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private IAtividadeTurmaRepository _atividadeTurmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AlunoEndsAtividadeUseCase(IMapper mapper,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IAlunoRepository alunoRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAtividadeAlunoJson> Execute(RequestAlunoEndsAtividadeJson request)
        {
            var aluno = await _alunoRepository.GetByIdAsync(request.AlunoId);
            var atividade = await _atividadeRepository.GetByIdAsync(request.AtividadeId);
            var atividadeAluno = await _atividadeAlunoRepository.GetByAlunoIdAndAtividadeId(request.AlunoId, request.AtividadeId);

            await Validate(aluno, atividade, atividadeAluno);

            atividadeAluno!.XpGanho = atividade!.XpRecompensa;
            atividadeAluno.MoedasGanhas = atividade.MoedasRecompensa;
            atividadeAluno.PontuacaoObtida = 99; // Implementar
            atividadeAluno.Status = StatusAtividade.Enviada;
            atividadeAluno.DataFim = DateTime.Now;


            aluno!.XpAtual += atividade.XpRecompensa;
            aluno.SaldoMoedas += atividade.MoedasRecompensa;

            await _alunoRepository.UpdateAsync(aluno);
            await _atividadeAlunoRepository.UpdateAsync(atividadeAluno);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAtividadeAlunoJson>(atividadeAluno);
        }


        private async Task Validate(Aluno? aluno, Atividade? atividade, AtividadeAluno? atividadeAluno)
        {
            var errors = new List<string>();

            if (aluno == null)
            {
                throw new NotFoundException("Aluno não encontrado.");
            }
            if (atividade == null)
            {
                throw new NotFoundException("Atividade não encontrada.");
            }
            if (atividadeAluno == null)
            {
                throw new NotFoundException("O aluno informado não iniciou esta atividade.");
            }

            if (aluno.TurmaId == null)
            {
                errors.Add("O aluno não está matriculado em nenhuma turma.");
            }

            if (atividadeAluno.Status == StatusAtividade.Enviada)
            {
                errors.Add("A atividade já foi enviada anteriormente.");
            }

            var dataEntrega = await _atividadeTurmaRepository.GetDataEntregaAtividade(atividade.Id, (int)aluno.TurmaId!);
            if (dataEntrega < DateTime.Now)
            {
                errors.Add("A atividade já foi encerrada e não pode mais ser enviada.");
            }

            if (errors.Count != 0)
            {
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
