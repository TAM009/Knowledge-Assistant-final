using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
//using ContentDetails.Controllers;
using FilesDetailsInfo.Controllers;
using FilesDetailsService;
using HandleContent;
using AutoMapper;


namespace HandleContent.Tests
{
    public class FilesDetailsControllerTests
    {
        private IMapper _mapper;

        public readonly UserFileDetailsContext _context;

        UserFileDetails item;

        FileDto item1;
        FileIdDto item2;

        [Fact]
        public void GetAllFilesTest()
        {
            //Arrange
            var mockRepo = new Mock<IFilesDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new FilesDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = controller.GetAllFiles();

            // Assert
            Assert.IsType<Task<List<UserFileDetails>>>(result);
        }  

        [Fact]
        public async Task CreateFilesTest()
        {
            //Arrange
            var mockRepo = new Mock<IFilesDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new FilesDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = await controller.CreateFileDetails(item1);

            // Assert
            Assert.IsType<bool>(result);
        } 

        [Fact]
        public async Task UpdateFilesTest()
        {
            //Arrange
            var mockRepo = new Mock<IFilesDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new FilesDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = await controller.UpdateDetails(1,item2);

            // Assert
            Assert.IsType<bool>(result);
        }

        [Fact]
        public async Task GetFileNameByIdTest()
        {
            //Arrange
            var mockRepo = new Mock<IFilesDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new FilesDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = await controller.GetFileNameByContentId(3,2);

            // Assert
            Assert.IsType<List<UserFileDetails>>(result);
        } 

        [Fact]
        public async Task DeleteFilesTest()
        {
           //Arrange
            var mockRepo = new Mock<IFilesDetailsService>();
            var mockRepo2=new Mock<IMapper>();
            var controller = new FilesDetailsController(mockRepo.Object,mockRepo2.Object);

            // Act
            var result = await controller.DeleteFile(3,2,item2);

            // Assert
            Assert.IsType<bool>(result);
        } 


    }
}