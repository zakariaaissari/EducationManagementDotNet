using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using isgasoir;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModulesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/Modules
        [HttpGet]
        public  List<Module> Getmodules()
        {
          if (_unitOfWork.moduleRepository == null)
          {
                return null;// NotFound();
          }
            return _unitOfWork.moduleRepository.Query.Include(m => m.Sem).ToList();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public  ActionResult<Module> GetModule(long id)
        {
          if (_unitOfWork.moduleRepository == null)
          {
              return NotFound();
          }
            var @module =  _unitOfWork.moduleRepository.findById(id);

            if (@module == null)
            {
                return NotFound();
            }

            return @module;
        }


        [HttpGet("/search")]
        public ActionResult<List<Module>> GetModuleByName(string name)
        {
            if (_unitOfWork.moduleRepository == null)
            {
                return NotFound();
            }
            var @listmodule = _unitOfWork.moduleRepository.findByCretiria(m => m.Name.ToLower().Contains(name.ToLower())).ToList();

            if (@listmodule == null)
            {
                return NotFound();
            }

            return @listmodule;
        }


        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idsem}")]
        public  ActionResult<Module> PostModule(Module @module, long idsem)
        {
          if (_unitOfWork.moduleRepository == null)
          {
              return Problem("Entity set 'ApplicationContext.modules'  is null.");
          }

            Semestre? sem = _unitOfWork.semestreRepository.findById(idsem);
            @module.Sem = sem;
            _unitOfWork.moduleRepository.add(@module);
            _unitOfWork.complete();

            return CreatedAtAction("GetModule", new { id = @module.Id }, @module);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public ActionResult<Module> PutModule(long id, Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.moduleRepository.update(module);
                _unitOfWork.complete();
                return Ok(module);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public IActionResult DeleteModule(long id)
        {
            if (_unitOfWork.moduleRepository == null)
            {
                return NotFound();
            }
            var module = _unitOfWork.moduleRepository.findById(id);
            if (module == null)
            {
                return NotFound();
            }

            _unitOfWork.moduleRepository.remove(module);
            _unitOfWork.complete();

            return NoContent();
        }

        private bool ModuleExists(long id)
        {
            return (_unitOfWork.moduleRepository.Query?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
