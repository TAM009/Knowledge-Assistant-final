namespace WebApi.Dtos
{
    public class ContentDto
    {
        public int deleteid{get; set;}
        public int UserId { get; set; }
        public string Content { get; set; }
        public string MetaTags { get; set; }
        public string CreatedBy { get; set; }
        public bool IsPrivate{get; set;}
        public string TokenString{get;set;}
      
    }


}