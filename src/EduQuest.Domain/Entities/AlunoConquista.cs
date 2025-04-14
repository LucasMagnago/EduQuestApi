namespace EduQuest.Domain.Entities
{
    public class AlunoConquista
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;
        public int ConquistaId { get; set; }
        public Conquista Conquista { get; set; } = default!;
        public DateTime DataObtencao { get; set; }
    }
}
