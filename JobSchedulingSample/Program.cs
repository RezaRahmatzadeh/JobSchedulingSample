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

//Start scheduler service
app.Services.UseScheduler(scheduler =>
{
    scheduler.Schedule<TestJob1>().EverySeconds(5); //every 30 seconds

    scheduler.Schedule<TestJob1>().DailyAt(3, 30); //this numbers can be configurable and comes from appsettings or env variable

    scheduler.Schedule<TestJob1>().Cron("0 3 * * 0"); //this cron can be configurable and comes from appsettings or env variable
    //this cron 0 3 * * 0 indicate that this job will run at 03:00 am on every 0 day of every week (on every sunday)
});

app.Run();
