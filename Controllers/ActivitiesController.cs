using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            if (_unitOfWork.activityRepository == null)
            {
                return NotFound();
            }
            return await Task.FromResult(_unitOfWork.activityRepository.findAll());
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(long id)
        {
            if (_unitOfWork.activityRepository == null)
            {
                return NotFound();
            }
            var activity = _unitOfWork.activityRepository.findById(id);

            if (activity == null)
            {
                return NotFound();
            }

            return await Task.FromResult(activity);
        }

        // GET: api/Activities/chapitre/5
        [HttpGet("chapitre/{chapitreId}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByChapitre(long chapitreId)
        {
            if (_unitOfWork.activityRepository == null)
            {
                return NotFound();
            }
            
            var activities = _unitOfWork.activityRepository.findByCretiria(a => a.ChapitreId == chapitreId).ToList();
            return await Task.FromResult(activities);
        }

        // GET: api/Activities/type/TP
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByType(string type)
        {
            if (_unitOfWork.activityRepository == null)
            {
                return NotFound();
            }
            
            var activities = _unitOfWork.activityRepository.findByCretiria(a => a.Type.ToLower() == type.ToLower()).ToList();
            return await Task.FromResult(activities);
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(long id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            try
            {
                await Task.Run(() =>
                {
                    _unitOfWork.activityRepository.update(activity);
                    _unitOfWork.complete();
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Activities
        [HttpPost("{chapitreId}")]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity, long chapitreId)
        {
            if (_unitOfWork.activityRepository == null)
            {
                return Problem("Entity set 'ApplicationContext.activities' is null.");
            }

            await Task.Run(() =>
            {
                Chapitre? chapitre = _unitOfWork.chapitreRepository.findById(chapitreId);
                if (chapitre == null)
                {
                    throw new Exception("Chapitre not found");
                }
                else
                {
                    activity.ChapitreId = chapitreId;
                    activity.Chapitre = chapitre;
                    _unitOfWork.activityRepository.add(activity);
                    _unitOfWork.complete();
                }
            });

            return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(long id)
        {
            if (_unitOfWork.activityRepository == null)
            {
                return NotFound();
            }
            var activity = await Task.Run(() => _unitOfWork.activityRepository.findById(id));
            if (activity == null)
            {
                return NotFound();
            }

            await Task.Run(() => {
                _unitOfWork.activityRepository.remove(activity);
                _unitOfWork.complete();
            });

            return NoContent();
        }

        private bool ActivityExists(long id)
        {
            return (_unitOfWork.activityRepository.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
