using System;
using System.Collections.Generic;
using System.Data;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class RecipesRepository
  {
    public readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Recipe> GetAll()
    {
      string sql = "SELECT * FROM recipes;";
      return _db.Query<Recipe>(sql);
    }

    internal Recipe GetOne(int id)
    {
      string sql = "SELECT * FROM recipes WHERE id = @id;";
      return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
    }

    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (title, description)
      VALUE
      (@title, @description);
      SELECT LAST_INSERT_ID()";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      newRecipe.Id = id;
      return newRecipe;
    }

    internal Recipe Edit(Recipe editRecipe)
    {
      string sql = @"
      UPDATE recipes
      SET
        title = @Title,
        description = @Description
      WHERE id = @Id; 
      SELECT * FROM recipes WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Recipe>(sql, editRecipe);
    }

    internal int Delete(Recipe recipeToRemove)
    {
      string sql = "DELETE FROM recipes WHERE id = @id;";
      return _db.Execute(sql, recipeToRemove);
    }
  }
}