using System.ComponentModel.DataAnnotations;

namespace Dio.AgendaDeContatos.MVC.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
