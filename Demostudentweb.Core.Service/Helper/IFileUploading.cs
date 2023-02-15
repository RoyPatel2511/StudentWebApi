using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Service.Helper
{
    public interface IFileUploading
    {
        Task<string> UploadPhoto(IFormFile file);
          
    }
}
