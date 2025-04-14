namespace EduQuest.Domain.Entities
{
    public class UsuarioPerfilEscola
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; } = null!;

        public int EscolaId { get; set; }
        public Escola Escola { get; set; } = null!;


    }
}
