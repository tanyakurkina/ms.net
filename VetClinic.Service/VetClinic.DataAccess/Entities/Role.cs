using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.Service.VetClinic.DataAccess.Entities;

[Table("roles")]
public class Role
{
    public int Id { get; set; }
    
    public string RoleName { get; set; }
    
    public List<User> Users { get; set; }
}