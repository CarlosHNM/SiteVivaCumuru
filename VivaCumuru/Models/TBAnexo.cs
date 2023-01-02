using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaCumuru.Models
{
    [Table("TBAnexo")]
    public class TBAnexo
    {
        [Key]
        public int TbAnexoId { get; set; }
        public string UrlImage { get; set; }
        public byte[] Arquivo { get; set; }
        public int LojaId { get; set; }

        public virtual Loja Loja { get; set; }
    }
}
