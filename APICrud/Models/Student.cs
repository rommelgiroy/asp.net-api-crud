using System.ComponentModel.DataAnnotations;

namespace APICrud.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; }  

    [Required]
    [StringLength(100, MinimumLength =3, ErrorMessage ="Last name must 3 minimum character and maximum 100 character.")]
    public string? LastName { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]*$", ErrorMessage ="Numeric only allowed.")]
    public string? Grade { get; set; }

    [Required]
    public string? Section { get; set; }
}
