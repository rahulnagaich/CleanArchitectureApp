﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Infrastructure
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}
