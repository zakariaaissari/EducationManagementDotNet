using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using isgasoir;
using isgasoir.Services.ServiceApi;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapitresController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitOfWork;
       private readonly LLMApi _llmApi;

        public ChapitresController(IUnitOfWork unitOfWork, LLMApi llm)
        {
            _unitOfWork = unitOfWork;
            _llmApi = llm;

        }


        // GET: api/Chapitres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapitre>>> Getchapitres()
        {
            if (_unitOfWork.chapitreRepository == null)
            {
                return NotFound();
            }
            // Include Module navigation property to get module information
            return await Task.FromResult(_unitOfWork.chapitreRepository.Query.Include(c => c.Module).ToList());
        }

        // GET: api/Chapitres/5
        // Remplacement de la méthode GetChapitre pour utiliser Task.FromResult afin de respecter la nature async
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapitre>> GetChapitre(long id)
        {
          if (_unitOfWork.chapitreRepository == null)
          {
              return NotFound();
          }
            var chapitre = _unitOfWork.chapitreRepository.findById(id);

            if (chapitre == null)
            {
                return NotFound();
            }

            return await Task.FromResult(chapitre);
        }

        // PUT: api/Chapitres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapitre(long id, Chapitre chapitre)
        {
            if (id != chapitre.Id)
            {
                return BadRequest();
            }

            try
            {
                await Task.Run(() =>
                {
                    // Ici, vous pouvez ajouter la logique de mise à jour si nécessaire, par exemple :
                     _unitOfWork.chapitreRepository.update(chapitre);
                    _unitOfWork.complete();
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapitreExists(id))
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

        // POST: api/Chapitres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idm}")]
        public async Task<ActionResult<Chapitre>> PostChapitre(Chapitre chapitre, long idm)
        {
            if (_unitOfWork.chapitreRepository == null)
            {
                return Problem("Entity set 'ApplicationContext.chapitres'  is null.");
            }
            await Task.Run(() =>
            {
                Module? mod = _unitOfWork.moduleRepository.findById(idm);
                if (mod == null)
                {
                    //throw new Exception("Module not found");
                }
                else
                {
                    chapitre.Module = mod;
                    _unitOfWork.chapitreRepository.add(chapitre);
                    _unitOfWork.complete();
                }
            });

            return CreatedAtAction("GetChapitre", new { id = chapitre.Id }, chapitre);
        }

        // DELETE: api/Chapitres/5
        // Remplacement de la méthode DeleteChapitre pour utiliser Task.Run afin d'utiliser l'opérateur await et corriger CS1998
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapitre(long id)
        {
            if (_unitOfWork.chapitreRepository == null)
            {
                return NotFound();
            }
            var chapitre = await Task.Run(() => _unitOfWork.chapitreRepository.findById(id));
            if (chapitre == null)
            {
                return NotFound();
            }

            await Task.Run(() => {
                _unitOfWork.chapitreRepository.remove(chapitre);
                _unitOfWork.complete();
            });

            return NoContent();
        }

        private bool ChapitreExists(long id)
        {
            return (_unitOfWork.chapitreRepository.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("generate")]
        public async Task<IActionResult> Generate(string prompt)
        {
            var result = await _llmApi.GenerateTextAsync(prompt);

            return Ok(result);
        }

    }
}
