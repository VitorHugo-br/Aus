using System.ComponentModel.DataAnnotations;

namespace ProjetoAus.Models;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; } 
}