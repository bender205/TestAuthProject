using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAuth.Resource.Api.Models
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>()
        {
            new Book(){Id = 1, Author = "author 1", Title = "title 1", Price = 1.1M},
            new Book(){Id = 2, Author = "author 2", Title = "title 2", Price = 2.2M},
            new Book(){Id = 3, Author = "author 3", Title = "title 3", Price = 3.3M},
            new Book(){Id = 4, Author = "author 4", Title = "title 4", Price = 4.4M}
        };
        public  Dictionary<Guid, int[]> Orders => new Dictionary<Guid, int[]>()
        {
            {Guid.Parse("e2371dc9-a849-4f3c-9004-df8fc921c13a"), new int[] {1,3}},
            {Guid.Parse("e2371dc9-a849-4f3c-9004-df8fc921c13b"), new int[] {2,3,4}}
        };
    }
}
