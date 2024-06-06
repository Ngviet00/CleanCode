using Microsoft.AspNetCore.Mvc;
using Clean_Code.Services;

namespace CleanCode.Controllers.API.User
{
    [Route("api/data/")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly DataService _dataService;

        public DataController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new
            {
                status = 200,
                message = "Success!"
            });
        }

        [Route("test-method-post")]
        [HttpPost]
        public ActionResult TestPost()
        {
            return Ok(new
            {
                status = 200,
                message = "Success!"
            });
        }
    }
}
