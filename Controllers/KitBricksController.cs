using System;
using legoland.Models;
using legoland.Services;
using Microsoft.AspNetCore.Mvc;

namespace legoland.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitBricksController : ControllerBase
  {
    private readonly KitBricksService _service;

    public KitBricksController(KitBricksService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<KitBrick> Post([FromBody] KitBrick newKb)
    {
        try
        {
            return Ok(_service.Create(newKb));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
  }
}