using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly TeacherDBContext _context;

        public DepartmentController(TeacherDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentsList(DateTime? foundationDate, int? minTeachers)
        {
            var query = _context.Departments
                .Include(d => d.Head)
                .Include(d => d.Teachers)
                .AsQueryable();

            if (foundationDate.HasValue)
            {
                query = query.Where(d => d.FoundationDate >= foundationDate.Value);
            }

            if (minTeachers.HasValue)
            {
                query = query.Where(d => d.Teachers.Count >= minTeachers.Value);
            }

            var departments = await query.ToListAsync();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingDepartmentById = _context.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (existingDepartmentById != null)
            {
                return BadRequest("Кафедра с таким ID уже существует.");
            }

            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == department.HeadId);
            if (existingTeacher == null)
            {
                return BadRequest("Преподаватель с таким ID не существует.");
            }

            var existingDepartment = _context.Departments.FirstOrDefault(d => d.HeadId == department.HeadId);
            if (existingDepartment != null)
            {
                return BadRequest("Этот преподаватель уже является главой другой кафедры.");
            }

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartmentsList), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentInfo(int id, [FromBody] Department department)
        {
            if (id != department.Id)
                return BadRequest("ID не совпадают");

            if (!_context.Departments.Any(d => d.Id == id))
                return NotFound("Кафедра не найдена");

            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentById(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Teachers)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                return NotFound("Кафедра не найдена");

            _context.Teachers.RemoveRange(department.Teachers);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
