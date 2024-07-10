using Coravel;
using JobSchedulingSample.Jobs;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//Adding required services
builder.Services.AddRazorPages();


builder.Services.AddTransient<TestJob1>();
builder.Services.AddTransient<TestJob2>();
builder.Services.AddTransient<TestJob3>();

//Adding Coravel scheduler service
builder.Services.AddScheduler();

var app = builder.Build();

//Adjusting Http Pipelines 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

if (true) //Start scheduler service, maybe based on a configuration value (only main instance of the application run scheduler, others don't run it)
{
    app.Services.UseScheduler(scheduler =>
    {
        scheduler.Schedule<TestJob1>().EverySeconds(5); //every 30 seconds

        scheduler.Schedule<TestJob2>().DailyAt(3, 30); //this numbers can be configurable and comes from appsettings or env variable


        scheduler.OnWorker("TestJob3-Worker");//This will assign a dedicated thread for running the below job (TestJob3), it is helpful when running job on a web app to let the main app threads keep working their ways and not affect on them

        scheduler.Schedule<TestJob3>()
        .Cron("0 3 * * 0") //this cron can be configurable and comes from configurations. ["0 3 * * 0" indicates that this job will run at 03:00 on every 0th day of every week (on every sunday)]
        .PreventOverlapping(Guid.NewGuid().ToString()); //it can also prevent overlapping if a job runs in short schedules and might took times to complete sometimes

    });
}


app.Run();