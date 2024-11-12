using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.Service.VetClinic.DataAccess.Entities;

[Table("medical_records")]
public class MedicalRecord
{
    public DateTime RecordDate { get; set; }
    
    public string  Treatment { get; set; }
    
    public string  Diagnosis { get; set; }
    
    public int PetId{ get; set; }
    
    [ForeignKey("PetId")]
    public Pet Pet { get; set; }
}