namespace JobSchedulingSample.Jobs
{
    public class TestJob3
    {
        public TestJob3()
        {
            //get required facade from DI
        }

        public async Task Invoke()
        {
            try
            {
                //call the facade function to do a specific operation

                //just for testing functionality
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 3 starts running;");
                Thread.Sleep(1000);
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 3 finished;");
            }
            catch (Exception e)
            {
                //logging maybe 
            }
        }
    }
}
