using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly DataContext _context;

        public IssueController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> Get(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null) return BadRequest("Issue Not Found");
            return Ok(issue);
        }

        [HttpGet]
        public async Task<ActionResult<List<Issue>>> Get()
        {
            return Ok(await _context.Issues.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Issue>>> AddIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return Ok(await _context.Issues.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Issue>>> UpdateIssue(Issue request)
        {
            var dbIssue = await _context.Issues.FindAsync(request.Id);
            if (dbIssue == null) return BadRequest("Issue Not Found");

            dbIssue.Name = request.Name;
            dbIssue.Description = request.Description;
            dbIssue.Priority = request.Priority;
            dbIssue.IsCompleted = request.IsCompleted;

            await _context.SaveChangesAsync();

            return Ok(await _context.Issues.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Issue>>> Delete(int id)
        {
            var dbIssue = await _context.Issues.FindAsync(id);
            if (dbIssue == null) return BadRequest("Issue Not Found");
            _context.Issues.Remove(dbIssue);
            await _context.SaveChangesAsync();

            return Ok(await _context.Issues.ToListAsync());
        }
    }
}
