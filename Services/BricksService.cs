using System;
using System.Collections.Generic;
using legoland.Models;
using legoland.Repositories;

namespace legoland.Services
{
  public class BricksService
  {
    private readonly BricksRepository _repo;
    //brought in kits repo in order to check the kit is actually a valid kit
    private readonly KitsRepository _krepo;
    public BricksService(BricksRepository repo, KitsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }

    public Brick Get(int id)
    {
      Brick exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }

    public Brick Create(Brick newBrick)
    {
      int id = _repo.Create(newBrick);
      newBrick.Id = id;
      return newBrick;
    }

    public string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }

    internal IEnumerable<Brick> GetBricksByKitId(int kitId)
    {
      Kit exists = _krepo.Get(kitId);
      if(exists == null) {throw new Exception ("invalid Id");}
      return _repo.getBricksByKitId(kitId);
    }
  }
}