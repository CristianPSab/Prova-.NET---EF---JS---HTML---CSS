using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjEntidades
{
    //Ejemplo de relación de uno a muchos entre 2 entidades
    [Table("Productos")]
    public class Producto
    {

        [Key]
        public int Codigo { get; set; }

        [Required]
        [Column("Nombre", TypeName = "varchar", Order = 2)]
        public string Nombre { get; set; }

        [MaxLength(100), MinLength(10)]
        public string Descripcion { get; set; }

        [NotMapped]
        public string CodigoIso { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
