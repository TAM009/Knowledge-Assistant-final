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

    public class UserFileDetailsController : Controller
    {
    private readonly Sharewithcontext _context;

        public UserFileDetailsController(Sharewithcontext context)
        {
            _context = context;
        }

        [HttpGet] //retrieves all the data in the UserFileDetails table
        public async Task<List<UserFileDetails>> GetAllUserDetails()
            {
                try{
                return await _context.UserFileDetails.ToListAsync();
                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }

        [HttpGet("{User_userID}/{User_contentID}")] //retrives all rows that matches both the prescribed userID and
        //contentID simultaneously
            public async Task<UserFileDetails> GetbyUser_userID (int User_userID, int User_contentID, [FromBody] UserDetails item)
            {   
                try{
                UserFileDetails todo =await _context.UserFileDetails.FirstOrDefaultAsync(t => (t.UserID == User_userID) && (t.ContentID == User_contentID) );
                 return todo;
                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
    }
}