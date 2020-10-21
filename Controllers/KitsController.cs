using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legoland.Models;
using legoland.Services;
using Microsoft.AspNetCore.Mvc;

namespace legoland.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitsController : ControllerBase
  {

    //able to bring in additional services and repos into the appropriate files
    //in order to reference correct method locations
    private readonly KitsService _ks;
    private readonly BricksService _bs;

    public KitsController(KitsService ks, BricksService bs)
    {
      _ks = ks;
      _bs = bs;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Kit> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_ks.Create(newKit));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //api/kits/:kitId/kitbricks
    [HttpGet("{kitId}/kitbricks")]
    public ActionResult<IEnumerable<Brick>> GetKitBricks(int kitId)
    {
      try
      {
        return Ok(_bs.GetBricksByKitId(kitId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

