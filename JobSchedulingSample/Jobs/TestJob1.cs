using Coravel.Invocable;

namespace JobSchedulingSample.Jobs
{
    public class TestJob1 : IInvocable
    {
        public TestJob1()
        {
            //get required facade from DI
        }

        public async Task Invoke()
        {
            try
            {
                //call the facade function to do a specific operation

                //just for testing functionality
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 1 starts running;");
                Thread.Sleep(1000);
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 1 finished;");
            }
            catch (Exception e)
            {
                //logging maybe 
            }
        }
    }
}
