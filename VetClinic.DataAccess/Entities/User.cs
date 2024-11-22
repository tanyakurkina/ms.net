using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("users")]
public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Patronymic { get; set; }
    
    public string Email { get; set; }
    
    public string HashPassword { get; set; }
    
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
    
    public List<Appointment> Appointments { get; set; }
    
    public List<Pet> Pets { get; set; }
}