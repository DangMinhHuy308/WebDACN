using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDACN.Models.EF
{
    [Table("tb_Review")]

    public class Review 
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Email { get; set; }
        public string Avatar { get; set; }

        public int Rate { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
        public virtual Product Product { get; set; }


    }
}