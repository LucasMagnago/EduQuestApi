using EduQuest.Domain.Entities;

namespace EduQuest.Communication.Responses
{
    public class ResponseAlunoJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataUltimoLogin { get; set; }
        public DateTime DataCadastro { get; set; }
        public int XpAtual { get; set; }
        public int Nivel { get; set; }
        public int SaldoMoedas { get; set; }
        public int StreakDiasConsecutivos { get; set; }
        public DateTime DataUltimoAcessoStreak { get; set; }
        public int? TurmaId { get; set; }

        //Está travando a aplicação
        public Turma? Turma { get; set; }
    }
}
