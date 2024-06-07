using CleanCode.Services.Interface;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace CleanCode.Controllers.API.User
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public JobController(IJobService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _jobService = jobTestService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet("/fire-and-forget-job")]
        public ActionResult FireAndForgetJob()
        {
            _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());

            return Ok();
        }

        [HttpGet("/delayed-job")]
        public ActionResult DelayedJob()
        {
            _backgroundJobClient.Schedule(() => _jobService.DelayedJob(), TimeSpan.FromSeconds(60));

            return Ok();
        }

        [HttpGet("/reccuring-job")]
        public ActionResult ReccuringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _jobService.ReccuringJob(), Cron.Minutely);

            return Ok();
        }

        [HttpGet("/continuation-job")]
        public ActionResult ContinuationJob()
        {
            var parentJobId = _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());
            _backgroundJobClient.ContinueJobWith(parentJobId, () => _jobService.ContinuationJob());

            return Ok();
        }
    }
}
