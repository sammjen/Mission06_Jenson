using System.ComponentModel.DataAnnotations;

namespace Mission06_Jenson.Models;

public class Category
{
    // setting up our category table
    [Key]
    public int CategoryId {get; set;}
    
    public string CategoryName {get; set;}
}