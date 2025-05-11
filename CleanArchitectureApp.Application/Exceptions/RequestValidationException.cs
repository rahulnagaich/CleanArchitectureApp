using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class RequestValidationException : Exception
    {
        public List<string> Errors { get; } = [];

        public RequestValidationException() : base("One or more validation failures have occurred.") { }

        public RequestValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors.AddRange(failures.Select(f =>
                string.IsNullOrWhiteSpace(f.PropertyName) ?
                f.ErrorMessage :
                $"{f.PropertyName}: {f.ErrorMessage}"
            ));
        }

        public RequestValidationException(string singleMessage)
            : base(singleMessage)
        {
            Errors.Add(singleMessage);
        }
    }
}
