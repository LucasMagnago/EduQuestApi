namespace EduQuest.Domain.Entities
{
    public class AlunoCompletaDesafio
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DesafioId { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
