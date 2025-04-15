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

        // 1. Usuario (Criação) ---> Matricula
        public virtual ICollection<Matricula> MatriculasCriadas { get; set; } = new HashSet<Matricula>();

        // 2. Usuario (Situação) ---> Matricula
        public virtual ICollection<Matricula> MatriculasComSituacaoAlterada { get; set; } = new HashSet<Matricula>();

        // 3. Usuario (Alteração) ---> Matricula
        public virtual ICollection<Matricula> MatriculasExcluidas { get; set; } = new HashSet<Matricula>();

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
    }
}
