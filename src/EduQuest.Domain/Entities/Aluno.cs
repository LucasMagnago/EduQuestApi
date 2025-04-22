namespace EduQuest.Domain.Entities
{
    public class Aluno : Usuario
    {
        // Não define uma nova chave primária, usa a Id herdada de Usuario.

        public int XpAtual { get; set; }
        public int Nivel { get; set; }
        public int SaldoMoedas { get; set; }
        public int StreakDiasConsecutivos { get; set; }
        public DateTime DataUltimoAcessoStreak { get; set; }

        // 1. Aluno ---> Matricula <--- Turma
        //public virtual ICollection<Matricula> Matriculas { get; set; } = new HashSet<Matricula>();

        // 1. Aluno ---> Turma
        public virtual int? TurmaId { get; set; }
        public virtual Turma? Turma { get; set; } = null!;


        // 2. Aluno ---> AlunoRealizaAtividade <--- Atividade
        public virtual ICollection<AlunoRealizaAtividade> AlunoRealizaAtividades { get; set; } = new HashSet<AlunoRealizaAtividade>();

        // 3. Aluno ---> BatalhaParticipante <--- Batalha
        public virtual ICollection<BatalhaParticipante> BatalhaParticipantes { get; set; } = new HashSet<BatalhaParticipante>();

        // 4. Aluno ---> AlunoPossuiItem <--- Item
        public virtual ICollection<AlunoPossuiItem> AlunoPossuiItens { get; set; } = new HashSet<AlunoPossuiItem>();

        // 5. Aluno ---> AlunoConquista <--- Conquista
        public virtual ICollection<AlunoConquista> AlunoConquistas { get; set; } = new HashSet<AlunoConquista>();

        // 6. Aluno ---> AlunoProgressoDesafio <--- Desafio
        public virtual ICollection<AlunoProgressoDesafio> AlunoProgressoDesafios { get; set; } = new HashSet<AlunoProgressoDesafio>();

        // 7. Aluno ---> AlunoProgressoCondicao <--- Condicao
        public virtual ICollection<AlunoProgressoCondicao> AlunoProgressoCondicoes { get; set; } = new HashSet<AlunoProgressoCondicao>();
    }
}
