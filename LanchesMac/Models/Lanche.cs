using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public Guid LancheId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Display(Name = "Nome do Lanche")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Display(Name = "Descrição Curta")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(255, ErrorMessage = "O tamanho máximo é de 255 caracteres")]
        [Display(Name = "Descrição Detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Display(Name = "Imagem")]

        public string ImagemUrl { get; set; }

        
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Display(Name = "Imagem Thumbnail")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Lanche Preferido")]

        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Em Estoque")]
        public bool EmEstoque { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}