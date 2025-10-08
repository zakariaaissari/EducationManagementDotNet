using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet(Name = "studants")]
        public List<Studant> getstudents()
        {
            return unitOfWork.studantRepository.findAll();
        }

    }
}
