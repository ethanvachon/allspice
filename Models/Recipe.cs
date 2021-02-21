using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
  public class Recipe
  {
    public Recipe()
    {

    }
    public Recipe(string title, string description, int id)
    {
      Title = title;
      Description = description;
      Id = id;
    }

    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public int Id { get; set; }
  }
}