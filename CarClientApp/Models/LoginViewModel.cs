using System.ComponentModel.DataAnnotations;

namespace CarClientApp.Models;

 public class LoginViewModel
{
    [Required(ErrorMessage = "Введите логин")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
