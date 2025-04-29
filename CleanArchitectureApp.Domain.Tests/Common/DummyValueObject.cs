using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Tests.Common
{
    public class DummyValueObject : ValueObject
    {
        public string Property1 { get; }
        public int Property2 { get; }

        public DummyValueObject(string prop1, int prop2)
        {
            Property1 = prop1;
            Property2 = prop2;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Property1;
            yield return Property2;
        }
    }

}
