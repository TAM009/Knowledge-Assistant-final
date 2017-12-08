using System;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using SettingController.Controllers;
using SettingsService;
using  SettingsModel.Models;
using Moq;
using Settingsmodel;
using SettingsMethodService;
using Microsoft.EntityFrameworkCore;

namespace settings.Tests
{
  public class SettingsTestContext:DbContext
  {

        public SettingsTestContext(DbContextOptions<SettingsTestContext> options): base(options){}        
        public DbSet<Settingslist> UserDetails {get;set;}

        // public DbSet<SettingsPhotolist> UserDetails {get;set;}
  }

  public class SettingsTest
  {
    
    private readonly ISettingsService _service;
    //private SettingsContext _context;

    private readonly SettingsContext _context;
    

    [Fact]
    public void Tests ()    
    {
   

        //   //Arrange
        //   SettingsServiceMethods obj = new SettingsServiceMethods(_context);
          

        //   //Act
        //   Task<List<Settingslist>> var = obj.Get();
        // //   Task<List<Settingslist>> var1 = obj.GetByID(12); 

        //   //Assert
        //   Assert.IsType<Task<List<Settingslist>>>(var);
        // //   Assert.IsType<Task<List<Settingslist>>>(var1);
        var mockrepo=new Mock<ISettingsService>();
        var mockrepo2=new Mock<SettingsContext>();
        var controller= new SettingsController(_context ,mockrepo.Object);

        var result= controller.Get();

        Assert.IsType<Task<List<Settingslist>>> (result);
    }
  }
}


