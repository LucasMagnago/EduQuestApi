namespace EduQuest.Communication.Responses
{
    public class ResponseUnassignedUsuarioJson
    {
        public int UsuarioId { get; set; }
        public int EscolaId { get; set; }
        public int PerfilId { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
