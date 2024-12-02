namespace VetClinic.BL.Users.Entity;

public class CreateUserModel
{
    public string PasswordHash { get; set; } 
    public string Email { get; set; } 
    public string Name { get; set; } 
    public string Surname { get; set; } 
    public string? Patronymic { get; set; } 
    public int RoleId { get; set; }
}