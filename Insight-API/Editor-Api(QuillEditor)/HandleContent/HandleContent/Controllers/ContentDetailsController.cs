using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;
using HandleContent;
using ContentService;
using AutoMapper;

using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Net;

using System.Net.Http.Headers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography;



namespace ContentDetailsInfo.Controllers
{
    [Route("api/[controller]")]
    public class ContentDetailsController:Controller //4.Using the infoservice defined in startup in the controller.
    {
        private IMapper _mapper;
        private IContentDetailsService _service;

        public ContentDetailsController(IContentDetailsService service,IMapper mapper)
        {
            _service=service;
            _mapper=mapper;
        }

        //Retrieves all the content stored in the database.
        [HttpGet] 
        public Task<List<UserContentDetails>> GetAll()
        {
            return _service.Get();
        }

        //Retrieves all the relevant information based on contentId received from client side.
        [HttpGet("{id}")] 
        public Task<List<UserContentDetails>> GetID(int id)
        {
            return  _service.GetByID(id); 
        }
        
         //Updates the data based on contentID received from database passed through API-Gateway.
        [HttpPut("{id}")]
        public Task<int> Put(int id, [FromBody] ContentIdDto item2)
        {
            Console.WriteLine("token"+item2.TokenString);

            var contentDetailsUpdate = _mapper.Map<UserContentDetails>(item2);
            
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
                        return _service.Update(id, contentDetailsUpdate); // Service used for updation.
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                  }
                }
            
           return null;
            
        }

        [HttpDelete("{id}")] //Deletes the data from the database based id received from client side.
        public Task<int> Del(int id)
        {
            return _service.Delete(id);
        }

        [HttpPost] // This controller method is used to post contentdetails from client side to the database passed through API-Gateway.
        public Task<int> Create([FromBody] ContentDto item2)
        {
            Console.WriteLine("token"+item2.TokenString);

            var contentDetailsPost = _mapper.Map<UserContentDetails>(item2);
            
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
                        return _service.Create(contentDetailsPost);//Service used for post operation.
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