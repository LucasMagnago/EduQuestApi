using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public Guid UsuarioIdentifier { get; set; }
        public DateTime DataUltimoLogin { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        // Matrículas que este usuário criou
        public virtual ICollection<Matricula> MatriculasCriadas { get; set; } = new HashSet<Matricula>();

        // Matrículas cuja situação foi alterada por último por este usuário
        public virtual ICollection<Matricula> MatriculasComSituacaoAlterada { get; set; } = new HashSet<Matricula>();

        // Matrículas que este usuário excluiu (logicamente)
        public virtual ICollection<Matricula> MatriculasExcluidas { get; set; } = new HashSet<Matricula>();
    }
}
