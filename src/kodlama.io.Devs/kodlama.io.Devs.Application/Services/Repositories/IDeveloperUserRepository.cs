using Core.Persistence.Repositories;
using kodlama.io.Devs.Domain.Entities;

namespace kodlama.io.Devs.Application.Services.Repositories
{
    public interface IDeveloperUserRepository : IAsyncRepository<DeveloperUser>, IRepository<DeveloperUser>
    {
    }
}
