using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Services.UpdateStatistics;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.Services.UpdateStatistics
{
    internal class UpdateStatisticsService : IUpdateStatisticsService
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAtividadeAlunoRepository _atividadeAlunoRepository;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IAlunoEstatisticaRepository _alunoEstatisticsRepository;
        private readonly ITurmaEstatisticaRepository _turmaEstatisticsRepository;
        private readonly IEscolaEstatisticaRepository _escolaEstatisticsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatisticsService(
            IAtividadeRepository atividadeRepository,
            IAlunoRepository alunoRepository,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IBatalhaRepository batalhaRepository,
            IAlunoEstatisticaRepository alunoEstatRepo,
            ITurmaEstatisticaRepository turmaEstatRepo,
            IEscolaEstatisticaRepository escolaEstatRepo,
            IUnitOfWork unitOfWork)
        {
            _atividadeRepository = atividadeRepository;
            _alunoRepository = alunoRepository;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _batalhaRepository = batalhaRepository;
            _alunoEstatisticsRepository = alunoEstatRepo;
            _turmaEstatisticsRepository = turmaEstatRepo;
            _escolaEstatisticsRepository = escolaEstatRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateAlunoStatisticsInBatalhas(int batalhaId)
        {
            var batalha = await _batalhaRepository.GetByIdAsync(batalhaId)
                ?? throw new NotFoundException("Batalha não encontrada.");

            if (batalha.AlunoAId is null || batalha.AlunoBId is null)
                throw new NotFoundException("Um ou mais alunos não foram encontrados.");

            var alunoA = await _alunoRepository.GetByIdAsync(batalha.AlunoAId.Value)
                ?? throw new NotFoundException("Aluno A não encontrado.");

            var alunoB = await _alunoRepository.GetByIdAsync(batalha.AlunoBId.Value)
                ?? throw new NotFoundException("Aluno B não encontrado.");

            var statisticsAlunoA = await _alunoEstatisticsRepository.GetByIdAsync(alunoA.Id) ?? new AlunoEstatistica() { AlunoId = alunoA.Id };
            var statisticsAlunoB = await _alunoEstatisticsRepository.GetByIdAsync(alunoB.Id) ?? new AlunoEstatistica() { AlunoId = alunoB.Id }; ;

            statisticsAlunoA.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoAId ? statisticsAlunoA.TotalVitoriasInBatalhas + 1 : statisticsAlunoA.TotalVitoriasInBatalhas;
            statisticsAlunoA.TotalParticipacoesInBatalhas++;
            statisticsAlunoA.UltimaAtualizacao = DateTime.Now;

            statisticsAlunoB.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoBId ? statisticsAlunoB.TotalVitoriasInBatalhas + 1 : statisticsAlunoB.TotalVitoriasInBatalhas;
            statisticsAlunoB.TotalParticipacoesInBatalhas++;
            statisticsAlunoB.UltimaAtualizacao = DateTime.Now;


            await _alunoEstatisticsRepository.UpdateAsync(statisticsAlunoA);
            await _alunoEstatisticsRepository.UpdateAsync(statisticsAlunoB);
            await _unitOfWork.Commit();
        }

        public async Task UpdateTurmaStatisticsInBatalhas(int batalhaId)
        {
            var batalha = await _batalhaRepository.GetByIdAsync(batalhaId)
                ?? throw new NotFoundException("Batalha não encontrada.");

            if (batalha.AlunoAId is null || batalha.AlunoBId is null)
                throw new NotFoundException("Um ou mais alunos não foram encontrados.");

            var turmaAlunoA = await _alunoRepository.GetTurmaByAlunoId(batalha.AlunoAId.Value);
            if (turmaAlunoA is not null)
            {
                var statisticsTurmaA = await _turmaEstatisticsRepository.GetByIdAsync(turmaAlunoA.Id) ?? new TurmaEstatistica() { TurmaId = turmaAlunoA.Id };

                statisticsTurmaA.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoAId ? statisticsTurmaA.TotalVitoriasInBatalhas + 1 : statisticsTurmaA.TotalVitoriasInBatalhas;
                statisticsTurmaA.TotalParticipacoesInBatalhas++;
                statisticsTurmaA.UltimaAtualizacao = DateTime.Now;

                await _turmaEstatisticsRepository.UpdateAsync(statisticsTurmaA);
            }

            var turmaAlunoB = await _alunoRepository.GetTurmaByAlunoId(batalha.AlunoBId.Value);
            if (turmaAlunoB is not null)
            {
                var statisticsTurmaB = await _turmaEstatisticsRepository.GetByIdAsync(turmaAlunoB.Id) ?? new TurmaEstatistica() { TurmaId = turmaAlunoB.Id };

                statisticsTurmaB.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoBId ? statisticsTurmaB.TotalVitoriasInBatalhas + 1 : statisticsTurmaB.TotalVitoriasInBatalhas;
                statisticsTurmaB.TotalParticipacoesInBatalhas++;
                statisticsTurmaB.UltimaAtualizacao = DateTime.Now;


                await _turmaEstatisticsRepository.UpdateAsync(statisticsTurmaB);
            }

            await _unitOfWork.Commit();
        }

        public async Task UpdateEscolaStatisticsInBatalhas(int batalhaId)
        {
            var batalha = await _batalhaRepository.GetByIdAsync(batalhaId)
                ?? throw new NotFoundException("Batalha não encontrada.");

            if (batalha.AlunoAId is null || batalha.AlunoBId is null)
                throw new NotFoundException("Um ou mais alunos não foram encontrados.");

            var escolaAlunoA = await _alunoRepository.GetEscolaByAlunoId(batalha.AlunoAId.Value);
            if (escolaAlunoA is not null)
            {
                var statisticsEscolaA = await _escolaEstatisticsRepository.GetByIdAsync(escolaAlunoA.Id) ?? new EscolaEstatistica() { EscolaId = escolaAlunoA.Id };

                statisticsEscolaA.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoAId ? statisticsEscolaA.TotalVitoriasInBatalhas + 1 : statisticsEscolaA.TotalVitoriasInBatalhas;
                statisticsEscolaA.TotalParticipacoesInBatalhas++;
                statisticsEscolaA.UltimaAtualizacao = DateTime.Now;

                await _escolaEstatisticsRepository.UpdateAsync(statisticsEscolaA);
            }

            var escolaAlunoB = await _alunoRepository.GetEscolaByAlunoId(batalha.AlunoBId.Value);
            if (escolaAlunoB is not null)
            {
                var statisticsEscolaB = await _escolaEstatisticsRepository.GetByIdAsync(escolaAlunoB.Id) ?? new EscolaEstatistica() { EscolaId = escolaAlunoB.Id };

                statisticsEscolaB.TotalVitoriasInBatalhas = batalha.AlunoVencedorId == batalha.AlunoBId ? statisticsEscolaB.TotalVitoriasInBatalhas + 1 : statisticsEscolaB.TotalVitoriasInBatalhas;
                statisticsEscolaB.TotalParticipacoesInBatalhas++;
                statisticsEscolaB.UltimaAtualizacao = DateTime.Now;

                await _escolaEstatisticsRepository.UpdateAsync(statisticsEscolaB);
            }

            await _unitOfWork.Commit();
        }

        public async Task UpdateAlunoStatisticsInAtividades(int atividadeAlunoId)
        {
            var atividadeAluno = await _atividadeAlunoRepository.GetByIdAsync(atividadeAlunoId)
        ?? throw new NotFoundException("Atividade do aluno não encontrada.");

            var aluno = await _alunoRepository.GetByIdAsync(atividadeAluno.AlunoId)
                ?? throw new NotFoundException("Aluno não encontrado.");

            var atividade = await _atividadeRepository.GetByIdAsync(atividadeAluno.AtividadeId)
                ?? throw new NotFoundException("Atividade não encontrada.");

            var statisticsAluno = await _alunoEstatisticsRepository.GetByIdAsync(aluno.Id)
                ?? new AlunoEstatistica() { AlunoId = aluno.Id };

            // Normaliza a pontuação para escala de 0 a 10
            double notaObtida = atividadeAluno.PontuacaoObtida ?? 0.0;
            double valorMaximo = atividade.Valor > 0 ? atividade.Valor : 10.0; // evitar divisão por zero
            double notaNormalizada = (notaObtida / valorMaximo) * 10.0;

            // Atualiza estatísticas
            statisticsAluno.AtividadesConcluidas++;

            double totalNotasAnteriores = statisticsAluno.MediaNotasNormalizadas * statisticsAluno.QuantidadeNotasValidas;

            statisticsAluno.QuantidadeNotasValidas++;
            statisticsAluno.MediaNotasNormalizadas = (totalNotasAnteriores + notaNormalizada) / statisticsAluno.QuantidadeNotasValidas;

            statisticsAluno.UltimaAtualizacao = DateTime.UtcNow;

            await _alunoEstatisticsRepository.UpdateAsync(statisticsAluno);
            await _unitOfWork.Commit();
        }

        public async Task UpdateTurmaStatisticsInAtividades(int atividadeAlunoId)
        {
            var atividadeAluno = await _atividadeAlunoRepository.GetByIdAsync(atividadeAlunoId)
        ?? throw new NotFoundException("Atividade do aluno não encontrada.");

            var atividade = await _atividadeRepository.GetByIdAsync(atividadeAluno.AtividadeId)
                ?? throw new NotFoundException("Atividade não encontrada.");

            var turma = await _alunoRepository.GetTurmaByAlunoId(atividadeAluno.AlunoId);
            if (turma is not null)
            {
                var statisticsTurma = await _turmaEstatisticsRepository.GetByIdAsync(turma.Id)
                ?? new TurmaEstatistica() { TurmaId = turma.Id };

                // Normaliza a pontuação para escala de 0 a 10
                double notaObtida = atividadeAluno.PontuacaoObtida ?? 0.0;
                double valorMaximo = atividade.Valor > 0 ? atividade.Valor : 10.0; // evitar divisão por zero
                double notaNormalizada = (notaObtida / valorMaximo) * 10.0;

                // Atualiza estatísticas
                statisticsTurma.AtividadesConcluidas++;

                double totalNotasAnteriores = statisticsTurma.MediaNotasNormalizadas * statisticsTurma.QuantidadeNotasValidas;

                statisticsTurma.QuantidadeNotasValidas++;
                statisticsTurma.MediaNotasNormalizadas = (totalNotasAnteriores + notaNormalizada) / statisticsTurma.QuantidadeNotasValidas;

                statisticsTurma.UltimaAtualizacao = DateTime.UtcNow;

                await _turmaEstatisticsRepository.UpdateAsync(statisticsTurma);
                await _unitOfWork.Commit();
            }
        }

        public async Task UpdateEscolaStatisticsInAtividades(int atividadeAlunoId)
        {
            var atividadeAluno = await _atividadeAlunoRepository.GetByIdAsync(atividadeAlunoId)
        ?? throw new NotFoundException("Atividade do aluno não encontrada.");

            var atividade = await _atividadeRepository.GetByIdAsync(atividadeAluno.AtividadeId)
                ?? throw new NotFoundException("Atividade não encontrada.");

            var escola = await _alunoRepository.GetEscolaByAlunoId(atividadeAluno.AlunoId);
            if (escola is not null)
            {
                var statisticsEscola = await _escolaEstatisticsRepository.GetByIdAsync(escola.Id)
                ?? new EscolaEstatistica() { EscolaId = escola.Id };

                // Normaliza a pontuação para escala de 0 a 10
                double notaObtida = atividadeAluno.PontuacaoObtida ?? 0.0;
                double valorMaximo = atividade.Valor > 0 ? atividade.Valor : 10.0; // evitar divisão por zero
                double notaNormalizada = (notaObtida / valorMaximo) * 10.0;

                // Atualiza estatísticas
                statisticsEscola.AtividadesConcluidas++;

                double totalNotasAnteriores = statisticsEscola.MediaNotasNormalizadas * statisticsEscola.QuantidadeNotasValidas;

                statisticsEscola.QuantidadeNotasValidas++;
                statisticsEscola.MediaNotasNormalizadas = (totalNotasAnteriores + notaNormalizada) / statisticsEscola.QuantidadeNotasValidas;

                statisticsEscola.UltimaAtualizacao = DateTime.UtcNow;

                await _escolaEstatisticsRepository.UpdateAsync(statisticsEscola);
                await _unitOfWork.Commit();
            }
        }
    }
}
