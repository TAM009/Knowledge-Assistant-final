namespace WebApi.Dtos
{
    public class FileDto
    {
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileType{get; set;}
        public string CreatedBy{get;set;}
        public string TokenString{get;set;}
      
    }

}