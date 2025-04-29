﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class BadRequestException(string message) : ApplicationException(message)
    {
    }
}
