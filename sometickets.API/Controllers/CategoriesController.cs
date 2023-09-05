using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sometickets.API.Data;
using sometickets.Shared.Entities;

namespace sometickets.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;
        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        
    }
}
