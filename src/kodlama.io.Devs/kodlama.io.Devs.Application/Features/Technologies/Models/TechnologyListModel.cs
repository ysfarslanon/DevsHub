﻿using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Models
{
    public class TechnologyListModel : BasePageableModel
    {
        public ICollection<TechnologyListDto> Items { get; set; }
    }
}
