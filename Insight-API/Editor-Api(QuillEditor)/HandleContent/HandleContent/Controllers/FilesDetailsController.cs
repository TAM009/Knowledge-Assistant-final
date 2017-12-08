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
using HandleContent; //To obtain FilesDetailsContext and ReceiveFiles class
using FilesDetailsService;// To obtain IFilesDetailsService
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;

namespace FilesDetailsInfo.Controllers
{
    [Route("api/[controller]")]
    public class FilesDetailsController:Controller //4.Using the infoservice defined in startup in the controller.
    {
        //private readonly FilesDetailsContext _context;

        private IFilesDetailsService _service;
        private IMapper _mapper;

        public FilesDetailsController(IFilesDetailsService service,IMapper mapper)
        {
           // _context=context;
            _service=service;
            _mapper=mapper;
            
        }

        [HttpGet]
        public Task<List<UserFileDetails>> GetAllFiles()
        {
            return _service.GetAllFiles();
        }

        //Post operation 
        [HttpPost] 
        public Task<bool> CreateFileDetails([FromBody] FileDto item2)
        {
            Console.WriteLine("token"+item2.TokenString);

            var FilesDetailsPost = _mapper.Map<UserFileDetails>(item2);
            
            AuthenticationTokenClass AuthenticationTokenClassObjRef = new AuthenticationTokenClass();

            TokenDto tokendto = new TokenDto();
            string tokenref = AuthenticationTokenClassObjRef.AuthenticationToken(tokendto).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var ParsedJsonObject= JObject.Parse(tokenref);
            string tokenserver= ParsedJsonObject["tokenstored"].ToString(); 
            dynamic dynJson = JsonConvert.DeserializeObject(tokenserver);

            foreach (var item in dynJson)
            {
                String tokenstored=  item.tokenstored;
                
                if(item2.TokenString == tokenstored)
                {
        
                    try 
                    {
                        return _service.CreateFileDetails(FilesDetailsPost);
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
            return null;
        }
        
        //HttpGet using multiple parameters passed from frontend.
        [HttpGet("{contentid}/{userid}")] 
        public Task<List<UserFileDetails>> GetFileNameByContentId(int contentId, int userid)
        {

            return _service.GetFileNameByContentId(contentId,userid);
        }

        //Delete File corresponding to fileId by updating (IsDelete=true).
        [HttpPut("{fileId}/{contentId}")] 
        public Task<bool> DeleteFile(int fileId,int contentId,[FromBody] FileIdDto item2)
        {
            Console.WriteLine("token"+item2.TokenString);

            var FilesDetailsDelete = _mapper.Map<UserFileDetails>(item2);
            
            AuthenticationTokenClass AuthenticationTokenClassObjRef = new AuthenticationTokenClass();

            TokenDto tokendto = new TokenDto();
            string tokenref = AuthenticationTokenClassObjRef.AuthenticationToken(tokendto).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var ParsedJsonObject= JObject.Parse(tokenref);
            string tokenserver= ParsedJsonObject["tokenstored"].ToString(); 
            dynamic dynJson = JsonConvert.DeserializeObject(tokenserver);

            foreach (var item in dynJson)
            {
                String tokenstored=  item.tokenstored;
                
                if(item2.TokenString == tokenstored)
                {
                    try 
                    {
                        return _service.DeleteFile(fileId,contentId,FilesDetailsDelete);
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
           return null;
        }

        //Update operation by obtaining fileId from client side passed via API-Gateway.
        [HttpPut("{fileId}")]
        public Task<bool> UpdateDetails(int fileId,[FromBody] FileIdDto item2)
        {
            Console.WriteLine("token"+item2.TokenString);

            var FilesDetailsUpdate = _mapper.Map<UserFileDetails>(item2);
            
            AuthenticationTokenClass AuthenticationTokenClassObjRef = new AuthenticationTokenClass();

            TokenDto tokendto = new TokenDto();
            string tokenref = AuthenticationTokenClassObjRef.AuthenticationToken(tokendto).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var ParsedJsonObject= JObject.Parse(tokenref);
            string tokenserver= ParsedJsonObject["tokenstored"].ToString(); 
            dynamic dynJson = JsonConvert.DeserializeObject(tokenserver);

            foreach (var item in dynJson)
            {
                String tokenstored=  item.tokenstored;
                
                if(item2.TokenString == tokenstored)
                {
        
                    try 
                    {
                        return _service.UpdateDetails(fileId,FilesDetailsUpdate);
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
           return null;
        }
    }
}