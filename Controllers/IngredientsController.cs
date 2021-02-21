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
  }
}