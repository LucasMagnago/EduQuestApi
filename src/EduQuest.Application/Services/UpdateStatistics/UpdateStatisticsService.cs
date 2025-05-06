using EduQuest.Domain.Repositories;
using EduQuest.Domain.Services.UpdateStatistics;

namespace EduQuest.Application.Services.UpdateStatistics
{
    internal class UpdateStatisticsService : IUpdateStatisticsService
    {
        private readonly IAlunoRepository _alunoRepo;
        private readonly IAlunoEstatisticaRepository _alunoEstatRepo;
        private readonly ITurmaEstatisticaRepository _turmaEstatRepo;
        private readonly IEscolaEstatisticaRepository _escolaEstatRepo;

        public UpdateStatisticsService(
            IAlunoRepository alunoRepo,
            IAlunoEstatisticaRepository alunoEstatRepo,
            ITurmaEstatisticaRepository turmaEstatRepo,
            IEscolaEstatisticaRepository escolaEstatRepo)
        {
            _alunoRepo = alunoRepo;
            _alunoEstatRepo = alunoEstatRepo;
            _turmaEstatRepo = turmaEstatRepo;
            _escolaEstatRepo = escolaEstatRepo;
        }


        public Task UpdateAlunoStatistics(int alunoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEscolaStatistics(int escolaId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTurmaStatistics(int turmaId)
        {
            throw new NotImplementedException();
        }
    }
}
