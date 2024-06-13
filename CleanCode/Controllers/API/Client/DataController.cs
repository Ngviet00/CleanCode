﻿using Microsoft.AspNetCore.Mvc;
using CleanCode.CommonClass;
using CleanCode.Services.Client;

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
    }
}