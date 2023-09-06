using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sometickets.API.Data;
using sometickets.API.Migrations;
using sometickets.Shared.Entities;

namespace sometickets.API.Controllers
{
    [ApiController]
    [Route("/api/workTypes")]
    public class WorkTypesController : Controller
    {
        private readonly DataContext _context;
        public WorkTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAsync()
        {
            return Ok(await _context.WorkTypes.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAsync(WorkTypes worktypes)
        {
            _context.WorkTypes.Add(worktypes);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(worktypes);
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var worktypes = await _context.WorkTypes.FirstOrDefaultAsync(x => x.Id_worktype == id);
            if (worktypes is null)
            {
                return NotFound();
            }

            return Ok(worktypes);
        }

        [HttpPut]
        public async Task<ActionResult> Put(WorkTypes workTypes)
        {
            _context.Update(workTypes);
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok(workTypes);
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
            var afectedRows = await _context.WorkTypes
                .Where(x => x.Id_worktype == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
