using System.ComponentModel.DataAnnotations;

namespace dtos;
public class StudentDTO
{
    
    public Guid Id { get; set; }
    [MaxLength(255)]
    [Required]
    public string Name { get; set; }=string.Empty;
    
    [Range(minimum:0d,maximum:5d)]
    public double Grade { get; set; } 

    [Required]
    public DateTime Birthdate { get; set; }  

    public static List<StudentDTO> Students { get; set; }=new List<StudentDTO>();
}