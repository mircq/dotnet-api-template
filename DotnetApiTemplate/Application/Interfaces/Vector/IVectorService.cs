using Domain.Entities;
using Domain.Result;

namespace Application.Interfaces.Job;

public interface IVectorService<T>
{
    # region Get
    public Task<Result<T>> GetAsync(Guid id);
    # endregion

   
