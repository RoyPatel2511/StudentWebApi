﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Domain.ResponseModel
{
    public record StudentResponseModel
    {
     
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string CourseName { get; set; }

    }
}
