using System.ComponentModel.DataAnnotations;

namespace GamerBacklog.MVC.ViewModels
{
    public class PlatformViewModel
    {
        [Key]
        public int PlatformId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        //public virtual IEnumerable<Platform> Platforms { get; set; }
    }
}