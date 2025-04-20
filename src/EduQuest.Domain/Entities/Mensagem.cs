using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Mensagem
    {
        [Key]
        public int Id { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }

        // Usuario ---> Mensagem
        public int RemetenteId { get; set; }
        public Usuario Remetente { get; set; } = default!;
        public int DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; } = default!;
    }
}