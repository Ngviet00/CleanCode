using Microsoft.AspNetCore.Mvc;
using Clean_Code.Services;
using CleanCode.CommonClass;

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
        public async Task<ActionResult> Index()
        {
            return Ok(new
            {
                status = 200,
                value = await CmFunc.ReadValueFileSetting("current_model"),
                message = "Success!"
            });
        }

        [Route("test-method-post")]
        [HttpPost]
        public async Task<ActionResult> TestPost(string value)
        {
            await CmFunc.UpdateValueFileSetting("current_model", value);

            return Ok(new
            {
                status = 200,
                message = "Success!"
            });
        }
    }
}
