using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        // Relacionamento com Turma
        public virtual int? TurmaId { get; set; }
        public virtual Turma? Turma { get; set; } = null!;


        // Relacionamento com AtividadeAluno (atividades atribuídas ao aluno)
        [JsonIgnore]
        public virtual ICollection<AtividadeAluno> AtividadeAlunos { get; set; } = new HashSet<AtividadeAluno>();

        // Relacionamento com Batalha (um aluno pode participar de várias batalhas)
        // Coleção de batalhas onde este aluno foi o 'AlunoA'
        [InverseProperty("AlunoA")] // Liga esta coleção à propriedade AlunoA na classe Batalha
        [JsonIgnore]
        public virtual ICollection<Batalha> BatalhasAsAlunoA { get; set; } = new HashSet<Batalha>();

        // Relacionamento com Batalha (um aluno pode participar de várias batalhas)
        [InverseProperty("AlunoB")] // Liga esta coleção à propriedade AlunoB na classe Batalha
        [JsonIgnore]
        public virtual ICollection<Batalha> BatalhasAsAlunoB { get; set; } = new HashSet<Batalha>();

        // Todas as batalhas juntas 
        [NotMapped]
        [JsonIgnore]
        public IEnumerable<Batalha> AllBatalhas => BatalhasAsAlunoA.Concat(BatalhasAsAlunoB);

        // Relacionamento com AlunoPossuiItem (itens do aluno)
        [JsonIgnore]
        public virtual ICollection<AlunoPossuiItem> AlunoPossuiItens { get; set; } = new HashSet<AlunoPossuiItem>();

        // Relacionamento com AlunoConquista (conquistas do aluno)
        [JsonIgnore]
        public virtual ICollection<AlunoConquista> AlunoConquistas { get; set; } = new HashSet<AlunoConquista>();

        // Relacionamento com AlunoProgressoDesafio (desafios que o aluno está progredindo)
        [JsonIgnore]
        public virtual ICollection<AlunoProgressoDesafio> AlunoProgressoDesafios { get; set; } = new HashSet<AlunoProgressoDesafio>();

        // Relacionamento com AlunoProgressoCondicao (condições do aluno em desafios)
        [JsonIgnore]
        public virtual ICollection<AlunoProgressoCondicao> AlunoProgressoCondicoes { get; set; } = new HashSet<AlunoProgressoCondicao>();
    }
}
