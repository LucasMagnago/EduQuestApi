using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public int Inep { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }

        // 1. Turma ---> Curso
        public int CursoId { get; set; }
        public Curso Curso { get; set; } = null!;

        // 2. Turma ---> PeriodoLetivo
        public int PeriodoLetivoId { get; set; }
        public PeriodoLetivo PeriodoLetivo { get; set; } = null!;

        // 3. Turma ---> Escola
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } = null!;

        // 4. Turma ---> Matricula <--- Aluno
        public virtual ICollection<Matricula> Matriculas { get; set; } = new HashSet<Matricula>();

        // 5. Turma ---> AtividadeTurma <--- Atividade
        public virtual ICollection<AtividadeTurma> AtividadeTurmas { get; set; } = new HashSet<AtividadeTurma>();

        // 6. Usuario ---> AlocacaoProfessor <--- Turma
        //                        ^
        //                        |
        //                    Disciplina
        public virtual ICollection<AlocacaoProfessor> AlocacaoProfessores { get; set; } = new HashSet<AlocacaoProfessor>();

        // 7. Turma ---> DesafioTurma <--- Desafio
        public virtual ICollection<DesafioTurma> DesafioTurmas { get; set; } = new HashSet<DesafioTurma>();
    }
}
