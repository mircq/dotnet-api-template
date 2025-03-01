using Domain.Entities;
using Domain.Result;

namespace Application.Interfaces.Vector;

public interface IVectorService<T>
{
    # region Get
    public Task<Result<T>> EmbedAsync(string text);
    # endregion
}

   
