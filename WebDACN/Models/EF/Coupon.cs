using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDACN.Models.EF
{
    [Table("tb_Coupon")]

    public class Coupon : CommonAbstract
    {
        public Coupon()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }

        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}