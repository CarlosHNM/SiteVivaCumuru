using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaCumuru.Models
{
    [Table("Loja")]
    public class Loja
    {
        [Key]
        public int LojaId { get; set; }

        [Required(ErrorMessage = "O nome do estabelecimento deve ser informado")]
        [Display(Name = "Nome do Estabelecimento")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do estabelecimento deve ser informada")]
        [Display(Name = "Descrição")]
        [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        //[MaxLength(500, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string Descricao { get; set; }

        
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        //[Required(ErrorMessage = "Informe o email.")]
        //[StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Caminho Imagem")]
       // [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }
        public string Instagran { get; set; }
        [Display(Name = "Localizador Google")]
        public string UrlLocalizador { get; set; }
        [Display(Name = "Horario de Funcionamento")]
        public string Funcionamento { get; set; }
        
        [Display(Name = "SubCategorias")]
        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }

        public List<TBAnexo> TBAnexo { get; set;}

    }
}
