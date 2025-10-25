using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestreController : ControllerBase
    {

        // private readonly ApplicationContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public SemestreController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/semestres
        [HttpGet]
        public List<Semestre> Getsemestres()
        {
            if (_unitOfWork.semestreRepository == null)
            {
                return null;// NotFound();
            }
            return _unitOfWork.semestreRepository.Query.Include(s => s.Modules).ToList();
           // return _unitOfWork.semestreRepository.findAll();
        }

        // GET: api/semestres/5
        [HttpGet("{id}")]
        public ActionResult<Semestre> Getsemestre(long id)
        {
            if (_unitOfWork.semestreRepository == null)
            {
                return NotFound();
            }
         /*   var @semestre = _unitOfWork.semestreRepository.findById(id);
            List<Module> ms = _unitOfWork.moduleRepository.findByCretiria(s => s.Sem.Id == id).ToList();
            @semestre.Modules = ms;*/

            var @semestre=  _unitOfWork.semestreRepository.Query.Include(s=> s.Modules).Where(w=>w.Id== id).First();   

            if (@semestre == null)
            {
                return NotFound();
            }

            return @semestre;
        }



        // POST: api/semestres
        [HttpPost]
        public ActionResult<Semestre> Postsemestre(Semestre @semestre)
        {
            if (_unitOfWork.semestreRepository == null)
            {
                return Problem("Entity set 'ApplicationContext.semestres'  is null.");
            }
            _unitOfWork.semestreRepository.add(@semestre);
            _unitOfWork.complete();

            return CreatedAtAction("Getsemestre", new { id = @semestre.Id }, @semestre);
        }

        // PUT: api/semestres/5
        [HttpPut("{id}")]
        public ActionResult<Semestre> PutSemestre(long id, Semestre semestre)
        {
            if (id != semestre.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.semestreRepository.update(semestre);
                _unitOfWork.complete();
                return Ok(semestre);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemestreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/semestres/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSemestre(long id)
        {
            if (_unitOfWork.semestreRepository == null)
            {
                return NotFound();
            }
            var semestre = _unitOfWork.semestreRepository.findById(id);
            if (semestre == null)
            {
                return NotFound();
            }

            _unitOfWork.semestreRepository.remove(semestre);
            _unitOfWork.complete();

            return NoContent();
        }

        private bool SemestreExists(long id)
        {
            return (_unitOfWork.semestreRepository.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
