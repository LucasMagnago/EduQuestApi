using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduQuest.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public Guid UsuarioIdentifier { get; set; }
        public DateTime DataUltimoLogin { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        //// 1. Usuario (Criação) ---> Matricula
        //public virtual ICollection<Matricula> MatriculasCriadas { get; set; } = new HashSet<Matricula>();

        //// 2. Usuario (Situação) ---> Matricula
        //public virtual ICollection<Matricula> MatriculasComSituacaoAlterada { get; set; } = new HashSet<Matricula>();

        //// 3. Usuario (Alteração) ---> Matricula
        //public virtual ICollection<Matricula> MatriculasExcluidas { get; set; } = new HashSet<Matricula>();

        // 4. Usuario ---> UsuarioPerfilEscola <--- Escola
        //                        ^
        //                        |
        //                      Perfil
        public virtual ICollection<UsuarioEscolaPerfil> UsuarioEscolaPerfis { get; set; } = new HashSet<UsuarioEscolaPerfil>();

        // 5. Usuario ---> AlocacaoProfessor <--- Turma
        //                        ^
        //                        |
        //                    Disciplina
        public virtual ICollection<AlocacaoProfessor> AlocacaoProfessores { get; set; } = new HashSet<AlocacaoProfessor>();

        // 6. Remetente ---> Mensagem
        [InverseProperty("Remetente")]
        public virtual ICollection<Mensagem> MensagensEnviadas { get; set; } = new List<Mensagem>();

        // 7. Remetente ---> Mensagem
        [InverseProperty("Destinatario")]
        public virtual ICollection<Mensagem> MensagensRecebidas { get; set; } = new List<Mensagem>();
    }
}
