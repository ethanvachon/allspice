using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Recipe> GetAll()
    {
      return _repo.GetAll();
    }
    internal Recipe GetOne(int id)
    {
      Recipe recipe = _repo.GetOne(id);
      return recipe;
    }

    internal Recipe Create(Recipe newRecipe)
    {
      _repo.Create(newRecipe);
      return newRecipe;
    }

    internal Recipe Edit(Recipe editRecipe)
    {
      Recipe recipe = GetOne(editRecipe.Id);
      _repo.Edit(editRecipe);
      return editRecipe;
    }

    internal Recipe Delete(int id)
    {
      Recipe recipeToRemove = GetOne(id);
      _repo.Delete(recipeToRemove);
      return recipeToRemove;
    }
  }
}