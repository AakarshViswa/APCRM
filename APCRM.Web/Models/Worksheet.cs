using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Worksheet
    {
        [Key]
        public int Id { get; set; }            
        [Required]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Event eventinfo { get; set; }
        public int PackageId { get; set; }    
       
        [ForeignKey("PackageId")]
        public virtual Package packageinfo { get; set; } 
        public int WorkFlowStatusId { get; set; }
        [ForeignKey("WorkFlowStatusId")]
        public virtual WorkStatus WorkStatus { get; set; }   
        public string TotalCost { get; set; }
        public string CreatedBy { get; set; }          
        public string UpdatedBy { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }   

    public class WorksheetProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WorkSheetId { get; set; }
        [ForeignKey("WorkSheetId")]
        public virtual Worksheet worksheet { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }   
        public int productquantity { get; set; }
        [Required]
        public string TotalProductCost { get; set; }

    }

    public class WorksheetDeliverable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WorkSheetId { get; set; }
        [ForeignKey("WorkSheetId")]
        public virtual Worksheet worksheet { get; set; }
        [Required]
        public int DeliverableId { get; set; }
        [ForeignKey("DeliverableId")]
        public virtual Deliverable deliverable { get; set; }
        public int deliverablequantity { get; set; }
        [Required]
        public string TotalDeliverableCost { get; set; }
    }

    public class WorksheetPaymentLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WorkSheetId { get; set; }
        [ForeignKey("WorkSheetId")]
        public virtual Worksheet worksheet { get; set; }
        [Required]
        public int PaidAmount { get; set; }      
        public string Remarks { get; set; }
    }

    public class WorksheetPaymentStatus
    {
        [Key]
        public int WorksheetPaymentId { get; set; }
        [Required]
        public int WorkSheetId { get; set; }
        [ForeignKey("WorkSheetId")]
        public virtual Worksheet worksheet { get; set; }
        public int PaymentStatusId { get; set; }
        [ForeignKey("PaymentStatusId")]
        public virtual WorkStatus PaymentStatus { get; set; }
    }
}
