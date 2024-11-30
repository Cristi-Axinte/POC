using EFCorePOC.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePOC.Services.Books
{
    public interface IPublisherRepository
    {
        public Task<Publisher> GetByNameAsync(string name);

    }
}
