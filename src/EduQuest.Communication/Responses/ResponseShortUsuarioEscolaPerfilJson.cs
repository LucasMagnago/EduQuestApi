namespace EduQuest.Communication.Responses
{
    public class ResponseShortUsuarioEscolaPerfilJson
    {
        public ResponseShortUsuarioJson Usuario { get; set; } = null!;
        public ResponseShortEscolaJson Escola { get; set; } = null!;
        public ResponseShortPerfilJson Perfil { get; set; } = null!;
    }
}
