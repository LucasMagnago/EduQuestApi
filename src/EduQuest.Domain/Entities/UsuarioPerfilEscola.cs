namespace EduQuest.Domain.Entities
{
    public class UsuarioEscolaPerfil
    {
        // 1. Usuario ---> UsuarioPerfilEscola <--- Escola
        //                        ^
        //                        |
        //                      Perfil

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; } = null!;

        public int EscolaId { get; set; }
        public virtual Escola Escola { get; set; } = null!;

        public bool Ativo { get; set; }
    }
}
