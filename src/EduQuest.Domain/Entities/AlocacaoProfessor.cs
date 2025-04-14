namespace EduQuest.Domain.Entities
{
    public class AlocacaoProfessor
    {
        public int Id { get; set; }

        public int ProfessorId { get; set; }
        public Usuario Professor { get; set; } = default!;

        public int TurmaId { get; set; }
        public Turma Turma { get; set; } = default!;

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; } = default!;

    }
}
