using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Package : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TotalPackagePrice { get; set; }

        public virtual List<ProductDocket> ProductDockets { get; set; } = new List<ProductDocket>() { };//detail very important

        public virtual List<DeliverableDocket> DeliverableDockets { get; set; } = new List<DeliverableDocket>() { };
    }

    public class ProductDocket : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PackageId { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package package { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

    public class DeliverableDocket : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PackageId { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package package { get; set; }
        [Required]
        public int DeliverableId { get; set; }

        [ForeignKey("DeliverableId")]
        public virtual Deliverable deliverable { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
