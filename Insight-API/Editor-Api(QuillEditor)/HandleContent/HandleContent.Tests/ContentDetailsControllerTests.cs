using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContentDetailsInfo.Controllers;
using ContentService;
using AutoMapper;

namespace HandleContent.Tests
{
    public class ContentDetailsControllerTests
    {
        //private readonly UserContentDetailsContext _context;

        private IMapper _mapper;

        private IContentDetailsService _service; 

        UserContentDetails item;

        ContentDto item1;
        ContentIdDto item2;

        [Fact]
        public void GetAllTest()
        {
            // Arrange
            var mockRepo = new Mock<IContentDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new ContentDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsType<Task<List<UserContentDetails>>>(result);
            
        }

        [Fact]
        public void GetIDTest()
        {
            // Arrange
            var mockRepo = new Mock<IContentDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new ContentDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result =  controller.GetID(3);

            // Assert
            Assert.IsType<Task<List<UserContentDetails>>>(result);
            
        }

        [Fact]
        public async Task CreateTest()
        {
            // Arrange
            var mockRepo = new Mock<IContentDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new ContentDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = await controller.Create(item1);

            // Assert
            Assert.IsType<int>(result);
            
        }

        [Fact]
        public async Task PutTest()
        {
            // Arrange
            var mockRepo = new Mock<IContentDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new ContentDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result =  await controller.Put(3,item2);

            // Assert
            Assert.IsType<int>(result);
            
        }

        [Fact]
        public async Task DelTest()
        {
            // Arrange
            var mockRepo = new Mock<IContentDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new ContentDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result =  await controller.Del(5);

            // Assert
            Assert.IsType<int>(result);
        }
    }
}