using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Utilities
{
    public record Error(string? Code, string Message, Guid ErrorId)
    {
        public static implicit operator string(Error error) => JsonSerializer.Serialize(error);
    };
}
