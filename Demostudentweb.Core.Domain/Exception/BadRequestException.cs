using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Domain.Exception
{
    public class BadRequestException : IOException
    {
        public BadRequestException(string message) : base(message) { }
    }
}
