using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _service;

    public RecipesController(RecipesService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAll()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetOne(int id)
    {
      try
      {
        return Ok(_service.GetOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
    {
      try
      {
        return Ok(_service.Create(newRecipe));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Recipe> Edit([FromBody] Recipe editRecipe, int id)
    {
      try
      {
        editRecipe.Id = id;
        return Ok(_service.Edit(editRecipe));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}