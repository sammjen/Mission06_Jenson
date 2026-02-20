using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Jenson.Models;

public class Movie
{
    // setting up our movie table
    [Key]
    public int MovieId { get; set; }
    // foreign key
    
    [ForeignKey("CategoryId")]
    public int CategoryId {get; set;}
    public Category Category {get; set;}
    public string Title {get; set;}
    public int Year {get; set;}
    public string? Director {get; set;}
    public string Rating {get; set;}
    public bool? Edited {get; set;}
    [MaxLength(25)]
    public string? LentTo {get; set;}

    public bool CopiedToPlex {get; set;}
    public string? Notes {get; set;}
}