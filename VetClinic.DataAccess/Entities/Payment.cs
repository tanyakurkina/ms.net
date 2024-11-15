using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("payments")]
public class Payment : BaseEntity
{
    public DateTime PaymentDate { get; set; }
    
    public int Amount { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public int AppointmentId{ get; set; }
    
    
    public Appointment Appointment { get; set; }
}