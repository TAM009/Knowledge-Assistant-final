using System;

namespace WebApi.Dtos
{
    public class FileIdDto
    {
        public int FileId { get; set;}
        public int ContentId {get;set;}
        public int UserId{get;set;}
        public string FilePath{get;set;}
        public string FileName{get;set;}
        public string FileType{ get; set;}
        public bool IsPrivate{get;set;}
        public bool IsGraphCreated{get;set;}
        public bool IsFavourites{get;set;}
        public string CreatedBy{get;set;}
        public DateTime CreatedOn{get;set;}
        public bool IsDelete{get;set;}
        public DateTime ModifiedOn{get;set;}
        public string TokenString{get;set;}
      
    }

}