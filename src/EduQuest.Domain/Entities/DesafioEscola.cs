namespace EduQuest.Domain.Entities
{
    public class DesafioEscola
    {
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; } = default!;
        public int EscolaId { get; set; }
        public Escola Escola { get; set; } = default!;
    }
}
