using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VivaCumuru.Models
{

    [Table("SubCategoria")]
    public class SubCategoria
    {
            [Key]
            public int Id { get; set; }

            [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
            [Required(ErrorMessage = "Informe o nome da subcategoria")]
            [Display(Name = "Nome da SubCategoria")]
            public string SubCategoriaNome { get; set; }
            [Display(Name = "Categorias")]
            public int CategoriaId { get; set; }
            public virtual Categoria Categoria { get; set; }
            
            [NotMapped]
            public List<Loja> Lojas { get; set; }
    }
}
