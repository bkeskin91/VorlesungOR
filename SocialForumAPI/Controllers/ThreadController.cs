using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialForumData;
using SocialForumData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly SocialForumContext _context;

        public ThreadController(SocialForumContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Thread>> GetAllThreads()
        {
            return _context.Threads
                .Include(thread => thread.Comments)
                    .ThenInclude(comments => comments.Author)
                .Include(t => t.Creator)
                .ToList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Thread> GetThreadByID(int id)
        {
            return _context.Threads
                .Include(thread => thread.Comments)
                    .ThenInclude(comments => comments.Author)
                .Include(t => t.Creator)
                .FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<int> CreateThread([FromBody] Thread thread)
        {
            Thread newItem = new Thread();

            newItem.Title = thread.Title;
            newItem.Description = thread.Description;
            newItem.Created = thread.Created;
            newItem.Creator = _context.Users.First(x => x.Username.Equals(thread.Creator.Username));
            newItem.LikeCount = 0;
            _context.Threads.Add(newItem);
            _context.SaveChanges();

            return _context.Threads.First(x => x.Title == thread.Title).Id;

        }

    }
}
