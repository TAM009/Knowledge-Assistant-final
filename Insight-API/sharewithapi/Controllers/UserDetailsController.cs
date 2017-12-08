using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
// using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")] 
    public class UserDetailsController: Controller
    {
        private readonly Sharewithcontext _context;
        // private readonly UserDetailsService _service;

        public UserDetailsController(Sharewithcontext context /*UserDetailsService service*/)
        {
            _context = context;
        
        } 
 
        [HttpGet]
       [Route("GetClientList/term")]  //this functionnchecks whether a sequence that is input as "term"
       // is present in the FirstName of all the rows present and if present, returns that row
       public  Microsoft.AspNetCore.Mvc.OkObjectResult GetUserbysearchedletters(string term)  
        {  try{
            var clientList = from c in _context.UserDetails  
                             where c.FirstName.Contains(term)  
                             select c;  
             return  Ok(clientList); 
        }catch(Exception ex){
            return Ok(ex);
        }
         }  
            

        [HttpGet] //returns all the data present in the UserDetails table
        public async Task<List<UserDetails>> GetAllUserDetails()
            {
                try{
                return await _context.UserDetails.ToListAsync();
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
        
          
            [HttpGet]//gets the row whose UserID matches with the prescribed userid
            [Route("getbyuserid/{userid}")]
            public async Task<UserDetails> GetbyuserID (int userid, [FromBody] UserDetails item)
            {
                try{
                 UserDetails todo =await _context.UserDetails.FirstOrDefaultAsync(t => t.UserID == userid);
                 return todo;
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }

            [HttpGet] //gets the row whose FirstName matches with the prescribed firstname
            [Route("getbyfirstname/{firstname}")]
            public /*async Task<UserDetails>*/ Microsoft.AspNetCore.Mvc.OkObjectResult GetbyFirstname (string firstname, [FromBody] UserDetails item)
            {
                try{
                 /*UserDetails*/ var todo =/*await*/ _context.UserDetails.FirstOrDefaultAsync(t => t.FirstName==firstname);
                 return Ok(todo);
                }
                catch(Exception ex)
                {
                  return Ok(ex);
                }
            }

            [HttpPost] //posts data into the UserDetails table
            public async Task Post([FromBody] UserDetails item)
            {
                try{
                _context.UserDetails.Add(item);
                await _context.SaveChangesAsync();
                }
                catch(Exception ex){
                    throw new Exception(ex.Message);
                }

                
            }
    }
}