using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Configuration;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using HandleContent;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;

//Namespaces used to avaid AWSSDK functions.
using Amazon;
using Amazon.Extensions.NETCore;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;


//User Defined Service
using AmazonUploadService;

namespace AmazonUploadController.Controllers
{
    [Route("api/[controller]")]
    public class AmazonS3UploadController : Controller
    {
        
        private IAmazonUploadService _service;
        //private IMapper _mapper;

        public AmazonS3UploadController(IAmazonUploadService service)
        {
            _service=service;
            //_mapper=mapper;
        }

        // [HttpPost]
        // public Task<bool> UploadToS3([FromBody] FileUploadDto item2)
        // {
        //     Console.WriteLine("token"+item2.TokenString);

        //     var FileUploadPost = _mapper.Map<IFormFile>(item2);
            
        //     AuthenticationTokenClass AuthenticationTokenClassObjRef = new AuthenticationTokenClass();

        //     TokenDto tokendto = new TokenDto();
        //     string tokenref = AuthenticationTokenClassObjRef.AuthenticationToken(tokendto).Result ;
        //     object jsonObject = JsonConvert.DeserializeObject(tokenref);
        //     var ParsedJsonObject= JObject.Parse(tokenref);
        //     string tokenserver= ParsedJsonObject["tokenstored"].ToString(); 
        //     dynamic dynJson = JsonConvert.DeserializeObject(tokenserver);

        //         foreach (var item in dynJson)
        //         {
        //           String tokenstored=  item.tokenstored;
                 
        //           if(item2.TokenString == tokenstored)
        //           {
           
        //             try 
        //             {
        //                 return _service.UploadToS3(FileUploadPost);
        //             } 
        //             catch(Exception ex)
        //             {
        //                 Console.WriteLine(ex.Message);
        //             }
        //           }
        //         }
            
        //    return null;
        // }

        //Post function initialised by passing the entire file as an argument from clientside.
        [HttpPost]
        public Task<bool> UploadToS3(IFormFile UploadedFile)
        {
            return _service.UploadToS3(UploadedFile);
        }

        //Get function initialised by passing a string filename as an argument from frontend via angular4.
        [HttpGet("{filename}")] 
        public Task<bool> DownloadFromS3(string filename)
        {
            return _service.DownloadFromS3(filename);
        }
        
        //Delete function initialised by passing string filename as an argument from frontend via angular4.
        [HttpDelete("{filename}")] 
        public Task<bool> DeleteFromS3(string filename)
        {
            return _service.DeleteFromS3(filename);
        }
    }
}
