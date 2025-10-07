using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.Services.Interfaces
{
    public interface IAttachmentService
    {
        public string? Upload(IFormFile file, string folderName);

        public bool Delete(string filePath);
    }
}
