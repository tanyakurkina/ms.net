﻿namespace VetClinic.BL.Users.Entity;

public class UserFilterModel
{
    public string? NamePart { get; set; } 
    public string? EmailPart { get; set; } 
    public DateTime? CreationTimeFrom { get; set; } 
    public DateTime? CreationTimeTo { get; set; } 
    public DateTime? ModificationTimeFrom { get; set; } 
    public DateTime? ModificationTimeTo { get; set; } 
    public int RoleId { get; set; } 
}