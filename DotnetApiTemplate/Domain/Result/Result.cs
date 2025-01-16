using System;
using Domain.Errors;

namespace Domain.Result;

public class Result<TValue>
{
  public readonly TValue? Value;
  public readonly Error? Error;

  private bool _isSuccess;

  private Result(TValue value)
  {
    _isSuccess = true;
    Value = value;
    Error = default;
  }

  private Result(Error error)
  {
    _isSuccess = false;
    Value = default;
    Error = error;
  }

  public bool IsFailure => !_isSuccess;
  
  //happy path
  public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);

  //error path
  public static implicit operator Result<TValue> (Error error)=> new Result<TValue>(error);

  public Result<TValue> Match(Func<TValue, Result<TValue>> success, Func<Error, Result<TValue>> failure)
  {
    if (_isSuccess)
    {
      return success(Value!);
    }
    return failure(Error!);
  }
}
