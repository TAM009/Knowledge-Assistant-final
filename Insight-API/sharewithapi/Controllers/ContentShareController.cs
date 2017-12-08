using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;
using System;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    public class ContentShareController : Controller
    {
        private readonly Sharewithcontext _context;

        public ContentShareController (Sharewithcontext context)
        {
            _context = context;
        }

        [HttpGet] //just retrieves all the data in the ContentShare table
        public async Task<List<ContentShare>> GetAllContentShare(){
            try{
            return await _context.ContentShare.ToListAsync();
            }
            catch(Exception ex){
                    throw new Exception(ex.Message);
                }
        }
                //retrieves all the data in the content share table that matches the contentID that we asks for
         [HttpGet("getallbycontentid/{ContentID}")] 
            
            public async Task<ContentShare> GetbycontentID (int contentid, [FromBody] UserDetails item)
            {
                try{
                 ContentShare todo =await _context.ContentShare.FirstOrDefaultAsync(t => t.ContentID == contentid);
                 return todo;
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }

        [HttpPost] //function to post in the Content share table
        public async Task Post([FromBody] ContentShare item)
            {
                try
                {
                    Console.WriteLine(item);
                    item.CreatedOn=System.DateTime.Now;
                    item.ModifiedOn=System.DateTime.Now;
                _context.ContentShare.Add(item);
                await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    }
}