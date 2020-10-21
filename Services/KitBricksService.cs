using System;
using legoland.Models;
using legoland.Repositories;

namespace legoland.Services
{
  public class KitBricksService
  {
    private readonly KitBricksRepository _repo;

    public KitBricksService(KitBricksRepository repo)
    {
      _repo = repo;
    }

    public KitBrick Create(KitBrick newKb)
    {
        int id = _repo.Create(newKb);
        newKb.Id = id;
        return newKb;
    }
  }
}