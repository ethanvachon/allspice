using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Ingredient> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Ingredient GetOne(int id)
    {
      Ingredient ingredient = _repo.GetOne(id);
      if (ingredient == null)
      {
        throw new Exception("invalid id");
      }
      return ingredient;
    }

    public IEnumerable<Ingredient> GetIngredientsByRecipeId(int id)
    {
      IEnumerable<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(id);
      return ingredients;
    }


    internal Ingredient Create(Ingredient newIngredient)
    {
      return _repo.Create(newIngredient);
    }

    internal object Edit(Ingredient editIngredient)
    {
      return _repo.Edit(editIngredient);
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return ("deleted");
    }
  }
}