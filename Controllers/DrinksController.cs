using System;
using System.Collections.Generic;
using burgershack.Interfaces;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DrinksController : ControllerBase, ICodeWorksRestfulController<Drink>
  {
    private readonly DrinksService _ds;

    public DrinksController(DrinksService ds)
    {
      _ds = ds;
    }


    [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
      try
      {
        Drink drink = _ds.Create(newDrink);
        return Ok(drink);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    public ActionResult<Drink> Delete(int id)
    {
      try
      {
        _ds.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      try
      {
        IEnumerable<Drink> drinks = _ds.GetAll();
        return Ok(drinks);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]

    public ActionResult<Drink> GetOne(int id)
    {
      try
      {
        Drink found = _ds.GetOne(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    public ActionResult<Drink> Update([FromBody] Drink update)
    {
      Drink updated = _ds.Update(update);
      return Ok(updated);
    }
  }
}
