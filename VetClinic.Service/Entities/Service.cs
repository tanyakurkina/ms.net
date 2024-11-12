using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("services")]
public class Service
{
    public string ServiceName { get; set; }
    
    public int Price { get; set; }
    
    public string Description { get; set; }
    
    public int AppointmentId{ get; set; }
    
    [ForeignKey("AppointmentId")]
    public Appointment Appointment { get; set; }
}