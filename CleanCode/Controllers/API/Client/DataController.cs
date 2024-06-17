using Microsoft.AspNetCore.Mvc;
using CleanCode.Application.Services.Client;
using CleanCode.Common;

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
                value = await Func.ReadValueFileSetting("current_model"),
                message = "Success!"
            });
        }

        [Route("post-method")]
        [HttpPost]
        public async Task<ActionResult> Post(string value)
        {
            await Func.UpdateValueFileSetting("current_model", value);

            return Ok(new
            {
                status = 200,
                message = "Success!"
            });
        }

        [HttpGet("/test-get-data")]
        public async Task<ActionResult> GetDataTest()
        {
            return Ok(new
            {
                status = 200,
                data = await _dataService.GetData(),
                message = "Success!"
            });
        }
    }
}
