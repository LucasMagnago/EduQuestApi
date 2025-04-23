using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public bool Ativo { get; set; }
        public int NivelEscolar { get; set; }
        public int Ano { get; set; }

        //// 1. Turma ---> Curso
        //public int CursoId { get; set; }
        //public Curso Curso { get; set; } = null!;

        //// 2. Turma ---> PeriodoLetivo
        //public int PeriodoLetivoId { get; set; }
        //public PeriodoLetivo PeriodoLetivo { get; set; } = null!;

        // 3. Turma ---> Escola
        public virtual int EscolaId { get; set; }
        public virtual Escola Escola { get; set; } = null!;

        //// 4. Turma ---> Matricula <--- Aluno
        //public virtual ICollection<Matricula> Matriculas { get; set; } = new HashSet<Matricula>();

        //// 4. Turma ---> Aluno
        [JsonIgnore]
        public virtual ICollection<Aluno> Alunos { get; set; } = new HashSet<Aluno>();

        // 5. Turma ---> AtividadeTurma <--- Atividade
        [JsonIgnore]
        public virtual ICollection<AtividadeTurma> AtividadeTurmas { get; set; } = new HashSet<AtividadeTurma>();

        // 6. Usuario ---> AlocacaoProfessor <--- Turma
        //                        ^
        //                        |
        //                    Disciplina
        [JsonIgnore]
        public virtual ICollection<AlocacaoProfessor> AlocacaoProfessores { get; set; } = new HashSet<AlocacaoProfessor>();

        // 7. Turma ---> DesafioTurma <--- Desafio
        [JsonIgnore]
        public virtual ICollection<DesafioTurma> DesafioTurmas { get; set; } = new HashSet<DesafioTurma>();
    }
}
