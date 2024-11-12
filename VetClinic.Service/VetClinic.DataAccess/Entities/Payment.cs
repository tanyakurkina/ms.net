using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.Service.VetClinic.DataAccess.Entities;

[Table("payments")]
public class Payment
{
    public DateTime PaymentDate { get; set; }
    
    public int Amount { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public int AppointmentId{ get; set; }
    
    [ForeignKey("AppointmentId")]
    public Appointment Appointment { get; set; }
}