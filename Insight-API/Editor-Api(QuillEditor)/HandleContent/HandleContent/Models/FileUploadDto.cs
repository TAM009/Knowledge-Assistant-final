using Microsoft.AspNetCore.Http;
using System;

namespace HandleContent
{
    public class FileUploadDto
    {
        public IFormFile File { get; set; }
        public string TokenString{get;set;}
    }
}