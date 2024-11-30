using EFCorePOC.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePOC.Services.Books
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetByNameAsync(IEnumerable<string> categoryNames);
    }
}
