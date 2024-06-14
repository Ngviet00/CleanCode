namespace CleanCode.Application.Job.Hangfire.Interface
{
    public interface IJobService
    {
        void FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
