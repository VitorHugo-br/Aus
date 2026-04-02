using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAus.Models;

public class User : Entity
{
    [Column("user_name")] 
    public string UserName { get; set; }

    [Column("password")]
    [StringLength(300)]
    public string Password { get; set; } = string.Empty;
}