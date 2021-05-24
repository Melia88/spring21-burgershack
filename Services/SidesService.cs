using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class SidesService
  {
    private readonly SidesRepository _repo;

    public SidesService(SidesRepository repo)
    {
      _repo = repo;
    }

    internal Side Create(Side newSide)
    {
      return _repo.Create(newSide);
    }
    internal void Delete(int id)
    {
      Side side = GetOne(id);
      if (!_repo.Delete(id))
      {
        throw new Exception("UhOh Somethins Went Wrong!");
      }
    }

    internal IEnumerable<Side> GetAll()
    {
      return _repo.GetAll();
    }

    internal Side GetOne(int id)
    {
      Side side = _repo.GetById(id);
      if (side == null)
      {
        throw new Exception("Invalid Side");
      }
      return side;
    }

    internal Side Update(Side update)
    {
      Side original = GetOne(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Quantity = update.Quantity > 0 ? update.Quantity : original.Quantity;
      original.Modifications = update.Modifications.Length > 0 ? update.Modifications : original.Modifications;
      original.Cost = update.Cost > 0 ? update.Cost : original.Cost;
      if (_repo.Update(original))
      {
        return original;
      }
      throw new Exception("Something went wrong??");
    }
  }
}