using System;
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

    internal object GetAll()
    {
      throw new NotImplementedException();
    }

    internal object GetOne(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Recipe newRecipe)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Ingredient editIngredient)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}