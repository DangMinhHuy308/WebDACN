using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDACN.Models.EF
{
    [Table("tb_Product")]

    public class Product : CommonAbstract
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Reviews = new HashSet<Review>();
            this.Wishlists = new HashSet<Wishlist>();

        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewProduct { get; set; }

        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }
        public int BrandId { get; set; }
/*        public int SizeId { get; set; }
*/


        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Brand Brand { get; set; }
/*        public virtual Size Size { get; set; }
*/

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }


    }
}