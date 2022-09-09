using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public virtual ICollection<Technology> Technologies { get; set; }
        public string Name { get; set; }

        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
