using System;
using System.Collections.Generic;
using System.Data;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class IngredientsRepository
  {
    public readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient GetOne(int id)
    {
      string sql = "SELECT * FROM ingredients WHERE id = @id;";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
    }

    // no populate

    // internal IEnumerable<Ingredient> GetIngredientsByRecipeId(int id)
    // {
    //   string sql = "SELECT * FROM ingredients WHERE recipeId = @id;";
    //   return _db.Query<Ingredient>(sql, new { id });
    // }
    internal IEnumerable<Ingredient> GetIngredientsByRecipeId(int id)
    {
      string sql = @"
      SELECT
      ingr.*,
      reci.*
      FROM ingredients ingr
      JOIN recipes reci ON ingr.recipeId = reci.id
      WHERE recipeId = @id;";

      return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.Recipe = recipe;
        return ingredient;
      }, new { id }, splitOn: "id");
    }

    internal Ingredient Create(Ingredient newIngredient)
    {
      string sql = @"
      INSERT INTO ingredients
      (quantity, name, recipeId)
      VALUES
      (@quantity, @name, @recipeId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newIngredient);
      newIngredient.Id = id;
      return newIngredient;
    }

    internal Ingredient Edit(Ingredient editIngredient)
    {
      string sql = @"
      UPDATE ingredients
      SET
        quantity = @Quantity,
        name = @Name
      WHERE id = @Id;
      SELECT * FROM ingredients WHERE id = @Id";
      return _db.QueryFirstOrDefault<Ingredient>(sql, editIngredient);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM ingredients WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}