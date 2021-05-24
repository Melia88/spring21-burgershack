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
  public class SidesController : ControllerBase, ICodeWorksRestfulController<Side>
  {
    private readonly SidesService _ss;

    public SidesController(SidesService ss)
    {
      _ss = ss;
    }

    [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
      try
      {
        Side side = _ss.Create(newSide);
        return Ok(newSide);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    public ActionResult<Side> Delete(int id)
    {
      try
      {
        _ss.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      try
      {
        IEnumerable<Side> sides = _ss.GetAll();
        return Ok(sides);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]

    public ActionResult<Side> GetOne(int id)
    {
      try
      {
        Side found = _ss.GetOne(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    public ActionResult<Side> Update([FromBody] Side update)
    {
      Side updated = _ss.Update(update);
      return Ok(updated);
    }
  }
}
