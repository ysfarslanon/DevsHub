using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Domain.Entities
{
    public class DeveloperUser : User
    {
        public virtual GithubProfile GithubProfile { get; set; }

        public DeveloperUser()
        {

        }

        public DeveloperUser(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType)
            : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}
