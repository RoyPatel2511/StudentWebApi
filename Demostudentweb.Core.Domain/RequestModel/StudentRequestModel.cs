using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demostudentweb.Core.Domain.RequestModel
{
    public record StudentRequestModel
    {
      
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int CourseId { get; set; }
        public IFormFile Img { get; set; }

    }
}
