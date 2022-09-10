using Core.Persistence.Repositories;

namespace kodlama.io.Devs.Domain.Entities
{
    public class GithubProfile : Entity
    {
        public int Id { get; set; }
        public virtual DeveloperUser DeveloperUser { get; set; }
        public int DeveloperUserId { get; set; }
        public string URL { get; set; }

        public GithubProfile()
        {

        }

        public GithubProfile(int id, int developerUserId, string url)
        {
            Id = id;
            DeveloperUserId = developerUserId;
            URL = url;
        }
    }
}