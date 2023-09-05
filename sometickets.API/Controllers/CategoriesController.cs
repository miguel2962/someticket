﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }



        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id_category == id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category category)
        {
            _context.Update(category);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Categories
                .Where(x => x.Id_category == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
