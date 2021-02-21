using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _service;

    public IngredientsController(IngredientsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Ingredient>> GetAll()
    {
      try
      {
        return (Ok(_service.GetAll()));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Ingredient> GetOne(int id)
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
    public ActionResult<Ingredient> Create([FromBody] Ingredient newIngredient)
    {
      try
      {
        return Ok(_service.Create(newIngredient));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Ingredient> Edit([FromBody] Ingredient editIngredient, int id)
    {
      try
      {
        editIngredient.Id = id;
        return Ok(_service.Edit(editIngredient));
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