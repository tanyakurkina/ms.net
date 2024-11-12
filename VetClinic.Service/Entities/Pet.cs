using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("pets")]
public class Pet : BaseEntity
{
    public string Name { get; set; }
    
    public string Species { get; set; }
    
    public string Breed { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public int Weight { get; set; }
    
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
}