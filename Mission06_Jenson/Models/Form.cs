using System.ComponentModel.DataAnnotations;

namespace Mission06_Jenson.Models;

public class Form
{
    [Key]
    public int MovieId { get; set; }
    public string Category {get; set;}
    public string Title {get; set;}
    public string Year {get; set;}
    public string Director {get; set;}
    public string Rating {get; set;}
    public bool? Edited {get; set;}
    public string? LentTo {get; set;}
    [MaxLength(25)]
    public string? Notes {get; set;}
}