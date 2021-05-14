﻿using System;

namespace Closure.ECommerceShipping.Api.Application.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.") { }
    }
}
