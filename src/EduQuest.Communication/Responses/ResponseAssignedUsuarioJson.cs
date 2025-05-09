namespace EduQuest.Communication.Responses
{
    public class ResponseAssignedUsuarioJson
    {
        public int UsuarioId { get; set; }
        public int EscolaId { get; set; }
        public int PerfilId { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
