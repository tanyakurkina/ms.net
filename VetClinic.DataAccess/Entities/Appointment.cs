using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("appointments")]
public class Appointment : BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public List<Service> Services { get; set; }
    
    public List<Payment> Payments { get; set; }
}