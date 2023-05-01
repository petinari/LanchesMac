using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public Guid CategotiaId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório" )]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        [Display(Name = "Nome da Categoria")]
        public string CategoriaNome { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Display(Name = "Descrição da Categoria")]

        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }

    }
}
