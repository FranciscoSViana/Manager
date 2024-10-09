using System;
using System.Collections.Generic;

namespace Manager.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

        public DomainException() { }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors ?? new List<string>();
        }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}