using ConfigurationsPractical;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<User>(builder.Configuration.GetSection("user"));

var app = builder.Build();


app.Use(async (context, next) =>
{
 // Get value directly from the section
 string name = app.Configuration.GetSection("user:name").Value;
 
 //Binding options
 User user = new User();
 app.Configuration.GetSection("user").Bind(user);
 
 //From shorter syntax
 User user1 = app.Configuration.GetSection("user").Get<User>();
 
 //From a service

 IOptions<User> options = app.Services.GetService<IOptions<User>>();

 Console.WriteLine($"From the section : {name}");
 Console.WriteLine($"From the binding method : {user.Name}");
 Console.WriteLine($"From the shorter binding method : {user1.Name}");
 Console.WriteLine($"From services : {options.Value.Email}");
 
 
 await next();
});


/*
 * In terms of priority of values in the settings, the following order is considered:
 * - appsettings.json
 * - appsettings[env].json
 * - user secrets
 * - environment
 * - last cmd
 */

app.MapGet("/", () => app.Configuration["message"]);


app.Run();