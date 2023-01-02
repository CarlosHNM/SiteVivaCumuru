using System.ComponentModel.DataAnnotations;

namespace VivaCumuru.Models
{
    public class TelefoneUteis
    {
        [Key]
        public int TelId { get; set; }
        [Display(Name = "Nome")]
        public string TelNome { get; set; }
        [Display(Name = "Número do Telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string TelNum { get; set; }

    }
}
