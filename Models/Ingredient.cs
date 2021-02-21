using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
  public class Ingredient
  {
    public Ingredient()
    {

    }

    public Ingredient(int quantity, string name, int id, int recipeId)
    {
      Quantity = quantity;
      Name = name;
      Id = id;
      RecipeId = recipeId;
    }

    [Required]
    public int Quantity { get; set; }
    [Required]
    public string Name { get; set; }
    public int Id { get; set; }

    public int RecipeId { get; set; }

  }
}