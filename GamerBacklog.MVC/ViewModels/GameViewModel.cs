using System.ComponentModel.DataAnnotations;

namespace GamerBacklog.MVC.ViewModels
{
    public class GameViewModel
    {
        [Key]
        public int GameId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        //public virtual IEnumerable<Platform> Platforms { get; set; }
    }
}