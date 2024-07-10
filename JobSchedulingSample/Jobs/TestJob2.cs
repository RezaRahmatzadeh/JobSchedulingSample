namespace JobSchedulingSample.Jobs
{
    public class TestJob2
    {
        public TestJob2()
        {
            //get required facade from DI
        }

        public async Task Invoke()
        {
            try
            {
                //call the facade function to do a specific operation

                //just for testing functionality
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 2 starts running;");
                Thread.Sleep(1000);
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ")}Test Job 2 finished;");
            }
            catch (Exception e)
            {
                //logging maybe 
            }
        }
    }
}
