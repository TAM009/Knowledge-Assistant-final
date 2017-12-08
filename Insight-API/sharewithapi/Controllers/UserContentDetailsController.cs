
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    
        public class UserContentDetailsController : Controller
        {
            private readonly Sharewithcontext _context;
        
        public UserContentDetailsController (Sharewithcontext context /*UserDetailsService service*/)
        {
            _context = context;
        }

        [HttpGet] //gets all the details in the UserContentDetailstable
        public async Task<List<UserContentDetails>> GetAllUserContentDetails()
            {
                try{
                return await _context.UserContentDetails.ToListAsync();
                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
            
        [HttpGet("{userID}")] //gets all the data that matches with the prescribed UserID
            public async Task<UserContentDetails> GetallbyUserID (int UserID, [FromBody] UserContentDetails item)
            {
                try{
                UserContentDetails todo =await _context.UserContentDetails.FirstOrDefaultAsync(t => t.UserID == UserID);
                 return todo;
                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }

            [HttpGet("getallbycontentID/{contentID}")] //gets all the data that matches with the prescribed
            //contentID from the Content Details table
            public /*async Task<UserContentDetails>*/ IActionResult GetallbyContentID (int ContentID, [FromBody] UserContentDetails item)
            {
                try{
                var todo = _context.UserContentDetails.FirstOrDefaultAsync(t => t.ContentID == ContentID);
                 return new ObjectResult(todo);
                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
    }
}