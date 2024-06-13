using CleanCode.Services.Interface;

namespace CleanCode.Services
{
    public class JobService : IJobService
    {
        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello from a Fire and Forget job!");
        }

        public void ReccuringJob()
        {
            Console.WriteLine("Hello from a reccuring job!");
        }

        public void DelayedJob()
        {
            Console.WriteLine("Hello from a Delayed job!");
        }

        public void ContinuationJob()
        {
            Console.WriteLine("Hello from a Continuation job!");
        }
    }
}
