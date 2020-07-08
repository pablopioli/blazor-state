﻿namespace TestApp.Api.Features.Base
{
  using System;

  public abstract class BaseRequest
  {
    public Guid Id { get; set; }

    /// <summary>
    /// Every request should have unique Id
    /// </summary>
    public BaseRequest()
    {
      Id = Guid.NewGuid();
    }
  }
}