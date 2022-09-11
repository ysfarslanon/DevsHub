using Core.Persistence.Repositories;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Services.Repositories
{
    public interface IGithubProfileRepository : IAsyncRepository<GithubProfile>, IRepository<GithubProfile>
    {
    }
}
