namespace EntityLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Denene1Table")]
public class Deneme2
{
    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength = 2)]
    public string FirstName { get; set; }
    
    [StringLength(50,MinimumLength = 2)]
    public string? SecondName { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength = 2)]
    public string LastName { get; set; }

    public DateTime? BirthDate { get; set; }
}