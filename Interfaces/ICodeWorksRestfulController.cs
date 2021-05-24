using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Interfaces
{
  public interface ICodeWorksRestfulController<T>
  {
    ActionResult<IEnumerable<T>> Get();
    ActionResult<T> GetOne(int id);
    ActionResult<T> Create(T data);
    ActionResult<T> Update(T data);
    ActionResult<T> Delete(int id);
  }
}