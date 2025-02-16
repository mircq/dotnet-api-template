﻿using Domain.Entities;
using Domain.Result;

namespace Application.Clients.Broker;

public interface IBrokerClient<T>
{
    # region Get
    public Task<Result<T>> GetAsync(Guid id, bool wait); 
    # endregion

    # region Post
    public Task<Result<T>> EnqueueAsync(JobEntity entity); 

    # endregion
}
