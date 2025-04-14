namespace EduQuest.Domain.Entities
{
    public class AlunoPossuiItem
    {
        public int Id { get; set; }
        public DateTime DataAquisicao { get; set; }

        public int AlunoId { get; set; }
        public int ItemId { get; set; }
    }
}
