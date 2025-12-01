using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [StringLength(10), MinLength(3)]
    public string Name { get; set; }

    public Address WorkAddress { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [RegularExpression("^Pkp*\\d{3}$")]
    public string Code { get; set; }


    public string Password { get; set; }
    
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }


  
}
