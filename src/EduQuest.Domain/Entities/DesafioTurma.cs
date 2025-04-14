namespace EduQuest.Domain.Entities
{
    public class DesafioTurma
    {
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; } = default!;
        public int TurmaId { get; set; }
        public Turma Turma { get; set; } = default!;
    }
}
