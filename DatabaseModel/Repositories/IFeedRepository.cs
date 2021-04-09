using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    interface IFeedRepository : IRepository<Feed>
    {
        Task<Feed> GetFeedByIdAsync(int id);
    }
}
