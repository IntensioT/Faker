using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Faker
{
    public class Faker : IFaker
    {
        public Faker() 
        { }

        public T Create<T>()
        {
            throw new NotImplementedException();
        }
    }
}
