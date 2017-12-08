using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using searchresult;
using ContentData;
using searchcontext;

namespace FavouritesController.Controllers
{
    [Route("api/[controller]")]
    public class FetchSearchResultController : Controller
    {
        private readonly SearchContext _context;

       public FetchSearchResultController(SearchContext context)
        {
            _context = context;

        }
         [HttpPost]
            public  List<List<UserContentFileDetails>> GetAll([FromBody] SearchResult searchId)
            {  
             int i;     
              int[] asIntegers = searchId.JsonString.Select(s => int.Parse(s)).ToArray(); 
              for(i=0;i<asIntegers.Length-1;i++){
                Console.WriteLine(asIntegers[i]);}
              List<List<UserContentFileDetails>> objfavlist=new List<List<UserContentFileDetails>>();
              for( i=0;i<asIntegers.Length;i++){
                  if(asIntegers[i]>0){   
               var query=_context.UserContentDetails.FromSql("select B.FileId,B.ContentId,A.Content,B.FileName,B.FilePath from UserContentDetails A full join UserFileDetails B on A.ContentId=B.ContentId where A.ContentId="+asIntegers[i]+"and A.IsDelete=0 and A.IsPrivate=0 and B.IsDelete=0 and B.IsPrivate=0").ToList();
                objfavlist.Add(query);
                  }
            }
            return objfavlist;
            }    

    }
}
