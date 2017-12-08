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
using Microsoft.AspNetCore.Http;
// using System.Net.Http.Headers;
// using WebApi.Dtos;




namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    public class AmazonS3UploadController : Controller
    {
        
       /* [HttpPost]
        public async Task<string> UploadToS3([FromBody] FileUploadDto item)
        {
            Console.WriteLine("items"+item.File);
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
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));          
            AppConfig api=new AppConfig();
            //var stringTask = await client.PostAsync(api.amazonUploadUrl + "api/AmazonS3Upload",new StringContent(JsonConvert.SerializeObject(item),Encoding.UTF8,"application/json"));
            //var msg=stringTask.Content.ReadAsStringAsync().Result;
            //Console.WriteLine("Result is"+msg);
            return msg;
        }*/
    }
}
