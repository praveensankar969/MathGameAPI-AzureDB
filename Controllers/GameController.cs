using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MathGameAPI.DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MathGameAPI.Controllers
{
    [Route("api")]
    public class GameController : BaseAPIController
    {
        private readonly DataContext _context;
        public GameController(DataContext context)
        {
            this._context = context;

        }
        [HttpGet("test")]
        public  ActionResult<string> Test()
        {
           return "Test Working";
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetName(int id)
        {
           return await _context.Users.FindAsync(id);
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(){
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddUser(User userData){
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == userData.Id);
            if(user!=null){
                return BadRequest("User Exist!!");
            }
            else if(user!=null && user.Name == userData.Name){
                return BadRequest("Username Taken");
            }
            else{
                await _context.AddAsync(userData);
            }

            await _context.SaveChangesAsync();
            return "User Added";
        }

        [HttpPatch("{name}")]
        public async Task<ActionResult<User>> UpdateScore(User userData){
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Id == userData.Id);
            if(user==null){
                return BadRequest("No such User");
            }
            user.CurrentScore = userData.CurrentScore;
            user.HighScore = userData.HighScore;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}