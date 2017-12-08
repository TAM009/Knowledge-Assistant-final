using System;
using Xunit;
using WebApi.FacebookEntities;
using WebApi.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.FacebookDatatransfer;
using AutoMapper;
using dataservice;
using Moq;
using SocialEntities.controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API_Google.Tests
{
    public class UnitTest1
    {


      private static DbContextOptions<FacebookDataContext> CreateNewContextOptions()
      {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<FacebookDataContext>();
            builder.UseInMemoryDatabase("testfacebook")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
       }
        

        [Fact]
        public void Test1()
        {
  
           using (var context = new FacebookDataContext(CreateNewContextOptions()))
           {
            
            UserDetails UD = new UserDetails();

            UD.UserId =12;
            UD.FirstName="sumanth";
            UD.LastName="sumanth";
            UD.Username="sumanth";
            UD.Email="sumanth@gmail.com";
            DataServiceClass dsc = new DataServiceClass(context);
            var str= dsc.Create(UD);
            Assert.IsType<UserDetails>(str);
           
           }
        }
    }
}
