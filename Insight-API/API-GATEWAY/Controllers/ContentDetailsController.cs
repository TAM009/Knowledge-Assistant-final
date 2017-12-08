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
    public class ContentDetailsController : Controller
    {
        //This method is used to pass the data from gateway to Quill Editor backend for update function.
        [HttpPut("{id}")] 
        public async void Put(int id, [FromBody] ContentIdDto item)
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
            var stringTask = await client.PutAsync(api.contentDetailsUrl + "api/ContentDetails"+"/"+id,new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result is"+msg);
            
        }

        //This method is used to pass the data from gateway to Quill Editor backend to the post function.
        [HttpPost]
        public async Task<string> Create([FromBody] ContentDto item)
        {
            Console.WriteLine("items"+item.Content);
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
            var stringTask = await client.PostAsync(/*api.contentDetailsUrl */"http://localhost:5005/"+ "api/ContentDetails",new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            var msg=stringTask.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result is"+msg);
            return msg; 

        }
    }
}
