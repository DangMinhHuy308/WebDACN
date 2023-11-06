using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDACN.Models.EF
{
    [Table("tb_Brand")]

    public class Brand : CommonAbstract
    {
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Alias { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}