using System.ComponentModel.DataAnnotations;

namespace EduQuest.Communication.Responses
{
    public class ResponseUsuarioJson
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public Guid UsuarioIdentifier { get; set; }
        public DateTime DataUltimoLogin { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
