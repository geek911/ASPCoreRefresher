using MiddlewarePractical;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ConsoleLogMiddleware>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
 app.UseDeveloperExceptionPage();
}


app.Use(async (context, next) =>
{
 await context.Response.WriteAsync("Before the dooms day\n");
 await next();
 await context.Response.WriteAsync("After the dooms day\n");

});

/*
 * Map branch-out from the main application
 */
app.Map("/test", async app =>
{
 app.Run(async context =>
 {
  await context.Response.WriteAsync("Cannot return to the main flow of the program\n");
 });
});


app.UseMiddleware<ConsoleLogMiddleware>();

/*
 * Run terminates the pipeline
 */

app.Run(async context =>
{
 await context.Response.WriteAsync("Hello World\n");
});

/*
 * Runs the application
 */
app.Run();