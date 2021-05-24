using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class BurgersService
  {

    private readonly BurgersRepository _repo;

    public BurgersService(BurgersRepository repo)
    {
      _repo = repo;
    }

    internal Burger Create(Burger newBurger)
    {
      return _repo.Create(newBurger);
    }

    internal IEnumerable<Burger> GetAll()
    {

      // TODO do this thing
      return _repo.GetAll();
    }

    internal void Delete(int id)
    {
      Burger blog = GetOne(id);
      if (!_repo.Delete(id))
      {
        throw new Exception("Something has gone very very wrong!");
      }
    }

    public Burger GetOne(int id)
    {
      Burger burger = _repo.GetById(id);
      if (burger == null)
      {
        throw new Exception("Invalid Burger");
      }
      return burger;
    }

    internal Burger Update(Burger update)
    {
      Burger original = GetOne(update.Id);

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