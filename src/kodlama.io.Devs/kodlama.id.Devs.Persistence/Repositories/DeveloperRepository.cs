using Core.Persistence.Repositories;
using kodlama.id.Devs.Persistence.Contexts;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Persistence.Repositories
{
    public class DeveloperUserRepository : EfRepositoryBase<DeveloperUser, BaseDbContext>, IDeveloperUserRepository
    {
        public DeveloperUserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
