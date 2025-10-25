using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApi : ControllerBase
    {
        IUnitOfWork unitOfWork { get; set; }

        public StudentApi(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/StudentApi
        [HttpGet]
        public List<Studant> getstudents()
        {
            return unitOfWork.studantRepository.findAll();
        }

        // GET: api/StudentApi/5
        [HttpGet("{id}")]
        public ActionResult<Studant> GetStudent(long id)
        {
            if (unitOfWork.studantRepository == null)
            {
                return NotFound();
            }
            var student = unitOfWork.studantRepository.findById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/StudentApi
        [HttpPost]
        public ActionResult<Studant> PostStudent(Studant student)
        {
            if (unitOfWork.studantRepository == null)
            {
                return Problem("Entity set 'ApplicationContext.studants' is null.");
            }

            unitOfWork.studantRepository.add(student);
            unitOfWork.complete();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // PUT: api/StudentApi/5
        [HttpPut("{id}")]
        public ActionResult<Studant> PutStudent(long id, Studant student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                unitOfWork.studantRepository.update(student);
                unitOfWork.complete();
                return Ok(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/StudentApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            if (unitOfWork.studantRepository == null)
            {
                return NotFound();
            }
            var student = unitOfWork.studantRepository.findById(id);
            if (student == null)
            {
                return NotFound();
            }

            unitOfWork.studantRepository.remove(student);
            unitOfWork.complete();

            return NoContent();
        }

        private bool StudentExists(long id)
        {
            return (unitOfWork.studantRepository.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
