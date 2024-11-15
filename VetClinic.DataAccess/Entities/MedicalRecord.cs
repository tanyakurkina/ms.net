using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.DataAccess.Entities;

[Table("medical_records")]
public class MedicalRecord : BaseEntity
{
    public DateTime RecordDate { get; set; }
    
    public string  Treatment { get; set; }
    
    public string  Diagnosis { get; set; }
    
    public int PetId{ get; set; }
    
    
    public Pet Pet { get; set; }
}