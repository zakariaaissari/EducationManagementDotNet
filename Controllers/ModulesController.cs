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
            return  _unitOfWork.moduleRepository.findAll();
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

       /* private bool ModuleExists(long id)
        {
            return (_context.modules?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
