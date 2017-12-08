using System;

namespace HandleContent
{
    public class ContentIdDto
    {
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public string MetaTags { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsGraphCreated { get; set; }
        public bool IsFavourites { get; set;} 
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDelete { get; set;}
        public DateTime ModifiedOn { get; set; }
        public string TokenString{get;set;}
    }

}