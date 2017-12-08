using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using tokennamespace;
using WebApi.GatewayTokenDtos;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    public class FilesDetailsController : Controller
    {

        //Method to pass data to quilleditor backend for update.
        [HttpPut("{fileId}/{contentId}")]
        public async void PutByFileIdAndContentId(int fileId,int contentId, [FromBody] FileIdDto item)
        {
            Console.WriteLine("Inside contentdetails gateway update");
            GatewayTokenClass gatewayTokenClassObjRef = new GatewayTokenClass();
            GatewayTokenDto tokendtoRef = new GatewayTokenDto();
            string tokenref = gatewayTokenClassObjRef.GatewayToken(tokendtoRef).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var obj3= JObject.Parse(tokenref);
            string token= obj3["token"].ToString(); 
            Console.WriteLine("token"+token);
            //passing token from gateway to respective microservice
            item.TokenString= token;
                //Microservice request
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            AppConfig api=new AppConfig();
            var stringTask = await client.PutAsync(api.filesDetailsUrl + "api/FilesDetails"+"/"+fileId+"/"+contentId,new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result is"+msg);
            
        }

        //Method to pass data to quilleditor backend for update.
        [HttpPut("{fileId}")]
        public async void PutByFileId(int fileId, [FromBody] FileIdDto item)
        {
            Console.WriteLine("Inside contentdetails gateway update");
            GatewayTokenClass gatewayTokenClassObjRef = new GatewayTokenClass();
            GatewayTokenDto tokendtoRef = new GatewayTokenDto();
            string tokenref = gatewayTokenClassObjRef.GatewayToken(tokendtoRef).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var obj3= JObject.Parse(tokenref);
            string token= obj3["token"].ToString(); 
            Console.WriteLine("token"+token);
            //passing token from gateway to respective microservice
            item.TokenString= token;
                //Microservice request
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            AppConfig api=new AppConfig();
            var stringTask = await client.PutAsync(api.filesDetailsUrl + "api/FilesDetails"+"/"+fileId,new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result is"+msg);
            
        }

        //Method to pass data to quilleditor backend to update method.
        [HttpPost]
        public async Task<string> Create([FromBody] FileDto item)
        {
            
            Console.WriteLine("Inside contentdetails gateway");
            GatewayTokenClass gatewayTokenClassObjRef = new GatewayTokenClass();
            GatewayTokenDto tokendtoRef = new GatewayTokenDto();
            string tokenref = gatewayTokenClassObjRef.GatewayToken(tokendtoRef).Result ;
            object jsonObject = JsonConvert.DeserializeObject(tokenref);
            var obj3= JObject.Parse(tokenref);
            string token= obj3["token"].ToString(); 
            Console.WriteLine("token"+token);
            //passing token from gateway to respective microservice
            item.TokenString= token;
                //Microservice request
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            AppConfig api=new AppConfig();
            var stringTask = await client.PostAsync(api.filesDetailsUrl + "api/FilesDetails",new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result is"+msg);
            return msg; 

        }
    }
}
