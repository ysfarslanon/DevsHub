using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Dtos
{
    public class CreateGithubProfileDto
    {
        public int Id { get; set; }
        public int DeveloperUserId { get; set; }
        public string URL { get; set; }
    }
}
