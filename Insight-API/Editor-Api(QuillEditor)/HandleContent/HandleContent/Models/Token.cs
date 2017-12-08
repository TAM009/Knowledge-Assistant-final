using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HandleContent;

namespace HandleContent
{
public class AuthenticationTokenClass
    {
       public async Task<string> AuthenticationToken(TokenDto tokendto)
        {   
            // stored token checking from tokenserver     
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            var stringTask = await client.PostAsync( "http://localhost:5003/api/token/tokenretreiver",new StringContent(JsonConvert.SerializeObject(tokendto),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("token stored "+msg);
            return msg; 
        }
    }
}
